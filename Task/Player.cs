namespace Task
{
    public class Player
    {
        public string playerName = "";
        public string playerClass = "";
        public int playerHp = 0;
        public int playerMaxHp = 0;
        public int playerDamagePower = 0;
        public int playerLoot = 0;
        public int playerMana = 0;
        Random random = new Random();

        public Player() { }
        public Player(string username, string userclass)
        {
            this.playerName = username;
            this.playerMaxHp = random.Next(45, 55);
            this.playerHp = this.playerMaxHp;
            this.playerDamagePower = random.Next(10, 20);

            if (userclass.ToLower() == "mage")
            {
                this.playerMana = random.Next(5, 10);
                this.playerHp += this.playerMana;
                this.playerMaxHp += this.playerMana;
                this.playerClass = userclass;
                Console.WriteLine("Mage class has been created");
            }
            else
            {
                this.playerClass = userclass;
                Console.WriteLine("warrior has been created");
            }
        }

        public void ResetStats()
        {

            this.playerMaxHp = random.Next(50, 60);
            this.playerHp = this.playerMaxHp;
            this.playerDamagePower = random.Next(10, 20);
            playerLoot += playerLoot;
            if (this.playerClass == "mage")
            {
                this.playerMana = random.Next(5, 10);
                this.playerHp += this.playerMana;
                this.playerMaxHp += this.playerMana;
            }
            Console.WriteLine("Your have been assigned new value for next level\n" +
                "But you have your gold that you earned from previous level");

        }
    }
}
