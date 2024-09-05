using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_10
{
    public static class Services
    {
        public static int CalculateSeverity(int volume, int sophistication, TargetType target)
        {
            int targetValue = (int)target;

            return (volume * sophistication) + targetValue;
        }


        public static void ActivateDefenses(BSTNode node)
        {
            foreach (var defense in node.Defenses)
            {
                Console.WriteLine(defense);
                System.Threading.Thread.Sleep(2000); 
            }
        }
       
    }
}
