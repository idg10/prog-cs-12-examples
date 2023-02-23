namespace ThreadAffinity;

public class Defer(Action callback)
{
    private readonly ExecutionContext? _context = ExecutionContext.Capture()!;

    public void Run()
    {
        if (_context is null) { callback(); return; }
        // When ExecutionContext.Run invokes the lambda we supply as the 2nd
        // argument, it passes that lambda the value we supplied as the 3rd
        // argument to Run. Here we're passing callback, so the lambda has
        // access to the Action we want to invoke. It would have been simpler
        // to write "_ => callback()", but the lambda would then need to
        // capture 'this' to be able to access callback, and that capture
        // would cause an additional allocation. Using the static keyword
        // on the lambda tells the compiler that we intend to avoid capture,
        // so it would report an error if we accidentally used any locals.
        ExecutionContext.Run(
            _context,
            static (cb) => ((Action)cb!)(),
            callback);
    }
}
