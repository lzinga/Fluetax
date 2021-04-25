using Fluetax.Configurations;
using Fluetax.Interfaces;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fluetax.Builders
{
    public class ClassBuilder : IClassBuilder
    {
        private ClassDeclarationSyntax classDeclaration;


        PropertyConfiguration propertyConfig;
        MethodConfiguration methodConfig;


        public ClassBuilder(string name, SyntaxKind kind)
        {
            classDeclaration = SyntaxFactory.ClassDeclaration(name);
            classDeclaration = classDeclaration.AddModifiers(SyntaxFactory.Token(kind));
        }


        public ClassBuilder(string name) : this(name, SyntaxKind.PublicKeyword)
        {
        }

        public IClassBuilder ConfigureProperties(Action<IPropertyConfiguration> properties)
        {
            propertyConfig = new PropertyConfiguration();
            properties.Invoke(propertyConfig);
            return this;
        }

        public IClassBuilder ConfigureMethods(Action<IMethodConfiguration> methods)
        {
            methodConfig = new MethodConfiguration();
            methods.Invoke(methodConfig);
            return this;
        }

        public ClassDeclarationSyntax Build()
        {
            var p = propertyConfig.Build();
            var m = methodConfig.Build();

            return classDeclaration
                .AddMembers(p.ToArray())
                .AddMembers(m.ToArray());
        }

    }
}
