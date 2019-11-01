using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower
{
    public RaceTower()
    {
        this.drivers = new List<Driver>();
        this.initialDrivers = new List<Driver>();
        this.currentLapsNumber = 0;
        this.weather = WeatherEnum.Sunny;
        this.DNFDriversconst = 1;
        this.DNFDriverFirstConst = int.MaxValue - 200;
        this.OrderOfInputVar = 1;
        this.boolHasRegisteredAllDrivers = false;

    }
    private bool boolHasRegisteredAllDrivers;
    private int DNFDriverFirstConst;
    private int OrderOfInputVar;
    private int DNFDriversconst;
    public List<Driver> drivers;
    public List<Driver> initialDrivers;
    private int totalLapsNumber;
    private double trackLength;
    private int currentLapsNumber;
    private WeatherEnum weather;

    public void SetTrackInfo(int lapsNumber, double trackLength)
    {
        this.totalLapsNumber = lapsNumber;
        this.trackLength = trackLength;
    }
    public void RegisterDriver(List<string> commandArgs)
    {
        if (int.Parse(commandArgs[2]) < 0 &&
            double.Parse(commandArgs[3]) < 0 &&
            double.Parse(commandArgs[5]) < 0 &&
            double.Parse(commandArgs[6]) < 0)
        {
            return;
        }
        switch (commandArgs[0])
        {
            case "Aggressive":
                if (commandArgs[4] == "Ultrasoft")
                {
                    drivers.Add(new AggressiveDriver
                        (commandArgs[1],
                        int.Parse(commandArgs[2]),
                        double.Parse(commandArgs[3]),
                        double.Parse(commandArgs[5]),
                        double.Parse(commandArgs[6])));
                }
                else if(commandArgs[4] == "Hard")
                {
                    drivers.Add(new AggressiveDriver
                        (commandArgs[1],
                        int.Parse(commandArgs[2]),
                        double.Parse(commandArgs[3]),
                        double.Parse(commandArgs[5])));
                }
                break;
            case "Endurance":
                if (commandArgs[4] == "Ultrasoft")
                {
                    drivers.Add(new EnduranceDriver
                        (commandArgs[1],
                        int.Parse(commandArgs[2]),
                        double.Parse(commandArgs[3]),
                        double.Parse(commandArgs[5]),
                        double.Parse(commandArgs[6])));
                }
                else if(commandArgs[4] == "Hard")
                {
                    drivers.Add(new EnduranceDriver
                        (commandArgs[1],
                        int.Parse(commandArgs[2]),
                        double.Parse(commandArgs[3]),
                        double.Parse(commandArgs[5])));
                }
                break;
        }
        drivers.Last().orderOfInput = this.OrderOfInputVar;
        this.OrderOfInputVar++;
    } // CHECK FOR INVALID PARAMS!!!

    internal bool IsFinishedRace()
    {
        return this.totalLapsNumber == this.currentLapsNumber;
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        string reasonToBox = commandArgs[0];
        string driversName = commandArgs[1];
        this.drivers.Single(dr => dr.Name == driversName).TotalTime += 20;
        if (reasonToBox == "ChangeTyres")
        {
            if (commandArgs[2] == "Hard")
            {
                this.drivers.Single(dr => dr.Name == driversName)
                    .ChangeCarsTyres(new HardTyre(double.Parse(commandArgs[3])));
            }
            else if(commandArgs[3] == "Ultrasoft")
            {
                this.drivers.Single(dr => dr.Name == driversName)
                    .ChangeCarsTyres(new UltrasoftTyre(double.Parse(commandArgs[3]),double.Parse(commandArgs[4])));
            }
        }
        else if(reasonToBox == "Refuel")
        {
            this.drivers.Single(dr => dr.Name == driversName).IncreaseCarFuelAmount(double.Parse(commandArgs[2]));
        }
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        if (this.boolHasRegisteredAllDrivers == false)
        {
            this.initialDrivers = new List<Driver>();
            this.initialDrivers.AddRange(drivers);
            this.boolHasRegisteredAllDrivers = true;
        }
        var listOfOutputMessages = new List<string>();
        int numberOfLaps = int.Parse(commandArgs[0]);
        if (numberOfLaps > this.totalLapsNumber - this.currentLapsNumber)
        {
            listOfOutputMessages.Add($"There is no time! On lap {this.currentLapsNumber}."); // in the main trycatch
            return string.Join(Environment.NewLine, listOfOutputMessages);
        }
        for (int lapCounter = 0; lapCounter < numberOfLaps; lapCounter++)
        {
            this.currentLapsNumber++;
            foreach (var driver in this.initialDrivers)
            {
                if (driver.isInRace == false)
                {
                    continue;
                }

                driver.TotalTime += (60d / (this.trackLength / driver.Speed));

                try
                {
                    driver.DecreaseCarFuelAmount(this.trackLength * driver.FuelConsumptionPerKm);
                    driver.DegradateTyres();
                }
                catch (DidNotFinishedDriverExcepton ex)
                {
                    driver.OutOFTheRace(ex.Message);
                    driver.TotalTime = this.DNFDriverFirstConst - this.DNFDriversconst;
                    this.DNFDriversconst++;
                }
            }
            
            CorrectLeaderBoard();
            CheckForOvertaking(listOfOutputMessages);
        }
        return string.Join(Environment.NewLine, listOfOutputMessages); // in main check for empty!!
    }

    private void CorrectLeaderBoard()
    {
        this.drivers = drivers.OrderBy(dr => dr.TotalTime).ThenByDescending(dr => dr.orderOfInput).ThenByDescending(dr => dr.Name).ToList();
    }

    private void CheckForOvertaking(List<string> listOfOvertakingMessages)
    {
        for (int i = this.drivers.Count - 1; i >= 1; i--)
        {
            if (drivers[i].isInRace == false)
            {
                continue;
            }
            if (drivers[i] is AggressiveDriver &&
                drivers[i].GetTyreType() == "Ultrasoft" &&
                drivers[i].TotalTime - drivers[i - 1].TotalTime <= 3)
            {
                if (this.weather == WeatherEnum.Foggy)
                {
                    drivers[i].OutOFTheRace("Crashed");
                }
                else
                {
                    drivers[i].TotalTime -= 3;
                    drivers[i - 1].TotalTime += 3;
                    listOfOvertakingMessages.
                        Add($"{drivers[i].Name} has overtaken {drivers[i - 1].Name} on lap {this.currentLapsNumber}.");
                }
                CorrectLeaderBoard();
                i--;
                continue;
            }

            if (drivers[i] is EnduranceDriver &&
                drivers[i].GetTyreType() == "Hard" &&
                drivers[i].TotalTime - drivers[i - 1].TotalTime <= 3)
            {
                if (this.weather == WeatherEnum.Rainy)
                {
                    drivers[i].OutOFTheRace("Crashed");
                }
                else
                {
                    drivers[i].TotalTime -= 3;
                    drivers[i - 1].TotalTime += 3;
                    listOfOvertakingMessages.
                        Add($"{drivers[i].Name} has overtaken {drivers[i - 1].Name} on lap {this.currentLapsNumber}.");
                }
                CorrectLeaderBoard();
                i--;
                continue;
            }

            if ((drivers[i].TotalTime - drivers[i - 1].TotalTime) <= 2)
            {
                drivers[i].TotalTime -= 2;
                drivers[i - 1].TotalTime += 2;
                listOfOvertakingMessages.
                        Add($"{drivers[i].Name} has overtaken {drivers[i - 1].Name} on lap {this.currentLapsNumber}.");
                i--;
                CorrectLeaderBoard();
            }
        }
    }
    public string GetLeaderboard()
    {
        CorrectLeaderBoard();
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"Lap {this.currentLapsNumber}/{this.totalLapsNumber}");
        for (int i = 0; i < drivers.Count; i++)
        {
            string resultOfRanking;
            if (this.drivers[i].isInRace)
            {
                resultOfRanking = $"{this.drivers[i].TotalTime:f3}";
            }
            else
            {
                resultOfRanking = this.drivers[i].ReasonForDNF;
            }
            stringBuilder.AppendLine($"{i + 1} {this.drivers[i].Name} {resultOfRanking}");
        }
        return stringBuilder.ToString().TrimEnd();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        switch (commandArgs[0])
        {
            case "Sunny":
                this.weather = WeatherEnum.Sunny;
                break;
            case "Foggy":
                this.weather = WeatherEnum.Foggy;
                break;
            case "Rainy":
                this.weather = WeatherEnum.Rainy;
                break;
        }
    }

    public void Finish()
    {
        Console.WriteLine($"{drivers[0].Name} wins the race for {drivers[0].TotalTime:f3} seconds.");
    }
}

