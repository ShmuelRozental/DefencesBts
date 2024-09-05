using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Week_10.Program;

namespace Week_10.Clases
{

    public class DefenseStrategy : IJsonLoadable
    {
        public int MinSeverity { get; set; }
        public int MaxSeverity { get; set; }
        public List<string> Defenses { get; set; }
    }
}
