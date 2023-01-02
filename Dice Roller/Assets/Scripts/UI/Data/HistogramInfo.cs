using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CaptainCoder.Data;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

namespace CaptainCoder.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class HistogramInfo : MonoBehaviour
    {

        public void Render(Histogram histogram, HistogramBar selected)
        {
            string message = $"Chance to roll a {selected.Value} is";
            message += selected.Chance < 0.01 ? " < 1%" : $" ~ {selected.Chance * 100:0.0}%";
            Render(message);
        }

        public void Render(string message) => GetComponent<TextMeshProUGUI>().text = message;

    }
}