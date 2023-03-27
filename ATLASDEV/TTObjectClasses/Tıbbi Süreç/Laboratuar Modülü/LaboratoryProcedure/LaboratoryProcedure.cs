
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
    /// Laboratuvar Test
    /// </summary>
    public partial class LaboratoryProcedure : SubactionProcedureFlowable
    {
        public partial class OLAP_GetLabProcedure_Class : TTReportNqlObject
        {
        }

        public partial class LaboratoryProcedureReportNQL_Class : TTReportNqlObject
        {
        }

        public partial class GetLabProcedureByBarcodeId_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetCancelledLabProcedure_Class : TTReportNqlObject
        {
        }

        public partial class GetLaboratoryProcedureByEpisode_Class : TTReportNqlObject
        {
        }

        public partial class GetLabProcByPatientByTestByDate_Class : TTReportNqlObject
        {
        }

        public partial class GetLaboratoryProcedureBySubEpisode_Class : TTReportNqlObject
        {
        }

        public partial class GetLabProcedureByTestAndRequest_Class : TTReportNqlObject
        {
        }

        public partial class GetLabProcedureByTabAndRequest_Class : TTReportNqlObject
        {
        }

        public partial class GetRejectedLaboratoryProceduresByDate_Class : TTReportNqlObject
        {
        }

        public partial class GetLabProcedureByFilter_Class : TTReportNqlObject
        {
        }

        public partial class GetOnlyApprovedProcedures_Class : TTReportNqlObject
        {
        }

        public partial class GetLabProcedureByRequestTab_Class : TTReportNqlObject
        {
        }


        #region Methods
        protected override void PostInsert()
        {
            #region PostInsert

            base.PostInsert();

            if (IsOldAction != true)
                CancelPatientAccTrxsIfHealthCommittee();

            if (((LaboratoryRequest)EpisodeAction).SourceObjectID != null)
                RequestedTab = null;


            if (RequestedTab == null)
                RequestedTab = ((LaboratoryTestDefinition)ProcedureObject).RequestFormTab;

            #endregion PostInsert
        }

        protected override void PostUpdate()
        {
            #region PostUpdate

            base.PostUpdate();

            if (IsOldAction != true)
                CancelPatientAccTrxsIfHealthCommittee();

            #endregion PostUpdate
        }

        protected void PreTransition_SampleAccept2Completed()
        {
            // From State : SampleAccept   To State : Completed
            #region PreTransition_SampleAccept2Completed

            if (OlapDate == null)
                OlapDate = DateTime.Now;
            #endregion PreTransition_SampleAccept2Completed
        }

        protected void PostTransition_SampleAccept2PendingCancel()
        {
            // From State : SampleAccept   To State : PendingCancel
            #region PostTransition_SampleAccept2PendingCancel
            foreach (AccountTransaction at in AccountTransactions)
            {
                if (at.CurrentStateDefID != AccountTransaction.States.Cancelled)
                {
                    if (at.IsAllowedToCancel == false)
                        throw new TTException(TTUtils.CultureService.GetText("M26178", "İşlem hareketi '") + at.CurrentStateDef.DisplayText + "' durumunda olduğu için iptal edilemez. Öncelikle ödeme/faturalama işleminin iptal edilmesi gerekmektedir!\r\n" + "Hizmet : " + at.ExternalCode + " " + at.Description);

                    at.CurrentStateDefID = AccountTransaction.States.Cancelled;
                }
            }
            #endregion PostTransition_SampleAccept2PendingCancel
        }

        protected void PreTransition_Procedure2Completed()
        {
            // From State : Procedure   To State : Completed
            #region PreTransition_Procedure2Completed

            if (OlapDate == null)
                OlapDate = DateTime.Now;
            #endregion PreTransition_Procedure2Completed
        }

        protected void CheckPanicValueAndInsertNotification(LaboratoryProcedure laboratoryProcedure)
        {
            if (!String.IsNullOrEmpty(Result))
            {
                //Panic değer bir sonuç gelmiş ise
                if ((Panic == LaboratoryAbnormalFlagsEnum.HH || Panic == LaboratoryAbnormalFlagsEnum.LL))
                {
                    string notificationDesc = null;
                    notificationDesc = Convert.ToString(ResultDate) + " tarihinde sonuçlanmış " + ProcedureObject?.Code + "-" + ProcedureObject?.Name + " tetkiğinin sonucu panik değer görülmüştür.";
                    notificationDesc = notificationDesc + " Sonuç : " + Result.ToString() + " " + Unit?.ToString() + " Referans Aralığı (" + Reference?.ToString() + ")";

                    LaboratoryResultNotificationInfo labResultNotificationInfo = new LaboratoryResultNotificationInfo(ObjectContext);
                    labResultNotificationInfo.CreationDate = DateTime.Now;
                    labResultNotificationInfo.Description = notificationDesc;
                    labResultNotificationInfo.IsSeen = false;
                    labResultNotificationInfo.RequestDoctorID = laboratoryProcedure.Laboratory.RequestDoctor == null ? Guid.Empty : laboratoryProcedure.Laboratory.RequestDoctor.ObjectID;
                    labResultNotificationInfo.LaboratoryProcedure = laboratoryProcedure;
                }
            }
        }

        protected void PostTransition_Procedure2Completed()
        {
            // From State : Procedure   To State : Completed
            #region PostTransition_Procedure2Completed

            PerformedDate = Common.RecTime();

            if (SubEpisode != null && SendToENabiz(true))
            {
                SendToENabiz s = new SendToENabiz();    //Paket içeriğine gerçekleşme zamanı bilgisi sonradan eklendiği için işlemler sonuçlanınca 102 paketi tekrar gönderiliyor.
                                                        //s.ENABIZSend102(this.ObjectID.ToString());
                new SendToENabiz(ObjectContext, SubEpisode, ObjectID, ObjectDef.Name, "102", Common.RecTime());
                new SendToENabiz(ObjectContext, SubEpisode, ObjectID, ObjectDef.Name, "105", Common.RecTime());
            }

            CheckPanicValueAndInsertNotification(this);


            #endregion PostTransition_Procedure2Completed
        }
        protected void PostTransition_SampleTaking2Completed()
        {
            PerformedDate = Common.RecTime();

            if (SubEpisode != null && SendToENabiz(true))
            {
                SendToENabiz s = new SendToENabiz();    //Paket içeriğine gerçekleşme zamanı bilgisi sonradan eklendiği için işlemler sonuçlanınca 102 paketi tekrar gönderiliyor.
                //s.ENABIZSend102(this.ObjectID.ToString()); Performeddate set edildiği halde henüz kaydedilmediği için veri tabanında null. O yüzden kapatılıp satır eklendi. ASLI
                new SendToENabiz(ObjectContext, SubEpisode, ObjectID, ObjectDef.Name, "102", Common.RecTime());
                new SendToENabiz(ObjectContext, SubEpisode, ObjectID, ObjectDef.Name, "105", Common.RecTime());
            }
            CheckPanicValueAndInsertNotification(this);
        }

        protected void PostTransition_Approve2Completed()
        {
            // From State : Approve   To State : Completed
            #region PostTransition_Approve2Completed

            PerformedDate = Common.RecTime();

            if (SubEpisode != null && SendToENabiz(true))
            {
                SendToENabiz s = new SendToENabiz();            //Paket içeriğine gerçekleşme zamanı bilgisi sonradan eklendiği için işlemler sonuçlanınca 102 paketi tekrar gönderiliyor.
                                                                //s.ENABIZSend102(this.ObjectID.ToString());
                new SendToENabiz(ObjectContext, SubEpisode, ObjectID, ObjectDef.Name, "102", Common.RecTime());
                new SendToENabiz(ObjectContext, SubEpisode, ObjectID, ObjectDef.Name, "105", Common.RecTime());
            }

            CheckPanicValueAndInsertNotification(this);
            #endregion PostTransition_Approve2Completed
        }

        protected void PostTransition_PendingCancel2Completed()
        {
            // From State : PendingCancel   To State : Completed
            #region PostTransition_PendingCancel2Completed

            foreach (AccountTransaction at in AccountTransactions)
            {
                if (at.CurrentStateDefID == AccountTransaction.States.Cancelled)
                    at.CurrentStateDefID = AccountTransaction.States.New;
            }

            #endregion PostTransition_PendingCancel2Completed
        }

        protected void PreTransition_New2Completed()
        {
            // From State : New   To State : Completed
            #region PreTransition_New2Completed

            if (OlapDate == null)
                OlapDate = DateTime.Now;
            #endregion PreTransition_New2Completed
        }

        protected void PostTransition_New2PendingCancel()
        {
            // From State : New   To State : PendingCancel
            #region PostTransition_New2PendingCancel
            foreach (AccountTransaction at in AccountTransactions)
            {
                if (at.CurrentStateDefID != AccountTransaction.States.Cancelled)
                {
                    if (at.IsAllowedToCancel == false)
                        throw new TTException(TTUtils.CultureService.GetText("M26178", "İşlem hareketi '") + at.CurrentStateDef.DisplayText + "' durumunda olduğu için iptal edilemez. Öncelikle ödeme/faturalama işleminin iptal edilmesi gerekmektedir!\r\n" + "Hizmet : " + at.ExternalCode + " " + at.Description);

                    at.CurrentStateDefID = AccountTransaction.States.Cancelled;
                }
            }
            #endregion PostTransition_New2PendingCancel
        }

        protected void PostTransition_SampleAccept2Cancelled()
        {
            // From State : SampleAccept   To State : Cancelled
            #region PostTransition_SampleAccept2Cancelled

            if (CurrentStateDefID != LaboratoryProcedure.States.Cancelled)
                Cancel();
            bool hasUnCancelledTest = false;
            foreach (LaboratoryProcedure test in Laboratory.LaboratoryProcedures)
            {
                if (test.CurrentStateDefID != LaboratoryProcedure.States.Cancelled)
                {
                    hasUnCancelledTest = true;
                    break;
                }
            }

            if (!hasUnCancelledTest)
                Laboratory.CurrentStateDefID = LaboratoryRequest.States.Cancelled;
            #endregion PostTransition_SampleAccept2Cancelled

        }

        protected void PostTransition_SampleTaking2Cancelled()
        {
            #region PostTransition_SampleTaking2Cancelled

            if (CurrentStateDefID != LaboratoryProcedure.States.Cancelled)
                Cancel();
            bool hasUnCancelledTest = false;
            foreach (LaboratoryProcedure test in Laboratory.LaboratoryProcedures)
            {
                if (test.CurrentStateDefID != LaboratoryProcedure.States.Cancelled)
                {
                    hasUnCancelledTest = true;
                    break;
                }
            }

            if (!hasUnCancelledTest)
                Laboratory.CurrentStateDefID = LaboratoryRequest.States.Cancelled;

            //XXXXXX tarafindan da tetkik sil yapiliyor.
            string resultMsg = LaboratoryProcedure.DeleteLaboratoryProcedureFromLIS(SpecimenId.ToString(), ObjectID.ToString(), String.Empty);
            if (resultMsg != "")
                throw new TTException("XXXXXX'dan tetkik silme işlemi yapılamadığı için işlem de iptal edilmemiştir. Hata : " + resultMsg);

            #endregion PostTransition_SampleTaking2Cancelled
        }

        protected void PostTransition_SampleLaboratoryAccept2Cancelled()
        {
            #region PostTransition_SampleLaboratoryAccept2Cancelled

            if (CurrentStateDefID != LaboratoryProcedure.States.Cancelled)
                Cancel();
            bool hasUnCancelledTest = false;
            foreach (LaboratoryProcedure test in Laboratory.LaboratoryProcedures)
            {
                if (test.CurrentStateDefID != LaboratoryProcedure.States.Cancelled)
                {
                    hasUnCancelledTest = true;
                    break;
                }
            }

            if (!hasUnCancelledTest)
                Laboratory.CurrentStateDefID = LaboratoryRequest.States.Cancelled;

            //XXXXXX tarafindan da tetkik sil yapiliyor.
            string resultMsg = LaboratoryProcedure.DeleteLaboratoryProcedureFromLIS(SpecimenId.ToString(), ObjectID.ToString(), String.Empty);
            if (resultMsg != "")
                throw new TTException("XXXXXX'dan tetkik silme işlemi yapılamadığı için işlem de iptal edilmemiştir. Hata : " + resultMsg);

            #endregion PostTransition_SampleLaboratoryAccept2Cancelled
        }

        protected void PostTransition_Approve2SampleReject()
        {
            // From State : Approve   To State : SampleReject
            #region PostTransition_Approve2SampleReject
            CreateAndSendENabizMessageToPatient(this);
            #endregion PostTransition_Approve2SampleReject
        }

        protected void PostTransition_Procedure2SampleReject()
        {
            // From State : Approve   To State : SampleReject
            #region PostTransition_Procedure2Completed
            CreateAndSendENabizMessageToPatient(this);
            #endregion PostTransition_Procedure2SampleReject
        }

        protected void PostTransition_SampleLaboratoryAccept2SampleReject()
        {
            // From State : Approve   To State : SampleReject
            #region PostTransition_SampleLaboratoryAccept2SampleReject
            CreateAndSendENabizMessageToPatient(this);
            #endregion PostTransition_SampleLaboratoryAccept2SampleReject
        }

        protected void PostTransition_SampleLaboratoryAccept2Completed()
        {
            PerformedDate = Common.RecTime();

            if (SubEpisode != null && SendToENabiz(true))
            {
                SendToENabiz s = new SendToENabiz();            //Paket içeriğine gerçekleşme zamanı bilgisi sonradan eklendiği için işlemler sonuçlanınca 102 paketi tekrar gönderiliyor.
                                                                //s.ENABIZSend102(this.ObjectID.ToString());
                new SendToENabiz(ObjectContext, SubEpisode, ObjectID, ObjectDef.Name, "102", Common.RecTime());
                new SendToENabiz(ObjectContext, SubEpisode, ObjectID, ObjectDef.Name, "105", Common.RecTime());
            }
            CheckPanicValueAndInsertNotification(this);
        }



        //Sonuçlanma tarihi cihazdan farklı gelebildiği için PerformedDate i ResultDate olarak set etme kodu kapatıldı.
        //LaboratoryProcedure testi Completed (Sonuçlandı) aşamasına geçtiği aşamalarda PerformedDate olarak set ediliyor.
        /* public override void SetPerformedDate() // İşlemin onaylandığı tarih set edecek şekilde override edilmeli
         {


             if (this.ResultDate != null)
                 this.PerformedDate = this.ResultDate;


         }*/

        override protected void OnConstruct()
        {
            base.OnConstruct();
            ITTObject ttObject = (ITTObject)this;
        }

        public LaboratoryProcedure(TTObjectContext objectContext, LaboratoryProcedure labProcedure) : this(objectContext)
        {
            CurrentStateDefID = LaboratoryProcedure.States.SampleAccept;
            ActionDate = Common.RecTime();
            MasterResource = labProcedure.Laboratory.MasterResource;
            FromResource = labProcedure.Laboratory.FromResource;
            ProcedureObject = labProcedure.ProcedureObject;
            ProcedureDepartment = labProcedure.ProcedureDepartment;
            Episode = labProcedure.Laboratory.Episode;
        }



        public class MicrobiologyTestOrderInfo
        {
            public Guid CultureSubActionID;
            public Guid ActionID;
            public Guid TestID;
            public Guid ProcedureUser;
            public string Result;
            public string Reference;
            public string Unit;
        }

        public static void MicrobiologyTestOrder(LaboratoryProcedure.MicrobiologyTestOrderInfo testOrderInfo)
        {
            TTObjectContext context = new TTObjectContext(false);
            LaboratoryProcedure defaultCultureTestProc = (LaboratoryProcedure)context.GetObject(testOrderInfo.CultureSubActionID, "LaboratoryProcedure");
            LaboratoryProcedure newCultureTestProc = new LaboratoryProcedure(context);
            LaboratoryTestDefinition testDefinition = (LaboratoryTestDefinition)context.GetObject(testOrderInfo.TestID, "LaboratoryTestDefinition");
            LaboratoryRequest labRequest = (LaboratoryRequest)context.GetObject(testOrderInfo.ActionID, "LABORATORYREQUEST");

            TTUser tt_User = TTUser.GetUser(testOrderInfo.ProcedureUser);
            ResUser procedureUser = null;
            procedureUser = (ResUser)context.GetObject(tt_User.UserObject.ObjectID, "RESUSER");


            newCultureTestProc.MasterResource = defaultCultureTestProc.MasterResource;
            newCultureTestProc.FromResource = defaultCultureTestProc.MasterResource; //Laboratuvar tarafından oluşturulduğu için.
            newCultureTestProc.ProcedureObject = testDefinition;
            newCultureTestProc.Amount = testDefinition.PriceCoefficient == null ? 1 : testDefinition.PriceCoefficient;
            newCultureTestProc.ResultDescription = testOrderInfo.Result;
            //newCultureTestProc.Reference = testOrderInfo.Reference;
            //newCultureTestProc.Unit = testOrderInfo.Unit;
            newCultureTestProc.RequestedTab = defaultCultureTestProc.RequestedTab;
            newCultureTestProc.RequestDate = Common.RecTime();
            newCultureTestProc.ResultDate = Common.RecTime();

            if (defaultCultureTestProc.SampleAcceptionDate != null)
            {
                newCultureTestProc.SampleAcceptionDate = defaultCultureTestProc.SampleAcceptionDate;
            }

            newCultureTestProc.ProcedureUser = procedureUser;
            newCultureTestProc.SampleUser = procedureUser;
            newCultureTestProc.RequestUser = procedureUser;
            newCultureTestProc.CurrentStateDefID = LaboratoryProcedure.States.New;
            //newCultureTestProc.Update();

            labRequest.LaboratoryProcedures.Add(newCultureTestProc);
            context.Save();

            newCultureTestProc.CurrentStateDefID = LaboratoryProcedure.States.SampleAccept;

            if (labRequest.CurrentStateDefID == LaboratoryRequest.States.Procedure)
            {
                newCultureTestProc.AccountOperation(AccountOperationTimeEnum.PRE);
                newCultureTestProc.Update();
            }

            if (labRequest.CurrentStateDefID == LaboratoryRequest.States.Completed)
            {
                newCultureTestProc.AccountOperation(AccountOperationTimeEnum.POST);
                newCultureTestProc.CurrentStateDefID = LaboratoryProcedure.States.Completed;
                newCultureTestProc.Update();
            }

            context.Save();
        }

        public class LabResultInfo
        {
            public Guid SubActionID;
            public Guid ActionID;
            public Guid TestID;
            public string Result;
            public string Reference;
            public string OzelReference;
            public string Aciklama;
            public string Birim;
            public HighLowEnum Warning;
            public HighLowEnum Panic;
            public Guid TeknisyenID;
            public DateTime TeknisyenOnayTarihi;
            public Guid OnayUzmani;
            public DateTime UzmanOnayTarihi;
            public string UzunRapor;
            public bool Antibiyogram;
            public bool MicrobiologyPanicNotification;
            public bool IsLastTest;
            public int BarcodeNo;
            public string TestGroupName;
            public string TestEnvironmentName;

            //
            public DateTime KabulTarihi;
            public DateTime NumuneKabulTarihi;
        }

        //CheckBoundedTestResults
        private static void CheckBoundedTestResults(LaboratoryRequest labRequest, TTObjectContext context)
        {
            foreach (LaboratoryProcedure labProc in labRequest.LaboratoryProcedures)
            {
                if (((LaboratoryTestDefinition)labProc.ProcedureObject).IsBoundedTest != null)
                {
                    if (((LaboratoryTestDefinition)labProc.ProcedureObject).IsBoundedTest == true)
                    {
                        foreach (LaboratoryGridBoundedTestDefinition testdef in ((LaboratoryTestDefinition)labProc.ProcedureObject).BoundedTests)
                        {
                            foreach (LaboratoryProcedure lp in labRequest.LaboratoryProcedures)
                            {
                                if (((LaboratoryTestDefinition)lp.ProcedureObject).ObjectID == testdef.LaboratoryTest.ObjectID)
                                {
                                    if (labProc.CurrentStateDefID == LaboratoryProcedure.States.Completed && lp.CurrentStateDefID != LaboratoryProcedure.States.Completed
                                        && lp.CurrentStateDefID != LaboratoryProcedure.States.Cancelled && lp.CurrentStateDefID != LaboratoryProcedure.States.PendingCancel)
                                    {
                                        if (String.IsNullOrEmpty(lp.Result))
                                        {
                                            lp.CurrentStateDefID = LaboratoryProcedure.States.PendingCancel;
                                            context.Save();
                                        }
                                    }

                                }
                            }
                        }
                    }
                }
            }
        }

        //CompleteLaboratoryRequest
        public static void CompleteLaboratoryRequest(Guid episodeActionID)
        {
            TTObjectContext context = new TTObjectContext(false);
            LaboratoryRequest labRequest = (LaboratoryRequest)context.GetObject(episodeActionID, "LABORATORYREQUEST");

            //
            string sysparam = TTObjectClasses.SystemParameter.GetParameterValue("CHECKBOUNDEDTESTRESULTS", "FALSE");
            if (sysparam == "TRUE")
            {
                CheckBoundedTestResults(labRequest, context);
            }
            //

            bool _toComplete = true;

            if (labRequest.LaboratoryProcedures.Count > 0)
            {
                foreach (LaboratoryProcedure labProc in labRequest.LaboratoryProcedures)
                {
                    if (labProc.CurrentStateDefID != LaboratoryProcedure.States.Cancelled && labProc.CurrentStateDefID != LaboratoryProcedure.States.Completed && labProc.CurrentStateDefID != LaboratoryProcedure.States.SampleReject && labProc.CurrentStateDefID != LaboratoryProcedure.States.PendingCancel)
                    {
                        _toComplete = false;
                        break;
                    }
                }
            }

            if (_toComplete == true)
            {
                if (labRequest.CurrentStateDefID == LaboratoryRequest.States.Procedure || labRequest.CurrentStateDefID == LaboratoryRequest.States.RequestAcception)
                {
                    labRequest.CurrentStateDefID = LaboratoryRequest.States.Completed;
                    context.Save();
                }
            }
        }

        public static string temporaryEpisodeState;
        public static bool isEpisodeUpdated;

        public static void UpdateEpisodeStateToOpen(Guid episodeActionID)
        {
            TTObjectContext contextOpen = new TTObjectContext(false);
            LaboratoryRequest labRequestOpen = (LaboratoryRequest)contextOpen.GetObject(episodeActionID, "LABORATORYREQUEST");
            if (labRequestOpen.Episode.CurrentStateDefID != Episode.States.Open)
            {
                temporaryEpisodeState = labRequestOpen.Episode.CurrentStateDefID.ToString();
                labRequestOpen.Episode.CurrentStateDefID = Episode.States.Open;
                isEpisodeUpdated = true;
                contextOpen.Save();
            }

        }

        public static void UpdateEpisodeToOldState(Guid episodeActionID)
        {
            TTObjectContext contextOldState = new TTObjectContext(false);
            LaboratoryRequest labRequestOldState = (LaboratoryRequest)contextOldState.GetObject(episodeActionID, "LABORATORYREQUEST");

            if (temporaryEpisodeState != string.Empty && isEpisodeUpdated == true)
            {
                labRequestOldState.Episode.CurrentStateDefID = new Guid(temporaryEpisodeState);
                temporaryEpisodeState = string.Empty;
                isEpisodeUpdated = false;
                contextOldState.Save();
            }
        }

        public static void SaveLabResult(LaboratoryProcedure.LabResultInfo labResult)
        {
            Exception ex = null;

            ex = TryToSaveLabResults(labResult);

            if (ex != null)
            {
                if (ex.Message.Contains("DBConcurrencyException") || ex.Message.Contains("SM0164"))
                {
                    ex = TryToSaveLabResults(labResult);
                }
                else
                {
                    throw new TTException(ex.ToString());
                }
            }

        }

        private static Exception TryToSaveLabResults(LaboratoryProcedure.LabResultInfo labResult)
        {

            string temporaryEpisodeStateLocal = string.Empty;
            bool isEpisodeUpdatedLocal = false;

            try
            {
                TTObjectContext contextOpen = new TTObjectContext(false);
                LaboratoryRequest labRequestOpen = (LaboratoryRequest)contextOpen.GetObject(labResult.ActionID, "LABORATORYREQUEST");
                if (labRequestOpen.Episode.CurrentStateDefID != Episode.States.Open)
                {
                    temporaryEpisodeStateLocal = labRequestOpen.Episode.CurrentStateDefID.ToString();
                    labRequestOpen.Episode.CurrentStateDefID = Episode.States.Open;
                    contextOpen.Save();
                    isEpisodeUpdatedLocal = true;
                }


                TTObjectContext context = new TTObjectContext(false);

                if (labResult.SubActionID == Guid.Empty) // Laboratuvarda eklenmiş veya tam kan sayımı gibi panel'in alt testi
                {
                    LaboratoryProcedure addLabProcedure = new LaboratoryProcedure(context);
                    LaboratoryTestDefinition labReqTestDef = (LaboratoryTestDefinition)context.GetObject(labResult.TestID, "LaboratoryTestDefinition");
                    addLabProcedure.MasterResource = labReqTestDef.Departments[0].Department; //tanımdaki ilk bölümü alır
                    addLabProcedure.FromResource = addLabProcedure.MasterResource; //lab'tan istenmiş
                    addLabProcedure.ProcedureObject = labReqTestDef;
                    LaboratoryRequest labRequest = (LaboratoryRequest)context.GetObject(labResult.ActionID, "LABORATORYREQUEST");
                    addLabProcedure.EpisodeAction = labRequest;
                    addLabProcedure.Amount = labReqTestDef.PriceCoefficient == null ? 1 : labReqTestDef.PriceCoefficient;

                    //
                    if (String.IsNullOrEmpty(labResult.Result))
                    {
                        throw new TTException(TTUtils.CultureService.GetText("M26920", "Sonuç değeri boş gönderilemez!") + " ActionID : " + labResult.ActionID.ToString() + " SubActionID : " + Guid.Empty.ToString());
                    }
                    //

                    addLabProcedure.Result = String.IsNullOrEmpty(labResult.Result) ? String.Empty : labResult.Result;
                    addLabProcedure.Reference = String.IsNullOrEmpty(labResult.Reference) ? String.Empty : labResult.Reference;
                    addLabProcedure.Unit = String.IsNullOrEmpty(labResult.Birim) ? String.Empty : labResult.Birim;
                    //addLabProcedure.Warning = labResult.Warning == null ? HighLowEnum.None: labResult.Warning ;
                    addLabProcedure.Warning = labResult.Warning;
                    //***
                    //addLabProcedure.Panic = labResult.Panic == null ? HighLowEnum.None : labResult.Panic;
                    //addLabProcedure.Panic = labResult.Panic;

                    //if (labResult.MicrobiologyPanicNotification != null)
                    {
                        addLabProcedure.MicrobiologyPanicNotification = labResult.MicrobiologyPanicNotification;
                    }

                    if (labResult.NumuneKabulTarihi != null)
                    {
                        addLabProcedure.SampleAcceptionDate = labResult.NumuneKabulTarihi;
                    }

                    //***
                    addLabProcedure.CurrentStateDefID = LaboratoryProcedure.States.New;
                    addLabProcedure.ResultDate = Common.RecTime();
                    addLabProcedure.ResultDescription = String.IsNullOrEmpty(labResult.Aciklama) ? String.Empty : labResult.Aciklama;
                    labRequest.BarcodeID = labResult.BarcodeNo;
                    if (labResult.UzunRapor != null)
                    {
                        Encoding enc = Encoding.GetEncoding(1254);
                        char[] c = enc.GetChars(Convert.FromBase64String(labResult.UzunRapor));
                        addLabProcedure.LongReport = new string(c);
                    }
                    if (labResult.OzelReference != null)
                    {
                        Encoding enc = Encoding.GetEncoding(1254);
                        char[] c = enc.GetChars(Convert.FromBase64String(labResult.OzelReference));
                        addLabProcedure.SpecialReference = new string(c);
                    }


                    if (labResult.OnayUzmani != null && labResult.OnayUzmani != Guid.Empty)
                    {
                        TTUser ttUser = TTUser.GetUser(labResult.OnayUzmani);
                        if (ttUser != null)
                        {
                            if (ttUser.UserObject != null)
                            {
                                labRequest.ApprovedBy = (ResUser)context.GetObject(ttUser.UserObject.ObjectID, "RESUSER");
                            }
                        }
                    }

                    addLabProcedure.CurrentStateDefID = LaboratoryProcedure.States.Completed;
                    labRequest.LaboratoryProcedures.Add(addLabProcedure);
                    //State ilerletme ile ilgili kısım yazılacak
                    //if (labResult.IsLastTest && addLabProcedure.Laboratory.CurrentStateDefID == LaboratoryRequest.States.Procedure)
                    //{
                    //    addLabProcedure.Laboratory.CurrentStateDefID = LaboratoryRequest.States.Completed;
                    //    UpdateEpisodeToOldState(labResult.ActionID);
                    //}
                }
                else
                {
                    SubactionProcedureFlowable baseProc = null;
                    baseProc = (SubactionProcedureFlowable)context.GetObject(labResult.SubActionID, TTObjectDefManager.Instance.ObjectDefs[typeof(SubactionProcedureFlowable).Name], false);
                    if (baseProc == null)
                    {
                        //throw new Exception("Onaylanmaya çalışılan testin nesne ID'si yok! Bilgi İşlemi arayınız.");
                        //if(labResult.IsLastTest)
                        //{
                        //    LaboratoryRequest labRequest = (LaboratoryRequest)context.GetObject(labResult.ActionID, TTObjectDefManager.Instance.ObjectDefs[typeof(LaboratoryRequest).Name], false);
                        //    if(labRequest.CurrentStateDefID == LaboratoryRequest.States.New ||
                        //       labRequest.CurrentStateDefID == LaboratoryRequest.States.Procedure)
                        //    {
                        //        labRequest.CurrentStateDefID = LaboratoryRequest.States.Completed;
                        //        UpdateEpisodeToOldState(labResult.ActionID);
                        //    }
                        //}
                    }
                    else
                    {
                        if (baseProc is LaboratoryProcedure)
                        {
                            LaboratoryProcedure labProc = (LaboratoryProcedure)baseProc;
                            if (labProc.CurrentStateDefID == LaboratoryProcedure.States.New ||
                                labProc.CurrentStateDefID == LaboratoryProcedure.States.Approve ||
                                labProc.CurrentStateDefID == LaboratoryProcedure.States.Completed ||
                                labProc.CurrentStateDefID == LaboratoryProcedure.States.Procedure ||
                                labProc.CurrentStateDefID == LaboratoryProcedure.States.SampleAccept ||
                                labProc.CurrentStateDefID == LaboratoryProcedure.States.PendingCancel)
                            {

                                if (labResult.OnayUzmani != null && labResult.OnayUzmani != Guid.Empty)
                                {
                                    TTUser ttUser = TTUser.GetUser(labResult.OnayUzmani);
                                    if (ttUser != null)
                                    {
                                        if (ttUser.UserObject != null)
                                        {
                                            labProc.Laboratory.ApprovedBy = (ResUser)context.GetObject(ttUser.UserObject.ObjectID, "RESUSER");
                                        }
                                    }
                                }

                                //
                                if (String.IsNullOrEmpty(labResult.Result))
                                {
                                    throw new TTException(TTUtils.CultureService.GetText("M26920", "Sonuç değeri boş gönderilemez!") + " ActionID : " + labResult.ActionID.ToString() + " SubActionID : " + labResult.SubActionID.ToString());
                                }
                                //

                                labProc.Result = String.IsNullOrEmpty(labResult.Result) ? String.Empty : labResult.Result;
                                labProc.Reference = String.IsNullOrEmpty(labResult.Reference) ? String.Empty : labResult.Reference;
                                labProc.Unit = String.IsNullOrEmpty(labResult.Birim) ? String.Empty : labResult.Birim;
                                //labProc.Warning = labResult.Warning == null ? HighLowEnum.None : labResult.Warning; ;
                                labProc.Warning = labResult.Warning; ;
                                //***
                                //labProc.Panic = labResult.Panic == null ? HighLowEnum.None : labResult.Panic;
                                //labProc.Panic = labResult.Panic;

                                //if(labResult.MicrobiologyPanicNotification != null)
                                {
                                    labProc.MicrobiologyPanicNotification = labResult.MicrobiologyPanicNotification;
                                }

                                if (labResult.NumuneKabulTarihi != null)
                                {
                                    labProc.SampleAcceptionDate = labResult.NumuneKabulTarihi;
                                }

                                //*** 
                                labProc.ResultDescription = String.IsNullOrEmpty(labResult.Aciklama) ? String.Empty : labResult.Aciklama;
                                labProc.Laboratory.BarcodeID = labResult.BarcodeNo;
                                labProc.Environment = String.IsNullOrEmpty(labResult.TestEnvironmentName) ? String.Empty : labResult.TestEnvironmentName;
                                labProc.TestGroup = String.IsNullOrEmpty(labResult.TestGroupName) ? String.Empty : labResult.TestGroupName;
                                if (labResult.UzunRapor != null)
                                {
                                    Encoding enc = Encoding.GetEncoding(1254);
                                    char[] c = enc.GetChars(Convert.FromBase64String(labResult.UzunRapor));
                                    labProc.LongReport = new string(c);
                                }

                                if (labResult.OzelReference != null)
                                {
                                    Encoding enc = Encoding.GetEncoding(1254);
                                    char[] c = enc.GetChars(Convert.FromBase64String(labResult.OzelReference));
                                    labProc.SpecialReference = new string(c);
                                }

                                labProc.ResultDate = Common.RecTime();
                                labProc.CurrentStateDefID = LaboratoryProcedure.States.Completed;
                            }
                            //if (labResult.IsLastTest && labProc.Laboratory.CurrentStateDefID == LaboratoryRequest.States.Procedure)
                            //{
                            //    labProc.Laboratory.CurrentStateDefID = LaboratoryRequest.States.Completed;
                            //    UpdateEpisodeToOldState(labResult.ActionID);
                            //}

                        }
                        else if (baseProc is LaboratorySubProcedure)
                        {
                            LaboratorySubProcedure labSubProc = (LaboratorySubProcedure)baseProc;
                            /* if (labSubProc.CurrentStateDefID != LaboratorySubProcedure.States.Cancelled)
                             {

                                 if (labResult.OnayUzmani != null && labResult.OnayUzmani != Guid.Empty)
                                 {
                                     TTUser ttUser = TTUser.GetUser(labResult.OnayUzmani);
                                     if (ttUser != null)
                                     {
                                         if (ttUser.UserObject != null)
                                         {
                                             labSubProc.LaboratoryProcedure.Laboratory.ApprovedBy = (ResUser)context.GetObject(ttUser.UserObject.ObjectID, "RESUSER");
                                         }
                                     }
                                 }

                                 //
                                 if (String.IsNullOrEmpty(labResult.Result))
                                 {
                                     throw new TTException(TTUtils.CultureService.GetText("M26920", "Sonuç değeri boş gönderilemez!") + " ActionID : " + labResult.ActionID.ToString() + " SubActionID : " + labResult.SubActionID.ToString());
                                 }
                                 //

                                 labSubProc.Result = String.IsNullOrEmpty(labResult.Result) ? String.Empty : labResult.Result;
                                 labSubProc.Reference = String.IsNullOrEmpty(labResult.Reference) ? String.Empty : labResult.Reference;
                                 labSubProc.Unit = String.IsNullOrEmpty(labResult.Birim) ? String.Empty : labResult.Birim;
                                 //labSubProc.Warning = labResult.Warning == null ? HighLowEnum.None : labResult.Warning;
                                 labSubProc.Warning = labResult.Warning;
                                 //***
                                 //labSubProc.Panic = labResult.Panic == null ? HighLowEnum.None : labResult.Panic;
                                 labSubProc.Panic = labResult.Panic;

                                 //if(labResult.MicrobiologyPanicNotification != null)
                                 {
                                     labSubProc.MicrobiologyPanicNotification = labResult.MicrobiologyPanicNotification;
                                 }

                                 if (labResult.NumuneKabulTarihi != null)
                                 {
                                     labSubProc.SampleAcceptionDate = labResult.NumuneKabulTarihi;
                                 }

                                 //***
                                 labSubProc.ResultDescription = String.IsNullOrEmpty(labResult.Aciklama) ? String.Empty : labResult.Aciklama;
                                 if (labResult.UzunRapor != null)
                                 {
                                     Encoding enc = Encoding.GetEncoding(1254);
                                     char[] c = enc.GetChars(Convert.FromBase64String(labResult.UzunRapor));
                                     labSubProc.LongReport = new string(c);
                                 }

                                 labSubProc.CurrentStateDefID = LaboratorySubProcedure.States.Completed;
                             }
                             */
                            //if (labResult.IsLastTest && labSubProc.LaboratoryProcedure.Laboratory.CurrentStateDefID == LaboratoryRequest.States.Procedure)
                            //{
                            //    labSubProc.LaboratoryProcedure.Laboratory.CurrentStateDefID = LaboratoryRequest.States.Completed;
                            //    UpdateEpisodeToOldState(labResult.ActionID);
                            //}
                        }
                    }
                }

                context.Save();

                CompleteLaboratoryRequest(labResult.ActionID);

                return null;

            }
            catch (Exception ex)
            {

                return ex;
            }

            finally
            {
                try
                {
                    if (temporaryEpisodeStateLocal != string.Empty && isEpisodeUpdatedLocal == true)
                    {
                        TTObjectContext contextOldState = new TTObjectContext(false);
                        LaboratoryRequest labRequestOldState = (LaboratoryRequest)contextOldState.GetObject(labResult.ActionID, "LABORATORYREQUEST");

                        labRequestOldState.Episode.CurrentStateDefID = new Guid(temporaryEpisodeStateLocal);
                        contextOldState.Save();
                    }
                }
                catch
                {

                }

            }
        }

        /// <summary>
        /// Seçilmiş olan panel'deki testleri istek olarak oluşturur.
        /// </summary>
        /// <param name="labReqTestDef"></param>
        /// <param name="labProcedure"></param>
        public void CreateTestsFromSelectedPanel()
        {
            LaboratoryTestDefinition labReqTestDef = ProcedureObject as LaboratoryTestDefinition;
            if (labReqTestDef != null)
            {
                foreach (LaboratoryGridPanelTestDefinition panelTestDef in labReqTestDef.PanelTests)
                {
                    LaboratorySubProcedure subProcedure = new LaboratorySubProcedure(ObjectContext);
                    LaboratoryTestDefinition labSubReqTestDef = (LaboratoryTestDefinition)panelTestDef.LaboratoryTest;
                    subProcedure.ProcedureObject = labSubReqTestDef;
                    subProcedure.MasterResource = MasterResource; //labReqTestDef.Departments[0].Department; //tanımdaki ilk bölümü alır
                    subProcedure.FromResource = FromResource;
                    subProcedure.EpisodeAction = EpisodeAction;
                    subProcedure.Eligible = false; // Fatura'ya düşmez.
                    LaboratorySubProcedures.Add(subProcedure);
                }
            }
        }

        public class LabStateInfo
        {
            public Guid SubActionID;
            public Guid ActionID;
            public int Durum; //0 - Kabul Edildi ; 1 - Red edildi
            public Guid RedNedeni;
            public string Aciklama;
            public Guid RedKullanici;
        }

        public static void SaveLabState(LaboratoryProcedure.LabStateInfo labState)
        {
            TTObjectContext context = new TTObjectContext(false);
            SubactionProcedureFlowable baseProc = null;
            baseProc = (SubactionProcedureFlowable)context.GetObject(labState.SubActionID, TTObjectDefManager.Instance.ObjectDefs[typeof(SubactionProcedureFlowable).Name], false);
            if (baseProc == null)
            {
                throw new Exception(SystemMessage.GetMessage(1240));
            }
            else
            {
                if (baseProc is LaboratoryProcedure)
                {
                    LaboratoryProcedure labProc = (LaboratoryProcedure)baseProc;
                    if (labProc.CurrentStateDefID == LaboratoryProcedure.States.SampleAccept || labProc.CurrentStateDefID == LaboratoryProcedure.States.Procedure)
                    {
                        labProc.Techniciannote = labState.Aciklama;
                        labProc.ProcedureDate = Common.RecTime();

                        if (labState.Durum == 0) //Kabul edildi
                        {
                            labProc.CurrentStateDefID = LaboratoryProcedure.States.Procedure;
                        }
                        else if (labState.Durum == 1) //Red edildi
                        {
                            labProc.CurrentStateDefID = LaboratoryProcedure.States.SampleReject;
                            if (labState.RedNedeni != null)
                            {
                                if (labState.RedNedeni != Guid.Empty)
                                {
                                    LaboratoryRejectReasonDefinition rejectReason = null;
                                    rejectReason = (LaboratoryRejectReasonDefinition)context.GetObject(labState.RedNedeni, TTObjectDefManager.Instance.ObjectDefs[typeof(LaboratoryRejectReasonDefinition).Name], false);

                                    labProc.SampleRejectionReason = rejectReason;

                                }

                            }

                            if (labState.RedKullanici != null)
                            {
                                if (labState.RedKullanici != Guid.Empty)
                                {
                                    TTUser tt_User = TTUser.GetUser(labState.RedKullanici);
                                    ResUser userOfSampleRejection = null;
                                    userOfSampleRejection = (ResUser)context.GetObject(tt_User.UserObject.ObjectID, "RESUSER");

                                    labProc.UserOfSampleRejection = userOfSampleRejection;
                                }
                            }
                            //labProc.ReasonOfReject = labState.RedNedeni;

                            if (labProc.SampleRejectionReason != null && labProc.UserOfSampleRejection != null && labProc.EpisodeAction != null)
                            {
                                LaboratoryRequest labRequest = (LaboratoryRequest)context.GetObject(labProc.EpisodeAction.ObjectID, TTObjectDefManager.Instance.ObjectDefs[typeof(LaboratoryRequest).Name], false);

                                UserMessage message = new UserMessage(context);
                                message.BaseAction = (BaseAction)labProc.EpisodeAction;
                                message.SubAction = (SubActionProcedure)labProc;
                                message.Patient = labProc.Episode.Patient;
                                message.IsPanicMessage = true;
                                message.IsSystemMessage = false;
                                message.Sender = labProc.UserOfSampleRejection;
                                message.ToUser = labRequest.RequestDoctor;
                                //   message.Status = MessageStatusEnum.Sent;
                                message.MessageDate = TTObjectDefManager.ServerTime;
                                message.MessageFeedback = false;
                                message.Subject = "LABORATUVAR_NUMUNE_RED_BİLDİRİMİ";

                                string messageText = "";

                                if (labRequest.RequestDoctor != null)
                                {
                                    if (!String.IsNullOrEmpty(labRequest.RequestDoctor.Name))
                                    {
                                        messageText += "Sayın " + labRequest.RequestDoctor.Name + ", ";
                                    }
                                }

                                if (labProc.Episode.Patient.UniqueRefNo != null)
                                    messageText += "( " + labProc.Episode.Patient.UniqueRefNo + " ) ";

                                if (!String.IsNullOrEmpty(labProc.Episode.Patient.Name))
                                    messageText += labProc.Episode.Patient.Name.Trim() + " ";

                                if (!String.IsNullOrEmpty(labProc.Episode.Patient.Surname))
                                    messageText += labProc.Episode.Patient.Surname.Trim() + " ";

                                messageText += " isimli hasta için istemiş olduğunuz Laboratuvar İstek İşleminde yer alan ";

                                if (labProc.ProcedureObject != null)
                                {
                                    if (!String.IsNullOrEmpty(labProc.ProcedureObject.Code))
                                        messageText += "'" + labProc.ProcedureObject.Code.ToString() + "'  '";

                                    if (!String.IsNullOrEmpty(labProc.ProcedureObject.Name))
                                        messageText += labProc.ProcedureObject.Name.ToString() + "'  '";
                                }




                                messageText += "' tetkiğin Numune Red işlemi gerçekleştirilmiştir. ";

                                if (labProc.SampleRejectionReason != null)
                                {
                                    if (!String.IsNullOrEmpty(labProc.SampleRejectionReason.Description))
                                    {
                                        messageText += " | NUMUNE RED SEBEBİ : '" + labProc.SampleRejectionReason.Description.Trim();
                                    }
                                    else
                                    {
                                        if (!String.IsNullOrEmpty(labProc.SampleRejectionReason.Reason))
                                            messageText += " | NUMUNE RED SEBEBİ : '" + labProc.SampleRejectionReason.Reason.Trim();
                                    }
                                }

                                if (labProc.Episode.Patient != null)
                                {
                                    if (labProc.Episode.Patient.UniqueRefNo != null)
                                        messageText += "| | HASTA TCKİMLİKNU : " + labProc.Episode.Patient.UniqueRefNo;

                                    if (!String.IsNullOrEmpty(labProc.Episode.Patient.Name))
                                        messageText += " | HASTA ADI SOYADI : " + labProc.Episode.Patient.Name.Trim() + " ";
                                    if (!String.IsNullOrEmpty(labProc.Episode.Patient.Surname))
                                        messageText += labProc.Episode.Patient.Surname.Trim();
                                }

                                if (labProc.Episode.OpeningDate != null)
                                    messageText += " | VAKA AÇILIŞ TARİHİ : " + labProc.Episode.OpeningDate.ToString();

                                if (labRequest.ID != null)
                                {
                                    if (labRequest.ID.Value != null)
                                        messageText += " | İŞLEM NUMARASI : " + labRequest.ID.Value.ToString();
                                }

                                message.SetRTFBody(messageText.Trim());
                            }
                        }
                    }
                }
            }
            context.Save();

            CompleteLaboratoryRequest(labState.ActionID);

        }

        public override SubActionProcedure PrepareSubActionProcedureForRemoteMethod(bool withNewObjectID)
        {
            LaboratoryProcedure labProcedure = (LaboratoryProcedure)base.PrepareSubActionProcedureForRemoteMethod(withNewObjectID);
            if (withNewObjectID)
            {

                labProcedure.Equipment = null;
                labProcedure.FromResource = null;
                labProcedure.MasterResource = null;
                TTSequence.allowSetSequenceValue = true;
                labProcedure.ID.SetSequenceValue(0);

            }
            return labProcedure;
        }

        public bool SendUserMessageIfPanic(LaboratoryProcedure labProcedure, TTObjectContext context)
        {
            if (labProcedure.Warning != null && labProcedure.Warning == HighLowEnum.Panic)
            {
                UserMessage message = new UserMessage(context);
                message.IsSystemMessage = false;
                message.MessageDate = TTObjectDefManager.ServerTime;
                message.Subject = TTUtils.CultureService.GetText("M26375", "Laboratuvar Sonucu Panik Değer Bilgilendirmesi");
                //   message.Status = MessageStatusEnum.Sent;
                message.ToUser = RequestUser;
                message.Sender = (ResUser)Common.CurrentUser.UserObject;
                message.SetRTFBody(labProcedure.ProcedureObject.Name + " isimli testin sonucu " + labProcedure.Result + " çıkmıştır. \n"
                                   + "Bu testin normal referans aralığı " + labProcedure.Reference + " değerleri arasıdır.");
                return true;
            }
            return false;
        }

        public override string GetDVOBransKodu(AccountTransaction accTrx)
        {
            if (((LaboratoryTestDefinition)ProcedureObject).Branch != null)
                return ((LaboratoryTestDefinition)ProcedureObject).Branch.Code;

            return EpisodeAction.GetBranchCodeForMedula();
        }

        public override string GetDVODrTescilNo(string branchCode)
        {
            if (!string.IsNullOrWhiteSpace(ProcedureObject?.Doctor?.DiplomaRegisterNo))  // Hizmet için doktor tanımlanmışsa
                return ProcedureObject.Doctor.DiplomaRegisterNo;

            if (!string.IsNullOrWhiteSpace(ApproveUser?.DiplomaRegisterNo)) // Onaylayan kullanıcı
                return ApproveUser.DiplomaRegisterNo;

            // Dr Tescil No ve Branş eşleşme kontrolü geldiği için artık istek yapan doktorun gönderilmesi doğru olmayacağından kapatıldı
            //if (ProcedureObject is LaboratoryTestDefinition) 
            //    if (((LaboratoryTestDefinition)ProcedureObject).SendByRequestDoctor == true && !string.IsNullOrWhiteSpace(Laboratory?.RequestDoctor?.DiplomaRegisterNo))
            //        return Laboratory.RequestDoctor.DiplomaRegisterNo;

            //string doktorTescilNo = SystemParameter.GetParameterValue("LABORATUVARMEDULADOKTORTESCILNO", string.Empty);
            //if (!string.IsNullOrWhiteSpace(doktorTescilNo))
            //    return doktorTescilNo;

            return Common.GetDoctorRegisterNoByBranchCode(branchCode);
        }

        public override ResUser GetDVOIstemYapanDr()
        {
            if (Laboratory != null && Laboratory.RequestDoctor != null)
                return Laboratory.RequestDoctor;

            return base.GetDVOIstemYapanDr();
        }

        public override HizmetKayitIslemleri.tahlilSonucDVO[] GetDVOTahlilSonuclari()
        {
            string tahlilTipi = "0";
            List<HizmetKayitIslemleri.tahlilSonucDVO> tahlilSonucDVOList = new List<HizmetKayitIslemleri.tahlilSonucDVO>();

            // TahlilSonucDVO  : tedaviTürü Yatarak Tedavi olanlarda ve tedavi türü Ayaktan Tedavi olup EK10C veya moleküler genetik işlemi olanlarda sonuç ZORUNLU
            if (LaboratorySubProcedures != null && LaboratorySubProcedures.Count > 0)
            {
                List<Guid> subProcedureObjectList = new List<Guid>();
                foreach (LaboratorySubProcedure labSubProcedure in LaboratorySubProcedures)
                {
                    if (labSubProcedure.ProcedureObject != null)
                    {
                        if (subProcedureObjectList.Where(x => x == labSubProcedure.ProcedureObject.ObjectID).Count() > 0)
                            continue;

                        subProcedureObjectList.Add(labSubProcedure.ProcedureObject.ObjectID);
                        tahlilTipi = ((LaboratoryTestDefinition)labSubProcedure.ProcedureObject).TahlilTipi != null ? ((LaboratoryTestDefinition)labSubProcedure.ProcedureObject).TahlilTipi.tahlilTipKodu : "0";

                        if (!string.IsNullOrEmpty(labSubProcedure.Result)) // tetkik sonucu boş olmayanlar tahlilSonuclari na eklenir
                        {
                            HizmetKayitIslemleri.tahlilSonucDVO tahlilSonucDVO = new HizmetKayitIslemleri.tahlilSonucDVO();
                            tahlilSonucDVO.tahlilTipi = tahlilTipi;

                            if (labSubProcedure.Result.Length > 14)
                                tahlilSonucDVO.sonuc = labSubProcedure.Result.Substring(0, 14);
                            else
                                tahlilSonucDVO.sonuc = labSubProcedure.Result;

                            if (!string.IsNullOrEmpty(labSubProcedure.Unit))
                            {
                                if (labSubProcedure.Unit.Length > 14)
                                    tahlilSonucDVO.birim = labSubProcedure.Unit.Substring(0, 14);
                                else
                                    tahlilSonucDVO.birim = labSubProcedure.Unit;
                            }

                            tahlilSonucDVOList.Add(tahlilSonucDVO);
                        }
                        else
                        {
                            if (labSubProcedure.LongReport != null)
                            {
                                HizmetKayitIslemleri.tahlilSonucDVO tahlilSonucDVO = new HizmetKayitIslemleri.tahlilSonucDVO();
                                tahlilSonucDVO.tahlilTipi = tahlilTipi;

                                string rtfStringOfLongReport = Common.GetTextOfRTFString(labSubProcedure.LongReport.ToString());
                                if (!string.IsNullOrEmpty(rtfStringOfLongReport))
                                {
                                    if (rtfStringOfLongReport.Length > 14)
                                        tahlilSonucDVO.sonuc = rtfStringOfLongReport.Substring(0, 14);
                                    else
                                        tahlilSonucDVO.sonuc = rtfStringOfLongReport.Trim();
                                }

                                if (!string.IsNullOrEmpty(labSubProcedure.Unit))
                                {
                                    if (labSubProcedure.Unit.Length > 14)
                                        tahlilSonucDVO.birim = labSubProcedure.Unit.Substring(0, 14);
                                    else
                                        tahlilSonucDVO.birim = labSubProcedure.Unit;
                                }
                                tahlilSonucDVOList.Add(tahlilSonucDVO);
                            }
                        }
                    }
                }
                if (tahlilSonucDVOList.Count > 0) // Sonuç eklenmişse tahlilSonuclari na set edilir
                    return tahlilSonucDVOList.ToArray();
            }

            // tahlilSonuclari boş ise Ana tetkiğin sonucu (boş değilse) tahlilSonuclari na eklenir. Yatan hastalarda ez az bir sonuç bilgisi
            // istendiği için, alt tetkiklerden hiçbir sonuç listeye eklenmemişse, ana tetkiğin sonucu gönderilir.
            tahlilTipi = ((LaboratoryTestDefinition)ProcedureObject).TahlilTipi != null ? ((LaboratoryTestDefinition)ProcedureObject).TahlilTipi.tahlilTipKodu : "0";

            if (ProcedureObject != null && !string.IsNullOrEmpty(Result))
            {
                HizmetKayitIslemleri.tahlilSonucDVO tahlilSonucDVO = new HizmetKayitIslemleri.tahlilSonucDVO();
                tahlilSonucDVO.tahlilTipi = tahlilTipi;

                if (Result.Length > 14)
                    tahlilSonucDVO.sonuc = Result.Substring(0, 14);
                else
                    tahlilSonucDVO.sonuc = Result;

                if (!string.IsNullOrEmpty(Unit))
                {
                    if (Unit.Length > 14)
                        tahlilSonucDVO.birim = Unit.Substring(0, 14);
                    else
                        tahlilSonucDVO.birim = Unit;
                }

                tahlilSonucDVOList.Add(tahlilSonucDVO);
                return tahlilSonucDVOList.ToArray();
            }
            else if (LongReport != null)
            {
                HizmetKayitIslemleri.tahlilSonucDVO tahlilSonucDVO = new HizmetKayitIslemleri.tahlilSonucDVO();
                tahlilSonucDVO.tahlilTipi = tahlilTipi;

                string rtfStringOfLongReport = Common.GetTextOfRTFString(LongReport.ToString());
                if (!string.IsNullOrEmpty(rtfStringOfLongReport))
                {
                    if (rtfStringOfLongReport.Length > 14)
                        tahlilSonucDVO.sonuc = rtfStringOfLongReport.Substring(0, 14);
                    else
                        tahlilSonucDVO.sonuc = rtfStringOfLongReport.Trim();
                }

                if (!string.IsNullOrEmpty(Unit))
                {
                    if (Unit.Length > 14)
                        tahlilSonucDVO.birim = Unit.Substring(0, 14);
                    else
                        tahlilSonucDVO.birim = Unit;
                }

                tahlilSonucDVOList.Add(tahlilSonucDVO);
                return tahlilSonucDVOList.ToArray();
            }
            else if (IsExternal())
            {
                HizmetKayitIslemleri.tahlilSonucDVO tahlilSonucDVO = new HizmetKayitIslemleri.tahlilSonucDVO();
                tahlilSonucDVO.tahlilTipi = tahlilTipi;
                tahlilSonucDVO.sonuc = "D.SEVK:" + ProcedureObject.Code;
                tahlilSonucDVO.birim = ".";
                tahlilSonucDVOList.Add(tahlilSonucDVO);
                return tahlilSonucDVOList.ToArray();
            }
            else if (!string.IsNullOrEmpty(ResultDescription) && !string.IsNullOrEmpty(ResultDescription.Trim()))
            {
                HizmetKayitIslemleri.tahlilSonucDVO tahlilSonucDVO = new HizmetKayitIslemleri.tahlilSonucDVO();
                tahlilSonucDVO.tahlilTipi = tahlilTipi;

                if (ResultDescription.Length > 14)
                    tahlilSonucDVO.sonuc = ResultDescription.Substring(0, 14);
                else
                    tahlilSonucDVO.sonuc = ResultDescription;

                tahlilSonucDVO.birim = ".";
                tahlilSonucDVOList.Add(tahlilSonucDVO);
                return tahlilSonucDVOList.ToArray();
            }

            return null;
        }

        #endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(LaboratoryProcedure).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == LaboratoryProcedure.States.SampleAccept && toState == LaboratoryProcedure.States.Completed)
                PreTransition_SampleAccept2Completed();
            else if (fromState == LaboratoryProcedure.States.Procedure && toState == LaboratoryProcedure.States.Completed)
                PreTransition_Procedure2Completed();
            else if (fromState == LaboratoryProcedure.States.New && toState == LaboratoryProcedure.States.Completed)
                PreTransition_New2Completed();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(LaboratoryProcedure).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == LaboratoryProcedure.States.Procedure && toState == LaboratoryProcedure.States.Completed)
                PostTransition_Procedure2Completed();
            else if (fromState == LaboratoryProcedure.States.Approve && toState == LaboratoryProcedure.States.Completed)
                PostTransition_Approve2Completed();
            else if (fromState == LaboratoryProcedure.States.SampleTaking && toState == LaboratoryProcedure.States.Completed)
                PostTransition_SampleTaking2Completed();
            else if (fromState == LaboratoryProcedure.States.SampleAccept && toState == LaboratoryProcedure.States.Cancelled)
                PostTransition_SampleAccept2Cancelled();
            else if (fromState == LaboratoryProcedure.States.SampleTaking && toState == LaboratoryProcedure.States.Cancelled)
                PostTransition_SampleTaking2Cancelled();
            else if (fromState == LaboratoryProcedure.States.SampleLaboratoryAccept && toState == LaboratoryProcedure.States.Cancelled)
                PostTransition_SampleLaboratoryAccept2Cancelled();
            else if (fromState == LaboratoryProcedure.States.Approve && toState == LaboratoryProcedure.States.SampleReject)
                PostTransition_Approve2SampleReject();
            else if (fromState == LaboratoryProcedure.States.SampleLaboratoryAccept && toState == LaboratoryProcedure.States.SampleReject)
                PostTransition_SampleLaboratoryAccept2SampleReject();
            else if (fromState == LaboratoryProcedure.States.SampleLaboratoryAccept && toState == LaboratoryProcedure.States.Completed)
                PostTransition_SampleLaboratoryAccept2Completed();
            else if (fromState == LaboratoryProcedure.States.Procedure && toState == LaboratoryProcedure.States.SampleReject)
                PostTransition_Procedure2SampleReject();


        }

        public void CreateAndSendENabizMessageToPatient(LaboratoryProcedure laboratoryProcedure)
        {
            try
            {
                using (var tempObjectContext = new TTObjectContext(false))
                {
                    SendMessageToPatient message = new SendMessageToPatient(tempObjectContext);
                    message.SubEpisode = laboratoryProcedure.SubEpisode;
                    message.Patient = laboratoryProcedure.SubEpisode.Episode.Patient;
                    message.MessageDate = Common.RecTime();
                    message.MessageInfo = ((DateTime)laboratoryProcedure.RequestDate).ToString("dd.MM.yyyy") + " tarihinde istenen " + laboratoryProcedure.ProcedureObject.Name.ToString() + " tetkik Laboratuvar tarafından reddedilmiştir";
                    var mesajTuru = SKRSHastaMesajlari.GetHastaMesajlariByKodu(tempObjectContext, 2);
                    if (mesajTuru != null)
                        message.SKRSHastaMesajlari = mesajTuru[0];
                    tempObjectContext.Save();
                    new SendToENabiz(tempObjectContext, message.SubEpisode, message.ObjectID, message.ObjectDef.Name, "411", Common.RecTime());
                    tempObjectContext.Save();
                    SendToENabiz s = new SendToENabiz();
                    s.ENABIZSend411(message.ObjectID.ToString());
                }
            }
            catch (Exception Ex)
            {
                TTUtils.Logger.WriteException("ENabız: hastaya mesaj gönderilirken hata oluştu.", Ex);
            }


        }


        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(LaboratoryProcedure).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;
            if (fromState == LaboratoryProcedure.States.New && toState == LaboratoryProcedure.States.SampleAccept)
                UndoTransition_New2SampleAccept(transDef);
            else if (fromState == LaboratoryProcedure.States.SampleAccept && toState == LaboratoryProcedure.States.SampleTaking)
                UndoTransition_SampleAccept2SampleTaking(transDef);
            else if (fromState == LaboratoryProcedure.States.SampleLaboratoryAccept && toState == LaboratoryProcedure.States.Procedure)
                UndoTransition_SampleLaboratoryAccept2Procedure(transDef);
            else if (fromState == LaboratoryProcedure.States.Procedure && toState == LaboratoryProcedure.States.Approve)
                UndoTransition_Procedure2Approve(transDef);
            else if (fromState == LaboratoryProcedure.States.Procedure && toState == LaboratoryProcedure.States.Completed)
                UndoTransition_Procedure2Completed(transDef);
            else if (fromState == LaboratoryProcedure.States.Approve && toState == LaboratoryProcedure.States.Completed)
                UndoTransition_Approve2Completed(transDef);
        }

        protected void UndoTransition_New2SampleAccept(TTObjectStateTransitionDef transitionDef)
        {
            #region UndoTransition_New2SampleAccept
            NoBackStateBack();
            #endregion UndoTransition_New2SampleAccept
        }

        protected void UndoTransition_SampleAccept2SampleTaking(TTObjectStateTransitionDef transitionDef)
        {
            #region UndoTransition_SampleAccept2SampleTaking

            //XXXXXX tarafindan da tetkik sil yapiliyor.
            string resultMsg = LaboratoryProcedure.DeleteLaboratoryProcedureFromLIS(SpecimenId.ToString(), ObjectID.ToString(), String.Empty);
            if (resultMsg != "")
                throw new TTException("XXXXXX'dan tetkik silme işlemi yapılamadığı için işlem de geri alınamamıştır. Hata : " + resultMsg);
            else
            //ATLAS tarafinda da barkod, ornek no, tup bilgileri vs. degerleri bosaltilacak. Istek kabul asamasinda bu degerler sifirlanmis olmali.
            {
                BarcodeId = null;
                SpecimenId = null;
                TubeInformation = null;
            }

            #endregion UndoTransition_SampleAccept2SampleTaking
        }


        protected void UndoTransition_SampleLaboratoryAccept2Procedure(TTObjectStateTransitionDef transitionDef)
        {
            #region UndoTransition_SampleLaboratoryAccept2Procedure
            NoBackStateBack();
            #endregion UndoTransition_SampleLaboratoryAccept2Procedure
        }

        protected void UndoTransition_Procedure2Approve(TTObjectStateTransitionDef transitionDef)
        {
            #region UndoTransition_Procedure2Approve
            NoBackStateBack();
            #endregion UndoTransition_Procedure2Approve
        }

        protected void UndoTransition_Procedure2Completed(TTObjectStateTransitionDef transitionDef)
        {
            #region UndoTransition_Procedure2Completed
            NoBackStateBack();
            #endregion UndoTransition_Procedure2Completed
        }

        protected void UndoTransition_Approve2Completed(TTObjectStateTransitionDef transitionDef)
        {
            #region UndoTransition_Approve2Completed
            NoBackStateBack();
            #endregion UndoTransition_Approve2Completed
        }


        public static string DeleteLaboratoryProcedureFromLIS(string specimenID, string placerOrderNumber, string fillerOrderNumber)
        {
            //Bu method XXXXXX dan ılgılı ornek altındakı tetkıgın sılınmesı saglar.  
            string resultMsg = "";
            try
            {
                string result = XXXXXXIHEWS.WebMethods.OrnekTetkikSilSync(Sites.SiteLocalHost, specimenID, placerOrderNumber, fillerOrderNumber);
                //Mesaj donmuyorsa basarili kabul ediliyor.
                //Asagidaki mesaj;ar geldiginde silinemiyor.
                //LTW100 - Raporu Basılmış,
                //LTW101 - Onaylanmış,
                //LTW102 - Sonucu Dolu,
                //LTW103 - Cihazda
                //LTW104 - Reddedilmiş
                //LTW105 - Kabul Edilmiş

                if (result == "") //Islem basarili silme islemi gerceklesti.
                    resultMsg = result;
                else
                    resultMsg = "XXXXXX OrnekTetkikSil methodunda hata oluştu. Örnek No: " + specimenID.ToString() + " Hata Kodu: " + result.ToString();
            }
            catch (Exception ex)
            {
                resultMsg = "DeleteLaboratoryProcedureFromLIS methodunda hata oluştu. Örnek No: " + specimenID.ToString() + " Hata Kodu: " + ex.ToString();
            }

            return resultMsg;
        }





        //e-Nabiz GunSonu Gonderim paketlerinde verilen SUTCode ve Sonuc Tarihi araligina gore sonuc degeri resultValue parametresindeki degerin altinda olan tetkiklerin sayisini doner. 
        public static int GunSonu_GS31DegeriDusukIslemSayisi(List<string> SUTCodes, double resultValue, DateTime startDate, DateTime endDate)
        {
            int labProcedureCnt = 0;
            BindingList<LaboratoryProcedure.GunSonu_GS31DegeriDusukIslemler_Class> labResultList = LaboratoryProcedure.GunSonu_GS31DegeriDusukIslemler(SUTCodes, startDate, endDate);

            foreach (LaboratoryProcedure.GunSonu_GS31DegeriDusukIslemler_Class labResult in labResultList)
            {
                try
                {
                    if (labResult.Result != null)
                    {
                        double result = 0;
                        if (double.TryParse(labResult.Result.Replace(".", ","), out result))
                        {
                            if (result < resultValue)
                                labProcedureCnt++;
                        }
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }

            }

            return labProcedureCnt;
        }


        public static int GunSonu_GS67PSADegeriYuksekHastaSayisi(List<string> SUTCodes, List<string> ICDCodes, double resultValue, DateTime startDate, DateTime endDate)
        {
            Dictionary<string, int> patientList = new Dictionary<string, int>();
            BindingList<LaboratoryProcedure.GunSonu_GS67PSADegeriYuksekHastaSayisi_Class> labResultList = LaboratoryProcedure.GunSonu_GS67PSADegeriYuksekHastaSayisi(startDate, endDate, SUTCodes, ICDCodes);

            foreach (LaboratoryProcedure.GunSonu_GS67PSADegeriYuksekHastaSayisi_Class labResult in labResultList)
            {
                try
                {
                    if (labResult.Result != null)
                    {
                        double result;
                        if (double.TryParse(labResult.Result.Replace(".", ","), out result))
                        {
                            if (result > resultValue)
                            {
                                int pCount;
                                string pObjectID = labResult.Patient.ToString();
                                if (patientList.TryGetValue(pObjectID, out pCount) == false)
                                {
                                    patientList.Add(pObjectID, pCount);
                                }
                            }
                        }
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }

            }

            return patientList.Count;
        }


        public static void CheckSampleRequestWorkListStartTime(int checkCount)
        {
            //Laboratuvar Numune Alma Is listesinde o gun tanimli saatte henuz Numune Alma asamasina alinmis test islemi yoksa, ilgili kullanicilara SMS gonderirir.
            string lastTime = "";
            if (checkCount == 1)
                lastTime = TTObjectClasses.SystemParameter.GetParameterValue("LABORATORYSAMPLETAKINGFIRSTCHECKTIME", "08:15");
            else if (checkCount == 2)
                lastTime = TTObjectClasses.SystemParameter.GetParameterValue("LABORATORYSAMPLETAKINGSECONDCHECKTIME", "08:30");

            DateTime startDate = Convert.ToDateTime(DateTime.Now.ToString("dd.MM.yyyy") + " " + "00:00:00");
            DateTime endDate = Convert.ToDateTime(DateTime.Now.ToString("dd.MM.yyyy") + " " + lastTime + ":00");

            //Testlerin o gün istenmiş olması kontrolünden vazgeçildi, TFS 58122.
            //Varsa bunlardan Numune Alma, Numune Kabul ve Laboratuvarda  asamasina gecmis testlerin sayisi kontrol ediliyor. Bu durumda hiç test bulunamıyorsa mesaj atiliyor.

            BindingList<LaboratoryProcedure.GetCountLabProcedureBySampleTakingStateByDate_Class> sampleTakingLabTests = LaboratoryProcedure.GetCountLabProcedureBySampleTakingStateByDate(startDate, endDate);
            if (sampleTakingLabTests.Count > 0)
            {
                if (Convert.ToInt16(sampleTakingLabTests[0].Sampletakingtestcount) == 0)
                {
                    //SendUser Message
                    UserMessage userMessage = new UserMessage();
                    string messageText = "Bugün saat " + lastTime + " itibariyle Kan Alma Birimi tetkik kabul işlemleri başlamamıştır. Bilgilerinize.";
                    if (!string.IsNullOrEmpty(messageText))
                    {
                        TTObjectContext context = new TTObjectContext(true);
                        ResUser smsPerson;
                        string sysParameterName = "";
                        if (checkCount == 1)
                            sysParameterName = "LABORATORYSAMPLETAKINGFIRSTCHECKUSER";
                        else if (checkCount == 2)
                            sysParameterName = "LABORATORYSAMPLETAKINGSECONDCHECKUSER";


                        string[] smsPersonList = TTObjectClasses.SystemParameter.GetParameterValue(sysParameterName, "").Split(',');
                        List<Guid> userObjectIDList = new List<Guid>();
                        List<ResUser> smsUserList = new List<ResUser>();

                        if (smsPersonList != null && smsPersonList.Length > 0)
                        {
                            foreach (string userObjectID in smsPersonList.Where(x => string.IsNullOrEmpty(x) == false))
                            {
                                userObjectIDList.Add(new Guid(userObjectID));
                            }

                            string filter = Common.CreateFilterExpressionOfGuidList("", "OBJECTID", userObjectIDList);

                            smsUserList = context.QueryObjects<ResUser>(filter).ToList();

                            //if (smsPersonList != null)
                            //{
                            //for (int i = 0; i < smsPersonList.Length; i++)
                            //{
                            //    if (smsPersonList[i] != null && smsPersonList[i] != "")
                            //    {
                            //smsPerson = (ResUser)context.GetObject(new Guid(smsPersonList[i]), "RESUSER");
                            userMessage.SendSMSPerson(smsUserList, messageText, SMSTypeEnum.LaboratoryTakingSampleDelaySMS);
                        }
                        //}
                        //}
                        context.Dispose();
                    }
                }
            }
        }



        //
        //Hastanın ilgili subepisode unda albümin tetkiki (900.210 ile başlayan tetkikler) var mı kontrolü yapılıyor.
        //0, 1,  2 değerlerini döndürecek.
        //Tetkik hiç instenmemişdse ya da istenmiş ama sonuçlanmamışsa Return 0
        //Tetkik istenmiş ise ve sonuçlanmışsa bu kez de sistem çıkan sonucu kontrol ediliyor Sonuç 2,5 üzerinde çıktı ise Return 1 
        //Eğer sonuç 2,5 ve altında ise Return 2  
        //HUMANALBUMINCHECKRESULTDATE kaç günlük alınacak parametresi...
        public static int CheckHumanAlbuminTest(string subEpisodeId, string sutCode)
        {
            int sysParamDateValue = Int32.Parse(TTObjectClasses.SystemParameter.GetParameterValue("HUMANALBUMINCHECKRESULTDATE", "3"));
            BindingList<LaboratoryProcedure.Get_HumanAlbuminTestAndResultBySubepisode_Class> humanAlbuminResultList = LaboratoryProcedure.Get_HumanAlbuminTestAndResultBySubepisode(subEpisodeId, sutCode, sysParamDateValue);
            if (humanAlbuminResultList != null)
            {
                if (humanAlbuminResultList.Count == 0)
                    return 0;
                else
                {
                    string sysParamValue = TTObjectClasses.SystemParameter.GetParameterValue("HUMANALBUMINCHECKRESULTVALUE", "2.5").Replace(".", ",");
                    double resultValue = Convert.ToDouble(sysParamValue);
                    foreach (LaboratoryProcedure.Get_HumanAlbuminTestAndResultBySubepisode_Class labResult in humanAlbuminResultList)
                    {
                        if (labResult.CurrentStateDefID.ToString() == LaboratoryProcedure.States.Completed.ToString() && labResult.Result != null)
                        {
                            string t = labResult.Result.Replace(".", ",");
                            double result = Convert.ToDouble(t);
                            if (result > resultValue)
                                return 1;
                            else
                                return 2;
                        }
                    }
                    //İstenmiş ama henüz sonuçlanmamışsa da Return 0
                    return 0;
                }
            }
            else
                return 0;
        }

        public string GetBranchCodeForLaboratoryProcedure()
        {
            if (this.EpisodeAction != null)
            {
                if (this.EpisodeAction.FromResource != null)
                {
                    foreach (ResourceSpecialityGrid resSpeciality in FromResource.ResourceSpecialities)
                    {
                        if (resSpeciality.Speciality != null)
                            return resSpeciality.Speciality.Code;
                    }
                }

                if (this.EpisodeAction.SubEpisode != null)
                {
                    if (SubEpisode.Speciality != null)
                        return SubEpisode.Speciality.Code;
                    else if (SubEpisode.ResSection != null && SubEpisode.ResSection.ResourceSpecialities != null && SubEpisode.ResSection.ResourceSpecialities.Count > 0)
                    {
                        if (SubEpisode.ResSection.ResourceSpecialities[0].Speciality != null)
                            return SubEpisode.ResSection.ResourceSpecialities[0].Speciality.Code;
                    }

                }
            }

            return null;
        }
    }
}