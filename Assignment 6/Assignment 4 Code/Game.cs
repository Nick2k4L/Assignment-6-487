using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4_487
{
    public class Game
    {
        ZombieFactory factory = new ZombieFactory();

        public Game()
        {
            
        }

        public void TestGame()
        {
            var factory = new ZombieFactory();
            List<IZombieComponent> zombies = new List<IZombieComponent>();

            IZombieComponent zombie1 = factory.CreateZombie("RegularZombie");
            IZombieComponent zombie2 = factory.CreateZombie("ConeZombie");
            IZombieComponent zombie3 = factory.CreateZombie("BucketZombie");

            zombies.Add(zombie1);
            zombies.Add(zombie2);
            zombies.Add(zombie3);
            int test = 5;

            while (zombies.Count > 0)
            {
                Console.WriteLine("=== No Damage Applied ===");
                this.PrintZombies(zombies);
                Console.WriteLine("=== Took Damage ===");
                zombies[0].TakeDamage(35);
                this.RemoveZombie(zombies);
                this.PrintZombies(zombies);
                
            }
        }

        public void GamePlay()
        {
            bool input = true;
            List<IZombieComponent> zombies = new List<IZombieComponent>();

            while (input)
            {
                Console.WriteLine("=====================");
                Console.Write(" 1. Create Zombies?\n 2. Play Game.\n 3. Quit \n");
                var keyPressed = Console.ReadLine();
                switch(keyPressed)
                {
                    case "1":
                        this.ZombieCreator(zombies);
                        break;
                    case "2":
                        this.MainGame(zombies);
                        break;
                    case "3":
                        input = false;
                        break;
                }
            }
        }

        public void MainGame(List<IZombieComponent> zombies)
        {
            Console.WriteLine($"Enter in a Damage value, Default is 25");
            string? damageNumber = Console.ReadLine();

            int damage = int.Parse(damageNumber);
            int roundCount = 0;
            Console.Write($"Round {roundCount}: ");
            this.PrintZombies(zombies);
            while (zombies.Count > 0)
            {
                roundCount++;
               // Console.WriteLine("=== No Damage Applied ===");
               // this.PrintZombies(zombies);
               // Console.WriteLine("=== Took Damage ===");
                zombies[0].TakeDamage(damage);
                this.RemoveZombie(zombies);
                Console.Write($"Round {roundCount}: ");
                this.PrintZombies(zombies);
            }

        }

        public void ZombieCreator(List<IZombieComponent> zombies)
        {
            string? zombieType = "";
           
            while (zombieType != "5")
            {
                Console.WriteLine("=====================");
                Console.WriteLine("Which Kind?");
                Console.Write(" 1. Regular \n 2. Cone \n 3. Screen \n 4. Bucket\n 5. Done\n");
                zombieType = Console.ReadLine();
                switch(zombieType)
                {
                    case "1":
                        zombies.Add(this.factory.CreateZombie("RegularZombie"));
                        Console.WriteLine("Regular Zombie Created");
                        break;
                    case "2":
                        zombies.Add(this.factory.CreateZombie("ConeZombie"));
                        Console.WriteLine("Cone Zombie Created");
                        break;
                    case "3":
                        zombies.Add(this.factory.CreateZombie("ScreenZombie"));
                        Console.WriteLine("Screen Zombie Created");
                        break;
                    case "4":
                        zombies.Add(this.factory.CreateZombie("BucketZombie"));
                        Console.WriteLine("Bucket Zombie Created");
                        break;
                }
            }

            Console.WriteLine("All Created Zombies: ");
            this.PrintZombies(zombies);

        }

        public void PrintZombies(List<IZombieComponent> zombies)
        {
            Console.Write("[");
            foreach (IZombieComponent zombie in zombies)
            {
                zombie.RepresentZombie();
            }
            Console.Write("]");
            Console.WriteLine("");
        }

        public void RemoveZombie(List<IZombieComponent> zombies)
        {
            for(int i = 0; i < zombies.Count; i++)
            {
                if (zombies[i].Die())
                {
                    zombies.RemoveAt(i);
                }
            }
        }

    }
}
