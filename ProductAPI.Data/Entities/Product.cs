using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI.Data.Entities
{
    /// <summary>
    /// Modelo de entidade Produto do banco de dados
    /// </summary>
    public class Product
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
