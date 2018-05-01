using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Создать массив, в котором записать информацию об учениках класса: фамилию, имя, дату рождения (в виде структуры с полями день, месяц, год), 
//средний балл. Вывести для введенного месяца года количество человек, родившихся в нем.
namespace OOP_labs_
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PupilsUI pupilsUI = new PupilsUI();
                var pupil = new Pupil[1];
                pupilsUI.CountSameYearAndMonth();
            }
            catch
            {
                Console.WriteLine("Error");
                Console.Read();
            }
        }
    }
}
