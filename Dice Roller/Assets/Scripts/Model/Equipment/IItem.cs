
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
            
            if (json.Contains("\"<ClassInformation>k__BackingField\":\"Armor\""))
            {
                return UnityEngine.JsonUtility.FromJson<Armor.Armor>(json);
            }
            if (json.Contains("\"<ClassInformation>k__BackingField\":\"Weapon\""))
            {
                return UnityEngine.JsonUtility.FromJson<Weapon>(json);
            }
            throw new System.FormatException($"Could not deserialize IItem from \"{json}\"");
        }
    }
}