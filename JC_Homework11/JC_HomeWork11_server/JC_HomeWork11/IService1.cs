using JC_HomeWork11.DataObjects;
using System.Collections.Generic;
using System.ServiceModel;


namespace JC_HomeWork11
{
    // Servis method
    [ServiceContract]
    public interface IServiceHomeWork
    {
        [OperationContract]
        List<OrderDO> GetOrders(string customerID);

    }
}
