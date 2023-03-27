# Atlas Yazılımı

## Development Ortamı

### Enterprise Manager: 

Yazılım ve Veritabanı modellemesinin yapılmasını sağlayan bir yazılım geliştirme aracıdır. Aynı zamanda form tasarımı, iş akışı, rol tanımlama ve yetkilendirme, rapor tasarımları da Enterprise Manager üzerinden yapılmaktadır.

### Front-End Application:

AtlasWeb/Core klasörü altında kaynak kodları bulunmaktadır.

* Front-End uygulamasını build etmek için bilgisayarınızda NodeJS kurulu olduğuna emin olunuz. **NodeJS 10** sürümü kullanılması önerilmektedir. Farklı sürümlerde hatalar alınabilir.
* Aşağıdaki komut ile "node_modules" klasörüne gerekli kütüphaneler oluşturulur
```
npm install
```
* Aşağıdaki komut ile yazılım localhost üzerinde ayağa kaldırılır.    

```
npm run dev
```

### Backend Application:

* Visual Studio 2022 kullanılarak **Atlas.sln** solution'u çalıştırılır. Gerekli nuget paketleri restore edildikten sonra, proje ayağa kaldırılır.
* Visual Studio üzerinden uygulama run olurken, post build işlemi sırasında frontend application'da otomatik olarak ayağa kalkar.
* **AtlasWeb/Core/ServerConfiguration.xml** içerisinde veritabanı bağlantısı ayarlamaları yapılmaktadır. Veritabanı olarak Oracle veritabanı kullanılması gerekmektedir.

### Release Ortamı oluşturma

* Atlas yazılmı release ortamında Docker üzerinde çalışmaktadır.
* Projenin root bölümünde **docker-compose** dosyası ve **Dockerfile** dosyası üzerinde yazılımın hangi adımlar ile ayağa kalktığı belirtilmiştir.
* Genel olarak docker file da şu işlemler yapılmaktadır.
* Base Asp.NET 3.1 imaj'ı kullanılmaktadır.
* HTTPS kullanımı için gerekli sertifika ayarlamaları yapılmaktadır.
* Node JS kurulumu yapılmaktadır
* Daha hızlı npm yüklemesi için **yarn** kullanılmaktadır.
* Gerekli **nuget** paketleri yüklenmektedir.
* Raporlama için gerekli linux gdi ve font kütüphaneleri yüklenmektedir.
* Atlas Backend Application, nginx proxy'si arkasında çalışmaktadır.
* docker-compose dosyası içerisinde gerekli configurasyonları yapılmaktadır.
* Aşağıdaki komut ile frontend/backend/proxy kodları'ları build edilmektedir.
```
docker-compose build
```
