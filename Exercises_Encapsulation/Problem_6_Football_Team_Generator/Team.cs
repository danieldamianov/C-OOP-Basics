using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Team
{
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    private List<Player> players;

    public int Rating => this.players.Count != 0 ? (int)Math.Round(this.players.Average(x => x.GetOverallReting())) : 0;

    public Team(string name)
    {
        if (IsNameValid(name) == false)
        {
            throw new ArgumentException("A name should not be empty.");
        }
        this.Name = name;
        this.players = new List<Player>();
    }

    public void AddPlayer(Player player)
    {
        this.players.Add(player);
    }

    public void RemovePlayer(string playerName)
    {
        if (this.players.Any(player => player.Name == playerName) == false)
        {
            throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
        }
        this.players.RemoveAll(x => x.Name == playerName);
    }

    private bool IsNameValid(string name)
    {
        if (name?.Trim().Length == 0)
        {
            return false;
        }
        return true;
    }

    public override string ToString()
    {
        return $"{this.Name} - {this.Rating}";
    }
}

