using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;

namespace MarsRover.Tests;

public class Positioning
{
    UserInterface userInterface = new UserInterface();
    MissionControl missionControl = new MissionControl();

    [SetUp]
    public void Setup()
    {
        // Set Plateau in Mission Control
        string plateauInput = "10 10";
        string[] plateauInputArray = plateauInput.Split(' ');
        List<int> validatedPlateauCoordinates = new List<int> { };
        userInterface.checkInputForPlateau(plateauInputArray, validatedPlateauCoordinates);
        missionControl.SetPlateau(validatedPlateauCoordinates[0], validatedPlateauCoordinates[1]);
    }

    [Test]
    public void Setting_MaxXY_In_Plateau()
    {
        Plateau testPlateau = new Plateau(5, 4);

        testPlateau.MaxX.Should().Be(5);
        testPlateau.MaxY.Should().Be(4);
    }
     
    [Test]
    public void Setting_First_Rover_In_A_Valid_Position_Using_Rover_Class()
    {
        Rover testRover = new Rover();

        testRover.PlaceInPosition(3, 1, 'N');
        testRover.CurrentPosition.X.Should().Be(3);
        testRover.CurrentPosition.Y.Should().Be(1);
        testRover.CurrentOrientation.O.Should().Be('N');
    }
    
    [Test]
    public void Setting_First_Rover_In_A_Valid_Position_Using_MissionControl()
    {
        string roverInput = "3 5 W";
        string[] roverInputArray = roverInput.Split(' ');

        userInterface.checkInputForRover(roverInputArray, missionControl.Plateau.MaxX, missionControl.Plateau.MaxY);
        missionControl.SetRovers(int.Parse(roverInputArray[0]), int.Parse(roverInputArray[1]), Convert.ToChar(roverInputArray[2]));
        missionControl.CurrentRover.CurrentPosition.X.Should().Be(3);
        missionControl.CurrentRover.CurrentPosition.Y.Should().Be(5);
        missionControl.CurrentRover.CurrentOrientation.O.Should().Be('W');
    }
    
    [Test]
    public void Setting_Second_Rover_In_A_Valid_Position()
    {
        string roverInput = "9 9 W";
        string[] roverInputArray = roverInput.Split(' ');
        userInterface.checkInputForRover(roverInputArray, missionControl.Plateau.MaxX, missionControl.Plateau.MaxY);
        missionControl.SetRovers(int.Parse(roverInputArray[0]), int.Parse(roverInputArray[1]), Convert.ToChar(roverInputArray[2]));

        string roverInput2 = "2 4 E";
        string[] roverInputArray2 = roverInput2.Split(' ');
        userInterface.checkInputForRover(roverInputArray2, missionControl.Plateau.MaxX, missionControl.Plateau.MaxY);
        missionControl.SetRovers(int.Parse(roverInputArray2[0]), int.Parse(roverInputArray2[1]), Convert.ToChar(roverInputArray2[2]));
        missionControl.CurrentRover.CurrentPosition.X.Should().Be(2);
        missionControl.CurrentRover.CurrentPosition.Y.Should().Be(4);
        missionControl.CurrentRover.CurrentOrientation.O.Should().Be('E'); 
    }
    
    [Test]
    public void Setting_Rover_In_An_Invalid_Position_Due_To_Being_Occupied()
    {
        string roverInput = "1 3 S";
        string[] roverInputArray = roverInput.Split(' ');
        userInterface.checkInputForRover(roverInputArray, missionControl.Plateau.MaxX, missionControl.Plateau.MaxY);
        missionControl.SetRovers(int.Parse(roverInputArray[0]), int.Parse(roverInputArray[1]), Convert.ToChar(roverInputArray[2]));

        string roverInput2 = "1 3 S";
        string[] roverInputArray2 = roverInput2.Split(' ');

        userInterface.checkInputForRover(roverInputArray2, missionControl.Plateau.MaxX, missionControl.Plateau.MaxY);

        var ex = Assert.Throws<ArgumentException>(() => missionControl.SetRovers(int.Parse(roverInputArray2[0]), int.Parse(roverInputArray2[1]), Convert.ToChar(roverInputArray2[2])));
        Assert.That(ex.Message, Is.EqualTo("Position has a rover already!"));
    }
}