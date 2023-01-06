using AdventureQuest.Controller;

namespace AdventureQuest.Equipment
{
    public class ObservableItem : Observable<IItem>
    {
        public IItem Item { set => Observed = value; }
    }
}