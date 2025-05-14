using System;
using System.Collections.Generic;
using PlayerManagerMVC.Models;

namespace PlayerManagerMVC.Views
{
    public class PlayerView
    {
        public void ShowMenu()
        {
            Console.WriteLine("Menu");
            Console.WriteLine("----\n");
            Console.WriteLine("1. Insert player");
            Console.WriteLine("2. List all players");
            Console.WriteLine("3. List players with score greater than");
            Console.WriteLine("4. Sort players");
            Console.WriteLine("0. Quit\n");
            Console.Write("Your choice > ");
        }

        public void DisplayPlayers(IEnumerable<Player> playersToList)
        {
            Console.WriteLine("\nList of players");
            Console.WriteLine("-------------\n");

            foreach (Player p in playersToList)
            {
                Console.WriteLine($" -> {p.Name} with a score of {p.Score}");
            }
            Console.WriteLine();
        }

        public (string name, int score) GetNewPlayerInfo()
        {
            Console.WriteLine("\nInsert player");
            Console.WriteLine("-------------\n");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Score: ");
            int score = Convert.ToInt32(Console.ReadLine());
            return (name, score);
        }

        public int GetMinimumScore()
        {
            Console.Write("\nMinimum score player should have? ");
            return Convert.ToInt32(Console.ReadLine());
        }

        public PlayerOrder GetSortOrder()
        {
            Console.WriteLine("Player order");
            Console.WriteLine("------------");
            Console.WriteLine($"{(int)PlayerOrder.ByScore}. Order by score");
            Console.WriteLine($"{(int)PlayerOrder.ByName}. Order by name");
            Console.WriteLine($"{(int)PlayerOrder.ByNameReverse}. Order by name (reverse)");
            Console.WriteLine("");
            Console.Write("> ");
            return Enum.Parse<PlayerOrder>(Console.ReadLine());
        }

        public void WaitForKey()
        {
            Console.Write("\nPress any key to continue...");
            Console.ReadKey(true);
            Console.WriteLine("\n");
        }

        public void DisplayGoodbye()
        {
            Console.WriteLine("Bye!");
        }

        public void DisplayError(string message)
        {
            Console.Error.WriteLine($"\n>>> {message} <<<\n");
        }
    }
}