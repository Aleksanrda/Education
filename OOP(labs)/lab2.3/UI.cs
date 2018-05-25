using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2._3
{
    public class UI
    {
        private LinkedList ui;

        public UI()
        {
            ui = new LinkedList();
        }

        public void OutputAddLast()
        {
            double inputNumber = 0;
            Console.Write("Input number, please ");
            bool result = double.TryParse(Console.ReadLine(), out inputNumber);

            while (result == false)
            {
                Console.WriteLine("Not valid");
                Console.WriteLine("You input wrong data, please try enter number again");
                result = double.TryParse(Console.ReadLine(), out inputNumber);
            }

            ui.AddLast(inputNumber);
            ui.PrintList();
        }

        public void OutputAddAfterValue()
        {
            Console.WriteLine("Input (insert element.Search value)");
            string[] data = Console.ReadLine().Split('.');

            while (data[0] == "" || data[1] == "")
            {
                Console.WriteLine("Not valid");
                Console.WriteLine("You input wrong data, please try enter number again");
                data = Console.ReadLine().Split('.');
            }

            double firstNumber = double.Parse(data[0]);
            double secondNumber = double.Parse(data[1]);

            ui.AddAfterValue(firstNumber, secondNumber);
            ui.PrintList();
        }

        public void OutputDeleteValue()
        {
            double inputNumber = 0;
            Console.Write("Input number, please ");
            bool result = double.TryParse(Console.ReadLine(), out inputNumber);

            while (result == false)
            {
                Console.WriteLine("Not valid");
                Console.WriteLine("You input wrong data, please try enter number again");
                result = double.TryParse(Console.ReadLine(), out inputNumber);
            }

            ui.DeleteValue(inputNumber);
            ui.PrintList();
        }

        public void OutputDeleteNegativeElements()
        {
            ui.DeleteNegativeElements();
            ui.PrintList();
        }

        public void OutputPrintIntegerNumber()
        {
            ui.PrintIntegerNumber();
            ui.PrintList();
        }

        public void OutputDescendingSort()
        {
            ui.DescendingSort();
            ui.PrintList();
        }

        public void OutputIndex()
        {
            int inputNumber = 0;
            Console.Write("Input number, please ");
            bool result = int.TryParse(Console.ReadLine(), out inputNumber);

            while (result == false || inputNumber < 0)
            {
                Console.WriteLine("Not valid");
                Console.WriteLine("You input wrong data, please try enter number again");
                result = int.TryParse(Console.ReadLine(), out inputNumber);
            }

            Console.WriteLine(ui[inputNumber]);
        }

        public void OutputPrintList()
        {
            ui.PrintList();
        }
        
    }
}
