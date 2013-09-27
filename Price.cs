using System;
using System.Runtime.Serialization;
using System.Xml.Serialization    ;

namespace Warehouse
{
    [Serializable]
    [DataContract (Name = "price")]
    public class Price
    {
        /** <value>The Total value before shipping, Tax, etc. are applied.</value> **/ 
        [DataMember(Name="subtotal")] [XmlElement(ElementName="subtotal")]
        public virtual double   SubTotal         { get; set; }

        /** <value>A discount amount for the order</value>                         **/ 
        [DataMember(Name="discount")] [XmlElement(ElementName="discount")]
        public virtual double   Discount         { get; set; }

        /** <value>The shipping cost for shipping this order.</value>              **/ 
        [DataMember(Name="shipping_cost")] [XmlElement(ElementName="shipping_cost")]
        public virtual double   ShippingCost     { get; set; }

        /** <value>The Tax associated with this order.</value>                     **/ 
        [DataMember(Name="tax")] [XmlElement(ElementName="tax")]
        public virtual double   Tax              { get; set; }

        [DataMember(Name="total")] [XmlElement(ElementName="total")]
        /** <value>The final Total amount on the order.</value>                    **/ public virtual double   Total            { get; set; }
    }
}
