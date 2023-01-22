using AdventureQuest.Equipment.Armor;
using AdventureQuest.Result;
using NUnit.Framework;
namespace AdventureQuest.Equipment
{
    [TestFixture]
    public class InventoryTest
    {

        [Test, Timeout(5000)]
        public void TestAddRemove()
        {
            Inventory inventory = new ("Test Inventory");
            Assert.AreEqual(0, inventory.Items.Count);

            IItem potion = new HealthPotion();
            Assert.That(inventory.Items.Contains(potion) == false);

            IResult result = inventory.Add(potion);
            Assert.That(result is Success);
            Assert.AreEqual(1, inventory.Items.Count);
            Assert.That(inventory.Items.Contains(potion));

            result = inventory.Remove(potion);
            Assert.That(result is Success);
            Assert.AreEqual(0, inventory.Items.Count);
            Assert.That(inventory.Items.Contains(potion) == false);

            result = inventory.Remove(potion);
            Assert.That(result is Failure);
            Assert.AreEqual(0, inventory.Items.Count);
            Assert.That(inventory.Items.Contains(potion) == false);

        }

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
            bobsInventory.Add(Armors.LeatherArmor);

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