namespace _08_Organic_DesignPatternsProject.ChainOfResponsibility.Abstract
{
    public abstract class OrderHandler
    {
        protected OrderHandler _nextHandler;//zincirdeki bir sonraki halka

        public OrderHandler SetNext(OrderHandler nextHandler)//handlerı birbirine bağlamak için
        {
            _nextHandler = nextHandler;
            return nextHandler;
        }
        public abstract Task<string> Handle(OrderRequest request);
    }
}
