using UnityEngine;
using TMPro;

namespace AdventureQuest.Combat.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class CombatResultTitleRenderer : CombatResultRenderer
    {
        private TextMeshProUGUI _title;
        private TextMeshProUGUI Title
        {
            get
            {
                if (_title == null)
                {
                    _title = GetComponent<TextMeshProUGUI>();
                    Debug.Assert(_title != null, "CombatDialogTitleRenderer could not find Text label.");
                }
                return _title;
            }
        }
        
        public override void Render(CombatResult result)
        {
            Title.text = result.Title;
        }
    }
}