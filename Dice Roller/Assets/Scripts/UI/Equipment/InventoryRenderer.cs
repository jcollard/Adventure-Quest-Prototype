using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;

using AdventureQuest.Character.Dice;
using AdventureQuest.Character;
using AdventureQuest.UI;

namespace AdventureQuest.Equipment
{

    public class InventoryRenderer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField]
        private InventoryObservable _defaultController;
        [SerializeField]
        private TextMeshProUGUI _name;
        [SerializeField]
        private InventoryItemRenderer _itemTemplate;
        [SerializeField]
        private Transform _itemList;
        private Transform _canvas;

        [field: SerializeField]
        public UnityEvent<IItem> OnSelectItem { get; private set; }
        [field: SerializeField]
        public UnityEvent<IItem> OnDragRelease { get; private set; }
        [field: SerializeField]
        public UnityEvent OnMouseEnter { get; private set; }
        [field: SerializeField]
        public UnityEvent OnMouseExit { get; private set; }

        // Start is called before the first frame update
        void Awake()
        {
            if (_defaultController != null)
            {
                _defaultController.OnChange.AddListener(Render);
            }
            _canvas = transform.GetComponentInParent<Canvas>().transform;
        }
        public void Render(IHasInventory hasInventory) => Render(hasInventory.Inventory);

        public void Render(IInventory inventory)
        {
            foreach (Transform child in _itemList)
            {
                Destroy(child.gameObject);
            }
            _name.text = inventory.Name;
            foreach (IItem item in inventory.Items)
            {
                InventoryItemRenderer entry = Instantiate(_itemTemplate, _itemList);
                entry.Render(item);
                entry.OnSelected.AddListener(() => OnSelectItem.Invoke(item));
                entry.OnDrag.AddListener(() =>
                {
                    InventoryItemRenderer itemRenderer = Instantiate(_itemTemplate, _canvas);
                    itemRenderer.DisableRaycast();
                    DraggableController draggable = itemRenderer.gameObject.AddComponent<DraggableController>();
                    itemRenderer.Render(item);
                    draggable.OnRelease.AddListener(() => OnDragRelease.Invoke(item));
                });
            }
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData) => OnMouseEnter.Invoke();
        void IPointerExitHandler.OnPointerExit(PointerEventData eventData) => OnMouseExit.Invoke();
    }

}