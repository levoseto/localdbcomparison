using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estructuras.Interfaces
{
    public interface ISQLiteDefinition
    {
        void InsertAll<T>(List<T> elements);
    }
}