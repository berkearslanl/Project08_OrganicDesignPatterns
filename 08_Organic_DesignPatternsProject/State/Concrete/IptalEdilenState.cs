using _08_Organic_DesignPatternsProject.State.Abstract;

namespace _08_Organic_DesignPatternsProject.State.Concrete
{
    public class IptalEdilenState : IOrderState
    {
        public string StateName => "İptal Edildi";

        public string BadgeClass => "status-red";

        public bool CanShip => false;

        public bool CanDeliver => false;

        public bool CanCancel => false;

        public IOrderState Cancel()
        {
            throw new InvalidOperationException("Sipariş zaten iptal edildi.");
        }

        public IOrderState Deliver()
        {
            throw new InvalidOperationException("İptal edilen sipariş işlenemez.");
        }

        public IOrderState Ship()
        {
            throw new InvalidOperationException("İptal edilen sipariş işlenemez.");
        }
    }
}
