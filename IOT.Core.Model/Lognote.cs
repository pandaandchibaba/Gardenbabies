using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Model
{
    public class Lognote
    {
        public int Lid { get; set; }
        public string Operation { get; set; }
        public DateTime Operationtime { get; set; }
        public string TableName { get; set; }
    }
}
