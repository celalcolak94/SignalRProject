using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System.Drawing.Text;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfDiscountDal : GenericRepository<Discount>, IDiscountDal
    {
        public EfDiscountDal(SignalRContext context) : base(context)
        {
        }

        public void ChangeStatus(int id)
        {
            using var context = new SignalRContext();
            var value = context.Discounts.Find(id);
            value.Status = !value.Status;
            context.SaveChanges();
        }

        public List<Discount> GetDiscountsByStatusTrue()
        {
            using var context = new SignalRContext();
            return context.Discounts.Where(x => x.Status).ToList();
        }
    }
}
