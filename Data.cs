namespace FinalWork
{
    public class Data
    {
        public string Player { get; }
        public string Opponent { get; }
        public int Rating { get; }
        public string Outcome { get; }
        public Data(string player, string opponent, int rating, string outcome)
        {
            Player = player;
            Opponent = opponent;
            Rating = rating;
            Outcome = outcome;
        }
    }
}