
using AdventureQuest.Character;
using UnityEngine.SceneManagement;

namespace AdventureQuest.Scene
{
    public class Location
    {
        public static readonly Location Town = new (Scenes.Town);
        public static readonly Location Status = new (Scenes.Status);
        public static readonly Location CharacterCreator = new (Scenes.CharacterCreator);
        public static readonly Location Shop = new (Scenes.Shop);

        private Location(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public virtual void Transition(PlayerCharacter character)
        {
            PlayerCharacter.Store(character);
            SceneManager.LoadScene(Name);
        }

        
    }
}