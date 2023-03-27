using RuleChecker.Interface;
using RuleChecker.Interface.Entities;
using System;
using System.Linq;
using System.Xml.Serialization;
using TTUtils.Entities;

namespace RuleChecker.Engine.RuleCheckers
{
    [XmlRoot(RuleXmlTag.Rule1)]
    public partial class Rule1 : IRule, IRuleChecker
    {
        [XmlAttribute(RuleXmlTag.ObjectId)]
        public Guid ObjectId { get; set; }

        [XmlAttribute(RuleXmlTag.GroupId)]
        public Guid GroupId { get; set; }

        [XmlElement(RuleXmlTag.ProcedureCode)]
        public string ProcedureCode { get; set; }

        [XmlElement(RuleXmlTag.ProcedureCode2)]
        public string ProcedureCode2 { get; set; }

        [XmlIgnore]
        public bool BlockRequest { get; set; }

        [XmlIgnore]
        public bool Active { get; set; }

        // Birlikte fatura edilme sınırlaması
        // Sut Kodu ve ikinci sut kodu birlikte aynı başvuruda bulunmamlı
        public void CheckRule(RuleCheckParameters ruleCheckParameters, Action<RuleViolateMessage> callback)
        {
            var detailList = ruleCheckParameters.DetailList;
            
            var detail1 = detailList.Where(d => d.ProcedureCode == this.ProcedureCode).FirstOrDefault();

            var detail2 = detailList.Where(d => d.ProcedureCode == this.ProcedureCode2).FirstOrDefault();

            if (detail1 != null && detail2 != null)
            {
                var message = string.Format(RuleCheckMessages.BirlikteFaturalanmazMesaji.Message, detail1.ProcedureName, detail2.ProcedureName);

                var messageDto = new RuleViolateMessage(ObjectId, GroupId, detail1.RequestDate, ProcedureCode, message, BlockRequest);
                messageDto.DetailId1 = detail1.ProcedureCode;
                messageDto.DetailId2 = detail2.ProcedureCode;
                callback(messageDto);
            }
        }

    }
}
