using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AdventureQuest.Entity.UI
{
    public class TraitManifestRenderer : MonoBehaviour
    {
        private TraitValueRenderer[] _renderers;

        private TraitValueRenderer[] Renderers
        {
            get 
            {
                if (_renderers == null)
                {
                    _renderers = GetComponentsInChildren<TraitValueRenderer>();
                }
                return _renderers;
            }
        }

        public void Render(IHasTraits hasTraits) => Render(hasTraits.Traits);

        public void Render(TraitManifest manifest)
        {
            foreach(TraitValueRenderer child in Renderers)
            {
                child.Observing = manifest.Get(child.Trait);
            }
        }

        protected void Awake()
        {
            _renderers = GetComponentsInChildren<TraitValueRenderer>();
        }
    }
}