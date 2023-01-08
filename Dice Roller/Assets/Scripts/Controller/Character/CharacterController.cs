using AdventureQuest.Equipment;
using UnityEngine;

namespace AdventureQuest.Character
{
    [RequireComponent(typeof(ObservableCharacter))]
    public class CharacterController : MonoBehaviour
    {
        private ICharacter _playerCharacter;

        [field: SerializeField]
        public bool LoadFromStorageOnLoad { get; private set; }
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
                // _observable.Observed = PlayerCharacter.Restore();
                _observable.Observed = new PlayerCharacter(
                    "Darwin",
                    Abilities.Roll(),
                    "knight-1"
                );
                _observable.Observed.Inventory.Add(new Weapon("Bag of Apples", "A bag full of apples!",10, Dice.AbilityRoll.Parse("1d3")));
                _observable.Observed.Gold = 70;
                return;
            }
        }

    }
}