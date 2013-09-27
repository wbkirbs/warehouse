using System;
using Utilities.Debugger;
using Warehouse;
using NUnit.Framework;

namespace WarehouseTest
{
    public abstract class WarehouseDataTest : WarehouseDataTestInterface
    {
        protected WarehouseData _warehouse;

        public WarehouseDataTest()
        {
            //turn on debugging
            Debug.DebugMode = true;
            Debug.StepMode  = true;
        }

        //the tests that must be implemented
        public abstract void getRandomWarehouse_Test();
        public abstract void Equals_Test();
        public abstract void Copy_Test();
        public abstract void Constructor_Test();
        public abstract void ToString_Test();
        public abstract void EqualOperator_Test();
        public abstract void NotEqualOperator_Test();
        public abstract void GetHashCode_Test();
        public abstract void Exists_Test();
        public abstract void Create_Test();
        public abstract void Read_Test();
        public abstract void Update_Test();
        public abstract void Delete_Test();

        //test helpers
        public virtual void getRandomWarehouse_Test(WarehouseData warehouse)
        {
            //Assert.IsNotNull(warehouse.id); //id can be null for some classes
        }

        
        public void Equal_TestHelper(WarehouseData warehouse1, WarehouseData warehouse2)
        {
            Assert.AreNotSame(warehouse1, warehouse2);
            Assert.AreEqual(warehouse1, warehouse2);
            Assert.AreEqual(warehouse1, warehouse1);
            Assert.AreEqual(warehouse2, warehouse2);
        }

        public virtual void Copy_TestHelper()
        {
            WarehouseData warehouse = _warehouse.Copy();
            Assert.AreNotSame(_warehouse, warehouse);
            Assert.AreEqual(_warehouse.ToString(), warehouse.ToString());
            Assert.AreEqual(_warehouse, warehouse);
        }

    }
}
