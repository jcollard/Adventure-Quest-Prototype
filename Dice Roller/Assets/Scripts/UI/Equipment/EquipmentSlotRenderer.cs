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
        public EquipmentSlot Slot => gameObject.GetComponent<EquipmentSlotController>().Slot;

        public void Render(IItem item)
        {
            Debug.Assert(_spriteDatabase != null, "Sprite Database was not initialized.");
            Debug.Assert(_image != null, "Image was not initialized.");
            SpriteEntry entry = _spriteDatabase.Get(item.ItemSpriteID);
            _image.sprite = entry.Sprite;
            _image.gameObject.SetActive(true);
        }
    }
}