
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
            return serializer.ClassInformation switch 
            {
                "Armor" => UnityEngine.JsonUtility.FromJson<Armor.Armor>(serializer.Json),
                "Weapon" => UnityEngine.JsonUtility.FromJson<Weapon>(serializer.Json),
                _ => throw new System.FormatException($"Could not deserialize IItem from \"{json}\"")
            };
            
        }

        public static string ToJson(IItem item) => JsonSerializer.ToJson(item);
    }
}