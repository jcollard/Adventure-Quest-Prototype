using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AdventureQuest.UI
{

    public class DraggableController : MonoBehaviour
    {
        public UnityEvent OnRelease { get; private set; } = new ();

        protected void Update()
        {
            CenterOnMouse();
            CheckDropped();
        }

        private void CenterOnMouse()
        {
            transform.position = Input.mousePosition;
        }
        private void CheckDropped()
        {
            if (!Input.GetMouseButton(0))
            {
                OnRelease.Invoke();
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
    }

}