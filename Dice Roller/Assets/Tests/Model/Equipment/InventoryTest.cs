using NUnit.Framework;
namespace AdventureQuest.Equipment
{
    [TestFixture]
    public class InventoryTest
    {
        [Test, Timeout(5000)]
        public void TestEquality()
        {
            Inventory bobsInventory = new ("Bob's Inventory");
            Inventory identicalInventory = new ("Bob's Inventory");
            Assert.AreEqual(bobsInventory, identicalInventory);

            bobsInventory.Add(Weapons.Dagger);
            bobsInventory.Add(Weapons.ShortSword);
            bobsInventory.Add(Weapons.Longsword);
            Assert.AreNotEqual(bobsInventory, identicalInventory);

            identicalInventory.Add(Weapons.Dagger);
            identicalInventory.Add(Weapons.ShortSword);
            identicalInventory.Add(Weapons.Longsword);
            Assert.AreEqual(bobsInventory, identicalInventory);

            Inventory clarksInventory = new ("Clark's Inventory");

            Assert.AreNotEqual(bobsInventory, clarksInventory);

            clarksInventory.Add(Weapons.Dagger);
            clarksInventory.Add(Weapons.ShortSword);
            clarksInventory.Add(Weapons.Longsword);
            Assert.AreNotEqual(bobsInventory, clarksInventory);
        }

        [Test, Timeout(5000)]
        public void TestSerialization()
        {
            Inventory bobsInventory = new ("Bob's Inventory");
            bobsInventory.Add(Weapons.Dagger);
            bobsInventory.Add(Weapons.ShortSword);
            bobsInventory.Add(Weapons.Longsword);

            string jsonified = UnityEngine.JsonUtility.ToJson(bobsInventory);
            Inventory loaded = UnityEngine.JsonUtility.FromJson<Inventory>(jsonified);
            Assert.AreEqual(bobsInventory, loaded);

            Inventory clarksInventory = new ("Clark's Inventory");
            clarksInventory.Add(Weapons.Dagger);
            jsonified = UnityEngine.JsonUtility.ToJson(clarksInventory);
            loaded = UnityEngine.JsonUtility.FromJson<Inventory>(jsonified);
            Assert.AreEqual(clarksInventory, loaded);
        }
    }
}