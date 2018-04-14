using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Создать массив, в котором записать информацию об учениках класса: фамилию, имя, дату рождения (в виде структуры с полями день, месяц, год), 
//средний балл. Вывести для введенного месяца года количество человек, родившихся в нем.
namespace OOP_labs_
{
   class Pupil
    {
        public string Surname { get; set; }
        public string Name  { get; set; }
        public Birthday Birthday { get; set; }
        public double AverageMark { get; set; }
    }

struct Birthday
{
    public int Day;
    public int Month;
    public int Year;
}
    class Program
    {
        
        static void Main(string[] args)
        {
            int countPupilsInClass = 0;
            int countPupilsOfSameYearAndMonth = 0;
            Console.WriteLine("Input count of pupils, please");
            countPupilsInClass = int.Parse(Console.ReadLine());
            Pupil[] pupils = new Pupil[countPupilsInClass];

            for(int i = 0; i<pupils.Length; i++)
            {
                pupils[i] = new Pupil();
                Console.Write("Name: ");
                pupils[i].Name = Console.ReadLine();
                Console.Write("SurName: ");
                pupils[i].Surname = Console.ReadLine();
                Console.Write("Average Mark: ");
                pupils[i].AverageMark = double.Parse(Console.ReadLine());

                Console.Write("Birthday(day.month.year) : ");
                string[] str = Console.ReadLine().Split('.');
                pupils[i].Birthday = new Birthday { Day = int.Parse(str[0]), Month = int.Parse(str[1]), Year = int.Parse(str[2]) };
            }

            Console.Write("Input month and year  to searching(month.year) : ");
            string[] birthday = Console.ReadLine().Split('.');
            for (int i = 0; i < countPupilsInClass; i++)
            {
                if ((int.Parse(birthday[0])==pupils[i].Birthday.Month) && (int.Parse(birthday[1])==pupils[i].Birthday.Year))
                {
                    countPupilsOfSameYearAndMonth++;
                }
            }
            Console.WriteLine("Count of same birthdays = " + countPupilsOfSameYearAndMonth);
            Console.ReadKey();
        }
    }
}
