using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fluetax.Interfaces
{
    public interface IMethodConfiguration : IFluetaxConfiguration<IMethodBuilder, MethodDeclarationSyntax>
    {

    }
}
