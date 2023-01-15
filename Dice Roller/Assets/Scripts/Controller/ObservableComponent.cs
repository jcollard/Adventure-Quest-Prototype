using UnityEngine;
using UnityEngine.Events;

namespace AdventureQuest.Controller
{
    public class ObservableComponent<T> : MonoBehaviour
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
                //TODO: Consider using OnChange?.
                OnChange.Invoke(_observed);
                _cleared = false;
            }
        }

        public void Clear() => _cleared = true;
        protected void Change() => OnChange.Invoke(_observed);

        [field: SerializeField]
        public UnityEvent<T> OnChange { get; private set; } = new(); 
    }
}