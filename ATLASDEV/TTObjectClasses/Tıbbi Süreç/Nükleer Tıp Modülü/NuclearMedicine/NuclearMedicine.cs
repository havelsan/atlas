
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
    /// Nükleer Tıp
    /// </summary>
    public partial class NuclearMedicine : EpisodeActionWithDiagnosis, IWorkListNuclear, IAppointmentDef, IWorkListEpisodeAction
    {
        public partial class NuclearMedicinePatientInfoNQL_Class : TTReportNqlObject
        {
        }

        public partial class NuclearMedicineReportNQL_Class : TTReportNqlObject
        {
        }

        public partial class GetByNuclearMedicineWorklistDateReport_Class : TTReportNqlObject
        {
            #region GetByNuclearMedicineWorklistDateReport_Methods

            public string RefNo
            {
                get
                {
                    if (Foreign == true)
                        return "(*) " + Convert.ToString(UniqueRefNo);
                    else
                        return Convert.ToString(UniqueRefNo);
                }
            }

            #endregion GetByNuclearMedicineWorklistDateReport_Methods

        }

        public partial class GetByWLFilterExpressionReport_Class : TTReportNqlObject
        {
            #region GetByWLFilterExpressionReport_Methods

            public string RefNo
            {
                get
                {
                    if (Foreign == true)
                        return "(*) " + Convert.ToString(UniqueRefNo);
                    else
                        return Convert.ToString(UniqueRefNo);
                }
            }

            #endregion GetByWLFilterExpressionReport_Methods

        }

        

        protected override void PostInsert()
        {
            #region PostInsert

            base.PostInsert();
            PatientAge = Episode.Patient.Age;

            #endregion PostInsert
        }

        protected override void PostUpdate()
        {
            #region PostUpdate
            base.PostUpdate();

            if (Report != null)
            {
                if (Common.CUCase(Common.GetTextOfRTFString(Report.ToString()), false, false).Length > 4000)
                {
                    ReportTxt = Common.CUCase(Common.GetTextOfRTFString(Report.ToString()), false, false).Substring(0, 4000);
                }
                else
                {
                    ReportTxt = Common.CUCase(Common.GetTextOfRTFString(Report.ToString()), false, false);
                }
            }

            #endregion PostUpdate
        }

        protected void PostTransition_Approve2Reported()
        {
            // From State : Approve   To State : Reported
            #region PostTransition_Approve2Reported

            ReportDate = Common.RecTime();
            //this.RunReturnNuclearMedicineFromOtherHospital();
            SetMySubActionProceduresPerformedDate();

            CheckDirectPurchaseGridToComplete();

            #endregion PostTransition_Approve2Reported
        }

        protected void PostTransition_AppointmentInfo2Cancelled()
        {
            // From State : AppointmentInfo   To State : Cancelled
            #region PostTransition_AppointmentInfo2Cancelled

            Cancel();

            #endregion PostTransition_AppointmentInfo2Cancelled
        }

        protected void PostTransition_AppointmentInfo2AdmissionAppointment()
        {
            // From State : AppointmentInfo   To State : AdmissionAppointment
            #region PostTransition_AppointmentInfo2AdmissionAppointment

            //foreach (NuclearMedicineTest test in this.NuclearMedicineTests)
            //{
            //    test.CancelMyAccountTransactions();
            //}

            #endregion PostTransition_AppointmentInfo2AdmissionAppointment
        }

        protected void UndoTransition_AppointmentInfo2AdmissionAppointment(TTObjectStateTransitionDef transitionDef)
        {
            // From State : AppointmentInfo   To State : AdmissionAppointment
            #region UndoTransition_AppointmentInfo2AdmissionAppointment

            NoBackStateBack();
            #endregion UndoTransition_AppointmentInfo2AdmissionAppointment
        }

        protected void PostTransition_Preparation2AdmissionAppointment()
        {
            // From State : Preparation   To State : AdmissionAppointment
            #region PostTransition_Preparation2AdmissionAppointment

            //foreach (NuclearMedicineTest test in this.NuclearMedicineTests)
            //{
            //    test.CancelMyAccountTransactions();
            //}

            #endregion PostTransition_Preparation2AdmissionAppointment
        }

        protected void UndoTransition_Preparation2AdmissionAppointment(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Preparation   To State : AdmissionAppointment
            #region UndoTransition_Preparation2AdmissionAppointment

            NoBackStateBack();
            #endregion UndoTransition_Preparation2AdmissionAppointment
        }

        protected void PostTransition_RequestAcception2Cancelled()
        {
            // From State : RequestAcception   To State : Cancelled
            #region PostTransition_RequestAcception2Cancelled

            Cancel();

            #endregion PostTransition_RequestAcception2Cancelled
        }

        protected void PreTransition_Request2RequestAcception()
        {
            // From State : Request   To State : RequestAcception
            #region PreTransition_Request2RequestAcception

            if (!TestSequenceNo.Value.HasValue)
                TestSequenceNo.GetNextValue();

            #endregion PreTransition_Request2RequestAcception
        }

        protected void PreTransition_Doctor2Reported()
        {
            // From State : Doctor   To State : Reported
            #region PreTransition_Doctor2Reported

            if (OlapDate == null)
                OlapDate = DateTime.Now;
            #endregion PreTransition_Doctor2Reported
        }

        protected void PostTransition_Doctor2Reported()
        {
            // From State : Doctor   To State : Reported
            #region PostTransition_Doctor2Reported

            ReportDate = Common.RecTime();
            //this.RunReturnNuclearMedicineFromOtherHospital();
            SetMySubActionProceduresPerformedDate();

            CheckDirectPurchaseGridToComplete();

            #endregion PostTransition_Doctor2Reported
        }

        #region Methods
        public NuclearMedicine(TTObjectContext objectContext, EpisodeAction episodeAction)
            : this(objectContext)
        {
            ActionDate = Common.RecTime();
            FromResource = episodeAction.MasterResource;
            CurrentStateDefID = NuclearMedicine.States.Request;
            ProcedureSpeciality = episodeAction.ProcedureSpeciality;
            MasterAction = episodeAction;
            Episode = episodeAction.Episode;
        }

        public NuclearMedicine(TTObjectContext objectContext, SubactionProcedureFlowable subactionProcedureFlowable)
            : this(objectContext)
        {
            ActionDate = Common.RecTime();
            FromResource = subactionProcedureFlowable.MasterResource;
            CurrentStateDefID = NuclearMedicine.States.Request;
            ProcedureSpeciality = subactionProcedureFlowable.ProcedureSpeciality;
            MasterAction = subactionProcedureFlowable.EpisodeAction;
            Episode = subactionProcedureFlowable.Episode;
        }

        public override ActionTypeEnum ActionType
        {
            get
            {
                return ActionTypeEnum.NuclearMedicine;
            }
        }

        public List<AppointmentCarrier> AppointmentCarrierList
        {
            get
            {
                List<AppointmentCarrier> _appointmentList = new List<AppointmentCarrier>();
                TTObjectContext context = new TTObjectContext(false);
                AppointmentDefinition appDef = null;
                IList appDefList = AppointmentDefinition.GetAppointmentDefinitionByName(context, AppointmentDefinitionEnum.NuclearMedicine);
                if (appDefList.Count > 0)
                {
                    appDef = (AppointmentDefinition)appDefList[0];
                    foreach (AppointmentCarrier appCarrier in appDef.AppointmentCarriers)
                    {
                        _appointmentList.Add(appCarrier);
                    }
                }

                if (_appointmentList.Count == 0)
                {
                    AppointmentCarrier carrier = new AppointmentCarrier(context);
                    carrier.MasterResource = "RESNUCLEARMEDICINEDEPARTMENT";
                    carrier.SubResource = "RESNUCLEARMEDICINEEQUIPMENT";
                    carrier.RelationParentName = "OBSERVATIONUNIT";
                    _appointmentList.Add(carrier);
                }
                ClearAppointmentCarrierDynamicFields(_appointmentList);
                foreach (AppointmentCarrier appointmentCarrier in _appointmentList)
                {
                    NuclearMedicineTestDefinition nmt = (NuclearMedicineTestDefinition)NuclearMedicineTests[0].ProcedureObject;
                    //appointmentCarrier.AppointmentCount=Convert.ToInt32(this.Amount);
                    if (nmt.NuclearMedicineDepartment != null)
                    {
                        appointmentCarrier.MasterResourceFilter = " OBJECTID = '" + nmt.NuclearMedicineDepartment.ObjectID.ToString() + "'";
                    }
                    else
                    {
                        appointmentCarrier.MasterResourceFilter = "";
                    }
                    break;
                }
                return _appointmentList;
            }
        }

        #region IAppointmentDef Members
        public List<AppointmentCarrier> GetAppointmentCarrierList()
        {
            return AppointmentCarrierList;
        }
        #endregion

        

        /* public void ShowViewer()
         {
             string accessionNoStr = this.NuclearMedicineTests[0].AccessionNo.ToString();
             string patientIdStr = this.Episode.Patient.ID.ToString();
             TTFormClasses.CommonForm.ShowPacsViewer(patientIdStr, accessionNoStr);
         }
         */
        public string EncodeTo64(string toEncode)
        {
            byte[] toEncodeAsBytes = System.Text.Encoding.GetEncoding("iso-8859-9").GetBytes(toEncode);
            string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }

        
        /*
        public void RunReturnNuclearMedicineFromOtherHospital()
        {
            if(this.SourceObjectID != null && this.Episode.CreaterSite != null)
            {
                Guid siteIDGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", Guid.Empty.ToString()));
                if(this.Episode.CreaterSite.ObjectID != siteIDGuid)
                {
                    Guid savePoint = this.ObjectContext.BeginSavePoint();
                    //String messageString="";
                    try
                    {
                        List<DiagnosisGrid> diagnosisList = new List<DiagnosisGrid>();
                        foreach (DiagnosisGrid dg in this.Diagnosis)// Geriye gönderilirken yalnız Consultasyonda konulan tanılar geriye gönderiliyor.
                        {
                            if(dg.ResponsibleUser!=null)
                                diagnosisList.Add(dg.PrepareDiagnosisGridForRemoteMethod(true));
                        }
                        
                        
                        NuclearMedicine.RemoteMethods.ReturnNuclearMedicineToSourceHospital(this.Episode.CreaterSite.ObjectID,(NuclearMedicine)this.PrepareEpisodeActionForRemoteMethod(true), this.NuclearMedicineTests[0],diagnosisList);
                        //ConsultationFromOtherHospital consultationFromOtherHospital = (ConsultationFromOtherHospital)objectContext.GetObject(this.ObjectID,"ConsultationFromOtherHospital");
                        //consultationFromOtherHospital.MessageID = message.MessageID.ToString();
                        //messageString = message.MessageID.ToString();
                    }
                    catch(Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        this.ObjectContext.RollbackSavePoint(savePoint);
                        //this.MessageID = messageString;
                        //this.ObjectContext.Save();
                    }
                }
            }
        }
        */

        public override EpisodeAction PrepareEpisodeActionForRemoteMethod(bool withNewObjectID)
        {

            NuclearMedicine nuclearMedicine = (NuclearMedicine)base.PrepareEpisodeActionForRemoteMethod(withNewObjectID);

            if (withNewObjectID)
            {

                nuclearMedicine.RequestDoctor = null;
            }
            return nuclearMedicine;

        }

        public override void Cancel()
        {
            base.Cancel();
            MakingDirectPurchaseMaterialsUnUsed();
        }

        public void MakingDirectPurchaseMaterialsUnUsed()
        {
            foreach (SurgeryDirectPurchaseGrid sdg in NuclearMedicine_SurgeryDirectPurchaseGrids)
            {
                if (sdg.DPADetailFirmPriceOffer != null && sdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail != null)
                    sdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.HasUsed = false;
            }

        }

        protected override void BeforeSetSubEpisode(SubEpisode subEpisode)
        {
           
        }

        override public Guid ProcedureRequestStartedStateDefID()
        {
            return (Guid)NuclearMedicine.States.RequestAcception;
        }

        override public void DoMyActionControlsForProcedureRequest()
        {
            if (String.IsNullOrEmpty(PreDiagnosis))
            {
                //TODO: Nukleer tetkik isteminde istem yapilirken zorunlu bilgi olarak kullanicinin girmesi  saglanacak popup ile.
                //throw new Exception(TTUtils.CultureService.GetText("M26302", "Kısa Anamnez ve Klinik Bulgular alanı boş geçilemez!"));
            }

        }

        override public void SetMyActionMandatoryProperties()
        {
            RequestDoctor = Common.CurrentResource;
            IsEmergency = false;
        }

        #endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(NuclearMedicine).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == NuclearMedicine.States.Request && toState == NuclearMedicine.States.RequestAcception)
                PreTransition_Request2RequestAcception();
            else if (fromState == NuclearMedicine.States.Doctor && toState == NuclearMedicine.States.Reported)
                PreTransition_Doctor2Reported();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(NuclearMedicine).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == NuclearMedicine.States.Approve && toState == NuclearMedicine.States.Reported)
                PostTransition_Approve2Reported();
            else if (fromState == NuclearMedicine.States.AppointmentInfo && toState == NuclearMedicine.States.Cancelled)
                PostTransition_AppointmentInfo2Cancelled();
            else if (fromState == NuclearMedicine.States.AppointmentInfo && toState == NuclearMedicine.States.AdmissionAppointment)
                PostTransition_AppointmentInfo2AdmissionAppointment();
            else if (fromState == NuclearMedicine.States.Preparation && toState == NuclearMedicine.States.AdmissionAppointment)
                PostTransition_Preparation2AdmissionAppointment();
            else if (fromState == NuclearMedicine.States.RequestAcception && toState == NuclearMedicine.States.Cancelled)
                PostTransition_RequestAcception2Cancelled();
            else if (fromState == NuclearMedicine.States.Doctor && toState == NuclearMedicine.States.Reported)
                PostTransition_Doctor2Reported();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(NuclearMedicine).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == NuclearMedicine.States.AppointmentInfo && toState == NuclearMedicine.States.AdmissionAppointment)
                UndoTransition_AppointmentInfo2AdmissionAppointment(transDef);
            else if (fromState == NuclearMedicine.States.Preparation && toState == NuclearMedicine.States.AdmissionAppointment)
                UndoTransition_Preparation2AdmissionAppointment(transDef);
        }

    }
}