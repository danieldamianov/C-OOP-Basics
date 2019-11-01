using System;
using System.Collections.Generic;
using System.Text;

public class Player
{
    private string name;
    private int endurance;
    private int sprint;
    private int dribble;
    private int passing;
    private int shooting;

    public string Name
    {
        get { return name; }
        private set { name = value; }
    }

    public int Endurance
    {
        get { return endurance; }
        private set { endurance = value; }
    }

    public int Sprint
    {
        get { return sprint; }
        private set { sprint = value; }
    }

    public int Dribble
    {
        get { return dribble; }
        private set { dribble = value; }
    }
    public int Shooting
    {
        get { return shooting; }
        private set { shooting = value; }
    }
    public int Passing
    {
        get { return passing; }
        private set { passing = value; }
    }

    public int GetOverallReting()
    {
        return (int)Math.Round((shooting + passing + dribble + sprint + endurance) / 5m);
    }

    public Player(string name , int endurance , int sprint , int dribble , int shoolting , int passing)
    {
        if (!(IsValidStat(endurance) && IsValidStat(sprint) && IsValidStat(dribble) && IsValidStat(shoolting) && IsValidStat(passing)))
        {
            string stat = "";
            if (IsValidStat(endurance) == false)
            {
                stat = "Endurance";
            }
            else if (IsValidStat(sprint) == false)
            {
                stat = "Spring";
            }
            else if (IsValidStat(dribble) == false)
            {
                stat = "Dribble";
            }
            else if (IsValidStat(shoolting) == false)
            {
                stat = "Shooting";
            }
            else if (IsValidStat(passing) == false)
            {
                stat = "Passing";
            }
            throw new ArgumentException($"{stat} should be between 0 and 100.");
        }
        this.Name = name;
        this.Endurance = endurance;
        this.Sprint = sprint;
        this.Dribble = dribble;
        this.Shooting = shoolting;
        this.Passing = passing;
    }
    private bool IsValidStat(int stat)
    {
        if (stat < 0 || stat > 100)
        {
            return false;
        }

        return true;
    }
}
