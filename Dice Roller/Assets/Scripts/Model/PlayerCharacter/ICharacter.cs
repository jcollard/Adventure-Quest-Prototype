namespace AdventureQuest.Character
{
    public interface ICharacter
    {
        public string Name { get; }
        public string PortraitSpriteKey { get; }
        public Abilities Abilities { get; }
    }
}