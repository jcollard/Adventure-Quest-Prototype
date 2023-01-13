
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
        
        public static IItem FromJson(string json)
        {
            // TODO: Better serialization is required for extensibility
            JsonSerializer serializer = UnityEngine.JsonUtility.FromJson<JsonSerializer>(json);
            return (IItem)UnityEngine.JsonUtility.FromJson(serializer.Json, serializer.ClassType);
        }

        public static string ToJson(IItem item) => JsonSerializer.ToJson(item);
    }
}