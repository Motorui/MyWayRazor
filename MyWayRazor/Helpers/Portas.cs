using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWayRazor.Helpers
{
    public class Portas
    {
        public class PortasT1SR
        {
            public string Num { get; set; }
        }

        protected static List<PortasT1SR> portasT1SRs = new List<PortasT1SR>
        {
            new PortasT1SR {Num = "08"},
            new PortasT1SR {Num = "08A"},
            new PortasT1SR {Num = "08B"},
            new PortasT1SR {Num = "09"},
            new PortasT1SR {Num = "10"},
            new PortasT1SR {Num = "11"},
            new PortasT1SR {Num = "12"},
            new PortasT1SR {Num = "13"},
            new PortasT1SR {Num = "18"},
            new PortasT1SR {Num = "18A"},
            new PortasT1SR {Num = "19"},
            new PortasT1SR {Num = "20"},
            new PortasT1SR {Num = "21"}
        };

        //        readonly IList<string> PortasT1SR = new List<string>() {
        //    "08", "08A", "08B", "09", "10", "11", "12", "13",
        //    "18", "18A", "19", "20", "21"
        //};
    }
}
