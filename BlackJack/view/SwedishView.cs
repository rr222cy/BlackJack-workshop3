﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.view
{
    class SwedishView : IView 
    {
        // Constants for the menu choices
        const char quit = 'a';
        const char newGame = 'p';
        const char hit = 'n';
        const char stand = 's';

        // Getters for the constants
        public char GetQuit()
        {
            return quit;
        }

        public char GetNewGame()
        {
            return newGame;
        }

        public char GetHit()
        {
            return hit;
        }

        public char GetStand()
        {
            return stand;
        }

        public void DisplayWelcomeMessage()
        {
            System.Console.Clear();
            System.Console.WriteLine("Hej Black Jack Världen");
            System.Console.WriteLine("----------------------");
            System.Console.WriteLine("Skriv '{0}' för att Spela, '{1}' för nytt kort, '{2}' för att stanna '{3}' för att avsluta\n", newGame, hit, stand, quit);
        }

        public void DisplayCard(model.Card a_card)
        {
            if (a_card.GetColor() == model.Card.Color.Hidden)
            {
                System.Console.WriteLine("Dolt Kort");
            }
            else
            {
                String[] colors = new String[(int)model.Card.Color.Count]
                    { "Hjärter", "Spader", "Ruter", "Klöver" };
                String[] values = new String[(int)model.Card.Value.Count] 
                    { "två", "tre", "fyra", "fem", "sex", "sju", "åtta", "nio", "tio", "knekt", "dam", "kung", "ess" };
                System.Console.WriteLine("{0} {1}", colors[(int)a_card.GetColor()], values[(int)a_card.GetValue()]);
            }
        }
        public void DisplayPlayerHand(IEnumerable<model.Card> a_hand, int a_score)
        {
            DisplayHand("Spelare", a_hand, a_score);
        }
        public void DisplayDealerHand(IEnumerable<model.Card> a_hand, int a_score)
        {
            DisplayHand("Croupier", a_hand, a_score);
        }
        public void DisplayGameOver(bool a_dealerIsWinner)
        {
            System.Console.Write("Slut: ");
            if (a_dealerIsWinner)
            {
                System.Console.WriteLine("Croupiern Vann!");
            }
            else
            {
                System.Console.WriteLine("Du vann!");
            }
        }

        private void DisplayHand(String a_name, IEnumerable<model.Card> a_hand, int a_score)
        {
            System.Console.WriteLine("{0} Har: ", a_name);
            foreach (model.Card c in a_hand)
            {
                DisplayCard(c);
            }
            System.Console.WriteLine("Poäng: {0}", a_score);
            System.Console.WriteLine("");
        }

        public int GetInput()
        {
            return System.Console.In.Read();
        }

        public void ShowBlackJack(IEnumerable<model.Card> dealerHand, IEnumerable<model.Card> playerHand, int dealerScore, int playerScore, bool gameOver, bool isDealerWinner)
        {
            DisplayDealerHand(dealerHand, dealerScore);
            DisplayPlayerHand(playerHand, playerScore);
            if (gameOver)
            {
                DisplayGameOver(isDealerWinner);
            }
        }
    }
}
