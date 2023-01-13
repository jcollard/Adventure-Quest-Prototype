using System.Collections.Generic;
using System.Linq;
using AdventureQuest.Scene;
using NUnit.Framework;
using UnityEditor;
namespace AdventureQuest.Character
{
    [TestFixture]
    public class LocationTest
    {
        [Test, Timeout(5000), Description("Tests that locations are in the build manifest.")]
        public void TestLocationScenesExist()
        {
            HashSet<string> enabledScenes = EditorBuildSettings
                .scenes
                .Where(scene => scene.enabled)
                .Select(scene => scene.path)
                .ToHashSet();
            List<Location> allLocations = Location.AllLocations;
            foreach(Location location in allLocations)
            {
                Assert.True(enabledScenes.Contains(location.ScenePath));
            }
        }
    }
}