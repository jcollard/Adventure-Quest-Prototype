using AdventureQuest.Equipment;
namespace AdventureQuest.Character
{
    public interface ICharacter : IHasInventory, IHasEquipment, IHasAbilities, IObservable<ICharacter>
    {
        public string Name { get; }
        public string PortraitSpriteKey { get; }
        public int Gold { get; set; }
        public string AsJson { get; }

        public static ICharacter FromJson(string json)
        {
            return PlayerCharacter.Decode(json);
        }
    }
}