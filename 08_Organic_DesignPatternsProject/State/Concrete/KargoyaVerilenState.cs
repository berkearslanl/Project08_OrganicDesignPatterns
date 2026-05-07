using _08_Organic_DesignPatternsProject.State.Abstract;

namespace _08_Organic_DesignPatternsProject.State.Concrete
{
    public class KargoyaVerilenState : IOrderState
    {
        public string StateName => "Kargoya Verildi";

        public string BadgeClass => "status-blue";

        public bool CanShip => false;

        public bool CanDeliver => true;

        public bool CanCancel => false;

        public IOrderState Cancel()
        {
            throw new InvalidOperationException("Kargodaki sipariş iptal edilemez.");
        }

        public IOrderState Deliver()
        {
            return new TeslimEdilenState();
        }

        public IOrderState Ship()
        {
            throw new InvalidOperationException("Zaten kargoya verildi.");
        }
    }
}
