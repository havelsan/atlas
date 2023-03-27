using System.Xml.Serialization;

namespace RuleChecker.Interface.Entities
{
    public class NthRequestMonth
    {
        [XmlElement(RuleXmlTag.NthRequest)]
        public int NthRequest { get; set; }

        [XmlElement(RuleXmlTag.MinMonths)]
        public int MinMonths { get; set; }

    }
}
