// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

// The C# diagnostics suggested using an empty collection expression to initialize dictionaries.
// This doesn't work in the general case - the collection expression doesn't have any support for
// key/value initialization in C# 12. So It looks inconsistent to me to use this syntax to
// initialize an empty dictionary. I don't want to disable IDE0028 for the whole project because
// in most cases I like the suggestions it makes. And if a future version of C# augments the
// collection expression syntax to support dictionaries, this particular instance would make
// more sense to me, but for now, I want to keep using new() in these examples.
[assembly: SuppressMessage("Style", "IDE0028:Simplify collection initialization", Justification = "<Pending>", Scope = "member", Target = "~F:Dictionaries.UserCache._cachedUserInfo")]
[assembly: SuppressMessage("Style", "IDE0028:Simplify collection initialization", Justification = "<Pending>", Scope = "member", Target = "~F:Dictionaries.AnotherCache._cachedUserInfo")]
