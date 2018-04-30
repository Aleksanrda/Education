using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1_2.Models;

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
                Console.WriteLine(outputListOfFreePlaceInRoom);
            }

            Console.ReadKey();
        }

        public void OutputFreeRoomOnEveryFlourAndPercentageOfPopulation()
        {
            string resultOutPercentageOfPopulation = "";
            var resultCountOfFreeRoomInFloor = hostelManager.OutputFreeRoomOnEveryFlourAndPercentageOfPopulation(out resultOutPercentageOfPopulation);

            if (resultCountOfFreeRoomInFloor.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Hhere are no free places in floor");
            }

            foreach (var v in resultCountOfFreeRoomInFloor)
            {
                //string countOfFreeRoomInFloor = v.
     
            }

            Console.WriteLine("");
            Console.WriteLine(resultOutPercentageOfPopulation);
            Console.ReadKey();
        }

        public void PrintAllPersonsInHostel()
        {
            List<string> resultGetAllPersonsInHostel = hostelManager.GetAllPersonsInHostel();

            foreach (var v in resultGetAllPersonsInHostel)
            {
                if (v != null)
                    Console.WriteLine(v);
            }
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

            hostelManager.Add(inputNumberOfUser, inputSurname);

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
    }

}
