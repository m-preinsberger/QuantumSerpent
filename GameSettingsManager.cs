using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace QuantumSerpent
{
    // Defines a static class for managing game settings and highscores
    public static class GameSettingsManager
    {
        // Constants for the file paths of game settings and highscores
        private const string SettingsFilePath = "gamesettings.json";
        private const string HighscoresFilePath = "highscores.json";

        // Loads game settings from a JSON file, or returns default settings if the file doesn't exist
        public static GameSettings Load()
        {
            // Check if the settings file exists
            if (File.Exists(SettingsFilePath))
            {
                // Read the JSON content from the file
                var json = File.ReadAllText(SettingsFilePath);
                // Deserialize the JSON content into a GameSettings object, using custom options
                return JsonSerializer.Deserialize<GameSettings>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true, // Ignore case when matching property names
                    Converters = { new ColorJsonConverter() } // Use a custom converter for Color properties
                }) ?? new GameSettings(); // Return a new GameSettings object if deserialization returns null
            }
            // Return default settings if the file doesn't exist
            return new GameSettings();
        }

        // Saves the current game settings to a JSON file
        public static void Save(GameSettings settings)
        {
            // Define JSON serialization options, including indentation and a custom converter
            var options = new JsonSerializerOptions
            {
                WriteIndented = true, // Pretty print the JSON
                Converters = { new ColorJsonConverter() } // Use a custom converter for Color properties
            };
            // Serialize the GameSettings object to JSON
            var json = JsonSerializer.Serialize(settings, options);
            // Write the JSON content to the settings file
            File.WriteAllText(SettingsFilePath, json);
        }

        // Loads highscores from a JSON file, or returns an empty list if the file doesn't exist
        public static List<Highscore> LoadHighscores()
        {
            // Check if the highscores file exists
            if (File.Exists(HighscoresFilePath))
            {
                // Read the JSON content from the file
                var json = File.ReadAllText(HighscoresFilePath);
                // Deserialize the JSON content into a list of Highscore objects
                return JsonSerializer.Deserialize<List<Highscore>>(json) ?? new List<Highscore>(); // Return an empty list if deserialization returns null
            }
            // Return an empty list if the file doesn't exist
            return new List<Highscore>();
        }

        // Saves the current highscores to a JSON file, sorted by score in descending order
        public static void SaveHighscores(List<Highscore> highscores)
        {
            // Define JSON serialization options, including indentation
            var options = new JsonSerializerOptions { WriteIndented = true };
            // Serialize the list of Highscore objects to JSON, after sorting by score
            var json = JsonSerializer.Serialize(highscores.OrderByDescending(h => h.Score).ToList(), options);
            // Write the JSON content to the highscores file
            File.WriteAllText(HighscoresFilePath, json);
        }
    }


    // Defines a class for storing highscore data
    public class Highscore
    {
        // Properties for the player's name and score
        public string PlayerName { get; set; } = string.Empty; // Default to an empty string
        public int Score { get; set; } // The player's score
    }

    // Defines a class for storing game settings
    public class GameSettings
    {
        // Properties for player names, colors, and various game settings
        public string Player1Name { get; set; } = "Player 1"; // Default player 1 name
        public Color Player1HeadColor { get; set; } = Color.Green; // Default player 1 head color
        public Color Player1BodyColor { get; set; } = Color.DarkGreen; // Default player 1 body color
        public string Player2Name { get; set; } = "Player 2"; // Default player 2 name
        public Color Player2HeadColor { get; set; } = Color.Yellow; // Default player 2 head color
        public Color Player2BodyColor { get; set; } = Color.Orange; // Default player 2 body color
        public int InitialPlayerLength { get; set; } = 5; // Default initial player length
        public string CurrentMode { get; set; } = "Singleplayer"; // Default game mode
        public int AIPlayers { get; set; } = 0; // Default number of AI players
        public int FPS { get; set; } = 60; // Default frames per second
        public int AppleCount { get; set; } = 5; // Default number of apples
        public int FoodGrowMultiplier { get; set; } = 1; // Default food grow multiplier
        public string Difficulty { get; set; } = "medium"; // Default difficulty
        public bool IsFatSerpentMode { get; set; } = false; // Default fat serpent mode state
        public int FatSerpentTimeFrame { get; set; } = 0; // Default fat serpent time frame in seconds
    }

}
