using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace QuantumSerpent
{
    public static class GameSettingsManager
    {
        private const string SettingsFilePath = "gamesettings.json";
        private const string HighscoresFilePath = "highscores.json";

        public static GameSettings Load()
        {
            if (File.Exists(SettingsFilePath))
            {
                var json = File.ReadAllText(SettingsFilePath);
                return JsonSerializer.Deserialize<GameSettings>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    Converters = { new ColorJsonConverter() }
                }) ?? new GameSettings();
            }
            return new GameSettings();
        }

        public static void Save(GameSettings settings)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new ColorJsonConverter() }
            };
            var json = JsonSerializer.Serialize(settings, options);
            File.WriteAllText(SettingsFilePath, json);
        }

        public static List<Highscore> LoadHighscores()
        {
            if (File.Exists(HighscoresFilePath))
            {
                var json = File.ReadAllText(HighscoresFilePath);
                return JsonSerializer.Deserialize<List<Highscore>>(json) ?? new List<Highscore>();
            }
            return new List<Highscore>();
        }

        public static void SaveHighscores(List<Highscore> highscores)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(highscores.OrderByDescending(h => h.Score).ToList(), options);
            File.WriteAllText(HighscoresFilePath, json);
        }
    }


    public class Highscore
    {
        public string PlayerName { get; set; } = string.Empty;
        public int Score { get; set; }
    }

    public class GameSettings
    {
        public string Player1Name { get; set; } = "Player 1";
        public Color Player1HeadColor { get; set; } = Color.Green;
        public Color Player1BodyColor { get; set; } = Color.DarkGreen;
        public string Player2Name { get; set; } = "Player 2";
        public Color Player2HeadColor { get; set; } = Color.Yellow;
        public Color Player2BodyColor { get; set; } = Color.Orange;
        public int InitialPlayerLength { get; set; } = 5;
        public string CurrentMode { get; set; } = "Singleplayer";
        public int AIPlayers { get; set; } = 0;
        public int FPS { get; set; } = 60;
        public int AppleCount { get; set; } = 5;
        public int FoodGrowMultiplier { get; set; } = 1;
        public string Difficulty { get; set; } = "medium";
        public bool IsFatSerpentMode { get; set; } = false; // Default value
        public int FatSerpentTimeFrame { get; set; } = 0;   // Default value in seconds
    }

}
