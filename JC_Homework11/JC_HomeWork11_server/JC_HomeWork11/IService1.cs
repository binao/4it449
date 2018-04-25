using JC_HomeWork11.DataObjects;
using System.Collections.Generic;
using System.ServiceModel;


namespace JC_HomeWork11
{
    // POZNÁMKA: Pomocí příkazu Přejmenovat v nabídce Refaktorovat můžete změnit název rozhraní IServiceHomeWork společně v kódu i konfiguračním souboru.
    [ServiceContract]
    public interface IServiceHomeWork
    {
        [OperationContract]
        List<OrderDO> GetOrders(string customerID);

    }
}
