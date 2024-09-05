using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.IO;


using System.Threading.Tasks;

namespace Week_10
{
    public static class DefenseServices
    {
        static int DefenseDuration = 2000;

        //O(1) 
        public static int CalculateSeverity(int volume, int sophistication, TargetType target)
        {
            int targetValue = (int)target;

            return (volume * sophistication) + targetValue;
        }

        // O(d)
        public static void ActivateDefenses(BSTNode node)
        {
            foreach (var defense in node.Defenses)
            {
                Console.WriteLine(defense);
                System.Threading.Thread.Sleep(DefenseDuration); 
            }
        }
    }
}
