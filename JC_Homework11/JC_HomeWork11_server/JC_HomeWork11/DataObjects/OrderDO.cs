using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using JC_HomeWork11.DataModels;
using System.Runtime.Serialization;

namespace JC_HomeWork11.DataObjects
{
    public class OrderDO
    {
        [DataMember]
        public int orderID { get; set; }
        [DataMember]
        public Nullable<System.DateTime> orderDate { get; set; }
        [DataMember]
        public string lastName { get; set; }
        [DataMember]        
        public string customerID { get; set; }
    }
}