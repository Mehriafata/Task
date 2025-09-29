namespace Task
{
    internal class Program
    {
        // player creation method
        public static Player createNewPlayer()
        {

            string? userName;
            string? userClass;

            bool validity = true;
            Player player = new Player();

            while (validity)
            {
                Console.WriteLine("Enter your name please");
                userName = Console.ReadLine()?.Trim();
                Console.WriteLine("Choose your class (Warrior or Mage)");
                userClass = Console.ReadLine()?.Trim();
                if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(userClass) && (userClass.ToLower() == "warrior" || userClass.ToLower() == "mage"))
                {
                    player = new Player(userName, userClass);
                    validity = false;
                }
                else
                {
                    Console.WriteLine("Invalid name or class. Please try again.");
                }
            }
            return player;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("<<<   Mini Adventure   >>>");
            string? userMenu;
            bool gameRunning = true;
            Tool tool = new Tool();
            Player player = createNewPlayer();

            while (gameRunning)
            {
                Console.WriteLine("\nMenu \n(1) Go on an adventure\n(2) Rest to regain some hp\n(3) Show status\n(4) Exit");
                userMenu = Console.ReadLine()?.Trim();
                Enemy? currentEnemy = null;


                if (!string.IsNullOrEmpty(userMenu))
                {

                    switch (userMenu)
                    {
                        case "1":
                            currentEnemy = new Enemy();//new enemy each time
                            tool.showGameMenu(player, currentEnemy);
                            break;
                        case "2":
                            tool.rest(player);
                            break;
                        case "3":
                            if (currentEnemy != null)
                            {
                                tool.showStatus(player, new Enemy());
                            }
                            else
                            {
                                Console.WriteLine("You have to choose adventure for creation of your enemy\nThen you can see status");
                            }
                            break;
                        case "4":
                            gameRunning = false;
                            Console.WriteLine("Thanks for playing");
                            break;
                        default:
                            Console.WriteLine("Invalid menu choice");
                            break;
                    }
                }

                if (player.playerHp <= 0)
                {
                    Console.WriteLine("Creating a new character");
                    player = createNewPlayer();
                    currentEnemy = null;
                }

            }
        }
    }
}
