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
            if (characters == null) return null;

            if (characters.Length == 0) return null;

            PlayerCharacter result = null;
            bool containsAliveRanged = false;
            bool below20Mode = false;
            bool contansAliveRangedBelow20 = false;
            List<PlayerCharacter> filteredCharacters = new List<PlayerCharacter>(characters.Length);

            //filter out dead, check condititions
            foreach (var player in characters)
            {
                if (player.HP <= 0) continue;

                if (player.HP < 20)
                {
                    below20Mode = true;
                    if (player.Type == CharacterType.Ranged)
                        contansAliveRangedBelow20 = true;
                }

                if (player.Type == CharacterType.Ranged) containsAliveRanged = true;

                filteredCharacters.Add(player);
            }

            if (below20Mode)
            {
                return SelectLowestHP(filteredCharacters, rangedOnly: contansAliveRangedBelow20);
            }
            else
            {
                return SelectHighestAggro(filteredCharacters, rangedOnly: containsAliveRanged);
            }
        }

        private static PlayerCharacter SelectLowestHP(List<PlayerCharacter> players, bool rangedOnly)
        {
            float min = float.MaxValue;
            PlayerCharacter result = null;

            foreach (var p in players)
            {
                bool typeIsGood = !rangedOnly || p.Type == CharacterType.Ranged;
                if (typeIsGood && p.HP < min)
                {
                    min = p.HP;
                    result = p;
                }
            }
            return result;
        }

        private static PlayerCharacter SelectHighestAggro(List<PlayerCharacter> players, bool rangedOnly)
        {
            float max = float.MinValue;
            PlayerCharacter result = null;

            foreach (var p in players)
            {
                bool typeIsGood = !rangedOnly || p.Type == CharacterType.Ranged;
                if (typeIsGood && p.AggroLevel > max)
                {
                    max = p.AggroLevel;
                    result = p;
                }
            }
            return result;
        }
    }
}
