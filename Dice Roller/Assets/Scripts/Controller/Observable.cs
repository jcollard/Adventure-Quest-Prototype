using UnityEngine;
using UnityEngine.Events;

namespace AdventureQuest.Controller
{
    public class Observable<T> : MonoBehaviour, IObservable<T>
    {
        private T _observed;
        public virtual T Observed
        {
            get => _observed;
            set
            {
                if (value == null) { return; }
                if (_observed != null && _observed.Equals(value)) { return; }
                _observed = value;
                OnChange.Invoke(_observed);
            }
        }

        [field: SerializeField]
        public UnityEvent<T> OnChange { get; private set; }
    }
}