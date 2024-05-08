using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba Eklendi";
        public static string CarNameInvalid="Geçersiz araba ismi";
        public static string CarListed="Araçlar Listelendi";
        public static string CarFindBrand="Araç markası bulundu";
        public static string CarFind = "Araç bulundu";
        public static string BuyAccepted="Satış kabul edilidi";
        public static string CustomerNot = "Müşteri bulunamadı";

        public static string BuyReject = "Arabanın kiralanabilmesi için arabanın teslim edilmesi gerekmektedir.";
        public static string CarDelete="Araba silinmiştir";
        public static string HataSonuc="Hatalı işlem";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "pasaword hatalı";
        public static string AccessTokenCreated = "Token oluşturuldu";
        public static string AuthorizationDenied = "Yetkiniz Yok";
        public static string TarihHata = "Bu tarihlerde Araç Dolu";
        public static string TarihUygun="Bu tarih aralğı uygun";
        public static string PaymentDelete="Ödeme Silindi.";


        public static string UserRegistered = "Kullanıcı kayıt oldu";

        public static string SuccessfulLogin = "Başarılı kayıt";
        public static string UserAlreadyExists = "kullanıcı mevcut";

        public static string SuccessfulLog = "Başarılı bir giriş yapıldı";
        public static string FindexAccepted= "Findex puanı araç kiralamaya yeterli";
        public static string FindexRejected = "Findex puanı araç kiralamaya yetersiz";
        public static string CarFindColor="Belirlenen renkteki araçlar listelendi";
        public static string CarByIdShow="Belirlenen araç getirildi";
        public static string CarDetailShow=" Araçların detayları getirildi";
        public static string CarDetailIdShow= "Belirlenen aracın detayları getirildi";
        public static string? CarPriceInvalid="Araç fiyatı geçersiz";
        public static string CarDetailListedBrandAndColor= "Belirlenen marka ve renkde araçların detayları getirildi";
        public static string ColorListed="Renkler listelendi";
        public static string ColorByListed="Belirlenen renk getirildi";
        public static string ColorUpdate= "Renk güncellendi";
        public static string CustomerAdded="Müşteri eklendi";
        public static string CustomerDelete = "Müşteri silindi";
        public static string CustomerListed = "Müşteriler listelendi";
        public static string CustomerGet = "Müşteri getirildi";
        public static string CustomerUpdate = "Müşteri güncellendi";
        public static object BuyError="Kart bilgilerinde hata var kontrol ediniz";
        public static string UserInfo="Kullanıcı Bilgiler;";
        public static string UserUpdate="Kullanıcı bilgileri güncellendi";
    }
}
