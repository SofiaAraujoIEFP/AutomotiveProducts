using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotiveProducts.Entities
{
    public class Images : BaseEntity
    {
        public string URL { get; set; }
        public Products Product { get; set; }
        public long ProductId { get; set; }
    }
}
