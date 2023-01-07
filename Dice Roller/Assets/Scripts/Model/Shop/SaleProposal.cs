namespace AdventureQuest.Shop
{
    public class SaleProposal
    {
        public SaleProposal(string title, string message, int value)
        {
            Title = title;
            Message = message;
            Value = value;
        }

        public string Title { get; }
        public int Value { get; }
        public string Message { get; }
    }
}