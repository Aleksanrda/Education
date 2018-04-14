using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Создать массив, в котором записать информацию об общежитии: номер комнаты, номер этажа, количество проживающих в комнате, 
//массив фамилий жильцов. В комнате может проживать не более пяти человек, а количество проживающих – менее или равно пяти 
//(то есть в комнатах могут быть свободные места). 
//а) Считать с клавиатуры фамилию и вывести номера этажей и комнат, где проживают люди с такой фамилией.
//б) Вывести список комнат, в которых есть свободные места в виде: номер комнаты, количество свободных мест, отсортировав вывод в порядке убывания свободных мест.
//в) Для каждого этажа получить количество свободных комнат и процент заселенности(количество проживающих/ общее количество мест на этаже).

namespace OOP_Labs
{
    class Program
    {
        public static void Main(string[] args)
        {
            //var hostel4 = new Hostel(40);
            //var hostel5 = new Hostel(100);

            var room = Hostel.GetDataOfRooms();

            Console.WriteLine("1 - Get information about number of flour and number of room");

            Console.WriteLine("2 - Get information about count of free place in room");

            Console.WriteLine("3 - Get information about count of free room and percentage of population");

            Console.WriteLine(" ");

            Console.WriteLine("You can input number three times and choose three different methods only! ");

            Console.WriteLine(" ");

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Input one of number to get information you want, please ");
                int inputNumber = 0;
                bool  result = int.TryParse(Console.ReadLine(), out inputNumber);
                if (result == false)
                {
                    Console.WriteLine("Not valid");
                    Console.WriteLine("You input wrong data, please try enter number again");

                }

                else
                {
                    while (inputNumber != 1 && inputNumber != 2 && inputNumber != 3)
                    {
                        Console.WriteLine("You input wrong number, please enter number again");
                        int repeatInputNumber = int.Parse(Console.ReadLine());
                    }

                    if (inputNumber == 1)
                    {
                        Hostel.SearchPlaceBySurname(room);

                        Console.ReadKey();
                    }

                    else if (inputNumber == 2)
                    {
                        string secondMethod = Hostel.OutputListOfFreePlaceInRoom(room);
                        Console.WriteLine(secondMethod);
                        Console.ReadKey();
                    }
                    else if (inputNumber == 3)
                    {
                        string thirdMethod = Hostel.OutputFreeRoomAndPercentageOfPopulation(room);
                        Console.WriteLine(thirdMethod);
                        Console.ReadKey();
                    }
                }

               
            }


            Console.WriteLine("You use all attempts");

            Console.ReadKey();
        }

    }
}
