using AdventureQuest.Character;
using AdventureQuest.Json;

namespace AdventureQuest.Equipment.Requirement
{
    public interface IRequirement : IJsonable
    {
        public bool MeetsRequirement(ICharacter character);

        public static IRequirement Deserialize(string json)
        {
            return UnityEngine.JsonUtility.FromJson<WeaponRequirement>(json);
        }
    }
}