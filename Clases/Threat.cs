using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Week_10.Program;

namespace Week_10
{
    public class Threat : IJsonLoadable
    {
        public string ThreatType { get; set; }
        public int Volume { get; set; }
        public int Sophistication { get; set; }
        public string Target { get; set; }

        public TargetType GetTargetType()
        {
            return Target switch
            {
                "Web Server" => TargetType.WebServer,
                "Database" => TargetType.Database,
                "User Credentials" => TargetType.UserCredentials,
                _ => throw new ArgumentException($"Invalid target type: {Target}")
            };
        }
    }
}
