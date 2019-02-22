using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Labs
{
    public static class Hostel
    {
        public static void SearchPlaceBySurname(Room[] room)
        {

            Console.Write("Input surname, please ");
            string inputSurname = Console.ReadLine();
            string searchPlaceBySurname = null;

            for (int i = 0; i < room.Length; i++)
            {

                for (int j = 0; j < room[i].Person.Length; j++)
                {
                    if (room[i].Person[j] == inputSurname)
                    {
                       searchPlaceBySurname = ("Number of flour is " + room[i].NumberOfFloor + " and number of room is " + room[i].NumberOfRoom);
                        Console.WriteLine(searchPlaceBySurname);                     
                    }
                    //else
                    //{
                    //    Console.WriteLine("Such surname does not exist in this hostel");
                    //}
                }

            }

            if(searchPlaceBySurname == null)
            {
                Console.WriteLine("Such surname does not exist in this hostel");
            }

            
        }

        public static string OutputListOfFreePlaceInRoom(Room[] room)
        {
            for (int m = 0; m < room.Length; m++)
            {
                for (int n = 0; n < room.Length - 1 - m; n++)
                {

                    if (room[n].CountOfPeopleInRoom > room[n + 1].CountOfPeopleInRoom)
                    {
                        int temp = room[n].CountOfPeopleInRoom;
                        room[n].CountOfPeopleInRoom = room[n + 1].CountOfPeopleInRoom;
                        room[n + 1].CountOfPeopleInRoom = temp;
                    }

                }
            }

            for (int q = 0; q < room.Length; q++)
            {
                int maxCountPeopleInRoom = 5;
                int countOfFreePlaces = maxCountPeopleInRoom - room[q].CountOfPeopleInRoom;

                if (countOfFreePlaces > 0)
                {
                    string outputListOfFreePlaceInRoom = (room[q].NumberOfRoom + " have " + countOfFreePlaces + " free places ");
                    return outputListOfFreePlaceInRoom;
                }

            }

            return "";
        }


        public static string OutputFreeRoomAndPercentageOfPopulation(Room[] room)
        {
            double countOfFreeRoom = 0;
            double countOfAllPepleInHostel = 0;
            double countOfAllPlacesInHostel = 0;

            for (int k = 0; k < room.Length; k++)
            {
                int countOfPeopleInRoom = room[k].CountOfPeopleInRoom;
                int maxCountPeopleInRoom = 5;/////////////
                int countOfFreePlaces = maxCountPeopleInRoom - countOfPeopleInRoom;

                if (countOfFreePlaces > 0)
                {
                    countOfFreeRoom++;
                    countOfAllPepleInHostel += countOfPeopleInRoom;
                    countOfAllPlacesInHostel += 5;
                }

            }

            double percentageOfPopulation = (countOfAllPepleInHostel / countOfAllPlacesInHostel) * 100;

            string outputFreeRoomAndPercentageOfPopulation = ("Count of free places in hostel: " + countOfFreeRoom + " and percentage of population: " + percentageOfPopulation);
            return outputFreeRoomAndPercentageOfPopulation;
        }



        public static  Room [] GetDataOfRooms()
        {
            Room[] room = new Room[]
             {

                new Room
                {
                    NumberOfFloor = 2,
                    NumberOfRoom = 211,
                    CountOfPeopleInRoom = 5,
                     Person = new string[5]
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
         Person = new string[]
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
          Person = new string[]
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
          Person = new string[]
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
          Person = new string[]
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
          Person = new string[]
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
          Person = new string[]
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
          Person = new string[]
                    {
                         "Bondarenko"
                    }
     }

};
            return room;
        }



    }
}
