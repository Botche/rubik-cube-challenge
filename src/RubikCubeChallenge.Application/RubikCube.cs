namespace RubikCubeChallenge.Application;

using System.Text;

public class RubikCube : IRubikCube
{
    private const int ShiftBy = 3;
    private const int CubeCols = 12;

    private char[][] Instance2D;

    public RubikCube()
    {
        Instance2D = InitializeRubikCubeState();
    }

    public void MoveFront(bool isInverted = false)
    {
        var frontCenter = new Edge(4, 4);
        RotateSide(frontCenter, isInverted);
        RotateEdgeRing(FrontEdges, isInverted);
    }

    public void MoveBack(bool isInverted = false)
    {
        var backCenter = new Edge(4, 10);
        RotateSide(backCenter, isInverted);
        RotateEdgeRing(BackEdges, !isInverted);
    }

    public void MoveRight(bool isInverted = false)
    {
        var rightCenter = new Edge(4, 7);
        RotateSide(rightCenter, isInverted);
        RotateEdgeRing(RightEdges, !isInverted);
    }


    public void MoveLeft(bool isInverted = false)
    {
        var leftCenter = new Edge(4, 1);
        RotateSide(leftCenter, isInverted);
        RotateEdgeRing(LeftEdges, isInverted);
    }

    public void MoveUp(bool isInverted = false)
    {
        var upCenter = new Edge(1, 4);
        RotateSide(upCenter, isInverted);
        RotateEdgeRing(UpEdges, !isInverted);
    }

    public void MoveDown(bool isInverted = false)
    {
        var downCenter = new Edge(7, 4);
        RotateSide(downCenter, isInverted);
        RotateEdgeRing(DownEdges, isInverted);
    }

    public void Reset()
    {
        Instance2D = InitializeRubikCubeState();
    }

    public override string ToString()
    {
        var builder = new StringBuilder();

        for (int row = 0; row < Instance2D.GetLength(0); row++)
        {
            builder.AppendLine(string.Join(' ', Instance2D[row]));
        }

        return builder.ToString();
    }

    private void RotateEdgeRing(List<Edge> positions, bool isClockwise)
    {
        var values = positions
            .Select(pos => Instance2D[pos.Row][pos.Col])
            .ToArray();

        // Clockwise means shifting right (same order)
        // Counter-clockwise means shifting left (reverse rotation)
        var shift = isClockwise
            ? ShiftBy
            : CubeCols - ShiftBy;
        var rotated = RotateRing(values, shift);

        for (int i = 0; i < positions.Count; i++)
        {
            var (row, col) = positions[i];
            Instance2D[row][col] = rotated[i];
        }
    }

    private static char[] RotateRing(char[] ring, int shift)
    {
        var result = new char[ring.Length];
        for (int i = 0; i < ring.Length; i++)
        {
            result[i] = ring[(i + shift) % ring.Length];
        }
        return result;
    }

    private void RotateSide(Edge center, bool isInverted)
    {
        var face = new char[3, 3];

        // Populate face matrix with the colors around the center from Instance2D
        for (int row = 0; row < face.GetLength(0); row++)
        {
            for (int col = 0; col < face.GetLength(1); col++)
            {
                face[row, col] = Instance2D[center.Row - 1 + row][center.Col - 1 + col];
            }
        }

        var rotated = RotateMatrix(face, isInverted);

        // Apply the rotated colors around the center in Instance2D
        for (int row = 0; row < face.GetLength(0); row++)
        {
            for (int col = 0; col < face.GetLength(1); col++)
            {
                Instance2D[center.Row - 1 + row][center.Col - 1 + col] = rotated[row, col];
            }
        }
    }

    private static char[,] RotateMatrix(char[,] face, bool isInverted)
    {
        var rotated = new char[3, 3];

        for (int row = 0; row < face.GetLength(0); row++)
        {
            for (int col = 0; col < face.GetLength(1); col++)
            {
                // Rotate CounterClockwise
                if (isInverted)
                {
                    rotated[2 - col, row] = face[row, col];
                }
                // Rotate Clockwise
                else
                {
                    rotated[col, 2 - row] = face[row, col];
                }
            }
        }

        return rotated;
    }

