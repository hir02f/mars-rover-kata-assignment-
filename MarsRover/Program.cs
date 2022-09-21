using MarsRover;

UserInterface userInterface = new UserInterface();
MissionControl missionControl = new MissionControl();

// Plateau input
// -------------
Console.WriteLine("Please enter upper-right coordinates of the Plateau");
string plateauInput = Console.ReadLine();
string[] plateauInputArray = plateauInput.Split(' ');
List<int> validatedPlateauCoordinates = new List<int> {};

try
{
    userInterface.checkInputForPlateau(plateauInputArray, validatedPlateauCoordinates);    
    missionControl.SetPlateau(validatedPlateauCoordinates[0], validatedPlateauCoordinates[1]);    
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
    return;
}

// Rover input
// -----------
Console.WriteLine("Now enter the Rover's coordinates and orientation");
string roverInput = Console.ReadLine();
string[] roverInputArray = roverInput.Split(' ');

try
{
    userInterface.checkInputForRover(roverInputArray, missionControl.Plateau.MaxX, missionControl.Plateau.MaxY); 
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
    return;
}

