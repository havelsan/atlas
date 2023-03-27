using RuleChecker.Interface;
using RuleChecker.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using TTUtils.Entities;

namespace RuleChecker.Engine.RuleCheckers
{
    [XmlRoot(RuleXmlTag.Rule15)]
    public partial class Rule15 : IRule, IRuleChecker
    {
        [XmlAttribute(RuleXmlTag.ObjectId)]
        public Guid ObjectId { get; set; }

        [XmlAttribute(RuleXmlTag.GroupId)]
        public Guid GroupId { get; set; }

        [XmlElement(RuleXmlTag.ProcedureCode)]
        public string ProcedureCode { get; set; }

        [XmlArray(RuleXmlTag.ProcedureList)]
        [XmlArrayItem(RuleXmlTag.ProcedureCode)]
        public List<string> ProcedureList { get; set; }

        [XmlIgnore]
        public bool BlockRequest { get; set; }

        [XmlIgnore]
        public bool Active { get; set; }

        // İlişkili tanımları var
        // geneli ifade eden bir sut girilirken daha özelleşmiş bir hali varsa kullanıcıyı
        // uyarmak bunlardan birini girmek mi istiyordu acaba
        public void CheckRule(RuleCheckParameters ruleCheckParameters, Action<RuleViolateMessage> callback)
        {
            var detailList = ruleCheckParameters.DetailList;

            var detail1 = detailList.Where(d => d.ProcedureCode == this.ProcedureCode).FirstOrDefault();

            if (detail1 == null)
                return;

            var procedureList = ruleCheckParameters.ProcedureRepository.ProcedureList(this.ProcedureList);

            var relatedProcedures = string.Join(System.Environment.NewLine, procedureList.Select(p => p.Name).ToArray());

            var message = string.Format(RuleCheckMessages.IliskiliTanimUyarisi.Message, detail1.ProcedureName, relatedProcedures);

            var messageDto = new RuleViolateMessage(ObjectId, GroupId, detail1.RequestDate, ProcedureCode, message, BlockRequest);
            messageDto.DetailId1 = detail1.DetailId;
            callback(messageDto);

        }

    }

}
