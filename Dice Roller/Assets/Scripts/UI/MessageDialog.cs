using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AdventureQuest.UI
{
    public class MessageDialog : MonoBehaviour
    {
        private MessageRenderer _renderer;
        public void Message(Result.Message Message)
        {
            gameObject.SetActive(true);
            _renderer.RenderMessage(Message);            
        }

        protected void Awake()
        {
            _renderer = transform.GetComponentInChildren<MessageRenderer>(true);
            if (_renderer == null)
            {
                throw new System.InvalidOperationException($"Unable to create Purchase Dialog. Could not find MessageRenderer");
            }
        }
    }
}