    private static char[][] InitializeRubikCubeState()
    {
        char[][] state2d =
        [
            [' ', ' ', ' ', 'W', 'W', 'W', ' ', ' ', ' ', ' ', ' ', ' '],
            [' ', ' ', ' ', 'W', 'W', 'W', ' ', ' ', ' ', ' ', ' ', ' '],
            [' ', ' ', ' ', 'W', 'W', 'W', ' ', ' ', ' ', ' ', ' ', ' '],
            ['O', 'O', 'O', 'G', 'G', 'G', 'R', 'R', 'R', 'B', 'B', 'B'],
            ['O', 'O', 'O', 'G', 'G', 'G', 'R', 'R', 'R', 'B', 'B', 'B'],
            ['O', 'O', 'O', 'G', 'G', 'G', 'R', 'R', 'R', 'B', 'B', 'B'],
            [' ', ' ', ' ', 'Y', 'Y', 'Y', ' ', ' ', ' ', ' ', ' ', ' '],
            [' ', ' ', ' ', 'Y', 'Y', 'Y', ' ', ' ', ' ', ' ', ' ', ' '],
            [' ', ' ', ' ', 'Y', 'Y', 'Y', ' ', ' ', ' ', ' ', ' ', ' ']
        ];

        return DeepCopy(state2d);
    }

    private static char[][] DeepCopy(char[][] source)
    {
        return source.Select(row => row.ToArray()).ToArray();
    }

    private static readonly List<Edge> FrontEdges =
        [
            new(2, 3), new(2, 4), new(2, 5),     // Top face (bottom col)
            new(3, 6), new(4, 6), new(5, 6),     // Right face (left col)
            new(6, 5), new(6, 4), new(6, 3),     // Bottom face (top col)
            new(5, 2), new(4, 2), new(3, 2),     // Left face (right col)
        ];

    private static readonly List<Edge> BackEdges =
    [
            new(0, 3), new(0, 4), new(0, 5),     // Top face (top col)
            new(3, 8), new(4, 8), new(5, 8),     // Right face (right col)
            new(8, 5), new(8, 4), new(8, 3),     // Bottom face (bottom col)
            new(5, 0), new(4, 0), new(3, 0),     // Left face (left col)
        ];

    private static readonly List<Edge> RightEdges =
        [
            new(0, 5), new(1, 5), new(2, 5),     // Top face (right col)
            new(3, 5), new(4, 5), new(5, 5),     // Front face (right col)
            new(6, 5), new(7, 5), new(8, 5),     // Bottom face (right col)
            new(5, 9), new(4, 9), new(3, 9),     // Back face (left col, reversed)
        ];

    private static readonly List<Edge> LeftEdges =
        [
            new(0, 3), new(1, 3), new(2, 3),     // Top face (left col)
            new(3, 3), new(4, 3), new(5, 3),     // Front face (left col)
            new(6, 3), new(7, 3), new(8, 3),     // Bottom face (left col)
            new(5,11), new(4,11), new(3,11),     // Back face (right col, reversed)
        ];

    private static readonly List<Edge> UpEdges =
        [
            new(3, 0), new(3, 1), new(3, 2),     // Left
            new(3, 3), new(3, 4), new(3, 5),     // Front
            new(3, 6), new(3, 7), new(3, 8),     // Right
            new(3, 9), new(3, 10), new(3, 11),   // Back
        ];

    private static readonly List<Edge> DownEdges =
        [
            new(5, 0), new(5, 1), new(5, 2),     // Left
            new(5, 3), new(5, 4), new(5, 5),     // Front
            new(5, 6), new(5, 7), new(5, 8),     // Right
            new(5, 9), new(5, 10), new(5, 11),   // Back
        ];
}
