using System;

namespace Warehouse
{
    /** ****************************************************************************
     * <author>Wayne Bryan</author>
     * <date>October 22, 2012 - 12:38 PM</date>
     * <category>Warehouse Class</category>
     * <summary>
     *   Class for storing payment information about a PayPayl order.
     * </summary>
     *******************************************************************************/
    public class PayPal : Payment
    {
        /** <value>The paypal token.</value> **/
        public virtual string token   { get; set; }
        /** <value>Paypal id.</value> **/
        public virtual string payerId { get; set; }


        /** ****************************************************************************
         * <summary>Constructor. Sets payment type as paypal.</summary>
         *******************************************************************************/
        public PayPal() : base(Payment.PaymentType.PAYPAL)
        {
            
        }

        /** ****************************************************************************
         * <summary>Constructor. Sets payment type as paypal.</summary>
         * <param name="company">The company object to use.</param>
         *******************************************************************************/
        public PayPal(Company company): base(Payment.PaymentType.PAYPAL, company)
        {
            
        }
    }
}
