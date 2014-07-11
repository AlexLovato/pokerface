using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandsClass
{
    class card
    {
        //Define properties of a poker card
        public int Rank { get; set; }
        public string Suit { get; set; }

        //Define constructor
        public card(string cardString){
            
            string tempRank = cardString[0].ToString();
            //execute code based on the value
            switch (tempRank)
            {       case "T":
                    this.Rank = 10;
                    break;
                    
                case "J":
                    this.Rank = 11;
                    break;

                case "Q":
                    this.Rank = 12;
                    break;

                case "K":
                    this.Rank = 13;
                    break;

                case "A":
                    this.Rank = 14;
                    break;
                default:
                    //not a special card 
                    this.Rank = int.Parse(tempRank);
                    break;
            }
            this.Suit = cardString[1].ToString();
        }
    }
}
