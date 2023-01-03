using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ErrorMessage : MonoBehaviour
{
    [field: SerializeField]
    private TextMeshProUGUI _textField;
    [field: SerializeField]
    public int HideDelay { get; private set; } = 2;

    public void DisplayError(string message)
    {
        _textField.text = message;
        gameObject.SetActive(true);
        Invoke(nameof(Hide), HideDelay);
    }

    protected void Start()
    {
        gameObject.SetActive(false);
    }

    private void Hide() => gameObject.SetActive(false);
}
