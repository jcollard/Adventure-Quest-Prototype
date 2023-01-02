using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CaptainCoder.Data;
using UnityEngine.UI;
using UnityEngine.Events;
using CaptainCoder.Dice;

namespace CaptainCoder.UI
{
    public class HistogramViewer : MonoBehaviour
    {
        [field: SerializeField]
        private GameObject NoDataLabel;
        [field: SerializeField]
        private HistogramBar _barTemplate;

        [field: SerializeField]
        private Transform _container;

        [field: SerializeField]
        public UnityEvent<Histogram, HistogramBar> OnHoverBar { get; private set; }
        [field: SerializeField]
        public UnityEvent OnMouseExit { get; private set; }

        public void Render(DicePool pool) => Render(pool.Histogram(100_000));

        public void Render(Histogram histogram)
        {
            Destroy(NoDataLabel);
            foreach (Transform child in _container)
            {
                Destroy(child.gameObject);
            }

            for (int value = histogram.Min; value <= histogram.Max; value++)
            {
                HistogramBar bar = Instantiate(_barTemplate, _container);
                bar.name = value.ToString();
                bar.OnMouseEnter.AddListener((_) => OnHoverBar.Invoke(histogram, bar));
                bar.Render(histogram, value);
            }
            _container.gameObject.SetActive(true);
        }

        public void MouseExit() => OnMouseExit.Invoke();
    }
}