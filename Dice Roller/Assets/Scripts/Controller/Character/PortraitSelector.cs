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

    public string PortraitKey {
        set
        {
            if (value == null) { throw new System.ArgumentNullException($"Cannot set portrait to null."); }
            SpriteEntry entry = _portraitDatabase.Get(value);
            OnChange.Invoke(entry.Sprite);
            OnKeyChange.Invoke(entry.Name);
        }
    }

    [field: SerializeField]
    public UnityEvent<Sprite> OnChange { get; private set; }
    [field: SerializeField]
    public UnityEvent<string> OnKeyChange { get; private set; }

    private int CurrentIx
    {
        get => _currentIx;
        set
        {
            int count = _portraitDatabase.Count;
            _currentIx = ((value % count) + count) % count;
            SpriteEntry entry = _portraitDatabase.Get(_currentIx);
            OnChange.Invoke(entry.Sprite);
            OnKeyChange.Invoke(entry.Name);
        }
    }

    protected void Start()
    {
        CurrentIx = 0;
    }

    public void Next() => CurrentIx++;
    public void Prev() => CurrentIx--;
}

