using System                      ;
using System.Runtime.Serialization;
using System.Xml.Serialization    ;
using System.Collections.Generic  ;

namespace Warehouse
{
    [Serializable]
    [DataContract (Name="box")]
    public class Box : WarehouseData
    {
        #region members
        [IgnoreDataMember]
        public override string LinkID {
            get { return this.ShipmentID ; }
            set { this.ShipmentID = value; }
        }

        //the link to the shipment
        [DataMember(Name="shipment_id")]
        [XmlElement(ElementName="shipment_id")]
        public virtual string ShipmentID       { get; set; }

        [DataMember(Name="tracking_number")] [XmlElement(ElementName="tracking_number")]
        public virtual string   TrackingNumber { get; set; }

        [DataMember(Name="weight")] [XmlElement(ElementName="weight")]
        public virtual double   Weight         { get; set; }

        [DataMember(Name="height")] [XmlElement(ElementName="height")]
        public virtual double   Height         { get; set; }

        [DataMember(Name="width")] [XmlElement(ElementName="width")]
        public virtual double   Width          { get; set; }

        [DataMember(Name="length")] [XmlElement(ElementName="length")]
        public virtual double   Length         { get; set; }

        [DataMember(Name="cost")] [XmlElement(ElementName="cost")]
        public virtual double   Cost           { get; set; }

        [DataMember(Name="box_number")] [XmlElement(ElementName="box_number")]
        public virtual int      BoxNumber      { get; set; }

        [DataMember(Name="ship_date")] [XmlElement(ElementName="ship_date")]
        public virtual DateTime ShipDate       { get; set; }

        [DataMember(Name="items")] [XmlElement(ElementName="items")]
        public virtual OrderItem[]   Items          { get { if (_items == null) return null; return _items.ToArray(); } set { if (_items == null) _items = new List<OrderItem>(); _items.Clear(); _items.AddRange(value); } }

        [IgnoreDataMember] public virtual Customer ShipTo           { get { if (_shipto == null) _shipto = new Customer(this.Company); return _shipto; } set { _shipto = value; } }
        
        private List<OrderItem> _items = new List<OrderItem>();
        private Customer _shipto;
        #endregion members


        #region constructors
        public Box()
        {
            this.BoxNumber = 1;
        }
        public Box(Company company) : base(company)
        {
            this.BoxNumber = 1;
        }
        public Box(WarehouseData data) : base(data)
        {
            if (this.BoxNumber == 0) this.BoxNumber = 1;
        }
        #endregion constructors


        #region public methods
        public void AddItem(OrderItem item)
        {
            List<OrderItem> items = new List<OrderItem>();
            if (this.Items != null) items.AddRange( (OrderItem[]) this.Items );
            items.Add( item );
            this.Items = items.ToArray();
        }
        public void RemoveItem(int index)
        {
            if (this.Items == null || index > this.Items.Length) return;
            List<OrderItem> items = new List<OrderItem>();
            items.AddRange( (OrderItem[]) this.Items );
            items.RemoveAt( index );
            this.Items = items.ToArray();
        }
        #endregion public methods
    }
}
