using System;
using System.Linq;
using System.Text.RegularExpressions;

public class Song
{
    private string artistName;
    private string songName;
    private int durationInSeconds;

    public int DurationInSeconds => this.durationInSeconds;

    public Song(string input)
    {
        string[] songArguments = ValidateSong(input);
        string artistName = songArguments[0];
        string songName = songArguments[1];
        string length = songArguments[2];
        ValidateArtistName(artistName);
        ValidateSongName(songName);
        ValidateSondLength(length);
        int[] lengthParameters = length.Split(':').Select(int.Parse).ToArray();
        ValidateMinutes(lengthParameters[0]);
        ValidateSeconds(lengthParameters[1]);

        this.artistName = artistName;
        this.songName = songName;
        this.durationInSeconds = lengthParameters[0] * 60 + lengthParameters[1];
    }

    private void ValidateMinutes(int m)
    {
        if (m < 0 || m > 14)
        {
            throw new InvalidSongMinutesException();
        }
    }

    private void ValidateSeconds(int s)
    {
        if (s < 0 || s > 59)
        {
            throw new InvalidSongSecondsException();
        }
    }

    private void ValidateSondLength(string length)
    {
        string pattern = @"[0-9]{1,}:[0-9]{1,}";
        if (Regex.IsMatch(length , pattern) == false)
        {
            throw new InvalidSongLengthException();
        }
    }

    private void ValidateArtistName(string artistName)
    {
        if (artistName.Length < 3 || artistName.Length > 20)
        {
            throw new InvalidArtistNameException();
        }
    }

    private void ValidateSongName(string songName)
    {
        if (songName.Length < 3 || songName.Length > 30)
        {
            throw new InvalidSongNameException();
        }
    }

    private string[] ValidateSong(string input)
    {
        var args = input.Split(';');
        if (args.Length < 3)
        {
            throw new InvalidSongException();
        }
        return args;
    }
}

