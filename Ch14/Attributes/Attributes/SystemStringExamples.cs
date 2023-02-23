using System.Runtime.CompilerServices;

namespace Attributes
{
    public static class SystemStringExamples
    {
        public static class BeforeCs11
        {
            // See https://github.com/dotnet/runtime/blob/a68ab4a50f9167795d469d5cefacb7de4b5c2da7/src/libraries/System.Private.CoreLib/src/System/String.cs#L331
            // for the pre-C#11.0 code in the runtime libraries that this is based on.
            public static string Create(
                IFormatProvider? provider,
                [InterpolatedStringHandlerArgument("provider")]
                ref DefaultInterpolatedStringHandler handler)
            {
                // We're just illustrating the method signature, so theres nothing to do here.
                _ = provider; _ = handler; // Prevent compiler warnings
                return string.Empty;
            }
        }

        public static class AfterCs11
        {
            // See https://github.com/dotnet/runtime/blob/main/src/libraries/System.Private.CoreLib/src/System/String.cs#L348
            // for the real code in the runtime libraries that this is based on.
            public static string Create(
                IFormatProvider? provider,
                [InterpolatedStringHandlerArgument(nameof(provider))]
            ref DefaultInterpolatedStringHandler handler)
            {
                // We're just illustrating the method signature, so theres nothing to do here.
                _ = provider; _ = handler; // Prevent compiler warnings
                return string.Empty;
            }
        }
    }
}
