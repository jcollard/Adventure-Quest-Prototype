namespace AdventureQuest.Dice
{
    public interface IRollable
    {
        public int Min { get; }
        public int Max { get; }
        public int Roll();
    }
}