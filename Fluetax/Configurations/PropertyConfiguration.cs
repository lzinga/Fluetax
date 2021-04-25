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
    internal class PropertyConfiguration : IPropertyConfiguration
    {
        private List<IPropertyBuilder> declarations = new List<IPropertyBuilder>();


        public IPropertyBuilder Add<Type>(string name)
        {
            var type = typeof(Type).Name;
            var propertyDeclaration = SyntaxFactory.PropertyDeclaration(SyntaxFactory.ParseTypeName(type), name);
            var prop = new PropertyBuilder(propertyDeclaration);
            prop.SetModifier(SyntaxKind.PublicKeyword);
            declarations.Add(prop);



            return prop;
        }

        public IEnumerable<PropertyDeclarationSyntax> Build()
        {
            foreach(var item in declarations)
            {
                var property = item as IDeclarationBuilder<PropertyDeclarationSyntax>;

                yield return property.Build();
            }
        }
    }
}
