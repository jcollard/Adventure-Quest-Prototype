using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace AdventureQuest.Entity.UI
{
    public class TraitValueRenderer : MonoBehaviour
    {
        [SerializeField]
        private Image _valueBar;
        [SerializeField]
        private TextMeshProUGUI _label;
        private TraitValue _observing;

        public TraitValue Observing
        {
            set
            {
                if (_observing != value)
                {
                    if (_observing != null)
                    {
                        _observing.OnChange -= Render;
                    }
                    _observing = value;
                    _observing.OnChange += Render;
                    Render(value);
                }
            }
        }

        [field: SerializeField]
        public Trait Trait { get; private set; }

        public void Render(TraitValue value)
        {
            _valueBar.rectTransform.localScale = new Vector2((float)value.Value / value.Max, 1);
            _label.text = $"{Trait}: {value.Value}/{value.Max}";
        }
    }
}