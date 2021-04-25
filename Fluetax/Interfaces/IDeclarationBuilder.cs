using System;
using System.Collections.Generic;
using System.Text;

namespace Fluetax.Interfaces
{
    public interface IDeclarationBuilder<T>
    {
        T Build();
    }
}
