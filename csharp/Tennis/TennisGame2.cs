using System.Collections.Generic;

namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int p1point;
        private int p2point;

        private string player1Name;
        private string player2Name;

        private string[,] playerScore = {
            { "Love-All", "Love-Fifteen", "Love-Thirty", "Love-Forty", "Win for player2", "" },
            { "Fifteen-Love", "Fifteen-All", "Fifteen-Thirty", "Fifteen-Forty", "Win for player2", "" },
            { "Thirty-Love", "Thirty-Fifteen", "Thirty-All", "Thirty-Forty", "Win for player2", "" },
            { "Forty-Love", "Forty-Fifteen", "Forty-Thirty", "Deuce", "Advantage player2", "Win for player2" },
            { "Win for player1", "Win for player1", "Win for player1", "Advantage player1", "", "" },
            { "", "", "", "Win for player1", "", "" }
        };

        public TennisGame2(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            p1point = 0;
            this.player2Name = player2Name;
            p2point = 0;
        }

        public string GetScore()
        {
            return playerScore[p1point, p2point];
        }

        private void P1Score()
        {
            if (playerScore[p1point, p2point] == "Advantage player2")
                p2point--;
            else
                p1point++;
        }

        private void P2Score()
        {
            if (playerScore[p1point, p2point] == "Advantage player1")
                p1point--;
            else
                p2point++;
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                P1Score();
            else
                P2Score();
        }

    }
}

