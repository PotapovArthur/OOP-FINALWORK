namespace FinalWork
{
    public abstract class Game
    {
        public string GetGameID { get; }
        private static int gameID = 12345;
        public GameAccount Account1;
        public GameAccount Account2;
        public abstract void Play();
        public Game(GameAccount account1, GameAccount account2)
        {
            GetGameID = gameID.ToString();
            gameID++;
            Account1 = account1;
            Account2 = account2;
        }
    }
}