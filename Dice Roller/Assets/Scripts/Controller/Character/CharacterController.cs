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
            _observable.Observed.Inventory.Add(Armors.LeatherArmor);
            _observable.Observed.Inventory.Add(Armors.ClothPants);
            _observable.Observed.Inventory.Add(Armors.LeatherBoots);
            _observable.Observed.Inventory.Add(Armors.ChainHelmet);
        }
    }
}