using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fluetax.Interfaces
{
    public interface IFluetaxConfiguration<T, E>
    {
        T Add<Result>(string name);

        IEnumerable<E> Build();
    }
}
