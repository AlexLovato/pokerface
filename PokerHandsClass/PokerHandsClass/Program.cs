using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandsClass
{
    class Program
    {
        static void Main(string[] args)
        {
            var myHand = new hand("TH JH QH KH AH");
            Console.WriteLine(myHand.IsRoyalFlush());
            Console.ReadKey();
        }
    }
}
