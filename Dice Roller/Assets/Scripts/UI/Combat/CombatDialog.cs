using UnityEngine;

namespace AdventureQuest.Combat.UI
{
    public class CombatDialog : MonoBehaviour
    {
        [SerializeField]
        private CombatLogRenderer _logRenderer;
        public void ProcessCombatResult(CombatResult result)
        {
            if (result.IsCombatOver)
            {
                _logRenderer.OnLogComplete.AddListener(() => gameObject.SetActive(true));                
            }
        }
    }
}