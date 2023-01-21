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
                if (victoryResult.Loot.Gold > 0)
                {
                    InventoryItemRenderer goldItem = Instantiate(_itemTemplate, transform);
                    goldItem.Render(new GoldItem(victoryResult.Loot.Gold));
                }                

                foreach(IItem item in victoryResult.Loot.Items)
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