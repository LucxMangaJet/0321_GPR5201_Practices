using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ExampleTests
{
    [Test]
    public void HoangTest()
    {
        Vector3 player = Vector3.zero;

        Vector3 enemy1 = new Vector3(1, 0, 0);
        Vector3 enemy2 = new Vector3(2, 0, 0);

        Vector3 result = ExampleModelCode.FindClosestPositionTo(player, new Vector3[] { enemy1, enemy2 });

        Assert.AreEqual(enemy1, result, "FindClosestPosition failed.");
    }


    [Test]
    public void NoEnemiesTest()
    {
        Vector3 player = Vector3.zero;

        Assert.Throws(typeof(System.ArgumentNullException),
            delegate { Vector3 result = ExampleModelCode.FindClosestPositionTo(player, null); });

        Assert.Throws(typeof(System.ArgumentException),
            delegate { Vector3 result = ExampleModelCode.FindClosestPositionTo(player, new Vector3[0]); });

    }




}
