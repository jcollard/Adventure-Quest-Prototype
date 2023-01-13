
using UnityEngine;
using AdventureQuest.Equipment;
using AdventureQuest.Character.Dice;
using AdventureQuest.Character;
using UnityEngine.Events;
using AdventureQuest.Result;
using AdventureQuest.Scene;

namespace AdventureQuest.Shop
{
    [RequireComponent(typeof(ObservableShop), typeof(ObservableItem), typeof(ObservableCharacter))]
    public class ShopController : MonoBehaviour
    {

        private ObservableItem _selected;
        private ObservableShop _shop;
        private ObservableCharacter _character;

        [field: SerializeField]
        public UnityEvent<Message> OnPurchase { get; private set; }
        [field: SerializeField]
        public UnityEvent<SaleProposal> OnEvaluateItem { get; private set; }
        [field: SerializeField]
        public UnityEvent<Message> OnSell { get; private set; }
        [field: SerializeField]
        public UnityEvent<Message> OnError { get; private set; }

        private ObservableItem Selected 
        {
            get
            {
                if (_selected == null)
                {
                    _selected = GetComponent<ObservableItem>();
                }
                return _selected;
            }
        }

        private ObservableShop Shop 
        {
            get
            {
                if (_shop == null)
                {
                    _shop = GetComponent<ObservableShop>();
                }
                return _shop;
            }
        }

        private ObservableCharacter Character
        {
            get
            {
                if (_character == null)
                {
                    _character = GetComponent<ObservableCharacter>();
                }
                return _character;
            }
        }

        protected void Start()
        {
            
            IInventory shopInventory = new Inventory("Wilfred's Weapons");
            shopInventory.Add(Weapons.Dagger);
            shopInventory.Add(Weapons.ShortSword);
            shopInventory.Add(Weapons.Longsword);
            shopInventory.Add(Weapons.BattleAxe);
            Shop shop = new Shop("Wilfred's Weapons", shopInventory);

            Shop.Observed = shop;
        }

        public void Purchase()
        {
            IResult result = Shop.Observed.Purchase(Selected.Observed, Character.Observed);
            SendMessage(result);            
        }

        public void EvaluateItem(IItem toEvaluate) 
        {
            Selected.Observed = toEvaluate;
            SaleProposal proposal = Shop.Observed.EvaluateItem(toEvaluate, Character.Observed);
            OnEvaluateItem.Invoke(proposal);
        }

        public void Sell()
        {
            IResult result = Shop.Observed.Sell(Selected.Observed, Character.Observed);
            SendMessage(result);
        }

        // TODO: Consider storing a PlayerCharacter rather than a Character
        public void ExitShop(string targetScene) => Location.Town.Transition((PlayerCharacter)Character.Observed);

        private void SendMessage(IResult result)
        {
            Message message = new ($"{Shop.Observed.Name}", result.Message);
            UnityEvent<Message> handlerEvent = result switch {
                Failure => OnError,
                Success => OnPurchase,
                _ => throw new System.InvalidOperationException($"Could not determine correct event to use for message."),

            };
            handlerEvent.Invoke(message);
        }
    }    
}