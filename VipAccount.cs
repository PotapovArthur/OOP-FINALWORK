namespace FinalWork
{
    class VipAccount : GameAccount
    {
        public VipAccount(string name, int startingrating) : base(name, startingrating)
        {
            AccountType = "Платиновий";
            RatingCalculationRules = "При поразцi вiднiмається лише половина вiд рейтингу, на який грали";
        }
        public override void LoseGame(string playername, string opponentname, Game game)
        {
            if (CurrentRating - game.GetRating < 1)
            {
                var negativerating = new Data(playername, opponentname, -CurrentRating + 1, "LOSE");
                allGames.Add(negativerating);
            }
            else
            {
                decimal rating = Decimal.Divide(game.GetRating, 2);
                var lostgame = new Data(playername, opponentname, (int)-Math.Ceiling(rating), "LOSE");
                allGames.Add(lostgame);
            }
        }
    }
}