
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
    /// Laboratuvar Alt Test
    /// </summary>
    public partial class LaboratorySubProcedure : SubactionProcedureFlowable
    {
        public partial class LabSubProcedureReportNQL_Class : TTReportNqlObject
        {
        }

        public partial class GetLabSubProcedureByTestAndRequest_Class : TTReportNqlObject
        {
        }

        public partial class GetLabSubProcByTestDef_Class : TTReportNqlObject
        {
        }

        public partial class GetByLaboratoryProcedure_Class : TTReportNqlObject
        {
        }

        public partial class GetLabSubProcedureByFilter_Class : TTReportNqlObject
        {
        }

        protected override void PostInsert()
        {
            #region PostInsert
            base.PostInsert();
            if (IsOldAction != true)
            {
                //CreationDate base.PostInsert inde set ediliyor, o nedenle null gelme ihtimali yok.
                if (PerformedDate == null)
                   PerformedDate = CreationDate;
                
                CancelPatientAccTrxsIfHealthCommittee();

                if (SubEpisode != null && SendToENabiz(true))
                {
                    new SendToENabiz(ObjectContext, SubEpisode, ObjectID, ObjectDef.Name, "105", Common.RecTime());
                }

                // Obje insert olduğu zaman sonucu gelmiş oluyor. o nedenle Panic değer notification işlemi kontrol ediliyor.
                CheckPanicValueAndInsertNotification(this);
            }

            #endregion PostInsert
        }

        protected override void PostUpdate()
        {
            #region PostUpdate
            base.PostUpdate();
            CancelPatientAccTrxsIfHealthCommittee();
            #endregion PostUpdate
        }

        #region Methods

        override public bool SendToENabiz(bool isNewInserted)
        {
            if (IsOldAction == true)
                return false;

            //alt testlerin ücretlenir olanlarının nabız a gönderilmesi gerekiyor o nedenle aşağıdaki kontrol eklendi.
            if (Eligible == true && ProcedureObject.Chargable == true)
                return true;
            else
                return false;
        }

        override protected void OnConstruct()
        {
            base.OnConstruct();
            ITTObject ttObject = (ITTObject)this;
        }

        public override string GetDVOBransKodu(AccountTransaction accTrx)
        {
            if (MasterSubActionProcedure != null) // LaboratoryProcedure ün Branş Kodu döndürülür
                return MasterSubActionProcedure.GetDVOBransKodu(accTrx);

            return base.GetDVOBransKodu(accTrx);
        }

        public override string GetDVODrTescilNo(string branchCode)
        {
            if (MasterSubActionProcedure != null) // LaboratoryProcedure ün Dr. Tescil No döndürülür
                return MasterSubActionProcedure.GetDVODrTescilNo(branchCode);

            return base.GetDVODrTescilNo(branchCode);
        }

        public override ResUser GetDVOIstemYapanDr()
        {
            if (MasterSubActionProcedure != null) // LaboratoryProcedure ün İstem Yapan Doktoru döndürülür
                return MasterSubActionProcedure.GetDVOIstemYapanDr();

            return base.GetDVOIstemYapanDr();
        }

        public override HizmetKayitIslemleri.tahlilSonucDVO[] GetDVOTahlilSonuclari()
        {
            string tahlilTipi = "0";
            List<HizmetKayitIslemleri.tahlilSonucDVO> tahlilSonucDVOList = new List<HizmetKayitIslemleri.tahlilSonucDVO>();

            if (ProcedureObject != null && ProcedureObject is LaboratoryTestDefinition)
                tahlilTipi = ((LaboratoryTestDefinition)ProcedureObject).TahlilTipi != null ? ((LaboratoryTestDefinition)ProcedureObject).TahlilTipi.tahlilTipKodu : "0";

            if (!string.IsNullOrEmpty(Result))
            {
                HizmetKayitIslemleri.tahlilSonucDVO tahlilSonucDVO = new HizmetKayitIslemleri.tahlilSonucDVO();
                tahlilSonucDVO.tahlilTipi = tahlilTipi;
                tahlilSonucDVO.sonuc = Result.Length > 14 ? Result.Substring(0, 14) : Result;

                if (!string.IsNullOrEmpty(Unit))
                    tahlilSonucDVO.birim = Unit.Length > 14 ? Unit.Substring(0, 14) : Unit;

                tahlilSonucDVOList.Add(tahlilSonucDVO);
            }
            else if (LongReport != null)
            {
                HizmetKayitIslemleri.tahlilSonucDVO tahlilSonucDVO = new HizmetKayitIslemleri.tahlilSonucDVO();
                tahlilSonucDVO.tahlilTipi = tahlilTipi;

                string rtfStringOfLongReport = Common.GetTextOfRTFString(LongReport.ToString());
                if (!string.IsNullOrEmpty(rtfStringOfLongReport))
                    tahlilSonucDVO.sonuc = rtfStringOfLongReport.Length > 14 ? rtfStringOfLongReport.Substring(0, 14) : rtfStringOfLongReport.Trim();

                if (!string.IsNullOrEmpty(Unit))
                    tahlilSonucDVO.birim = Unit.Length > 14 ? Unit.Substring(0, 14) : Unit;

                tahlilSonucDVOList.Add(tahlilSonucDVO);
            }

            if (tahlilSonucDVOList.Count > 0)
                return tahlilSonucDVOList.ToArray();

            return null;
        }


        protected void CheckPanicValueAndInsertNotification(LaboratorySubProcedure laboratorySubProcedure)
        {
            if (!String.IsNullOrEmpty(Result))
            {
                //Panic değer bir sonuç gelmiş ise
                if ((Panic == LaboratoryAbnormalFlagsEnum.HH || Panic == LaboratoryAbnormalFlagsEnum.LL))
                {
                    string notificationDesc = null;
                    string resultDateStr = null;
                    string testName = null;
                    LaboratoryProcedure masterSubactionProcedure = (LaboratoryProcedure)MasterSubActionProcedure;

                    if (masterSubactionProcedure.ResultDate != null)
                        resultDateStr = Convert.ToString(masterSubactionProcedure.ResultDate);

                    testName = masterSubactionProcedure.ProcedureObject?.Code + "-" + masterSubactionProcedure.ProcedureObject?.Name + " " + ProcedureObject?.Code + "-" + ProcedureObject?.Name;

                    notificationDesc = resultDateStr + " tarihinde sonuçlanmış " + testName + " alt tetkiğinin sonucu panik değer görülmüştür.";
                    notificationDesc = notificationDesc + " Sonuç : " + Result.ToString() + " " + Unit?.ToString() + " Referans Aralığı (" + Reference?.ToString() + ")";

                    LaboratoryResultNotificationInfo labResultNotificationInfo = new LaboratoryResultNotificationInfo(ObjectContext);
                    labResultNotificationInfo.CreationDate = DateTime.Now;
                    labResultNotificationInfo.Description = notificationDesc;
                    labResultNotificationInfo.IsSeen = false;
                    labResultNotificationInfo.RequestDoctorID = masterSubactionProcedure.Laboratory.RequestDoctor == null ? Guid.Empty : masterSubactionProcedure.Laboratory.RequestDoctor.ObjectID;

                    labResultNotificationInfo.LaboratorySubProcedure = laboratorySubProcedure;

                    //Notification Gönder
                    string paramPanicNotification = TTObjectClasses.SystemParameter.GetParameterValue("LABPANICNOTIFICATION", "FALSE");


                    //Notification Gönder
                    if (masterSubactionProcedure.Laboratory.RequestDoctor == null && paramPanicNotification == "TRUE")
                    {
                        string messageText = "";
                        List<string> doctorlist = new List<string>();
                        doctorlist.Add(masterSubactionProcedure.Laboratory.RequestDoctor.ObjectID.ToString());

                        messageText += "Sayın Dr. " + masterSubactionProcedure.Laboratory.RequestDoctor.Name + ", ";
                        messageText += masterSubactionProcedure.Laboratory.SubEpisode.ProtocolNo + " kabul numaralı ";
                        messageText += masterSubactionProcedure.Laboratory.SubEpisode.Episode.Patient != null ? ("'" + masterSubactionProcedure.Laboratory.SubEpisode.Episode.Patient.FullName + "' hastası için ") : "";
                        messageText += notificationDesc;

                        TTUtils.AtlasNotificationContainer atlasNotification = new TTUtils.AtlasNotificationContainer();
                        atlasNotification.users = doctorlist;
                        atlasNotification.notificationType = TTUtils.AtlasNotificationType.Info;
                        atlasNotification.contentType = TTUtils.AtlasContentType.LaboratoryPanicNotification;

                        atlasNotification.content = messageText;
                        string notificationStr = Newtonsoft.Json.JsonConvert.SerializeObject(atlasNotification);
                        try
                        {
                            TTUtils.AtlasSignalRHubFactory.Instance.HandleUserNotification(notificationStr);
                        }
                        catch { }

                    }

                }
            }
        }
        #endregion Methods

    }
}