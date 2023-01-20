using AdventureQuest.Controller;
using AdventureQuest.Entity;

namespace AdventureQuest.Combat
{
    public class ObservableCombatant : ObservableComponent<ICombatant>  
    {
        protected void Start()
        {
            //TODO: This is a hack. Plz fix me!
            Observed = (ICombatant)Enemies.StrawManOfDoom.Build();
        }
    }
}