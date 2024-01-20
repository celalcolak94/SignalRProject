using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstract
{
    public interface ICategoryService : IGenericService<Category>
    {
        int TCategoryCount();
        int TAktiveCategoryCount();
        int TPassiveCategoryCount();
    }
}
