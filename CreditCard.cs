using System;

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
    public class CreditCard : Payment
    {
        /** <value>The expiration date of the credit card.</value> **/
        public virtual DateTime expiration        { get; set; }
        /** <value>The CVC code of the credit card. This value should never be saved to permanent storage.</value> **/
        public virtual string   cvc               { get; set; }
        /** <value>An authorization code for a credit card payment.</value> **/
        public virtual string   authorization     { get; set; }
        /** <value>Time of the authorization</value> **/
        public virtual DateTime authorizationTime { get; set; }
        /** <value>The credit card type. See CardTypes enumerator for possible list.</value> **/
        public virtual CardType creditcard    { get; set; }
        /** <value></value> **/
        public virtual string   number        { get; set; }
        /** <value>List of credit card types</value> **/
        public enum CardType {
            /** <value>A Visa credit card.</value>              **/ VISA            , 
            /** <value>A Discover credit card.</value>          **/ DISCOVER        , 
            /** <value>An American Express credit card.</value> **/ AMERICAN_EXPRESS, 
            /** <value>A Mastercard credit card.</value>        **/ MASTERCARD      ,
            /** <value>A Diners Club card.</value>              **/ DINERS_CLUB
        }


        /** ****************************************************************************
         * <summary>Constructor. Sets payment type as credit card.</summary>
         *******************************************************************************/
        public CreditCard() : base(Payment.PaymentType.CREDIT_CARD)
        {
            
        }

        /** ****************************************************************************
         * <summary>Constructor. Sets payment type as credit card.</summary>
         * <param name="company">The company object to use.</param>
         *******************************************************************************/
        public CreditCard(Company company) : base(Payment.PaymentType.CREDIT_CARD, company)
        {
            
        }


        /** ****************************************************************************
         * <summary>Algorithm for determining if a credit card number is a valid number. This works for all major credit cards.</summary>
         * <returns>True if a valid credit card number. False otherwise.</returns>
         *******************************************************************************/
        public bool LuhnCheckDigitValidation()
        {
            int sum = 0;
            bool alt = false;
            for(int i = this.number.Length - 1; i >= 0; i--) {
                int n = 0;
                if (! int.TryParse(this.number.Substring(i, 1), out n)) return false; //not a digit

                if(alt) {
                    n *= 2; //square n
                    if(n > 9) n = (n % 10) +1; //calculate remainder
                }
                sum += n;
                alt = ! alt;
            }

            //if $sum divides by 10 with no remainder then it's valid
            return ( sum > 0 && sum % 10 == 0);
        }


    }
}
