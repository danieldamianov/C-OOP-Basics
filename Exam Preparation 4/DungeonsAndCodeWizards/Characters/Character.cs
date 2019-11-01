using DungeonsAndCodeWizards.Bags;
using DungeonsAndCodeWizards.Characters.Enums;
using DungeonsAndCodeWizards.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Characters
{
    public abstract class Character
    {
        private string name;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;
            this.Health = health; // validate
            this.Armor = armor; // validate 
            this.BaseHealth = health;
            this.BaseArmour = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
            //this.RestHealMultiplier = 0.2; // try overrindg
            this.IsAlive = true;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                this.name = value;
            }
        }

        public double BaseHealth { get; }

        public double Health { get; private set; }

        public double BaseArmour { get; }

        public double Armor { get; private set; }

        public double AbilityPoints { get; }

        public Bag Bag { get; } // check visibility

        public Faction Faction { get; } // check visibility

        public bool IsAlive { get; private set; }

        public virtual double RestHealMultiplier => 0.2;

        protected void CheckCharacterForAlive(Character character)
        {
            if (character.IsAlive == false)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }

        public void TakeDamage(double hitPoints)
        {
            this.CheckCharacterForAlive(this);
            this.Armor -= hitPoints;
            if (this.Armor < 0)
            {
                this.Health += this.Armor;
                this.Armor = 0;
                if (this.Health <= 0)
                {
                    this.IsAlive = false;
                    this.Health = 0;
                }
            }
        }

        public void Rest()
        {
            this.CheckCharacterForAlive(this);
            this.Health += this.BaseHealth * this.RestHealMultiplier;
            this.Health = Math.Min(this.Health, this.BaseHealth);
        }

        public void UseItem(Item item)
        {
            this.CheckCharacterForAlive(this);
            item.AffectCharacter(this); // check later

        }

        public void UseItemOn(Item item, Character character)
        {
            this.CheckCharacterForAlive(this);
            this.CheckCharacterForAlive(character);
            item.AffectCharacter(character);
        }

        public void ReceiveItem(Item item)
        {
            this.CheckCharacterForAlive(this);
            this.Bag.AddItem(item);
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            this.CheckCharacterForAlive(this);
            this.CheckCharacterForAlive(character);
            character.ReceiveItem(item);
        }

        public void IncreaseHealth(double healthPoints)
        {
            this.Health += healthPoints; // check for OverHealthing
            this.Health = Math.Min(this.Health, this.BaseHealth);
        }

        public void DecreaseHealth(double healthPoints)
        {
            this.Health -= healthPoints; // check for OverHealthing
            if (this.Health <= 0)
            {
                this.IsAlive = false;
                this.Health = 0;
            }
        }

        public void RepairArmour()
        {
            this.Armor = this.BaseArmour;
        }

        public override string ToString()
        {
            string status = this.IsAlive ? "Alive" : "Dead";
            return $"{this.Name} - HP: {this.Health}/{this.BaseHealth}, AP: {this.Armor}/{this.BaseArmour}, Status: {status}";
        }
    }
}
