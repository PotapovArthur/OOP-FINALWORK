namespace FinalWork
{
    public class GameAccount
    {
        private int GamesCount;
        protected string AccountType;
        protected string RatingCalculationRules;
        public string AccountID { get; }
        public string UserName { get; set; }
        public int CurrentRating
        {
            get
            {
                int currentrating = 0;
                foreach (var item in allGames)
                {
                    currentrating += item.Rating;
                }
                return currentrating;
            }
        }
        private static int accountNumberSeed = 1234567890;
        public GameAccount(string username, int rating)
        {
            AccountID = accountNumberSeed.ToString();
            accountNumberSeed++;
            UserName = username;
            SetInitialRating(username, rating);
            AccountType = "Безкоштовний";
            RatingCalculationRules = "Звичайна";
        }
        protected List<Data> allGames = new List<Data>();
        public virtual void WinGame(string playername, string opponentname, Game game)
        {
            var gamewon = new Data(playername, opponentname, game.GetRating, "ПЕРЕМОГА");
            allGames.Add(gamewon);
        }
        public virtual void LoseGame(string playername, string opponentname, Game game)
        {
            if (CurrentRating - game.GetRating < 1)
            {
                var negativerating = new Data(playername, opponentname, -CurrentRating + 1, "ПОРАЗКА");
                allGames.Add(negativerating);
            } else
            {
                var lostgame = new Data(playername, opponentname, -game.GetRating, "ПОРАЗКА");
                allGames.Add(lostgame);
            }
        }
        public virtual void DrawGame(string playername, string opponentname)
        {
            var drawgame = new Data(playername, opponentname, 0, "НIЧИЯ");
            allGames.Add(drawgame);
        }
        public void SetInitialRating(string playername, int rating)
        {
            if (rating < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(rating), "Початковий рейтинг гравця не може бути меншим, нiж 1");
            }
            var setrating = new Data(playername, "---", rating, "---");
            allGames.Add(setrating);
        }
        public string GetStats()
        {
            var report = new System.Text.StringBuilder();
            int currentrating = 0;
            report.AppendLine(string.Format("{0, -17}{1, -17}{2, -17}  {3, -17}{4, -5}", "Гравець", "Опонент", "Кiлькiсть партiй", "Результат гри", "Поточний рейтинг"));
            foreach (var item in allGames)
            {
                currentrating += item.Rating;
                GamesCount++;
                report.AppendLine(string.Format("{0, -17}{1, -17}{2, -17}  {3, -17}{4, -5}", item.Player, item.Opponent, GamesCount - 1, item.Outcome, currentrating));
            }
            Console.WriteLine($"id акаунту : {AccountID}\nТип акаунту : {AccountType}\nФормула обчислення рейтингу : {RatingCalculationRules}\n");
            return report.ToString();
        }
    }
}