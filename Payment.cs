using System                      ;
using System.Runtime.Serialization;

namespace Warehouse
{
    /** ****************************************************************************
     * <author>Wayne Bryan</author>
     * <date>October 22, 2012 - 12:22 PM</date>
     * <category>Warehouse Class</category>
     * <summary>
     *   Class for storing payment information for an order.
     * </summary>
     *******************************************************************************/
    [Serializable]
    [DataContract (Name="payment")]
    public abstract class Payment : WarehouseData
    {
        /** <value>The type of payment. See PaymentType enumerator for options.</value> **/ [IgnoreDataMember] public PaymentType Type  ;
        /** <value>The total amount of this payment.</value>                            **/ [DataMember(Name = "amount")] public virtual double      Amount { get; set; }
        /** <value>Types of available payments.</value> **/
        public enum PaymentType {
            /** <value>A credit card payment.</value>       **/ CREDIT_CARD      , 
            /** <value>A check payment.</value>             **/ CHECK            , 
            /** <value>An invoice payment.</value>          **/ INVOICE          , 
            /** <value>An echeck payment.</value>           **/ ECHECK           , 
            /** <value>A credit card token payment.</value> **/ CREDIT_CARD_TOKEN, 
            /** <value>A paypal payment.</value>            **/ PAYPAL
        }

        public Payment() : base()
        {

        }
        public Payment(Company company) : base(company)
        {

        }

        /** ****************************************************************************
         * <summary>Constructor. Simply calls parent class and sets up the payment type.</summary>
         * <param name="paymentType">The type of payment.</param>
         *******************************************************************************/
        public Payment(PaymentType paymentType) : base()
        {
            this.Type = paymentType;
        }

        /** ****************************************************************************
         * <summary>Constructor. Simply calls parent class and sets up the payment type.</summary>
         * <param name="paymentType">The type of payment.</param>
         * <param name="company">The company object to use.</param>
         *******************************************************************************/
        public Payment(PaymentType paymentType, Company company) : base(company)
        {
            this.Type = paymentType;
        }

    }
}
