namespace FinalWork
{
    public class TicTacToe : Game
    {
        public TicTacToe(GameAccount account1, GameAccount account2) : base(account1, account2)
        {

        }
        public override void Play()
        {
            int playerturn = 0, position = 0, gameWon = 0, row = 0, column = 0;
            Random random = new Random();
            int n = random.Next(0, 2);
            char[,] board = new char[3, 3] { {'1', '2', '3'}, {'4', '5', '6'}, {'7', '8', '9'} };
            Console.WriteLine("\nНОВА ГРА");
            for (int i = 0; i < 9 && gameWon == 0; i++)
            {
                Console.WriteLine();
                Console.Write($" {board[0, 0]} | {board[0, 1]} | {board[0, 2]}\n");
                Console.Write("---|---|---\n");
                Console.Write($" {board[1, 0]} | {board[1, 1]} | {board[1, 2]}\n");
                Console.Write("---|---|---\n");
                Console.Write($" {board[2, 0]} | {board[2, 1]} | {board[2, 2]}\n");
                playerturn = i % 2 + 1;
                do
                {
                    if (n == 0)
                    {
                        Console.WriteLine("\n{0}, оберiть де ставити {1}", (playerturn == 1) ? Account1.UserName : Account2.UserName, (playerturn == 1) ? 'X' : 'O');
                    } else
                    {
                        Console.WriteLine("\n{0}, оберiть де ставити {1}", (playerturn == 1) ? Account2.UserName : Account1.UserName, (playerturn == 1) ? 'X' : 'O');
                    }
                    position = Convert.ToInt32(Console.ReadLine());
                    row = --position / 3;
                    column = position % 3;
                    Console.Clear();
                } while (position < 0 || position > 9 || board[row, column] > '9');
                board[row, column] = (playerturn == 1) ? 'X' : 'O';
                if ((board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2]) || (board[0, 2] == board[1, 1] && board[0, 2] == board[2, 0]))
                {
                    gameWon = playerturn;
                } else
                {
                    for(int j = 0; j <= 2; j++)
                    {
                        if ((board[j, 0] == board[j, 1] && board[j, 0] == board[j, 2]) || (board[0, j] == board[1, j] && board[0, j] == board[2, j]))
                        {
                            gameWon = playerturn;
                        }
                    }
                }
            }
            Console.WriteLine("\n");
            Console.Write($" {board[0, 0]} | {board[0, 1]} | {board[0, 2]}\n");
            Console.Write("---|---|---\n");
            Console.Write($" {board[1, 0]} | {board[1, 1]} | {board[1, 2]}\n");
            Console.Write("---|---|---\n");
            Console.Write($" {board[2, 0]} | {board[2, 1]} | {board[2, 2]}\n");
            if (n == 0)
            {
                switch (gameWon)
                {
                    case 0: Console.WriteLine("\nНiчия!\n"); Account1.DrawGame(Account1.UserName, Account2.UserName, this); Account2.DrawGame(Account2.UserName, Account1.UserName, this); break;
                    case 1: Console.WriteLine($"\nПеремiг гравець {Account1.UserName}!\n"); Account1.WinGame(Account1.UserName, Account2.UserName, this); Account2.LoseGame(Account2.UserName, Account1.UserName, this); break;
                    case 2: Console.WriteLine($"\nПеремiг гравець {Account2.UserName}!\n"); Account2.WinGame(Account2.UserName, Account1.UserName, this); Account1.LoseGame(Account1.UserName, Account2.UserName, this); break;
                }
            } else
            {
                switch (gameWon)
                {
                    case 0: Console.WriteLine("\nНiчия!\n"); Account1.DrawGame(Account1.UserName, Account2.UserName, this); Account2.DrawGame(Account2.UserName, Account1.UserName, this); break;
                    case 1: Console.WriteLine($"\nПеремiг гравець {Account2.UserName}!\n"); Account2.WinGame(Account2.UserName, Account1.UserName, this); Account1.LoseGame(Account1.UserName, Account2.UserName, this); break;
                    case 2: Console.WriteLine($"\nПеремiг гравець {Account1.UserName}!\n"); Account1.WinGame(Account1.UserName, Account2.UserName, this); Account2.LoseGame(Account2.UserName, Account1.UserName, this); break;
                }
            }
            Console.WriteLine("Натиснiть ENTER для продовження");
            Console.ReadLine();
            Console.Clear();
        }
    }
}