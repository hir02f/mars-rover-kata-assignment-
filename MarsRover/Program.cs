using MarsRover;

// Plateau input
Console.WriteLine("Please enter upper-right coordinates of the Plateau");
string plateauInput = Console.ReadLine();
string[] plateauInputArray = plateauInput.Split(' ');
List<int> plateauCoordinates = new List<int> {};

try
{
    bool inputOK = new UserInterface().checkInputForPlateau(plateauInputArray, plateauCoordinates);
}
catch (System.ArgumentException e)
{
    Console.WriteLine(e.Message);
    return;
}
