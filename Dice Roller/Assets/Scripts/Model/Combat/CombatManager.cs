using System.Collections.Generic;
using AdventureQuest.Character;
using AdventureQuest.Entity;
using System.Diagnostics;
using AdventureQuest.Character.Dice;
using AdventureQuest.Equipment;

namespace AdventureQuest.Combat
{
    public class CombatManager : IObservable<CombatResult>
    {
        private readonly Queue<ICombatant> _turnQueue = new();
        public event System.Action<CombatResult> OnChange;

        public CombatManager(ICharacter player, ICombatant enemy)
        {
            Debug.Assert(player != null, "Player should not be null");
            Debug.Assert(enemy != null, "Enemy should not be null");
            Player = player;
            PlayerAgent = new PlayerAgent(player);
            Enemy = enemy;
        }

        public ICombatant NextToAct => _turnQueue.Peek();
        public PlayerAgent PlayerAgent { get; private set; }
        public ICharacter Player { get; private set; }
        public ICombatant Enemy { get; private set; }

        public CombatResult InitializeCombat()
        {
            // TODO: Consider writing a method on ICombatant called Initialize
            Enemy.Effects.Clear();
            Player.Effects.Clear();
            CombatResult result = new("Combat Begins!");
            _turnQueue.Clear();
            result.Add($"A {Enemy.Name} appears!");
            AbilityRoll initiativeRoll = AbilityRoll.Parse($"1d20 + {Ability.Agility}");
            int playerRoll = initiativeRoll.Roll(Player.CombatAbilities);
            int enemyRoll = initiativeRoll.Roll(Enemy.CombatAbilities);

            // TODO: Consider using Agility to break ties AND if that is tied, flip a coin?
            if (playerRoll == enemyRoll)
            {
                foreach (ICombatant c in CombatExtensions.FindFastest(Player, Enemy))
                {
                    _turnQueue.Enqueue(c);
                }
            }
            else if (playerRoll > enemyRoll)
            {
                _turnQueue.Enqueue(Player);
                _turnQueue.Enqueue(Enemy);
            }
            else
            {
                _turnQueue.Enqueue(Enemy);
                _turnQueue.Enqueue(Player);
            }
            ICombatant firstToAct = _turnQueue.Peek();
            result.Add($"{firstToAct.Name} moves to act!");
            OnChange.Invoke(result);
            StartNextRound();
            return result;
        }

        private void StartNextRound()
        {
            ICombatant nextToAct = _turnQueue.Peek();
            ICombatAgent agent = nextToAct switch
            {
                PlayerCharacter => PlayerAgent,
                Entity.Enemy => new EnemyAgent(),
                _ => throw new System.Exception("Something terrible has happened."),
            };

            agent.WaitForAction(this, (ICombatAction action) =>
            {
                ICombatant acting = _turnQueue.Dequeue();
                CombatResult result = action.PerformAction();
                _turnQueue.Enqueue(acting);
                OnChange.Invoke(result);

                if (!CheckEndOfCombat(result))
                {
                    ICombatant nextToAct = _turnQueue.Peek();
                    CombatResult tickResult = nextToAct.Tick();
                    OnChange.Invoke(tickResult);
                    StartNextRound();
                }
            });
        }

        private bool CheckEndOfCombat(CombatResult result)
        {
            if (result.IsCombatOver) { return true; }

            if (Player.Traits.Get(Trait.Health).Value <= 0)
            {
                DefeatResult playerDeath = new() ;
                playerDeath.Add($"{Player.Name} dies!");
                OnChange.Invoke(playerDeath);
                return true;
            }

            if (Enemy.Traits.Get(Trait.Health).Value <= 0)
            {
                Loot loot = Loot.NoLoot;
                if (Enemy is Entity.Enemy lootableEnemy)
                {
                    loot = lootableEnemy.Loot;
                }
                VictoryResult enemyDeath = new(loot);
                enemyDeath.Add($"{Enemy.Name} dies!");
                Player.Gold += loot.Gold;
                foreach (IItem item in loot.Items)
                {
                    Player.Inventory.Add(item);
                }
                OnChange.Invoke(enemyDeath);
                return true;
            }
            return false;
        }
    }
}