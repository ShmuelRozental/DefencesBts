using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_10
{
    internal class BSTNode
    {
        public int MaxSeverity { get; set; }
        public int MinSeverity { get; set; }
        List<string> Defences { get; set; }
        public BSTNode Left { get; set; }
        public BSTNode Right { get; set; }
        public BSTNode(int minSeverity, int maxSeverity, List<string> defenses) 
        {
            MinSeverity = minSeverity;
            MaxSeverity = maxSeverity;
            Defences = defenses;
        }
    }
}
