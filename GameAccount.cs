namespace FinalWork
{
    public class GameAccount
    {
        protected int GamesCount;
        public string AccountID { get; }
        public string UserName { get; set; }
        private static int accountNumberSeed = 1234567890;
        public GameAccount(string username)
        {
            AccountID = accountNumberSeed.ToString();
            accountNumberSeed++;
            UserName = username;
        }
        protected List<Data> allGames = new List<Data>();
        public void WinGame(string playername, string opponentname, Game game)
        {
            var gamewon = new Data(playername, opponentname, game.GetGameID, "WIN");
            allGames.Add(gamewon);
        }
        public void LoseGame(string playername, string opponentname, Game game)
        {
            var lostgame = new Data(playername, opponentname, game.GetGameID, "LOSE");
            allGames.Add(lostgame);
        }
        public void DrawGame(string playername, string opponentname, Game game)
        {
            var drawgame = new Data(playername, opponentname, game.GetGameID, "DRAW");
            allGames.Add(drawgame);
        }
        public string GetStats()
        {
            var report = new System.Text.StringBuilder();
            report.AppendLine("Гравець\t\tОпонент\t\tКiлькiсть партiй\tРезультат гри\t\tid iгрової сесiї");
            foreach (var item in allGames)
            {
                GamesCount++;
                report.AppendLine($"{item.Player}\t\t{item.Opponent}\t\t{GamesCount}\t\t\t{item.Outcome}\t\t\t{item.GameID}");
                
            }
            Console.WriteLine($"id акаунту : {AccountID}\n");
            return report.ToString();
        }
    }
}