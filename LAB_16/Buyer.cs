using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace LAB_16
{
    class Buyer
    {
        string Name { get; }

        public Buyer(string name)
        {
            Name = name;
        }

        public void Take(BlockingCollection<string> stock)
        {
            if (stock.TryTake(out string product))
                Console.WriteLine($"{Name} потребил продукт");

        }
        
    }
}
