using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Task5.Core.Entities
{
    public class Amount : Entity
    {
        [Required]
        public int FlowerAmount { get; set; }
    }
}
