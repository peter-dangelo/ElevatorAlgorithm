using System.Collections.Generic;
using System.Linq;

namespace ElevatorAlgorithm.Core
{
    public class Elevator
    {
        public Elevator()
        {
            CallRequests = new List<ElevatorCallRequest>();
        }

        public List<ElevatorCallRequest> CallRequests { get; set; }
        public Direction? CurrentDirection { get; set; }
        public bool IsIdle => CurrentDirection == null;

        public void Call(ElevatorCallRequest callRequest)
        {
            if(!CallRequests.Any(c => c.Floor == callRequest.Floor && c.Direction == callRequest.Direction))
                CallRequests.Add(callRequest);
        }

        public void MoveUp()
        {
            CurrentDirection = Direction.Up;
        }

        public void MoveDown()
        {
            CurrentDirection = Direction.Down;
        }
    }
}