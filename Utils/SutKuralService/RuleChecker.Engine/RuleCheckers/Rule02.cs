using RuleChecker.Interface;
using RuleChecker.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using TTUtils.Entities;

namespace RuleChecker.Engine.RuleCheckers
{
    [XmlRoot(RuleXmlTag.Rule2)]
    public partial class Rule2 : IRule, IRuleChecker
    {
        [XmlAttribute(RuleXmlTag.ObjectId)]
        public Guid ObjectId { get; set; }

        [XmlAttribute(RuleXmlTag.GroupId)]
        public Guid GroupId { get; set; }

        [XmlElement(RuleXmlTag.ProcedureCode)]
        public string ProcedureCode { get; set; }

        [XmlArray(RuleXmlTag.BranchCodes)]
        [XmlArrayItem(RuleXmlTag.BanchCode)]
        public List<string> BranchCodes { get; set; }

        [XmlIgnore]
        public bool BlockRequest { get; set; }

        [XmlIgnore]
        public bool Active { get; set; }

        // Branş kodu uyumluluğu kontrol
        // İlgili sut sadece tanımda belirtilen branş ile faturalandırılmalı
        // Aksi durumda uyarı mesajı üretilecek
        public void CheckRule(RuleCheckParameters ruleCheckParameters, Action<RuleViolateMessage> callback)
        {
            var detailList = ruleCheckParameters.DetailList;

            var detail1 = detailList.Where(d => d.ProcedureCode == this.ProcedureCode).FirstOrDefault();

            if (detail1 == null)
                return;

            var episodeInfo = ruleCheckParameters.EpisodeInfo;

            var checkBranchCode = string.IsNullOrEmpty(detail1.BranchCode) ? episodeInfo.BranchCode : detail1.BranchCode;

            if (!this.BranchCodes.Contains(checkBranchCode))
            {
                var bransListe = ruleCheckParameters.BranchRepository.BranchList(this.BranchCodes);

                var branchNames = string.Join("; ", bransListe.Select(b => b.Name).ToArray());

                var message = string.Format(RuleCheckMessages.BransUygunDegil.Message, detail1.ProcedureName, branchNames);

                var messageDto = new RuleViolateMessage(ObjectId, GroupId, detail1.RequestDate, ProcedureCode, message, BlockRequest);
                messageDto.DetailId1 = detail1.DetailId;
                callback(messageDto);
            }
        }

    }
}
