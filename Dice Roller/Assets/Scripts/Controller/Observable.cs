using UnityEngine;
using UnityEngine.Events;

namespace AdventureQuest.Controller
{
    public class Observable<T> : MonoBehaviour, IObservable<T>
    {
        private T _observed;
        private bool _cleared = true;
        public virtual T Observed
        {
            get => _observed;
            set
            {
                if (value == null) { return; }
                if (!_cleared && _observed != null && _observed.Equals(value)) { return; }
                _observed = value;
                OnChange.Invoke(_observed);
                _cleared = false;
            }
        }

        public void Clear() => _cleared = true;

        [field: SerializeField]
        public UnityEvent<T> OnChange { get; private set; }
    }
}