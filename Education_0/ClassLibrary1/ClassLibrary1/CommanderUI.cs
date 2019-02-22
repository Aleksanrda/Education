//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ClassLibrary1
//{
//    public class CommanderUI
//    {
//        private CommanderManager commanderManager;

//        public CommanderUI()
//        {
//            commanderManager = new CommanderManager();
//        }

//        public void Add()
//        {            
//            Console.WriteLine("Input surname");
//            string soldier = Console.ReadLine();

//            if (soldier == "")
//            {
//                throw  new ArgumentNullException("Input surname can't be empty");
//            }

//            var resultAddSoldier = commanderManager.Add(soldier);
//            Console.WriteLine(resultAddSoldier);
//            Console.ReadKey();
//        }

//        public void Remove()
//        {
//            Console.WriteLine("Input surname");
//            string soldier = Console.ReadLine();

//            if (soldier == "")
//            {
//                throw new ArgumentNullException("Input surname can't be empty");
//            }

//            var resultRemoveSoldier = commanderManager.Remove(soldier);
//            Console.ReadKey();
//        }

//        public void OutputSearchSoldier()
//        {
//            Console.WriteLine("Input surname");
//            string soldier = Console.ReadLine();

//            if (soldier == "")
//            {
//                throw new ArgumentNullException("Input surname can't be empty");
//            }

//            var resultRemoveSoldier = commanderManager.OutputSearchSoldier(soldier);
//            Console.ReadKey();
//        }

//        public void OutputChange()
//        {
//            int id = 0;
//            Console.WriteLine("Input id");
//            bool result = int.TryParse(Console.ReadLine(), out id);

//            while (!result)
//            {
//                Console.WriteLine("Not valid. You input wrong data, please, try enter number again");
//                result = int.TryParse(Console.ReadLine(), out id);
//            }

//            commanderManager.Change(id);
//            Console.ReadKey();
//        }
//    }
//}
