using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Soldier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public int Age { get; set; }

        public string Character { get; set; }
        public string ServiceAttitude { get; set; }

        public Adress ParentAdress { get; set; }
        public Educational Educational { get; set; }
        public Service Service { get; set; }
        public Soldier() { }
    }
}
