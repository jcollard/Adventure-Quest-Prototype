using UnityEngine;
using TMPro;
using AdventureQuest.Dice;

[RequireComponent(typeof(TextMeshProUGUI))]
public class RollResultController : MonoBehaviour
{
    public void Render(Die die) => GetComponent<TextMeshProUGUI>().text = $"{die.LastRoll}";
}