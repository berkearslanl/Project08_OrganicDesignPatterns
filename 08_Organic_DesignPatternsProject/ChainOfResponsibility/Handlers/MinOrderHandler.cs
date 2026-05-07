using _08_Organic_DesignPatternsProject.ChainOfResponsibility.Abstract;

namespace _08_Organic_DesignPatternsProject.ChainOfResponsibility.Handlers
{
    public class MinOrderHandler : OrderHandler
    {
        private readonly decimal _minOrderAmount = 50m;//m harfi decimal olduğunu belirtir


        public override async Task<string> Handle(OrderRequest request)
        {
            if (request.TotalAmount < _minOrderAmount)
            {
                return $"Minimum sipariş tutarı {_minOrderAmount}₺ olmalıdır. " + $"Mevcut tutar: {request.TotalAmount}₺";
            }
            if (_nextHandler != null)
            {
                return await _nextHandler.Handle(request);
            }
            return null;
        }
    }
}
