using RubikCubeChallenge.Application;

HashSet<string> validCommands =
[
    "U", "U'", "D", "D'", "R", "R'", "L", "L'", "F", "F'", "B", "B'", "EXIT", "HELP", "RESET"
];

var rubikCube = new RubikCube();

Console.WriteLine("Rubik cube flat view:");
Console.WriteLine(rubikCube);
Console.Write("Enter a rubik cube's operation or sequal of operations: ");
var input = Console.ReadLine()
    ?.Trim()
    .ToUpper();
while (input != "EXIT")
{
    if (!string.IsNullOrEmpty(input)) 
    { 
        var commands = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        foreach (var command in commands)
        {
            if (validCommands.Contains(command))
            {
                ExecuteCommand(rubikCube, command);
            }
            else
            {
                Console.WriteLine($"Invalid command: {command}. Please try again.");
            }
        }
        Console.WriteLine(rubikCube.ToString(" "));
    }

    Console.Write("Enter another rubik cube's operation: ");
    input = Console.ReadLine()
        ?.Trim()
        .ToUpper();
}

static void ExecuteCommand(RubikCube rubikCube, string? command)
{
    switch (command)
    {
        case "U":
            rubikCube.MoveUp();
            break;
        case "U'":
            rubikCube.MoveUp(true);
            break;
        case "D":
            rubikCube.MoveDown();
            break;
        case "D'":
            rubikCube.MoveDown(true);
            break;
        case "R":
            rubikCube.MoveRight();
            break;
        case "R'":
            rubikCube.MoveRight(true);
            break;
        case "L":
            rubikCube.MoveLeft();
            break;
        case "L'":
            rubikCube.MoveLeft(true);
            break;
        case "F":
            rubikCube.MoveFront();
            break;
        case "F'":
            rubikCube.MoveFront(true);
            break;
        case "B":
            rubikCube.MoveBack();
            break;
        case "B'":
            rubikCube.MoveBack(true);
            break;

        case "HELP":
            Console.WriteLine("Valid commands: U, U', D, D', R, R', L, L', F, F', B, B', RESET, EXIT");
            break;

        case "RESET":
            rubikCube.Reset();
            break;

        default:
            Console.WriteLine("Invalid command.");
            break;
    }
}