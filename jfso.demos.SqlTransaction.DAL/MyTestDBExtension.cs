using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jfso.demos.SqlTransaction.DAL
{
    public partial class MyTestDV : DbContext
    {
        public MyTestDV(EntityConnection connection, bool contextOwnsConnection)
            : base(connection, contextOwnsConnection)
        {
        }
    }
}
