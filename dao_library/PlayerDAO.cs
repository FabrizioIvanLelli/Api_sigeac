using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity_library;


namespace dao_library
{
    internal class PlayerDAO
    {
        public Player CreatePlayer(Player player)
        {
            MockDatabase.Players.Add(player);
            return player;
        }

        public Player? ReadPlayerByNumber(int number)
        {
            return MockDatabase.Players.FirstOrDefault(s => s.Number == number);
        }

        public List<Player> ReadPlayers()
        {
            return MockDatabase.Players;
        }

        public bool UpdatePlayer(Player updatedPlayer)
        {
            var existingPlayer = ReadPlayerByNumber(updatedPlayer.Number);

            if (existingPlayer != null)
            {
                existingPlayer.Number = updatedPlayer.Number;
            }

            return false;
        }

        public bool DeletePlayer(int number)
        {
            var playerToDelete = ReadPlayerByNumber(number);

            if (playerToDelete != null)
            {
                MockDatabase.Players.Remove(playerToDelete);
                return true;
            }

            return false;
        }
    }
}
