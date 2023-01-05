using NUnit.Framework;
using AdventureQuest.Equipment;
using AdventureQuest.Character.Dice;

namespace AdventureQuest.Character.Equipment
{

    public class CharacterEquipmentManifestTest
    {
        [Test, Timeout(5000), Description("Test Character can only have 1 weapon equipped.")]
        public void TestEquipWeapon()
        {
            Weapon dagger = new ("Dagger", 3, AbilityRoll.Parse($"1d4 + {Ability.Dexterity}"));
            Weapon sword = new ("Sword", 6, AbilityRoll.Parse($"1d6 + {Ability.Strength}"));
            PlayerCharacter bob = new ("Bob", Abilities.Roll(), "no-portrait");
            CharacterEquipmentManifest manifest = new (bob);
            
            Assert.IsEmpty(manifest.Equipped);

            Assert.True(manifest.Equip(dagger, EquipmentSlot.LeftHand ));
            Assert.Contains(dagger, manifest.Equipped.Values);
            Assert.AreEqual(1, manifest.Equipped.Count);
            Assert.AreEqual(dagger, manifest.Equipped[EquipmentSlot.LeftHand]);

            Assert.False(manifest.Equip(sword, EquipmentSlot.LeftHand ));
            Assert.False(manifest.Equip(sword, EquipmentSlot.RightHand ));
            Assert.Contains(dagger, manifest.Equipped.Values);
            Assert.AreEqual(dagger, manifest.Equipped[EquipmentSlot.LeftHand]);
            Assert.AreEqual(1, manifest.Equipped.Count);

            Assert.True(manifest.Unequip(EquipmentSlot.LeftHand));
            Assert.IsEmpty(manifest.Equipped);

            Assert.True(manifest.Equip(sword, EquipmentSlot.RightHand));
            Assert.Contains(sword, manifest.Equipped.Values);
            Assert.AreEqual(1, manifest.Equipped.Count);
            Assert.AreEqual(sword, manifest.Equipped[EquipmentSlot.RightHand]);
        }
    }
}