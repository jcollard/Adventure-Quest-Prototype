using AdventureQuest.Character;

namespace AdventureQuest.Equipment.Requirement
{
    [System.Serializable]
    public class WeaponRequirement : IRequirement
    {
        public string AsJson => UnityEngine.JsonUtility.ToJson(this);

        [field: UnityEngine.SerializeField]
        public string ClassInformation { get; private set; } = "WeaponRequirement";

        public bool MeetsRequirement(ICharacter character)
        {
            foreach(IEquipable equipped in character.Equipment.Equipped.Values)
            {
                if (equipped is Weapon) { return false; }
            }
            return true;
        }
    }
}