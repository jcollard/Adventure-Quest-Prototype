using UnityEngine;
using AdventureQuest.Controller;

namespace AdventureQuest.Character
{
    public class ObservableCharacter : ObservableComponent<ICharacter> 
    { 
        public ICharacter Character { set => Observed = value; }

        public override ICharacter Observed
        {
            get => base.Observed;
            set
            {
                if (base.Observed != null)
                {
                    Observed.OnChange -= Change;
                }
                base.Observed = value;
                Observed.OnChange += Change;
            }
        }

        private void Change(ICharacter character) => base.Change();
    }
}