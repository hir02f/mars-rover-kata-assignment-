using MarsRover;

UserInterface userInterface = new UserInterface();
MissionControl missionControl = new MissionControl();

/*
 * Plateau input
 * -------------
 */
Console.WriteLine("Please enter upper-right coordinates of the Plateau");
string plateauInput = Console.ReadLine();
string[] plateauInputArray = plateauInput.Split(' ');
List<int> validatedPlateauCoordinates = new List<int> {};

try
{
    userInterface.checkInputForPlateau(plateauInputArray, validatedPlateauCoordinates);    
    missionControl.SetPlateau(validatedPlateauCoordinates[0], validatedPlateauCoordinates[1]);
    Console.WriteLine("The Plateau is ready.");
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
    return;
}

/*
 * Rover input for position
 * ------------------------
 */
Console.WriteLine("Now enter the Rover's coordinates and orientation");
string roverInput = Console.ReadLine();
string[] roverInputArray = roverInput.Split(' ');
Console.WriteLine("The Rover is ready.");

try
{
    userInterface.checkInputForRover(roverInputArray, missionControl.Plateau.MaxX, missionControl.Plateau.MaxY);
    missionControl.SetRovers(int.Parse(roverInputArray[0]), int.Parse(roverInputArray[1]), Convert.ToChar(roverInputArray[2]));
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
    return;
}

/*
 * Rover input for movement
 * ------------------------
 */
Console.WriteLine("Now enter the Rover's movement instructions");
string roverMovement = Console.ReadLine();

try
{
    char[] instructions = userInterface.checkInputForMovement(roverMovement);
    missionControl.ManageRoverMoment(instructions);
    Console.Write("Rover is at position: " + missionControl.CurrentRover.CurrentPosition.X + " " + missionControl.CurrentRover.CurrentPosition.Y + " " + missionControl.CurrentRover.CurrentOrientation.O);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
    return;
}



