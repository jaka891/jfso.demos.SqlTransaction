using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace jfso.demos.SqlTransaction.DAL
{
    public class DataHandler
    {
        public static bool insertDataToTable1(int numberID, string text)
        {
            bool response = false;

            try
            {
                using (var ctx = new MyTestDV())
                {
                    ctx.TestTable1.Add(
                        new TestTable1()
                        {
                            ID = numberID,
                            Text = text
                        });


                    ctx.SaveChanges();

                    response = true;
                }
            }
            catch (Exception)
            {
                response = false;
            }

            return response;
        }

        public static bool insertDataToTable1(SqlConnection connection, System.Data.SqlClient.SqlTransaction transaction, int numberID, string text)
        {
            bool response = false;

            MetadataWorkspace workspace = new MetadataWorkspace
                (
                    new string[]
                    {
                        string.Format("res://{0}/MyTestDB.csdl" , "*"),
                        string.Format("res://{0}/MyTestDB.ssdl" , "*"),
                        string.Format("res://{0}/MyTestDB.msl" , "*")
                    },
                    new Assembly[]
                    {
                        Assembly.GetAssembly(typeof (jfso.demos.SqlTransaction.DAL.MyTestDV))
                    }
                );

            EntityConnection _conn = new EntityConnection(workspace, connection);

            try
            {
                using (var ctx = new MyTestDV(_conn, false))
                {

                    ctx.Database.UseTransaction(transaction);

                    ctx.TestTable1.Add(
                        new TestTable1()
                        {
                            ID = numberID,
                            Text = text
                        });


                    ctx.SaveChanges();

                    response = true;
                }
            }
            catch (Exception)
            {
                response = false;
            }

            return response;
        }

        public static bool insertDataToTable2(int numberID, string text)
        {
            bool response = false;

            try
            {
                using (var ctx = new MyTestDV())
                {
                    ctx.TestTable2.Add(
                        new TestTable2()
                        {
                            ID = numberID,
                            Text = text
                        });


                    ctx.SaveChanges();

                    response = true;
                }
            }
            catch (Exception)
            {
                response = false;
            }

            return response;
        }

        public static bool insertDataToTable2(SqlConnection connection, System.Data.SqlClient.SqlTransaction transaction, int numberID, string text)
        {
            bool response = false;

            MetadataWorkspace workspace = new MetadataWorkspace
            (
                new string[]
                {
                    string.Format( "res://{0}/MyTestDB.csdl" , "*"),
                    string.Format( "res://{0}/MyTestDB.ssdl" , "*"),
                    string.Format( "res://{0}/MyTestDB.msl" , "*")
                },
                new Assembly[]
                {
                    Assembly.GetAssembly(typeof (jfso.demos.SqlTransaction.DAL.MyTestDV))
                }
            );

            EntityConnection _conn = new EntityConnection(workspace, connection);

            try
            {
                using (var ctx = new MyTestDV(_conn, false))
                {

                    ctx.Database.UseTransaction(transaction);

                    ctx.TestTable2.Add(
                        new TestTable2()
                        {
                            ID = numberID,
                            Text = text
                        });


                    ctx.SaveChanges();

                    response = true;
                }
            }
            catch (Exception)
            {
                response = false;
            }

            return response;
        }

    }
}
