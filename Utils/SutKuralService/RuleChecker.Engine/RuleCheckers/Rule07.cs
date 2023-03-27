using RuleChecker.Interface;
using RuleChecker.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using TTUtils.Entities;

namespace RuleChecker.Engine.RuleCheckers
{
    [XmlRoot(RuleXmlTag.Rule7)]
    public partial class Rule7 : IRule, IRuleChecker
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

        private IEnumerable<string> Icd10ListesiDerle(RuleCheckParameters ruleCheckParameters)
        {
            var icd10List = ruleCheckParameters.Icd10Repository.Icd10List(); 

            var expandedIcd10List = new List<string>();

            foreach (var icd10 in this.Icd10List)
            {
                expandedIcd10List.Add(icd10);

                if (Regex.IsMatch(icd10, @"^\w{3}$"))
                {
                    var pattern = string.Format(@"{0}.\w", icd10);

                    var query1 = from i in icd10List
                                 where Regex.IsMatch(i.Code, pattern)
                                 select i;

                    expandedIcd10List.AddRange(query1.Select(i => i.Code).ToArray());
                }
            }

            return expandedIcd10List;
        }

        // Tanı veya endikasyon koşolu
        public void CheckRule(RuleCheckParameters ruleCheckParameters, Action<RuleViolateMessage> callback)
        {
            var detaylar = ruleCheckParameters.DetailList;

            var detay1 = detaylar.Where(d => d.ProcedureCode == this.ProcedureCode).FirstOrDefault();

            if (detay1 == null)
                return;

            var icd10Listesi = Icd10ListesiDerle(ruleCheckParameters);

            // tanımdaki listede bulunan tanılarında en az biri
            // hastaya girilmiş ise yeterli
            foreach (var icd10 in icd10Listesi)
            {
                if (ruleCheckParameters.PatientIcd10DiagnosisList.Contains(icd10))
                {
                    return;
                }
            }

            // tüm tanılara bakıldı hiçbirini içermiyor, sorun var

            var gerekliTanilar = string.Join(", ", this.Icd10List.ToArray());

            var mesaj = string.Format(RuleCheckMessages.GerekliTaniBulunamadi.Message, detay1.ProcedureName, gerekliTanilar);

            var mesajDto = new RuleViolateMessage(ObjectId, GroupId, detay1.RequestDate, ProcedureCode, mesaj, Icd10List, BlockRequest);
            mesajDto.DetailId1 = detay1.DetailId;
            callback(mesajDto);
        }

    }

}
