using AdventureQuest.Equipment.Armor;
using AdventureQuest.Json;
using NUnit.Framework;
namespace AdventureQuest.Entity
{
    [TestFixture]
    public class TraitManifestTest
    {
        [Test, Timeout(5000)]
        public void TestEquality()
        {
            TraitManifest manifestFirst = new (
                new TraitValue(Trait.Health, 25),
                new TraitValue(Trait.Stamina, 10)
            );
            TraitManifest manifestOther = new (
                new TraitValue(Trait.Health, 25),
                new TraitValue(Trait.Stamina, 10)
            );
            Assert.AreNotSame(manifestFirst, manifestOther);
            Assert.AreEqual(manifestFirst, manifestOther);

            manifestFirst.Get(Trait.Health).Max = 12;
            Assert.AreNotEqual(manifestFirst, manifestOther);

            manifestOther.Get(Trait.Health).Max = 12;
            Assert.AreEqual(manifestFirst, manifestOther);

            manifestOther.Get(Trait.Stamina).Min = 2;
            manifestOther.Get(Trait.Stamina).Max = 10;
            Assert.AreNotEqual(manifestFirst, manifestOther);

            manifestFirst.Get(Trait.Stamina).Min = 2;
            manifestFirst.Get(Trait.Stamina).Max = 10;
            Assert.AreEqual(manifestFirst, manifestOther);

            manifestFirst.Get(Trait.Stamina).Value = 7;
            Assert.AreNotEqual(manifestFirst, manifestOther);

            manifestOther.Get(Trait.Stamina).Value = 7;
            Assert.AreEqual(manifestFirst, manifestOther);
        }

        [Test, Timeout(5000)]
        public void TestSerialization()
        {
            TraitManifest original = new (
                new TraitValue(Trait.Health, 25),
                new TraitValue(Trait.Stamina, 10)
            );
            string json = UnityEngine.JsonUtility.ToJson(original);
            TraitManifest loaded = UnityEngine.JsonUtility.FromJson<TraitManifest>(json);
            Assert.AreNotSame(original, loaded);
            Assert.AreEqual(original, loaded);
        }
    }
}