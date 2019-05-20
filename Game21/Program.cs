using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game21
{
    enum Name
    {
        Jack = 2,
        Queen,
        King,
        Six = 6,
        Seven,
        Eight,
        Nine,
        Ten,
        Ace
    }

    enum Suit
    {
        Diamonds,
        Hearts,
        Spades,
        Clubs
    }

    struct Deck
    {
        public Name Name;
        public Suit Suit;
    }

    class Program
    {
        static void Main(string[] args)
        {
            int playerWins = 0;
            int compWins = 0;
            Name[] names = { Name.Jack, Name.Queen, Name.King, Name.Six, Name.Seven, Name.Eight, Name.Nine, Name.Ten, Name.Ace };
            Suit[] suit = { Suit.Diamonds, Suit.Hearts, Suit.Clubs, Suit.Spades };
            Deck[] deck = new Deck[36];
            for (int i = 0; i < deck.Length; i += names.Length)
            {
                for (int j = 0; j < names.Length; j++)
                {
                    deck[i + j].Name = names[j];
                    deck[i + j].Suit = suit[i / names.Length];
                }
            }

            string allStr = "";

            do
            {
                int playerPoints = 0;
                int computerPoints = 0;

                Random random = new Random();

                for (int i = 0; i < deck.Length / 2; i++)
                {
                    int i1 = random.Next(deck.Length);
                    int i2 = random.Next(deck.Length);
                    Deck temp = deck[i1];
                    deck[i1] = deck[i2];
                    deck[i2] = temp;
                }

                int firstPlayer = random.Next(2);
                if (firstPlayer == 0)
                {
                    Console.WriteLine("Player goes first");
                    Console.WriteLine();
                    string player = $"You have: {deck[0].Suit} {deck[0].Name} ; {deck[1].Suit} {deck[1].Name}";
                    Console.WriteLine(player);
                    playerPoints = playerPoints + ((int)deck[0].Name + (int)deck[1].Name);
                    Console.WriteLine($"You have {playerPoints} points now");
                    Console.WriteLine();
                    string computer = $"Computer have: {deck[2].Suit} {deck[2].Name} ; {deck[3].Suit} {deck[3].Name}";
                    Console.WriteLine(computer);
                    computerPoints = computerPoints + ((int)deck[2].Name + (int)deck[3].Name);
                    Console.WriteLine($"Computer have {computerPoints} points now");
                    Console.WriteLine();
                    int count = 3;
                    string str = "";
                    do
                    {
                        if (playerPoints == 21 || (deck[0].Name == Name.Ace && deck[1].Name == Name.Ace))
                        {
                            Console.WriteLine("You have Black Jack");
                            Console.WriteLine("You win");
                            playerWins++;
                            break;
                        }
                        if (computerPoints == 21 || (deck[2].Name == Name.Ace && deck[3].Name == Name.Ace))
                        {
                            Console.WriteLine("Computer have Black Jack");
                            Console.WriteLine("Computer win");
                            compWins++;
                            break;
                        }
                        Console.WriteLine("Do You want anothe card?(Y/N)");
                        str = Console.ReadLine();
                        Console.WriteLine();
                        if (str == "y")
                        {
                            count++;
                            player = player + " ; " + $"{deck[count].Suit} {deck[count].Name}";
                            Console.WriteLine(player);
                            playerPoints = playerPoints + (int)deck[count].Name;
                            Console.WriteLine($"You have {playerPoints} points now");
                            Console.WriteLine();
                        }
                        if (playerPoints > 21)
                        {
                            Console.WriteLine("You have too much points");
                            Console.WriteLine();
                            Console.WriteLine("Computer passes");
                            Console.WriteLine("Computer win");
                            compWins++;
                            break;
                        }
                    } while (str == "y");


                    do
                    {
                        if (playerPoints == 21 || (deck[0].Name == Name.Ace && deck[1].Name == Name.Ace))
                        {
                            break;
                        }
                        if (computerPoints == 21 || (deck[2].Name == Name.Ace && deck[3].Name == Name.Ace))
                        {
                            break;
                        }
                        if (computerPoints >= playerPoints)
                        {
                            Console.WriteLine("Computer passes");
                            Console.WriteLine("Computer win");
                            break;
                        }
                        if (playerPoints < 21 && computerPoints < playerPoints)
                        {
                            count++;
                            Console.WriteLine($"Computer takes one more card: {deck[count].Suit}:{deck[count].Name}");
                            computer = computer + " ; " + $" ; {deck[count].Suit} {deck[count].Name}";
                            Console.WriteLine(computer);
                            computerPoints = computerPoints + (int)deck[count].Name;
                            Console.WriteLine($"Computer have {computerPoints} points now");
                            Console.WriteLine();
                            if (computerPoints > 21)
                            {
                                Console.WriteLine("Computer have too much points");
                                Console.WriteLine("You win");
                                playerWins++;
                                break;
                            }
                            if (computerPoints == 21)
                            {
                                Console.WriteLine("Computer have Black Jack");
                                Console.WriteLine("Computer win");
                                compWins++;
                                break;
                            }
                            if (computerPoints >= playerPoints)
                            {
                                Console.WriteLine("Computer passes");
                                Console.WriteLine("Computer win");
                                compWins++;
                                break;
                            }
                        }
                    } while (computerPoints <= playerPoints && playerPoints <= 21);
                }
                else
                {
                    Console.WriteLine("Computer goes first");
                    Console.WriteLine();
                    string computer = $"Computer have: {deck[0].Suit} {deck[0].Name} ; {deck[1].Suit} {deck[1].Name}";
                    Console.WriteLine(computer);
                    computerPoints = computerPoints + ((int)deck[0].Name + (int)deck[1].Name);
                    Console.WriteLine($"Computer has {computerPoints} points now");
                    Console.WriteLine();
                    string player = $"You have: {deck[2].Suit} {deck[2].Name} ; {deck[3].Suit} {deck[3].Name}";
                    Console.WriteLine(player);
                    playerPoints = playerPoints + ((int)deck[2].Name + (int)deck[3].Name);
                    Console.WriteLine($"You have {playerPoints} points now");
                    Console.WriteLine();
                    Console.WriteLine();

                    int count = 3;
                    string str = "";

                    do
                    {
                        if (computerPoints == 21 || (deck[0].Name == Name.Ace && deck[1].Name == Name.Ace))
                        {
                            Console.WriteLine("Computer have Black Jack");
                            Console.WriteLine("Computer win");
                            compWins++;
                            break;
                        }
                        if (playerPoints == 21 || (deck[2].Name == Name.Ace && deck[3].Name == Name.Ace))
                        {
                            Console.WriteLine("You have Black Jack");
                            Console.WriteLine("You win");
                            playerWins++;
                            break;
                        }

                        if (computerPoints < 17 || computerPoints <= playerPoints && computerPoints != 20)
                        {
                            count++;
                            Console.WriteLine($"Computer takes one more card: {deck[count].Suit}:{deck[count].Name}");
                            computer = computer + $" ; {deck[count].Suit} {deck[count].Name}";
                            Console.WriteLine(computer);
                            computerPoints = computerPoints + (int)deck[count].Name;
                            Console.WriteLine($"Computer have {computerPoints} points now");
                            Console.WriteLine();
                        }
                        if (computerPoints == 21)
                        {
                            Console.WriteLine("Computer have Black Jack");
                            Console.WriteLine("Computer win");
                            compWins++;
                            break;
                        }
                        if (computerPoints > 21)
                        {
                            Console.WriteLine("Computer have too much points");
                            Console.WriteLine();
                            break;
                        }
                    } while (computerPoints < 17 || (computerPoints <= playerPoints && computerPoints != 20));

                    do
                    {
                        if (computerPoints == 21 || (deck[0].Name == Name.Ace && deck[1].Name == Name.Ace))
                        {
                            break;
                        }
                        if (playerPoints == 21 || (deck[2].Name == Name.Ace && deck[3].Name == Name.Ace))
                        {
                            break;
                        }

                        Console.WriteLine("Do You want anothe card?(Y/N)");
                        str = Console.ReadLine();
                        if (str == "y")
                        {
                            count++;
                            player = player + $" ; {deck[count].Suit}:{deck[count].Name}";
                            Console.WriteLine(player);
                            playerPoints = playerPoints + (int)deck[count].Name;
                            Console.WriteLine($"You have {playerPoints} points now");
                            Console.WriteLine();
                            if (playerPoints > 21)
                            {
                                Console.WriteLine("You have too much points");
                                break;
                            }
                            if (playerPoints == 21)
                            {
                                Console.WriteLine("You have Black Jack");
                                Console.WriteLine("You win");
                                playerWins++;
                                break;
                            }
                        }
                    } while (str == "y");
                    if (playerPoints > 21 && (deck[2].Name != Name.Ace || deck[3].Name != Name.Ace) && (deck[0].Name != Name.Ace || deck[1].Name != Name.Ace))
                    {
                        if (computerPoints > 21 && computerPoints > playerPoints)
                        {
                            Console.WriteLine("But Computer have more");
                            Console.WriteLine("You win");
                            playerWins++;
                        }
                        else
                        {
                            Console.WriteLine("Computer win");
                            compWins++;
                        }
                    }
                    if (playerPoints < 21 && (deck[2].Name != Name.Ace || deck[3].Name != Name.Ace) && (deck[0].Name != Name.Ace || deck[1].Name != Name.Ace))
                    {
                        if (computerPoints > 21)
                        {
                            Console.WriteLine("You passes");
                            Console.WriteLine("You win");
                            playerWins++;
                        }
                        if (computerPoints < 21 && computerPoints > playerPoints)
                        {
                            Console.WriteLine("You passes");
                            Console.WriteLine("Computer win");
                            compWins++;
                        }
                        if (computerPoints < 21 && computerPoints < playerPoints)
                        {
                            Console.WriteLine("You passes");
                            Console.WriteLine("You win");
                            playerWins++;
                        }
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Do you want play again? (Y/N)");
                allStr = Console.ReadLine();
                Console.WriteLine();
            } while (allStr == "y");

            Console.WriteLine($"Player wins: {playerWins} times");
            Console.WriteLine($"Computer wins: {compWins} times");
        }
    }
}
