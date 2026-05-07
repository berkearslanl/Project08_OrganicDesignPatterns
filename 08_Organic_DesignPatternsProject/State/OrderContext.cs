using _08_Organic_DesignPatternsProject.State.Abstract;
using _08_Organic_DesignPatternsProject.State.Concrete;

namespace _08_Organic_DesignPatternsProject.State
{
    public class OrderContext
    {
        private IOrderState _currentState;

        public OrderContext(string currentState)
        {
            _currentState = currentState switch
            {
                "Kargoya Verildi" => new KargoyaVerilenState(),
                "Teslim Edildi" => new TeslimEdilenState(),
                "İptal Edildi" => new IptalEdilenState(),
                _ => new HazırlananState()
            };
        }

        public string CurrentStateName => _currentState.StateName;
        public string CurrentBadgeClass => _currentState.BadgeClass;
        public bool CanShip => _currentState.CanShip;
        public bool CanDeliver => _currentState.CanDeliver;
        public bool CanCancel => _currentState.CanCancel;

        public void Ship() => _currentState = _currentState.Ship();
        public void Deliver() => _currentState = _currentState.Deliver();
        public void Cancel() => _currentState = _currentState.Cancel();
    }
}
