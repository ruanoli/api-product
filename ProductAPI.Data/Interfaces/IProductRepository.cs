using ProductAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI.Data.Interfaces
{
    public interface IProductRepository
    {
        IList<Product> GetAll();
        Product GetById(Guid id);
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
    }
}
