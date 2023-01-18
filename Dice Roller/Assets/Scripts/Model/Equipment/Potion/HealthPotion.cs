using AdventureQuest.Combat;
using AdventureQuest.Character.Dice;

namespace AdventureQuest.Equipment
{
    public class HealthPotion : IUseable
    {
        private static AbilityRoll s_Roll => AbilityRoll.Parse("1d6 + 4");
        public string ItemSpriteID => throw new System.NotImplementedException();
        public string Name => "Health Potion";
        public string Description => "A health potion is a magical concoction that can restore a character's vitality, restoring some of their health.";
        public int Cost => 5;
        public string AsJson => UnityEngine.JsonUtility.ToJson(this);
        public IItem Duplicate() => new HealthPotion();

        public string Use(ICombatant user)
        {
            // TODO: Remove from inventory?
            int amount = s_Roll.Roll(user);
            user.Traits.Get(Entity.Trait.Health).Value += amount;
            return $"{user.Name} drinks a Health Potion and restores {amount} health.";
        }
    }
}