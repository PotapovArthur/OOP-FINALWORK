namespace FinalWork
{
    class UpgradedAccount : GameAccount
    {
        public UpgradedAccount(string name, int startingrating) : base(name, startingrating)
        {
            AccountType = "Золотий";
            RatingCalculationRules = "Якщо кiлькiсть перемог пiдряд >=3, то окрiм рейтингу на який грали буде додаватися його значення, подiлене на п'ять + (кiлькiсть перемог пiдряд - 3)";
        }
        private static int WinStreak = 0;
        public override void WinGame(string playername, string opponentname, Game game)
        {
            WinStreak++;
            if (WinStreak >= 3)
            {
                decimal bonus = Decimal.Divide(game.GetRating, 5);
                var gamewon = new Data(playername, opponentname, game.GetRating + (int)Math.Round(bonus) + (WinStreak - 3), "ПЕРЕМОГА");
                allGames.Add(gamewon);
            }
            else
            {
                var gamewon = new Data(playername, opponentname, game.GetRating, "ПЕРЕМОГА");
                allGames.Add(gamewon);
            }
        }
        public override void LoseGame(string playername, string opponentname, Game game)
        {
            WinStreak = 0;
            base.LoseGame(playername, opponentname, game);
        }
        public override void DrawGame(string playername, string opponentname)
        {
            WinStreak = 0;
            base.DrawGame(playername, opponentname);
        }
    }
}