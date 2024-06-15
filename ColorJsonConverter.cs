// File: ColorJsonConverter.cs
using System;
using System.Drawing;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace QuantumSerpent
{
    public class ColorJsonConverter : JsonConverter<Color>
    {
        // Liest einen Color-Wert aus JSON und konvertiert ihn von einem HTML-Farbstring.
        public override Color Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                // Lese den HTML-Farbstring aus JSON
                string colorString = reader.GetString();
                // Konvertiere den HTML-Farbstring in ein Color-Objekt
                return ColorTranslator.FromHtml(colorString);
            }
            // Fehler beim Lesen des JSON-Tokens
            throw new JsonException($"Unexpected token parsing color. Expected a string, got {reader.TokenType}.");
        }

        // Schreibt einen Color-Wert als HTML-Farbstring in JSON.
        public override void Write(Utf8JsonWriter writer, Color value, JsonSerializerOptions options)
        {
            // Konvertiere das Color-Objekt in einen HTML-Farbstring
            string colorString = ColorTranslator.ToHtml(value);
            // Schreibe den HTML-Farbstring in JSON
            writer.WriteStringValue(colorString);
        }
    }
}
