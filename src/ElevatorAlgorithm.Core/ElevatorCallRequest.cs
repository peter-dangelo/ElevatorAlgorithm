using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElevatorAlgorithm.Core
{
    public class ElevatorCallRequest
    {
        public int Floor { get; set; }
        public Direction Direction { get; set; }
    }
}
