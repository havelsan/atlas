
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;



using TTStorageManager;
using System.Runtime.Versioning;


namespace TTObjectClasses
{
    public partial class InfluenzaServis : TTObject, IRestServiceObject
    {
        public IRestCallParameters GetRestCallParameters(string methodName, HttpVerbMethod httpVerb)
        {
            var restCallParamaters = new TTUtils.RestCallParameters();


            string password = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICISIFRESI", "");
            System.Security.Cryptography.SHA1 sha = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            string hex = BitConverter.ToString(sha.ComputeHash(enc.GetBytes(password)));
            hex = hex.Replace("-", "");

            restCallParamaters.Headers = new Dictionary<string, string>();
            restCallParamaters.Headers.Add("username", TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKULLANICIADI", ""));
            restCallParamaters.Headers.Add("password", hex);
            restCallParamaters.Headers.Add("uygulamakodu", TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETERISIMKODU", "XXXXXX"));
            var baseAddress = "http://xxxxxx.com/api/AkilciAntibiyotikInflenza/";
            restCallParamaters.HttpVerb = httpVerb;
            restCallParamaters.MethodUrl = $"{baseAddress}/{methodName}";
            return restCallParamaters;
        }

        public static partial class WebMethods
        {
            public static InfluenzaTaniBilgisi UrunSorgulaSync_ServerSide2()
            {
                InfluenzaTaniBilgisi i = new InfluenzaTaniBilgisi();
                string _siteId = TTObjectClasses.SystemParameter.GetParameterValue("SITEID", "");
                ServiceResult result = WebMethods.SaveInfluenzaTaniTestSync(new Guid(_siteId), i);
                return null;
            }

            [Serializable]
            public class InfluenzaTaniBilgisi
            {
                public bool? aileHekimligindeMi { get; set; }
                public AntijenTestiSonuclari? AntijenTesti { get; set; }
                public string HastaTC { get; set; }
                public int? HastaYasi { get; set; }
                public string HekimTC { get; set; }
                public string ICD10Kodu { get; set; }
                public string IslemGuid { get; set; }
            }

            public enum AntijenTestiSonuclari
            {
                Belirtilmemis = 0,
                Pozitif = 1,
                Negatif = 2
            }

            public class ServiceResult
            {
                public ServisSonucDurumu State { get; set; }
                public string Message { get; set; }
                public string Result { get; set; }
            }
            public enum ServisSonucDurumu
            {
                HATA = 0,
                BASARILI = 1,
                UYARI = 2
            }
        }
    }
}