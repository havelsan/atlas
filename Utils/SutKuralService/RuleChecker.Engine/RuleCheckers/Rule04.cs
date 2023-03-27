using RuleChecker.Interface;
using RuleChecker.Interface.Entities;
using System;
using System.Xml.Serialization;
using TTUtils.Entities;

namespace RuleChecker.Engine.RuleCheckers
{
    [XmlRoot(RuleXmlTag.Rule4)]
    public partial class Rule4 : IRule, IRuleChecker
    {
        [XmlAttribute(RuleXmlTag.ObjectId)]
        public Guid ObjectId { get; set; }

        [XmlAttribute(RuleXmlTag.GroupId)]
        public Guid GroupId { get; set; }

        [XmlElement(RuleXmlTag.ProcedureCode)]
        public string ProcedureCode { get; set; }

        [XmlElement(RuleXmlTag.EstablishmentType)]
        public string EstablishmentType { get; set; }

        [XmlIgnore]
        public bool BlockRequest { get; set; }

        [XmlIgnore]
        public bool Active { get; set; }

        public void CheckRule(RuleCheckParameters ruleCheckParameters, Action<RuleViolateMessage> callback)
        {
            
        }

    }

}
