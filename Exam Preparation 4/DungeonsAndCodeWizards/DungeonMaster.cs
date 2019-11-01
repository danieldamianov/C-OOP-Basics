using DungeonsAndCodeWizards.Characters;
using DungeonsAndCodeWizards.Characters.Enums;
using DungeonsAndCodeWizards.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards
{
    public class DungeonMaster
    {
        private List<Character> characters;
        private List<Item> items;
        int lastSurvivorRounds = 0;

        public DungeonMaster()
        {
            this.characters = new List<Character>();
            this.items = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            string faction = args[0];
            string characterType = args[1];
            string name = args[2];
            if (faction != "CSharp" && faction != "Java")
            {
                throw new ArgumentException($@"Invalid faction ""{faction}""!");
            }
            if (characterType != "Cleric" && characterType != "Warrior")
            {
                throw new ArgumentException($@"Invalid character type ""{characterType}""!");
            }
            Character character = null;
            switch (characterType)
            {
                case "Cleric":
                    if (faction == "CSharp")
                    {
                        character = new Cleric(name, Faction.CSharp);
                    }
                    else if(faction == "Java")
                    {
                        character = new Cleric(name, Faction.Java);
                    }
                    break;
                case "Warrior":
                    if (faction == "CSharp")
                    {
                        character = new Warrior(name, Faction.CSharp);
                    }
                    else if (faction == "Java")
                    {
                        character = new Warrior(name, Faction.Java);
                    }
                    break;
            }
            this.characters.Add(character);
            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];
            if (itemName != "ArmorRepairKit" && itemName != "HealthPotion" && itemName != "PoisonPotion")
            {
                throw new ArgumentException($@"Invalid item ""{itemName}""!");
            }
            switch (itemName)
            {
                case "ArmorRepairKit":
                    this.items.Add(new ArmorRepairKit());
                    break;
                case "HealthPotion":
                    this.items.Add(new HealthPotion());
                    break;
                case "PoisonPotion":
                    this.items.Add(new PoisonPotion());
                    break;
            }
            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            Character character = this.characters.SingleOrDefault(ch => ch.Name == characterName);
            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("No items left in pool!");
            }
            string itemName = this.items.Last().GetType().Name;
            character.ReceiveItem(this.items.Last());
            items.RemoveAt(items.Count - 1);
            return $"{characterName} picked up {itemName}!";
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];
            Character character = this.characters.SingleOrDefault(ch => ch.Name == characterName);
            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }
            Item item = character.Bag.GetItem(itemName);
            character.UseItem(item);
            return $"{characterName} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];
            Character giverCharacter = this.characters.SingleOrDefault(ch => ch.Name == giverName);
            Character receiverCharacter = this.characters.SingleOrDefault(ch => ch.Name == receiverName);
            if (giverCharacter == null)
            {
                throw new ArgumentException($"Character {giverName} not found!");
            }
            if (receiverCharacter == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }
            Item item = giverCharacter.Bag.GetItem(itemName);
            giverCharacter.UseItemOn(item,receiverCharacter);
            return $"{giverName} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];
            Character giverCharacter = this.characters.SingleOrDefault(ch => ch.Name == giverName);
            Character receiverCharacter = this.characters.SingleOrDefault(ch => ch.Name == receiverName);
            if (giverCharacter == null)
            {
                throw new ArgumentException($"Character {giverName} not found!");
            }
            if (receiverCharacter == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }
            Item item = giverCharacter.Bag.GetItem(itemName);
            giverCharacter.GiveCharacterItem(item, receiverCharacter);
            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var character in this.characters.OrderByDescending(ch => ch.IsAlive).ThenByDescending(ch => ch.Health))
            {
                stringBuilder.AppendLine(character.ToString());
            }
            return stringBuilder.ToString().Trim();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            Character attackerCharacter = this.characters.SingleOrDefault(ch => ch.Name == attackerName);
            Character receiverCharacter = this.characters.SingleOrDefault(ch => ch.Name == receiverName);
            if (attackerCharacter == null)
            {
                throw new ArgumentException($"Character {attackerName} not found!");
            }
            if (receiverCharacter == null)
            {
                throw new ArgumentException($"Character {receiverName} not found!");
            }

            if (attackerCharacter is Cleric)
            {
                throw new ArgumentException($"{attackerName} cannot attack!");
            }

            Warrior warrior = (Warrior)attackerCharacter;

            warrior.Attack(receiverCharacter);

            string result = $"{attackerName} attacks {receiverName} for {attackerCharacter.AbilityPoints} hit points! " +
                $"{receiverName} has {receiverCharacter.Health}/{receiverCharacter.BaseHealth} HP " +
                $"and {receiverCharacter.Armor}/{receiverCharacter.BaseArmour} AP left!";
            if (receiverCharacter.Health == 0)
            {
                result += Environment.NewLine;
                result += $"{receiverCharacter.Name} is dead!";
            }
            return result;
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            Character healerCharacter = this.characters.SingleOrDefault(ch => ch.Name == healerName);
            Character healingReceiverCharacter = this.characters.SingleOrDefault(ch => ch.Name == healingReceiverName);
            if (healerCharacter == null)
            {
                throw new ArgumentException($"Character {healerName} not found!");
            }
            if (healingReceiverCharacter == null)
            {
                throw new ArgumentException($"Character {healingReceiverName} not found!");
            }

            if (healerCharacter is Warrior)
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }

            Cleric cleric = (Cleric)healerCharacter;

            cleric.Heal(healingReceiverCharacter);

            return $"{healerName} heals {healingReceiverName} for {healerCharacter.AbilityPoints}! " +
                $"{healingReceiverName} has {healingReceiverCharacter.Health} health now!";
        }

        public string EndTurn(string[] args)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var character in this.characters.Where(ch => ch.IsAlive))
            {
                double healthBeforeRest = character.Health;
                character.Rest();
                stringBuilder.AppendLine($"{character.Name} rests ({healthBeforeRest} => {character.Health})");
            }
            if (this.characters.Count(ch => ch.IsAlive) <= 1)
            {
                this.lastSurvivorRounds++;
            }
            return stringBuilder.ToString().Trim();
        }

        public bool IsGameOver()
        {
            if (this.lastSurvivorRounds > 1)
            {
                return true;
            }
            return false;
        }

    }
}
