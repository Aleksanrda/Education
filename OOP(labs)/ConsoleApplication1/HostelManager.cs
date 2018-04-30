using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1_2.Models;

namespace Lab1_2
{
    public class HostelManager
    {
        private HostelStorage hostelStorage;

        public HostelManager()
        {
            this.hostelStorage = new HostelStorage();
        }

        public bool Add(int nameRoom, string personName)
        {
            string result = "";

            if (nameRoom < 0)
            {
                throw new ArgumentException("Room can`t  be negative");
            }

            var rooms = this.hostelStorage.GetAllRooms();
            // проверить : такая комната есть в массиве, personName не пустая строка 
            if (personName == "")
            {
                throw new ArgumentNullException("Room can`t  be empty");
            }
            else
            {
                for (int i = 0; i < rooms.Count; i++)
                {
                    if (nameRoom == rooms[i].NumberOfRoom)
                    {
                        if (rooms[i].Person.Count < 5)
                        {
                            this.hostelStorage.AddRoommate(rooms[i], personName);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }

                }
            }

            return false;
        }

        public void Remove(int nameRoom, string personName)
        {
            if (nameRoom < 0)
            {
                throw new ArgumentException("Room can`t  be negative");
            }
            // проверить : такая комната есть в массиве, personName не пустая строка 

            if (personName == "")
            {
                throw new ArgumentException("Room can`t  be empty");
            }

            var rooms = this.hostelStorage.GetAllRooms();

            for (int i = 0; i < rooms.Count; i++)
            {
                if (nameRoom == rooms[i].NumberOfRoom)
                {
                    for (int j = 0; j < rooms[i].Person.Count; j++)
                    {
                        if (personName == rooms[i].Person[j])
                        {
                            this.hostelStorage.RemoveRoommate(rooms[i], personName);
                            break;
                        }
                    }
                }

            }

            //валидация и логика
        }

        public List<string> GetAllPersonsInHostel()
        {
            List<string> printAllPersonsInHostel = new List<string>();

            var rooms = this.hostelStorage.GetAllRooms();

            for (int i = 0; i < rooms.Count; i++)
            {
                for (int j = 0; j < rooms[i].Person.Count; j++)
                {
                    printAllPersonsInHostel.Add(rooms[i].Person[j]);
                }
            }

            return printAllPersonsInHostel;
        }

        public List<Room> SearchPlaceBySurname(string inputSurname)
        {
            var rooms = this.hostelStorage.GetAllRooms();

            string searchPlaceBySurname = string.Empty;
            List<Room> arrayOfSearchPlaceBySurname = new List<Room>();

            for (int i = 0; i < rooms.Count; i++)
            {
                for (int j = 0; j < rooms[i].Person.Count; j++)
                {
                    if (rooms[i].Person[j] == inputSurname)
                    {
                        arrayOfSearchPlaceBySurname.Add(rooms[i]);
                    }
                }
            }

            return arrayOfSearchPlaceBySurname;
        }

        public List<FreePlacesResult> OutputListOfFreePlaceInRoom()
        {
            var rooms = this.hostelStorage.GetAllRooms();
            List<FreePlacesResult> freePlacesInRoom = new List<FreePlacesResult>();
            string outputListOfFreePlaceInRoom = string.Empty;

            for (int m = 0; m < rooms.Count; m++)
            {
                for (int n = 0; n < rooms.Count - 1 - m; n++)
                {

                    if (rooms[n].CountOfPeopleInRoom > rooms[n + 1].CountOfPeopleInRoom)
                    {
                        int temp = rooms[n].CountOfPeopleInRoom;
                        rooms[n].CountOfPeopleInRoom = rooms[n + 1].CountOfPeopleInRoom;
                        rooms[n + 1].CountOfPeopleInRoom = temp;
                    }

                }
            }

            for (int i = 0; i < rooms.Count; i++)
            {
                int maxCountPeopleInRoom = 5;
                int countOfFreePlaces = maxCountPeopleInRoom - rooms[i].CountOfPeopleInRoom;

                if (countOfFreePlaces > 0)
                {
                    FreePlacesResult result = new FreePlacesResult(rooms[i], countOfFreePlaces);
                    freePlacesInRoom.Add(result);
                }
            }

            return freePlacesInRoom;
        }

        public List<PercentagePopulation> OutputFreeRoomOnEveryFlourAndPercentageOfPopulation(out string outPercentageOfPopulation)
        {

            double countOfAllPepleInHostel = 0;
            double countOfAllPlacesInHostel = 0;
            int maxCountPeopleInRoom = 5;
            int numberOfFloor = 2;
            List<Room> countOfFreeRoomInFloor = new List<Room>();
            var rooms = this.hostelStorage.GetAllRooms();
            List<PercentagePopulation> percentagePopulation = new List<PercentagePopulation>();

            for (int k = 0; k < 4; k++)
            {
                double countOfFreeRoom = 0;
                for (int z = 0; z < rooms.Count; z++)
                {
                    if (rooms[z].NumberOfFloor == numberOfFloor)
                    {
                        int countOfPeopleInRoom = rooms[z].CountOfPeopleInRoom;
                        int countOfFreePlaces = maxCountPeopleInRoom - countOfPeopleInRoom;

                        countOfAllPepleInHostel += countOfPeopleInRoom;
                        countOfAllPlacesInHostel += 5;

                        if (countOfFreePlaces > 0)
                        {
                            countOfFreeRoom++;
                        }

                    }
                }

                PercentagePopulation result = new PercentagePopulation(countOfFreeRoom, k + 2);
                percentagePopulation.Add(result);
                numberOfFloor++;
            }

            double percentageOfPopulation = (countOfAllPepleInHostel / countOfAllPlacesInHostel) * 100; //!нужно вернуть

            string outputPercentageOfPopulation = ("percentage of population: " + percentageOfPopulation);


            outPercentageOfPopulation = outputPercentageOfPopulation;

            return percentagePopulation;
        }
    }
}
