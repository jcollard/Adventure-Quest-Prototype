using AdventureQuest.Entity;
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

            ICharacter player = _observable.Observed;
            player.Traits.Get(Trait.Health).Value = 25;
            player.Inventory.Clear();
            player.Inventory.Add(Armors.ChainHelmet);
            player.Inventory.Add(new HealthPotion());
            player.Inventory.Add(new Bomb("Fire Bomb"));
        }

    }
}