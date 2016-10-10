using System;

namespace Tennis
{
    class TennisGame1 : ITennisGame
    {
        private int m_score1 = 0;
        private int m_score2 = 0;
        private string player1Name;
        private string player2Name;
        private bool player1Up = false;
        private bool player2Up = false;

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                m_score1++;
            else
                m_score2++;
            
            if (m_score1 > m_score2)
            {
                player1Up = true;
                player2Up = false;
            }
            else if (m_score1 < m_score2)
            {
                player2Up = true;
                player1Up = false;
            }
            else
            {
                player2Up = false;
                player1Up = false;
            }                
        }
        
        private string playerScore(int score)
        {
            string strScore = "";
            switch (score)
            {
                case 0:
                    strScore = "Love";
                    break;
                case 1:
                    strScore = "Fifteen";
                    break;
                case 2:
                    strScore = "Thirty";
                    break;
                case 3:
                    strScore = "Forty";
                    break;
            }            
            return strScore;
        }

        public string GetScore()
        {
            string score = "";
            int highestScore = Math.Max(m_score1, m_score2);
            int lowestScore = Math.Min(m_score1, m_score2);
            int scoreDistance = highestScore - lowestScore;
            if (highestScore < 4)
            {
                if (player1Up || player2Up)
                    score = playerScore(m_score1) + "-" + playerScore(m_score2);
                else
                {
                    if (highestScore == 3)
                        score = "Deuce";
                    else
                        score = playerScore(highestScore) + "-All";
                }
            }
            else
            {
                if (player1Up || player2Up)
                {
                    if (player1Up)
                    {
                        if (scoreDistance > 1)
                            score = "Win for player1";
                        else
                            score = "Advantage player1";
                    }
                    else
                    {
                        if (scoreDistance > 1)
                            score = "Win for player2";
                        else
                            score = "Advantage player2";
                    }
                }
                else
                    score = "Deuce";
            }
            return score;
        }
    }
}