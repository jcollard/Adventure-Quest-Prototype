using System.Collections.Generic;
using AdventureQuest.Character;
using AdventureQuest.Entity;
using System.Diagnostics;

namespace AdventureQuest.Combat
{
    public class CombatResult
    {
        private readonly List<string> _messages = new();
        public CombatResult() { }

        public string Message => string.Join("\n", _messages);
        public bool IsCombatOver { get; set; } = false;

        public CombatResult Add(string message)
        {
            _messages.Add(message);
            return this;
        }
    }
}