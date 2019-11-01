using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{
    public class GreedyTimes
    {
        static void Main(string[] args)
        {
            long bagCapacity = long.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var bag = new Dictionary<string, Dictionary<string, long>>();

            for (int i = 0; i < input.Length; i += 2)
            {
                string name = input[i];
                long amount = long.Parse(input[i + 1]);

                string type = DefineType(name);

                if (FullBagOrUnDefunedType(bag, type, bagCapacity, amount))
                {
                    continue;
                }

                if (ImpossiblePut(type, bag, amount))
                {
                    continue;
                }

                FillBag(bag, name, amount, type);
            }

            PrintBag(bag);
        }

        private static void PrintBag(Dictionary<string, Dictionary<string, long>> bag)
        {
            foreach (var type in bag)
            {
                Console.WriteLine($"<{type.Key}> ${type.Value.Values.Sum()}");
                foreach (var item in type.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item.Key} - {item.Value}");
                }
            }
        }

        private static void FillBag(Dictionary<string, Dictionary<string, long>> bag, string name, long amount, string type)
        {
            if (!bag.ContainsKey(type))
            {
                bag[type] = new Dictionary<string, long>();
            }

            if (!bag[type].ContainsKey(name))
            {
                bag[type][name] = 0;
            }

            bag[type][name] += amount;
        }

        private static bool ImpossiblePut(string type , Dictionary<string, Dictionary<string, long>> bag,long amount )
        {
            switch (type)
            {
                case "Gem":
                    if (!bag.ContainsKey(type))
                    {
                        if (bag.ContainsKey("Gold"))
                        {
                            if (amount > bag["Gold"].Values.Sum())
                            {
                                return true;
                            }
                        }
                        else
                        {
                            return true;
                        }
                    }
                    else if (bag[type].Values.Sum() + amount > bag["Gold"].Values.Sum())
                    {
                        return true;
                    }
                    break;
                case "Cash":
                    if (!bag.ContainsKey(type))
                    {
                        if (bag.ContainsKey("Gem"))
                        {
                            if (amount > bag["Gem"].Values.Sum())
                            {
                                return true;
                            }
                        }
                        else
                        {
                            return true;
                        }
                    }
                    else if (bag[type].Values.Sum() + amount > bag["Gem"].Values.Sum())
                    {
                        return true;
                    }
                    break;
            }

            return false;
        }

        private static bool FullBagOrUnDefunedType(Dictionary<string, Dictionary<string, long>> bag, string type , long bagCapacity , long amount)
        {
            if(type == "")
            {
                return true;
            }
            if(bagCapacity < bag.Values.Select(x => x.Values.Sum()).Sum() + amount)
            {
                return true;
            }
            return false;
        }

        static string DefineType(string name)
        {
            if (name.Length == 3)
            {
                return "Cash";
            }
            else if (name.ToLower().EndsWith("gem"))
            {
                return "Gem";
            }
            else if (name.ToLower() == "gold")
            {
                return "Gold";
            }

            return "";
        }
    }
}