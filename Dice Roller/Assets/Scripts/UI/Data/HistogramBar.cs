using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace AdventureQuest.Data
{
    public class HistogramBar : MonoBehaviour
    {
        [field: SerializeField]
        private Image _bar;
        
        [field: SerializeField]
        public UnityEvent<HistogramBar> OnMouseEnter { get; private set; }
        public int Value { get; private set; }
        public float Chance { get; private set; }
        
        public void Render(Histogram histogram, int value)
        {
            Value = value;
            Chance = (float)System.Math.Round(histogram.ChanceOf(value), 3);
            // Exagerates the histogram such that the largest element is ~1
            float scale = 1 / histogram.ChanceOf(histogram.MostLikelyElement);
            float yScale = Chance * scale;
            
            _bar.color = CalculateColor(yScale);
            _bar.GetComponent<RectTransform>().localScale = new Vector3(1, yScale, 1);
        }

        public void MouseEnter() => OnMouseEnter.Invoke(this);

        public static Color CalculateColor(float yScale)
        {
            if (yScale > .8)
            {
                return Color.green;
            }
            if (yScale > .25)
            {
                return Color.yellow;
            }
            return Color.red;
        }
    }
}