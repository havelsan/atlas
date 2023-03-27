using RuleChecker.Interface;
using RuleChecker.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using TTUtils.Entities;

namespace RuleChecker.Engine.RuleCheckers
{
    [XmlRoot(RuleXmlTag.Rule19)]
    public partial class Rule19 : IRule, IRuleChecker
    {
        [XmlAttribute(RuleXmlTag.ObjectId)]
        public Guid ObjectId { get; set; }

        [XmlAttribute(RuleXmlTag.GroupId)]
        public Guid GroupId { get; set; }

        [XmlElement(RuleXmlTag.ProcedureCode)]
        public string ProcedureCode { get; set; }

        [XmlArray(RuleXmlTag.RequestMonthList)]
        [XmlArrayItem(RuleXmlTag.RequestMonth)]
        public List<NthRequestMonth> RequestMonthList { get; set; }

        [XmlIgnore]
        public bool BlockRequest { get; set; }

        [XmlIgnore]
        public bool Active { get; set; }

        private ProcedureRequestDetailDto GetNthItem(ProcedureRequestDetailDto detailCurrent, IList<ProcedureRequestDetailDto> detailList, int nthIndex)
        {
            if (detailCurrent == null)
                return null;

            int index = 0;
            bool itemLocated = false;
            foreach (var detail in detailList)
            {
                if (detail.LocalId.Equals(detailCurrent.LocalId))
                {
                    itemLocated = true;
                }

                if (itemLocated)
                    ++index;

                if (index == nthIndex)
                    return detail;
            }

            return null;
        }

        private ProcedureRequestDetailDto[] BuildRequestArray(ProcedureRequestDetailDto detailCurrent, IList<ProcedureRequestDetailDto> detailList)
        {
            var detailArray = new ProcedureRequestDetailDto[this.RequestMonthList.Count + 1];

            int targetIndex = 0;

            detailArray[targetIndex] = detailCurrent;

            foreach (var reqMonth in this.RequestMonthList)
            {
                var prevItem = GetNthItem(detailCurrent, detailList, reqMonth.NthRequest);

                detailArray[++targetIndex] = prevItem;
            }

            return detailArray.Reverse().ToArray();
        }

        // Ortodonti paketleri en ez geçmesi gereken süre kontrolü
        // 2. paket minimum 6 ay, 3. paket minimum 10 ay
        public void CheckRule(RuleCheckParameters ruleCheckParameters, Action<RuleViolateMessage> callback)
        {
            var detailList = ruleCheckParameters.DetailList.Where(d => d.ProcedureCode == this.ProcedureCode);

            var patientProcedureRepository = ruleCheckParameters.PatientProcedureRepository;

            var patientInfo = ruleCheckParameters.PatientInfo;

            var patientDetailList = patientProcedureRepository.PatientProcedureList(patientInfo.PatientId, this.ProcedureCode);

            var combinedDetailList = patientDetailList.Union(detailList).OrderByDescending(d => d.RequestDate).ToList();

            // Zaten 3 adet giriş varsa artık ortodonti paketi istenemez
            if (combinedDetailList.Count() > this.RequestMonthList.Count + 1)
            {
                var detail2 = combinedDetailList.FirstOrDefault();
                var mesaj = string.Format(RuleCheckMessages.OrtodontiPaketGirisYapilamaz.Message, detail2.ProcedureName);
                var mesajDto = new RuleViolateMessage(ObjectId, GroupId, detail2.RequestDate, ProcedureCode, mesaj, BlockRequest);
                callback(mesajDto);
                return;
            }

            foreach (var reqMonth in this.RequestMonthList)
            {

                if (combinedDetailList.Count() == reqMonth.NthRequest)
                {
                    var firstDetail = combinedDetailList.LastOrDefault();

                    var lastDetail = combinedDetailList.FirstOrDefault();

                    if (firstDetail != null && lastDetail != null)
                    {

                        var totalMonths = lastDetail.RequestDate.MonthDifference(firstDetail.RequestDate);

                        if (totalMonths >= 0 && totalMonths < reqMonth.MinMonths)
                        {
                            var mesaj = string.Format(RuleCheckMessages.OrtodontiMinimumPaketGecildi.Message, firstDetail.ProcedureName, reqMonth.NthRequest, reqMonth.MinMonths);

                            var mesajDto = new RuleViolateMessage(ObjectId, GroupId, firstDetail.RequestDate, ProcedureCode, mesaj, BlockRequest);
                            mesajDto.DetailId1 = firstDetail.DetailId;
                            mesajDto.DetailId2 = lastDetail.DetailId;
                            callback(mesajDto);
                            continue;
                        }
                    }
                }
            }

        }
    }
}
