using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class PlayerInfoController : MonoBehaviour
{
    [field: SerializeField]
    private Player _player { get; set; }

    public void Start()
    {
        GetComponent<TextMeshProUGUI>().text = $"Player Name: {_player.Name}";
    }

}
