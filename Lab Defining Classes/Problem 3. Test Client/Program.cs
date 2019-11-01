using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] inputTokens = input.Split();
            string commandType = inputTokens[0];
            int accountId = int.Parse(inputTokens[1]);
            switch (commandType)
            {
                case "Create":
                    if (accounts.ContainsKey(accountId))
                    {
                        Console.WriteLine("Account already exists");
                    }
                    else
                    {
                        var account = new BankAccount();
                        account.Id = accountId;
                        account.Balance = 0;
                        accounts.Add(accountId, account);
                    }
                    break;
                case "Deposit":
                    if (!accounts.ContainsKey(accountId))
                    {
                        Console.WriteLine("Account does not exist");
                    }
                    else
                    {
                        accounts[accountId].Deposit(decimal.Parse(inputTokens[2]));
                    }
                    break;
                case "Withdraw":
                    if (!accounts.ContainsKey(accountId))
                    {
                        Console.WriteLine("Account does not exist");
                    }
                    else
                    {
                        accounts[accountId].Withdraw(decimal.Parse(inputTokens[2]));
                    }
                    break;
                case "Print":
                    if (accounts.ContainsKey(accountId))
                    {
                        Console.WriteLine(accounts[accountId]);
                    }
                    else
                    {
                        Console.WriteLine("Account does not exist");
                    }
                    break;
            }
        }
    }
}
