namespace AdventureQuest.Combat
{
    public interface ICombatAgent
    {
        public void WaitForAction(CombatManager manager, System.Action<ICombatAction> onAction);
    }
}