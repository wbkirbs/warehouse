using System;

namespace Warehouse
{
    /** ****************************************************************************
     * <author>Wayne Bryan</author>
     * <date>October 24, 2012 - 2:42 PM</date>
     * <category>Class</category>
     * <summary>
     *   Stores tax data for a location.
     * </summary>
     *******************************************************************************/
    public class Tax : WarehouseData
    {
        /** <value>National sales tax percentage.</value>             **/ public virtual double  nationalRate { get; set; }
        /** <value>State sales tax percentage.</value>                **/ public virtual double  stateRate    { get; set; }
        /** <value>County sales tax percentage.</value>               **/ public virtual double  countyRate   { get; set; }
        /** <value>City sales tax percentage.</value>                 **/ public virtual double  cityRate     { get; set; }
        /** <value>Whether to calculate tax on shipping cost.</value> **/ public virtual bool    taxShipping  { get; set; }
        /** <value>The tax location.</value>                          **/ public         Address location     = null;


        /** ****************************************************************************
         * <summary>Constructor. Sets up company.</summary>
         * <param name="company">The Company to use.</param>
         *******************************************************************************/
        public Tax(Company company) : base(company)
        {

        }
    }
}
