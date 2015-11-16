using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLCARDGAME
{
    class Player
    {
        private Deck _playedDeck;
        private Deck _countWin;
        private string _name;

        public Deck PlayedDeck
        {
            get
            {
                return _playedDeck;
            }

            set
            {
                _playedDeck = value;
            }
        }

        public Deck CountWin
        {
            get
            {
                return _countWin;
            }

            set
            {
                _countWin = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public Player()
        {
            Name = "Unknown";
            PlayedDeck = new Deck();
            CountWin = new Deck();
        }
    }
}
