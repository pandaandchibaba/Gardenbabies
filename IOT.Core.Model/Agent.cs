using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Model
{
    /// <summary>
    /// 代理商
    /// </summary>
    public class Agent
    {
        public int AgentId { get; set; }
        public string AgentName { get; set; }
        public string BackgroudColor { get; set; }
        public string Icon { get; set; }
        public string BCImg { get; set; }
        public string Fans { get; set; }
        public int Consume { get; set; }
        public double Money { get; set; }
        public string NFans { get; set; }
        public double Two { get; set; }
        public double Three { get; set; }
        public double One { get; set; }
        public string Explaina { get; set; }
        public int AgentState { get; set; }
    }
}
