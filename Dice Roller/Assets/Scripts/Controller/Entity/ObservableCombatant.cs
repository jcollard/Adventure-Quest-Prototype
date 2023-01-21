using AdventureQuest.Controller;
using AdventureQuest.Entity;
using AdventureQuest.Equipment;

namespace AdventureQuest.Combat
{
    public class ObservableCombatant : ObservableComponent<ICombatant>  
    {
        protected void Start()
        {
            //TODO: This is a hack. Plz fix me!
            Enemy enemy = Enemies.Slime.Build();
            Observed = (ICombatant)enemy;
        }
    }
}