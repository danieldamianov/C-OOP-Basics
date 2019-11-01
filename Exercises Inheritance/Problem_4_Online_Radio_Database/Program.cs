using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Program
{
    static void Main(string[] args)
    {
        var result = new StringBuilder();

        List<Song> songs = new List<Song>();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            try
            {
                songs.Add(new Song(Console.ReadLine()));
                result.AppendLine("Song added.");
            }
            catch (Exception ex)
            {
                result.AppendLine(ex.Message);
            }
        }
        var sum = songs.Sum(x => x.DurationInSeconds);
        var hours = sum / 3600;
        sum %= 3600;

        var minutes = sum / 60;
        sum %= 60;

        var seconds = sum;
        Console.WriteLine(result.ToString().Trim());

        Console.WriteLine($"Songs added: {songs.Count}");
        Console.WriteLine($"Playlist length: {hours}h {minutes}m {seconds}s");
    }
}