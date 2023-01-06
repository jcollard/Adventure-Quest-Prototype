using UnityEngine;
using AdventureQuest.Controller;

namespace AdventureQuest.Character
{
    public class ObservableCharacter : Observable<ICharacter> 
    { 
        public ICharacter Character { set => Observed = value; }
    }
}