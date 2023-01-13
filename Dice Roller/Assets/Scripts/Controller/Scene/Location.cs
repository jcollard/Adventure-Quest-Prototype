using System.Linq;
using System.Collections.Generic;
using AdventureQuest.Character;
using UnityEngine.SceneManagement;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace AdventureQuest.Scene
{
    public class Location
    {
        private static readonly List<Location> s_AllLocations = new();
        public static readonly Location Town = new(Scenes.Town);
        public static readonly Location Status = new(Scenes.Status);
        public static readonly Location CharacterCreator = new(Scenes.CharacterCreator);
        public static readonly Location Shop = new(Scenes.Shop);

        private Location(string name)
        {
            #if UNITY_EDITOR
            // TODO: Attempting to fail fast.
            Debug.Assert(IsSceneEnabled(name), $"The Location {name} could not be constructed because the scene is not enabled in the build settings.");
            #endif
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

        #if UNITY_EDITOR
        public static bool IsSceneEnabled(string path)
        {
            return EditorBuildSettings
                    .scenes
                    .Where(scene => scene.enabled)
                    .Any(scene => scene.path == path);            
        }
        #endif
    }
}