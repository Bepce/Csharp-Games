using DungeonGame.Models.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame
{
    public static class HelperExtensions
    {
        public static void AssignIfNeighbourWith(this Room newRoom, Room nextRoom)
        {
            if (newRoom.roomX == nextRoom.roomX - 1 && newRoom.roomY == nextRoom.roomY)
            {
                newRoom.Right = nextRoom;
                nextRoom.Left = newRoom;
            }
            if (newRoom.roomX == nextRoom.roomX + 1 && newRoom.roomY == nextRoom.roomY)
            {
                newRoom.Left = nextRoom;
                nextRoom.Right = newRoom;
            }
            if (newRoom.roomY == nextRoom.roomY - 1 && newRoom.roomX == nextRoom.roomX)
            {
                newRoom.Up = nextRoom;
                nextRoom.Down = newRoom;
            }
            if (newRoom.roomY == nextRoom.roomY + 1 && newRoom.roomX == nextRoom.roomX)
            {
                newRoom.Down = nextRoom;
                nextRoom.Up = newRoom;
            }
        }
    }
}
