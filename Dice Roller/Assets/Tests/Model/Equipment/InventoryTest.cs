using NUnit.Framework;
namespace AdventureQuest.Equipment
{
    [TestFixture]
    public class InventoryTest
    {
        [Test]
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
    }
}