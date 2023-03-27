using RuleChecker.Interface;
using RuleChecker.Interface.Entities;
using System;
using System.Xml.Serialization;
using TTUtils.Entities;

namespace RuleChecker.Engine.RuleCheckers
{
    [XmlRoot(RuleXmlTag.Rule6)]
    public partial class Rule6 : IRule, IRuleChecker
    {
        [XmlAttribute(RuleXmlTag.ObjectId)]
        public Guid ObjectId { get; set; }

        [XmlAttribute(RuleXmlTag.GroupId)]
        public Guid GroupId { get; set; }

        [XmlElement(RuleXmlTag.ProcedureCode)]
        public string ProcedureCode { get; set; }

        [XmlElement(RuleXmlTag.DocumentType)]
        public string DocumentType { get; set; }

        [XmlIgnore]
        public bool BlockRequest { get; set; }

        [XmlIgnore]
        public bool Active { get; set; }

        // Ekinde belge istenmektedir
        // hizmet girişinde kontrolü uygun değil
        // faturada ileti olarak verilecek
        public void CheckRule(RuleCheckParameters ruleCheckParameters, Action<RuleViolateMessage> callback)
        {

        }

    }

}
