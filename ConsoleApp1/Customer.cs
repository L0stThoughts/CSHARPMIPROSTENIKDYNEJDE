using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSHARPMIPROSTENIKDYNEJDE
{
    internal class Customer : BaseClass
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string email { get; set; }

        public Customer(int id, string name, string email)
        {
            this.ID = id;
            this.name = name;
            this.email = email;
        }
        public override string ToString()
        {
            return ID + name + email;
        }
    }
}
