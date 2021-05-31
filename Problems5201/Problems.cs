using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems5201
{
    public static class Problems
    {
        /*
        Problem 01:
        Given an array of enemy positions, calculate the closest enemey that is in front of the player.
        Return the index of the corresponding enemy. Return -1 if there is no answer.
        "in front" is defined as being in the direction of where the player is looking.
        An enemy sharing the exact position of the player is not considered in front.

        position = position of the player
        forward = orientation of the player (forward vector)
        enemiesPositions = array of positions of enemies
        */



        public static int GetClosestTargetInFront(Vector3 position, Vector3 forward, Vector3[] enemiesPositions)
        {
            int closest = -1;
            float min = float.MaxValue;

            for (int i = 0; i < enemiesPositions.Length; i++)
            {
                Vector3 enemy = enemiesPositions[i];

                Vector3 norm = (enemy - position).normalized;
                float dot = Vector3.Dot(norm, forward);
                bool inFront = dot > 0;

                if (inFront)
                {
                    float distance = (enemy - position).magnitude;
                    if (distance < min)
                    {
                        min = distance;
                        closest = i;
                    }
                }
            }
            return closest;
        }
    }
}
