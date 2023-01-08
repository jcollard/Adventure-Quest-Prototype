using AdventureQuest.Equipment;
using UnityEngine;

namespace AdventureQuest.Character
{
    [RequireComponent(typeof(ObservableCharacter))]
    public class CharacterController : MonoBehaviour
    {
        [SerializeField]
        private PlayerCharacter SerializedCharacter;
        private ICharacter _playerCharacter;

        [field: SerializeField]
        public bool LoadFromStorageOnLoad { get; private set; }
        private ObservableCharacter _observable;

        protected void Awake()
        {
            _observable = GetComponent<ObservableCharacter>();
            _observable.OnChange.AddListener((character) => _playerCharacter = character);
            _observable.OnChange.AddListener((character) => SerializedCharacter = (PlayerCharacter)character);
        }

        protected void Start()
        {
            if (LoadFromStorageOnLoad)
            {
                _observable.Observed = PlayerCharacter.Restore();
                return;
            }
        }

    }
}