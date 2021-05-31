using System;
using NUnit.Framework;

namespace Problems5201
{
    [TestFixture]
    public class ClosestTargetTests
    {
        [Test]
        public void NoEnemyTest()
        {
            Vector3 position = new Vector3(0, 0, 0);
            Vector3 forward = new Vector3(0, 0, 1);
            Vector3[] enemies = { };
            int expected = -1;

            int result = Problems.GetClosestTargetInFront(position, forward, enemies);

            Assert.AreEqual(expected, result);
        }

        [TestCase(0, 0, 0, -1)]
        [TestCase(0, 0, 1, 0)]
        [TestCase(1000, 1000, 1000, 0)]
        [TestCase(1000, 1000, -1000, -1)]
        public void SingleEnemyTestForward(float enemyX, float enemyY, float enemyZ, int expected)
        {
            Vector3 position = new Vector3(0, 0, 0);
            Vector3 forward = new Vector3(0, 0, 1);
            Vector3[] enemies = { new Vector3(enemyX, enemyY, enemyZ) };

            int result = Problems.GetClosestTargetInFront(position, forward, enemies);

            Assert.AreEqual(expected, result);

        }

        [TestCase(0, 0, 0, -1)]
        [TestCase(0, 0, 1, -1)]
        [TestCase(1000, 1000, 1000, 0)]
        [TestCase(1000, 1000, -1000, 0)]
        public void SingleEnemyTestOffsetUp(float enemyX, float enemyY, float enemyZ, int expected)
        {
            Vector3 position = new Vector3(-100, 50, 75);
            Vector3 forward = new Vector3(0, 1, 0);
            Vector3[] enemies = { new Vector3(enemyX, enemyY, enemyZ) };

            int result = Problems.GetClosestTargetInFront(position, forward, enemies);

            Assert.AreEqual(expected, result);

        }

        [TestCase(0, 0, 1, 1)]
        [TestCase(0, 0, -1, 0)]
        [TestCase(0, 1, 0, 1)]
        [TestCase(0, -1, 0, 0)]
        [TestCase(1, 0, 0, 1)]
        [TestCase(-1, 0, 0, 0)]
        public void TwoEnemiesTest(float fwdX, float fwdY, float fwdZ, int expected)
        {
            Vector3 position = new Vector3(5000, 5000, 5000);
            Vector3 forward = new Vector3(fwdX, fwdY, fwdZ);
            Vector3[] enemies = { new Vector3(0, 0, 0), new Vector3(10000, 10000, 10000) };

            int result = Problems.GetClosestTargetInFront(position, forward, enemies);

            Assert.AreEqual(expected, result);

        }

        [Test]
        public void MultiEnemyTest()
        {
            Vector3 position = new Vector3(0, 0, 0);
            Vector3 forward = new Vector3(1, 0, 0);
            Vector3[] enemies = {
                new Vector3(0, 0, 0),
                new Vector3(10000, 10000, 10000),
                new Vector3(-100, 0, 0),
                new Vector3(5, 10000, 10000),
                new Vector3(1, -10000, 10000)
            };

            int expected = 4;
            int result = Problems.GetClosestTargetInFront(position, forward, enemies);

            Assert.AreEqual(expected, result);
        }
    }
}
