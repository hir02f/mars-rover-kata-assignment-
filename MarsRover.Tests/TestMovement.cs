using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;

namespace MarsRover.Tests
{
    public class Movement
    {
        Plateau testPlateau = new Plateau(5, 5);        

        [Test]
        public void Moving_LMLMLMLMM()
        {           
            Rover testRover = new Rover(testPlateau);

            // Initial position and orientation
            testRover.PlaceInPosition(1, 2, 'N');
            testRover.CurrentPosition.X.Should().Be(1);
            testRover.CurrentPosition.Y.Should().Be(2);
            testRover.CurrentOrientation.O.Should().Be('N'); // Current Orientation

            // L
            testRover.CurrentOrientation.GetNewOrientation('L');
            testRover.CurrentOrientation.O.Should().Be('W'); // New Orientation
           
            // M
            testRover.MoveToNewPosition();
            testRover.CurrentPosition.X.Should().Be(0);      // New position
            testRover.CurrentPosition.Y.Should().Be(2);      // New position
            testRover.CurrentOrientation.O.Should().Be('W'); // Same Orientation

            // L
            testRover.CurrentOrientation.GetNewOrientation('L');
            testRover.CurrentOrientation.O.Should().Be('S'); // New Orientation

            // M
            testRover.MoveToNewPosition();
            testRover.CurrentPosition.X.Should().Be(0);      // New position
            testRover.CurrentPosition.Y.Should().Be(1);      // New position
            testRover.CurrentOrientation.O.Should().Be('S'); // Same Orientation

            // L
            testRover.CurrentOrientation.GetNewOrientation('L');
            testRover.CurrentOrientation.O.Should().Be('E'); // New Orientation

            // M
            testRover.MoveToNewPosition();
            testRover.CurrentPosition.X.Should().Be(1);      // New position
            testRover.CurrentPosition.Y.Should().Be(1);      // New position
            testRover.CurrentOrientation.O.Should().Be('E'); // Same Orientation

            // L
            testRover.CurrentOrientation.GetNewOrientation('L');
            testRover.CurrentOrientation.O.Should().Be('N'); // New Orientation

            // M
            testRover.MoveToNewPosition();
            testRover.CurrentPosition.X.Should().Be(1);      // New position
            testRover.CurrentPosition.Y.Should().Be(2);      // New position
            testRover.CurrentOrientation.O.Should().Be('N'); // Same Orientation

            // M
            testRover.MoveToNewPosition();
            testRover.CurrentPosition.X.Should().Be(1);      // New position
            testRover.CurrentPosition.Y.Should().Be(3);      // New position
            testRover.CurrentOrientation.O.Should().Be('N'); // Same Orientation                                                             
        }        
    }
}
