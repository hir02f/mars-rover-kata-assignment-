using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;

namespace MarsRover.Tests;

public class Orientation
{

    Plateau testPlateau = new Plateau(5, 5);

    [Test]
    public void Change_Rover_Orientation()
    {
        Rover testRover = new Rover(testPlateau);

        testRover.PlaceInPosition(1, 2, 'N');
        testRover.CurrentPosition.X.Should().Be(1);
        testRover.CurrentPosition.Y.Should().Be(2);
       
        testRover.CurrentOrientation.O.Should().Be('N');
        testRover.CurrentOrientation.GetNewOrientation('L').Should().Be('W');

    }
    [Test]
    public void Invalid_Change_Of_Rover_Orientation()
    {
        Rover testRover = new Rover(testPlateau);

        testRover.PlaceInPosition(1, 0, 'N');
        testRover.CurrentPosition.X.Should().Be(1);
        testRover.CurrentPosition.Y.Should().Be(0);

        testRover.CurrentOrientation.O.Should().Be('N');
        var ex = Assert.Throws<ArgumentException>(() => testRover.CurrentOrientation.GetNewOrientation('N'));
        Assert.That(ex.Message, Is.EqualTo("Invalid orientation movement!"));     
    }
}