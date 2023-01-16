
using UnityEngine;
using UnityEngine.Events;
using AdventureQuest.Entity;
using AdventureQuest.Character;

namespace AdventureQuest.Combat
{
    public class CombatController : MonoBehaviour
    {
        private CombatManager _manager;
        private ICharacter _player;
        private ICombatant _enemy;

        [field: SerializeField]
        public UnityEvent<CombatResult> OnCombatEvent { get; private set; } = new();

        public void PlayerAttack()
        {
            _manager.ProcessRound();
        }

        public void InitializeCombat(ICharacter player, ICombatant enemy)
        {
            if (_manager != null || player == null || enemy == null) { return; }
            //TODO: Code Smell, should probably have an "initialize" method that is called somewhere
            _manager = new CombatManager(player, enemy);
            _manager.OnChange += (result) => OnCombatEvent.Invoke(result);
            _manager.InitializeCombat();
        }

        protected void Awake()
        {
            var character = GetComponentInChildren<ObservableCharacter>();
            var enemy = GetComponentInChildren<ObservableCombatant>();
            Debug.Assert(character != null, "Could not locate CharacterController in children.");
            Debug.Assert(enemy != null, "Could not locate CombatantController in children.");
            character.OnChange.AddListener(InitPlayer);
            enemy.OnChange.AddListener(InitEnemy);
        }

        private void InitPlayer(ICharacter player)
        {
            _player = player;
            InitializeCombat(_player, _enemy);
        }

        private void InitEnemy(ICombatant enemy)
        {
            _enemy = enemy;
            InitializeCombat(_player, _enemy);
        }
    }
}
