using System.Collections.Generic;
using UnityEngine;

namespace AdventureQuest.Combat.UI
{
    public class CombatDialog : MonoBehaviour
    {
        
        [SerializeField]
        private CombatLogRenderer _logRenderer;
        private CombatResultRenderer[] _renderers;
        private CombatResultRenderer[] Renderers
        {
            get
            {
                if(_renderers == null)
                {
                    _renderers = GetComponentsInChildren<CombatResultRenderer>();
                }
                return _renderers;
            }
        }
        public void ProcessCombatResult(CombatResult result)
        {
            if (result.IsCombatOver)
            {
                _logRenderer.OnLogComplete.AddListener(() => gameObject.SetActive(true));                
            }
            foreach(CombatResultRenderer renderer in Renderers)
            {
                renderer.Render(result);
            }
        }
    }
}