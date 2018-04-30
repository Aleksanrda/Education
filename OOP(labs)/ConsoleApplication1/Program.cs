using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1_2.Models;
//Создать массив, в котором записать информацию об общежитии: номер комнаты, номер этажа, количество проживающих в комнате, 
//массив фамилий жильцов. В комнате может проживать не более пяти человек, а количество проживающих – менее или равно пяти 
//(то есть в комнатах могут быть свободные места). 
//а) Считать с клавиатуры фамилию и вывести номера этажей и комнат, где проживают люди с такой фамилией.
//б) Вывести список комнат, в которых есть свободные места в виде: номер комнаты, количество свободных мест, отсортировав вывод в порядке убывания свободных мест.
//в) Для каждого этажа получить количество свободных комнат и процент заселенности(количество проживающих/ общее количество мест на этаже).

namespace Lab1_2
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                HostelUI hostelUI = new HostelUI();


                var room = new Room[1];

                Console.WriteLine("1 - Get information about number of flour and number of room");

                Console.WriteLine("2 - Get information about count of free place in room");

                Console.WriteLine("3 - Get information about count of free room and percentage of population");

                Console.WriteLine("4 - You can print all members of hostel");

                Console.WriteLine("5 - Input number of room, input surname and do attempt to add person");

                Console.WriteLine("6 - Input number of room, input surname and do attempt to delete person");

                Console.WriteLine(" ");

                Console.WriteLine("You can input number six times and choose six different methods only! ");

                Console.WriteLine(" ");

                for (int i = 0; i < 6; i++)
                {
                    Console.WriteLine("Input one of number to get information you want, please ");
                    int inputNumber = 0;
                    bool result = int.TryParse(Console.ReadLine(), out inputNumber);

                    while (result == false)
                    {
                        Console.WriteLine("Not valid");
                        Console.WriteLine("You input wrong data, please try enter number again");
                        result = int.TryParse(Console.ReadLine(), out inputNumber);
                    }

                    while (inputNumber < 1 && inputNumber > 6)
                    {
                        Console.WriteLine("You input wrong number, please enter number again");
                        result = int.TryParse(Console.ReadLine(), out inputNumber);
                    }

                    if (inputNumber == 1)
                    {
                        hostelUI.SearchPlaceBySurname();
                    }

                    else if (inputNumber == 2)
                    {
                        hostelUI.OutputListOfFreePlaceInRoom();

                    }

                    else if (inputNumber == 3)
                    {

                        hostelUI.OutputFreeRoomOnEveryFlourAndPercentageOfPopulation();
                    }

                    else if (inputNumber == 4)
                    {
                        hostelUI.PrintAllPersonsInHostel();
                    }

                    else if (inputNumber == 5)
                    {
                        hostelUI.Add();
                    }

                    else if (inputNumber == 6)
                    {
                        hostelUI.Remove();
                    }
                }

                Console.WriteLine("You use all attempts");

                Console.ReadKey();
            }
            catch
            {
                Console.WriteLine("Error");
                Console.Read();
            }
        }
    }
}
