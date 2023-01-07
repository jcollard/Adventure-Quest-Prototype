using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using AdventureQuest.Controller;

namespace AdventureQuest.Equipment
{
    public class InventoryObservable : ObservableComponent<IHasInventory>
    {
        public IHasInventory Inventory { set => Observed = value; }
    }
}