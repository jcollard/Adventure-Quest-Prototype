using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AdventureQuest.Character;
using TMPro;

namespace AdventureQuest.UI
{
    public class AbilityScoreLabel : MonoBehaviour
    {
        [field: SerializeField]
        protected TextMeshProUGUI _nameLabel;
        [field: SerializeField]
        protected TextMeshProUGUI _scoreLabel;
        [field: SerializeField]
        protected TextMeshProUGUI _modifierLabel;

        [field: SerializeField]
        public Ability Ability { get; private set; }  

        public virtual void Render(Abilities abilities)
        {
            AbilityScore score = abilities.Score(Ability);
            _nameLabel.text = score.Name;
            _scoreLabel.text = score.Score.ToString();
            string modifier = score.Modifier.ToString();
            modifier = score.Modifier >= 0 ? $"+{modifier}" : modifier;
            _modifierLabel.text = modifier;            
        }

        public AbilityScoreLabel Instantiate(Ability ability, Transform parent)
        {
            AbilityScoreLabel label = Instantiate(this, parent);
            label.Ability = ability;
            return label;
        }
    }
}