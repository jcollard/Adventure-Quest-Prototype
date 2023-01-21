using AdventureQuest.Equipment;
using UnityEngine;

namespace AdventureQuest.Combat.UI
{
    public class LootItemsRenderer : CombatResultRenderer
    {
        [SerializeField]
        private InventoryItemRenderer _itemTemplate;

        public override void Render(CombatResult result)
        {
            foreach(Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            if (result is VictoryResult victoryResult)
            {
                foreach(IItem item in victoryResult.Loot)
                {
                    InventoryItemRenderer itemRenderer = Instantiate(_itemTemplate, transform);
                    itemRenderer.Render(item);
                }
                gameObject.SetActive(true);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}