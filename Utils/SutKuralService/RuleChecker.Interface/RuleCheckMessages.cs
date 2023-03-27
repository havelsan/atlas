using System;
using System.Collections.Generic;
using System.Text;

namespace RuleChecker.Interface
{
    public class RuleCheckMessages
    {
        public static readonly RuleCheckMessage BirlikteFaturalandirmaUyarisi = new RuleCheckMessage() { Code = 1000, Message = "\"{0}\" bu hizmeti girebilmek için aşağıdaki işlemlerden biri girilmiş olmalıdır:  {1}" };
        public static readonly RuleCheckMessage BirlikteFaturalanmazMesaji = new RuleCheckMessage() { Code = 1001, Message = "\"{0}\" bu hizmet \"{1}\" ile birlikte faturalanamaz" };
        public static readonly RuleCheckMessage BransUygunDegil = new RuleCheckMessage() { Code = 1002, Message = "\"{0}\" bu hizmet sadece aşağıdaki branşlardan birine girilmeli: {1}" };
        public static readonly RuleCheckMessage CinsiyetSinirlamasiUyarisi = new RuleCheckMessage() { Code = 1003, Message = "\"{0}\" bu hizmet sadece cinsiyeti {1} olan hastalara girilebilir." };
        public static readonly RuleCheckMessage GerekliTaniBulunamadi = new RuleCheckMessage() { Code = 1004, Message = "\"{0}\" bu hizmetle birlikte listesi verilen tanılardan biri gerekliydi, lütfen uygun tanıyı ekleyiniz." };
        public static readonly RuleCheckMessage IliskiliTanimUyarisi = new RuleCheckMessage() { Code = 1005, Message = "\"{0}\" bu hizmet için bunlardan birini girebilirsiniz: {1}" };
        public static readonly RuleCheckMessage KosulluIslemTekrariUyarisi = new RuleCheckMessage() { Code = 1006, Message = "\"{0}\" bu hizmet için {1} koşulunda {2} adet ile sınırlandırılmıştır, lütfen kontrol ediniz" };
        public static readonly RuleCheckMessage OmurBoyuAdetGecildi = new RuleCheckMessage() { Code = 1007, Message = "\"{0}\" bu hizmet için ömür boyu yapılabilme sınırı aşıldı" };
        public static readonly RuleCheckMessage OrtodontiMinimumPaketGecildi = new RuleCheckMessage() { Code = 1008, Message = "\"{0}\" bu paket \"{1}\". girişi en az \"{2}\" ay ara ile girilebilir" };
        public static readonly RuleCheckMessage OrtodontiPaketGirisYapilamaz = new RuleCheckMessage() { Code = 1009, Message = "\"{0}\" bu hizmet ömür boyu bir defa verilebilir." };
        public static readonly RuleCheckMessage SureBoyuAdetGecildi = new RuleCheckMessage() { Code = 1010, Message = "\"{0}\" bu hizmet için {1} gün içinde max {2} adet yapılabilir sınırı aşıldı" };
        public static readonly RuleCheckMessage TedaviBoyuAdetGecildi = new RuleCheckMessage() { Code = 1011, Message = "\"{0}\" bu hizmet için tedavi boyunca yapılabilecek adet geçildi" };
        public static readonly RuleCheckMessage YasSiniriAsildi = new RuleCheckMessage() { Code = 1000, Message = "\"{0}\" bu hizmet için \"{1} ay\" ila \"{2} ay\" yaş sınırı belirlenmiş, bu hasta yaşı ({3}) bu sınırında dışında" };
        
        public static string GetFormattedMessage(RuleCheckMessage message, params object[] args)
        {
            return string.Format(message.Message, args);
        }
    }
}
