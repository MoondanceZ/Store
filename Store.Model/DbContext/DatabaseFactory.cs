using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Model.DbContext
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private StoreDbContext dataContext;
        public StoreDbContext Get()
        {
            return dataContext ?? (dataContext = new StoreDbContext());
        }

        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}
