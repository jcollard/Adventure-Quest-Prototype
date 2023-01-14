using AdventureQuest.Equipment;
using AdventureQuest.Equipment.Armor;
using UnityEngine;

namespace AdventureQuest.Character
{
    [RequireComponent(typeof(ObservableCharacter))]
    public class CharacterController : MonoBehaviour
    {
 
        private ObservableCharacter _observable;
        public ICharacter PlayerCharacter { get; private set; }

        [field: SerializeField]
        public bool LoadFromStorageOnLoad { get; private set; }
        [field: SerializeField]
        public bool Reinitialize { get; private set; }
    
        protected void Awake()
        {
            _observable = GetComponent<ObservableCharacter>();
            _observable.OnChange.AddListener((character) => PlayerCharacter = character);
        }

        protected void Start()
        {
            if (LoadFromStorageOnLoad)
            {
                _observable.Observed = Character.PlayerCharacter.Restore();
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
            _observable.Observed.Equipment.Equip(Armors.LeatherArmor, EquipmentSlot.Torso, _observable.Observed);
            _observable.Observed.Equipment.Equip(Armors.ClothPants, EquipmentSlot.Legs, _observable.Observed);
            _observable.Observed.Inventory.Add(Armors.LeatherBoots);
            _observable.Observed.Inventory.Add(Armors.ChainHelmet);

            InvokeRepeating(nameof(ReduceTraits), 1, 1);
        }

        private void ReduceTraits()
        {
            _observable.Observed.Traits.Get(Entity.Trait.Health).Value--;
            _observable.Observed.Traits.Get(Entity.Trait.Stamina).Value--;
        }
    }
}