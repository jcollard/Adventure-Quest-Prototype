using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AdventureQuest.Controller;
using UnityEngine.Events;

namespace AdventureQuest.Shop
{
    public class ObservableShop : ObservableComponent<IShop> 
    {
        public IShop Shop { set => Observed = value; }
    } 
}