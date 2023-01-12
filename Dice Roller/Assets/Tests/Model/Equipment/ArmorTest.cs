using AdventureQuest.Equipment.Armor;
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
            string asJson = IItem.ToJson(Armors.LeatherArmor);
            Armor loaded = (Armor)IItem.FromJson(asJson);
            Assert.AreEqual(Armors.LeatherArmor, loaded);
        }
    }
}