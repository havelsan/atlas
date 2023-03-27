
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;



using TTStorageManager;
using System.Runtime.Versioning;


namespace TTObjectClasses
{
    public partial class SendToDoctorPerformance : TTObject
    {
        public partial class GetByStatus_Class : TTReportNqlObject
        {
        }

        #region Methods
        public SendToDoctorPerformance(TTObjectContext objectContext, Guid internalObjectID, String internalObjectDefName, DPInternalObjectStatus internalObjectStatus, DateTime recordDate) : this(objectContext)
        {
            InternalObjectID = internalObjectID;
            InternalObjectDefName = internalObjectDefName;
            InternalObjectStatus = internalObjectStatus;
            RecordDate = recordDate;
            Status = DPStatus.ToBeSent;
        }

        public class PerformanceDetailDto
        {
            public string PatientRefKey { get; set; }
            public string EpisodeRefKey { get; set; }
            public string EpisodeActionRefKey { get; set; }
            public string ProcedureRefKey { get; set; }
            public string PhysicianCode { get; set; }
            public string ProcedureCode { get; set; }
            public DateTime ProcedureDate { get; set; }

            public PerformanceDetailDto() { }

            public PerformanceDetailDto(string patientRefKey, string episodeRefKey, string episodeActionRefKey, string procedureRefKey, string physicianCode, string procedureCode, DateTime procedureDate)
            {
                PatientRefKey = patientRefKey;
                EpisodeRefKey = episodeRefKey;
                EpisodeActionRefKey = episodeActionRefKey;
                ProcedureRefKey = procedureRefKey;
                PhysicianCode = physicianCode;
                ProcedureCode = procedureCode;
                ProcedureDate = procedureDate;
            }
        }

