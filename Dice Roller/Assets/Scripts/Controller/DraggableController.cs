using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace AdventureQuest.UI
{

    public class DraggableController : MonoBehaviour
    {
        
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
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
    }

}