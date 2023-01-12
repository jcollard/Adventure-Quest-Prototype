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
            string asJson = UnityEngine.JsonUtility.ToJson(Armors.LeatherArmor);
            UnityEngine.Debug.Log(asJson);
            Armor loaded = UnityEngine.JsonUtility.FromJson<Armor>(asJson);
            Assert.AreEqual(Armors.LeatherArmor, loaded);
            Armor fromJson = (Armor)IItem.FromJson(asJson);
            Assert.AreEqual(Armors.LeatherArmor, fromJson);
        }
    }
}