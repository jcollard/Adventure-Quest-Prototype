using AdventureQuest.Equipment;
using AdventureQuest.Entity;

namespace AdventureQuest.Character
{
    public interface ICharacter : IHasInventory, IHasEquipment, IHasAbilities, IHasTraits, IObservable<ICharacter>
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