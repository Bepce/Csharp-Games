using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame.Models.Map
{
    public class Room
    {
        private const int DEFAULT_ROOM_SIZE = 5;

        public Room Up { get; set; }
        public Room Left { get; set; }
        public Room Right { get; set; }
        public Room Down { get; set; }
        public List<RoomDirection> AvailableRoomDirections
        {
            get
            {
                return GetAvailableDirections();
            }           
        }

        private List<RoomDirection> GetAvailableDirections()
        {
            var avaiableDirection = new List<RoomDirection>();
            if (this.Up == null)
            {
                avaiableDirection.Add(RoomDirection.Up);
            }
            if (this.Down == null)
            {
                avaiableDirection.Add(RoomDirection.Down);
            }
            if (this.Left == null)
            {
                avaiableDirection.Add(RoomDirection.Left);
            }
            if (this.Right == null)
            {
                avaiableDirection.Add(RoomDirection.Right);
            }
            return avaiableDirection;
        }

        public bool IsEndRoom { get; set; }

        public int roomX = int.MinValue;
        public int roomY = int.MinValue;      

        public char[,] RoomMatix;

        public int Size { get; private set; }

        public Room()
        {
            this.Size = DEFAULT_ROOM_SIZE;
            RoomMatix = new char[DEFAULT_ROOM_SIZE, DEFAULT_ROOM_SIZE];            

            //Fills the RoomMatrix
            for (int i = 0; i < this.Size; i++)
            {
                for (int j = 0; j < this.Size; j++)
                {
                    RoomMatix[i, j] = '.';
                }
            }            
        }             
    }
}
