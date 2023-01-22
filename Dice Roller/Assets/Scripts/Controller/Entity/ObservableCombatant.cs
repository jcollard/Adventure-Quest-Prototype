using AdventureQuest.Controller;
using AdventureQuest.Entity;

namespace AdventureQuest.Combat
{
    public class ObservableCombatant : ObservableComponent<ICombatant>  
    {
        protected void Start()
        {
            ICombatant enemy = Encounters.Forest.Build();
            Observed = enemy;
        }
    }
}