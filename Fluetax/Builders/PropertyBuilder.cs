using Fluetax.Interfaces;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fluetax.Builders
{
    public class PropertyBuilder : IPropertyBuilder, IDeclarationBuilder<PropertyDeclarationSyntax>
    {
        public PropertyDeclarationSyntax Declaration { get; private set; }

        private List<AccessorDeclarationSyntax> accessors = new List<AccessorDeclarationSyntax>();
        private List<SyntaxToken> modifiers = new List<SyntaxToken>();

        public PropertyBuilder(PropertyDeclarationSyntax property)
        {
            this.Declaration = property;
        }

        

        public PropertyDeclarationSyntax Build()
        {
            Declaration = Declaration.AddModifiers(modifiers.ToArray());
            Declaration = Declaration.AddAccessorListAccessors(accessors.ToArray());
            return Declaration;
        }

        public IPropertyBuilder SetAccessor(SyntaxKind kind)
        {
            var accessor = SyntaxFactory.AccessorDeclaration(kind)
                .WithSemicolonToken(SyntaxFactory.Token(SyntaxKind.SemicolonToken));

            this.accessors.Add(accessor);
            return this;
        }

        public IPropertyBuilder SetModifier(SyntaxKind kind)
        {
            var token = SyntaxFactory.Token(kind);
            if (!modifiers.Contains(token))
            {
                this.modifiers.Add(token);
            }

            return this;
        }
    }
}
