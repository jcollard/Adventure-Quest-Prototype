using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AdventureQuest.Character;
using TMPro;

namespace AdventureQuest.UI
{
    public class TotalScoreLabel : AbilityScoreLabel
    {
        public override void Render(Abilities abilities)
        {
            _scoreLabel.text = abilities.Total.ToString();
            string modifier = abilities.TotalModifiers.ToString();
            modifier = abilities.TotalModifiers >= 0 ? $"+{modifier}" : modifier;
            _modifierLabel.text = modifier;

            // _nameLabel.color = CalculateColor(abilities.TotalModifiers);
            _modifierLabel.color = CalculateColor(abilities.TotalModifiers);
            _scoreLabel.color = CalculateColor(abilities.TotalModifiers);
        }

        private static Color CalculateColor(int modifiers)
        {
            if (modifiers > 6)
            {
                return Color.green;
            }
            else if (modifiers > 0)
            {
                return Color.yellow;
            }
            else
            {
                //FF7C7C - Redish
                //960000
                return new Color32(0x96,0x00,0x00,0xFF);
            }
        }
    }
}