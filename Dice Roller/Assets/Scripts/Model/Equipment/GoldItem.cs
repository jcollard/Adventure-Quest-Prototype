
using System.Diagnostics;
using AdventureQuest.Json;

namespace AdventureQuest.Equipment
{
    public class GoldItem : IItem
    {
        [UnityEngine.SerializeField]
        private int _amount;

        public GoldItem(int amount)
        {
            UnityEngine.Debug.Assert(amount >= 0, "GoldItem must have at least 0 gold.");
            _amount = amount;
        }

        public string ItemSpriteID => throw new System.NotImplementedException();
        public string Name => $"{_amount} Gold";
        public string Description => $"{_amount} gold coins.";
        public int Cost => _amount;
        public string AsJson => UnityEngine.JsonUtility.ToJson(this);

        public IItem Duplicate() => new GoldItem(_amount);
    }
}