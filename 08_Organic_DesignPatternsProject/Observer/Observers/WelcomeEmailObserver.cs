using _08_Organic_DesignPatternsProject.Services;

namespace _08_Organic_DesignPatternsProject.Observer.Observers
{
    public class WelcomeEmailObserver : ISubscriberObserver
    {
        private readonly EmailService _emailService;

        public WelcomeEmailObserver(EmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task OnSubscribedAsync(string email)
        {
            var subject = "Organik Mağazaya Hoş Geldiniz! 🌿";
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
              <div style='font-size:40px;margin-bottom:12px;'>🌿</div>
              <h1 style='margin:0;color:white;font-size:26px;font-weight:700;letter-spacing:-0.5px;'>
                Organik Mağaza
              </h1>
              <p style='margin:8px 0 0;color:rgba(255,255,255,0.85);font-size:14px;'>
                100% Doğal & Organik Ürünler
              </p>
            </td>
          </tr>

          <!-- CONTENT -->
          <tr>
            <td style='padding:40px;'>
              <h2 style='margin:0 0 16px;color:#1e293b;font-size:22px;font-weight:700;'>
                Hoş Geldiniz! 👋
              </h2>
              <p style='margin:0 0 16px;color:#64748b;font-size:15px;line-height:1.7;'>
                Merhaba, bültenimize abone olduğunuz için teşekkür ederiz.
                Artık en taze organik ürünler, özel indirimler ve kampanyalardan
                ilk siz haberdar olacaksınız.
              </p>
              <p style='margin:0 0 32px;color:#64748b;font-size:15px;line-height:1.7;'>
                Sağlıklı ve doğal bir yaşam için doğru adrestesiniz. 🥦🍎🥕
              </p>

              <!-- BUTTON -->
              <table cellpadding='0' cellspacing='0'>
                <tr>
                  <td style='background:#5cb85c;border-radius:50px;'>
                    <a href='http://localhost:5000/Shop/ShopList'
                       style='display:inline-block;padding:14px 32px;color:white;text-decoration:none;font-size:15px;font-weight:600;'>
                      Alışverişe Başla →
                    </a>
                  </td>
                </tr>
              </table>
            </td>
          </tr>

          <!-- FEATURES -->
          <tr>
            <td style='padding:0 40px 40px;'>
              <table width='100%' cellpadding='0' cellspacing='0'>
                <tr>
                  <td width='33%' style='text-align:center;padding:20px 10px;background:#f8fdf8;border-radius:12px;margin:4px;'>
                    <div style='font-size:28px;margin-bottom:8px;'>🌱</div>
                    <div style='font-size:13px;font-weight:600;color:#1e293b;'>%100 Organik</div>
                    <div style='font-size:12px;color:#94a3b8;margin-top:4px;'>Sertifikalı ürünler</div>
                  </td>
                  <td width='4'></td>
                  <td width='33%' style='text-align:center;padding:20px 10px;background:#f8fdf8;border-radius:12px;'>
                    <div style='font-size:28px;margin-bottom:8px;'>🚚</div>
                    <div style='font-size:13px;font-weight:600;color:#1e293b;'>Hızlı Teslimat</div>
                    <div style='font-size:12px;color:#94a3b8;margin-top:4px;'>99₺ üzeri ücretsiz</div>
                  </td>
                  <td width='4'></td>
                  <td width='33%' style='text-align:center;padding:20px 10px;background:#f8fdf8;border-radius:12px;'>
                    <div style='font-size:28px;margin-bottom:8px;'>💚</div>
                    <div style='font-size:13px;font-weight:600;color:#1e293b;'>Doğaya Saygı</div>
                    <div style='font-size:12px;color:#94a3b8;margin-top:4px;'>Sürdürülebilir üretim</div>
                  </td>
                </tr>
              </table>
            </td>
          </tr>

          <!-- FOOTER -->
          <tr>
            <td style='background:#f8fafc;padding:24px 40px;text-align:center;border-top:1px solid #f1f5f9;'>
              <p style='margin:0;color:#94a3b8;font-size:12px;line-height:1.6;'>
                Bu maili aldınız çünkü <strong>{email}</strong> adresiyle bültenimize abone oldunuz.<br>
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