using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;

namespace MarsRover.Tests;

public class Positioning
{
    /*
     * Same plateau for all tests
     */

    Plateau testPlateau = new Plateau(5, 4);
  
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Setting_MaxXY_In_Plateau()
    {
        testPlateau.MaxX.Should().Be(5);
        testPlateau.MaxY.Should().Be(4);
    }
     
    [Test]
    public void Setting_First_Rover_In_A_Valid_Position()
    {    
        Rover testRover = new Rover(testPlateau);

        testRover.PlaceInPosition(3, 1, 'N');
        testRover.CurrentPosition.X.Should().Be(3);
        testRover.CurrentPosition.Y.Should().Be(1);
        testRover.CurrentOrientation.O.Should().Be('N');
    }

    [Test]
    public void Setting_Second_Rover_In_A_Valid_Position()
    {
        Rover testRover = new Rover(testPlateau);

        testRover.PlaceInPosition(3, 0, 'S');
        testRover.CurrentPosition.X.Should().Be(3);
        testRover.CurrentPosition.Y.Should().Be(0);
        testRover.CurrentOrientation.O.Should().Be('S');
    }

    [Test]
    public void Setting_Rover_In_An_Invalid_Position_Due_To_Being_Occupied()
    {
        Rover testRover = new Rover(testPlateau);
        var ex = Assert.Throws<ArgumentException>(() => testRover.PlaceInPosition(3, 1, 'E'));
        Assert.That(ex.Message, Is.EqualTo("Position has a rover already!"));
    }
}