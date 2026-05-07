using _08_Organic_DesignPatternsProject.State.Abstract;

namespace _08_Organic_DesignPatternsProject.State.Concrete
{
    public class TeslimEdilenState : IOrderState
    {
        public string StateName => "Teslim Edildi";

        public string BadgeClass => "status-green";

        public bool CanShip => false;

        public bool CanDeliver => false;

        public bool CanCancel => false;

        public IOrderState Cancel()
        {
            throw new InvalidOperationException("Teslim edilen sipariş iptal edilemez.");
        }

        public IOrderState Deliver()
        {
            throw new InvalidOperationException("Sipariş zaten teslim edildi.");
        }

        public IOrderState Ship()
        {
            throw new InvalidOperationException("Sipariş teslim edildi.");
        }
    }
}
