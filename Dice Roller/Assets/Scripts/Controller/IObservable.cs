using UnityEngine;
using UnityEngine.Events;

namespace AdventureQuest
{
    public interface IObservable<T>
    {
        public event System.Action<T> OnChange;
    }
}