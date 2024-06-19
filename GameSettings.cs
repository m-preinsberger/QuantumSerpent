using QuantumSerpent;
using System;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

// Defines the GameSettings class to store and manage game settings
public class GameSettings
{
    // Properties for player 1's name, head color, and body color with default values
    public string Player1Name { get; set; } = "Player 1";
    [JsonConverter(typeof(ColorJsonConverter))] // Custom JSON converter for System.Drawing.Color
    public Color Player1HeadColor { get; set; } = Color.Green;
    [JsonConverter(typeof(ColorJsonConverter))] // Custom JSON converter for System.Drawing.Color
    public Color Player1BodyColor { get; set; } = Color.Green;

    // Properties for player 2's name, head color, and body color with default values
    public string Player2Name { get; set; } = "Player 2";
    [JsonConverter(typeof(ColorJsonConverter))] // Custom JSON converter for System.Drawing.Color
    public Color Player2HeadColor { get; set; } = Color.Yellow;
    [JsonConverter(typeof(ColorJsonConverter))] // Custom JSON converter for System.Drawing.Color
    public Color Player2BodyColor { get; set; } = Color.Yellow;

    // Property for the initial length of the player's snake
    public int InitialPlayerLength { get; set; } = 5;

    // Property for the current game mode (e.g., Singleplayer, Multiplayer)
    public string CurrentMode { get; set; } = "Singleplayer";

    // Property for the number of AI players in the game
    public int AIPlayers { get; set; } = 0;

    // Property for the frames per second (FPS) setting of the game
    public int FPS { get; set; } = 60;

    // Property for the number of apples (food items) in the game
    public int AppleCount { get; set; } = 5;

    // Property for the multiplier effect of food on player growth
    public int FoodGrowMultiplier { get; set; } = 1;

    // Property for the difficulty setting of the game
    public string Difficulty { get; set; } = "Medium";

    // Static method to load game settings from a JSON file
    public static GameSettings Load()
    {
        // Check if the settings file exists
        if (File.Exists("gamesettings.json"))
        {
            // Read the JSON content from the file
            var json = File.ReadAllText("gamesettings.json");
            // Deserialize the JSON content to a GameSettings object
            return JsonSerializer.Deserialize<GameSettings>(json) ?? new GameSettings();
        }
        // Return a new GameSettings object with default values if the file does not exist
        return new GameSettings();
    }

    // Static method to save the current game settings to a JSON file
    public static void Save(GameSettings settings)
    {
        // Define JSON serialization options (e.g., pretty print)
        var options = new JsonSerializerOptions { WriteIndented = true };
        // Serialize the GameSettings object to JSON
        var json = JsonSerializer.Serialize(settings, options);
        // Write the JSON content to the settings file
        File.WriteAllText("gamesettings.json", json);
    }
}
