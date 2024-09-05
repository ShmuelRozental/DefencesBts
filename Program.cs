using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Week_10
{
    public class Program
    {


        static void Main(string[] args)
        {
            //1:
            DefenseStrategiesBST bst = new DefenseStrategiesBST();
            var defenseStrategies = LoadFromJson<DefenseStrategy>("C:\\Users\\rozen\\source\\repos\\Week-10\\defenceStrategiesBalanced.json");

            foreach (var strategy in defenseStrategies)
            {
                bst.Insert(strategy.MinSeverity, strategy.MaxSeverity, strategy.Defenses);
            }
            //2:
            bst.PreOrderTraversal(bst.Root);

            //3:
            var Threats = LoadFromJson<Threat>("C:\\Users\\rozen\\source\\repos\\Week-10\\threats.json")




            Console.ReadLine();

        }


        public interface IJsonLoadable
        {
            
        }


        public static List<T> LoadFromJson<T>(string filePath) where T : IJsonLoadable
        {
            var jsonString = File.ReadAllText(filePath);
            var objects = JsonSerializer.Deserialize<List<T>>(jsonString);
            return objects;
        }


        public class DefenseStrategy: IJsonLoadable
        {
            public int MinSeverity { get; set; }
            public int MaxSeverity { get; set; }
            public List<string> Defenses { get; set; }
        }

        public class Threat : IJsonLoadable
        {
            public int ThreatLevel { get; set; }
            public string Description { get; set; }
        }
    }
}
