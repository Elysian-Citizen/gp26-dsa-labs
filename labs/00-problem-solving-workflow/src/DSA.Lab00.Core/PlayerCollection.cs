using System;
using System.Collections.Generic;

namespace DSA.Lab00
{
    public sealed class PlayerCollection
    {
        private readonly List<Player> _players;

        public PlayerCollection(IEnumerable<Player> players)
        {
            if (players == null)
            {
                throw new ArgumentNullException(nameof(players));
            }

            _players = new List<Player>(players);
        }

        public Player? FindById(int id)
        {
            foreach (Player player in _players)
            {
                if (player.Id == id)
                {
                    return player;
                }
            }

            return null;
        }

        public Player? FindHighestScore()
        {
            // TODO:
            // Return the player with the highest score.
            // Return null when the collection is empty.

            if (_players.Count == 0) return null;

            Player highScorePlayer = _players[0];

            foreach (Player player in _players)
            {
                if (player.Score > highScorePlayer.Score)
                {
                    highScorePlayer = player;
                }
            }

            return highScorePlayer;
        }

        public bool ContainsName(string name)
        {
            // TODO:
            // Return true when a player with exactly this name exists.
            // Use case-sensitive comparison for this lab.


            foreach (Player player in _players)
            {
                 if (player.Name == name)
                {
                    return true;
                }
            }
            return false;
        }

        public bool HighScoreContains(int number)
        {
            Player? highScorePlayer = FindHighestScore();

            if (highScorePlayer == null) return false;

            int count = highScorePlayer.Score / number;

            return count > 0; 
        }
    }
}
