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

        public static string ToJson(PlayerCharacter character) => JsonUtility.ToJson(character);
        public static PlayerCharacter FromJson(string json)
        {
            try
            {
                PlayerCharacter loaded = JsonUtility.FromJson<PlayerCharacter>(json);
                // TODO: Validate loaded is in a legal state
                return loaded;
            }
            catch 
            {
                // TODO: Use correct exceptions / error reporting
                throw new System.IO.InvalidDataException($"Could not load PlayerCharacter.");
            }
        }

    }
}