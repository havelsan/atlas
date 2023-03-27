using RuleChecker.Interface;
using System;
using System.Linq;
using System.Xml.Serialization;
using TTUtils.Entities;

namespace RuleChecker.Engine.RuleCheckers
{
    [XmlRoot(RuleXmlTag.Rule5)]
    public partial class Rule5 : IRule, IRuleChecker
    {
        [XmlAttribute(RuleXmlTag.ObjectId)]
        public Guid ObjectId { get; set; }

        [XmlAttribute(RuleXmlTag.GroupId)]
        public Guid GroupId { get; set; }

        [XmlElement(RuleXmlTag.ProcedureCode)]
        public string ProcedureCode { get; set; }

        [XmlElement(RuleXmlTag.MinAge)]
        public int MinAge { get; set; }

        [XmlElement(RuleXmlTag.MaxAge)]
        public int MaxAge { get; set; }

        [XmlIgnore]
        public bool BlockRequest { get; set; }

        [XmlIgnore]
        public bool Active { get; set; }

        // Yaş kontrolu
        public void CheckRule(RuleCheckParameters ruleCheckParameters, Action<RuleViolateMessage> callback)
        {
            var detailList = ruleCheckParameters.DetailList;

            var detail1 = detailList.Where(d => d.ProcedureCode == ProcedureCode).FirstOrDefault();

            if (detail1 == null)
                return;

            var patientInfo = ruleCheckParameters.PatientInfo;

            var filteredDetailList = detailList.Where(d => d.ProcedureCode == ProcedureCode);

            foreach (var detail2 in filteredDetailList)
            {
                if (!(patientInfo.AgeMonth >= MinAge && patientInfo.AgeMonth <= MaxAge))
                {
                    var message = string.Format(RuleCheckMessages.YasSiniriAsildi.Message, detail2.ProcedureName, MinAge, MaxAge, patientInfo.Age);

                    var messageDto = new RuleViolateMessage(ObjectId, GroupId, detail2.RequestDate, ProcedureCode, message, BlockRequest);
                    messageDto.DetailId1 = detail2.DetailId;
                    callback(messageDto);
                }
            }
        }

    }

}
