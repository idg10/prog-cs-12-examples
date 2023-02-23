static int SumSpan(ReadOnlySpan<int> span)
{
    int sum = 0;
    for (int i = 0; i < span.Length; ++i)
    {
        sum += span[i];
    }
    return sum;
}

int[] numberArray = [1, 2, 3];
Console.WriteLine(SumSpan(numberArray));

Console.WriteLine(SumSpan(new int[] { 1, 2, 3 }));

// Creates an array because one of the initializer values is not constant.
Console.WriteLine(SumSpan(new int[] { 1, 2, DateTime.Now.Hour }));

// Creates an array because we asked for a Span<int> (not readonly).
Span<int> numberSpan = new int[] { 1, 2, 3 };
Console.WriteLine(SumSpan(numberSpan));

#pragma warning disable IDE0302 // Simplify collection initialization - this example is to illustrate this syntax; a later example does what this diagnostic suggests
ReadOnlySpan<int> nonConstReadOnly = stackalloc int[] { 1, 2, DateTime.Now.Hour };
Console.WriteLine(SumSpan(nonConstReadOnly));

Span<int> constWriteable = stackalloc int[] { 1, 2, 3 };
Console.WriteLine(SumSpan(constWriteable));
#pragma warning restore IDE0302

// Lives on stack (because one of the values is not constant).
Console.WriteLine(SumSpan([1, 2, DateTime.Now.Hour]));

// Lives on stack (because using Span<int> means this must be writable).
Span<int> numbersCollectionExpression = [1, 2, DateTime.Now.Hour];
Console.WriteLine(SumSpan(numbersCollectionExpression));

// Pointer to constant data embedded in DLL.
Console.WriteLine(SumSpan([1, 2, 3]));

List<int> li = [1, 2, 3];
Console.WriteLine(SumSpan([..li]));

string uriString = "http://example.com/books/1323?edition=6&format=pdf";
int id = int.Parse(uriString.AsSpan(25, 4));

static void CheckStart(ReadOnlySpan<char> chars)
{
    if (chars is ['H', .. ReadOnlySpan<char> theRest])
    {
        Console.WriteLine(theRest.Length);
    }
}

CheckStart("Hello");
CheckStart("World");

static void RespondToGreeting(ReadOnlySpan<char> message)
{
    switch (message)
    {
        case "Hello":
            Console.WriteLine("Hello to you too");
            break;

        case "How do you do":
            Console.WriteLine("How do you do");
            break;
    }
}

RespondToGreeting("Hello");
RespondToGreeting("How do you do");