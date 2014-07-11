using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandsClass
{
   
    class hand
    {
        //define properties
        public List<card> Cards { get; set; }
        // constructors
        public hand(string handString){
            this.Cards = new List<card>();
            var tempList = handString.Split(' ').ToList();
            foreach(string eachcard in tempList){
                this.Cards.Add(new card(eachcard));
            }
            IsRoyalFlush();
            isFlush();
            isStraightFlush();
            isStraight();
            IsPair();
            IsTwoPair();
            IsHigh();
        }
        //new functions go here
        //like if we have a flush 
        public bool isFlush()//test flush
        {
            if (this.Cards.Select(x => x.Suit).Distinct().Count() == 1)
            {
                return true;
            }
            else return false;
            
        }
        public bool IsRoyalFlush()//test royal flush
        {
            //how to select just one property to examine 
            //and get only (distinct) values
            //only a flush
            if (this.Cards.Select(x => x.Suit).Distinct().Count() == 1)
            {
                string testString = string.Join("", this.Cards.OrderBy(x => x.Rank).Select(x => x.Rank));
                string tester = "1011121314";
                if (tester.Contains(testString))
                {
                    return true;
                }
                else return false;
            }
            else return false;
            
        }
        public bool isStraightFlush()//test straight flush
        {
            return this.Cards.Select(x => x.Suit).Distinct().Count() == 1;

        }
        public bool isStraight()//test straight
        {
            string testString = string.Join("", this.Cards.OrderBy(x => x.Rank).Select(x => x.Rank));
            string tester = "234567891011121314";//see if the ordered cards are in this string
            if (tester.Contains(testString))
            {
                return true;
            }
            else return false;
        }
        public bool IsPair()//test for pair
        {
            return this.Cards.Select(x => x.Rank).Distinct().Count() == 4;
        }
        public bool IsTwoPair()//test for two pair
        {
            return this.Cards.Select(x => x.Rank).Distinct().Count() == 3;
        }
        public bool IsHigh()//tset for high card
        {
            if (this.Cards.Select(x => x.Rank).Distinct().Count() == 5 && !isFlush() && !isStraight())
            {
                return true;
            }
            else return false;
        }
        public bool ThreeOfAKind()//test for three of kidn
        {
           var tmp = this.Cards.GroupBy(x => x.Rank).Select(x=> new {
                Rank = x.Key,
                Count = x.Count()
            }).OrderByDescending(x=>x.Count);
            return tmp.First().Count == 3;
        }
        public bool FourOfAKind()//test for four of kind
        {
            var tmp = this.Cards.GroupBy(x => x.Rank).Select(x => new
            {
                Rank = x.Key,
                Count = x.Count()
            }).OrderByDescending(x => x.Count);
            return tmp.First().Count == 4;
        }
    }
}
