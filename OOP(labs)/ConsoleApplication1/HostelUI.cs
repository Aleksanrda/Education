using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1_2.Models;
using System.IO;

namespace Lab1_2
{
    public class HostelUI
    {
        private HostelManager hostelManager;

        public HostelUI()
        {
            hostelManager = new HostelManager();
        }

        public void SearchPlaceBySurname()
        {
            Console.Write("Input surname, please ");
            string inputSurname = Console.ReadLine();

            if (inputSurname == "")
            {
                throw new ArgumentException("Input Surname can`t  be empty");
                //error message
            }

            var resultSearchPlaceBySurname = hostelManager.SearchPlaceBySurname(inputSurname);

            if (resultSearchPlaceBySurname.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Such surname does not exist in this hostel");
            }
            else
            {
                foreach (var v in resultSearchPlaceBySurname)
                {
                    string searchPlaceBySurname = ("Number of flour is " + v.NumberOfFloor + " and number of room is " + v.NumberOfRoom);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(searchPlaceBySurname);
                }
            }

            Console.ResetColor();
            Console.ReadKey();
        }

        public void OutputListOfFreePlaceInRoom()
        {
            var resultOutputListOfFreePlaceInRoom = hostelManager.OutputListOfFreePlaceInRoom();

            if (resultOutputListOfFreePlaceInRoom.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Hhere are no free places in hostel");
            }

            foreach (var v in resultOutputListOfFreePlaceInRoom)
            {
                string outputListOfFreePlaceInRoom = v.Room.NumberOfRoom + " have " + v.AmountFreeBeds + " free places ";
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(outputListOfFreePlaceInRoom);
            }

            Console.ResetColor();
            Console.ReadKey();
        }

        public void OutputFreeRoomOnEveryFlourAndPercentageOfPopulation()
        {
            double resultOutPercentageOfPopulation = 0;
            var resultCountOfFreeRoomInFloor = hostelManager.OutputFreeRoomOnEveryFlourAndPercentageOfPopulation(out resultOutPercentageOfPopulation);

            if (resultCountOfFreeRoomInFloor.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Hhere are no free places in floor");
            }

            foreach (var v in resultCountOfFreeRoomInFloor)
            {
                string countOfFreeRoomInFloor = "Count of free rooms in " + v.NumberFlour + " floor: " + v.CountFreeRoom;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(countOfFreeRoomInFloor);
            }

            Console.WriteLine("");
            Console.WriteLine("percentage of population: " + resultOutPercentageOfPopulation);
            Console.ResetColor();
            Console.ReadKey();
        }

        public void PrintAllPersonsInHostel()
        {
            var resultAllPersonsHostel = hostelManager.GetAllPersonsInHostel();

            foreach (var v in resultAllPersonsHostel)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(v);
            }

            Console.ResetColor();
            Console.ReadKey();
        }

        public void Add()
        {
            int inputNumberOfUser = 0;
            Console.Write("Input number of room, please ");
            bool result = int.TryParse(Console.ReadLine(), out inputNumberOfUser);

            while (result == false)
            {
                Console.WriteLine("Not valid");
                Console.WriteLine("You input wrong data, please try enter number again");
                result = int.TryParse(Console.ReadLine(), out inputNumberOfUser);
            }

            Console.Write("Input surname, please ");
            string inputSurname = Console.ReadLine();

            if (inputSurname == "")
            {
                throw new ArgumentNullException("Input Surname can`t  be empty");
                //error message
            }

            var resultAddPerson = hostelManager.Add(inputNumberOfUser, inputSurname);
            if (resultAddPerson == true)
            {
                Console.WriteLine("Person was added");
            }
            else
            {
                Console.WriteLine("Room is full, we can not add person");
            }
            Console.ReadKey();
        }

        public void Remove()
        {
            int inputNumberOfUser = 0;
            Console.Write("Input number of room, please ");
            bool result = int.TryParse(Console.ReadLine(), out inputNumberOfUser);

            while (result == false)
            {
                Console.WriteLine("Not valid");
                Console.WriteLine("You input wrong data, please try enter number again");
                result = int.TryParse(Console.ReadLine(), out inputNumberOfUser);
            }

            Console.Write("Input surname, please ");
            string inputSurname = Console.ReadLine();

            if (inputSurname == "")
            {
                throw new ArgumentNullException("Input Surname can`t  be null");
                //error message
            }

            hostelManager.Remove(inputNumberOfUser, inputSurname);
        }

        public void Save()
        {
            string path = @"OOP(labs).txt"; /* Объявляем строковую переменную "path", 
                                         * которая описывает путь к файлу */
            string text = "";

            try
            {
                Console.WriteLine();
                Console.WriteLine("******считываем построчно********");
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                    //sr.Close();
                }

                using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(text);
                }

            }
            catch
            {
                Console.WriteLine("Error");
                Console.ReadKey();
            }
        }
        public void Exit()
        {
            Console.WriteLine("If you are sure, you want exit: write exit");
            string keyWord = Console.ReadLine();
            hostelManager.GetExit(keyWord);
        }
    }

}
