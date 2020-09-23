using System;
//test update
namespace Warehouse
{
    /** ****************************************************************************
     * <author>Wayne Bryan</author>
     * <date>February 22, 2012 - 1:42 PM</date>
     * <category>Warehosue Class</category>
     * <summary>Represents a tracking number for a package.</summary>
     *******************************************************************************/
    public class TrackingNumber : WarehouseData
    {
        /** <value>The actual tracking number assigned.</value>       **/ public virtual string   TheTrackingNumber { get; set; }
        /** <value>The weight of the package.</value>                 **/ public virtual double   Weight         { get; set; }
        /** <value>The freight weight of the package.</value>         **/ public virtual double   Freight        { get; set; }
        /** <value>The shipping date of this tracking number.</value> **/ public virtual DateTime Shipdate       { get; set; }


        #region constructors
        /** ****************************************************************************
         * <summary>Constructor. Does nothing.</summary>
         *******************************************************************************/
        public TrackingNumber() : base()
        {

        }

        /** ****************************************************************************
         * <summary>Constructor. Assigns the company.</summary>
         * <param name="company">The company object to use.</param>
         *******************************************************************************/
        public TrackingNumber(Company company) : base(company)
        {

        }

        /** ****************************************************************************
         * <summary>Constructor. Assigns the company.</summary>
         * <param name="company">The company object to use.</param>
         * <param name="trackingNumber">The tracking number to store.</param>
         *******************************************************************************/
        public TrackingNumber(Company company, string trackingNumber) : base(company)
        {
            this.TheTrackingNumber = trackingNumber;
        }
        #endregion constructors


        /** ****************************************************************************
		 * <summary>Determines if this TrackingNumber object is equivalent to another TrackingNumber.</summary>
         * <param name="obj">The TrackingNumber object to compare to.</param>
         * <returns>True if the TrackingNumber member data are equivalent. False otherwise.</returns>
		 ********************************************************************************/
        public override bool Equals(object obj)
        {
            if (! base.Equals(obj)) return false;
            TrackingNumber tracking = (TrackingNumber) obj;
            if (this.TheTrackingNumber != tracking.TheTrackingNumber) return false;
            if (this.Weight != tracking.Weight) return false;
            if (this.Freight != tracking.Freight) return false;
            return true;
        }


        /** ****************************************************************************
		 * <summary>Calculates a unique hash for this TrackingNumber object.</summary>
         * <returns>Unique hashcode for the TrackingNumber object.</returns>
		 ********************************************************************************/
        public override int GetHashCode()
        {
            unchecked {
                int hash = base.GetHashCode(); 
                hash = hash * 23 + this.Weight.GetHashCode();
                hash = hash * 23 + this.Freight.GetHashCode();
                return hash; 
            }
        }

    }
}
