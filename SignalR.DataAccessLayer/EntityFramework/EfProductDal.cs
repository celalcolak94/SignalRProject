using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(SignalRContext context) : base(context)
        {
        }

        public List<Product> GetProductsWithCategory()
        {
            var context = new SignalRContext();
            var values = context.Products.Include(x => x.Category).ToList();
            return values;
        }

        public int ProductCount()
        {
            using var context = new SignalRContext();
            return context.Products.Count();
        }

        public int ProductCountByCategoryNameDrink()
        {
            using var context = new SignalRContext();
            return context.Products.Where(x => x.CategoryID == (context.Categories.FirstOrDefault(y => y.CategoryName == "İçecek").CategoryID)).Count();
        }

        public int ProductCountByCategoryNameHamburger()
        {
            using var context = new SignalRContext();
            return context.Products.Where(x => x.CategoryID == (context.Categories.FirstOrDefault(y => y.CategoryName == "Hamburger").CategoryID)).Count();
        }

        public string ProductNameByMaxPrice()
        {
            using var context = new SignalRContext();
            return context.Products.FirstOrDefault(x => x.Price == (context.Products.Max(y => y.Price))).ProductName;
        }

        public string ProductNameByMinPrice()
        {
            using var context = new SignalRContext();
            return context.Products.FirstOrDefault(x => x.Price == (context.Products.Min(y => y.Price))).ProductName;
        }

        public decimal ProductPriceAvg()
        {
            using var context = new SignalRContext();
            return context.Products.Average(x => x.Price);
        }

        public decimal ProductAvgPriceByHamburger()
        {
            using var context = new SignalRContext();
            return context.Products.Where(x => x.CategoryID == (context.Categories.FirstOrDefault(y => y.CategoryName == "Hamburger").CategoryID)).Average(z => z.Price);
        }

        public List<Product> GetProductsWithCategoryByStatusTrue()
        {
            using var context = new SignalRContext();
            return context.Products.Include(x => x.Category).Where(y => y.ProductStatus == true).ToList();
        }

        public void ProductChangeStatus(int id)
        {
            using var context = new SignalRContext();
            var product = context.Products.Find(id);
            product.ProductStatus = !product.ProductStatus;
            context.SaveChanges();
        }
    }
}
