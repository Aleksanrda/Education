using System;

namespace FairyTale.Entities
{
    public abstract class Character
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public int CountLikes { get; set; }

        public string Personality { get; set; }
    }
}
