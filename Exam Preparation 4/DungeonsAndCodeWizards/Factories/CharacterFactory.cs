using DungeonsAndCodeWizards.Characters;
using DungeonsAndCodeWizards.Characters.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Factories
{
    public class CharacterFactory
    {
        public Character CreateCharacter(string faction, string characterType, string name)
        {
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
                    else if (faction == "Java")
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
            return character;
        }
    }
}
