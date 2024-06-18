using QuantumSerpent;
using System;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

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
    public string Difficulty { get; set; } = "Medium";


    public static GameSettings Load()
    {
        if (File.Exists("gamesettings.json"))
        {
            var json = File.ReadAllText("gamesettings.json");
            return JsonSerializer.Deserialize<GameSettings>(json) ?? new GameSettings();
        }
        return new GameSettings();
    }

    public static void Save(GameSettings settings)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(settings, options);
        File.WriteAllText("gamesettings.json", json);
    }
}
