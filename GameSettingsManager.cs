using System;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace QuantumSerpent
{
    public static class GameSettingsManager
    {
        private const string SettingsFilePath = "gamesettings.json";

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
    }

    public class GameSettings
    {
        public string Player1Name { get; set; } = "Player 1";
        [JsonConverter(typeof(ColorJsonConverter))]
        public Color Player1HeadColor { get; set; } = Color.Green;
        [JsonConverter(typeof(ColorJsonConverter))]
        public Color Player1BodyColor { get; set; } = Color.Green;
        public string Player2Name { get; set; } = "Player 2";
        [JsonConverter(typeof(ColorJsonConverter))]
        public Color Player2HeadColor { get; set; } = Color.Yellow;
        [JsonConverter(typeof(ColorJsonConverter))]
        public Color Player2BodyColor { get; set; } = Color.Yellow;
        public int InitialPlayerLength { get; set; } = 5;
        public string CurrentMode { get; set; } = "Singleplayer";
        public int AIPlayers { get; set; } = 0;
        public int FPS { get; set; } = 60;
        public int AppleCount { get; set; } = 5;
        public int FoodGrowMultiplier { get; set; } = 1;
    }
}
