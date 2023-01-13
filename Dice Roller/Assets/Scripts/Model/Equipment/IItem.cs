
using AdventureQuest.Json;

namespace AdventureQuest.Equipment
{
    public interface IItem : IJsonable
    {
        public string ItemSpriteID { get; }
        public string Name { get; }
        public string Description { get; }
        public int Cost { get; }
        public IItem Duplicate();
    }
}