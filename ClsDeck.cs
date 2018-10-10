using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingGameJdvallance
{
    class ClsDeck
    {
        private int count = 0;
        private string[] Deck = new string[52];
        private string[] Hand = new string[16];
        private string mCard;
        public ClsDeck()
        {
            BuildDeck();
        }
        public string Card
        {
            get
            {
                return mCard;
            }
            set
            {
                mCard = value;
            }
        }
        public void FetchHandFromDeck()
        {
            //Fills the Hand Array with pair cards from Deck Array using Search1 and Search2 private methods
            Random ObjR = new Random();
            Search1(ObjR.Next(0, 52));
            Search2();
        }

        public void ShuffleHand()
        {
            //Randomizes location of cards within the Hand Array so that when displayed pairs will be found in random locations
            Random ObjR = new Random();
            string temp;
            int randNum;
            for (int i = 0; i < 16; i++)
            {
                temp = Hand[i];
                randNum = ObjR.Next(0, 16);
                Hand[i] = Hand[randNum];
                Hand[randNum] = temp;
                count = 0;
            }

        }

        public void DealFromHand(int index)
        {
            //Uses the string values within the Hand Array to assign to Picture Box Arrays to begin the game  
            mCard = Hand[index];
        }

        public bool CheckHandForMatch(int index1, int index2)
        {
            //Checks for a match
            bool match = false;
            int card1 = index1;
            int card2 = index2;
            if (Hand[card1].Substring(0, 2) == Hand[card2].Substring(0, 2))
            {
                match = true;
            }
            return match;
        }

        private void BuildDeck()
        {
            //Builds the Deck by using numbers and suits to determine the string name of each Array element
            int count = 0;
            for (int i = 1; i <= 13; i++)
            {
                if (i >= 10)
                {
                    Deck[count] = i + "Hearts.jpg";
                }
                else
                {
                    Deck[count] = "0" + i + "Hearts.jpg";
                }
                count++;
            }
            for (int i = 1; i <= 13; i++)
            {
                if (i >= 10)
                {
                    Deck[count] = i + "Diamonds.jpg";
                }
                else
                {
                    Deck[count] = "0" + i + "Diamonds.jpg";
                }
                count++;
            }
            for (int i = 1; i <= 13; i++)
            {
                if (i >= 10)
                {
                    Deck[count] = i + "Clubs.jpg";
                }
                else
                {
                    Deck[count] = "0" + i + "Clubs.jpg";
                }
                count++;
            }
            for (int i = 1; i <= 13; i++)
            {
                if (i >= 10)
                {
                    Deck[count] = i + "Spades.jpg";
                }
                else
                {
                    Deck[count] = "0" + i + "Spades.jpg";
                }
                count++;
            }
        }

        private void Search1(int RandNum)
        {
            //Finds the first card of the matching pair and assigns it from Deck to Hand
            int i = 0;
            if (Deck[RandNum] == "xx")
            {
                while (Deck[i] == "xx")
                {
                    i++;
                }
                Hand[count] = Deck[i];
                Deck[i] = "xx";
            }
            else
            {
                Hand[count] = Deck[RandNum];
                Deck[RandNum] = "xx";
            }
            count++;
        }

        private void Search2()
        {
            //Finds the matching card and assigns it to the adjacent position of the card found in Search1 in the Hand Array
            int i = 0;
            while (Deck[i].Substring(0, 2) != Hand[count - 1].Substring(0, 2))
            {
                i++;
            }
            Hand[count] = Deck[i];
            count++;
            Deck[i] = "xx";
        }

    }
}
