using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IDiscountDal : IGenericDal<Discount>
    {
        List<Discount> GetDiscountsByStatusTrue();
        void ChangeStatus(int id);
    }
}
