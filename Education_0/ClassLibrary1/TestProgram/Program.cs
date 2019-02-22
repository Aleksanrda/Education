using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace TestProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            //try
            //{
            //    CommanderUI commanderUI = new CommanderUI();

            //    Console.WriteLine("1 - Add");

            //    Console.WriteLine("2 - Remove");

            //    Console.WriteLine("3 - Change");

            //    Console.WriteLine("4 - Search");

            //    Console.WriteLine("5 - Exit");

            //    int inputNumber = 0;
            //    while (inputNumber != 5)
            //    {
            //        Console.WriteLine("Input one of number");
            //        bool result = int.TryParse(Console.ReadLine(), out inputNumber);

            //        while (result == false)
            //        {
            //            Console.WriteLine("Not valid. try enter number again");
            //            result = int.TryParse(Console.ReadLine(), out inputNumber);
            //        }

            //        while (inputNumber < 1 && inputNumber > 4)
            //        {
            //            Console.WriteLine("You input wrong number, try again");
            //            result = int.TryParse(Console.ReadLine(), out inputNumber);
            //        }

            //        if (inputNumber == 1)
            //        {
            //            commanderUI.Add();
            //        }
            //        else if (inputNumber == 2)
            //        {
            //            commanderUI.Remove();
            //        }
            //        else if (inputNumber == 3)
            //        {
            //            commanderUI.OutputChange();
            //        }
            //        else if(inputNumber == 4)
            //        {
            //            commanderUI.OutputSearchSoldier();
            //        }

            //    }
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Exception: ");
            //    Console.WriteLine(e.Message);
            //    Console.Read();
            //}
            CommanderDirectory commanderDirectory = new CommanderDirectory();
            TestAdding(commanderDirectory);
            //string resultString = ""
            //List<Soldier> result = commanderDirectory.RemoveSoldier(resultString);



            Console.ReadKey();
        }

        private static void TestAdding(CommanderDirectory directory)
        {
            var soldier = new Soldier
            {
                Name = "Test forth"
            };

            directory.AddSoldier(soldier);

            var allSoldiers = directory.GetAllSoldiers();
        }

        private static void TestSearch(CommanderDirectory directory)
        {

        }

    }



}
