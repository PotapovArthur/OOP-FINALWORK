namespace FinalWork
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("\nВведiть ваш нiкнейм :");
            string? nickname1 = Console.ReadLine();
            Console.WriteLine("\nВведiть нiкнейм опонента :");
            string? nickname2 = Console.ReadLine();
            Console.WriteLine("\nВведiть початковий рейтинг для кожного з гравцiв:");
            int initialrating = Convert.ToInt32(Console.ReadLine());
            //var acc1 = new GameAccount(nickname1!, initialrating);
            //var acc2 = new GameAccount(nickname2!, initialrating);
            var acc1 = new UpgradedAccount(nickname1!, initialrating);
            var acc2 = new VipAccount(nickname2!, initialrating);
            Console.WriteLine("\nСкiльки iгор бажаєте провести :");
            int gamescount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nНа скiльки рейтингу буде кожна з iгор :");
            int bid = Convert.ToInt32(Console.ReadLine());
            var game = CreateGame.GetGame(acc1, acc2, bid);
            for (int i = 0; i < gamescount; i++)
            {
               game.Play();
            }
            Console.WriteLine($"\nСТАТИСТИКА ГРАВЦЯ {nickname1!} :\n");
            Console.WriteLine(acc1.GetStats());
            Console.WriteLine($"\nСТАТИСТИКА ГРАВЦЯ {nickname2!} :\n");
            Console.WriteLine(acc2.GetStats());
        }
    }
}