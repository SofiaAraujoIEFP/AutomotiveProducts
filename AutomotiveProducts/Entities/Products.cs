using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotiveProducts.Entities
{
    //Verificar se esta abordagem vai ser utilizada na primeira versão do carrossel
    public class Products : BaseEntity
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal CostPrice { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsCompleted { get; set; }
        public decimal SalePrice { get; set; }
        public string Supplier { get; set; }
        public int SupplierRef { get; set; }
        public string? SupplierRefType { get; set; }
        public long Quantity { get; set; }
    }
}
