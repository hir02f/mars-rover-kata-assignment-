using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;

namespace MarsRover.Tests
{
    public class Movement
    {
        UserInterface userInterface = new UserInterface();
        MissionControl missionControl = new MissionControl();

        [SetUp]
        public void Setup()
        {
            // Set Plateau in Mission Control
            string plateauInput = "5 5";
            string[] plateauInputArray = plateauInput.Split(' ');
            List<int> validatedPlateauCoordinates = new List<int> { };
            userInterface.checkInputForPlateau(plateauInputArray, validatedPlateauCoordinates);
            missionControl.SetPlateau(validatedPlateauCoordinates[0], validatedPlateauCoordinates[1]);
        }

        [Test]
        public void Moving_LMLMLMLMM()
        {
            // Initial position and orientation
            string roverInput = "1 2 N";
            string[] roverInputArray = roverInput.Split(' ');
            userInterface.checkInputForRover(roverInputArray, missionControl.Plateau.MaxX, missionControl.Plateau.MaxY);
            missionControl.SetRovers(int.Parse(roverInputArray[0]), int.Parse(roverInputArray[1]), Convert.ToChar(roverInputArray[2]));
            missionControl.CurrentRover.CurrentPosition.X.Should().Be(1);
            missionControl.CurrentRover.CurrentPosition.Y.Should().Be(2);
            missionControl.CurrentRover.CurrentOrientation.O.Should().Be('N'); // Current Orientation

            // Movement Instructions
            char[] movementInstructions = new char[] { 'L', 'M', 'L', 'M', 'L', 'M', 'L', 'M', 'M'};
            missionControl.ManageRoverMoment(movementInstructions);
            missionControl.CurrentRover.CurrentPosition.X.Should().Be(1);      
            missionControl.CurrentRover.CurrentPosition.Y.Should().Be(3);      
            missionControl.CurrentRover.CurrentOrientation.O.Should().Be('N');                                                      
        }

        [Test]
        public void Moving_MMRMMRMRRM()
        {
            // Initial position and orientation
            string roverInput = "3 3 E";
            string[] roverInputArray = roverInput.Split(' ');
            userInterface.checkInputForRover(roverInputArray, missionControl.Plateau.MaxX, missionControl.Plateau.MaxY);
            missionControl.SetRovers(int.Parse(roverInputArray[0]), int.Parse(roverInputArray[1]), Convert.ToChar(roverInputArray[2]));

            // Movement Instructions
            char[] movementInstructions = new char[] { 'M', 'M', 'R', 'M', 'M', 'R', 'M', 'R', 'R', 'M' };
            missionControl.ManageRoverMoment(movementInstructions);
            missionControl.CurrentRover.CurrentPosition.X.Should().Be(5);
            missionControl.CurrentRover.CurrentPosition.Y.Should().Be(1);
            missionControl.CurrentRover.CurrentOrientation.O.Should().Be('E');
        }

        [Test]
        public void Moving_To_A_Coordinate_That_Has_A_Rover() // (1,3) has a rover from above test so can't move to it
        {
            // Initial position and orientation
            string roverInput = "1 2 N";
            string[] roverInputArray = roverInput.Split(' ');
            userInterface.checkInputForRover(roverInputArray, missionControl.Plateau.MaxX, missionControl.Plateau.MaxY);
            missionControl.SetRovers(int.Parse(roverInputArray[0]), int.Parse(roverInputArray[1]), Convert.ToChar(roverInputArray[2]));

            // Movement Instructions
            char[] movementInstructions = new char[] { 'M' };
            var ex = Assert.Throws<ArgumentException>(() => missionControl.ManageRoverMoment(movementInstructions));
            Assert.That(ex.Message, Is.EqualTo("Position (1, 3) has a rover already!"));
        }

        [Test]
        public void Moving_To_A_Coordinate_Outside_Plateau_Area() // Cannot move to (1, 6) as Plateu is 5 5
        {
            // Initial position and orientation
            string roverInput = "1 5 N";
            string[] roverInputArray = roverInput.Split(' ');
            userInterface.checkInputForRover(roverInputArray, missionControl.Plateau.MaxX, missionControl.Plateau.MaxY);
            missionControl.SetRovers(int.Parse(roverInputArray[0]), int.Parse(roverInputArray[1]), Convert.ToChar(roverInputArray[2]));
        
            // Movement Instructions
            char[] movementInstructions = new char[] { 'M' };
            var ex = Assert.Throws<ArgumentException>(() => missionControl.ManageRoverMoment(movementInstructions));
            Assert.That(ex.Message, Is.EqualTo("Rover cannot move outside Plateau area!"));
        }

        [Test]
        public void Moving_To_A_Negative_Coordinate_X() 
        {
            // Initial position and orientation
            string roverInput = "0 0 W";
            string[] roverInputArray = roverInput.Split(' ');
            userInterface.checkInputForRover(roverInputArray, missionControl.Plateau.MaxX, missionControl.Plateau.MaxY);
            missionControl.SetRovers(int.Parse(roverInputArray[0]), int.Parse(roverInputArray[1]), Convert.ToChar(roverInputArray[2]));

            // Movement Instructions
            char[] movementInstructions = new char[] { 'M' };
            var ex = Assert.Throws<ArgumentException>(() => missionControl.ManageRoverMoment(movementInstructions));
            Assert.That(ex.Message, Is.EqualTo("Rover cannot move to negative coordinates!"));
        }

        [Test]
        public void Moving_To_A_Negative_Coordinate_Y()
        {
            // Initial position and orientation
            string roverInput = "5 0 S";
            string[] roverInputArray = roverInput.Split(' ');
            userInterface.checkInputForRover(roverInputArray, missionControl.Plateau.MaxX, missionControl.Plateau.MaxY);
            missionControl.SetRovers(int.Parse(roverInputArray[0]), int.Parse(roverInputArray[1]), Convert.ToChar(roverInputArray[2]));

            // Movement Instructions
            char[] movementInstructions = new char[] { 'M' };
            var ex = Assert.Throws<ArgumentException>(() => missionControl.ManageRoverMoment(movementInstructions));
            Assert.That(ex.Message, Is.EqualTo("Rover cannot move to negative coordinates!"));
        }
    }
}
