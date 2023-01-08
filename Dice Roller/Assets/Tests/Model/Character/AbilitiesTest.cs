using NUnit.Framework;
using AdventureQuest.Equipment;
using AdventureQuest.Character.Dice;

namespace AdventureQuest.Character
{
    [TestFixture]
    public class AbilitiesTest
    {
        [Test]
        public void TestEquality()
        {
            Abilities abilities = new Abilities.Builder()
                .SetScore(Ability.Agility, 1)
                .SetScore(Ability.Constitution, 2)
                .SetScore(Ability.Dexterity, 3)
                .SetScore(Ability.Diplomacy, 4)
                .SetScore(Ability.Intelligence, 5)
                .SetScore(Ability.Perception, 6)
                .SetScore(Ability.Strength, 7)
                .Build();

            Abilities abilitiesSame = new Abilities.Builder()
                .SetScore(Ability.Agility, 1)
                .SetScore(Ability.Constitution, 2)
                .SetScore(Ability.Dexterity, 3)
                .SetScore(Ability.Diplomacy, 4)
                .SetScore(Ability.Intelligence, 5)
                .SetScore(Ability.Perception, 6)
                .SetScore(Ability.Strength, 7)
                .Build();

            Assert.AreEqual(abilities, abilitiesSame); 

            Abilities abilitiesDiff = new Abilities.Builder()
                .SetScore(Ability.Agility, 1)
                .SetScore(Ability.Constitution, 3)
                .SetScore(Ability.Dexterity, 3)
                .SetScore(Ability.Diplomacy, 4)
                .SetScore(Ability.Intelligence, 5)
                .SetScore(Ability.Perception, 6)
                .SetScore(Ability.Strength, 7)
                .Build();

            Assert.AreNotEqual(abilities, abilitiesDiff);

            Abilities abilitiesDiff2 = new Abilities.Builder()
                .SetScore(Ability.Agility, 1)
                .SetScore(Ability.Constitution, 2)
                .SetScore(Ability.Dexterity, 3)
                .SetScore(Ability.Diplomacy, 4)
                .SetScore(Ability.Intelligence, 5)
                .SetScore(Ability.Perception, 6)
                .SetScore(Ability.Strength, 8)
                .Build();

            Assert.AreNotEqual(abilities, abilitiesDiff2); 
        
        }
    }
}