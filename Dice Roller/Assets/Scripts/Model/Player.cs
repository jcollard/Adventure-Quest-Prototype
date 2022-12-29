using UnityEngine;

[System.Serializable]
public class Player
{
    [field: SerializeField]
    public string Name { get; private set; }

    public Player(string name)
    {
        this.Name = name;
    }
}