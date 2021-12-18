using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.Models.Map
{
    public class Map
    {
        private Random rng = new Random();
        enum Exits
        {
            Up,
            Left,
            Right,
            Down
        }
        public int exitX = 0;
        public int exitY = 0;

        public char[,] MapMatix;

        public int Size { get; private set; }
        
        public Map(int size)
        {
            this.Size = size;
            MapMatix = new char[size, size];

            int exitEnum = rng.Next(0, 3);
            int[] exit = GenerateExit(exitEnum, this.Size);
            this.exitX = exit[0];
            this.exitY = exit[1];

            int coinX = rng.Next(0, this.Size - 1);
            int coinY = rng.Next(0, this.Size - 1);
            for (int i = 0; i < this.Size; i++)
            {               
                for (int j = 0; j < this.Size; j++)
                {
                    MapMatix[i, j] = '.';
                }               
            }
            while (coinX == exitX && coinY == exitY)
            {
                coinX = rng.Next(0, this.Size - 1);
                coinY = rng.Next(0, this.Size - 1);
            }
            MapMatix[exitX, exitY] = 'E';
            MapMatix[coinX, coinY] = 'C';
        }

        private static int[] GenerateExit(int exitEnum, int mapSize)
        {
            int[] exitCoords = new int[2];
            switch ((Exits)exitEnum)
            {
                case Exits.Up:
                    exitCoords[0] = 0;
                    exitCoords[1] = (int)mapSize / 2;
                    break;
                case Exits.Left:
                    exitCoords[1] = 0;
                    exitCoords[0] = (int)mapSize / 2;
                    break;
                case Exits.Right:
                    exitCoords[0] = (int)mapSize / 2;
                    exitCoords[1] = mapSize - 1;
                    break;
                case Exits.Down:
                    exitCoords[0] = mapSize - 1;
                    exitCoords[1] = (int)mapSize / 2;
                    break;
                default:
                    break;
            }
            return exitCoords;
        }
    }
}
