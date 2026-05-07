using _08_Organic_DesignPatternsProject.Services;

namespace _08_Organic_DesignPatternsProject.Observer.Observers
{
    public class OrderConfirmationObserver : IOrderObserver
    {
        private readonly EmailService _emailService;

        public OrderConfirmationObserver(EmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task OnOrderCreatedAsync(string email, int orderId, decimal totalAmount)
        {
            var subject = $"Siparişiniz Alındı! #{orderId} 🛍️";
            var body = $@"
<!DOCTYPE html>
<html lang='tr'>
<head><meta charset='UTF-8'></head>
<body style='margin:0;padding:0;background-color:#f1f5f9;font-family:Segoe UI,sans-serif;'>

  <table width='100%' cellpadding='0' cellspacing='0'>
    <tr>
      <td align='center' style='padding:40px 20px;'>
        <table width='600' cellpadding='0' cellspacing='0' style='background:white;border-radius:16px;overflow:hidden;box-shadow:0 4px 20px rgba(0,0,0,0.08);'>

          <!-- HEADER -->
          <tr>
            <td style='background:linear-gradient(135deg,#5cb85c,#3d8b3d);padding:40px;text-align:center;'>
              <div style='font-size:40px;margin-bottom:12px;'>🛍️</div>
              <h1 style='margin:0;color:white;font-size:26px;font-weight:700;letter-spacing:-0.5px;'>
                Siparişiniz Alındı!
              </h1>
              <p style='margin:8px 0 0;color:rgba(255,255,255,0.85);font-size:14px;'>
                En kısa sürede hazırlanacaktır
              </p>
            </td>
          </tr>

          <!-- SİPARİŞ NO BANNER -->
          <tr>
            <td style='padding:24px 40px 0;'>
              <table width='100%' cellpadding='0' cellspacing='0'>
                <tr>
                  <td style='background:#f0fdf4;border:2px solid #bbf7d0;border-radius:12px;padding:20px;text-align:center;'>
                    <div style='color:#64748b;font-size:13px;font-weight:600;text-transform:uppercase;letter-spacing:1px;margin-bottom:6px;'>
                      Sipariş Numaranız
                    </div>
                    <div style='color:#16a34a;font-size:32px;font-weight:800;letter-spacing:-1px;'>
                      #{orderId}
                    </div>
                  </td>
                </tr>
              </table>
            </td>
          </tr>

          <!-- CONTENT -->
          <tr>
            <td style='padding:32px 40px;'>
              <p style='margin:0 0 24px;color:#64748b;font-size:15px;line-height:1.7;'>
                Merhaba, siparişiniz başarıyla alındı ve şu an hazırlanıyor.
                Siparişinizle ilgili gelişmeleri bu mail adresi üzerinden takip edebilirsiniz.
              </p>

              <!-- SİPARİŞ DETAY TABLOSU -->
              <table width='100%' cellpadding='0' cellspacing='0'
                     style='background:#f8fafc;border-radius:12px;overflow:hidden;margin-bottom:28px;'>
                <tr style='background:#f1f5f9;'>
                  <td style='padding:12px 20px;font-size:11px;font-weight:700;color:#64748b;text-transform:uppercase;letter-spacing:1px;'>
                    Detay
                  </td>
                  <td style='padding:12px 20px;font-size:11px;font-weight:700;color:#64748b;text-transform:uppercase;letter-spacing:1px;text-align:right;'>
                    Bilgi
                  </td>
                </tr>
                <tr style='border-top:1px solid #e2e8f0;'>
                  <td style='padding:14px 20px;color:#64748b;font-size:14px;'>Sipariş No</td>
                  <td style='padding:14px 20px;color:#1e293b;font-size:14px;font-weight:600;text-align:right;'>#{orderId}</td>
                </tr>
                <tr style='border-top:1px solid #e2e8f0;background:white;'>
                  <td style='padding:14px 20px;color:#64748b;font-size:14px;'>Sipariş Tarihi</td>
                  <td style='padding:14px 20px;color:#1e293b;font-size:14px;font-weight:600;text-align:right;'>{DateTime.Now:dd.MM.yyyy HH:mm}</td>
                </tr>
                <tr style='border-top:1px solid #e2e8f0;'>
                  <td style='padding:14px 20px;color:#64748b;font-size:14px;'>Durum</td>
                  <td style='padding:14px 20px;text-align:right;'>
                    <span style='background:#fef9c3;color:#ca8a04;padding:4px 12px;border-radius:20px;font-size:12px;font-weight:600;'>
                      Hazırlanıyor
                    </span>
                  </td>
                </tr>
                <tr style='border-top:2px solid #e2e8f0;background:#f0fdf4;'>
                  <td style='padding:16px 20px;color:#1e293b;font-size:15px;font-weight:700;'>Toplam Tutar</td>
                  <td style='padding:16px 20px;color:#16a34a;font-size:18px;font-weight:800;text-align:right;'>
                    {totalAmount.ToString("C2", new System.Globalization.CultureInfo("tr-TR"))}
                  </td>
                </tr>
              </table>

              <!-- SÜREÇ ADIMLARI -->
              <table width='100%' cellpadding='0' cellspacing='0' style='margin-bottom:28px;'>
                <tr>
                  <td width='25%' style='text-align:center;padding:0 8px;'>
                    <div style='width:44px;height:44px;background:#5cb85c;border-radius:50%;margin:0 auto 8px;display:flex;align-items:center;justify-content:center;'>
                      <span style='color:white;font-size:18px;'>✓</span>
                    </div>
                    <div style='font-size:12px;font-weight:600;color:#1e293b;'>Sipariş Alındı</div>
                  </td>
                  <td width='25%' style='text-align:center;padding:0 8px;'>
                    <div style='width:44px;height:44px;background:#fef9c3;border:2px solid #fbbf24;border-radius:50%;margin:0 auto 8px;'>
                      <span style='line-height:40px;font-size:18px;'>📦</span>
                    </div>
                    <div style='font-size:12px;font-weight:600;color:#ca8a04;'>Hazırlanıyor</div>
                  </td>
                  <td width='25%' style='text-align:center;padding:0 8px;'>
                    <div style='width:44px;height:44px;background:#f1f5f9;border-radius:50%;margin:0 auto 8px;'>
                      <span style='line-height:44px;font-size:18px;'>🚚</span>
                    </div>
                    <div style='font-size:12px;color:#94a3b8;'>Kargoda</div>
                  </td>
                  <td width='25%' style='text-align:center;padding:0 8px;'>
                    <div style='width:44px;height:44px;background:#f1f5f9;border-radius:50%;margin:0 auto 8px;'>
                      <span style='line-height:44px;font-size:18px;'>🏠</span>
                    </div>
                    <div style='font-size:12px;color:#94a3b8;'>Teslim Edildi</div>
                  </td>
                </tr>
              </table>

              <!-- BUTTON -->
              <table cellpadding='0' cellspacing='0' width='100%'>
                <tr>
                  <td style='background:#5cb85c;border-radius:50px;text-align:center;'>
                    <a href='http://localhost:5000/Shop/ShopList'
                       style='display:block;padding:14px 32px;color:white;text-decoration:none;font-size:15px;font-weight:600;'>
                      Alışverişe Devam Et →
                    </a>
                  </td>
                </tr>
              </table>
            </td>
          </tr>

          <!-- FOOTER -->
          <tr>
            <td style='background:#f8fafc;padding:24px 40px;text-align:center;border-top:1px solid #f1f5f9;'>
              <p style='margin:0;color:#94a3b8;font-size:12px;line-height:1.6;'>
                Bu sipariş onayı <strong>{email}</strong> adresine gönderilmiştir.<br>
                Herhangi bir sorun için bizimle iletişime geçebilirsiniz.<br><br>
                © {DateTime.Now.Year} Organik Mağaza. Tüm hakları saklıdır.
              </p>
            </td>
          </tr>

        </table>
      </td>
    </tr>
  </table>

</body>
</html>";

            await _emailService.SendAsync(email, subject, body);
        }
    }
}