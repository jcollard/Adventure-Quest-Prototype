using AdventureQuest.Entity;
using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Linq;

namespace AdventureQuest.Combat.UI
{
    /// <summary>
    /// CombatLogRenderer is a class used to render combat log to a text mesh pro uGui text area.
    /// </summary>
    public class CombatLogRenderer : MonoBehaviour
    {
        /// <summary>
        /// The TextMeshProUGUI instance used for output.
        /// </summary>
        private TextMeshProUGUI _textArea;

        /// <summary>
        /// Queue used to store characters that need to be rendered.
        /// </summary>
        private Queue<char> _renderQueue = new();

        /// <summary>
        /// Time when the last character was rendered.
        /// </summary>
        private float _lastRenderTime;

        /// <summary>
        /// Number of characters to render per second.
        /// </summary>
        [field: SerializeField]
        public float CharactersPerSecond { get; private set; }

        /// <summary>
        /// Enqueues the provided AttackResult to the render queue.
        /// </summary>
        /// <param name="result">AttackResult to enqueue.</param>
        public void Enqueue(AttackResult result)
        {
            foreach (char ch in result.Description.ToCharArray())
            {
                _renderQueue.Enqueue(ch);
            }
        }

        /// <summary>
        /// Unity Update Method
        /// </summary>
        protected void Update()
        {
            ProcessQueue();
        }

        /// <summary>
        /// Unity Awake Method
        /// </summary>
        protected void Awake()
        {
            _textArea = GetComponentInChildren<TextMeshProUGUI>();
            Debug.Assert(_textArea != null, "The Combat Log does not have a _textArea to output to.");
        }

        /// <summary>
        /// Processes the render queue.
        /// </summary>
        private void ProcessQueue()
        {
            if (_renderQueue.Count < 1)
            {
                _lastRenderTime = Time.time;
                return;
            }

            float secondsPassed = (Time.time - _lastRenderTime);
            int charactersToRender = (int)(secondsPassed * CharactersPerSecond);
            int count = System.Math.Clamp(charactersToRender, 0, _renderQueue.Count);
            if (count <= 0) { return; }

            var charsToAdd = Enumerable.Range(0, count)
                                        .Select(_ => _renderQueue.Dequeue());
            string toAdd = string.Join("", charsToAdd);
            _textArea.text += toAdd;
            _lastRenderTime = Time.time;
        }
    }
}