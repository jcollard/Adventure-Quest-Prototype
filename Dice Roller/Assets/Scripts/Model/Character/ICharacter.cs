using AdventureQuest.Equipment;
using AdventureQuest.Combat;

namespace AdventureQuest.Character
{
    public interface ICharacter : IHasInventory, IHasEquipment, ICombatant, IObservable<ICharacter>
    {
        public int Gold { get; set; }
        public string AsJson { get; }

        public static ICharacter FromJson(string json)
        {
            return PlayerCharacter.Decode(json);
        }
    }
}