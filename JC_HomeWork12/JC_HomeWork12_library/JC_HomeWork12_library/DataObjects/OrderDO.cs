using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JC_HomeWork12_library.DataObjects
{
    //Library with share class
    public class OrderDO
    {
        public int orderID { get; set; }
        public Nullable<System.DateTime> orderDate { get; set; }
        public string lastName { get; set; }
        public string customerID { get; set; }
    }
}
