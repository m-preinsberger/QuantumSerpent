using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public class HighscoreEntry
{
    public string PlayerName { get; set; }
    public int Score { get; set; }
}

public static class HighscoreManager
{
    private const string HighscoreFilePath = "highscores.json";

    public static List<HighscoreEntry> LoadHighscores()
    {
        if (File.Exists(HighscoreFilePath))
        {
            var json = File.ReadAllText(HighscoreFilePath);
            return JsonSerializer.Deserialize<List<HighscoreEntry>>(json) ?? new List<HighscoreEntry>();
        }
        return new List<HighscoreEntry>();
    }

    public static void SaveHighscores(List<HighscoreEntry> highscores)
    {
        var json = JsonSerializer.Serialize(highscores);
        File.WriteAllText(HighscoreFilePath, json);
    }

    public static void AddHighscore(string playerName, int score)
    {
        var highscores = LoadHighscores();
        highscores.Add(new HighscoreEntry { PlayerName = playerName, Score = score });
        highscores = highscores.OrderByDescending(h => h.Score).Take(10).ToList();
        SaveHighscores(highscores);
    }
}
