using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_labs_
{
    public class PupilsData
    {
        private List<Pupil> pupils;

        public PupilsData()
        {
            pupils = new List<Pupil>()
            {
                new Pupil
                {
                    Surname = "Bondarenko",
                    Name = "Boris",
                    Birthday = new Birthday
                    {
                        Day = 10,
                        Month = 11,
                        Year = 1996
                    },
                    AverageMark = 5
                },
                new Pupil
                {
                    Surname = "Kryvko",
                    Name = "Evheniya",
                    Birthday = new Birthday
                    {
                        Day = 12,
                        Month = 11,
                        Year = 1996
                    },
                    AverageMark = 5
                },
                new Pupil
                {
                    Surname = "Kryvko",
                    Name = "Valentina",
                    Birthday = new Birthday
                    {
                        Day = 14,
                        Month = 11,
                        Year = 1994
                    },
                    AverageMark = 5
                },
                new Pupil
                {
                    Surname = "Prothuk",
                    Name = "Elena",
                    Birthday = new Birthday
                    {
                        Day = 19,
                        Month = 11,
                        Year = 1993
                    },
                    AverageMark = 5
                },
                new Pupil
                {
                    Surname = "Virodov",
                    Name = "Konstantin",
                    Birthday = new Birthday
                    {
                        Day = 9,
                        Month = 3,
                        Year = 1996
                    },
                    AverageMark = 5
                },
                new Pupil
                {
                    Surname = "Vovk",
                    Name = "Anton",
                    Birthday = new Birthday
                    {
                        Day = 5,
                        Month = 11,
                        Year = 1996
                    },
                    AverageMark = 3
                },
                new Pupil
                {
                    Surname = "Kryvko",
                    Name = "Aleksandra",
                    Birthday = new Birthday
                    {
                        Day = 30,
                        Month = 5,
                        Year = 2000
                    },
                    AverageMark = 5
                },
                new Pupil
                {
                    Surname = "Rudic",
                    Name = "Mila",
                    Birthday = new Birthday
                    {
                        Day = 23,
                        Month = 4,
                        Year = 1999
                    },
                    AverageMark = 4
                }
            };
        }

        public PupilsData(List<Pupil> pupils)
        {
            if(pupils == null)
            {
                throw new ArgumentException("Pupils can't be null");
            }

            this.pupils = pupils;
        }
        public List<Pupil> GetAllPupils()
        {
            return pupils;
        }

    }
}
