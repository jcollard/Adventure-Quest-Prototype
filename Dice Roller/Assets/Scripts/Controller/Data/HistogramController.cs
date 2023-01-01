using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using CaptainCoder.Dice;

namespace CaptainCoder.Data
{    
    public class HistogramController : MonoBehaviour {
        
        private Histogram _histogram;
        public Histogram Histogram 
        { 
            get => _histogram; 
            set
            {
                if (value == null) throw new System.ArgumentNullException("Cannot set null Histogram.");
                _histogram = value;
                OnChange.Invoke(_histogram);
            }
        }

        [field: SerializeField]
        public UnityEvent<Histogram> OnChange { get; private set; }

        public void Start()
        {
            DicePool pool = DicePool.Parse("3d6");
            List<int> data = new ();
            for (int i = 0; i < 100_000; i++)
            {
                data.Add(pool.Roll());
            }
            Histogram = new Histogram(data);
        }

    }
}