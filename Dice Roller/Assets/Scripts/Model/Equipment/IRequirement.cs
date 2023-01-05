using AdventureQuest.Character;

namespace AdventureQuest.Equipment
{
    public interface IRequirement
    {
        public bool MeetsRequirement(ICharacter character);
    }
}