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
            //

            Console.Write("Please input the map size: ");
            int mapSize = int.Parse(Console.ReadLine());
            var map = new Map(5);
            var player = new Player();
            map.MapMatix[player.X, player.Y] = 'P';

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Coins collected: {player.CoinsCollected}");
                PrintMap(map);
                Console.Write("Command: ");

                var command = Console.ReadKey().Key;

                Console.WriteLine();

                map.MapMatix[player.X, player.Y] = '.';
                player.Move(command.ToString()[0]);

                if (player.IsInside(map.Size))
                {
                    if (map.MapMatix[player.X, player.Y] == 'C')
                    {
                        player.CoinsCollected++;
                        map.MapMatix[player.X, player.Y] = 'P';
                    }
                    else if (map.MapMatix[player.X, player.Y] == 'E')
                    {
                        map = new Map(mapSize);
                        player.ResetPostion();
                        map.MapMatix[player.X, player.Y] = 'P';
                    }
                    else
                    {
                        map.MapMatix[player.X, player.Y] = 'P';
                    }                    
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("You hit the wall.");
                    break;
                }
            }
            PrintMap(map);
            Console.WriteLine($"Coins collected: {player.CoinsCollected}");
        }

        private static void PrintMap(Map map)
        {
            for (int i = 0; i < map.Size; i++)
            {
                for (int j = 0; j < map.Size; j++)
                {
                    if (map.MapMatix[i, j] == 'P')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(map.MapMatix[i, j]);
                        Console.ResetColor();
                    }
                    else if (map.MapMatix[i,j] == 'C')
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(map.MapMatix[i,j]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(map.MapMatix[i, j]);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
