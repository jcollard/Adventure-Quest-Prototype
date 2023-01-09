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
                _observable.Observed = PlayerCharacter.Restore();
                return;
            }
        }
    }
}