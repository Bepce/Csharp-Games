using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonGame;


namespace DungeonGame.Models.Map
{
    public class Level
    {
        public Random rng = new Random();
        private const int LEVEL_ROOM_CAPACITY = 10;
        public List<Room> rooms;

        public Level()
        {
            //First step get available rooms for appending new room //level.Where(RoomGenerationAvailability()); DONE!
            //Second steop generate room based on random available room DONE!
            //Third step check where to put exits based on coordinates TODO!
            //Forth step choose endroom and add prop to it SEMI-DONE!

            rooms = new List<Room>();


            while (rooms.Count != LEVEL_ROOM_CAPACITY)
            {
                if (rooms.Count == 0)
                {
                    var room = CreateSpawnRoom();
                    rooms.Add(room);
                    continue;
                }

                var newRoom = CreateNewRoom();
               
                Room randomRoom = PickRandomAvailableRoom();

                RoomDirection roomDirection = PickRandomAvailableDirection(randomRoom);

                CreateRoomReference(randomRoom, newRoom, roomDirection);

                CheckIfRoomHasNeighboursAndAssign(newRoom);

                rooms.Add(newRoom);
                              
            }

        }

        private Room CreateNewRoom()
        {
            if (rooms.Count == LEVEL_ROOM_CAPACITY - 1)
            {
                return CreateEndRoom();
            }
            return new Room();
        }
        private static Room CreateEndRoom()
        {
            var newRoom = new Room();
            newRoom.IsEndRoom = true;
            return newRoom;
        }

        private void CheckIfRoomHasNeighboursAndAssign(Room newRoom)
        {
            rooms.ForEach(r => newRoom.AssignIfNeighbourWith(r));
        }

        private RoomDirection PickRandomAvailableDirection(Room randomRoom)
        {
            int availableDirectionsCount = randomRoom.AvailableRoomDirections.Count;
            int directionAsNumber = rng.Next(0, availableDirectionsCount);
            var roomDirection = randomRoom.AvailableRoomDirections[directionAsNumber];
            return roomDirection;
        }

        private Room PickRandomAvailableRoom()
        {
            var availableRooms = rooms.Where(r => r.AvailableRoomDirections.Any()).ToList();
            int randomRoomAsNumber = rng.Next(0, availableRooms.Count());
            var randomRoom = availableRooms[randomRoomAsNumber];
            return randomRoom;
        }

        private Room CreateSpawnRoom()
        {
            var room = new Room();
            room.roomX = 0;
            room.roomY = 0;
            return room;
        }

        private static void CreateRoomReference(Room fromRoom, Room toRoom, RoomDirection toRoomDirection)
        {
            switch (toRoomDirection)
            {
                case RoomDirection.Up:
                    fromRoom.Up = toRoom;
                    toRoom.Down = fromRoom;
                    toRoom.roomX = fromRoom.roomX;
                    toRoom.roomY = fromRoom.roomY + 1;
                    break;
                case RoomDirection.Down:
                    fromRoom.Down = toRoom;
                    toRoom.Up = fromRoom;
                    toRoom.roomX = fromRoom.roomX;
                    toRoom.roomY = fromRoom.roomY - 1;
                    break;
                case RoomDirection.Left:
                    fromRoom.Left = toRoom;
                    toRoom.Right = fromRoom;
                    toRoom.roomX = fromRoom.roomX - 1;
                    toRoom.roomY = fromRoom.roomY;
                    break;
                case RoomDirection.Right:
                    fromRoom.Right = toRoom;
                    toRoom.Left = fromRoom;
                    toRoom.roomX = fromRoom.roomX + 1;
                    toRoom.roomY = fromRoom.roomY;
                    break;
                default:
                    break;
            }
        }

    }
}
