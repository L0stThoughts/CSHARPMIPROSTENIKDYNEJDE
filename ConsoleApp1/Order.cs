using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSHARPMIPROSTENIKDYNEJDE
{
    internal class Order : BaseClass
    {
        public int ID { get; set; }
        public string deliveryTime { get; set; }
        public string productName { get; set; }
        public bool vipCustomer { get; set; }
        public int customerID { get; set; }

        public Order(int id, string deliveryTime, string productName, bool vipCustomer, int customerID)
        {
            this.ID = id;
            this.deliveryTime = deliveryTime;
            this.productName = productName;
            this.vipCustomer = vipCustomer;
            this.customerID = customerID;
        }
        public override string ToString()
        {
            return ID + deliveryTime + productName + vipCustomer + customerID;
        }
    }
}
