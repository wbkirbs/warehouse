using System;

namespace WarehouseTest
{
    public interface WarehouseDataTestInterface
    {
        //the tests that must be implemented
        void getRandomWarehouse_Test();
        void Constructor_Test();
        void ToString_Test();
        void EqualOperator_Test();
        void NotEqualOperator_Test();
        void Equals_Test();
        void GetHashCode_Test();
        void Copy_Test();
        void Exists_Test();
        void Create_Test();
        void Read_Test();
        void Update_Test();
        void Delete_Test();
    }
}
