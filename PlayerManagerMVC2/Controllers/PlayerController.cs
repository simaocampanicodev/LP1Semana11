using System;
using System.Collections.Generic;
using System.IO;
using PlayerManagerMVC2.Models;
using PlayerManagerMVC2.Views;

namespace PlayerManagerMVC2.Controllers
{
    public class PlayerController
    {
        private readonly List<Player> playerList;
        private readonly PlayerView view;
        private readonly IComparer<Player> compareByName;
        private readonly IComparer<Player> compareByNameReverse;

        public PlayerController(PlayerView view, string filename)
        {
            this.view = view;
            compareByName = new CompareByName(true);
            compareByNameReverse = new CompareByName(false);
            playerList = new List<Player>();
            LoadPlayersFromFile(filename);
        }

        private void LoadPlayersFromFile(string filename)
        {
            try
            {
                string[] lines = File.ReadAllLines(filename);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 2 && int.TryParse(parts[1].Trim(), out int score))
                    {
                        playerList.Add(new Player(parts[0].Trim(), score));
                    }
                }
            }
            catch (Exception ex)
            {
                view.DisplayError($"Erro ao ler ficheiro: {ex.Message}");
                Environment.Exit(1);
            }
        }

        public void Start()
        {
            string option;
            do
            {
                view.ShowMenu();
                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        InsertPlayer();
                        break;
                    case "2":
                        ListPlayers();
                        break;
                    case "3":
                        ListPlayersWithScoreGreaterThan();
                        break;
                    case "4":
                        SortPlayerList();
                        break;
                    case "0":
                        view.DisplayGoodbye();
                        break;
                    default:
                        view.DisplayError("Unknown option!");
                        break;
                }

                if (option != "0")
                    view.WaitForKey();

            } while (option != "0");
        }

        private void InsertPlayer()
        {
            var (name, score) = view.GetNewPlayerInfo();
            playerList.Add(new Player(name, score));
        }

        private void ListPlayers()
        {
            view.DisplayPlayers(playerList);
        }

        private void ListPlayersWithScoreGreaterThan()
        {
            int minScore = view.GetMinimumScore();
            IEnumerable<Player> filtered = GetPlayersWithScoreGreaterThan(minScore);
            view.DisplayPlayers(filtered);
        }

        private IEnumerable<Player> GetPlayersWithScoreGreaterThan(int minScore)
        {
            foreach (Player p in playerList)
            {
                if (p.Score > minScore)
                {
                    yield return p;
                }
            }
        }

        private void SortPlayerList()
        {
            PlayerOrder playerOrder = view.GetSortOrder();

            switch (playerOrder)
            {
                case PlayerOrder.ByScore:
                    playerList.Sort();
                    break;
                case PlayerOrder.ByName:
                    playerList.Sort(compareByName);
                    break;
                case PlayerOrder.ByNameReverse:
                    playerList.Sort(compareByNameReverse);
                    break;
                default:
                    view.DisplayError("Unknown player order!");
                    break;
            }
        }
    }
}