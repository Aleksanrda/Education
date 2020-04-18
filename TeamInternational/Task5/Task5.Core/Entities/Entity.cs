using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Task5.Core.Entities
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
