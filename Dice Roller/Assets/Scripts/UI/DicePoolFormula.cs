using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CaptainCoder.Data;
using CaptainCoder.Dice;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

namespace CaptainCoder.UI
{
    public class DicePoolFormula : MonoBehaviour
    {
        [field: SerializeField]
        private DicePoolController _controller;
        [field: SerializeField]
        private TMP_InputField _textField;
        [field: SerializeField]
        public UnityEvent<string> OnError { get; private set; }

        public void UpdateController()
        {
            string formula = _textField.text.Trim().ToLower();
            Debug.Log(formula);
            Debug.Log(formula.Equals("1d4"));
            if (!DicePool.IsParseable(formula))
            {
                OnError.Invoke($"\"{formula}\" is not a valid die pool formula.");
                return;
            }
            _controller.DicePoolFormula = formula;
        }

    }
}