using System;
using UnityEngine;

namespace AdventureQuest.Combat.UI
{
    public class CombatantRenderer : MonoBehaviour
    {
        private CombatantPropertyRenderer[] _propertyRenderers;

        public void Render(ICombatant combatant)
        {
            foreach (CombatantPropertyRenderer child in PropertyRenderers)
            {
                child.Render(combatant);
            }   
        }

        private CombatantPropertyRenderer[] PropertyRenderers
        {
            get 
            {
                if (_propertyRenderers == null)
                {
                    _propertyRenderers = GetComponentsInChildren<CombatantPropertyRenderer>();
                }
                return _propertyRenderers;
            }
        }

        protected void Awake()
        {
            _propertyRenderers = GetComponentsInChildren<CombatantPropertyRenderer>();
        }
    }
}