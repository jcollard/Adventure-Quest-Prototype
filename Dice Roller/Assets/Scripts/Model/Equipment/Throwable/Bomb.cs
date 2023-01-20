using AdventureQuest.Combat;
using AdventureQuest.Dice;

namespace AdventureQuest.Equipment
{
    public class Bomb : IThrowable
    {
        private static readonly IRollable s_Damage = DicePool.Parse("1d6");
        public Bomb(string name)
        {
            Name = name;
        }

        public bool IsConsumedOnUse => true;
        public string ItemSpriteID => throw new System.NotImplementedException();
        [field: UnityEngine.SerializeField]
        public string Name { get; private set; }
        public string Description => "This bomb is a small, round device with a bright red fuse. Once thrown, it will explode, dealing a moderate amount of damage to any enemies in the vicinity.";
        public int Cost => 10;
        public string AsJson => UnityEngine.JsonUtility.ToJson(this);

        public IItem Duplicate() => new Bomb(Name);

        public string Throw(ICombatant user, ICombatant target)
        {
            int damage = s_Damage.Roll();
            target.Traits.Get(Entity.Trait.Health).Value -= damage;
            return $"{user.Name} lobs a {Name}!\nThe {Name} explodes dealing {damage} damage to {target.Name}";
        }

        public string Use(ICombatant user) => $"{Name} must be thrown.";
    }
}