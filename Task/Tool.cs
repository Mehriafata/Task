namespace Task
{
    public class Tool
    {
        public void showGameMenu(Player player, Enemy enemy)
        {
            Console.WriteLine($"\n <<< A wild {enemy.enemyName} has appeared");
            bool battleGoingOn = true;
            string? action;

            while (battleGoingOn)
            {
                showStatus(player, enemy);
                Console.WriteLine("What do you want to do?\nAttack/Heal/Run");
                action = Console.ReadLine()?.Trim();

                if (!string.IsNullOrWhiteSpace(action))
                {
                    switch (action.ToLower())
                    {
                        case "attack":
                            Console.WriteLine($"{player.playerName} attacks\n");
                            enemy.enemyHp -= player.playerDamagePower;
                            Console.WriteLine($"{enemy.enemyName} hp is now {enemy.enemyHp} ");
                            if (enemy.enemyHp <= 0)
                            {
                                Console.WriteLine($"You defeated {enemy.enemyName}");
                                player.playerLoot += enemy.enemyLoot + 100;
                                Console.WriteLine($"You gained {player.playerLoot} gold!");
                                battleGoingOn = false;
                                player.ResetStats();
                                break;
                            }

                            Console.WriteLine($"{enemy.enemyName} attacks back");
                            player.playerHp -= enemy.enemyDamagePower;
                            Console.WriteLine($"{player.playerName} hp is now {player.playerHp} ");

                            if (player.playerHp <= 0)
                            {
                                Console.WriteLine("You died! Game over.");
                                battleGoingOn = false;

                            }
                            break;

                        case "heal":
                            if (player.playerHp >= player.playerMaxHp)
                            {
                                Console.WriteLine("Your hp is full");
                            }
                            else
                            {
                                player.playerHp += 5;
                                if (player.playerHp >= player.playerMaxHp)
                                {
                                    player.playerHp = player.playerMaxHp;

                                }
                                Console.WriteLine($"{player.playerName} healed and hp is now {player.playerHp}");
                            }
                            Console.WriteLine($"{enemy.enemyName} attacks back");
                            player.playerHp -= enemy.enemyDamagePower;
                            Console.WriteLine($"{player.playerName} hp is now {player.playerHp} ");

                            if (player.playerHp <= 0)
                            {
                                Console.WriteLine("You died! Game over.");
                                battleGoingOn = false;
                            }

                            break;

                        case "run":
                            Console.WriteLine($"{player.playerName}  ran away! You lost");
                            battleGoingOn = false;
                            break;
                        default:
                            Console.WriteLine("Invalid action please choose one of following (attack/heal/run)");
                            break;
                    }
                }
            }
        }


        public void showStatus(Player player, Enemy enemy)
        {
            Console.WriteLine("\n<<<<    Player and Enemy Status    >>>>");
            Console.WriteLine($"Player :{player.playerName} Class:{player.playerClass}" +
                $" HP:{player.playerHp} Damage Power:{player.playerDamagePower} Loot:{player.playerLoot}");
            Console.WriteLine($"Enemy :{enemy.enemyName} Class:{enemy.enemyClass}" +
                $" HP:{enemy.enemyHp} Damage Power:{enemy.enemyDamagePower} Loot:{enemy.enemyLoot}");
        }

        public void rest(Player player)
        {
            if (player.playerHp >= player.playerMaxHp)
            {
                Console.WriteLine("hp is already full");
            }
            else
            {
                player.playerHp += 5;
                if (player.playerHp > player.playerMaxHp)
                {
                    player.playerHp = player.playerMaxHp;
                }
                Console.WriteLine($"{player.playerName} is rested and hp is {player.playerHp}");
            }
        }


    }
}
