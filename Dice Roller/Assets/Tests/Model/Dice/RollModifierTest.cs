using System.Collections;
using System.Collections.Generic;
using AdventureQuest.Character;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace AdventureQuest.Dice
{

    public class RollModifierTest
    {

        [Test, Timeout(5000), Description("Test's simple additive modifiers.")]
        public void TestSimpleModifiers()
        {
            RollModifier simple = new (5);
            Assert.AreEqual(5, simple.Modifier);

            Abilities abilities = Abilities.Roll();
            Assert.AreEqual(5, simple.ModifyWith(abilities));

            RollModifier simple2 = new (2);
            Assert.AreEqual(2, simple2.Modifier);
            Assert.AreEqual(2, simple2.ModifyWith(abilities));
        }

        [Test, Timeout(5000), Description("Test's ability additive modifiers.")]
        [TestCase(Ability.Strength)]
        [TestCase(Ability.Dexterity)]
        [TestCase(Ability.Constitution)]
        [TestCase(Ability.Diplomacy)]
        [TestCase(Ability.Intelligence)]
        [TestCase(Ability.Perception)]
        [TestCase(Ability.Agility)] 
        public void TestAllAbilityModifiers(Ability toCheck)
        {
            for (int score = AbilityScore.MIN; score < AbilityScore.MAX; score++)
            {
                Abilities abilities = new Abilities.Builder()
                    .SetScore(toCheck, score)
                    .Build();
                int modifier = abilities.Score(toCheck).Modifier;

                RollModifier plus2 = new (2, toCheck);
                int expected = 2 + modifier;
                Assert.AreEqual(expected, plus2.ModifyWith(abilities));

                RollModifier plus4 = new (4, toCheck);
                expected = 4 + modifier;
                Assert.AreEqual(expected, plus4.ModifyWith(abilities));
            }
        }
    }
}