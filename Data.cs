namespace FinalWork
{
    public class Data
    {
        public string Player { get; }
        public string Opponent { get; }
        public string GameID { get; }
        public string Outcome { get; }
        public Data(string player, string opponent, string gameid, string outcome)
        {
            Player = player;
            Opponent = opponent;
            GameID = gameid;
            Outcome = outcome;
        }
    }
}