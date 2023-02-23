namespace StandardOperators;

public static class Filtering
{
    public static void WhereWithIndex()
    {
        IEnumerable<Course> q = Course.Catalog.Where(
            (course, index) => (index % 2 == 0) && course.Duration.TotalHours >= 3);
    }

    public static void ShowAllStrings(IEnumerable<object> src)
    {
        foreach (string s in src.OfType<string>())
        {
            Console.WriteLine(s);
        }
    }

    public static void DistinctOperator()
    {
        IEnumerable<string> categories =
            Course.Catalog.Select(c => c.Category).Distinct();
    }
}