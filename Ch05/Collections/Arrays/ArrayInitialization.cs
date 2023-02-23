namespace Arrays;

public static class ArrayInitialization
{
    public static void Laborious()
    {
        var workingWeekDayNames = new string[5];
        workingWeekDayNames[0] = "Monday";
        workingWeekDayNames[1] = "Tuesday";
        workingWeekDayNames[2] = "Wednesday";
        workingWeekDayNames[3] = "Thursday";
        workingWeekDayNames[4] = "Friday";
    }

    public static void CollectionExpressions()
    {
        string[] workingWeekDayNames =
            ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday"];

        string[] weekDayNames = ["Sunday", .. workingWeekDayNames, "Saturday"];

        Console.WriteLine(string.Join(", ", weekDayNames));
    }

    public static void InitializerExpression()
    {
        var workingWeekDayNames = new string[]
            { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
    }

#pragma warning disable IDE0300 // Simplify collection initialization - the following examples illustrate the older syntax, so we don't want to be told we can change these to collection expressions
    public static void ShorterInitializer()
    {
        string[] workingWeekDayNames =
            { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
    }

    public static void ElementTypeInference()
    {
        var workingWeekDayNames = new[]
            { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
    }

    public static void ArrayInitializerArgument()
    {
        SetHeaders(new[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" });
    }

    public static void JaggedCollectionExpression()
    {
        int[][] arrays =
        [
            [1, 2],
            [1, 2, 3, 4, 5, 6],
            [1, 2, 4],
            [1],
            [1, 2, 3, 4, 5]
        ];
    }

    public static void JaggedArrayInitializer()
    {
        var arrays = new int[5][]
        {
            new[] { 1, 2 },
            new[] { 1, 2, 3, 4, 5, 6 },
            new[] { 1, 2, 4 },
            new[] { 1 },
            new[] { 1, 2, 3, 4, 5 }
        };
    }

    public static void Rectangular()
    {
        int[,] grid = new int[5, 10];
        var smallerGrid = new int[,]
        {
                { 1, 2, 3, 4 },
                { 2, 3, 4, 5 },
                { 3, 4, 5, 6 },
        };

        var cuboid = new int[,,]
        {
                {
                    { 1, 2, 3, 4, 5 },
                    { 2, 3, 4, 5, 6 },
                    { 3, 4, 5, 6, 7 }
                },
                {
                    { 2, 3, 4, 5, 6 },
                    { 3, 4, 5, 6, 7 },
                    { 4, 5, 6, 7, 8 }
                },
        };
    }

    private static void SetHeaders(IEnumerable<string> v)
    {
    }
}
