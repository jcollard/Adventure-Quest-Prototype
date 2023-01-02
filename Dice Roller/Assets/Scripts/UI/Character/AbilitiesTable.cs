using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AdventureQuest.Character;
using TMPro;

namespace AdventureQuest.UI
{
    public class AbilitiesTable : MonoBehaviour
    {
        [field: SerializeField]
        private AbilityScoreLabel _labelTemplate;
        private readonly List<AbilityScoreLabel> _labels = new ();
        protected void Start()
        {
            foreach (Transform child in transform)
            {
                if (child.name == "Top Row") { continue; }
                Destroy(child.gameObject);
            }
            _labels.Clear();
            foreach (Ability ability in Abilities.Types)
            {
                AbilityScoreLabel label = _labelTemplate.Instantiate(ability, transform);
                _labels.Add(label);
            }
        }

        public void Render(PlayerCharacter playerCharacter) => Render(playerCharacter.Abilities);

        public void Render(Abilities abilities)
        {
            foreach (AbilityScoreLabel child in _labels)
            {
                child.Render(abilities);
            }
        }
    }
}