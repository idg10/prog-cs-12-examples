using BasicCoding;

using System.Globalization;
using System.Text;

Variables.DeclarationsAndAssignments();
Variables.ImplicitVariableTypes();

Person[] people = [new Person("Peter", 12), new Person("Ian", 50)];

CompositeFormat nameAgeFormat = CompositeFormat.Parse(GetPersonFormat());

foreach (Person p in people)
{
    string message = string.Format(
        CultureInfo.InvariantCulture, nameAgeFormat, p.Name, p.Age);
    Console.WriteLine(message);
}

static string GetPersonFormat()
{
    // Typically we'd pick the string based on the locale. But any situation in
    // which we decide at runtime which composite format string to use makes
    // CompositeFormat relevant because we're unable to use string interpolation.
    return new Random().Next(0, 2) == 0 ? "{0} is {1} years old" : "{0} is {1} years of age";
}

public record Person(string Name, int Age);