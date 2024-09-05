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
            var defenseStrategies = LoadDefenseStrategies("C:\\Users\\rozen\\source\\repos\\Week-10\\defenceStrategiesBalanced.json");

            foreach (var strategy in defenseStrategies)
            {
                bst.Insert(strategy.MinSeverity, strategy.MaxSeverity, strategy.Defenses);
            }

            bst.PreOrderTraversal(bst.Root);


            Console.ReadLine();

        }

        

        public static List<DefenseStrategy> LoadDefenseStrategies(string filePath)
        {
            var jsonString = File.ReadAllText(filePath);
            var defenseStrategies = JsonSerializer.Deserialize<List<DefenseStrategy>>(jsonString);
            return defenseStrategies;
        }

        public class DefenseStrategy
        {
            public int MinSeverity { get; set; }
            public int MaxSeverity { get; set; }
            public List<string> Defenses { get; set; }
        }
    }
}
