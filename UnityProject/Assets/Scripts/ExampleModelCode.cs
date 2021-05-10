using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleModelCode
{

    public static Vector3 FindClosestPositionTo(Vector3 target, Vector3[] potentialPositions)
    {
        float minDist = float.MaxValue;
        Vector3 result = Vector3.zero;

        for (int i = 0; i < potentialPositions.Length; i++)
        {
            Vector3 current = potentialPositions[i];
            float localDist = Vector3.Distance(current, target);

            if (localDist < minDist)
            {
                minDist = localDist;
                result = current;
            }

        }

        return result;
    }

}
