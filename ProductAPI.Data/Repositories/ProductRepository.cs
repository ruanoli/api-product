using ProductAPI.Data.Context;
using ProductAPI.Data.Entities;
using ProductAPI.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext) 
        {
            _appDbContext = appDbContext;
        }

        public IList<Product> GetAll()
        {
            return _appDbContext.Products.ToList();
        }

        public Product GetById(Guid id)
        {
            return _appDbContext.Products.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Add(Product product)
        {
            _appDbContext.Products.Add(product);
            _appDbContext.SaveChanges();
        }

        public void Update(Product product)
        {
            _appDbContext.Products.Update(product);
            _appDbContext.SaveChanges();

        }

        public void Delete(Product product)
        {
            _appDbContext.Products.Remove(product);
            _appDbContext.SaveChanges();

        }
    }
}
