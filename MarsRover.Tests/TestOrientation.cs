using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;

namespace MarsRover.Tests;

public class Orientation
{

    Plateau testPlateau = new Plateau(5, 5);

    [Test]
    public void Setting_Second_Rover_In_A_Valid_Position()
    {
        Rover testRover = new Rover(testPlateau);

        testRover.PlaceInPosition(1, 2, 'N');
        testRover.CurrentPosition.X.Should().Be(1);
        testRover.CurrentPosition.Y.Should().Be(2);
       
        testRover.CurrentOrientation.O.Should().Be('N');
        testRover.CurrentOrientation.GetNewOrientation('L').Should().Be('W');

    }
}