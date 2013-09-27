using System;

namespace Warehouse
{
    /** ****************************************************************************
     * <author>Wayne Bryan</author>
     * <date>August 16, 2012 - 1:40 PM</date>
     * <category>WarehouseData Class</category>
     * <summary>
     *   Provides an interfaces to Adjustment transactions.
     * </summary>
     *******************************************************************************/
    public class Adjustment : PurchaseOrder
    {
        #region constructors
        /** ****************************************************************************
         * <summary>Constructor. Sets up the company connection.</summary>
         * <param name="company">The company to use for the Adjustment.</param>
         *******************************************************************************/
        public Adjustment(Company company) : base(company)
        {

        }
        #endregion constructors
    }
}
