using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeWork11WcfService.DataModels
{
    public class OrderDataModel
    {
        public int OrderID { get; set; }
        public DateTime? OrderDate { get; set; }
        public string EmployeeLastName { get; set; }
        public string CustomerID { get; set; }
    }
}