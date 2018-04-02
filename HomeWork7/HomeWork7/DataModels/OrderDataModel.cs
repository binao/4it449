using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork7.DataModels
{
    class OrderDataModel
    {
        public int OrderID { get; set; }
        public DateTime? OrderDate { get; set; }
        public string EmployeeLastName { get; set; }
        public string CustomerID { get; set; }
    }
}
