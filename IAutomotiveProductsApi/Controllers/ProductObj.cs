namespace IAutomotiveProductsApi.Controllers
{
    internal class ProductObj
    {
        public ProductObj()
        {
        }

        public object Descrition { get; internal set; }
        public object Title { get; internal set; }
        public DateTime CreatedAt { get; internal set; }
        public DateTime UpdateAt { get; internal set; }
    }
}
