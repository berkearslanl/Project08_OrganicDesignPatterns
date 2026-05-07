using _08_Organic_DesignPatternsProject.ChainOfResponsibility.Abstract;

namespace _08_Organic_DesignPatternsProject.ChainOfResponsibility.Handlers
{
    public class StockHandler : OrderHandler
    {
        public override async Task<string> Handle(OrderRequest request)
        {
            foreach (var item in request.CartItems)
            {
                if (item.Product.Stock < item.Quantity)//ürünün mevcut stoğu sepetteki ürünün stoğundan düşükse
                {
                    return $"{item.Product.ProductName} ürününde yeterli stok bulunmamaktadır!" + $"Mevcut stok: {item.Product.Stock}";
                }
            }
            if(_nextHandler !=null)
            {
                return await _nextHandler.Handle(request);
            }
            return null;//buraya geldiyse tüm kontrolleri geçti demektir. controlerda bu kontrol edilir
        }
    }
}
