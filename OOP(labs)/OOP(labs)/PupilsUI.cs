using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_labs_
{
    public class PupilsUI
    {
        private PupilsManager pupilsManager;
        public PupilsUI()
        {
            pupilsManager = new PupilsManager();
        }

        public void CountSameYearAndMonth()
        {
            Console.Write("Input month and year  to searching(month.year) : ");

            string[] birthday = Console.ReadLine().Split('.');
            var resultCountSameYearAndMonth = pupilsManager.GetCountPupilsOfSameYearAndMonth(birthday);

            Console.WriteLine("Count of same birthdays:" + resultCountSameYearAndMonth);
            Console.ReadKey();
        }
    }
}
