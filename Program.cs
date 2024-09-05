using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Week_10.Clases;

namespace Week_10
{
    public class Program
    {
        static void Main(string[] args)
        {
            // 1. Initialize defense strategies
            DefenseStrategiesBST bst = new DefenseStrategiesBST();
            var defenseStrategies = LoadFromJson<DefenseStrategy>("C:\\Users\\rozen\\source\\repos\\Week-10\\defenceStrategiesBalanced.json");

            foreach (var strategy in defenseStrategies)
            {
                bst.Insert(strategy.MinSeverity, strategy.MaxSeverity, strategy.Defenses);
            }

            // 2. Pre-order traversal
            bst.PreOrderTraversal(bst.Root);

            // 3. Load threats
            var threats = LoadFromJson<Threat>("C:\\Users\\rozen\\source\\repos\\Week-10\\threats.json");

            // 4. Process each threat
            foreach (var threat in threats)
            {
                try
                {
                    var targetType = threat.GetTargetType();
                    int severity = Services.CalculateSeverity(threat.Volume, threat.Sophistication, targetType);
                    Console.WriteLine($"Calculated severity: {severity}");

                    if (severity < bst.Min())
                    {
                        Console.WriteLine("Severity Attack below the threshold. Attack is ignored.");
                        continue; // Skip to the next threat
                    }

                    var node = bst.Search(severity);
                    if (node != null)
                    {
                        Console.WriteLine("Activating defenses...");
                        Services.ActivateDefenses(node);
                    }
                    else
                    {
                        Console.WriteLine("No suitable defense found. Brace for impact!");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public interface IJsonLoadable { }

        public static List<T> LoadFromJson<T>(string filePath) where T : IJsonLoadable
        {
            var options = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
            };
            var jsonString = File.ReadAllText(filePath);
            var objects = JsonSerializer.Deserialize<List<T>>(jsonString, options);
            return objects;
        }
    }
}
