using System;
using Utilities.Debugger;
using Databases;
using Warehouse;
using NUnit.Framework;

namespace WarehouseTest
{
    [TestFixture]
    [Ignore("Ignoring TableColumnTest ...")]
    public class TableColumnTest : WarehouseDataTest
    {
        private Database _abecasDatabase = new SqlDatabase("abecas_practice", "wfsapp02");

        public TableColumnTest()
        {
            //turn on debugging
            Debug.DebugMode = true;
            Debug.StepMode  = true;
        }

        [Test]
        public override void getRandomWarehouse_Test()
        {
            TableColumn column = new TableColumn();
            column.getRandomWarehouse();
            base.getRandomWarehouse_Test(column);
            Assert.IsNotNullOrEmpty(column.DatabaseString);
            Assert.IsNotNullOrEmpty(column.DataType);
            Assert.IsNotNull(column.Identity);
            Assert.IsNotNull(column.IsNullable);
            Assert.Greater(column.MaxLength, 0);
            Assert.IsNotNull(column.Modified);
            Assert.IsNotNullOrEmpty(column.Name);
            Assert.IsNotNull(column.PrimaryKey);
            Assert.IsNotNull(column.Value);
        }

        [Test]
        public override void Equals_Test()
        {
            TableColumn column1 = new TableColumn();
            TableColumn column2 = new TableColumn();
            base.Equal_TestHelper(column1, column2);

            column1.getRandomWarehouse();
            column2 = new TableColumn();
            Assert.AreNotEqual(column1, column2);
            column2.id = column1.id;
            Assert.AreNotEqual(column1, column2);
            column2.SetDataType(column1.DataType);
            Assert.AreNotEqual(column1, column2);
            column2.SetIdentity(column1.Identity);
            Assert.AreNotEqual(column1, column2);
            column2.SetIsNullable(column1.IsNullable);
            Assert.AreNotEqual(column1, column2);
            column2.SetMaximumLength(column1.MaxLength);
            Assert.AreNotEqual(column1, column2);
            column2.SetModified(column1.Modified);
            Assert.AreNotEqual(column1, column2);
            column2.SetName(column1.Name);
            Assert.AreNotEqual(column1, column2);
            column2.SetPrimaryKey(column1.PrimaryKey);
            Assert.AreNotEqual(column1, column2);
            column2.SetValue(column1.Value);
            
            column1.SetModified(true);//column2 has been modified by setvalue
            base.Equal_TestHelper(column1, column2);
        }

        [Test]
        public override void Copy_Test()
        {
            _warehouse = new TableColumn();
            base.Copy_TestHelper();

            _warehouse.getRandomWarehouse();
            base.Copy_TestHelper();
        }

        [Test]
        public override void Constructor_Test()
        {
            //test the various types of constructors
            _warehouse = new TableColumn();
            TableColumn column = new TableColumn();
            Assert.AreNotSame(_warehouse, column);

            column = new TableColumn((TableColumn) _warehouse);
            Assert.AreNotSame(_warehouse, column);
            Assert.AreEqual(_warehouse, column);

            TableColumn column2 = new TableColumn();
            column = new TableColumn(column2);
            Assert.AreNotSame(column, column2);
            Assert.AreEqual(column, column2);

            column = new TableColumn(new Company());
            //column = new TableColumn(_abecasDatabase);
        }

        [Test]
        public override void ToString_Test()
        {
            TableColumn column = new TableColumn();
            column.getRandomWarehouse();
            Assert.IsTrue(column.ToString().Contains(column.id));
            Assert.IsTrue(column.ToString().Contains(column.DataType));
            Assert.IsTrue(column.ToString().Contains(column.Identity.ToString()));
            Assert.IsTrue(column.ToString().Contains(column.IsNullable.ToString()));
            Assert.IsTrue(column.ToString().Contains(column.MaxLength.ToString()));
            Assert.IsTrue(column.ToString().Contains(column.Modified.ToString()));
            Assert.IsTrue(column.ToString().Contains(column.Name));
            Assert.IsTrue(column.ToString().Contains(column.PrimaryKey.ToString()));
            Assert.IsTrue(column.ToString().Contains(column.Value.ToString()));
        }

        [Test]
        public override void EqualOperator_Test()
        {
            TableColumn column1 = new TableColumn();
            TableColumn column2 = new TableColumn();
            Assert.IsTrue(column1 == column2);

            column1.getRandomWarehouse();
            Assert.IsFalse(column1 == column2);
            
            column2 = new TableColumn(column1);
            Assert.IsTrue(column1 == column2);
        }

        [Test]
        public override void NotEqualOperator_Test()
        {
            TableColumn column1 = new TableColumn();
            TableColumn column2 = new TableColumn();
            Assert.IsFalse(column1 != column2);
            column2.id = "columnid";
            Assert.IsTrue(column1 != column2);

            column1.getRandomWarehouse();
            Assert.IsTrue(column1 != column2);
            column2 = new TableColumn(column1);
            Assert.IsFalse(column1 != column2);
        }

        [Test]
        public override void GetHashCode_Test()
        {
            TableColumn column1 = new TableColumn();
            TableColumn column2 = new TableColumn();
            Assert.AreEqual(column1.GetHashCode(), column2.GetHashCode());

            column1.getRandomWarehouse();
            Assert.AreNotEqual(column1.GetHashCode(), column2.GetHashCode());
            
            column2 = new TableColumn(column1);
            Assert.AreEqual(column1.GetHashCode(), column2.GetHashCode());
        }

        [Test]
        public override void Exists_Test()
        {
            TableColumn column = new TableColumn();
            int count = 0;
            try { column.Exists(); }
            catch { count++; }
            Assert.AreEqual(1, count);
        }

        [Test]
        public override void Create_Test()
        {
            TableColumn column = new TableColumn();
            int count = 0;
            try { column.Create(); }
            catch { count++; }
            Assert.AreEqual(1, count);
        }

        [Test]
        public override void Read_Test()
        {
            TableColumn column = new TableColumn();
            int count = 0;
            try { column.Read(); }
            catch { count++; }
            Assert.AreEqual(1, count);
        }

        [Test]
        public override void Update_Test()
        {
            TableColumn column = new TableColumn();
            int count = 0;
            try { column.Update(); }
            catch { count++; }
            Assert.AreEqual(1, count);
        }

        [Test]
        public override void Delete_Test()
        {
            TableColumn column = new TableColumn();
            int count = 0;
            try { column.Delete(); }
            catch { count++; }
            Assert.AreEqual(1, count);
        }
    }
}
