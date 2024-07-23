using System;
using System.Collections.Generic;
using ThrowException.CSharpLibs.DataObjectLib;

namespace ThrowException.CSharpLibs.DatabaseObjectLib
{
    public interface IDatabaseContext : IDataContext<DatabaseObject>
    {
    }
}