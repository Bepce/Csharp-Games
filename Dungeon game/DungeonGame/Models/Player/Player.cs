using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.Models.Player
{
    public class Player
    {
        private const int STARTING_HEALTH = 40;
        private const int DEFAULT_X = 2;
        private const int DEFAULT_Y = 2;

        public Player()
        {
            this.Heath = STARTING_HEALTH;
            this.X = DEFAULT_X;
            this.Y = DEFAULT_Y;
            this.CoinsCollected = 0;
        }

        public int CoinsCollected { get; set; }
        public int Heath { get; private set; }

        public int X { get; private set; }

        public int Y { get; private set; }

        public bool IsInside(int mapSize)
        {
            if (this.X < 0 || this.X >= mapSize || this.Y < 0 || this.Y >= mapSize)
            {
                return false;
            }
            return true;
        }

        public void Move(char controll)
        {
            switch (controll.ToString().ToUpper())
            {
                case "W":
                    this.X--;
                    break;
                case "A":
                    this.Y--;
                    break;
                case "S":
                    this.X++;
                    break;
                case "D":
                    this.Y++;
                    break;
                default:
                    break;
            }
        }

        internal void ResetPostion()
        {
            this.X = 2;
            this.Y = 2;
        }
    }
}
