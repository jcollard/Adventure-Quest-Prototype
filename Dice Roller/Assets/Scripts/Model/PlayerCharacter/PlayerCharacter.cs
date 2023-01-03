using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AdventureQuest.Character
{
    public class PlayerCharacter
    {
        
        public string Name { get; private set; }
        public string PortraitSpriteKey { get; private set; }
        public Abilities Abilities { get; private set; }

        public PlayerCharacter(string name, Abilities abilities)
        {
            if (name == null || abilities == null)
            {
                throw new System.ArgumentNullException();
            }
            Name = name;
            Abilities = abilities;
        }

    }
}