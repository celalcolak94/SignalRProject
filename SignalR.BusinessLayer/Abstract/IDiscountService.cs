using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IDiscountService : IGenericService<Discount>
    {
        List<Discount> TGetDiscountsByStatusTrue();
        void TChangeStatus(int id);
    }
}
