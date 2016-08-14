using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace ElevatorAlgorithm.Core.Test
{
    [TestFixture]
    public class ElevatorTest
    {
        [SetUp]
        public void Setup()
        {
            GivenAnElevator();
        }

        [Test]
        public void Elevator_Should_Go_Up()
        {
            WhenMovingUp();
            ThenCurrentDirection.Should().Be(Direction.Up);
        }

        [Test]
        public void Elevator_Should_Go_Down()
        {
            WhenMovingDown();
            ThenCurrentDirection.Should().Be(Direction.Down);
        }

        [Test]
        public void Should_Add_Call_Request_If_Does_Not_Exist()
        {
            GivenAnElevatorCallRequest();
            WhenAddingCallRequest(SomeElevatorCallRequest);
            ThenCallRequestIsAdded(SomeElevatorCallRequest);
        }

        [Test]
        public void Should_Only_Add_Call_Request_If_Does_Not_Already_Exist()
        {
            GivenAnElevatorCallRequest();
            WhenAddingCallRequest(SomeElevatorCallRequest);
            WhenAddingCallRequest(SomeElevatorCallRequest);
            ThenCallRequestIsAdded(SomeElevatorCallRequest);
        }

        [Test]
        public void Should_Add_Multiple_Different_Call_Requests()
        {
            GivenAnElevatorCallRequest();
            GivenAnotherElevatorCallRequest();
            WhenAddingCallRequest(SomeElevatorCallRequest);
            WhenAddingCallRequest(OtherElevatorCallRequest);
            ThenCallRequestIsAdded(SomeElevatorCallRequest);
            ThenCallRequestIsAdded(OtherElevatorCallRequest);
        }

        private void ThenCallRequestIsAdded(ElevatorCallRequest callRequest)
        {
            SomeElevator.CallRequests.Should().Contain(r => r.Floor == callRequest.Floor && r.Direction == callRequest.Direction);
            SomeElevator.CallRequests.Count(r => r.Floor == callRequest.Floor && r.Direction == callRequest.Direction).Should().Be(1);
        }

        private void WhenAddingCallRequest(ElevatorCallRequest callRequest)
        {
            SomeElevator.Call(callRequest);
        }

        private void GivenAnElevatorCallRequest()
        {
            SomeElevatorCallRequest = new ElevatorCallRequest
            {
                Floor = SomeFloor,
                Direction = SomeDirection
            };
        }

        private void GivenAnotherElevatorCallRequest()
        {
            OtherElevatorCallRequest = new ElevatorCallRequest
            {
                Floor = OtherFloor,
                Direction = OtherDirection
            };
        }

        private void WhenMovingDown()
        {
            SomeElevator.MoveDown();
        }

        private void WhenMovingUp()
        {
            SomeElevator.MoveUp();
        }

        private void GivenAnElevator()
        {
            SomeElevator = new Elevator();
        }


        private const int SomeFloor = 2;
        private const int OtherFloor = 4;
        private const Direction SomeDirection = Direction.Up;
        private const Direction OtherDirection = Direction.Down;
        protected Elevator SomeElevator { get; set; }

        protected Direction? ThenCurrentDirection => SomeElevator.CurrentDirection;
        protected ElevatorCallRequest SomeElevatorCallRequest { get; set; }
        protected ElevatorCallRequest OtherElevatorCallRequest { get; set; }
    }
}