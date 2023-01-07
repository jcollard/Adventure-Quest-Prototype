namespace AdventureQuest.Result
{
    public class Message
    {
        public Message(string title, string text)
        {
            Title = title;
            Text = text;
        }
        
        public string Title { get; }
        public string Text { get; }
    }
}