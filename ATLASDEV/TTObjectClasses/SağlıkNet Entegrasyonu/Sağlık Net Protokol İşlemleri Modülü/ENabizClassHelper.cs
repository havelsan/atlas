using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTObjectClasses
{
    public class Utf8StringWriter : System.IO.StringWriter
    {
        public override Encoding Encoding { get { return Encoding.UTF8; } }
    }
    public class messageGuid : ValueBase
    {
        public messageGuid()
        {
            value = Guid.NewGuid().ToString();
        }
    }

    public class documentGenerationTime : ValueBase
    {
        public documentGenerationTime()
        {
            value = DateTime.Now.ToString("yyyyMMddHHmm");
        }
    }
    public class healthcareProvider : CodeBase
    {
        public healthcareProvider()
        {
            codeSystemGuid = "c3eade04-4f91-5dab-e043-14031b0ac9f9";
            version = "1";

        }

        public healthcareProvider(string Code, string Value)
        {
            codeSystemGuid = "c3eade04-4f91-5dab-e043-14031b0ac9f9";
            version = "1";
            code = Code;
            value = Value;

        }
    }
    public class author
    {
        public healthcareProvider healthcareProvider;
        public author()
        {
            SKRSKurumlar myTesisSKRSKurumlarDefinition = SKRSKurumlar.GetMyTesisSKRSKurumlarDefinition();
            healthcareProvider = new healthcareProvider(myTesisSKRSKurumlarDefinition.KODU.ToString(), myTesisSKRSKurumlarDefinition.ADI);
        }

    }

    public class firmaKodu : ValueBase
    {
        public firmaKodu()
        {

            value = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETERISIMKODU", "XXXXXX").ToString(); //"C740D0288F1DC45FE0407C0A04162BDD" test XXXXXX

        }
    }
    public class CodeBase
    {
        [System.Xml.Serialization.XmlAttribute("version")]
        public string version { get; set; }

        [System.Xml.Serialization.XmlAttribute("codeSystemGuid")]
        public string codeSystemGuid { get; set; }

        [System.Xml.Serialization.XmlAttribute("code")]
        public string code { get; set; }

        [System.Xml.Serialization.XmlAttribute("value")]
        public string value { get; set; }
    }

    public class ValueBase
    {
        [System.Xml.Serialization.XmlAttribute("value")]
        public string value { get; set; }

        public ValueBase()
        {
            value = "";
        }
    }

    public enum ISLEMTURU
    {
        ISLEM = 1,
        ILAC = 2,
        MALZEME = 3
    }
}
