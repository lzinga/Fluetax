using Fluetax.Builders;
using Fluetax.Interfaces;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fluetax.Configurations
{
    internal class MethodConfiguration : IMethodConfiguration
    {
        private List<IMethodBuilder> declarations = new List<IMethodBuilder>();


        public IMethodBuilder Add<Result>(string name)
        {
            var type = typeof(Result).Name;
            if (typeof(Result) == typeof(Void))
            {
                type = "void";
            }
            
            var declaration = SyntaxFactory.MethodDeclaration(SyntaxFactory.ParseTypeName(type), name);
            var prop = new MethodBuilder(declaration);
            prop.SetModifier(SyntaxKind.PublicKeyword);
            declarations.Add(prop);

            return prop;
        }

        public IEnumerable<MethodDeclarationSyntax> Build()
        {
            foreach (var item in declarations)
            {
                var property = item as IDeclarationBuilder<MethodDeclarationSyntax>;

                yield return property.Build();
            }
        }
    }
}
