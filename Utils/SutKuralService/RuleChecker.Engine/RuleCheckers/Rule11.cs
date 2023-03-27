using RuleChecker.Interface;
using RuleChecker.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using TTUtils.Entities;

namespace RuleChecker.Engine.RuleCheckers
{
    [XmlRoot(RuleXmlTag.Rule11)]
    public partial class Rule11 : IRule, IRuleChecker
    {
        [XmlAttribute(RuleXmlTag.ObjectId)]
        public Guid ObjectId { get; set; }

        [XmlAttribute(RuleXmlTag.GroupId)]
        public Guid GroupId { get; set; }

        [XmlElement(RuleXmlTag.ProcedureCode)]
        public string ProcedureCode { get; set; }

        [XmlArray(RuleXmlTag.Icd10List)]
        [XmlArrayItem(RuleXmlTag.Icd10)]
        public List<string> Icd10List { get; set; }

        [XmlIgnore]
        public bool BlockRequest { get; set; }

        [XmlIgnore]
        public bool Active { get; set; }

        // Fizik tedavi ve rehabilitasyon paketleri için tanı koşulları
        public void CheckRule(RuleCheckParameters ruleCheckParameters, Action<RuleViolateMessage> callback)
        {
            var detailList = ruleCheckParameters.DetailList;

            var detail1 = detailList.Where(d => d.ProcedureCode == this.ProcedureCode).FirstOrDefault();

            if (detail1 == null)
                return;
            // tanımdaki listede bulunan tanılarında en az biri
            // hastaya girilmiş ise yeterli
            foreach (var icd10 in this.Icd10List)
            {
                if (ruleCheckParameters.PatientIcd10DiagnosisList.Contains(icd10))
                {
                    return;
                }
            }

            // tüm tanılara bakıldı hiçbirini içermiyor, sorun var
            var requiredIcd10Codes = string.Join(", ", this.Icd10List.ToArray());

            var message = string.Format(RuleCheckMessages.GerekliTaniBulunamadi.Message, detail1.ProcedureName, requiredIcd10Codes);
            var messageDto = new RuleViolateMessage(ObjectId, GroupId, detail1.RequestDate, ProcedureCode, message, Icd10List, BlockRequest);
            messageDto.DetailId1 = detail1.DetailId;
            callback(messageDto);

        }
    }

}
