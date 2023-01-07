using UnityEngine;
using AdventureQuest.Controller;

namespace AdventureQuest.Character
{
    public class ObservableCharacter : ObservableComponent<ICharacter> 
    { 
        public ICharacter Character { set => Observed = value; }
    }
}