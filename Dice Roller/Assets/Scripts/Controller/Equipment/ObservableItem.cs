using AdventureQuest.Controller;

namespace AdventureQuest.Equipment
{
    public class ObservableItem : ObservableComponent<IItem>
    {
        public IItem Item { set => Observed = value; }
    }
}