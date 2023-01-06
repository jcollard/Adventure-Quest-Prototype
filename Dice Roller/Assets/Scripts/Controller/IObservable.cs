using UnityEngine;
using UnityEngine.Events;

namespace AdventureQuest.Controller
{
    public interface IObservable<T>
    {
        public T Observed { get; set; }
        public UnityEvent<T> OnChange { get;  }
    }
}