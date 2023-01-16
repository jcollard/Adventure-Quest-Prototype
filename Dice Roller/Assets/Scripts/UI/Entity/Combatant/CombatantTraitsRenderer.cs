using System.Collections;
using System.Collections.Generic;
using AdventureQuest.Entity.UI;
using UnityEngine;

namespace AdventureQuest.Combat.UI
{
    [RequireComponent(typeof(TraitManifestRenderer))]
    public class CombatantTraitsRenderer : CombatantPropertyRenderer
    {
        public override void Render(ICombatant toRender) => GetComponent<TraitManifestRenderer>().Render(toRender);
    }
}