using AdventureQuest.Controller;
using UnityEngine;

namespace AdventureQuest.Entity
{
    public class ObservableCombatant : ObservableComponent<ICombatant>  
    {
        protected void Start()
        {
            //TODO: This is a hack. Plz fix me!
            Observed = Enemies.Slime.Build();
        }
    }
}