using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLCARDGAME
{
    class Card
    {
        private int _ranked;
        private int _suit;


        protected string[] suit = { "Clubs", "Diamonds", "Hearts", "Spades" };
        protected string[] ranked = { "Ace", "Deuce", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };

        public int Ranked
        {
            get
            {
                return _ranked;
            }

            set
            {
                _ranked = value;
            }
        }

        public int Suit
        {
            get
            {
                return _suit;
            }

            set
            {
                _suit = value;
            }
        }

        public override string ToString()
        {
            return string.Format(ranked[Ranked] + " of " + suit[Suit]);
        }

        public Card()
        {
            Ranked = 0;
            Suit = 0;
        }

        public Card(int value, int suit)
        {
            Ranked = value;
            Suit = suit;
        }
    }
}
