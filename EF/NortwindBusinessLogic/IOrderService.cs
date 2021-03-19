using NortwindBusinessLogic.ViewModels;

namespace NortwindBusinessLogic
{
    public interface IOrderService
    {
        CreateOrderResults CreateOrder(CreateOrderViewModel viewOrder);
    }
}