        public static void SendAllDPs()
        {
            TTObjectContext roObjectContext = new TTObjectContext(true);
            IList<SendToDoctorPerformance.GetByStatus_Class> DPList = SendToDoctorPerformance.GetByStatus(roObjectContext, DPStatus.ToBeSent);
            List<Guid> failedToSendProcedureId = new List<Guid>();

            foreach (SendToDoctorPerformance.GetByStatus_Class DP in DPList)
            {
                TTObjectContext objectContext = new TTObjectContext(false);
                SendToDoctorPerformance sendToDP = objectContext.GetObject(DP.ObjectID.Value, typeof(SendToDoctorPerformance)) as SendToDoctorPerformance;
                if (sendToDP != null)
                {
                    try
                    {

                        PerfRuleCheckerResult<IList<PerformanceDetailNoteDto>> performanceResult = null;
                        PerfRuleCheckerResult<PerformanceDetailIdDto> cancelPerfResult = null;
                        bool isSuccess = false;

                        int failedCount = failedToSendProcedureId.Count(x => x == sendToDP.InternalObjectID);

                        if (sendToDP.InternalObjectStatus == DPInternalObjectStatus.Cancelled && failedCount == 0)
                        {
                            cancelPerfResult = sendToDP.CancelDoctorPerformanceDetail();
                            isSuccess = cancelPerfResult.IsSuccess;
                            if (isSuccess == false)
                                failedToSendProcedureId.Add(sendToDP.InternalObjectID.Value);
                        }
                        else if ((sendToDP.InternalObjectStatus == DPInternalObjectStatus.Inserted || sendToDP.InternalObjectStatus == DPInternalObjectStatus.Updated) && failedCount == 0)
                        {
                            SubActionProcedure sp = (SubActionProcedure)objectContext.GetObject(DP.InternalObjectID.Value, TTObjectDefManager.Instance.ObjectDefs[typeof(SubActionProcedure).Name], false); if (sp != null)
                            {
                                performanceResult = sp.SendDoctorPerformanceDetail(sendToDP);
                                isSuccess = performanceResult.IsSuccess;

                                if (isSuccess == false)
                                    failedToSendProcedureId.Add(sp.ObjectID);
                            }

                        }
                        objectContext.Save();
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }
            }
        }

        public PerfRuleCheckerResult<PerformanceDetailIdDto> CancelDoctorPerformanceDetail()
        {
            try
            {
                var detailIdDto = new TTUtils.ProcedureIdDto();
                detailIdDto.ProcedureId = InternalObjectID.Value;
                var ruleEngineService = TTUtils.PerfRuleEngineServiceFactory.Instance;
                var result = ruleEngineService.PerformanceCancel(detailIdDto);
                if (ruleEngineService != null)
                    result = ruleEngineService.PerformanceCancel(detailIdDto);
                else
                {
                    result = new PerfRuleCheckerResult<PerformanceDetailIdDto>();
                    result.IsSuccess = false;
                    result.ErrorMessage = "PerfRuleEngineServiceFactory.Instace null. PerfRuleEngineService.cs yi ilgili projeye ekleyip Instance oluşturun.";
                }

                if (result.IsSuccess)
                    Status = DPStatus.Sent;

                return result;
            }
            catch (Exception ex)
            {
                PerfRuleCheckerResult<PerformanceDetailIdDto> cathResult = new PerfRuleCheckerResult<PerformanceDetailIdDto>();
                cathResult.IsSuccess = false;
                cathResult.ErrorMessage = ex.ToString();
                return cathResult;
            }
        }

        //public static void SendAllDPsOld()
        //{
        //    TTObjectContext roObjectContext = new TTObjectContext(true);
        //    IList<SendToDoctorPerformance.GetByStatus_Class> DPList = SendToDoctorPerformance.GetByStatus(roObjectContext, DPStatus.ToBeSent);

        //    try
        //    {
        //        foreach (SendToDoctorPerformance.GetByStatus_Class DP in DPList)
        //        {
        //            TTObjectContext objectContext = new TTObjectContext(false);
        //            SendToDoctorPerformance sendToDP = objectContext.GetObject(DP.ObjectID.Value, typeof(SendToDoctorPerformance)) as SendToDoctorPerformance;
        //            if (sendToDP != null)
        //            {
        //                SubActionProcedure sp = objectContext.GetObject(DP.InternalObjectID.Value, typeof(SubActionProcedure)) as SubActionProcedure;
        //                if (sp != null)
        //                {
        //                    if (sp.ProcedureObject != null && sp.ProcedureDoctor != null && sp.PerformedDate.HasValue)
        //                    {
        //                        string procedureCode = sp.GetGILCode();
        //                        int procedurePoint = sp.GetGILPoint();

        //                        if (!string.IsNullOrEmpty(procedureCode) && procedurePoint > 0)
        //                        {
        //                            //string patientRefKey = sp.EpisodeAction.Episode.Patient.ObjectID.ToString();
        //                            //string episodeRefKey = sp.EpisodeAction.Episode.ObjectID.ToString();
        //                            //string episodeActionRefKey = sp.EpisodeAction.ObjectID.ToString();
        //                            //string procedureRefKey = sp.ObjectID.ToString();
        //                            //string physicianCode = sp.ProcedureDoctor.ObjectID.ToString();
        //                            //DateTime procedureDate = sp.PerformedDate.Value;
        //                            //PerformanceDetailDto performanceDetailDto = new PerformanceDetailDto(patientRefKey, episodeRefKey, episodeActionRefKey, procedureRefKey, physicianCode, procedureCode, procedureDate);

        //                            if (sendToDP.InternalObjectStatus == DPInternalObjectStatus.Inserted)
        //                            {
        //                                PerformanceDetailDto performanceDetailDto = new PerformanceDetailDto();
        //                                performanceDetailDto.PatientRefKey = sp.EpisodeAction.Episode.Patient.ObjectID.ToString();
        //                                performanceDetailDto.EpisodeRefKey = sp.EpisodeAction.Episode.ObjectID.ToString();
        //                                performanceDetailDto.EpisodeActionRefKey = sp.EpisodeAction.ObjectID.ToString();
        //                                performanceDetailDto.ProcedureRefKey = sp.ObjectID.ToString();
        //                                performanceDetailDto.PhysicianCode = sp.ProcedureDoctor.ObjectID.ToString();
        //                                performanceDetailDto.ProcedureCode = procedureCode;
        //                                performanceDetailDto.ProcedureDate = sp.PerformedDate.Value;
        //                                // Burda branş bilgisi de gerekecek büyük ihtimalle, mesela 520033 için branş önemli 

        //                                // TODO : Burada karşıdaki Insert metodu çağırılacak, karşıdan hata gelmesi durumunda hata burda throw edilmeli ki işletim dursun
        //                                // Karşıdan hata aldığı halde bir sonraki işlem ile devam etmemeli. Orada kesmeli işletimi. Bir sonraki çalışmada tekrar baştan başlanmalı
        //                                // tarih sırası ile.

        //                            }
        //                            else if (sendToDP.InternalObjectStatus == DPInternalObjectStatus.Updated)
        //                            {

        //                                // TODO : Burada karşıdaki Update metodu çağırılacak
        //                            }
        //                            else if (sendToDP.InternalObjectStatus == DPInternalObjectStatus.Cancelled)
        //                            {

        //                                // TODO : Burada karşıdaki Delete metodu çağırılacak
        //                            }

        //                            sendToDP.Status = DPStatus.Sent;
        //                        }
        //                        else if (string.IsNullOrEmpty(sp.ProcedureObject.GILCode))
        //                            sendToDP.Status = DPStatus.DontSend; // NoGILCode gibi bir duruma alınabilir
        //                        else if (!sp.ProcedureObject.GILPoint.HasValue || (sp.ProcedureObject.GILPoint.HasValue && sp.ProcedureObject.GILPoint.Value == 0))
        //                            sendToDP.Status = DPStatus.DontSend; // NoGILPoint gibi bir duruma alınabilir
        //                        //else if (sp.ProcedureDoctor.TakesPerformanceScore.HasValue)
        //                        // TODO : TakesPerformanceScore false bile olsa göndersek iyi olacak gibi, doktor değişmişse önceki doktordan puanı silmesi gerekecek çünkü
        //                        objectContext.Save();
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // TODO : Hata alınması durumunda yapılacaklar
        //    }
        //}

        #endregion Methods

    }
}