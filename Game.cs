namespace FinalWork
{
    public abstract class Game
    {
        public virtual int GetRating { get; }
        public GameAccount Account1;
        public GameAccount Account2;
        public abstract void Play();
        public Game(GameAccount account1, GameAccount account2, int Rating)
        {
            GetRating = Rating;
            Account1 = account1;
            Account2 = account2;
        }
    }
}