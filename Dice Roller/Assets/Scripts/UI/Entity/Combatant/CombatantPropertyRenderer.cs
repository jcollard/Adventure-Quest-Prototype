using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AdventureQuest.Entity.UI
{
    [RequireComponent(typeof(TraitManifestRenderer))]
    public class CombatantPropertyRenderer : MonoBehaviour
    {
        public virtual void Render(ICombatant toRender)
        {
            
        }
    }
}