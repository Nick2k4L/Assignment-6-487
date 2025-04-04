using Assignment4_487;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _487Assignment4.Decorator_Pattern
{
    public class ConeDecorator : ZombieDecorator
    {

        public override string ZombieType { get; set; } = "Cone Zombie";
        public override int GetTotalHealth => this.zombie.GetTotalHealth + this.AccessoryHealth;
        public override bool isMetal { get; set; }
        public override int AccessoryHealth { get; set; } = 25;

        public ConeDecorator(IZombieComponent zombie) : base(zombie)
        {
            //this.GetTotalHealth = zombie.GetTotalHealth + this.AccessoryHealth;
        }

        public override bool Die()
        {
            return this.zombie.Die();
        }

        public override void FromAboveDamage(int damage)
        {
            this.TakeDamage(damage);
        }

        public override bool GetMetalStatus()
        {
            return false;
        }

        public override void MagnetForce()
        {
       
        }

        public override void RepresentZombie()
        {
            if (this.AccessoryHealth > 0)
            {
                Console.Write($"{this.ZombieType} / {this.GetTotalHealth}, ");
            }
            else
            {
                this.zombie.RepresentZombie();
            }
            //base.RepresentZombie();
        }
        
        public override void TakeDamage(int damage)
        {
            if (this.AccessoryHealth > 0)
            {
                this.AccessoryHealth -= damage;
                if (this.AccessoryHealth <= 0)
                {
                    this.ZombieType = "Regular Zombie";
                    this.zombie?.TakeDamage(Math.Abs(this.AccessoryHealth));
                }
            }
            else
            {
                this.zombie?.TakeDamage(damage);
            }
        }
    }
}
