using UnityEngine;
using TMPro;

namespace AdventureQuest.Combat.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class CombatantNameRenderer : CombatantPropertyRenderer
    {
        public override void Render(ICombatant toRender) => GetComponent<TextMeshProUGUI>().text = toRender.Name;
    }
}