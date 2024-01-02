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
        public static string BuyAccepted="Satış kabul edilid";

        public static string BuyReject = "Arabanın kiralanabilmesi için arabanın teslim edilmesi gerekmektedir.";
        public static string CarDelete="Araba silinmiştir";
        public static string HataSonuc="Hatalı işlem";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "pasaword hatalı";
        public static string AccessTokenCreated = "Token oluşturuldu";
        public static string AuthorizationDenied = "Yetkiniz Yok";
        public const string FileNotFound = "Dosya bulunamadı";
    }
}
