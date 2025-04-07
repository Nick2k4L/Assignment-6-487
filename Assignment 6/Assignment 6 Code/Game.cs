using _487Assignment4.GEM_GOM;
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
        GameObjectManager manager = new GameObjectManager();
        GameEventManager gameEventManager;

        public Game()
        {
            this.gameEventManager = new GameEventManager(this.manager);
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

        public void TestDecorator()
        {
            var factory = new ZombieFactory();
            List<IZombieComponent> zombies = new List<IZombieComponent>();

            IZombieComponent zombie1 = factory.CreateZombie("RegularZombie");
            IZombieComponent zombie2 = factory.CreateZombie("ConeZombie");
            IZombieComponent zombie3 = factory.CreateZombie("BucketZombie");
            IZombieComponent zombie4 = factory.CreateZombie("ScreenZombie");

            //zombies.Add(zombie1);
            //zombies.Add(zombie2);
            zombies.Add(zombie3);
            zombies.Add(zombie4);
            int test = 5;

            int count = 0;
            this.PrintZombies(zombies);
            while (zombies.Count > 0)
            {
                //Console.WriteLine("=== No Damage Applied ===");
                //this.PrintZombies(zombies);
                // Console.WriteLine("=== Took Damage ===");
                //this.PrintZombies(zombies);
                //Console.WriteLine("==Above is Before the magnent and damage==");
                //zombies[0].MagnetForce();

                //zombies[0].TakeDamage(35);
                zombies[0].FromAboveDamage(25);
                //this.PrintZombies(zombies);
                //Console.WriteLine("==Damage has been taken==");
                this.RemoveZombie(zombies);
                this.PrintZombies(zombies);
                //Console.WriteLine("==Magnet has been removed==");
                count++;

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
            
            int roundCount = 0;
            Console.Write($"Round {roundCount}: ");
            this.PrintZombies(zombies);
            while (this.manager?.zombies?.Count > 0)
            {
                roundCount++;
               // Console.WriteLine("=== No Damage Applied ===");
               // this.PrintZombies(zombies);
               // Console.WriteLine("=== Took Damage ===");
                this.ChoosePlant(zombies);
                this.manager.RemoveDeadZombies();
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
                IZombieComponent? zombie = null;
                zombieType = Console.ReadLine();
                
                switch(zombieType)
                {
                    case "1":
                        zombie = this.factory.CreateZombie("RegularZombie");
                        Console.WriteLine("Regular Zombie Created");
                        break;
                    case "2":
                        zombie = this.factory.CreateZombie("ConeZombie");
                        Console.WriteLine("Cone Zombie Created");
                        break;
                    case "3":
                        zombie = this.factory.CreateZombie("ScreenZombie");
                        Console.WriteLine("Screen Zombie Created");
                        break;
                    case "4":
                        zombie = this.factory.CreateZombie("BucketZombie");
                        Console.WriteLine("Bucket Zombie Created");
                        break;
                }
                if (zombie != null)
                {
                    this.manager.AddZombie(zombie);
                }
            }

            

            Console.WriteLine("All Created Zombies: ");
            this.PrintZombies(zombies);

        }

        public void ChoosePlant(List<IZombieComponent> zombies)
        {
            // Here we choose the plant that will affect the 
            Console.WriteLine("What Type of Plant do you want to attack with: ");
            Console.WriteLine(" 1. Peashooter\n 2. Watermelon\n 3. Magnet-Shroom\n");
            var plantType = Console.ReadLine();
            switch(plantType)
            {
                case "1":
                    //Console.WriteLine($"Enter in a Damage value, Default is 25");
                    //string? damageNumber = Console.ReadLine();

                    //int damage = int.Parse(damageNumber);
                    this.gameEventManager.SimulateCollisionDetection(1);
                    break;
                case "2":
                    //Console.WriteLine($"Enter in a Damage value, Default is 40");
                    //string? damageNumber1 = Console.ReadLine();

                    //int damage1 = int.Parse(damageNumber1);
                    this.gameEventManager.SimulateCollisionDetection(2);

                    break;
                case "3":
                    this.gameEventManager.SimulateCollisionDetection(3);
                    break;
                default:
                    Console.WriteLine("Invalid Type skipping round....");
                    break;
            }
        }

        public void PrintZombies(List<IZombieComponent> zombies)
        {
            Console.Write("[");
            foreach (IZombieComponent zombie in this.manager.zombies)
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
