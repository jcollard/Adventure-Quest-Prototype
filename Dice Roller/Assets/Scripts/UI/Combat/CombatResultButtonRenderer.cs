using UnityEngine;
using UnityEngine.UI;

namespace AdventureQuest.Combat.UI
{
    [RequireComponent(typeof(Button))]
    public class CombatResultButtonRenderer : CombatResultRenderer
    {
        [SerializeField]
        private bool _showOnDefeated;
        
        public override void Render(CombatResult result)
        {
            if (result is DefeatResult)
            {
                gameObject.SetActive(_showOnDefeated);
            }
            else
            {
                gameObject.SetActive(!_showOnDefeated);
            }
        }
    }
}