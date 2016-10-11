using System.Collections.Generic;

namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int p1point;
        private int p2point;

        private string player1Name;
        private string player2Name;

        private List<string> playerScore = new List<string> { "Love", "Fifteen", "Thirty", "Forty" };

        public TennisGame2(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            p1point = 0;
            this.player2Name = player2Name;
            p2point = 0;
        }

        public string GetScore()
        {
            string score = "";

            if (p1point >= 4 && p2point >= 0 && (p1point - p2point) >= 2)
            {
                score = "Win for player1";
            }
            else if (p2point >= 4 && p1point >= 0 && (p2point - p1point) >= 2)
            {
                score = "Win for player2";
            }
            else if (p1point > p2point && p2point >= 3 && (p1point - p2point) < 2)
            {
                score = "Advantage player1";
            }
            else if (p2point > p1point && p1point >= 3 && (p2point - p1point) < 2)
            {
                score = "Advantage player2";
            }
            else if ((p1point < 4 || p2point < 4) && p1point != p2point)
            {
                score = playerScore[p1point] + "-" + playerScore[p2point];
            }
            else if (p1point == p2point && p1point > 2)
                score = "Deuce";
            else
            {
                score = playerScore[p1point] + "-All";
            }

            return score;
        }

        public void SetP1Score(int number)
        {
            for (int i = 0; i < number; i++)
            {
                P1Score();
            }
        }

        public void SetP2Score(int number)
        {
            for (var i = 0; i < number; i++)
            {
                P2Score();
            }
        }

        private void P1Score()
        {
            p1point++;
        }

        private void P2Score()
        {
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

