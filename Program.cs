using System;
using System.Collections.Generic;
using Week_10.Services;
using Week_10.Clases;
using System.Threading;



namespace Week_10
{
    public class Program
    {
        static int actionDuration = 4000;
        static void Main(string[] args)
        {
            // 1. Initialize defense strategies
            DefenseStrategiesBST bst = new DefenseStrategiesBST();
            var defenseStrategies = JsonService.LoadFromJson<DefenseStrategy>("C:\\Users\\rozen\\source\\repos\\Week-10\\defenceStrategiesBalanced.json");

            foreach (var strategy in defenseStrategies)
            {
                bst.Insert(strategy.MinSeverity, strategy.MaxSeverity, strategy.Defenses);
            }

            Thread.Sleep(actionDuration);

            // 2. Pre-order traversal
            bst.PreOrderTraversal(bst.Root);

            Thread.Sleep(actionDuration);

            // 3. Load threats
            var threats = JsonService.LoadFromJson<Threat>("C:\\Users\\rozen\\source\\repos\\Week-10\\threats.json");

            Thread.Sleep(actionDuration);

            // 4. Process each threat
            foreach (var threat in threats)
            {
                try
                {
                    var targetType = threat.GetTargetType();
                    int severity = DefenseServices.CalculateSeverity(threat.Volume, threat.Sophistication, targetType);
                    Console.WriteLine($"Calculated severity: {severity}");

                    if (severity < bst.Min())
                    {
                        Console.WriteLine("Severity Attack below the threshold. Attack is ignored.");
                        continue; 
                    }

                    var node = bst.Search(severity);
                    if (node != null)
                    {
                        Console.WriteLine("Activating defenses...");
                        DefenseServices.ActivateDefenses(node);
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
    }
}
