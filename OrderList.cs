using System;
using System.Collections;
using System.Collections.Generic;

namespace Warehouse
{
    /** ****************************************************************************
     * <author>Wayne Bryan</author>
     * <date>October 23, 2012 - 8:45 AM</date>
     * <category>Warehouse Class</category>
     * <summary>
     *   Class to read in an entire list of order objects.
     * </summary>
     *******************************************************************************/
    public abstract class OrderList : WarehouseData, IEnumerable, IEnumerator
    {
        /** <value>Stored list of orders to search from.</value> **/
        protected Order[] _ordersToSearch = null;

        /** ****************************************************************************
         * <summary>Child classes must implement method to search for orders.</summary>
         * <returns>List of orders that were found</returns>
         *******************************************************************************/
        protected abstract Order[] search();


        /** ****************************************************************************
         * <summary>Constructor. Calls parent constructor.</summary>
         * <param name="company">The company to use.</param>
         *******************************************************************************/
        public OrderList(Company company) : base(company)
        {

        }



        /** ****************************************************************************
         * <summary>Adds an order to the list to search.</summary>
         * <param name="order">The order to add to the list.</param>
         *******************************************************************************/
        public void Add(Order order)
        {
            List<Order> orders = new List<Order>();
            if (_ordersToSearch != null) orders.AddRange(_ordersToSearch);
            _ordersToSearch = orders.ToArray();
        }


        #region foreach
        private int _currentIndex = 0;
        private Order[] _orders = null;

        /** ****************************************************************************
         * <summary>Gets an enumerator for the order list.</summary>
         * <returns>Enumerator to loop over the order list object.</returns>
         *******************************************************************************/
        public override IEnumerator GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /** ****************************************************************************
         * <summary>Moves to the next order in the list.</summary>
         * <returns>True if there are any more orders in the list. False if no more orders exist.</returns>
         *******************************************************************************/
        public override bool MoveNext()
        {
            _currentIndex++;
            return (_orders != null && _currentIndex < _orders.Length);
        }

        /** ****************************************************************************
         * <summary>Sets the iterator back to the beginning of the order list.</summary>
         *******************************************************************************/
        public override void Reset()
        {
            _orders = this.search();
            _currentIndex = 0;
        }

        /** <value>The current order in the list.</value> **/
        public override object Current {
            get {
                return _orders[_currentIndex];
            }
        }
        #endregion foreach
    }
}
