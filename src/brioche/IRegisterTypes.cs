using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace brioche
{
    public interface IRegisterTypes
    {
        bool Contains(Type generalType);

        void Register(Type general, Type specific);

        Type Find(Type general);
    }
}
