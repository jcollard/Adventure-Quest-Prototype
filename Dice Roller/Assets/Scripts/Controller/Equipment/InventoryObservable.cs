using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using AdventureQuest.Controller;

namespace AdventureQuest.Equipment
{
    public class InventoryObservable : Observable<IHasInventory>
    {
        public IHasInventory Inventory { set => Observed = value; }
    }
}