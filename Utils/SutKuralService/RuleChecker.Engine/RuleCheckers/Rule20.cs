using RuleChecker.Interface;
using System;
using System.Linq;
using System.Xml.Serialization;
using TTUtils.Entities;

namespace RuleChecker.Engine.RuleCheckers
{
    [XmlRoot(RuleXmlTag.Rule20)]
    public class Rule20 : IRule, IRuleChecker
    {
        [XmlAttribute(RuleXmlTag.ObjectId)]
        public Guid ObjectId { get; set; }

        [XmlAttribute(RuleXmlTag.GroupId)]
        public Guid GroupId { get; set; }

        [XmlElement(RuleXmlTag.ProcedureCode)]
        public string ProcedureCode { get; set; }

        [XmlElement(RuleXmlTag.TreatmentMaxQuantity)]
        public int TreatmentMaxQuantity { get; set; }

        [XmlIgnore]
        public bool BlockRequest { get; set; }

        [XmlIgnore]
        public bool Active { get; set; }

        //Kabul Bazlı İşlem Adedi	
        public void CheckRule(RuleCheckParameters ruleCheckParameters, Action<RuleViolateMessage> callback)
        {
            var detailList = ruleCheckParameters.DetailList;

            var filteredDetailList = detailList.Where(d => d.ProcedureCode == this.ProcedureCode);

            if (filteredDetailList.Count() > 0)
            {
                var toplamAdet = filteredDetailList.Sum(d => d.Quantity);

                var detail1 = filteredDetailList.FirstOrDefault();
                // Tedavi boyunca n adet, sınır geçilmişse uyarı iletilecek
                if (this.TreatmentMaxQuantity > 0 && toplamAdet > this.TreatmentMaxQuantity)
                {
                    var mesaj = string.Format(RuleCheckMessages.TedaviBoyuAdetGecildi.Message, detail1.ProcedureName);

                    var mesajDto = new RuleViolateMessage(ObjectId, GroupId, detail1.RequestDate, ProcedureCode, mesaj, BlockRequest);
                    mesajDto.DetailId1 = detail1.DetailId;
                    callback(mesajDto);
                }
            }
        }
    }
}
