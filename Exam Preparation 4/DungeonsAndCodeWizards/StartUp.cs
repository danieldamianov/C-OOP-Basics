using System;
using System.Linq;

namespace DungeonsAndCodeWizards
{
    public class StartUp
    {
        // DO NOT rename this file's namespace or class name.
        // However, you ARE allowed to use your own namespaces (or no namespaces at all if you prefer) in other classes.
        public static void Main(string[] args)
        {
            DungeonMaster dungeonMaster = new DungeonMaster();
            string input;
            while (string.IsNullOrEmpty(input = Console.ReadLine()) == false)
            {
                string[] split = input.Split();
                string command = split[0];
                try
                {
                    switch (command)
                    {
                        case "JoinParty":
                            Console.WriteLine(dungeonMaster.JoinParty(split.Skip(1).ToArray()));
                            break;
                        case "AddItemToPool":
                            Console.WriteLine(dungeonMaster.AddItemToPool(split.Skip(1).ToArray()));
                            break;
                        case "PickUpItem":
                            Console.WriteLine(dungeonMaster.PickUpItem(split.Skip(1).ToArray()));
                            break;
                        case "UseItem":
                            Console.WriteLine(dungeonMaster.UseItem(split.Skip(1).ToArray()));
                            break;
                        case "UseItemOn":
                            Console.WriteLine(dungeonMaster.UseItemOn(split.Skip(1).ToArray()));
                            break;
                        case "GiveCharacterItem":
                            Console.WriteLine(dungeonMaster.GiveCharacterItem(split.Skip(1).ToArray()));
                            break;
                        case "GetStats":
                            Console.WriteLine(dungeonMaster.GetStats());
                            break;
                        case "Attack":
                            Console.WriteLine(dungeonMaster.Attack(split.Skip(1).ToArray()));
                            break;
                        case "Heal":
                            Console.WriteLine(dungeonMaster.Heal(split.Skip(1).ToArray()));
                            break;
                        case "EndTurn":
                            Console.WriteLine(dungeonMaster.EndTurn(split.Skip(1).ToArray()));
                            if (dungeonMaster.IsGameOver())
                            {
                                Console.WriteLine("Final stats:");
                                Console.WriteLine(dungeonMaster.GetStats());
                                return;
                            }
                            break;
                        case "IsGameOver":
                            break;
                    }

                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Parameter Error: " + ex.Message);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("Invalid Operation: " + ex.Message);
                }
            }
            Console.WriteLine("Final stats:");
            Console.WriteLine(dungeonMaster.GetStats());
        }
    }
}