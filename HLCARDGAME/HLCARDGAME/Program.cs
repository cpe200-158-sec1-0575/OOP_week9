using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLCARDGAME
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player();
            Player player2 = new Player();
            Control.Setting(player1, player2);
            do
                Control.Playing(player1, player2);
            while (player1.PlayedDeck.Cards.Count != 0);
            Control.WhoWinGame(player1, player2);
            System.Console.ReadKey();

        }
    }
}
