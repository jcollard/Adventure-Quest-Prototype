using AdventureQuest.Character;

namespace AdventureQuest.Equipment.Requirement
{
    public class WeaponRequirement : IRequirement
    {
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