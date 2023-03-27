using RuleChecker.Interface;
using RuleChecker.Interface.Entities;
using System;
using System.Linq;
using System.Xml.Serialization;
using TTUtils.Entities;

namespace RuleChecker.Engine.RuleCheckers
{
    [XmlRoot(RuleXmlTag.Rule17)]
    public partial class Rule17 : IRule, IRuleChecker
    {
        [XmlAttribute(RuleXmlTag.ObjectId)]
        public Guid ObjectId { get; set; }

        [XmlAttribute(RuleXmlTag.GroupId)]
        public Guid GroupId { get; set; }

        [XmlElement(RuleXmlTag.ProcedureCode)]
        public string ProcedureCode { get; set; }

        [XmlElement(RuleXmlTag.LifeTimeMaxQuantity)]
        public int LifeTimeMaxQuantity { get; set; }

        //[XmlElement(RuleXmlTag.SupplementalCondition1)]
        //public string SupplementalCondition1 { get; set; }

        [XmlIgnore]
        public bool BlockRequest { get; set; }

        [XmlIgnore]
        public bool Active { get; set; }


        // Ömür boyu adet kontrolu
        // hastanın tüm gelişleri içinde bir defa bile varsa ileti verilir
        private void LifeTimeQuantityCheck(RuleCheckParameters ruleCheckParameters, Action<RuleViolateMessage> callback, ProcedureRequestDetailDto kontrolDetay)
        {
            var patientProcedureRepository = ruleCheckParameters.PatientProcedureRepository;

            var patientInfo = ruleCheckParameters.PatientInfo;

            var detailList = patientProcedureRepository.PatientProcedureList(patientInfo.PatientId, this.ProcedureCode).ToList();
            if(ruleCheckParameters.NewEntries != null)
                detailList.AddRange(ruleCheckParameters.NewEntries);
            //Yeni ve öncekiler
            decimal totalNumberOfProcedure = detailList.Where(x => x.ProcedureCode == this.ProcedureCode).Sum(x => x.Quantity);

            if (totalNumberOfProcedure > this.LifeTimeMaxQuantity)
            {
                var procedure = detailList.FirstOrDefault(x => x.ProcedureCode == this.ProcedureCode);
                var message = string.Format(RuleCheckMessages.OmurBoyuAdetGecildi.Message, procedure.ProcedureName);

                var ruleMessage = new RuleViolateMessage(ObjectId, GroupId, procedure.RequestDate, ProcedureCode, message, BlockRequest);

                ruleMessage.DetailId1 = procedure.DetailId;

                callback(ruleMessage);
            }
        }


        // İşlem tekrarı süre sınırlaması
        // süreden faturadan bağımsız sınırlama
        // program kontrol edemez
        // kullanıcı dikkat etmeli
        public void CheckRule(RuleCheckParameters ruleCheckParameters, Action<RuleViolateMessage> callback)
        {
            var detailList = ruleCheckParameters.DetailList;

            var detail1 = detailList.Where(d => d.ProcedureCode == this.ProcedureCode).FirstOrDefault();

            if (detail1 == null)
                return;

            if (this.LifeTimeMaxQuantity > 0)
            {
                //TODO: Rule03 için LifeTimeMaxQuantity koşulunda sorun var. 
                //Sorgusu amount ları toplayıp getirmiyor. 
                //Ayrıca newEntries amount larıda toplama dahil edilmiyor.
                LifeTimeQuantityCheck(ruleCheckParameters, callback, detail1);
            }

            //if (!string.IsNullOrEmpty(SupplementalCondition1))
            //{
            //    var message = string.Format(RuleCheckMessages.KosulluIslemTekrariUyarisi.Message, detail1.ProcedureName, this.SupplementalCondition1, this.TreatmentMaxQuantity);

            //    var messageDto = new RuleViolateMessage(ObjectId, GroupId, ProcedureCode, message, this.BlockRequest);
            //    messageDto.DetailId1 = detail1.DetailId;
            //    callback(messageDto);
            //}
            //else
            //{
            //    var message = string.Format(RuleCheckMessages.IliskiliTanimUyarisi.Message, detail1.ProcedureName, this.TreatmentMaxQuantity);

            //    var messageDto = new RuleViolateMessage(ObjectId, GroupId, ProcedureCode, message, this.BlockRequest);
            //    messageDto.DetailId1 = detail1.DetailId;
            //    callback(messageDto);
            //}
        }

    }

}
