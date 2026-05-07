using _08_Organic_DesignPatternsProject.State.Abstract;

namespace _08_Organic_DesignPatternsProject.State.Concrete
{
    public class HazırlananState : IOrderState
    {
        public string StateName => "Hazırlanıyor";

        public string BadgeClass => "status-yellow";

        public bool CanShip => true;

        public bool CanDeliver => false;

        public bool CanCancel => true;

        public IOrderState Cancel()
        {
            return new IptalEdilenState();
        }

        public IOrderState Deliver()
        {
            throw new InvalidOperationException("Önce kargoya verilmeli.");
        }

        public IOrderState Ship()
        {
            return new KargoyaVerilenState();
        }
    }
}
