using System.Collections;
using System.Collections.Generic;
using AdventureQuest.Character;
using UnityEngine;
using AdventureQuest.Scene;
using AdventureQuest.Shop;
using AdventureQuest.Combat;

namespace AdventureQuest.Town
{
    [RequireComponent(typeof(ObservableCharacter))]
    public class TownHubController : MonoBehaviour
    {
        private PlayerCharacter _character;
        
        public void EnterWeaponShop() 
        {
            Shops.CurrentShop = Shops.WilfredsWeapons;
            Location.Shop.Transition(_character);
        }
        public void EnterArmorShop()
        {
            Shops.CurrentShop = Shops.AbdulsArmor;
            Location.Shop.Transition(_character);
        }

        public void EnterAlchemyShop()
        {
            Shops.CurrentShop = Shops.AlchemyShop;
            Location.Shop.Transition(_character);
        }

        


        public void StatusScreen() => Location.Status.Transition(_character);

        public void EnterCemetery()
        { 
            Encounters.CurrentEncounterBuilder = Encounters.Cemetery;
            Location.Combat.Transition(_character);
        }

        public void EnterForest()
        {
            Encounters.CurrentEncounterBuilder = Encounters.Forest;
            Location.Combat.Transition(_character);
        }

        protected void Awake()
        {
            ObservableCharacter _observable = GetComponent<ObservableCharacter>();
            // TODO: Should not have to cast.
            _observable.OnChange.AddListener((character) => _character = (PlayerCharacter)character);
        }

    }
}
