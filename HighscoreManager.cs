using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

// Represents a single highscore entry.
public class HighscoreEntry
{
    public string PlayerName { get; set; }
    public int Score { get; set; }
}

// Manages highscore operations: load, save, add.
public static class HighscoreManager
{
    private const string HighscoreFilePath = "highscores.json"; // File path for storing highscores.

    // Loads highscores from file, or returns an empty list if file doesn't exist.
    public static List<HighscoreEntry> LoadHighscores()
    {
        if (File.Exists(HighscoreFilePath))
        {
            var json = File.ReadAllText(HighscoreFilePath);
            return JsonSerializer.Deserialize<List<HighscoreEntry>>(json) ?? new List<HighscoreEntry>();
        }
        return new List<HighscoreEntry>();
    }

    // Saves highscores to file.
    public static void SaveHighscores(List<HighscoreEntry> highscores)
    {
        var json = JsonSerializer.Serialize(highscores);
        File.WriteAllText(HighscoreFilePath, json);
    }

    // Adds a new highscore and keeps the top 10 scores.
    public static void AddHighscore(string playerName, int score)
    {
        var highscores = LoadHighscores();
        highscores.Add(new HighscoreEntry { PlayerName = playerName, Score = score });
        highscores = highscores.OrderByDescending(h => h.Score).Take(10).ToList();
        SaveHighscores(highscores);
    }
}
