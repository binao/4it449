using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork12Library.DataModels
{
    public class OrderDataModel
    {
        public int OrderID { get; set; }
        public DateTime? OrderDate { get; set; }
        public string EmployeeLastName { get; set; }
        public string CustomerID { get; set; }
    }
}
