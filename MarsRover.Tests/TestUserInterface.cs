using System.Diagnostics.Metrics;
using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;

namespace MarsRover.Tests
{
    public class TestUserInterface
    {
        UserInterface userInterface = new UserInterface();

        /*
         *  Plateau input tests
         *  ===================
         */

        [Test]
        public void Correct_Input_Should_Give_Plateau_Top_Right_Coordinates()
        {
            string plateauInput = "5 10";
            string[] plateauInputArray = plateauInput.Split(' ');
            List<int> validatedPlateauCoordinates = new List<int> { };
            userInterface.checkInputForPlateau(plateauInputArray, validatedPlateauCoordinates);
           
            MissionControl missionControl = new MissionControl();
            missionControl.SetPlateau(validatedPlateauCoordinates[0], validatedPlateauCoordinates[1]);
            missionControl.Plateau.MaxX.Should().Be(5);
            missionControl.Plateau.MaxY.Should().Be(10);
        }

        [Test]
        public void Null_Input()
        {
            string plateauInput = " 10";
            string[] plateauInputArray = plateauInput.Split(' ');
            List<int> validatedPlateauCoordinates = new List<int> { };

            var ex = Assert.Throws<FormatException>(() => userInterface.checkInputForPlateau(plateauInputArray, validatedPlateauCoordinates));
            Assert.That(ex.Message, Is.EqualTo("Input string was not in a correct format."));
        }

        [Test]
        public void More_Than_Two_Numbers_Given_For_Plateau()
        {
            string plateauInput = "1 2 3";
            string[] plateauInputArray = plateauInput.Split(' ');
            List<int> validatedPlateauCoordinates = new List<int> { };

            var ex = Assert.Throws<ArgumentException>(() => userInterface.checkInputForPlateau(plateauInputArray, validatedPlateauCoordinates));
            Assert.That(ex.Message, Is.EqualTo("Just enter two numbers followed by a space in between them!"));
        }

        [Test]
        public void Negative_Number_Given_For_Plateau()
        {
            string plateauInput = "-7 2";
            string[] plateauInputArray = plateauInput.Split(' ');
            List<int> validatedPlateauCoordinates = new List<int> { };

            var ex = Assert.Throws<ArgumentException>(() => userInterface.checkInputForPlateau(plateauInputArray, validatedPlateauCoordinates));
            Assert.That(ex.Message, Is.EqualTo("Plateau coordinates must be positive!"));
        }

        /*
         *  Rover input tests
         *  =================
         */

        [Test]
        public void Invalid_Orientation_Given()
        {
            string plateauInput = "3 2";
            string[] plateauInputArray = plateauInput.Split(' ');
            List<int> validatedPlateauCoordinates = new List<int> { };

            string roverInput = "1 3 Q";
            string[] roverInputArray = roverInput.Split(' ');

            var ex = Assert.Throws<ArgumentException>(() => userInterface.checkInputForRover(roverInputArray, 3, 2)); // hardcode plateau input
            Assert.That(ex.Message, Is.EqualTo("Orientation must be N, E, S or W!"));
        }

        [Test]
        public void Invalid_Rover_Position_Given()
        {
            string plateauInput = "3 2";
            string[] plateauInputArray = plateauInput.Split(' ');
            List<int> validatedPlateauCoordinates = new List<int> { };

            string roverInput = "1 -3 W";
            string[] roverInputArray = roverInput.Split(' ');

            var ex = Assert.Throws<ArgumentException>(() => userInterface.checkInputForRover(roverInputArray, 3, 2)); // hardcode plateau input
            Assert.That(ex.Message, Is.EqualTo("Position must be more than zero!"));
        }

        [Test]
        public void Rover_Input_Position_Not_In_Plateau()
        {
            string plateauInput = "2 2";
            string[] plateauInputArray = plateauInput.Split(' ');
            List<int> validatedPlateauCoordinates = new List<int> { };
            userInterface.checkInputForPlateau(plateauInputArray, validatedPlateauCoordinates);

            MissionControl missionControl = new MissionControl();
            missionControl.SetPlateau(validatedPlateauCoordinates[0], validatedPlateauCoordinates[1]);

            string roverInput = "3 5 W";
            string[] roverInputArray = roverInput.Split(' ');

            var ex = Assert.Throws<ArgumentException>(() => userInterface.checkInputForRover(roverInputArray, missionControl.Plateau.MaxX, missionControl.Plateau.MaxY));
            Assert.That(ex.Message, Is.EqualTo("Position given is not within Plateau dimensions!"));
        }

        /*
         *  Rover movement tests
         *  ====================
         */

        [Test]
        public void Invalid_Movement_Instructions_Given()
        {
            string roverInstructions = "LMMMK";

            var ex = Assert.Throws<ArgumentException>(() => userInterface.checkInputForMovement(roverInstructions));
            Assert.That(ex.Message, Is.EqualTo("Movment must be either L, R or M!"));
        }

        [Test]
        public void Movement_Instructions_Given_Is_Null_Or_Empty()
        {
            string roverInstructions = "";

            var ex = Assert.Throws<ArgumentException>(() => userInterface.checkInputForMovement(roverInstructions));
            Assert.That(ex.Message, Is.EqualTo("Enter valid movement instructions!"));
        }  
    }
}
