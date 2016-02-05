using jfso.demos.SqlTransaction.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace jfso.demos.SqlTransaction
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Transaction Scope Method
            using (TransactionScope ctx = new TransactionScope())
            {
                DataHandler.insertDataToTable1(1, "blabla1");

                DataHandler.insertDataToTable2(2, "blabla2");

                ctx.Complete();

            }
            #endregion

            #region SqlTransactionMethod
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MyTestDV2"].ConnectionString))
            {
                connection.Open();
                using (System.Data.SqlClient.SqlTransaction transaction = connection.BeginTransaction())
                {
                    DataHandler.insertDataToTable1(connection, transaction, 1, "blabla1");

                    DataHandler.insertDataToTable2(connection, transaction, 2, "blabla2");

                    transaction.Commit();

                }
            }

            #endregion
        }
    }
}
