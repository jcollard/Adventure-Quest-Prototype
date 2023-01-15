using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace AdventureQuest.Entity.UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class CombatantNameRenderer : CombatantPropertyRenderer
    {
        public override void Render(ICombatant toRender) => GetComponent<TextMeshProUGUI>().text = toRender.Name;
    }
}