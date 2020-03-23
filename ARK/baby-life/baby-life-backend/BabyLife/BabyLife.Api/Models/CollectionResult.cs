using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabyLife.Api.Models
{
    public class CollectionResult<T>
    {
        public IEnumerable<T> Items { get; }

        public int TotalAmount { get; }

        public CollectionResult(IEnumerable<T> items, int totalAmount)
        {
            Items = items;
            TotalAmount = totalAmount;
        }
    }
}
