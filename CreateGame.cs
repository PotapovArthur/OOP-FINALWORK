namespace FinalWork
{
    class CreateGame
    {
        public static Game GetGame(GameAccount account1, GameAccount account2)
        {
            return new TicTacToe(account1, account2);
        }
    }
}