<h1>Apartment Site Management System</h1>

<b>Projenin Tanımı</b>

- Yöneticinin apartman ve apartman sakinlerini bir sistem üzerinden takip etmesini ve yönetmesini sağlar. Bu uygulamada yönetici aylık olarak aidatı ve faturaları apartman sakinlerine tanımlar.
- Yöneticinin sisteme eklediği her bir apartman sakini için rastgele bir şifre oluşturulur ve bu şifre apartman sakinlerine mail üzerinden iletilir.
- Ödemeler uygulama üzerinden sadece kredi kartıyla yapılmaktadır.
- Ödenmeyen faturalar için apartman sakinlerine günlük mail gönderilecek şekilde bir yapı hazırlanmıştır.



<b>Kullanılan Teknoloji ve Kütüphaneler</b>

- .NET
- Hangfire
- Postgresql
- AutoMapper
- FluentValidation
- Entity Framework
- JWT
- Identity
- MailKit
<p></p>
<b>Veritabanı Tabloların Oluşturulması (Code First)</b>
<p>Projede tabloların oluşturulması için DAL ve Payment.API katmanlarında migrationlar çalıştırılmalıdır.
</p>
<p></p>
<b>Örnek:</b> 

- Add-Migration First
- Update-Database
<p></p>
<p></p>
<b>Bu proje 4 alt katmandan oluşmaktadır.</b>
<p></p>

- DAL: Data Access Layer
- BLL: Business Logic Layer
- API: Servislere Erişim Katmanı
- Payment.API: Ödeme Servisine Erişim Katmanı
<p></p>
<p></p>
<b>DAL</b>
<p>Veritabanında ki tablo ve kayıtlara erişmek için oluşturulan katmandır. Temel CRUD işlemlerinin Generic olarak yapılmasını sağlar. Entityleri,Repository'i ve DbContext'i içerisinde barındırır.</p>
<p></p>
<b>BLL</b>
<p>Projenin iş kurallarının gerçekleştirildiği katmandır. Başlıca iş kuralları,Servisler,Validatorlar,Request ve Response modelleri,Mapping'i içerisinde barındırır.</p>
<p></p>
<b>API</b>
<p>Kullanıcıların servislere erişimi için tanımlı endpointler üzerinden işlemleri gerçekleştiren katmandır.Controller'ı ve projenin Config işlemlerini içerisinde barındırır.</p>
<p></p>
<b>Payment.API</b>
<p>Kullanıcıların ödeme işlemini gerçekleştiren katmandır.DAL,BLL ve API katmanlarına direk erişimi yoktur.HTTP isteğiyle iletişim sağlanmaktadır.Kendine ait bağımlılıkları vardır.Entity,DbContext,Repository,Servis,Controller ve projenin Config işlemlerini içerisinde barındırır.</p>
<p></p>
<b>Referanslar</b>

- https://ravindradevrani.medium.com/net-7-jwt-authentication-and-role-based-authorization-5e5e56979b67
- https://www.c-sharpcorner.com/article/emailservice/
- https://www.borakasmer.com/net-6-0-uzerinde-hangfire-implementasyonu/#:~:text=Hangfire%2C%20arkada%20asenkron%20olarak%20%C3%A7al%C4%B1%C5%9Fan,%2C%20MSMQ%2C%20Redis)%20gibi.


