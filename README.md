# Dijital Cüzdan Uygulaması

Bu C# Windows Forms uygulaması, kişisel gelir ve gider takibi yapmanızı sağlayan basit bir dijital cüzdan uygulamasıdır.

## Özellikler

### Ana Sayfa
- **Toplam Bakiye Gösterimi**: Mevcut bakiyenizi görüntüler
- **Gelir/Gider Butonu**: Gelir ve gider ekleme sayfasına yönlendirir
- **Harcamalarım Butonu**: Harcama geçmişini görüntüleme sayfasına yönlendirir
- **Sıfırla Butonu**: Tüm verileri sıfırlar
- **Kaydet ve Çık Butonu**: Verileri kaydeder ve uygulamayı kapatır

### Gelir/Gider Sayfası
- **Gelir Ekleme**: Gelir miktarı girip bakiyeye ekleyebilirsiniz
- **Gider Ekleme**: Gider miktarı ve kategorisi seçerek bakiyeden düşebilirsiniz
- **Kategori Seçenekleri**: Giyim, Yiyecek, Alışveriş, Diğer

### Harcamalarım Sayfası
- **Harcama Listesi**: Tüm harcamalarınızı kategori ve miktar ile listeler
- **Ana Sayfaya Dönüş**: Ana sayfaya geri dönüş

## Veri Saklama
Uygulama verilerinizi `wallet_data.txt` dosyasında saklar. Bu sayede uygulamayı kapattığınızda verileriniz kaybolmaz.

## Kurulum ve Çalıştırma

1. .NET 6.0 SDK'nın yüklü olduğundan emin olun
2. Proje dizininde terminal açın
3. Aşağıdaki komutları çalıştırın:

## Teknik Detaylar

- **Framework**: .NET 6.0 Windows Forms
- **Dil**: C#
- **Veri Saklama**: Text dosyası
- **UI**: Windows Forms kontrolleri

## Dosya Yapısı

- `Program.cs` - Uygulama giriş noktası
- `MainForm.cs` - Ana sayfa formu
- `IncomeExpenseForm.cs` - Gelir/Gider ekleme formu
- `ExpensesForm.cs` - Harcamaları görüntüleme formu
- `DigitalWallet.csproj` - Proje dosyası 
