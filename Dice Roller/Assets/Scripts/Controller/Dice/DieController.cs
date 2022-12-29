using UnityEngine;
using CaptainCoder.Dice;
using UnityEngine.Events;

public class DieController : MonoBehaviour
{
    [field: SerializeField]
    public string DieType { get; private set; } = "d6";
    [field: SerializeField]
    public UnityEvent<Die> OnRoll { get; private set; }
    
    private Die _die;

    public void Start()
    {
        _die = Die.Parse(DieType);
    }

    public void Roll()
    {
        _die.Roll();
        OnRoll.Invoke(_die);
    }

}
