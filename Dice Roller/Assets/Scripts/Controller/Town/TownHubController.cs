using System.Collections;
using System.Collections.Generic;
using AdventureQuest.Character;
using UnityEngine;
using AdventureQuest.Scene;

namespace AdventureQuest.Town
{
    [RequireComponent(typeof(ObservableCharacter))]
    public class TownHubController : MonoBehaviour
    {
        private PlayerCharacter _character;
        
        public void EnterShop() => Location.Shop.Transition(_character);

        public void StatusScreen() => Location.Status.Transition(_character);

        protected void Awake()
        {
            ObservableCharacter _observable = GetComponent<ObservableCharacter>();
            // TODO: Should not have to cast.
            _observable.OnChange.AddListener((character) => _character = (PlayerCharacter)character);
        }

    }
}
