using System;

namespace Warehouse
{
    /** ****************************************************************************
     * <author>Wayne Bryan</author>
     * <date>October 22, 2012 - 12:37 PM</date>
     * <category>Warehouse Class</category>
     * <summary>
     *   Class for storing payment information about a credit card tokenization order.
     * </summary>
     *******************************************************************************/
    public class CreditCardToken : CreditCard
    {
        /** <value>The Authorize.net customer id.</value>              **/ public virtual string CustomerProfileId          { get; set; }
        /** <value>The Authorize.net payment profile id.</value>       **/ public virtual string PaymentProfileId           { get; set; }
        /** <value>Last four digits of the credit card number.</value> **/ public virtual string LastFourOfNumber           { get; set; }
        /** <value>The approval code for the tokenization.</value>     **/ public virtual string ApprovalCode               { get; set; }
        /** <value>Issuer of the tokenization transaction.</value>     **/ public virtual string Issuer                     { get; set; }
        /** <value>Authorize.net transaction id.</value>               **/ public virtual string AuthorizationTransactionId { get; set; }

        /** ****************************************************************************
         * <summary>Constructor. Sets payment type as a credit card token.</summary>
         *******************************************************************************/
        public CreditCardToken() : base()
        {
            this.Type = Payment.PaymentType.CREDIT_CARD_TOKEN;
        }

        /** ****************************************************************************
         * <summary>Constructor. Sets payment type as a credit card token.</summary>
         * <param name="company">The company object to use.</param>
         *******************************************************************************/
        public CreditCardToken(Company company) : base(company)
        {
            this.Type = Payment.PaymentType.CREDIT_CARD_TOKEN;
        }
    }
}
