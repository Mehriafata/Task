namespace Task
{
    public class Enemy
    {
        public string[] enemyRandomName = { "Goblin", "Rat", "Skeleton", "Bandit", "Dragon" };
        public string enemyClass = "Enemy";
        public string enemyName = "";
        public int enemyHp = 0;
        public int enemyDamagePower = 0;
        public int enemyLoot = 0;
        Random random = new Random();

        public Enemy()
        {
            this.enemyName = this.enemyRandomName[random.Next(0, enemyRandomName.Length)];
            this.enemyHp = random.Next(40, 51);
            this.enemyDamagePower = random.Next(10, 20);
            this.enemyLoot = random.Next(50, 200);
        }

    }
}
