using UnityEngine;
using UnityEngine.Events;
using TMPro;

using AdventureQuest.Character.Dice;
using AdventureQuest.Character;

namespace AdventureQuest.Equipment
{

    public class ItemInfoRenderer : MonoBehaviour
    {
        [field: SerializeField]
        public UnityEvent<string> OnChangeCost { get; private set; }
        [field: SerializeField]
        public UnityEvent<string> OnChangeName { get; private set; }
        [field: SerializeField]
        public UnityEvent<string> OnChangeDescription { get; private set; }
        public void RenderItemInfo(IItem item)
        {
            OnChangeName.Invoke(item.Name);
            OnChangeCost.Invoke(item.Cost.ToString());
            OnChangeDescription.Invoke(item.Description);
        }
    }
}