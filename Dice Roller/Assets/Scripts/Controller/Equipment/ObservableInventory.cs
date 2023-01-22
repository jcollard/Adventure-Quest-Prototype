using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using AdventureQuest.Controller;

namespace AdventureQuest.Equipment
{
    public class ObservableInventory : ObservableComponent<IHasInventory>
    {
        public IHasInventory Inventory
        {
            set
            {
                if (Observed != null)
                {
                    Observed.Inventory.OnChange -= ForwardUpdate;
                }
                Observed = value;
                Observed.Inventory.OnChange += ForwardUpdate;
                ForwardUpdate(Observed.Inventory);
            }
        }

        private void ForwardUpdate(IInventory toUpdate)
        {
            Change();
        }

    }
}