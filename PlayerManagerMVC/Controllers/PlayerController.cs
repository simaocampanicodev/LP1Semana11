using System;
using System.Collections.Generic;
using PlayerManagerMVC.Models;
using PlayerManagerMVC.Views;

namespace PlayerManagerMVC.Controllers
{
    public class PlayerController
    {
        private readonly List<Player> playerList;
        private readonly PlayerView view;
        private readonly IComparer<Player> compareByName;
        private readonly IComparer<Player> compareByNameReverse;

        public PlayerController(PlayerView view)
        {
            this.view = view;
            compareByName = new CompareByName(true);
            compareByNameReverse = new CompareByName(false);

            playerList = new List<Player>() {
                new Player("Best player ever", 100),
                new Player("An even better player", 500)
            };
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