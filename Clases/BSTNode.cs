using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_10
{
    public class BSTNode
    {
        public int MaxSeverity { get; set; }
        public int MinSeverity { get; set; }
        public List<string> Defenses { get; set; }
        public BSTNode Left { get; set; }
        public BSTNode Right { get; set; }
        public BSTNode(int minSeverity, int maxSeverity, List<string> defenses) 
        {
            MinSeverity = minSeverity;
            MaxSeverity = maxSeverity;
            Defenses = defenses;
        }
    }
}
