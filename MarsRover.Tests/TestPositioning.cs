using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;

namespace MarsRover.Tests;

public class Positioning
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Setting_Max_XY_Using_Plateau()
    {
        Plateau testPlateau = new Plateau(5,4);
        testPlateau.MaxX.Should().Be(5);
        testPlateau.MaxY.Should().Be(4);
    }

    [Test]
    public void Setting_Max_XY_Using_Position()
    {    
        Position testPosition = new Position(3, 1);
        testPosition.MaxX.Should().Be(3);
        testPosition.MaxY.Should().Be(1);
}
}