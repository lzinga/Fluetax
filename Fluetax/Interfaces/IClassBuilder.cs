using Fluetax.Configurations;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fluetax.Interfaces
{
    public interface IClassBuilder : IDeclarationBuilder<ClassDeclarationSyntax>
    {
        IClassBuilder ConfigureProperties(Action<IPropertyConfiguration> properties);
        IClassBuilder ConfigureMethods(Action<IMethodConfiguration> methods);
    }
}
