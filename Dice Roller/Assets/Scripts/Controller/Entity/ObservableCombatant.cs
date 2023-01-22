using AdventureQuest.Controller;
using AdventureQuest.Entity;

namespace AdventureQuest.Combat
{
    public class ObservableCombatant : ObservableComponent<ICombatant>  
    {
        protected void Start()
        {
            Observed = Encounters.CurrentEncounterBuilder.Build();
        }
    }
}