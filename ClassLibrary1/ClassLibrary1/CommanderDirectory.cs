using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Models;
using ClassLibrary1.Infrastrcture;

namespace ClassLibrary1
{
    public class CommanderDirectory
    {
        private List<Soldier> soldiers;

        public CommanderDirectory()
        {
            LoadSoldiers();
            //if (soldiers == null)
            //{
            //    throw new ArgumentNullException("Soldiers can't be null");
            //}
            //soldiers = new List<Soldier>();

            //using (TextReader reader = new StreamReader("soldiers.txt"))
            //{
            //    int n = Convert.ToInt32(reader.ReadLine());
            //    while (n-- > 0)
            //    {
            //        soldiers.Add(new Soldier
            //        {
            //            Id = Convert.ToInt32(reader.ReadLine()),
            //            Name = reader.ReadLine(),
            //            Surname = reader.ReadLine(),
            //            Patronymic = reader.ReadLine(),
            //            Age = Convert.ToInt32(reader.ReadLine()),
            //            Character = reader.ReadLine(),
            //            ServiceAttitude = reader.ReadLine(),
            //            ParentAdress = new Adress
            //            {
            //                City = reader.ReadLine(),
            //                Street = reader.ReadLine(),
            //                NumberHouse = Convert.ToInt32(reader.ReadLine()),
            //                NumberFlat = Convert.ToInt32(reader.ReadLine())
            //            },
            //            Educational = new Educational
            //            {
            //                CivilProfession = reader.ReadLine(),
            //                Education = reader.ReadLine(),
            //                Rank = reader.ReadLine(),
            //                DataReceiveRank = reader.ReadLine()
            //            },
            //            Service = new Service
            //            {
            //                Post = reader.ReadLine(),
            //                Subdivision = reader.ReadLine(),
            //                FormService = reader.ReadLine(),
            //                PeriodService = reader.ReadLine()
            //            }
            //        });
            //    }
            //}
        }



        public void LoadSoldiers()
        {
            soldiers = new List<Soldier>();
            using (TextReader reader = new StreamReader("soldiers.txt"))
            {
                int n = Convert.ToInt32(reader.ReadLine());
                while (n-- > 0)
                {
                    soldiers.Add(new Soldier
                    {
                        Id = Convert.ToInt32(reader.ReadLine()),
                        Name = reader.ReadLine(),
                        Surname = reader.ReadLine(),
                        Patronymic = reader.ReadLine(),
                        Age = Convert.ToInt32(reader.ReadLine()),
                        Character = reader.ReadLine(),
                        ServiceAttitude = reader.ReadLine(),
                        ParentAdress = new Adress
                        {
                            City = reader.ReadLine(),
                            Street = reader.ReadLine(),
                            NumberHouse = Convert.ToInt32(reader.ReadLine()),
                            NumberFlat = Convert.ToInt32(reader.ReadLine())
                        },
                        Educational = new Educational
                        {
                            CivilProfession = reader.ReadLine(),
                            Education = reader.ReadLine(),
                            Rank = reader.ReadLine(),
                            DataReceiveRank = reader.ReadLine()
                        },
                        Service = new Service
                        {
                            Post = reader.ReadLine(),
                            Subdivision = reader.ReadLine(),
                            FormService = reader.ReadLine(),
                            PeriodService = reader.ReadLine()
                        }
                    });
                }
            }
        }

        public List<Soldier> GetAllSoldiers()
        {
            return soldiers;
        }

        public List<Soldier> AddDefaultSoldier()
        {
            soldiers.Add(new Soldier
            {
                Id = 4,
                Name = "Роман",
                Surname = "еаегаг",
                Patronymic = "ПРспрсп",
                Age = 5,
                Character = "мромр",
                ServiceAttitude = "рпапрс",
                ParentAdress = new Adress
                {
                    City = "Харьков",
                    Street = "апрс",
                    NumberHouse = 5,
                    NumberFlat = 78
                },
                Educational = new Educational
                {
                    CivilProfession = "нвсосгсп",
                    Education = "раопо",
                    Rank = "рсрвр",
                    DataReceiveRank = "пачрачр"
                },
                Service = new Service
                {
                    Post = "рпспрспо",
                    Subdivision = "сопсоа",
                    FormService = "нврев",
                    PeriodService = "12.08.2018-13.04.2020"
                }
            });

            return soldiers;
        }

        public void AddSoldier(Soldier soldier)
        {
            var id = soldiers.Last().Id + 1;
            soldier.Id = id;

            soldiers.Add(soldier);
        }

        public List<SearchSoldier> SearchByFullName(string stringToSearchBy)
        {         
            List<SearchSoldier> searchSoldiers = new List<SearchSoldier>();

            var sequenceSoldiers = soldiers.Where(p => p.Name.Contains(stringToSearchBy)
                || p.Surname.Contains(stringToSearchBy)
                || p.Patronymic.Contains(stringToSearchBy));

            foreach (var s in sequenceSoldiers)
            {
                SearchSoldier result = new SearchSoldier(s);
                searchSoldiers.Add(result);
            }

            return searchSoldiers;
        }

        public void RemoveSoldier(string soldier)
        {

            for (int i = 0; i < soldiers.Count; i++)
            {
                if (soldier == soldiers[i].Surname)
                {
                    soldiers.Remove(soldiers[i]);
                }
            }
        }

        public void RemoveSoldier(int soldierId)
        {
            // TODO: Додати трай кетч для обробки ситуації, коли не знайдено жодного солдата з таким айдішніком чи знайдено бульше одного солдату
            var soldierToRemove = soldiers.SingleOrDefault(s => s.Id == soldierId);
            soldiers.Remove(soldierToRemove);
        }

        public void UpdateSoldier(int soldierId, Soldier soldierToUpdate)
        {
            //for (int i = 0; i < soldiers.Count; i++)
            //{
            //    if (idSoldier == soldiers[i].Id)
            //    {

            //    }
            //}

            try
            {
                var soldier = soldiers.SingleOrDefault(s => s.Id == soldierId);

                if (soldier == null)
                {
                    AddSoldier(soldierToUpdate);

                    throw new ComanderException($"Жоден солдат з айдішіком {soldierId} не був знайдений, тому був створений новий солдат з айдішником {soldier.Id}.");
                }

                soldier.Name = soldierToUpdate.Name;
                soldier.Service = soldierToUpdate.Service;
                soldier.Patronymic = soldierToUpdate.Patronymic;
                soldier.Age = soldierToUpdate.Age;
                soldier.Character = soldierToUpdate.Character;
                soldier.ServiceAttitude = soldierToUpdate.ServiceAttitude;
                soldier.ParentAdress.City = soldierToUpdate.ParentAdress.City;
                soldier.ParentAdress.Street = soldierToUpdate.ParentAdress.Street;
                soldier.ParentAdress.NumberHouse = soldierToUpdate.ParentAdress.NumberHouse;
                soldier.ParentAdress.NumberFlat = soldierToUpdate.ParentAdress.NumberFlat;


                // TODO: Додати оновлення усіх полів для солдата
            }
            catch(InvalidOperationException ex)
            {
                throw new ComanderException($"Більш ніж один солдат має аналогчний айдішник - {soldierId}. Видаліть зайвих солдат з таким же айдішником чи виберіть іншого солдата.", ex);
            }

        }
    }
}
