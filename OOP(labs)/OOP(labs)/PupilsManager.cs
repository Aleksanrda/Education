using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_labs_
{
    public class PupilsManager
    {
        private PupilsData pupilData;

        public PupilsManager()
        {
            this.pupilData = new PupilsData();
        }

        public int GetCountPupilsOfSameYearAndMonth(string[] birthday)
        {
            var pupils = this.pupilData.GetAllPupils();
            int countPupilsOfSameYearAndMonth = 0;

            for (int i = 0; i < pupils.Count; i++)
            {
                if ((int.Parse(birthday[0]) == pupils[i].Birthday.Month) && (int.Parse(birthday[1]) == pupils[i].Birthday.Year))
                {
                    countPupilsOfSameYearAndMonth++;
                }
            }

            return countPupilsOfSameYearAndMonth;
        }
    }
}
