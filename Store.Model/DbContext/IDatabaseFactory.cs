using Store.Framework.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model.DbContext
{
    public interface IDatabaseFactory : IDisposable
    {
        StoreDbContext Get();
    }
}
