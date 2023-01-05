using AdventureQuest.Character;

namespace AdventureQuest.Equipment.Requirement
{
    public interface IRequirement
    {
        public bool MeetsRequirement(ICharacter character);
    }
}