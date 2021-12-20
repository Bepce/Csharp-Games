using DungeonGame.Models.Map;
using DungeonGame.Models.Player;
using System;

namespace DungeonGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //Really basic console game based on Binding of Isaac.

            //make a map
            //using wasd controls make the player move around the map
            //map levels (collection of maps conneted in a layout)

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var level = new Level();

            var levelMatrix = new char[20, 20];
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    levelMatrix[i, j] = '.';
                }
            }

            int counter = 1;
            foreach (var room in level.rooms)
            {               
                Console.WriteLine($"Room {counter} : {room.roomX} {room.roomY}");
                counter += 1;
                levelMatrix[(int)room.roomX + 10, (int)room.roomY + 10] = '#';
            }

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Console.Write(levelMatrix[i, j]);
                }
                Console.WriteLine();
            }
            ;
        }

        private static void GetCurrentRoomCoords(Room currentRoom, Room previousRoom)
        {
            if (previousRoom.Up == currentRoom)
            {
                currentRoom.roomX = previousRoom.roomX--;
                currentRoom.roomY = previousRoom.roomY;
            }
            else if (previousRoom.Down == currentRoom)
            {
                currentRoom.roomX = previousRoom.roomX++;
                currentRoom.roomY = previousRoom.roomY;
            }
            else if (previousRoom.Left == currentRoom)
            {
                currentRoom.roomX = previousRoom.roomX;
                currentRoom.roomY = previousRoom.roomY--;
            }
            else if(previousRoom.Right == currentRoom)
            {
                currentRoom.roomX = previousRoom.roomX;
                currentRoom.roomY = previousRoom.roomY++;
            }
        }

        private static void PrintRoom(Room room)
        {
            for (int i = 0; i < room.Size; i++)
            {
                for (int j = 0; j < room.Size; j++)
                {
                    if (room.RoomMatix[i, j] == 'P')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(room.RoomMatix[i, j]);
                        Console.ResetColor();
                    }
                    else if (room.RoomMatix[i,j] == 'C')
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(room.RoomMatix[i,j]);
                        Console.ResetColor();
                    }
                    else if (room.RoomMatix[i, j] == 'E')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(room.RoomMatix[i, j]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(room.RoomMatix[i, j]);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
