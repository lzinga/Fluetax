# Fluetax
A C# Fluent control on the Roslyn syntax builder. This library is not in any kind of official state, there are things missing and probably breaking issues. However hopefully someone can find it useful or contribute to it in someway if the library is deemed convienent.

# Why?
I dabbled in learning source generators with latest .net releases and the current method to build a simple class seemed to be rather frustrating and messy looking. This project may be completely unnecessary, however I managed to learn a decent amount about source generators and the `Microsoft.CodeAnalysis` library.

# Example
```csharp
var b = new ClassBuilder("MyClass")
    .ConfigureProperties(properties =>
    {
        properties.Add<int>("MyProperty")
            .SetAccessor(SyntaxKind.GetAccessorDeclaration)
            .SetAccessor(SyntaxKind.SetAccessorDeclaration);
    })
    .ConfigureMethods(methods =>
    {
        methods.Add<Void>("MyMethod")
            .AddParameter<int>(SyntaxKind.PublicKeyword, "test")
            .AddParameter<string>(SyntaxKind.PublicKeyword, "MyName");
    })
    .Build();

    var t = b.NormalizeWhitespace();
```

When outputting the `t` variable from the code above the output is as follows - 
```csharp
public class MyClass
{
    public Int32 MyProperty { get; set; }

    public void MyMethod(Int32 test, String myname)
    {
        throw new NotImplementedException();
    }
}
```

I plan to add some other things into this library before making it an official package.
