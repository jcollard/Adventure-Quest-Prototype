using System.Collections.Generic;

namespace AdventureQuest.Combat
{
    public class CombatResult
    {
        private readonly List<string> _messages = new();
        public CombatResult(string title) 
        { 
            Title = title;
        }

        public string Title { get; set; }
        public string Message => string.Join("\n", _messages);
        public bool IsCombatOver { get; set; } = false;

        public CombatResult Add(string message)
        {
            _messages.Add(message);
            return this;
        }
    }
}