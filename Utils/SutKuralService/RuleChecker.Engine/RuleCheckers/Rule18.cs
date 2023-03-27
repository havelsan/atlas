using RuleChecker.Interface;
using RuleChecker.Interface.Entities;
using System;
using System.Linq;
using System.Xml.Serialization;
using TTUtils.Entities;

namespace RuleChecker.Engine.RuleCheckers
{
    [XmlRoot(RuleXmlTag.Rule18)]
    public partial class Rule18 : IRule, IRuleChecker
    {
        [XmlAttribute(RuleXmlTag.ObjectId)]
        public Guid ObjectId { get; set; }

        [XmlAttribute(RuleXmlTag.GroupId)]
        public Guid GroupId { get; set; }

        [XmlElement(Interface.RuleXmlTag.ProcedureCode)]
        public string ProcedureCode { get; set; }

        [XmlElement(RuleXmlTag.Gender)]
        public string Gender { get; set; }

        [XmlIgnore]
        public bool BlockRequest { get; set; }

        [XmlIgnore]
        public bool Active { get; set; }

        // Cinsiyet sınırlaması
        public void CheckRule(RuleCheckParameters ruleCheckParameters, Action<RuleViolateMessage> callback)
        {
            var detailList = ruleCheckParameters.DetailList;

            var detail1 = detailList.Where(d => d.ProcedureCode == this.ProcedureCode).FirstOrDefault();

            if (detail1 == null)
                return;

            var patientInfo = ruleCheckParameters.PatientInfo;

            if (this.Gender != patientInfo.Gender)
            {
                var message = string.Format(RuleCheckMessages.CinsiyetSinirlamasiUyarisi.Message, detail1.ProcedureName, Gender);
                var messageDto = new RuleViolateMessage(ObjectId, GroupId, detail1.RequestDate, ProcedureCode, message, BlockRequest);
                messageDto.DetailId1 = detail1.DetailId;
                callback(messageDto);
            }
        }

    }

}
