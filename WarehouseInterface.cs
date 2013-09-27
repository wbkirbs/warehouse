using System;

namespace Warehouse
{
    /** ****************************************************************************
     * <author>Wayne Bryan</author>
     * <date>November 23, 2011 - 11:36 AM</date>
     * <category>Interface</category>
     * <summary>
     *   Represents the core functionality of a Warehouse object..
     * </summary>
     *******************************************************************************/
    public interface WarehouseInterface
    {
        /** ****************************************************************************
		 * <summary>
         *   Generates a random Warehouse object with random data.
         * </summary>
         * <returns>The random Warehouse object.</returns>
		 *******************************************************************************/
        void getRandomWarehouse();
        
        /** ****************************************************************************
		 * <summary>Warehouse must implement object Equals.</summary>
         * <param name="obj">The object to compare to.</param>
         * <returns>True if the Warehouse objects member data are equivalent. False otherwise.</returns>
		 *******************************************************************************/
        bool Equals(object obj);

        /** ****************************************************************************
		 * <summary>Compares two Warehouse objects to see if they are less than, equal, or great than one another. This is used for sorting objects.</summary>
         * <param name="warehouse">The object to compare to.</param>
         * <returns>0 if the two objects are identical. -1 if the current object is less than obj. +1 if the currnet object is greater than obj.</returns>
		 *******************************************************************************/
        int CompareTo(object warehouse);

        /** ****************************************************************************
		 * <summary>Warehouse must implement GetHashCode.</summary>
         * <returns>Unique hashcode for the Warehouse object.</returns>
		 *******************************************************************************/
        int GetHashCode();

        /** ****************************************************************************
		 * <summary>
         *   Creates a new WarehouseData object and copies all data members to this new object.
         * </summary>
         * <returns>An exact copy of the current WarehouseData object</returns>
		 *******************************************************************************/
        WarehouseData Copy();

        /** ****************************************************************************
		 * <summary>
         *   Checks if the current WarehouseData object already exists in the "database" context.
         * </summary>
         * <returns>True if the WarehouseData already exists. False otherwise.</returns>
		 *******************************************************************************/
        bool Exists();

        /** ****************************************************************************
		 * <summary>
         *   Creates a new WarehouseData object in the "database" with the values of the
         *   current WarehouseData object.
         * </summary>
         * <returns>True if the WarehouseData was successfully created. False otherwise.</returns>
		 *******************************************************************************/
        bool Create();

        /** ****************************************************************************
		 * <summary>
         *   Retrieves data on the current WarehouseData object and updates itself.
         * </summary>
         * <returns>True if the WarehouseData was successfully read. False otherwise.</returns>
		 *******************************************************************************/
        bool Read();

        /** ****************************************************************************
		 * <summary>
         *   Retrieves list of data on the current WarehouseData object and updates itself.
         * </summary>
         * <returns>True if the WarehouseData was successfully read. False otherwise.</returns>
		 *******************************************************************************/
        WarehouseData[] ReadAll();

        /** ****************************************************************************
		 * <summary>
         *   Updates the current WarehouseData object in the "database."
         * </summary>
         * <returns>True if the WarehouseData was successfully updated. False otherwise.</returns>
		 *******************************************************************************/
        bool Update();

        /** ****************************************************************************
		 * <summary>
         *   Deletes the current WarehouseData object in the "database."
         * </summary>
         * <returns>True if the WarehouseData was successfully deleted. False otherwise.</returns>
		 *******************************************************************************/
        bool Delete();
    }
}
