using UnityEngine;
using UnityEngine.Events;

namespace AdventureQuest.UI
{
    public class MessageRenderer : MonoBehaviour
    {
        [field: SerializeField]
        public UnityEvent<string> OnTitleChange { get; private set; }
        [field: SerializeField]
        public UnityEvent<string> OnMessageChange { get; private set; }

        public void RenderMessage(Result.Message error)
        {
            OnTitleChange.Invoke(error.Title);
            OnMessageChange.Invoke(error.Text);
        }
    }
}