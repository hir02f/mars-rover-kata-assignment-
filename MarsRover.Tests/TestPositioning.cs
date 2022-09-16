using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;

namespace MarsRover.Tests;

public class Positioning
{

    Plateau testPlateau = new Plateau(5, 4);
    //Position testPosition = new Position(3, 1, 'N');

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Setting_MaxXY_In_Plateau()
    {
       // Plateau testPlateau = new Plateau(5,4);        
        testPlateau.MaxX.Should().Be(5);
        testPlateau.MaxY.Should().Be(4);
    }

    [Test]
    public void Setting_Rover_In_An_Invalid_Position_Due_To_XY()
    {
        Rover testRover = new Rover(testPlateau);

        var ex = Assert.Throws<ArgumentException>(() => testRover.PlaceInPosition(6, 1, 'N'));
        Assert.That(ex.Message, Is.EqualTo("Position is bigger than Plateau dimensions!"));

        ex = Assert.Throws<ArgumentException>(() => testRover.PlaceInPosition(6, -1, 'N'));
        Assert.That(ex.Message, Is.EqualTo("Position must be more than zero!"));
    }

    [Test]
    public void Setting_Rover_In_An_Invalid_Position_Due_To_Orientation()
    {
        Rover testRover = new Rover(testPlateau);

        var ex = Assert.Throws<ArgumentException>(() => testRover.PlaceInPosition(6, 1, 'K'));
        Assert.That(ex.Message, Is.EqualTo("Orentation must be N, E, S or W!"));
    }

    
    [Test]
    public void Setting_First_Rover_In_A_Valid_Position()
    {    
        Rover testRover = new Rover(testPlateau);

        testRover.PlaceInPosition(3, 1, 'N');
        testRover.CurrentPosition.X.Should().Be(3);
        testRover.CurrentPosition.Y.Should().Be(1);
        testRover.CurrentPosition.O.Should().Be('N');
    }

    [Test]
    public void Setting_Second_Rover_In_A_Valid_Position()
    {
        Rover testRover = new Rover(testPlateau);

        testRover.PlaceInPosition(3, 0, 'S');
        testRover.CurrentPosition.X.Should().Be(3);
        testRover.CurrentPosition.Y.Should().Be(0);
        testRover.CurrentPosition.O.Should().Be('S');
    }

    [Test]
    public void Setting_Rover_In_An_Invalid_Position_Due_To_Being_Occupied()
    {
        Rover testRover = new Rover(testPlateau);
        var ex = Assert.Throws<ArgumentException>(() => testRover.PlaceInPosition(3, 1, 'E'));
        Assert.That(ex.Message, Is.EqualTo("Position has a rover already!"));
    }
}