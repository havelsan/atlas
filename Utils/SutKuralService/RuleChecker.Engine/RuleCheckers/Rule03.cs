using RuleChecker.Interface;
using RuleChecker.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using TTUtils.Entities;

namespace RuleChecker.Engine.RuleCheckers
{
    [XmlRoot(RuleXmlTag.Rule3)]
    public partial class Rule3 : IRule, IRuleChecker
    {
        [XmlAttribute(RuleXmlTag.ObjectId)]
        public Guid ObjectId { get; set; }

        [XmlAttribute(RuleXmlTag.GroupId)]
        public Guid GroupId { get; set; }

        [XmlElement(RuleXmlTag.ProcedureCode)]
        public string ProcedureCode { get; set; }

        [XmlElement(RuleXmlTag.NumOfDays)]
        public int NumOfDays { get; set; }

        [XmlElement(RuleXmlTag.MaxQuantity)]
        public int MaxQuantity { get; set; }

        [XmlIgnore]
        public bool BlockRequest { get; set; }

        [XmlIgnore]
        public bool Active { get; set; }


        private void TimedQuantityCheck(RuleCheckParameters ruleCheckParameters, Action<RuleViolateMessage> callback)
        {
            var query1 = from d in ruleCheckParameters.DetailList
                         where d.ProcedureCode == this.ProcedureCode
                         orderby d.RequestDate descending
                         select d;

            var ruleCheckDate = ruleCheckParameters.RuleCheckDate.Date;

            var groupList = new List<List<ProcedureRequestDetailDto>>();

            var detailList = new List<ProcedureRequestDetailDto>();

            foreach (var detail1 in query1)
            {

                var diff = detail1.RequestDate.Date - ruleCheckDate.Date;

                if (Math.Abs(diff.Days) >= this.NumOfDays)
                {
                    groupList.Add(detailList);
                    detailList = new List<ProcedureRequestDetailDto>();
                    ruleCheckDate = detail1.RequestDate.Date;
                }

                detailList.Add(detail1);
            }

            groupList.Add(detailList);

            foreach (var grup in groupList)
            {
                var timedQuantity = grup.Sum(d => d.Quantity);

                if (timedQuantity > this.MaxQuantity)
                {
                    var detail2 = grup.FirstOrDefault();

                    var message = string.Format(RuleCheckMessages.SureBoyuAdetGecildi.Message, detail2.ProcedureName, NumOfDays, MaxQuantity);

                    var messageDto = new RuleViolateMessage(ObjectId, GroupId, detail2.RequestDate, ProcedureCode, message, BlockRequest);
                    messageDto.DetailId1 = detail2.DetailId;
                    callback(messageDto);
                }
            }
        }

        //Periyodik Gün Sınırı ve İşlem Günlük Adedi
        public void CheckRule(RuleCheckParameters ruleCheckParameters, Action<RuleViolateMessage> callback)
        {
            var detailList = ruleCheckParameters.DetailList;

            var filteredDetailList = detailList.Where(d => d.ProcedureCode == this.ProcedureCode);

            //foreach (var detail1 in filteredDetailList)
            //{

                //// Ömür boyu n adet koşulu varsa sadece bizdeki kayıtlar bu kriteri karşılıyorsa uyarı verilecek
                //if (this.LifeTimeMaxQuantity > 0)
                //{
                //    //TODO: Rule03 için LifeTimeMaxQuantity koşulunda sorun var. 
                //    //Sorgusu amount ları toplayıp getirmiyor. 
                //    //Ayrıca newEntries amount larıda toplama dahil edilmiyor.
                //    LifeTimeQuantityCheck(ruleCheckParameters, callback, detail1);
                //    continue;
                //}

                // TODO: Alttaki satır kontrol edilecek neden döngünün içinde yer alıyor???
                // var kuralDetaylari = detailList.Where(d => d.ProcedureCode == this.ProcedureCode);

                //var toplamAdet = filteredDetailList.Sum(d => d.Quantity);

                //// Tedavi boyunca n adet, sınır geçilmişse uyarı iletilecek
                //if (this.TreatmentMaxQuantity > 0 && toplamAdet > this.TreatmentMaxQuantity)
                //{
                //    var mesaj = string.Format(RuleCheckMessages.TedaviBoyuAdetGecildi.Message, detail1.ProcedureName);

                //    var mesajDto = new RuleViolateMessage(ObjectId, GroupId, ProcedureCode, mesaj, this.BlockRequest);
                //    mesajDto.DetailId1 = detail1.DetailId;
                //    callback(mesajDto);
                //    continue;
                //}

                // belirli bir gün süresinde n adet kontrolu
                if (this.NumOfDays > 0 && this.MaxQuantity > 0)
                {
                    TimedQuantityCheck(ruleCheckParameters, callback);
                }
            //}

        }

    }

}
