# RentACarProject

RentACar is a car rental solution. This project includes an enterprise-grade solution for building RESTful services using ASP.NET WebAPI and C#. Here is the list that you can make with this project right now;

- CRUD operations for Cars, Colors, Brands, Users, Customers and Rentals.
- Authorization Added. You need to be logged in and having a claim for add, update and delete operations
- Working with a real DB (MSSQL)
- EntityFramework files added
- IEntity, IDto, IEntityRepository, EfEntityRepositoryBase added
- Core Layer added
- WebAPI, JWT, IoC, Interceptors,Autofac
- The rules that I tried to follow rules when writing this project

- SOLID Principles,
- Clean Coding,
- DRY (Don't Repeat Yourself)
## Türkçe Açıklama

Proje SOLID, Kurumsal Yazılım Mimari, AOP ve Yazılım Geliştirme Prensiplerine uygun geliştirildi.
- .Net Core 7.0 platformu ile geliştirildi.

- Cross Cutting Concerns "kesişen ilgililer" *interceptor Autofac kütüphanesi kullanılarak geliştirildi.

--Performance
-- Transaction
-- Validation
-- Caching
- Entity Framework ORM kullanılarak geliştirildi.

- AOP ile Cross Cutting Concerns "kesişen ilgililer" projede modülarite yapıda geliştirildi.

- Exception Middleware ile Merkezi hata mekanizması geliştrildi.

- Claim Mekanizması ile rol bazlı yetkilendirmenin sınırları esnetildi.

- JWT (JSON Web Token) kimlik doğrulaması entegre edildi.

- Fluent Validation ile validasyon(doğrulama) işlemleri geliştirildi.

- IoC(Inversion Of Control) ile (loose coupling) olan nesneler oluşturuldu.

- REST VE RESTFUL WEB SERVİS ile sunucu-istemci iletişimi sağlandı.
# Frontend tarafı Angular geliştirme yapıldı link
- https://github.com/firnox61/rentacar-frontend-new
