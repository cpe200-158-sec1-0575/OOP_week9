using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLCARDGAME
{
    class Control
    {
        
            static Deck maindeck;
            public static void Setting(Player player1, Player player2)
            {
                maindeck = new Deck(13, 4);
                System.Console.WriteLine("Welcome to High-Low Card Game!!!");
                maindeck.Shuffle();
                System.Console.Write("Player1 Name : ");
                player1.Name = System.Console.ReadLine();
                System.Console.Write("Player2 Name : ");
                player2.Name = System.Console.ReadLine();
                System.Console.WriteLine("----------------------------------");
                for (int i = 0; i < 52; i += 2)
                {
                    player1.PlayedDeck.Cards.Add(maindeck.Cards[i]);
                    player2.PlayedDeck.Cards.Add(maindeck.Cards[i + 1]);
                }
            }

            public static void Playing(Player player1, Player player2)
            {
                System.Console.WriteLine("\nNew Round");
                System.Console.WriteLine(player1.Name + " : " + player1.PlayedDeck.TopCard().ToString());
                System.Console.WriteLine(player2.Name + " : " + player2.PlayedDeck.TopCard().ToString());
                Compare(player1, player2);
                System.Console.WriteLine("----------------------------------");
            }

            public static void Compare(Player player1, Player player2)
            {
                int card1 = player1.PlayedDeck.TopCard().Ranked;
                int card2 = player2.PlayedDeck.TopCard().Ranked;

                if (player1.PlayedDeck.Cards.Count == 1 && card1 == card2)
                {
                    System.Console.WriteLine("Last round is draw.");
                    player1.PlayedDeck.RemoveTopCard();
                    player2.PlayedDeck.RemoveTopCard();
                }
                else if (card1 == card2)
                {
                    System.Console.WriteLine("Draw!");
                    System.Console.WriteLine("\n");
                    int card_rank1 = 0;
                    int card_rank2 = 0;
                    int shift1 = 0;
                    int shift2 = 0;
                    if ((player1.PlayedDeck.Cards.Count - card1 - 1) <= 0)
                    {
                        System.Console.WriteLine("Not enough cards to play.");
                        System.Console.WriteLine("Time to open  the last card.");
                        card_rank1 = player1.PlayedDeck.LastCard().Ranked;
                        card_rank2 = player2.PlayedDeck.LastCard().Ranked;
                        shift1 = player1.PlayedDeck.Cards.Count - (1 + 1/*-first card*/);
                        shift2 = player1.PlayedDeck.Cards.Count - (1 + 1/*-first card*/);
                        System.Console.WriteLine(player1.Name + " : " + player1.PlayedDeck.CardAt(shift1 + 1/*+first card*/).ToString());
                        System.Console.WriteLine(player2.Name + " : " + player2.PlayedDeck.CardAt(shift2 + 1/*+first card*/).ToString());
                    }
                    else
                    {
                        card_rank1 = player1.PlayedDeck.CardAt(card1).Ranked;
                        card_rank2 = player2.PlayedDeck.CardAt(card2).Ranked;
                        shift1 = card1;
                        shift2 = card2;
                        System.Console.WriteLine(player1.Name + " : " + player1.PlayedDeck.CardAt(shift1).ToString());
                        System.Console.WriteLine(player2.Name + " : " + player2.PlayedDeck.CardAt(shift2).ToString());
                    }
                    if (card_rank1 == card_rank2)
                    {
                        System.Console.WriteLine("This round is draw 2 times.");
                        System.Console.WriteLine("Shuffle Time!");
                        player1.PlayedDeck.Shuffle();
                        player2.PlayedDeck.Shuffle();
                    }
                    else if (card_rank1 > card_rank2)
                    {
                        for (int i = 0; i < (shift2 + 1 + 1/*first card*/); i++)
                        {
                            player2.CountWin.Cards.Add(player1.PlayedDeck.TopCard());
                            player2.CountWin.Cards.Add(player2.PlayedDeck.TopCard());
                            player1.PlayedDeck.RemoveTopCard();
                            player2.PlayedDeck.RemoveTopCard();


                        }
                        WhowinRound(player2);
                    }
                    else if (card_rank1 < card_rank2)
                    {
                        for (int i = 0; i < (shift1 + 1 + 1/*first card*/); i++)
                        {
                            player1.CountWin.Cards.Add(player1.PlayedDeck.TopCard());
                            player1.CountWin.Cards.Add(player2.PlayedDeck.TopCard());
                            player1.PlayedDeck.RemoveTopCard();
                            player2.PlayedDeck.RemoveTopCard();
                        }
                        WhowinRound(player1);
                    }
                }

                else if (card1 > card2)
                {
                    player2.CountWin.Cards.Add(player1.PlayedDeck.TopCard());
                    player2.CountWin.Cards.Add(player2.PlayedDeck.TopCard());
                    player1.PlayedDeck.RemoveTopCard();
                    player2.PlayedDeck.RemoveTopCard();
                    WhowinRound(player2);
                }
                else if (card1 < card2)
                {
                    player1.CountWin.Cards.Add(player1.PlayedDeck.TopCard());
                    player1.CountWin.Cards.Add(player2.PlayedDeck.TopCard());
                    player1.PlayedDeck.RemoveTopCard();
                    player2.PlayedDeck.RemoveTopCard();
                    WhowinRound(player1);
                }
            }
            public static void WhowinRound(Player player)
            {
                System.Console.WriteLine(player.Name + " win this round.");
                System.Console.WriteLine(player.Name + " have " + player.CountWin.Cards.Count + " cards left in win deck.");
                System.Console.WriteLine("They have " + player.PlayedDeck.Cards.Count + " cards in played deck.");
            }
            public static void WhoWinGame(Player player1, Player player2)
            {
                System.Console.WriteLine("\n!!!!!!!!!!!!!!!!!!!!!!!!");
                System.Console.WriteLine(player1.Name + " have " + player1.CountWin.Cards.Count + " cards in win deck.");
                System.Console.WriteLine(player2.Name + " have " + player2.CountWin.Cards.Count + " cards in win deck.");
                if (player1.CountWin.Cards.Count > player2.CountWin.Cards.Count)
                {
                    System.Console.WriteLine("The winner is " + player1.Name);
                }
                else if (player1.CountWin.Cards.Count < player2.CountWin.Cards.Count)
                {
                    System.Console.WriteLine("The winner is " + player2.Name);
                }
                else
                    System.Console.WriteLine("No winner.It's draw!!!");

            }
        }
}
