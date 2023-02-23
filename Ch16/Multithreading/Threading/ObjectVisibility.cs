using System.Text;

namespace Threading;

internal class ObjectVisibility
{
    public static string FormatDictionary<TKey, TValue>(
        IDictionary<TKey, TValue> input)
    {
        var sb = new StringBuilder();
        foreach ((TKey key, TValue value) in input)
        {
            sb.Append($"{key}: {value}");
            sb.AppendLine();
        }

        return sb.ToString();
    }
}
