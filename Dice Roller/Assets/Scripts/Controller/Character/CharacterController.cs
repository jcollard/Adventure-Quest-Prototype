using AdventureQuest.Equipment;
using AdventureQuest.Equipment.Armor;
using UnityEngine;

namespace AdventureQuest.Character
{
    [RequireComponent(typeof(ObservableCharacter))]
    public class CharacterController : MonoBehaviour
    {
 
        private ICharacter _playerCharacter;

        [field: SerializeField]
        public bool LoadFromStorageOnLoad { get; private set; }
        [field: SerializeField]
        public bool Reinitialize { get; private set; }
        private ObservableCharacter _observable;

        protected void Awake()
        {
            _observable = GetComponent<ObservableCharacter>();
            _observable.OnChange.AddListener((character) => _playerCharacter = character);
        }

        protected void Start()
        {
            if (LoadFromStorageOnLoad)
            {
                _observable.Observed = PlayerCharacter.Restore();
            }

            if (Reinitialize)
            {
                ReinitializeCharacter();
            }
            
        }

        private void ReinitializeCharacter()
        {
            _observable.Observed.Gold = 50;
            _observable.Observed.Inventory.Clear();
            _observable.Observed.Inventory.Add(Weapons.Dagger);
            _observable.Observed.Inventory.Add(Weapons.Longsword);
            Armor leatherArmor = new ("Leather Armor", "leather_armor", "Itsa me! Leather Armor!", 25, 5, EquipmentSlot.Torso);
            Armor cap = new ("Leather Cap", "leather_cap", "Itsa me! Leather Armor!", 25, 5, EquipmentSlot.Head);
            Armor boots = new ("Leather Boots", "leather_boots", "Itsa me! Leather Armor!", 25, 5, EquipmentSlot.Feet);
            Armor pants = new ("Leather Cap", "leather_pants", "Itsa me! Leather Armor!", 25, 5, EquipmentSlot.Legs);
            _observable.Observed.Inventory.Add(leatherArmor);
            _observable.Observed.Inventory.Add(cap);
            _observable.Observed.Inventory.Add(pants);
            _observable.Observed.Inventory.Add(boots);
        }
    }
}