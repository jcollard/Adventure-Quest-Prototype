using AdventureQuest.Equipment.Armor;
using AdventureQuest.Json;
using NUnit.Framework;
namespace AdventureQuest.Equipment.Armor
{
    [TestFixture]
    public class ArmorTest
    {
        [Test, Timeout(5000)]
        public void TestEquality()
        {
            Assert.AreNotSame(Armors.LeatherArmor, Armors.LeatherArmor.Duplicate());
            Assert.AreEqual(Armors.LeatherArmor, Armors.LeatherArmor.Duplicate());            
        }

        [Test, Timeout(5000)]
        public void TestSerialization()
        {
            string asJson = JsonSerializer.ToJson(Armors.LeatherArmor);
            Armor loaded = JsonSerializer.FromJson<Armor>(asJson);
            Assert.AreEqual(Armors.LeatherArmor, loaded);
        }
    }
}