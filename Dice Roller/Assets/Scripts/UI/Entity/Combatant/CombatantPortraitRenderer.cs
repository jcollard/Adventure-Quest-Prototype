using UnityEngine;
using UnityEngine.UI;

using AdventureQuest.UI;

namespace AdventureQuest.Combat.UI
{
    [RequireComponent(typeof(Image))]
    public class CombatantPortraitRenderer : CombatantPropertyRenderer
    {
        [SerializeField]
        private SpriteDatabase _sprites;
        public override void Render(ICombatant toRender) => 
            GetComponent<Image>().sprite = _sprites.Get(toRender).Sprite;
    }
}