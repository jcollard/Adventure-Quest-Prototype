using NUnit.Framework;
using AdventureQuest.Equipment;
using AdventureQuest.Character.Dice;

namespace AdventureQuest.Character
{

    [TestFixture]
    public class PlayerCharacterTest
    {
        private Abilities abilities;
        private PlayerCharacter character;
        [SetUp]
        public void Setup()
        {
            abilities = new Abilities.Builder()
                .SetScore(Ability.Agility, 1)
                .SetScore(Ability.Constitution, 2)
                .SetScore(Ability.Dexterity, 3)
                .SetScore(Ability.Diplomacy, 4)
                .SetScore(Ability.Intelligence, 5)
                .SetScore(Ability.Perception, 6)
                .SetScore(Ability.Strength, 7)
                .Build();
            character = new ("TestyTesterson", abilities, "TestPortrait");
            character.Inventory.Add(Weapons.Dagger);
            character.Inventory.Add(Weapons.ShortSword);
            character.Inventory.Add(Weapons.Longsword);
            character.Equipment.Equip(Weapons.Dagger, EquipmentSlot.RightHand);
        }

        [Test]
        public void TestSerialization()
        {
            string serialized = PlayerCharacter.Encode(character);
            PlayerCharacter loaded = PlayerCharacter.Decode(serialized);

            Assert.AreEqual(character, loaded);
        }

        [Test]
        public void TestEquality()
        {
            Abilities abilitiesIdentical = new Abilities.Builder()
                .SetScore(Ability.Agility, 1)
                .SetScore(Ability.Constitution, 2)
                .SetScore(Ability.Dexterity, 3)
                .SetScore(Ability.Diplomacy, 4)
                .SetScore(Ability.Intelligence, 5)
                .SetScore(Ability.Perception, 6)
                .SetScore(Ability.Strength, 7)
                .Build();
            PlayerCharacter characterDiffName = new ("TestyTesterson2", abilitiesIdentical, "TestPortrait");
            characterDiffName.Inventory.Add(Weapons.Dagger);
            characterDiffName.Inventory.Add(Weapons.ShortSword);
            characterDiffName.Inventory.Add(Weapons.Longsword);
            characterDiffName.Equipment.Equip(Weapons.Dagger, EquipmentSlot.RightHand);
            Assert.AreNotEqual(character, characterDiffName);

            PlayerCharacter characterIdentical = new ("TestyTesterson", abilitiesIdentical, "TestPortrait");
            characterIdentical.Inventory.Add(Weapons.Dagger);
            characterIdentical.Inventory.Add(Weapons.ShortSword);
            characterIdentical.Inventory.Add(Weapons.Longsword);
            characterIdentical.Equipment.Equip(Weapons.Dagger, EquipmentSlot.RightHand);
            Assert.AreEqual(character, characterIdentical);

            characterIdentical.Gold += 10;
            Assert.AreNotEqual(character, characterIdentical);

            Abilities abilitiesOtherNotEqual = new Abilities.Builder()
                .SetScore(Ability.Agility, 1)
                .SetScore(Ability.Constitution, 4)
                .SetScore(Ability.Dexterity, 3)
                .SetScore(Ability.Diplomacy, 4)
                .SetScore(Ability.Intelligence, 5)
                .SetScore(Ability.Perception, 6)
                .SetScore(Ability.Strength, 7)
                .Build();
            PlayerCharacter characterOtherNotEqual = new ("TestyTesterson", abilitiesOtherNotEqual, "TestPortrait");
            characterOtherNotEqual.Inventory.Add(Weapons.Dagger);
            characterOtherNotEqual.Inventory.Add(Weapons.ShortSword);
            characterOtherNotEqual.Inventory.Add(Weapons.Longsword);
            characterOtherNotEqual.Equipment.Equip(Weapons.Dagger, EquipmentSlot.RightHand);
            Assert.AreNotEqual(character, characterOtherNotEqual);

            PlayerCharacter characterInventoryDiff = new ("TestyTesterson", abilitiesIdentical, "TestPortrait");
            characterInventoryDiff.Inventory.Add(Weapons.ShortSword);
            characterInventoryDiff.Inventory.Add(Weapons.Longsword);
            characterInventoryDiff.Equipment.Equip(Weapons.Dagger, EquipmentSlot.RightHand);
            Assert.AreNotEqual(character, characterInventoryDiff);

            PlayerCharacter characterEquipmentDiff = new ("TestyTesterson", abilitiesIdentical, "TestPortrait");
            characterEquipmentDiff.Inventory.Add(Weapons.Dagger);
            characterEquipmentDiff.Inventory.Add(Weapons.ShortSword);
            characterEquipmentDiff.Inventory.Add(Weapons.Longsword);
            characterEquipmentDiff.Equipment.Equip(Weapons.Dagger, EquipmentSlot.LeftHand);
            Assert.AreNotEqual(character, characterEquipmentDiff);
        }
            
    }
}