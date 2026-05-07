# 🌿 Organik E-Ticaret — Design Patterns

Bu proje, **ASP.NET Core MVC** mimarisi kullanılarak geliştirilmiş, temel odağı karmaşık iş mantıklarını **Yazılım Tasarım Desenleri (Design Patterns)** ile yönetmek ve temiz kod (Clean Code) standartlarını uygulamak olan bir e-ticaret platformudur. Proje boyunca, spagetti kod yapısından kaçınılarak, her özelliğin kendi sorumluluk alanında kaldığı, genişletilebilir bir yapı hedeflenmiştir.

---

## 🛠️ Teknolojik Stack

* **Framework:** ASP.NET Core 6.0 MVC
* **ORM:** Entity Framework Core
* **Veritabanı:** MS SQL Server
* **Frontend:** Bootstrap 5, ViewComponents

---

## 🏗️ Uygulanan Tasarım Desenleri (Design Patterns)

Projenin mimari gücünü oluşturan 5 ana tasarım deseni ve uygulama senaryoları şunlardır:

### 1. Repository & Unit of Work Pattern
* **Uygulama:** Veri erişim katmanını soyutlayarak veritabanı bağımsızlığı sağlanmıştır.
* **İşleyiş:** Tüm işlemler tek bir kanal üzerinden yönetilir ve veri bütünlüğü `CommitAsync()` metodu ile atomik bir yapıda korunur.

### 2. State Pattern (Durum Tasarım Deseni)
* **Senaryo:** Admin panelindeki siparişlerin yaşam döngüsü (Hazırlanıyor ➡️ Kargoda ➡️ Teslim Edildi) bu desenle kurgulanmıştır.
* **Mantık:** "Hazırlanıyor" aşamasındaki bir sipariş iptal edilebilirken, "Kargoya Verildi" statüsündeki bir siparişin iptal edilmesi veya tekrar kargolanması tasarım seviyesinde engellenmiştir.
* **Avantaj:** Karmaşık `if-else` blokları yerine nesne tabanlı bir durum makinesi kullanılmıştır.

### 3. Chain of Responsibility Pattern (Sorumluluk Zinciri)
* **Senaryo:** Sipariş onaylanmadan önce 4 aşamalı bir doğrulama zinciri oluşturulmuştur: Stok Kontrolü ➡️ Kupon Doğrulama ➡️ Minimum Tutar ➡️ Ödeme.
* **İşleyiş:** Her halka kendi sorumluluğunu yerine getirir; herhangi bir aşamada hata oluşursa süreç anında durdurulur.

### 4. Strategy Pattern (Strateji Tasarım Deseni)
* **Uygulama:** Kredi Kartı, Banka Transferi ve Kapıda Ödeme gibi farklı ödeme yöntemleri için ayrı strateji sınıfları tanımlanmıştır.
* **Avantaj:** "Open/Closed" prensibi sayesinde mevcut koda dokunmadan sisteme yeni ödeme yöntemleri dinamik olarak eklenebilir.

### 5. Observer Pattern (Gözlemci Tasarım Deseni)
* **Senaryo:** Sipariş tamamlandığında veya bültene abone olunduğunda tetiklenen ve kullanıcıya mail gönderen bir bildirim altyapısı kurulmuştur.
* **Esneklik:** "Subject" ve "Observer" ayrımı sayesinde ana iş mantığı kirletilmeden sisteme yeni bildirim kanalları (E-posta, SMS vb.) kolayca dahil edilebilir.

---

👨‍🏫 Teşekkür

Bu projenin gelişim sürecindeki rehberliği ve değerli eğitimleri için Murat Yücedağ hocama ve M&Y Yazılım Eğitim Akademi'ye teşekkürlerimi sunarım.

---

📸 Ekran Görüntüleri
> Ana Sayfa
> <img width="1920" height="6950" alt="homepage" src="https://github.com/user-attachments/assets/9b4ce763-637d-405d-9560-5ac363638236" />
> Ürünler
> <img width="1920" height="2260" alt="ürünler" src="https://github.com/user-attachments/assets/1478a936-c50f-41b1-aaa1-2e8a81c12431" />
> Sepet
> <img width="1920" height="2964" alt="sepet" src="https://github.com/user-attachments/assets/1e42fabd-96ec-4996-8a34-c2f5ece19603" />
> Sipariş Sayfası
> <img width="1950" height="1863" alt="siparişverme" src="https://github.com/user-attachments/assets/a46d3ab0-cef8-4bbc-b4b2-d60ef96e84d6" />
> Kredi Kartı Seçimi
> <img width="839" height="451" alt="kredikarti" src="https://github.com/user-attachments/assets/5086e17b-05e4-4fbb-9a01-cf28a4ce52d3" />
> EFT Seçimi
> <img width="840" height="271" alt="eft" src="https://github.com/user-attachments/assets/d1bd00cd-a49e-4448-85e7-8281faaeefa4" />
> Sipariş Onayı
> <img width="1950" height="2203" alt="siparisalındı" src="https://github.com/user-attachments/assets/75d1e703-a29f-4e05-ba91-a7888d46f0c9" />
> Sipariş Bilgilendirme Maili
> <img width="373" height="660" alt="siparismail" src="https://github.com/user-attachments/assets/447dcd8a-5bfc-4ad6-a685-fb0de38bf655" />
> Admin Siparişler
> <img width="1912" height="907" alt="siparisler" src="https://github.com/user-attachments/assets/5ffe9cf8-8438-495f-af55-f3d80ada30fa" />
> Admin Kuponlar
> <img width="1909" height="909" alt="kuponlar" src="https://github.com/user-attachments/assets/61fba456-2216-4b18-8d88-08caa8ebccb1" />
> Abone Olma
> <img width="1893" height="176" alt="aboneolma" src="https://github.com/user-attachments/assets/6b7d977f-59cd-4224-a322-d2112af482aa" />
>Abonelik Maili
> <img width="498" height="654" alt="abone" src="https://github.com/user-attachments/assets/ebf07cd6-dc4a-40ea-9609-b6156f05db4a" />




