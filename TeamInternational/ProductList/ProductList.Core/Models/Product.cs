using System;

namespace ProductList.Core.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Count { get; set; }

        public Quizine Quizine { get; set; }  
    }
}
