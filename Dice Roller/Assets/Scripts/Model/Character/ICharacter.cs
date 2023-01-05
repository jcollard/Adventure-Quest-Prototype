using AdventureQuest.Equipment;
namespace AdventureQuest.Character
{
    public interface ICharacter
    {
        public string Name { get; }
        public string PortraitSpriteKey { get; }
        public Abilities Abilities { get; }
        public IEquipmentManifest Equipment { get; }
    }
}