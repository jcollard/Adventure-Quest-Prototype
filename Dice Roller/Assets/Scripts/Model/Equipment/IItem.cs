
namespace AdventureQuest.Equipment
{
    public interface IItem
    {
        public string Name { get; }
        public string Description { get; }
        public int Cost { get; }
        public IItem Duplicate();
    }
}