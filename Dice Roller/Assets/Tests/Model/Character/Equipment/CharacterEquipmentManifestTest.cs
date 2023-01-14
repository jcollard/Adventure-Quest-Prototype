using NUnit.Framework;
using AdventureQuest.Equipment;
using AdventureQuest.Character.Dice;
using AdventureQuest.Entity;

namespace AdventureQuest.Character.Equipment
{

    public class CharacterEquipmentManifestTest
    {
        [Test, Timeout(5000), Description("Test Character can only have 1 weapon equipped.")]
        public void TestEquipWeapon()
        {
            Weapon dagger = Weapons.Dagger;
            Weapon sword = Weapons.ShortSword;
            PlayerCharacter bob = new ("Bob", Abilities.Roll(), TraitManifest.Default, "no-portrait");
            IEquipmentManifest manifest = bob.Equipment;
            
            Assert.IsEmpty(manifest.Equipped);

            Assert.True(manifest.Equip(dagger, EquipmentSlot.LeftHand, bob ));
            Assert.Contains(dagger, manifest.Equipped.Values);
            Assert.AreEqual(1, manifest.Equipped.Count);
            Assert.AreEqual(dagger, manifest.Equipped[EquipmentSlot.LeftHand]);

            Assert.False(manifest.Equip(sword, EquipmentSlot.LeftHand, bob ));
            Assert.False(manifest.Equip(sword, EquipmentSlot.RightHand, bob ));
            Assert.Contains(dagger, manifest.Equipped.Values);
            Assert.AreEqual(dagger, manifest.Equipped[EquipmentSlot.LeftHand]);
            Assert.AreEqual(1, manifest.Equipped.Count);

            Assert.True(manifest.Unequip(EquipmentSlot.LeftHand));
            Assert.IsEmpty(manifest.Equipped);

            Assert.True(manifest.Equip(sword, EquipmentSlot.RightHand, bob));
            Assert.Contains(sword, manifest.Equipped.Values);
            Assert.AreEqual(1, manifest.Equipped.Count);
            Assert.AreEqual(sword, manifest.Equipped[EquipmentSlot.RightHand]);
        }

        [Test, Timeout(5000), Description("Tests structural equality")]
        public void TestEquality()
        {
            PlayerCharacter bob = new ("Bob", Abilities.Roll(), TraitManifest.Default, "no-portrait");
            CharacterEquipmentManifest manifest = new (bob);
            CharacterEquipmentManifest manifestOther = new (bob);
            Assert.AreEqual(manifest, manifestOther);

            manifest.Equip(Weapons.Dagger, EquipmentSlot.LeftHand, bob);
            Assert.AreNotEqual(manifest, manifestOther);

            manifestOther.Equip(Weapons.Dagger, EquipmentSlot.LeftHand, bob);
            Assert.AreEqual(manifest, manifestOther);

            manifest.Unequip(EquipmentSlot.LeftHand);
            Assert.AreNotEqual(manifest, manifestOther);

            manifest.Equip(Weapons.Dagger, EquipmentSlot.RightHand, bob);
            Assert.AreNotEqual(manifest, manifestOther);
            
            manifestOther.Unequip(EquipmentSlot.LeftHand);
            Assert.AreNotEqual(manifest, manifestOther);

            manifestOther.Equip(Weapons.ShortSword, EquipmentSlot.RightHand, bob);
            Assert.AreNotEqual(manifest, manifestOther);

            manifest.Unequip(EquipmentSlot.RightHand);
            Assert.AreNotEqual(manifest, manifestOther);

            manifest.Equip(Weapons.ShortSword, EquipmentSlot.RightHand, bob);
            Assert.AreEqual(manifest, manifestOther);            
        }

        [Test, Timeout(5000), Description("Tests Serialization/Deserialization equality")]
        [TestCase(EquipmentSlot.LeftHand)]
        [TestCase(EquipmentSlot.RightHand)]
        public void TestSerialization(EquipmentSlot slot)
        {
            PlayerCharacter bob = new ("Bob", Abilities.Roll(), TraitManifest.Default, "no-portrait");
            CharacterEquipmentManifest manifest = new (bob);
            manifest.Equip(Weapons.Dagger, slot, bob);

            string json = UnityEngine.JsonUtility.ToJson(manifest);
            CharacterEquipmentManifest loaded = UnityEngine.JsonUtility.FromJson<CharacterEquipmentManifest>(json);
            Assert.AreEqual(manifest, loaded);

            PlayerCharacter steve = new ("Steve", Abilities.Roll(), TraitManifest.Default, "no-portrait");
            manifest = new (steve);
            manifest.Equip(Weapons.ShortSword, slot, bob);

            json = UnityEngine.JsonUtility.ToJson(manifest);
            loaded = UnityEngine.JsonUtility.FromJson<CharacterEquipmentManifest>(json);
            Assert.AreEqual(manifest, loaded);
        }
    }
}