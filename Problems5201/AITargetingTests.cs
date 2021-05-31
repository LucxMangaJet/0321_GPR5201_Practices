using System;
using NUnit.Framework;

namespace Problems5201
{
    [TestFixture]
    public class AITargetingTests
    {
        [Test]
        public void NoCharacterTest_01()
        {
            PlayerCharacter[] players = null;

            PlayerCharacter expected = null;

            PlayerCharacter result = Problems.SelectCharacter_SmartFocusedRanged(players);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void NoCharacterTest_02()
        {
            PlayerCharacter[] players = { };

            PlayerCharacter expected = null;

            PlayerCharacter result = Problems.SelectCharacter_SmartFocusedRanged(players);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void NoCharacterTest_03()
        {
            PlayerCharacter[] players = { new PlayerCharacter(CharacterType.Melee, 0, 0) };

            PlayerCharacter expected = null;

            PlayerCharacter result = Problems.SelectCharacter_SmartFocusedRanged(players);

            Assert.AreEqual(expected, result);
        }


        [Test]
        public void RangedTest_01()
        {
            PlayerCharacter expected = new PlayerCharacter(CharacterType.Ranged, 100, 100);

            PlayerCharacter[] players =
                {
                new PlayerCharacter(CharacterType.Ranged, 100, -100),
                new PlayerCharacter(CharacterType.Ranged, 100, 0),
                new PlayerCharacter(CharacterType.Ranged, 100, 10),
                expected,
                };

            PlayerCharacter result = Problems.SelectCharacter_SmartFocusedRanged(players);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void RangedTest_02()
        {
            PlayerCharacter expected = new PlayerCharacter(CharacterType.Ranged, 100, 100);

            PlayerCharacter[] players =
                {
                new PlayerCharacter(CharacterType.Ranged, 0, 100),
                expected,
                };

            PlayerCharacter result = Problems.SelectCharacter_SmartFocusedRanged(players);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void NoRangedTest_01()
        {
            PlayerCharacter expected = new PlayerCharacter(CharacterType.Melee, 100, 100);

            PlayerCharacter[] players =
                {
                new PlayerCharacter(CharacterType.Ranged, 0, 100),
                expected,
                new PlayerCharacter(CharacterType.Melee, 100, 20)
                };

            PlayerCharacter result = Problems.SelectCharacter_SmartFocusedRanged(players);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Below20Test_01()
        {
            PlayerCharacter expected = new PlayerCharacter(CharacterType.Melee, 10, 100);

            PlayerCharacter[] players =
                {
                new PlayerCharacter(CharacterType.Ranged, 100, 100),
                expected,
                };

            PlayerCharacter result = Problems.SelectCharacter_SmartFocusedRanged(players);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Below20Test_02()
        {
            PlayerCharacter expected = new PlayerCharacter(CharacterType.Ranged, 10, 100);

            PlayerCharacter[] players =
                {
                new PlayerCharacter(CharacterType.Melee, 1, 100),
                expected,
                };

            PlayerCharacter result = Problems.SelectCharacter_SmartFocusedRanged(players);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Below20Test_03()
        {
            PlayerCharacter expected = new PlayerCharacter(CharacterType.Ranged, 10, 100);

            PlayerCharacter[] players =
                {
                new PlayerCharacter(CharacterType.Melee, 1, 100),
                new PlayerCharacter(CharacterType.Ranged, 11, 100),
                expected,
                };

            PlayerCharacter result = Problems.SelectCharacter_SmartFocusedRanged(players);

            Assert.AreEqual(expected, result);
        }

    }

}
