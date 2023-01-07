using UnityEngine;
using UnityEngine.Events;

namespace AdventureQuest.UI
{
    public class ErrorDialogRenderer : MonoBehaviour
    {
        [field: SerializeField]
        public UnityEvent<string> OnErrorTitle { get; private set; }
        [field: SerializeField]
        public UnityEvent<string> OnErrorMessage { get; private set; }

        public void RenderError(Result.Error error)
        {
            OnErrorTitle.Invoke(error.Title);
            OnErrorMessage.Invoke(error.Message);
        }
    }
}