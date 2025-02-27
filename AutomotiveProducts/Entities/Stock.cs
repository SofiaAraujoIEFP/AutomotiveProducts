using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomotiveProducts.Entities
{
    //Verificar se esta abordagem vai ser utilizada na primeira versão do carrossel
    public class Stock : BaseEntity
    {
        public long PoductId { get; set; }
        public Products Products { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime MovementDate { get; set; }
    }
}
