using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AdventureQuest.UI;
using UnityEngine.Events;

public class PortraitSelector : MonoBehaviour
{
    private int _currentIx = 0;
    [field: SerializeField]
    private SpriteDatabase _portraitDatabase;

    [field: SerializeField]
    public UnityEvent<Sprite> OnChange { get; private set; }

    protected void Start()
    {
        OnChange.Invoke(_portraitDatabase.Get(_currentIx));
    }

    public void Next()
    {
        _currentIx = (_currentIx + 1) % _portraitDatabase.Count;
        OnChange.Invoke(_portraitDatabase.Get(_currentIx));
    }

    public void Prev()
    {
        _currentIx = _currentIx <= 0 ? _portraitDatabase.Count - 1 : _currentIx - 1;
        OnChange.Invoke(_portraitDatabase.Get(_currentIx));
    }
}

