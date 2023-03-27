using RuleChecker.Interface;
using RuleChecker.Interface.Entities;
using System;
using System.Xml.Serialization;
using TTUtils.Entities;

namespace RuleChecker.Engine.RuleCheckers
{
    [XmlRoot(RuleXmlTag.Rule10)]
    public partial class Rule10 : IRule, IRuleChecker
    {
        [XmlAttribute(RuleXmlTag.ObjectId)]
        public Guid ObjectId { get; set; }

        [XmlAttribute(RuleXmlTag.GroupId)]
        public Guid GroupId { get; set; }

        [XmlElement(RuleXmlTag.ProcedureCode)]
        public string ProcedureCode { get; set; }

        [XmlElement(RuleXmlTag.Icd10)]
        public string Icd10 { get; set; }

        [XmlElement(RuleXmlTag.Indication)]
        public string Indication { get; set; }

        [XmlElement(RuleXmlTag.FirstDispatchSeance)]
        public int IlkSevkteSeans { get; set; }

        [XmlElement(RuleXmlTag.MaxTotalSeance)]
        public int MaxTotalSession { get; set; }

        [XmlIgnore]
        public bool BlockRequest { get; set; }

        [XmlIgnore]
        public bool Active { get; set; }

        public void CheckRule(RuleCheckParameters ruleCheckParameters, Action<RuleViolateMessage> callback)
        {
            //Hiperbarik oksijen tedavisi için tanı koşulu
        }

    }

}
