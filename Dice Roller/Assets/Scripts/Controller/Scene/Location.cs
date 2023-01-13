
using System.Linq;
using System.Collections.Generic;
using AdventureQuest.Character;
using UnityEngine.SceneManagement;

namespace AdventureQuest.Scene
{
    public class Location
    {
        private static readonly List<Location> s_AllLocations = new ();
        public static readonly Location Town = new (Scenes.Town);
        public static readonly Location Status = new (Scenes.Status);
        public static readonly Location CharacterCreator = new (Scenes.CharacterCreator);
        public static readonly Location Shop = new (Scenes.Shop);    

        private Location(string name)
        {
            ScenePath = name;
            s_AllLocations.Add(this);
        }

        public static List<Location> AllLocations => s_AllLocations.ToList();

        public string ScenePath { get; }

        public virtual void Transition(PlayerCharacter character)
        {
            PlayerCharacter.Store(character);
            SceneManager.LoadScene(ScenePath);
        }
    }
}