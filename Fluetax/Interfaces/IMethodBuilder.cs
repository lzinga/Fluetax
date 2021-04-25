using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fluetax.Interfaces
{
    public interface IMethodBuilder
    {
        IMethodBuilder AddParameter<T>(SyntaxKind kind, string name);
        void AddBody(BlockSyntax body);
        IMethodBuilder SetModifier(SyntaxKind kind);

    }
}
