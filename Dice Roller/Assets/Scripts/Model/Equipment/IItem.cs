
namespace AdventureQuest.Equipment
{
    public interface IItem
    {
        public string Name { get; }
        public string Description { get; }
        public int Cost { get; }
        public IItem Duplicate();
        
        public static IItem FromJson(string json)
        {
            // TODO: Better serialization is required for extensibility
            try
            {
                return UnityEngine.JsonUtility.FromJson<Weapon>(json);
            }
            catch
            {

            }
            throw new System.Exception("Could not load IEquipable");
        }
    }
}