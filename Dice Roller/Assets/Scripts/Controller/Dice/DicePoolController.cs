using CaptainCoder.Data;
using CaptainCoder.Dice;
using UnityEngine;
using UnityEngine.Events;


public class DicePoolController : MonoBehaviour
{
    [field: SerializeField]
    private string _dicePoolString = "3d6";
    private DicePool _pool;
    public string DicePoolFormula 
    { 
        get => _dicePoolString; 
        set
        {
            if (!DicePool.IsParseable(value)) throw new System.FormatException($"Invalid DicePool format {value}.");
            _dicePoolString = value;
            _pool = DicePool.Parse(_dicePoolString);
            OnChange.Invoke(_pool);
        }
    }

    [field: SerializeField]
    public UnityEvent<DicePool> OnChange { get; private set; }


}
