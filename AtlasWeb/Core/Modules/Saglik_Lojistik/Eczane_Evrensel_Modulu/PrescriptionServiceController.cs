//$0E48FAFB
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using System.Collections.Generic;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using TTUtils;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class PrescriptionServiceController : Controller
    {
        public class GetEReceteSignedInputRequest_Input
        {
            public TTObjectClasses.Prescription pres
            {
                get;
                set;
            }
        }

        [HttpPost]
        public string GetEReceteSignedInputRequest(GetEReceteSignedInputRequest_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.pres != null)
                    input.pres = (TTObjectClasses.Prescription)objectContext.AddObject(input.pres);
                var ret = Prescription.GetEReceteSignedInputRequest(input.pres);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetEReceteDelete_Input
        {
            public TTObjectClasses.Prescription pres
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.EReceteIslemleri.ereceteSilIstekDVO GetEReceteDelete(GetEReceteDelete_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.pres != null)
                    input.pres = (TTObjectClasses.Prescription)objectContext.AddObject(input.pres);
                var ret = Prescription.GetEReceteDelete(input.pres);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetEReceteInputRequest_Input
        {
            public TTObjectClasses.Prescription pres
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.EReceteIslemleri.ereceteGirisIstekDVO GetEReceteInputRequest(GetEReceteInputRequest_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.pres != null)
                    input.pres = (TTObjectClasses.Prescription)objectContext.AddObject(input.pres);
                var ret = Prescription.GetEReceteInputRequest(input.pres);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetEreceteInQuiry_Input
        {
            public TTObjectClasses.Prescription pres
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.EReceteIslemleri.ereceteSorguIstekDVO GetEreceteInQuiry(GetEreceteInQuiry_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.pres != null)
                    input.pres = (TTObjectClasses.Prescription)objectContext.AddObject(input.pres);
                var ret = Prescription.GetEreceteInQuiry(input.pres);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetEreceteListInQuiry_Input
        {
            public TTObjectClasses.Prescription pres
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.EReceteIslemleri.ereceteListeSorguIstekDVO GetEreceteListInQuiry(GetEreceteListInQuiry_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.pres != null)
                    input.pres = (TTObjectClasses.Prescription)objectContext.AddObject(input.pres);
                var ret = Prescription.GetEreceteListInQuiry(input.pres);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetEreceteApprovalRequest_Input
        {
            public TTObjectClasses.Prescription pres
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.EReceteIslemleri.ereceteOnayIstekDVO GetEreceteApprovalRequest(GetEreceteApprovalRequest_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.pres != null)
                    input.pres = (TTObjectClasses.Prescription)objectContext.AddObject(input.pres);
                var ret = Prescription.GetEreceteApprovalRequest(input.pres);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetEreceteInpatientApprovalRequest_Input
        {
            public TTObjectClasses.Prescription pres
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.EReceteIslemleri.ereceteYatanHastaOnayiIstekDVO GetEreceteInpatientApprovalRequest(GetEreceteInpatientApprovalRequest_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.pres != null)
                    input.pres = (TTObjectClasses.Prescription)objectContext.AddObject(input.pres);
                var ret = Prescription.GetEreceteInpatientApprovalRequest(input.pres);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetEreceteApprovalCancelRequest_Input
        {
            public TTObjectClasses.Prescription pres
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.EReceteIslemleri.ereceteOnayIptalIstekDVO GetEreceteApprovalCancelRequest(GetEreceteApprovalCancelRequest_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.pres != null)
                    input.pres = (TTObjectClasses.Prescription)objectContext.AddObject(input.pres);
                var ret = Prescription.GetEreceteApprovalCancelRequest(input.pres);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetEreceteEHUApprovalRequest_Input
        {
            public TTObjectClasses.Prescription pres
            {
                get;
                set;
            }

            public long UniqueRefNo
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.EReceteIslemleri.ereceteOnayIstekDVO GetEreceteEHUApprovalRequest(GetEreceteEHUApprovalRequest_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.pres != null)
                    input.pres = (TTObjectClasses.Prescription)objectContext.AddObject(input.pres);
                var ret = Prescription.GetEreceteEHUApprovalRequest(input.pres, input.UniqueRefNo);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetEreceteEHUCancelRequest_Input
        {
            public TTObjectClasses.Prescription pres
            {
                get;
                set;
            }

            public long UniqueRefNo
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.EReceteIslemleri.ereceteOnayIptalIstekDVO GetEreceteEHUCancelRequest(GetEreceteEHUCancelRequest_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.pres != null)
                    input.pres = (TTObjectClasses.Prescription)objectContext.AddObject(input.pres);
                var ret = Prescription.GetEreceteEHUCancelRequest(input.pres, input.UniqueRefNo);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetEreceteDailyPresApprovalRequest_Input
        {
            public TTObjectClasses.Prescription pres
            {
                get;
                set;
            }

            public long UniqueRefNo
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.EReceteIslemleri.ereceteOnayIstekDVO GetEreceteDailyPresApprovalRequest(GetEreceteDailyPresApprovalRequest_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.pres != null)
                    input.pres = (TTObjectClasses.Prescription)objectContext.AddObject(input.pres);
                var ret = Prescription.GetEreceteDailyPresApprovalRequest(input.pres, input.UniqueRefNo);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetEreceteDailyPresCancelRequest_Input
        {
            public TTObjectClasses.Prescription pres
            {
                get;
                set;
            }

            public long UniqueRefNo
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.EReceteIslemleri.ereceteOnayIptalIstekDVO GetEreceteDailyPresCancelRequest(GetEreceteDailyPresCancelRequest_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.pres != null)
                    input.pres = (TTObjectClasses.Prescription)objectContext.AddObject(input.pres);
                var ret = Prescription.GetEreceteDailyPresCancelRequest(input.pres, input.UniqueRefNo);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetDısReceteInfo_Input
        {
            public TTObjectClasses.Prescription pres
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.XXXXXXSptsClasses.ReceteInfo GetDısReceteInfo(GetDısReceteInfo_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.pres != null)
                    input.pres = (TTObjectClasses.Prescription)objectContext.AddObject(input.pres);
                var ret = Prescription.GetDısReceteInfo(input.pres);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetReceteInfo_Input
        {
            public TTObjectClasses.Prescription pres
            {
                get;
                set;
            }
        }

        [HttpPost]
        public TTObjectClasses.XXXXXXSptsClasses.ReceteInfo GetReceteInfo(GetReceteInfo_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.pres != null)
                    input.pres = (TTObjectClasses.Prescription)objectContext.AddObject(input.pres);
                var ret = Prescription.GetReceteInfo(input.pres);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetPrescription_Input
        {
            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Prescription> GetPrescription(GetPrescription_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = Prescription.GetPrescription(objectContext, input.STARTDATE, input.ENDDATE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class OLAP_GetPrescription_Input
        {
            public DateTime FIRSTDATE
            {
                get;
                set;
            }

            public DateTime LASTDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Prescription.OLAP_GetPrescription_Class> OLAP_GetPrescription(OLAP_GetPrescription_Input input)
        {
            var ret = Prescription.OLAP_GetPrescription(input.FIRSTDATE, input.LASTDATE);
            return ret;
        }

        public class GetFamilyForPrescriptionStatisticReportQuery_Input
        {
            public string MASTERRESOURCEID
            {
                get;
                set;
            }

            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }

            public PrescriptionTypeEnum PRESCRIPTIONTYPE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Prescription.GetFamilyForPrescriptionStatisticReportQuery_Class> GetFamilyForPrescriptionStatisticReportQuery(GetFamilyForPrescriptionStatisticReportQuery_Input input)
        {
            var ret = Prescription.GetFamilyForPrescriptionStatisticReportQuery(input.MASTERRESOURCEID, input.STARTDATE, input.ENDDATE, input.PRESCRIPTIONTYPE);
            return ret;
        }

        public class GetCivilianForPrescriptionStatisticReportQuery_Input
        {
            public string MASTERRESOURCEID
            {
                get;
                set;
            }

            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }

            public PrescriptionTypeEnum PRESCRIPTIONTYPE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Prescription.GetCivilianForPrescriptionStatisticReportQuery_Class> GetCivilianForPrescriptionStatisticReportQuery(GetCivilianForPrescriptionStatisticReportQuery_Input input)
        {
            var ret = Prescription.GetCivilianForPrescriptionStatisticReportQuery(input.MASTERRESOURCEID, input.STARTDATE, input.ENDDATE, input.PRESCRIPTIONTYPE);
            return ret;
        }

        public class GetOfficerForPrescriptionStatisticReportQuery_Input
        {
            public string MASTERRESOURCEID
            {
                get;
                set;
            }

            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }

            public PrescriptionTypeEnum PRESCRIPTIONTYPE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Prescription.GetOfficerForPrescriptionStatisticReportQuery_Class> GetOfficerForPrescriptionStatisticReportQuery(GetOfficerForPrescriptionStatisticReportQuery_Input input)
        {
            var ret = Prescription.GetOfficerForPrescriptionStatisticReportQuery(input.MASTERRESOURCEID, input.STARTDATE, input.ENDDATE, input.PRESCRIPTIONTYPE);
            return ret;
        }

        public class GetPrescriptionSearchWithProtocolNOReportQuery_Input
        {
            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }

            public long PROTOCOLNO
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Prescription.GetPrescriptionSearchWithProtocolNOReportQuery_Class> GetPrescriptionSearchWithProtocolNOReportQuery(GetPrescriptionSearchWithProtocolNOReportQuery_Input input)
        {
            var ret = Prescription.GetPrescriptionSearchWithProtocolNOReportQuery(input.STARTDATE, input.ENDDATE, input.PROTOCOLNO);
            return ret;
        }

        public class GetNCOfficerForPrescriptionStatisticReportQuery_Input
        {
            public string MASTERRESOURCEID
            {
                get;
                set;
            }

            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }

            public PrescriptionTypeEnum PRESCRIPTIONTYPE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Prescription.GetNCOfficerForPrescriptionStatisticReportQuery_Class> GetNCOfficerForPrescriptionStatisticReportQuery(GetNCOfficerForPrescriptionStatisticReportQuery_Input input)
        {
            var ret = Prescription.GetNCOfficerForPrescriptionStatisticReportQuery(input.MASTERRESOURCEID, input.STARTDATE, input.ENDDATE, input.PRESCRIPTIONTYPE);
            return ret;
        }

        public class GetPrescriptionStatisticWithGroupReportQuery_Input
        {
            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }

            public PrescriptionTypeEnum PRESCRIPTIONTYPEENUM
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Prescription.GetPrescriptionStatisticWithGroupReportQuery_Class> GetPrescriptionStatisticWithGroupReportQuery(GetPrescriptionStatisticWithGroupReportQuery_Input input)
        {
            var ret = Prescription.GetPrescriptionStatisticWithGroupReportQuery(input.STARTDATE, input.ENDDATE, input.PRESCRIPTIONTYPEENUM);
            return ret;
        }

        public class GetOfficialForPrescriptionStatisticReportQuery_Input
        {
            public string MASTERRESOURCEID
            {
                get;
                set;
            }

            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }

            public PrescriptionTypeEnum PRESCRIPTIONTYPE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Prescription.GetOfficialForPrescriptionStatisticReportQuery_Class> GetOfficialForPrescriptionStatisticReportQuery(GetOfficialForPrescriptionStatisticReportQuery_Input input)
        {
            var ret = Prescription.GetOfficialForPrescriptionStatisticReportQuery(input.MASTERRESOURCEID, input.STARTDATE, input.ENDDATE, input.PRESCRIPTIONTYPE);
            return ret;
        }

        public class GetExpertNonComForPrescriptionStatisticReportQuery_Input
        {
            public string MASTERRESOURCEID
            {
                get;
                set;
            }

            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }

            public PrescriptionTypeEnum PRESCRIPTIONTYPE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Prescription.GetExpertNonComForPrescriptionStatisticReportQuery_Class> GetExpertNonComForPrescriptionStatisticReportQuery(GetExpertNonComForPrescriptionStatisticReportQuery_Input input)
        {
            var ret = Prescription.GetExpertNonComForPrescriptionStatisticReportQuery(input.MASTERRESOURCEID, input.STARTDATE, input.ENDDATE, input.PRESCRIPTIONTYPE);
            return ret;
        }

        public class GetPrivateForPrescriptionStatisticReportQuery_Input
        {
            public string MASTERRESOURCEID
            {
                get;
                set;
            }

            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }

            public PrescriptionTypeEnum PRESCRIPTIONTYPE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Prescription.GetPrivateForPrescriptionStatisticReportQuery_Class> GetPrivateForPrescriptionStatisticReportQuery(GetPrivateForPrescriptionStatisticReportQuery_Input input)
        {
            var ret = Prescription.GetPrivateForPrescriptionStatisticReportQuery(input.MASTERRESOURCEID, input.STARTDATE, input.ENDDATE, input.PRESCRIPTIONTYPE);
            return ret;
        }

        public class GetCadetForPrescriptionStatisticReportQuery_Input
        {
            public string MASTERRESOURCEID
            {
                get;
                set;
            }

            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }

            public PrescriptionTypeEnum PRESCRIPTIONTYPE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Prescription.GetCadetForPrescriptionStatisticReportQuery_Class> GetCadetForPrescriptionStatisticReportQuery(GetCadetForPrescriptionStatisticReportQuery_Input input)
        {
            var ret = Prescription.GetCadetForPrescriptionStatisticReportQuery(input.MASTERRESOURCEID, input.STARTDATE, input.ENDDATE, input.PRESCRIPTIONTYPE);
            return ret;
        }

        public class GetRetiredForPrescriptionStatisticReportQuery_Input
        {
            public string MASTERRESOURCEID
            {
                get;
                set;
            }

            public DateTime STARTDATE
            {
                get;
                set;
            }

            public DateTime ENDDATE
            {
                get;
                set;
            }

            public PrescriptionTypeEnum PRESCRIPTIONTYPE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Prescription.GetRetiredForPrescriptionStatisticReportQuery_Class> GetRetiredForPrescriptionStatisticReportQuery(GetRetiredForPrescriptionStatisticReportQuery_Input input)
        {
            var ret = Prescription.GetRetiredForPrescriptionStatisticReportQuery(input.MASTERRESOURCEID, input.STARTDATE, input.ENDDATE, input.PRESCRIPTIONTYPE);
            return ret;
        }

        public class OLAP_GetCancelledPrescription_Input
        {
            public DateTime FIRSTDATE
            {
                get;
                set;
            }

            public DateTime LASTDATE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<Prescription.OLAP_GetCancelledPrescription_Class> OLAP_GetCancelledPrescription(OLAP_GetCancelledPrescription_Input input)
        {
            var ret = Prescription.OLAP_GetCancelledPrescription(input.FIRSTDATE, input.LASTDATE);
            return ret;
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<Prescription.VEM_RECETE_Class> VEM_RECETE()
        {
            var ret = Prescription.VEM_RECETE();
            return ret;
        }

        public class PrepareRepeatApprovalRequest_Input
        {
            public InpatientPrescription inpatientPrescription
            {
                get;
                set;
            }
        }

        [HttpPost]
        public string PrepareRepeatApprovalRequest(PrepareRepeatApprovalRequest_Input input)
        {
            SignedPrescriptionOutput output = new SignedPrescriptionOutput();
            string signApprovalContent = string.Empty;
            using (var objectContext = new TTObjectContext(false))
            {
                var prescription = (InpatientPrescription)objectContext.AddObject(input.inpatientPrescription);
                signApprovalContent = Prescription.GetEreceteSignedApprovalRequest(prescription);
            }
            return signApprovalContent;
        }

        public class SendRepeatApprovalRequest_Input
        {
            public InpatientPrescription inpatientPrescription
            {
                get;
                set;
            }
            public string signApprovalContent
            {
                get;
                set;
            }
        }

        [HttpPost]
        public bool SendRepeatApprovalRequest(SendRepeatApprovalRequest_Input input)
        {
            var signedData = Convert.FromBase64String(input.signApprovalContent);
            ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;
            bool error = false;
            if (input.inpatientPrescription.SubEpisode.IsSGK)
            {
                EReceteIslemleri.imzaliEreceteOnayIstekDVO eReceteSignedApprovalRequest = new EReceteIslemleri.imzaliEreceteOnayIstekDVO();
                long drKimlikNo = Convert.ToInt64(currentUser.UniqueNo);
                long saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
                eReceteSignedApprovalRequest.doktorTcKimlikNo = drKimlikNo.ToString();
                eReceteSignedApprovalRequest.tesisKodu = saglikTesisKodu.ToString();
                eReceteSignedApprovalRequest.imzaliEreceteOnay = signedData;
                eReceteSignedApprovalRequest.surumNumarasi = "1";

                EReceteIslemleri.imzaliEreceteOnayCevapDVO resOnay = EReceteIslemleri.WebMethods.imzaliEreceteOnaySync(Sites.SiteLocalHost, currentUser.UniqueNo.ToString(), currentUser.ErecetePassword, eReceteSignedApprovalRequest);
                if (resOnay != null)
                {
                    if (resOnay.sonucKodu.Equals("0000"))
                        InfoMessageService.Instance.ShowMessage(input.inpatientPrescription.EReceteNo.ToString() + " e reçete numarası ile reçete kaydedilmiştir.");
                    else
                    {
                        if (!string.IsNullOrEmpty(resOnay.uyariMesaji))
                        {
                            InfoMessageService.Instance.ShowMessage("e-Reçete Servisinden Gelen Sonuç Mesajı : " + resOnay.sonucMesaji + TTUtils.CultureService.GetText("M25049", "\n\r e-Reçete ServisindenGelen Uyarı Mesajı :")+ resOnay.uyariMesaji);
                            error = true;
                        }
                        else
                        {
                            InfoMessageService.Instance.ShowMessage("e-Reçete Servisinden Gelen Sonuç Mesajı : " + resOnay.sonucMesaji);
                            error = true;
                        }
                    }
                    //if (error)
                    //    throw new TTException("Bazı reçetelerınizde e reçeteye yollanırken hata alınmıştır. Tekrar kontrol ediniz");
                }
            }
            return error;
        }
    }
}