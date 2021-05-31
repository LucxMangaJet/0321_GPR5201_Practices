using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems5201
{

    public enum CharacterType
    {
        Melee,
        Ranged
    }

    public class PlayerCharacter
    {
        private CharacterType type;
        private float hp;
        private float aggroLevel;

        public CharacterType Type => type;
        public float HP => hp;
        public float AggroLevel => aggroLevel;

        public PlayerCharacter(CharacterType t, float hp, float aggro)
        {
            this.type = t;
            this.hp = hp;
            this.aggroLevel = aggro;
        }
        public override string ToString()
        {
            return $"Character (T: {type} , HP: {hp}, Aggro: {aggroLevel})";
        }
    }
}
