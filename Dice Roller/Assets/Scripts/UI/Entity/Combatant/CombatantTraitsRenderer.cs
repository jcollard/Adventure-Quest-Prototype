using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AdventureQuest.Entity.UI
{
    [RequireComponent(typeof(TraitManifestRenderer))]
    public class CombatantTraitsRenderer : CombatantPropertyRenderer
    {
        public override void Render(ICombatant toRender) => GetComponent<TraitManifestRenderer>().Render(toRender);
    }
}