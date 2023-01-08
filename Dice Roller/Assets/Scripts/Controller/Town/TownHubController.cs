using System.Collections;
using System.Collections.Generic;
using AdventureQuest.Character;
using AdventureQuest.Shop;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AdventureQuest.Town
{
    [RequireComponent(typeof(ObservableCharacter))]
    public class TownHubController : MonoBehaviour
    {
        private PlayerCharacter _character;
        
        public void EnterShop()
        {
            PlayerCharacter.Store(_character);
            SceneManager.LoadScene("Shop");
        }

        protected void Awake()
        {
            ObservableCharacter _observable = GetComponent<ObservableCharacter>();
            // TODO: Should not have to cast.
            _observable.OnChange.AddListener((character) => _character = (PlayerCharacter)character);
        }

    }
}
