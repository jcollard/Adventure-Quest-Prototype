using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AdventureQuest.Character
{
    public class PlayerCharacter
    {
        [field: SerializeField]
        public string Name { get; private set; }
        [field: SerializeField]
        public string PortraitSpriteKey { get; private set; }
        [field: SerializeField]
        public Abilities Abilities { get; private set; }

        public PlayerCharacter(string name, Abilities abilities, string portraitSpriteKey)
        {
            if (name == null || abilities == null || portraitSpriteKey == null)
            {
                throw new System.ArgumentNullException();
            }
            Name = name;
            Abilities = abilities;
            PortraitSpriteKey = portraitSpriteKey;
        }

    }
}