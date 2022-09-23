# Mars Rover Kata


The brief of this project is set out in the file “Mars Rover Kata – The Brief.pdf”. Please read that document first.
## The Solution

- There is a Mission Control class which has knowledge of the Plateau and a list of rovers and their positions. In addition, it manages a current rover by putting it in position and controls its movement after doing checks.
- Mission Control is supported by other classes, their names indicate what they look after, eg Plateau knows its maximum coordinates.
- These said classes are: Plateau, Rover, Orientation, Position & Movement
- Initialy, functions are tested in TDD style, slowly building up to classes and how they interact together. The tests are explained below.
- Then a UserInterface class is introduced to manage input submitted by the user via a console application - the console code is in Program.cs


## How to use the Console

First type ```dotnet run``` and follow the instructions given.

## How to test

The tests are split into four areas of functionality:
- TestPositioning

- TestOrientation

- TestMovement

- TestUserInterface

To test each area individually, use:

- ```dotnet test --filter Positioning ``` 
- ```dotnet test --filter Orientation ``` 
- ```dotnet test --filter Movement ``` 
- ```dotnet test --filter TestUserInterface ``` 

Otherwise, use ```dotnet test``` to run all the test cases.

## Future Considerations
### Console
At the moment, the console does not output where empty positions are, nor does it allow for more than one movement instruction per rover. These can be enhanced by outputting where rovers are and ask Mission Control to swap which current rover it is working on.

### Plateau
The current plateau is a quadrilateral grid consisting of positive coordinates. To extend to support different shaped plateaus, in addition to just maximum coordinates, the Plateau class should also know out-of-bounds coordinates. For a circular shape, perhaps (0,0) could be the centre of the plateau, and the rover can move to negative coordinates too. Each movement can still be in steps of one, however coordinates outside the circle needs to be calculated and checked for.

### Rover
Rovers can be enhanced to have cameras, robot arms and storage areas. More classes need to be created for these purposes.
