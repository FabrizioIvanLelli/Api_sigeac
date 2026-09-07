using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity_library;


namespace dao_library
{
    public class PlayerDAO
    {
        public Player CreatePlayer(Player player)
        {
            MockDatabase.Players.Add(player);
            return player;
        }

        public Player? ReadPlayerById(int id)
        {
            return MockDatabase.Players.FirstOrDefault(s => s.Id == id);
        }

        public List<Player> ReadPlayers()
        {
            return MockDatabase.Players;
        }

        public bool UpdatePlayer(Player updatedPlayer)
        {
            var existingPlayer = ReadPlayerById(updatedPlayer.Id);

            if (existingPlayer != null)
            {
                existingPlayer.Number = updatedPlayer.Number;
            }

            return false;
        }

        public bool DeletePlayer(int id)
        {
            var playerToDelete = ReadPlayerById(id);

            if (playerToDelete != null)
            {
                MockDatabase.Players.Remove(playerToDelete);
                return true;
            }

            return false;
        }
    }
}
