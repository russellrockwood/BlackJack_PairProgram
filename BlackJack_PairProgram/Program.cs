using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack_PairProgram
{

    class Program
    {

        static void Main(string[] args)
        {
            BlackJack game = new BlackJack();

            game.PlayGame();
        }
    }

    public class BlackJack
    {
        public int PlayerScore = 0;
        public int Max = 21;
        public int DealerScore = 0;


        public void PlayerHit()
        {
            Random random = new Random();

            Dictionary<string, int> dictionary = new Dictionary<string, int>
            {
                { "A", 1 },
                { "2", 2 },
                { "3", 3 },
                { "4", 4 },
                { "5", 5 },
                { "6", 6 },
                { "7", 7 },
                { "8", 8 },
                { "9", 9 },
                { "10", 10 },
                { "J", 10 },
                { "Q", 10 },
                { "K", 10 }
            };

            for (int i = 0; i < 1; ++i)
            {
                int index = random.Next(dictionary.Count);

                //string key = dictionary.Keys.ElementAt(index);
                //int value = dictionary.Values.ElementAt(index);

                KeyValuePair<string, int> pair = dictionary.ElementAt(index);

                char suit = GetIcon();
                Console.WriteLine("Card: " + pair.Key + " " + suit);
                PlayerScore += pair.Value;


            }
        }

        public char GetIcon()
        {
            Random random = new Random();

            List<char> suits = new List<char>();
            suits.Add('♣');
            suits.Add('♠');
            suits.Add('♦');
            suits.Add('♥');

            int index = random.Next(suits.Count);
            char randomIcon = suits[index];

            //if (randomIcon == '♥' || randomIcon == '♦')
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //}
            //else
            //{
            //    Console.ForegroundColor = ConsoleColor.White;
            //}
            return randomIcon;
        }
        public void DealerHit()
        {
            Random random = new Random();

            Dictionary<string, int> dictionary = new Dictionary<string, int>
            {
                { "A", 1 },
                { "2", 2 },
                { "3", 3 },
                { "4", 4 },
                { "5", 5 },
                { "6", 6 },
                { "7", 7 },
                { "8", 8 },
                { "9", 9 },
                { "10", 10 },
                { "J", 10 },
                { "Q", 10 },
                { "K", 10 }
            };

            for (int i = 0; i < 1; ++i)
            {
                int index = random.Next(dictionary.Count);
                KeyValuePair<string, int> pair = dictionary.ElementAt(index);
                char suit = GetIcon();
                Console.WriteLine("Dealer Card: " + pair.Key + " " + suit);
                DealerScore += pair.Value;


            }
        }

        public void InitialDeal()
        {
            Console.WriteLine("~~~~~~ BlackJack!! ~~~~~");
            Console.WriteLine($"You've Been Dealt: ");
            PlayerHit();
            PlayerHit();
            Console.WriteLine($"You Have {PlayerScore}");
            Console.WriteLine("Dealer Shows: ");
            DealerHit();
        }

        public void KeepDealing()
        {
            bool keepPlaying = true;
            while (keepPlaying)
            {
                Console.WriteLine("Hit or Stay\n" +
                        "1. Hit\n" +
                        "2. Stay");

                string userInput = Console.ReadLine();
                switch (userInput.ToLower())
                {
                    case "1":
                    case "hit":
                        PlayerHit();
                        Console.WriteLine($"You now have {PlayerScore}");
                        bool hitAgain = true;
                        while (hitAgain)
                        {
                            if (PlayerScore > Max)
                            {
                                Console.WriteLine("Bust!");
                                hitAgain = false;
                                keepPlaying = false;
                            }
                            else if (PlayerScore < Max)
                            {
                                Console.WriteLine("Hit Again?\n" +
                                    "1. Hit\n" +
                                    "2. Stay");
                                string anotherCard = Console.ReadLine();
                                if (anotherCard == "1")
                                {
                                    PlayerHit();
                                }
                                else
                                {
                                    hitAgain = false;
                                }
                            }
                            else
                            {
                                Console.WriteLine("You got 21!!");
                                hitAgain = false;
                            }
                        }
                        break;

                    case "2":
                    case "stay":
                        DealerHit();
                        Console.WriteLine($"Dealer Has {DealerScore}");
                        break;

                    default:
                        break;
                }

                if (PlayerScore <= Max)
                {


                    while (DealerScore < 16)
                    {
                        Console.WriteLine("Dealer Hits");
                        DealerHit();
                        Console.WriteLine($"Dealer Has: {DealerScore}");

                    }

                    if (PlayerScore == DealerScore)
                    {
                        Console.WriteLine("Push");
                        keepPlaying = false;
                    }
                    else if (PlayerScore > Max)
                    {
                        Console.WriteLine("Bust! You Lose.");
                        keepPlaying = false;
                    }
                    else if (DealerScore > Max)
                    {
                        Console.WriteLine("Dealer Busts, You win.");
                        keepPlaying = false;
                    }
                    else if (PlayerScore > DealerScore)
                    {
                        Console.WriteLine($"Dealer has: {DealerScore}. You Win!");
                        keepPlaying = false;
                    }
                    else if (DealerScore > PlayerScore)
                    {
                        Console.WriteLine("House Wins");
                        keepPlaying = false;
                    }
                }
            }
            PlayerScore = 0;
            DealerScore = 0;
            Console.ReadLine();
        }

        public void PlayGame()
        {
            bool dealIn = true;
            while (dealIn)
            {
                Console.WriteLine("♥ ♦ ♠ ♣ Welcome to C# BlackJack. ♣ ♠ ♦ ♥\n" +
                    "");
                Console.WriteLine("Should I deal you in?\n" +
                    "1. Yes\n" +
                    "2. No");
                string dealMeIn = Console.ReadLine();
                if (dealMeIn == "1")
                {
                    InitialDeal();
                    KeepDealing();
                }
                else
                {
                    Console.WriteLine("Thanks for stopping by!");
                    dealIn = false;
                    Console.ReadLine();
                }
            }
            
        }

        public BlackJack() { }
    }

}




