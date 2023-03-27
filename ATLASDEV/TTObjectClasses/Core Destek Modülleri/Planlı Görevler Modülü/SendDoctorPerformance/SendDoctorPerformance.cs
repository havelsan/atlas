
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
    /// <summary>
    /// Doktor Performans Gönder
    /// </summary>
    public partial class SendDoctorPerformance : BaseScheduledTask
    {
        public void CreateNewSendDoctorPerformanceLog(TTObjectContext objectContext, SendToDoctorPerformance sendToDoctorPerformance, string Log)
        {
            SendDoctorPerformanceLog performanceLog = new SendDoctorPerformanceLog(objectContext);
            performanceLog.LogDate = DateTime.Now;
            performanceLog.SendToDoctorPerformance = sendToDoctorPerformance;
            performanceLog.Log = Log;
            objectContext.Save();
        }
        public override void TaskScript()
        {
            TTObjectContext roObjectContext = new TTObjectContext(true);
            string startDate;
            string endDate;
            if (DpStartDate.HasValue)
                startDate = Convert.ToDateTime((DpStartDate.Value.ToShortDateString() + " 00:00:00")).ToString("yyyy-MM-dd HH:mm:ss");
            else
                startDate = DateTime.MinValue.ToString("yyyy-MM-dd HH:mm:ss");
            if (DpEndDate.HasValue)
                endDate = Convert.ToDateTime((DpEndDate.Value.ToShortDateString() + " 23:59:59")).ToString("yyyy-MM-dd HH:mm:ss");
            else
                endDate = Convert.ToDateTime(Common.RecTime().ToShortDateString() + " 23:59:59").ToString("yyyy-MM-dd HH:mm:ss");

            IList<SendToDoctorPerformance.GetByStatus_Class> DPList = SendToDoctorPerformance.GetByStatus(roObjectContext, DPStatus.ToBeSent, " AND RECORDDATE BETWEEN TODATE('" + startDate + "') AND TODATE('" + endDate + "')");
            List<Guid> failedToSendProcedureId = new List<Guid>();
            AddLog(TTUtils.CultureService.GetText("M26836", "SendDoctorPerformance metodu başlatıldı.") + Common.RecTime().ToString());
            foreach (SendToDoctorPerformance.GetByStatus_Class DP in DPList)
            {
                TTObjectContext objectContext = new TTObjectContext(false);
                SendToDoctorPerformance sendToDP = objectContext.GetObject(DP.ObjectID.Value, typeof(SendToDoctorPerformance)) as SendToDoctorPerformance;
                SendDoctorPerformanceLog performanceLog = new SendDoctorPerformanceLog();

                if (sendToDP != null)
                {
                    try
                    {
                        PerfRuleCheckerResult<IList<PerformanceDetailNoteDto>> performanceResult = null;
                        PerfRuleCheckerResult<PerformanceDetailIdDto> cancelPerfResult = null;
                        int failedCount = failedToSendProcedureId.Count(x => x == sendToDP.InternalObjectID);
                        //bool isSuccess = false;

                        if (sendToDP.InternalObjectStatus == DPInternalObjectStatus.Cancelled && failedCount == 0)
                        {
                            cancelPerfResult = sendToDP.CancelDoctorPerformanceDetail();
                            if (cancelPerfResult != null)
                            {
                                failedToSendProcedureId.Add(sendToDP.InternalObjectID.Value);
                                if (cancelPerfResult.IsSuccess == false)
                                    AddLog("ResultErrorMessageForCancel:" + cancelPerfResult.ErrorMessage + " SendToDoctorPerformance ObjectID: " + sendToDP.ObjectID);
                            }
                            else
                                AddLog("ResultErrorMessageForCancel: cancelPerfResult is null. SendToDoctorPerformance ObjectID: " + sendToDP.ObjectID);

                        }
                        else if ((sendToDP.InternalObjectStatus == DPInternalObjectStatus.Inserted || sendToDP.InternalObjectStatus == DPInternalObjectStatus.Updated) && failedCount == 0)
                        {
                            SubActionProcedure sp = (SubActionProcedure)objectContext.GetObject(DP.InternalObjectID.Value, TTObjectDefManager.Instance.ObjectDefs[typeof(SubActionProcedure).Name], false);
                            if (sp != null)
                            {
                                performanceResult = sp.SendDoctorPerformanceDetail(sendToDP);
                                if (performanceResult != null)
                                {
                                    failedToSendProcedureId.Add(sp.ObjectID);
                                    if (performanceResult.IsSuccess == false)
                                        AddLog("ResultErrorMessageForPerformance:" + performanceResult.ErrorMessage + " SendToDoctorPerformance ObjectID: " + sendToDP.ObjectID);
                                }
                                else
                                    AddLog("ResultErrorMessageForCancel: performanceResult is null. SendToDoctorPerformance ObjectID: " + sendToDP.ObjectID);

                            }
                            else
                            {
                                performanceLog.CreateNewSendDoctorPerformanceLog(objectContext, sendToDP, DPDetailedErrorTypes.SUBACTIONPROCEDURENULL, "SubActionProcedure null.", "TaskScript");
                                sendToDP.Status = DPStatus.DontSend;
                            }
                        }

                        objectContext.Save();
                        objectContext.Dispose();
                        //SubActionProcedure sp = objectContext.GetObject(DP.InternalObjectID.Value, typeof(SubActionProcedure)) as SubActionProcedure;
                        //if (sp != null)
                        //{
                        //    bool isSuccess = false;
                        //    PerfRuleCheckerResult<IList<PerformanceDetailNoteDto>> result = null;
                        //    if (sendToDP.InternalObjectStatus == DPInternalObjectStatus.Inserted || sendToDP.InternalObjectStatus == DPInternalObjectStatus.Updated)
                        //        result = sp.SendDoctorPerformanceDetail();
                        //    else if (sendToDP.InternalObjectStatus == DPInternalObjectStatus.Cancelled)
                        //        isSuccess = sp.CancelDoctorPerformanceDetail(sendToDP);

                        //    // Burada hata gelmesi durumunda işletim durmalı. Karşıdan hata aldığı halde bir sonraki işlem ile devam etmemeli.
                        //    // Devam ederse işletime, sonra göndermesi gereken bir iptal işlemini daha önce gönderir ve iptal etmesi gereken bir performans
                        //    // puanını iptal etmemiş olur.
                        //    if (isSuccess == false)
                        //    {
                        //        this.AddLog("SendToDoctorPerformance metodunda isSuccess false geldi. SendToDoctorPerformance ObjectID: " + sendToDP.ObjectID.ToString());
                        //        return;
                        //    }

                        //    objectContext.Save();
                        //}
                    }
                    catch (Exception ex)
                    {
                        AddLog("SendDoctorPerformance metodunda hata. " + ex.ToString());
                        continue;
                    }
                }
            }

            AddLog("SendDoctorPerformance metodu başarılı tamamlandı. " + Common.RecTime().ToString());
        }
    }
}