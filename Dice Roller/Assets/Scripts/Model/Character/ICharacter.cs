using AdventureQuest.Equipment;
namespace AdventureQuest.Character
{
    public interface ICharacter : IHasInventory, IHasEquipment, IObservable<ICharacter>
    {
        public string Name { get; }
        public string PortraitSpriteKey { get; }
        public Abilities Abilities { get; }
        public int Gold { get; set; }
        public string AsJson { get; }

        public static ICharacter FromJson(string json)
        {
            return PlayerCharacter.Decode(json);
        }
    }
}