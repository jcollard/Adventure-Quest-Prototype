using System.Collections;
using System.Collections.Generic;
using AdventureQuest.UI;
using UnityEngine;
using UnityEngine.UI;

namespace AdventureQuest.Equipment.UI
{
    [RequireComponent(typeof(EquipmentSlotController))]
    public class EquipmentSlotRenderer : MonoBehaviour
    {
        [field: SerializeField]
        private SpriteDatabase _spriteDatabase;
        [field: SerializeField]
        private Image _image;
        public EquipmentSlotController Controller => gameObject.GetComponent<EquipmentSlotController>();
        public EquipmentSlot Slot => Controller.Slot;

        public void Render(IItem item)
        {
            Debug.Assert(_spriteDatabase != null, "Sprite Database was not initialized.");
            Debug.Assert(_image != null, "Image was not initialized.");
            SpriteEntry entry = _spriteDatabase.Get(item.ItemSpriteID);
            _image.sprite = entry.Sprite;
            _image.gameObject.SetActive(true);
        }

        public void ClearRender()
        {
            _image.gameObject.SetActive(false);
        }

        public Image CloneImage(Transform parent)
        {
            Image img = Instantiate(_image, parent);
            img.rectTransform.anchoredPosition = new Vector2(0, 0);
            Rect actualSize = _image.rectTransform.rect;
            img.rectTransform.sizeDelta = new Vector2(actualSize.width, actualSize.height);
            return img;
        }
    }
}