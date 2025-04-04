using Assignment4_487;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _487Assignment4.Decorator_Pattern
{
    public class BucketDecorator : ZombieDecorator
    {

        public override string ZombieType { get; set; }

        public override int AccessoryHealth { get; set; } = 100;

        public override int GetTotalHealth { get; set; }
        public override bool isMetal { get; set; }

        public IZombieComponent accessory { get; set; }

        public BucketDecorator(IZombieComponent zombieAccessory) : base(zombieAccessory)
        {
            this.ZombieType = $"Bucket {zombieAccessory.ZombieType}";
            this.GetTotalHealth = zombieAccessory.GetTotalHealth + this.AccessoryHealth;
            this.isMetal = true;
        }

        public override bool Die()
        {
            return this.zombie.Die();
        }

        public override bool GetMetalStatus()
        {
            if (this.isMetal)
            {
                return true;
            }
            else
            {
                this.AccessoryHealth = 0;
                this.ZombieType = "Regular Zombie";
                return false;
            }
        }

        public override void RepresentZombie()
        {
            Console.Write($"{this.ZombieType} / {this.GetTotalHealth}, ");
        }

        public override void TakeDamage(int damage)
        {
            if (this.AccessoryHealth > 0 && this.isMetal)
            {
                this.AccessoryHealth -= damage;
                if (this.AccessoryHealth <= 0)
                {
                    this.isMetal = false;
                    this.ZombieType = "Regular Zombie";
                    this.zombie?.TakeDamage(Math.Abs(this.AccessoryHealth));
                }
            }
            else
            {
                this.zombie?.TakeDamage(damage);
            }
        }

        public override void MagnetForce()
        {
            this.isMetal = false;
            this.GetMetalStatus();
        }

        public override void FromAboveDamage(int damage)
        {
            this.TakeDamage(damage);
        }
    }
}
