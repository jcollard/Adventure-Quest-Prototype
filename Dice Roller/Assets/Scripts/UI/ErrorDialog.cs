using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AdventureQuest.UI
{
    public class ErrorDialog : MonoBehaviour
    {
        private ErrorDialogRenderer _renderer;
        public void Error(Result.Error error)
        {
            gameObject.SetActive(true);
            _renderer.RenderError(error);            
        }

        protected void Awake()
        {
            _renderer = transform.GetComponentInChildren<ErrorDialogRenderer>(true);
            if (_renderer == null)
            {
                throw new System.InvalidOperationException($"Unable to create Purchase Dialog. Could not find ErrorDialogRenderer");
            }
        }
    }
}
