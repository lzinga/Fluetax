using Fluetax.Builders;
using Fluetax.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.CodeAnalysis.CSharp;
using System.Diagnostics;
using System;
using Microsoft.CodeAnalysis;

namespace Fluetax.Test
{
    [TestClass]
    public class ClassTests
    {
        [TestMethod]
        public void TestMethod1()
        {
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
            Assert.IsTrue(true);
        }
    }
}
