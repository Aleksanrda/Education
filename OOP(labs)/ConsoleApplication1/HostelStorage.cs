using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1_2.Models;

namespace Lab1_2
{
    public class HostelStorage
    {
        private List<Room> rooms;

        public HostelStorage()
        {
            rooms = new List<Room>()
            {
                new Room
                {
                    NumberOfFloor = 2,
                    NumberOfRoom = 211,
                    CountOfPeopleInRoom = 5,
                    Person = new List<string>()
                    {
                        "Bondarenko",
                        "Kryvko",
                        "Hrapunova",
                        "Smetankin",
                        "Socolov"
                    }
                },
                new Room
                {
                    NumberOfFloor = 3,
                    NumberOfRoom= 311,
                    CountOfPeopleInRoom = 3,
                    Person = new List<string>()
                    {
                       "Bondarenko",
                        "Bashkirtheva",
                        "Kovalenko"
                     }
                 },
                 new Room
                 {
                    NumberOfFloor= 4,
                    NumberOfRoom = 411,
                    CountOfPeopleInRoom = 4,
                    Person = new List<string>()
                    {
                        "Bilbo",
                        "Kryko",
                        "Hrapunov",
                        "Smetankina"
                    }
                },
                new Room
                {
                    NumberOfFloor = 5,
                    NumberOfRoom = 511,
                    CountOfPeopleInRoom = 2,
                    Person = new List<string>()
                    {
                        "Solovey",
                        "Kayk"
                    }
                },
                new Room
                {
                    NumberOfFloor = 5,
                    NumberOfRoom = 521,
                    CountOfPeopleInRoom = 5,
                    Person = new List<string>()
                    {
                        "Manysh",
                        "Lutic",
                        "Rudic",
                        "Belka",
                        "Hrypunov"
                    }
                },
                new Room
                {
                    NumberOfFloor = 2,
                    NumberOfRoom = 213,
                    CountOfPeopleInRoom = 4,
                    Person = new List<string>()
                    {
                        "Popova",
                        "Babloran",
                        "Hrapunova",
                        "Milka"
                    }
                },
                new Room
                {
                    NumberOfFloor = 3,
                    NumberOfRoom = 313,
                    CountOfPeopleInRoom = 2,
                    Person = new List<string>()
                    {
                        "Aidman",
                        "Bond"
                    }
                },
                new Room
                {
                    NumberOfFloor = 4,
                    NumberOfRoom = 413,
                    CountOfPeopleInRoom = 1,
                    Person = new List<string>()
                    {
                       "Bondarenko"
                    }
                }
            };
        }

        public HostelStorage(List<Room> rooms)
        {
            if(rooms == null)
            {
                throw new ArgumentNullException("Rooms can`t be null");
            }

            this.rooms = rooms;
        }

        public List<Room> GetAllRooms()
        {
            return rooms;
        }

        public void AddRoommate(Room room, string name)
        {
            foreach(var r in rooms)
            {
                if(room == r)
                {
                    r.Person.Add(name);
                }
            }
        }
    }
}
