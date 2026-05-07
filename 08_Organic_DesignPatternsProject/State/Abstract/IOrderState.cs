namespace _08_Organic_DesignPatternsProject.State.Abstract
{
    public interface IOrderState
    {
        string StateName { get; }//hazırlanıyor-teslim edildi vs
        string BadgeClass { get; }

        bool CanShip { get; }//kargoya verilebilir mi
        bool CanDeliver { get; }//teslim edilebilir mi
        bool CanCancel { get; }//iptal edilebilir mi

        IOrderState Ship();
        IOrderState Deliver();
        IOrderState Cancel();
    }
}
