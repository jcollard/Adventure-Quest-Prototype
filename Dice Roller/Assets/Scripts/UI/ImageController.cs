using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AdventureQuest.UI
{

    [RequireComponent(typeof(Image))]
    public class ImageController : MonoBehaviour
    {
        private Image _image;
        private Image Image
        {
            get
            {
                if (_image == null)
                {
                    _image = GetComponent<Image>();
                }
                return _image;
            }
        }
        public float Alpha 
        { 
            set
            {
                Color orig = Image.color;
                Image.color = new Color(orig.r, orig.g, orig.b, value);
            }
        }
    }

}