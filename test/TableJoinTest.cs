using System;
using NUnit.Framework;
using Utilities.Debugger;
using Databases;
using Warehouse;
//using Warehouse.Databases.Abecas;

namespace WarehouseTest
{
    [TestFixture]
    [Ignore("Ignoring TableJoinTest ...")]
    public class TableJoinTest
    {
        private Database _database = new SqlDatabase("abecas_cs", "wfsapp02");

        public TableJoinTest()
        {
            //turn on debugging
            Debug.DebugMode = true;
            Debug.StepMode  = true;
        }


        [Test]
        public void AbecasJoin_Test()
        {
            /*string sql = "select top 1 wmtransactiondetail.rowid as wmtransactiondetail.rowid from wmtransactionheader inner join wmtransactiondetail on wmtransactiondetail.r_transactionheader = wmtransactionheader.rowid";
            using (Result result = _database.Query(sql)) {
                Row row = result.FetchRow();
                foreach (string column in row.Columns) Console.WriteLine(column);
                Debug.Step(row[0]);
                Debug.Step(row["wmtransactiondetail.rowid"]);
            }*/
            
            
            /*wmtransactionheader header = new wmtransactionheader(_database);
            header.transactionnumber = "S-0085525";

            wmtransactiondetail detail = new wmtransactiondetail(_database);
            detail.setJoin(detail.Columns.r_transactionheader, header.Columns.rowid);

            //another table to join
            imitem item = new imitem(_database);
            item.setJoin(item.Columns.rowid, detail.Columns.r_item);

            TableJoin join = new TableJoin(header, detail, item);
            join.Join();
            foreach (Row row in join) {
                Debug.Step(row["transactionnumber"]);
                Debug.Step(row["wmtransactiondetail.r_transactionheader"]);
                Debug.Step(row["wmtransactiondetail.rowid"]);
                Debug.Step(row["imitem.itemcode"]);
            }

            Debug.Step(join.ToString());
             * */
        }

    }
}
