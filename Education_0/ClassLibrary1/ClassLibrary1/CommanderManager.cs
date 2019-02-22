//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using ClassLibrary1.Models;

//namespace ClassLibrary1
//{
//    public class CommanderManager
//    {
//        private CommanderDirectory _commanderDirectory;

//        public CommanderManager()
//        {
//            this._commanderDirectory = new CommanderDirectory();
//        }

//        public bool Add(string soldier)
//        {
//            if (soldier == null)
//            {
//                throw new ArgumentNullException("Soldier can't be null");
//            }

//            this._commanderDirectory.AddSoldier(soldier);
//            return true;
//        }

//        public bool Remove(string soldier)
//        {
//            if (soldier == null)
//            {
//                throw new ArgumentNullException("Soldier can't be null");
//            }

//            this._commanderDirectory.RemoveSoldier(soldier);
//            return true;
//        }

//        public bool Change(int idSoldier)
//        {
//            if (idSoldier == null)
//            {
//                throw new ArgumentNullException("Soldier can't be null");
//            }

//            this._commanderDirectory.ChangeDataOfSoldier(idSoldier);
//            return true;
//        }

//        public List<SearchSoldier> OutputSearchSoldier(string userString)
//        {

//            var soldiers = this._commanderDirectory.GetAllSoldiers();
//            List<SearchSoldier> searchSoldiers = new List<SearchSoldier>();

//            var sequenceSoldiers = soldiers.Where(p => p.Name.StartsWith(userString));

//            foreach (var s in sequenceSoldiers)
//            {
//                SearchSoldier result = new SearchSoldier(s);
//                searchSoldiers.Add(result);
//            }
                
//            return searchSoldiers;
//        }

//    }
//}
