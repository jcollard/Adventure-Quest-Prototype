using System.Collections.Generic;
using AdventureQuest.Character;
using AdventureQuest.Equipment.Requirement;

namespace AdventureQuest.Equipment
{
    public interface IEquipable : IItem
    {
        public HashSet<EquipmentSlot> Slots { get; }
        public List<IRequirement> Requirements { get; }

        public static IEquipable FromJson(string json)
        {
            // TODO: Better serialization is required for extensibility
            try
            {
                return UnityEngine.JsonUtility.FromJson<Weapon>(json);
            }
            catch
            {

            }
            throw new System.Exception("Could not load IEquipable");
        }

    }
}