using Fluetax.Interfaces;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using Fluetax.Common;

namespace Fluetax.Builders
{
    public class MethodBuilder : IMethodBuilder, IDeclarationBuilder<MethodDeclarationSyntax>
    {
        public MethodDeclarationSyntax Declaration { get; private set; }


        private BlockSyntax body;
        private List<ParameterSyntax> parameters = new List<ParameterSyntax>();
        private List<SyntaxToken> modifiers = new List<SyntaxToken>();

        public MethodBuilder(MethodDeclarationSyntax property)
        {
            this.Declaration = property;
        }

        

        public MethodDeclarationSyntax Build()
        {
            Declaration = Declaration.AddModifiers(modifiers.ToArray());
            Declaration = Declaration.AddParameterListParameters(parameters.ToArray());
            if(body == null)
            {
                body = SyntaxFactory.Block(SyntaxFactory.ParseStatement("throw new NotImplementedException();"));
            }

            Declaration = Declaration.WithBody(body);
            return Declaration;
        }


        public IMethodBuilder SetModifier(SyntaxKind kind)
        {
            var token = SyntaxFactory.Token(kind);
            if (!modifiers.Contains(token))
            {
                this.modifiers.Add(token);
            }
            return this;
        }

        public IMethodBuilder AddParameter<T>(SyntaxKind kind, string name)
        {
            name = name.ToCamelCase();
            if (this.parameters.Any(i => i.Identifier.ValueText.ToCamelCase() == name.ToCamelCase()))
            {
                throw new InvalidOperationException($"There is already a parameter named '{name}' on {Declaration.Identifier.ValueText}.");
            }


            
            var type = typeof(T).Name;
            var parameter = SyntaxFactory.Parameter(SyntaxFactory.Identifier(name)).WithType(SyntaxFactory.ParseTypeName(type));
            this.parameters.Add(parameter);
            return this;
        }

        public void AddBody(BlockSyntax body)
        {
            this.body = body;
        }
    }
}
