﻿using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
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
        public long ProductId { get; set; }
        public Products Products { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsCompleted { get; set; }
        public long QuantityReceived { get; set; }
        public long QuantitySent { get; set; }
        public DateTime EntryRegistry {  get; set; }
        public DateTime ExitRegistry {  get; set; }

        public void Decrease(long sentQuantity)
        {
            QuantitySent += sentQuantity;
            Console.WriteLine($"Quantity after decrease: {QuantityReceived - QuantitySent}");
        }

        public void Increase(long receivedQuantity)
        {
            QuantityReceived += receivedQuantity;
            Console.WriteLine($"Quantity after increase: {QuantityReceived - QuantitySent}");
        }
    }
}



