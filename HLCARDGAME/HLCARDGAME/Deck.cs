using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLCARDGAME
{
    class Deck
    {
        public List<Card> Cards;

        public Deck()
        {
            Cards = new List<Card>();
        }

        public Deck(int playerValue = 13, int playerSuit = 4) : this()
        {

            for (int i = 0; i < playerValue; i++)
            {
                for (int j = 0; j < playerSuit; j++)
                {
                    Cards.Add(new Card(i, j));
                }
            }
        }

        public Card TopCard()
        {
            return Cards[this.Cards.Count - 1];
        }
        public Card CardAt(int position)
        {
            return Cards[this.Cards.Count - (1 + position)];
        }
        public Card LastCard()
        {
            return Cards[0];
        }
        public void RemoveTopCard()
        {
            Cards.RemoveAt(this.Cards.Count - 1);
        }

        public void Shuffle()
        {
            Random random = new Random();
            for (int i = 0; i < Cards.Count; i++)
            {
                var j = random.Next(i, Cards.Count);
                var k = Cards[i];
                Cards[i] = Cards[j];
                Cards[j] = k;
            }
        }
    }
}
