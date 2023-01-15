using AdventureQuest.Controller;
using UnityEngine;

namespace AdventureQuest.Entity
{
    public class ObservableCombatant : ObservableComponent<ICombatant>  
    {
        protected void Start()
        {
            Observed = Enemies.Slime.Build();
        }
    }
}