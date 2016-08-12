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
            ThenDirection.Should().Be(Direction.Up);
        }

        private void WhenMovingUp()
        {
            SomeElevator.MoveUp();
        }

        private void GivenAnElevator()
        {
            SomeElevator = new Elevator();
        }

        protected Elevator SomeElevator { get; set; }

        protected Direction? ThenDirection => SomeElevator.Direction;
    }
}