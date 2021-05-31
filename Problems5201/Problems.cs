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
            
            throw new System.NotImplementedException();
        }



        /*
        Problem 02:
        Given an array of PlayerCharacters, return the Character that matches the following conditions.
            Return the Ranged character with the highest AggroLevel that is still alive (hp>0).
            If there are no ranged characters, return the meelee character with the highest AggroLevel that is still alive.
            If there is a player (regardless of type) that is below 20 hp, prioritize him/her.            
            If multiple players are below 20hp, priorizie ranged followed by lower hp.
            In case of identical stats pick the one that comes first in the array.
            Return null when no characters are passed or alive.
         */

        public static PlayerCharacter SelectCharacter_SmartFocusedRanged(PlayerCharacter[] characters)
        {
            throw new System.NotImplementedException();
        }

    }
}
