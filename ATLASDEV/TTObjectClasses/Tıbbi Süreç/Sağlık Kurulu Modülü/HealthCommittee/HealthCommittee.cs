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
    /// Sağlık Kurulu İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
    public partial class HealthCommittee : BaseHealthCommittee, IWorkListHealthCommittee, IAppointmentDef, IOAHealthCommittee, IPatientWorkList, ICreateSubEpisode
    {
        public partial class GetCurrentHealthCommittee_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetHealthCommitteeByEpisode_Class : TTReportNqlObject
        {
        }

        public partial class GetHealthCommittees_Class : TTReportNqlObject
        {
        }

        public partial class GetXXXXXXApprovalHCsByDate_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetCancelledHealthCommittees_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetHealthCommittesByDate_Class : TTReportNqlObject
        {
        }

        public partial class GetHCsByDateAndUniqueRefNo_Class : TTReportNqlObject
        {
        }

        public partial class GetMSBApprovalHCsByDate_Class : TTReportNqlObject
        {
        }

        public partial class GetHealthCommitteesByDate_Class : TTReportNqlObject
        {
        }

        public partial class GetHcBySlice_Class : TTReportNqlObject
        {
        }

        public partial class GetNotCollectedInvoicableHealthCommitteeRQ_Class : TTReportNqlObject
        {
        }

        public partial class GetHealthCommitteesByType_Class : TTReportNqlObject
        {
        }

        public partial class GetHCsForPeriodicExaminationResultReport_Class : TTReportNqlObject
        {
        }

        public partial class GetHCsForAdditionalReport_Class : TTReportNqlObject
        {
        }

        public partial class GetSuccessfulHCsByDateTypePatientGroup_Class : TTReportNqlObject
        {
        }

        public partial class GetUnsuccessfulHCsByDateTypePatientGroup_Class : TTReportNqlObject
        {
        }

        public class InpatientHC_Class
        {
            public ReasonForExaminationDefinition reasonForExaminationDefinition { get; set; }
            public List<PatientAdmissionResourcesToBeReferred> resourcesToBeReferredList { get; set; }
            public string _hcReasonID { get; set; }
            public WhoPaysEnum HCModeOfPayment { get; set; }
            public Guid episodeActionObjectID { get; set; }
            public EDisabledReport eDisabledReport { get; set; }
            public EStatusNotRepCommitteeObj eStatusNotfReportObj { get; set; }

        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        protected override void PostUpdate()
        {
#region PostUpdate
            base.PostUpdate();
            // İptal Edildi veya Reddedildi adımına geçilirse Sağlık Kurulu Rapor hizmeti iptal edilir
            if (TransDef != null && TransDef.ToStateDefID != null)
            {
                if (TransDef.ToStateDefID == HealthCommittee.States.Cancelled)
                {
                    foreach (HealthCommitteeProcedure HCProc in HealthCommitteeProcedures)
                    {
                        if (HCProc.CurrentStateDefID != SubActionProcedure.States.Cancelled)
                        {
                            HCProc.Cancel();
                            HCProc.CurrentStateDefID = SubActionProcedure.States.Cancelled; // SubactionProcedure.Cancel() da state değişmediği için eklendi
                        }
                    }
                }
            }

            // Tamamlanmamış Sağlık Kurulu Bilgisini Merkezde güncelleme
            // HealthCommittee nin update ten önceki orjinal hali alınır
            /*
            TTObjectContext objContext = new TTObjectContext(true);
            HealthCommittee originalHC = (HealthCommittee)objContext.GetObject(this.ObjectID, TTObjectDefManager.Instance.ObjectDefs[typeof(HealthCommittee).Name], false);
            if (originalHC != null)
            {
                // State değişmişse
                if(originalHC.CurrentStateDefID != this.CurrentStateDefID)
                {
                    // "Raporlandı" adımından "Rapor" adımına geri dönülürken merkezdeki HCUncompleted Tamamlanmadı adımına alınır
                    if(originalHC.CurrentStateDefID == HealthCommittee.States.Reported && this.CurrentStateDefID == HealthCommittee.States.Report)
                        this.RunUpdateHCUncompleted(HCUncompleted.States.Uncompleted);
                    
                    // "İptal", "Rapor İptali" veya "Reddedildi" adımlarına geçerken merkezdeki HCUncompleted İptal adımına alınır.
                    if((originalHC.CurrentStateDefID != HealthCommittee.States.Cancelled && originalHC.CurrentStateDefID != HealthCommittee.States.ReportCancelled && originalHC.CurrentStateDefID != HealthCommittee.States.Rejected) &&
                       (this.CurrentStateDefID == HealthCommittee.States.Cancelled || this.CurrentStateDefID == HealthCommittee.States.ReportCancelled || this.CurrentStateDefID == HealthCommittee.States.Rejected))
                        this.RunUpdateHCUncompleted(HCUncompleted.States.Cancelled);
                    
                    // "İptal", "Rapor İptali" veya "Reddedildi" adımlarından geri dönülürken
                    if(originalHC.CurrentStateDefID == HealthCommittee.States.Cancelled || originalHC.CurrentStateDefID == HealthCommittee.States.ReportCancelled || originalHC.CurrentStateDefID == HealthCommittee.States.Rejected)
                    {
                        // "Raporlandı", "Makam Onayı" veya "Tamamlandı" adımlarına geri dönülüyorsa merkezdeki HCUncompleted Tamamlandı adımına
                        // alınır. Başka bir adıma geri dönülüyorsa (İptal, Rapor İptali ve Reddedildi haricinde) merkezdeki HCUncompleted Tamamlanmadı adımına alınır.
                        if(this.CurrentStateDefID == HealthCommittee.States.Reported || this.CurrentStateDefID == HealthCommittee.States.ApproveofChair || this.CurrentStateDefID == HealthCommittee.States.Completed)
                            this.RunUpdateHCUncompleted(HCUncompleted.States.Completed);
                        else if(this.CurrentStateDefID != HealthCommittee.States.Cancelled && this.CurrentStateDefID != HealthCommittee.States.ReportCancelled && this.CurrentStateDefID != HealthCommittee.States.Rejected)
                            this.RunUpdateHCUncompleted(HCUncompleted.States.Uncompleted);
                    }
                }
            }
            */
            SetCommitteeAcceptanceStatus(); // Heyet Kabul Durumu güncellenir
#endregion PostUpdate
        }
        

        protected void PostTransition_New2Cancelled()
        {
            // From State : New   To State : Cancelled
#region PostTransition_New2Cancelled
            Cancel();
#endregion PostTransition_New2Cancelled
        }

        protected void PreTransition_New2CommitteeAcceptance()
        {
        // From State : New   To State : CommitteeAcceptance
#region PreTransition_New2CommitteeAcceptance
        //CreateHCReportProcedure();           
#endregion PreTransition_New2CommitteeAcceptance
        }

        protected void PostTransition_New2CommitteeAcceptance()
        {
        // From State : New   To State : CommitteeAcceptance
#region PostTransition_New2CommitteeAcceptance
        // Sağlık Kurulu paket hizmeti SKM Fişi İstek adımına geçilirken oluşturulmadıysa burada oluşturulur ve ücretlendirilir
        //CreateHCPackageProcedure();
        // this.CheckHospitalsUnitsGridForFork();
#endregion PostTransition_New2CommitteeAcceptance
        }

        protected void UndoTransition_New2CommitteeAcceptance(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : CommitteeAcceptance
#region UndoTransition_New2CommitteeAcceptance
            CheckUnCompletedExamination();
            bool bFound = false;
            foreach (EpisodeAction pAction in LinkedActions)
            {
                if (pAction is HealthCommitteeExamination)
                {
                    bFound = true;
                    break;
                }
            }

            if (bFound)
            {
                //throw new Exception("Devam eden (" + this.LinkedActions.Count.ToString() + ") Sağlık Kurulu Muayene işlemi var.");
                throw new TTUtils.TTException(SystemMessage.GetMessageV3(503, new string[]{LinkedActions.Count.ToString()}));
            }
#endregion UndoTransition_New2CommitteeAcceptance
        }

        protected void PreTransition_CommitteeAcceptance2Report()
        {
        // From State : New   To State : CommitteeAcceptance
#region PreTransition_CommitteeAcceptance2Report
        //CreateHCReportProcedure();
#endregion PreTransition_CommitteeAcceptance2Report
        }

        protected void PostTransition_CommitteeAcceptance2Report()
        {
        // From State : New   To State : CommitteeAcceptance
#region PostTransition_CommitteeAcceptance2Report
        // Sağlık Kurulu paket hizmeti SKM Fişi İstek adımına geçilirken oluşturulmadıysa burada oluşturulur ve ücretlendirilir
        //CreateHCPackageProcedure();
        //  this.CheckHospitalsUnitsGridForFork();
#endregion PostTransition_CommitteeAcceptance2Report
        }

        protected void UndoTransition_CommitteeAcceptance2Report(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : CommitteeAcceptance
#region UndoTransition_CommitteeAcceptance2Report
            CheckUnCompletedExamination();
            bool bFound = false;
            foreach (EpisodeAction pAction in LinkedActions)
            {
                if (pAction is HealthCommitteeExamination)
                {
                    bFound = true;
                    break;
                }
            }

            if (bFound)
            {
                //throw new Exception("Devam eden (" + this.LinkedActions.Count.ToString() + ") Sağlık Kurulu Muayene işlemi var.");
                throw new TTUtils.TTException(SystemMessage.GetMessageV3(503, new string[]{LinkedActions.Count.ToString()}));
            }
#endregion UndoTransition_CommitteeAcceptance2Report
        }

        protected void PreTransition_CommitteeAcceptance2Appointment()
        {
            // From State : CommitteeAcceptance   To State : Appointment
#region PreTransition_CommitteeAcceptance2Appointment
            //this.throwExceptionForUnfinishedHCExaminations();//for it's new version was designed, it's commented out...YY
            string sDeps = GetUnCompletedExaminations();
            if (!string.IsNullOrEmpty(sDeps))
            {
                //throw new TTException("Hastanın bazı birimlerde tamamlanmamış Sağlık Kurulu Muayeneleri bulunmaktadır. İşlemler tamamlanmadan süreci ilerletemezsiniz. Muayene işlemi tamamlanmamış birimler: " + sDeps);
                throw new TTUtils.TTException(SystemMessage.GetMessageV3(502, new string[]{sDeps}));
            }
#endregion PreTransition_CommitteeAcceptance2Appointment
        }

        protected void PostTransition_CommitteeAcceptance2Appointment()
        {
        // From State : CommitteeAcceptance   To State : Appointment
#region PostTransition_CommitteeAcceptance2Appointment
        /*
            IList<MemberOfHealthCommitteeDefinition> currentDefs = (IList<MemberOfHealthCommitteeDefinition>)MemberOfHealthCommitteeDefinition.GetTodaysMemberDefinition(this.ObjectContext, DateTime.Now.Date);
            if(currentDefs.Count == 0)
                throw new TTUtils.TTException(SystemMessage.GetMessage(483, new string[] { DateTime.Today.Date.ToShortDateString() }));
            else
                this.MemberOfHealthCommittee = currentDefs[0];
             */
#endregion PostTransition_CommitteeAcceptance2Appointment
        }

        protected void PostTransition_CommitteeAcceptance2Cancelled()
        {
            // From State : CommitteeAcceptance   To State : Cancelled
#region PostTransition_CommitteeAcceptance2Cancelled
            Cancel();
        //CancelLinkedEpisodeActions();
#endregion PostTransition_CommitteeAcceptance2Cancelled
        }

        protected void PostTransition_Report2Completed()
        {
            // From State : CommitteeAcceptance   To State : Reported
#region PostTransition_Report2Completed
            OlapDate = DateTime.Now;
            // Karar ve süre bilgilerinin boş geçilememe kontrolü
            if (HealthCommitteeDecision == null)
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26792", "Sağlık Kurulu Kararı boş geçilemez."));
            HealthCommitteeTypeEnum committeeType = HealthCommitteeTypeEnum.NormalCommittee;
            if (HCRequestReason.ReasonForExamination != null && HCRequestReason.ReasonForExamination.HealthCommitteeType.HasValue)
                committeeType = HCRequestReason.ReasonForExamination.HealthCommitteeType.Value;
            if (!ReportNo.Value.HasValue && IsOldAction != true)
            {
                string raporGrubu = HCRequestReason.ReasonForExamination.HCReportTypeDefinition.ReportGroupName;
                ReportNo.GetNextValue(raporGrubu, Common.RecTime().Year);
            }

            //Engelli raporu ve engel oranı %0 çıkmışsa hasta ödere çevrilir.
            if (HCRequestReason.ReasonForExamination.HCReportTypeDefinition.IsDisabled == true && FunctionRatio == 0)
            {
                WhoPays = WhoPaysEnum.PatientPays;
                TurnMySubActionsToPatientShare(true);
            }
#endregion PostTransition_Report2Completed
        }

        protected void PostTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
#region PostTransition_Completed2Cancelled
            Cancel();
#endregion PostTransition_Completed2Cancelled
        }

#region Methods
        protected override void OnConstruct()
        {
            base.OnConstruct();
        //ITTObject pObj = (ITTObject)this;
        //if(pObj.IsNew)
        //{
        //this.ReportNo.GetNextValue(Common.RecTime().Year);
        //}
        }

        public List<AppointmentCarrier> AppointmentCarrierList
        {
            get
            {
                List<AppointmentCarrier> _appointmentList = new List<AppointmentCarrier>();
                TTObjectContext context = new TTObjectContext(false);
                AppointmentDefinition appDef = null;
                IList appDefList = AppointmentDefinition.GetAppointmentDefinitionByName(context, AppointmentDefinitionEnum.HealthCommittee);
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
                    carrier.MasterResource = "ResHealthCommittee";
                    carrier.SubResource = "ResDepartment";
                    carrier.RelationParentName = "ResHealthCommittee";
                    _appointmentList.Add(carrier);
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

        public override ActionTypeEnum ActionType
        {
            get
            {
                return ActionTypeEnum.HealthCommittee;
            }
        }

        public HealthCommittee(TTObjectContext objectContext, EpisodeAction episodeAction): this (objectContext)
        {
            ActionDate = Common.RecTime();
            FromResource = episodeAction.MasterResource;
            CurrentStateDefID = HealthCommittee.States.New;
            MasterAction = episodeAction;
            Episode = episodeAction.Episode;
        }

        /// <summary>
        /// Ortez protezden fire edildiğinde ortez protezin HospitalsUnits ve ReasonForExamination değerlerini aktarmaya yaratan constracter
        /// </summary>
        /// <param name = "objectContext"></param>
        /// <param name = "reasonForExaminationDefinition"></param>
        /// <param name = "hospitalsUnitsList"></param>
        /// 
        public HealthCommittee(OrthesisProsthesisProcedure orthesisProsthesisProcedure): this (orthesisProsthesisProcedure.ObjectContext)
        {
            CurrentStateDefID = HealthCommittee.States.New;
            ActionDate = Common.RecTime();
            MasterAction = orthesisProsthesisProcedure.OrthesisProsthesisRequest;
            FromResource = orthesisProsthesisProcedure.OrthesisProsthesisRequest.FromResource;
            HCRequestReason.ReasonForExamination = ((OrthesisProsthesisRequest)orthesisProsthesisProcedure.OrthesisProsthesisRequest).ReasonForExamination;
            Episode = orthesisProsthesisProcedure.OrthesisProsthesisRequest.Episode;
            foreach (OrthesisProsthesisHospitalsUnitsGrid orthesisProsthesisHospitalsUnitsGrid in ((OrthesisProsthesisRequest)orthesisProsthesisProcedure.OrthesisProsthesisRequest).HospitalsUnits)
            {
                BaseHealthCommittee_HospitalsUnitsGrid hospitalsUnitsGrid = new BaseHealthCommittee_HospitalsUnitsGrid(ObjectContext);
                // hospitalsUnitsGrid.Hospital = orthesisProsthesisHospitalsUnitsGrid.Hospital;
                hospitalsUnitsGrid.Unit = orthesisProsthesisHospitalsUnitsGrid.Unit;
                HospitalsUnits.Add(hospitalsUnitsGrid);
            }
        }

        public HealthCommittee(TTObjectContext objectContext, PatientAdmission patientAdmission, bool AddProcedureToHC, EDisabledReport reportObj = null, EStatusNotRepCommitteeObj eStatusNotRepCommitteeObj = null) : this (objectContext)
        {
            CurrentStateDefID = HealthCommittee.States.New;
            ActionDate = Common.RecTime();
            MasterAction = patientAdmission;
            FromResource = patientAdmission.Policlinic;
            HCRequestReason = patientAdmission.HCRequestReason;
            //PA'nın firedEpisodeAction'ı Episode dan önce set edilmeli. Buradaki sıra önemli
            foreach (var firedAction in patientAdmission.FiredEpisodeActions)
            {
                if (firedAction is PatientExamination)
                {
                    ((PatientExamination)firedAction).SetPatientExaminationStatus();
                    ((PatientExamination)firedAction).SetResponsibleDoctorAsProcedureDoctor();
                }
            }

            patientAdmission.FiredEpisodeActions.Add(this);
            Episode = patientAdmission.Episode;
            WhoPays = patientAdmission.HCModeOfPayment;
            foreach (PatientAdmissionResourcesToBeReferred pAResourcesToBeReferred in patientAdmission.ResourcesToBeReferred)
            {
                BaseHealthCommittee_HospitalsUnitsGrid hospitalsUnitsGrid = new BaseHealthCommittee_HospitalsUnitsGrid(ObjectContext);
                hospitalsUnitsGrid.Unit = pAResourcesToBeReferred.Resource;
                hospitalsUnitsGrid.Speciality = pAResourcesToBeReferred.Speciality;
                hospitalsUnitsGrid.Doctor = pAResourcesToBeReferred.ProcedureDoctorToBeReferred;

                if (AddProcedureToHC)//otomatik atılcak işlemleri eklemesi için (kullanıcıdan gelen cevabı tutuyor)
                {
                    hospitalsUnitsGrid.EpisodeActionTemplate = GetEpisodeActionTemplate(pAResourcesToBeReferred);
                }

                HospitalsUnits.Add(hospitalsUnitsGrid);
            }

            CreateHCPackageProcedure();
            CreateHCReportProcedure();
            //CreateHCTetkik();
            if (HospitalsUnits != null || HospitalsUnits.Count > 0)
            {
                CheckHospitalsUnitsGridForFork();
            }
            if(patientAdmission.HCRequestReason.ReasonForExamination.HCReportTypeDefinition.IsDisabled == true)
            {
                foreach (var firedAction in patientAdmission.FiredEpisodeActions)
                {
                    if (firedAction is PatientExamination)
                    {
                        ((PatientExamination)firedAction).HCExaminationComponent.EDisabledReport = reportObj;
                    }
                }
            }
            else
            {
                foreach (var firedAction in patientAdmission.FiredEpisodeActions)
                {
                    if (firedAction is PatientExamination)
                    {
                        ((PatientExamination)firedAction).HCExaminationComponent.EStatusNotRepCommitteeObj = eStatusNotRepCommitteeObj;
                    }
                }
            }
            
            
        //objectContext.Save();
        //this.CurrentStateDefID = HealthCommittee.States.CommitteeAcceptance;
        }

        public HealthCommittee(TTObjectContext objectContext, InPatientTreatmentClinicApplication inPatientTreatmentClinicApplication, HealthCommittee.InpatientHC_Class inpatientHC_Class) : this(objectContext)
        {
            CurrentStateDefID = HealthCommittee.States.New;
            ActionDate = Common.RecTime();
            MasterAction = inPatientTreatmentClinicApplication;
            FromResource = inPatientTreatmentClinicApplication.MasterResource;
            HCRequestReason = objectContext.GetObject<HCRequestReason>(new Guid(inpatientHC_Class._hcReasonID));

            SubEpisode = inPatientTreatmentClinicApplication.SubEpisode;
            Episode = inPatientTreatmentClinicApplication.Episode;

            if (HCRequestReason.ReasonForExamination.HCReportTypeDefinition.IsDisabled == true &&  inpatientHC_Class.HCModeOfPayment != WhoPaysEnum.PatientPays)
                WhoPays = WhoPaysEnum.Free;
            else
                WhoPays = inpatientHC_Class.HCModeOfPayment;

            objectContext.AddToRawObjectList(inpatientHC_Class.resourcesToBeReferredList);
            objectContext.AddToRawObjectList(inpatientHC_Class.reasonForExaminationDefinition);
            if (inpatientHC_Class.eDisabledReport != null)
            {
                objectContext.AddToRawObjectList(inpatientHC_Class.eDisabledReport);
            }
            if (inpatientHC_Class.eStatusNotfReportObj != null)
            {
                objectContext.AddToRawObjectList(inpatientHC_Class.eStatusNotfReportObj);
            }
            objectContext.ProcessRawObjects(false);

            foreach (PatientAdmissionResourcesToBeReferred pAResourcesToBeReferred in inpatientHC_Class.resourcesToBeReferredList)
            {
                var hospitalTimeScheduleDetailImported = (PatientAdmissionResourcesToBeReferred)objectContext.GetLoadedObject(pAResourcesToBeReferred.ObjectID);

                BaseHealthCommittee_HospitalsUnitsGrid hospitalsUnitsGrid = new BaseHealthCommittee_HospitalsUnitsGrid(ObjectContext);
                hospitalsUnitsGrid.Unit = hospitalTimeScheduleDetailImported.Resource;
                hospitalsUnitsGrid.Speciality = hospitalTimeScheduleDetailImported.Speciality;
                hospitalsUnitsGrid.Doctor = hospitalTimeScheduleDetailImported.ProcedureDoctorToBeReferred;
                
                ///
                /// Yatıştan gelen sağlık kurulları için otomatik işlem atması istenmedi
                /// 
                //hospitalsUnitsGrid.EpisodeActionTemplate = GetEpisodeActionTemplate(hospitalTimeScheduleDetailImported);

                HospitalsUnits.Add(hospitalsUnitsGrid);
            }

            CreateHCPackageProcedure();
            CreateHCReportProcedure();
            //CreateHCTetkik();
            if (HospitalsUnits != null || HospitalsUnits.Count > 0)
            {
                CheckHospitalsUnitsGridForFork();
            }
            if (HCRequestReason.ReasonForExamination.HCReportTypeDefinition.IsDisabled == true)
            {
                foreach (var firedAction in this.LinkedActions)
                {
                    if (firedAction is PatientExamination)
                    {
                        ((PatientExamination)firedAction).HCExaminationComponent.EDisabledReport = inpatientHC_Class.eDisabledReport;
                    }
                }
            }
            else
            {
                foreach (var firedAction in this.LinkedActions)
                {
                    if (firedAction is PatientExamination)
                    {
                        ((PatientExamination)firedAction).HCExaminationComponent.EStatusNotRepCommitteeObj = inpatientHC_Class.eStatusNotfReportObj;
                    }
                }
            }

                SubEpisode.ArrangeMeOrCreateNewSubEpisode(this, false, false);
        }

        private EpisodeActionTemplate GetEpisodeActionTemplate(PatientAdmissionResourcesToBeReferred hospitalTimeScheduleDetailImported)
        {
            IList<ReasonForExaminationDefinition> pDefs = null;
            pDefs = (IList<ReasonForExaminationDefinition>)ReasonForExaminationDefinition.GetReasonForExaminationDefinitionByID(ObjectContext, HCRequestReason.ReasonForExamination.ObjectID.ToString());
            if (pDefs.Count > 0)
            {
                var template = pDefs[0].HospitalsUnits.Where(x => x.ProcedureDoctor.ObjectID == hospitalTimeScheduleDetailImported.ProcedureDoctorToBeReferred.ObjectID &&
                    x.Policklinic.ObjectID == hospitalTimeScheduleDetailImported.Resource.ObjectID).FirstOrDefault();

                if (template != null)
                {
                    return template.EpisodeActionTemplate;
                }
            }
            return null;
        }

        protected override ReasonForExaminationDefinition MyReasonForExamination()
        {
            return HCRequestReason.ReasonForExamination;
        }

        /// <summary>
        /// HospitalsUnits içindeki her bir satırın SK Muayenesi olarak fork edilmesini sağlar.
        /// </summary>
        protected void CheckHospitalsUnitsGridForFork()
        {
            foreach (BaseHealthCommittee_HospitalsUnitsGrid hospitalUnit in _HospitalsUnits)
            {
                EpisodeAction.ForkHealthCommitteeExamination((HospitalsUnitsGrid)hospitalUnit, this);
                //NE Portor muayeneleri yapılırken açılacak
                if (hospitalUnit.EpisodeActionTemplate != null)
                    this.FireEpisodeActionByTemplate(hospitalUnit.EpisodeActionTemplate, hospitalUnit.Unit);
                //else if (hospitalUnit.Template != null) // Eski ActionTemplate kalmadığında silinecek
                //{
                //    EpisodeAction templateEA = hospitalUnit.Template.Action as EpisodeAction;
                //    if (templateEA != null)
                //    {
                //        EpisodeAction firedAction = templateEA.CreateNewActionFromTemplate(hospitalUnit.Unit, this);
                //        firedAction.MasterAction = this;
                //    }
                //}
            }
        //NE Portor muayeneleri yapılırken açılacak
        //  this.ControlReasonForExaminationToTurnPatientShare();
        }

        public void FillHospitalsUnitsGridByReasonForExamination()
        {
            HospitalsUnits.Clear();
            IList<ReasonForExaminationDefinition> pDefs = null;
            pDefs = (IList<ReasonForExaminationDefinition>)ReasonForExaminationDefinition.GetReasonForExaminationDefinitionByID(ObjectContext, HCRequestReason.ReasonForExamination.ObjectID.ToString());
            if (pDefs.Count > 0)
            {
                foreach (HospitalsUnitsDefinitionGrid pDefGridItem in pDefs[0].HospitalsUnits)
                {
                    bool bValid = true;
                    if (pDefGridItem.MaxOld.HasValue && pDefGridItem.MaxOld.Value <= Episode.Patient.Age.Value)
                        bValid = false;
                    if (pDefGridItem.MinOld.HasValue && pDefGridItem.MinOld.Value > Episode.Patient.Age.Value)
                        bValid = false;
                    // if (pDefGridItem.Sex.HasValue && pDefGridItem.Sex.Value != SexEnum.Unidentified && pDefGridItem.Sex.Value != this.Episode.Patient.Sex.Value) bValid = false;
                    if (bValid)
                    {
                        BaseHealthCommittee_HospitalsUnitsGrid pGrid = new BaseHealthCommittee_HospitalsUnitsGrid(ObjectContext);
                        //pGrid.Hospital = pDefGridItem.ExaminationHospital;
                        //  pGrid.Hospitals = pDefGridItem.ExamHospital;
                        pGrid.Unit = pDefGridItem.Policklinic as ResSection;
                        //pGrid.ReferableResource = pDefGridItem.ReferableResource;
                        pGrid.Speciality = pDefGridItem.Speciality;
                        pGrid.Explanation = pDefGridItem.TemplateDescription;
                        pGrid.Template = pDefGridItem.Template;
                        pGrid.EpisodeActionTemplate = pDefGridItem.EpisodeActionTemplate;
                        HospitalsUnits.Add(pGrid);
                    }
                }
            }
        }

        private void CheckUnCompletedExamination()
        {
            bool bFound = HealthCommittee.UnCompletedExaminationExists(this);
            if (bFound)
                throw new TTUtils.TTException(SystemMessage.GetMessage(501));
        }

        public static double ? CalculateFunctionRatio(HealthCommittee healthCommittee)
        {
            double ? ratio = null;
            ArrayList arrList = EpisodeAction.GetLinkedEpisodeActions(healthCommittee);
            BindingList<double ? > rationList = new BindingList<double ? >();
            foreach (EpisodeAction eaction in arrList)
            {
                if (eaction is PatientExamination && ((PatientExamination)eaction).HCExaminationComponent != null && ((PatientExamination)eaction).HCExaminationComponent.DisabledRatio != null)
                {
                    rationList.Add(((PatientExamination)eaction).HCExaminationComponent.DisabledRatio);
                }
            }

            if (rationList.Count >= 2)
            {
                IEnumerable<double ? > rationListDesc = rationList.OrderByDescending(x => x.Value);
                double ? B = rationListDesc.ToList()[0];
                double ? A = rationListDesc.ToList()[1];
                ratio = healthCommittee.CalculateRatio(A, B);
                if (rationList.Count > 2)
                {
                    for (int i = 0; i < rationListDesc.Count(); i++)
                    {
                        if (ratio > rationListDesc.ToList()[i])
                        {
                            B = ratio;
                            A = rationListDesc.ToList()[i];
                            ratio = healthCommittee.CalculateRatio(A, B);
                        }
                        else if (ratio < rationListDesc.ToList()[i])
                        {
                            A = rationListDesc.ToList()[i];
                            B = ratio;
                            ratio = healthCommittee.CalculateRatio(A, B);
                        }
                    }
                }
            }
            else if (rationList.Count > 0)
                ratio = rationList[0];
            if (healthCommittee.Episode.Patient.Age >= 60)
                ratio = ratio + 0.1;
            return ratio;
        }

        private double ? CalculateRatio(double ? A, double ? B)
        {
            double ? ratio = 0;
            A = A / 100;
            B = B / 100;
            ratio = ((1 - A) * B) + A;
            return ratio;
        }

        public static bool UnCompletedExaminationExists(HealthCommittee healthCommittee)
        {
            bool bFound = false;
            ArrayList arrList = EpisodeAction.GetLinkedEpisodeActions(healthCommittee);
            foreach (EpisodeAction eaction in arrList)
            {
                if (eaction is PatientExamination && ((PatientExamination)eaction).PatientExaminationType == PatientExaminationEnum.HealthCommittee && !eaction.IsCancelled && eaction.CurrentStateDefID != PatientExamination.States.PatientNoShown)
                {
                    PatientExamination exam = (PatientExamination)eaction;
                    if (!exam.CurrentStateDefID.Equals(PatientExamination.States.Completed))
                    {
                        bFound = true;
                        break;
                    }
                }
            ///Sağlık Kurulu muayenesi Normal Muayene içinde uzamnlık olacak şekilde dönüştürüldü
             //if (eaction is HealthCommitteeExamination && !eaction.IsCancelled && eaction.CurrentStateDefID != HealthCommitteeExamination.States.PatientNoShown)
            //{
            //    HealthCommitteeExamination exam = (HealthCommitteeExamination)eaction;
            //    if (!exam.CurrentStateDefID.Equals(HealthCommitteeExamination.States.Completed))
            //    {
            //        bFound = true;
            //        break;
            //    }
            //}
            ///Kullanılmıyo
             //if (eaction is HealthCommitteeExaminationFromOtherDepartments && !eaction.IsCancelled && eaction.CurrentStateDefID.Value != HealthCommitteeExaminationFromOtherDepartments.States.Rejected)
            //{
            //    HealthCommitteeExaminationFromOtherDepartments exam = (HealthCommitteeExaminationFromOtherDepartments)eaction;
            //    if (!exam.CurrentStateDefID.Equals(HealthCommitteeExaminationFromOtherDepartments.States.Acceptance))
            //    {
            //        bFound = true;
            //        break;
            //    }
            //}
            //if (eaction is HealthCommitteeExaminationFromOtherHospitals && !eaction.IsCancelled)
            //{
            //    HealthCommitteeExaminationFromOtherHospitals exam = (HealthCommitteeExaminationFromOtherHospitals)eaction;
            //    if (!exam.CurrentStateDefID.Equals(HealthCommitteeExaminationFromOtherHospitals.States.Resulted))
            //    {
            //        bFound = true;
            //        break;
            //    }
            //}
            }

            return bFound;
        }

        public string GetUnCompletedExaminations()
        {
            string sUnits = "";
            ArrayList arrList = EpisodeAction.GetLinkedEpisodeActions(this);
            foreach (EpisodeAction eaction in arrList)
            {
                if (eaction is HealthCommitteeExamination && !eaction.IsCancelled && eaction.CurrentStateDefID != HealthCommitteeExamination.States.PatientNoShown)
                {
                    HealthCommitteeExamination exam = (HealthCommitteeExamination)eaction;
                    if (!exam.CurrentStateDefID.Equals(HealthCommitteeExamination.States.Completed))
                    {
                        sUnits += exam.MasterResource.Name + " , ";
                    }
                }

                if (eaction is HealthCommitteeExaminationFromOtherDepartments && !eaction.IsCancelled && eaction.CurrentStateDefID.Value != HealthCommitteeExaminationFromOtherDepartments.States.Rejected)
                {
                    HealthCommitteeExaminationFromOtherDepartments exam = (HealthCommitteeExaminationFromOtherDepartments)eaction;
                    if (!exam.CurrentStateDefID.Equals(HealthCommitteeExaminationFromOtherDepartments.States.Acceptance))
                    {
                        sUnits += exam.MasterResource.Name + " , ";
                    }
                }

                if (eaction is HealthCommitteeExaminationFromOtherHospitals && !eaction.IsCancelled)
                {
                    HealthCommitteeExaminationFromOtherHospitals exam = (HealthCommitteeExaminationFromOtherHospitals)eaction;
                    if (!exam.CurrentStateDefID.Equals(HealthCommitteeExaminationFromOtherHospitals.States.Resulted))
                    {
                        sUnits += exam.MasterResource.Name + " , ";
                    }
                }
            }

            if (sUnits != "")
                sUnits = sUnits.Substring(0, (sUnits.Length - 3));
            return sUnits;
        }

        public static bool CheckIfAllCancelledOrNotExists(HealthCommittee healthCommittee)
        {
            bool bCancelled = true;
            ArrayList arrList = EpisodeAction.GetLinkedEpisodeActions(healthCommittee);
            foreach (EpisodeAction eaction in arrList)
            {
                if (eaction is PatientExamination && !eaction.IsCancelled)
                {
                    if (((PatientExamination)eaction).HCExaminationComponent != null)
                    {
                        bCancelled = false;
                        break;
                    }
                }
            //if (eaction is HealthCommitteeExaminationFromOtherDepartments && !eaction.IsCancelled)
            //{
            //    bCancelled = false;
            //    break;
            //}
            //if (eaction is HealthCommitteeExaminationFromOtherHospitals && !eaction.IsCancelled)
            //{
            //    bCancelled = false;
            //    break;
            //}
            }

            return bCancelled;
        }

        //        protected override List<OldActionPropertyObject> OldActionPropertyList()
        //        {
        //            List<OldActionPropertyObject> propertyList;
        //            if(base.OldActionPropertyList()==null)
        //                propertyList = new List<OldActionPropertyObject>();
        //            else
        //                propertyList = base.OldActionPropertyList();
        //            propertyList.Add(new OldActionPropertyObject("Protokol No",Common.ReturnObjectAsString(this.ProtocolNo)));
        //            propertyList.Add(new OldActionPropertyObject("Rapor No",Common.ReturnObjectAsString(ReportNo)));
        //            propertyList.Add(new OldActionPropertyObject("Rapor Tarihi",Common.ReturnObjectAsString(ReportDate)));
        //            propertyList.Add(new OldActionPropertyObject("Rapor ",Common.ReturnObjectAsString(Report)));
        //            propertyList.Add(new OldActionPropertyObject("Karar ",Common.ReturnObjectAsString(Decision)));
        //            if(ProcedureDoctor!=null)
        //                propertyList.Add(new OldActionPropertyObject("Sorumlu Doktor ",Common.ReturnObjectAsString(ProcedureDoctor.Name)));
        //            if(this.ProcedureSpeciality!=null)
        //                propertyList.Add(new OldActionPropertyObject("Uzmanlık Dalı",Common.ReturnObjectAsString(this.ProcedureSpeciality.Name)));
        //
        //            return propertyList;
        //        }
        //
        //
        //        protected override List<List<List<OldActionPropertyObject>>> OldActionChildRelationList()
        //        {
        //            List<List<List<OldActionPropertyObject>>> gridList;
        //            if(base.OldActionChildRelationList()==null)
        //                gridList=new List<List<List<OldActionPropertyObject>>>();
        //            else
        //                gridList=base.OldActionChildRelationList();
        //            // Madde Dilim Fıkra
        //            List<List<OldActionPropertyObject>> gridMainSurgeryProceduresRowList=new List<List<OldActionPropertyObject>>();
        //            foreach(HealthCommittee_MatterSliceAnectodeGrid theGrid in this.MatterSliceAnectodes)
        //            {
        //                List<OldActionPropertyObject> gridMainSurgeryProceduresRowColumnList=new List<OldActionPropertyObject>();
        //                gridMainSurgeryProceduresRowColumnList.Add(new OldActionPropertyObject("Madde",Common.ReturnObjectAsString(theGrid.Matter)));
        //                gridMainSurgeryProceduresRowColumnList.Add(new OldActionPropertyObject("Dilim",Common.ReturnObjectAsString(theGrid.Slice)));
        //                gridMainSurgeryProceduresRowColumnList.Add(new OldActionPropertyObject("Fıkra",Common.ReturnObjectAsString(theGrid.Anectode)));
        //                gridMainSurgeryProceduresRowList.Add(gridMainSurgeryProceduresRowColumnList);
        //            }
        //            gridList.Add(gridMainSurgeryProceduresRowList);
        //
        //            return gridList;
        //        }
        /*
        public void RunCreateHCUncompleted(Guid currentStateDefID)
        {
            TTObjectContext objectContext = new TTObjectContext(false);
            
            HCUncompleted hcUncompleted = new HCUncompleted(objectContext);
            hcUncompleted.CreationDate = Common.RecTime();
            hcUncompleted.EpisodeHospitalProtocolNo = this.Episode.HospitalProtocolNo.ToString();
            hcUncompleted.EpisodeOpeningDate = this.Episode.OpeningDate;
            hcUncompleted.HCActionID = this.ID.ToString();
            hcUncompleted.HCObjectID = this.ObjectID;
            hcUncompleted.Patient = this.Episode.Patient;
            hcUncompleted.ReasonForExamination = this.ReasonForExamination;
            hcUncompleted.Site = TTObjectClasses.SystemParameter.GetSite();
            hcUncompleted.CurrentStateDefID = currentStateDefID;
            
            HealthCommittee.RemoteMethods.CreateHCUncompleted(Sites.SiteMerkezSagKom, hcUncompleted);
        }
        
        public void RunUpdateHCUncompleted(Guid state)
        {
            HealthCommittee.RemoteMethods.UpdateHCUncompleted(Sites.SiteMerkezSagKom, this.ObjectID, state);
        }
        
        public void RunSendHCSummary()
        {
            TTObjectContext objectContext = new TTObjectContext(false);

            HCSummary hcSummary = new HCSummary(objectContext);
            hcSummary.ReportDate = this.ReportDate;
            hcSummary.EpisodeOpeningDate = this.Episode.OpeningDate;
            hcSummary.DecisionTime = this.HCDecisionTime;
            hcSummary.DecisionUnitOfTime = this.HCDecisionUnitOfTime;
            hcSummary.HCObjectID = this.ObjectID;
            hcSummary.UnsuitableForMilitaryService = this.UnsuitableForMilitaryService;

            if (this.ReportNo.Value.HasValue)
                hcSummary.ReportNo = this.ReportNo.Value.ToString();

            if (this.ClinicHeight != null)
                hcSummary.Height = this.ClinicHeight;
            else if (this.HCHeight != null)
                hcSummary.Height = this.HCHeight;

            if (this.ClinicWeight != null)
                hcSummary.Weight = Convert.ToDouble((int)this.ClinicWeight);
            else if (this.HCWeight != null)
                hcSummary.Weight = this.HCWeight;

            if (this.Decision != null)
            {
                hcSummary.AdditionalDecision = Common.GetTextOfRTFString(this.Decision.ToString());
                if (hcSummary.AdditionalDecision.Length > 1000)
                    hcSummary.AdditionalDecision = hcSummary.AdditionalDecision.Substring(0, 1000);
            }

            hcSummary.AircraftType = this.AircraftType;
            hcSummary.Decision = this.HCDecision;
            hcSummary.Duty = this.HCDutyType;
            hcSummary.MilitaryClass = this.Episode.MilitaryClass;
            hcSummary.MilitaryUnit = this.Episode.MilitaryUnit;
            hcSummary.Patient = this.Episode.Patient;
            hcSummary.Rank = this.Episode.Rank;
            hcSummary.ReasonForExamination = this.ReasonForExamination;
            hcSummary.SenderChair = this.Episode.SenderChair;
            hcSummary.Site = TTObjectClasses.SystemParameter.GetSite();

            // Tanılar listeye eklenir
            List<HCSummaryDiagnosis> diagnosisList = new List<HCSummaryDiagnosis>();
            foreach (DiagnosisGrid dg in this.Diagnosis)
            {
                HCSummaryDiagnosis hcSummaryDiagnosis = new HCSummaryDiagnosis(objectContext);
                hcSummaryDiagnosis.DiagnosisDate = dg.DiagnoseDate;
                hcSummaryDiagnosis.DiagnosisType = dg.DiagnosisType;
                hcSummaryDiagnosis.FreeDiagnosis = dg.FreeDiagnosis;
                hcSummaryDiagnosis.IsMainDiagnosis = dg.IsMainDiagnose;
                hcSummaryDiagnosis.Diagnosis = dg.Diagnose;
                hcSummaryDiagnosis.HCSummary = hcSummary;
                diagnosisList.Add(hcSummaryDiagnosis);
            }

            // Madde Dilim Fıkralar listeye eklenir
            List<HCSummaryMSA> msaList = new List<HCSummaryMSA>();
            foreach (MatterSliceAnectodeGrid msa in this.MatterSliceAnectodes)
            {
                HCSummaryMSA hcSummaryMSA = new HCSummaryMSA(objectContext);
                hcSummaryMSA.Anectode = msa.Anectode;
                hcSummaryMSA.Matter = msa.Matter;
                hcSummaryMSA.Slice = msa.Slice;
                hcSummaryMSA.HCSummary = hcSummary;
                msaList.Add(hcSummaryMSA);
            }

            HealthCommittee.RemoteMethods.SendHCSummary(Sites.SiteMerkezSagKom, hcSummary, diagnosisList, msaList);
        }

        public static void RunGetHCSummariesThead(object hc)
        {
            HealthCommittee hcommittee = hc as HealthCommittee;
            hcommittee.RunGetHCSummaries();
        }

        public void RunGetHCSummaries()
        {
            try
            {
                List<HCSummaryPrevious> hcSummaryPreviousList = new List<HCSummaryPrevious>();
                hcSummaryPreviousList = HealthCommittee.RemoteMethods.GetHCSummaries(Sites.SiteMerkezSagKom, this.Episode.Patient.ObjectID);
                foreach (HCSummaryPrevious hcSP in hcSummaryPreviousList)
                {
                    this.ObjectContext.AddObject(hcSP);
                    HCSummaryPrevious hcSummaryPrevious = (HCSummaryPrevious)this.ObjectContext.GetObject(hcSP.ObjectID, hcSP.ObjectDef);
                    this.HCSummaryPrevious.Add(hcSummaryPrevious);
                }

                //Önceki Sağlık Kurulu İşlem sayısını getirir.
                this.NumberOfProcedure = this.HCSummaryPrevious.Count + 1;
            }
            catch { }
        }
        
        public void RunGetHCUncompleteds()
        {
            try
            {
                if(TTObjectClasses.SystemParameter.GetParameterValue("GETUNCOMPLETEDHCSUMMARIES","FALSE").ToUpper() == "TRUE")
                {
                    // HCUNCOMPLETEDCONTROLDAYLIMIT sistem parametresindeki gün kadar geriye bakılır
                    DateTime startDate = DateTime.MinValue;
                    string dayLimit = SystemParameter.GetParameterValue("HCUNCOMPLETEDCONTROLDAYLIMIT","");
                    if(!string.IsNullOrEmpty(dayLimit))
                        startDate = Common.RecTime().Date.AddDays(Convert.ToDouble(dayLimit) * -1);
                    
                    List<HCUncompletedPrevious> hcUncompletedPreviousList = new List<HCUncompletedPrevious>();
                    hcUncompletedPreviousList = HealthCommittee.RemoteMethods.GetHCUncompleteds(Sites.SiteMerkezSagKom, this.Episode.Patient.ObjectID, startDate);
                    foreach (HCUncompletedPrevious hcUP in hcUncompletedPreviousList)
                    {
                        this.ObjectContext.AddObject(hcUP);
                        HCUncompletedPrevious hcUncompletedPrevious = (HCUncompletedPrevious)this.ObjectContext.GetObject(hcUP.ObjectID, hcUP.ObjectDef);
                        this.HCUncompletedPrevious.Add(hcUncompletedPrevious);
                    }
                }
            }
            catch { }
        }

        public void RunSendHealthCommittee()
        {
            if (this.HCApprovelOfChair != null)
            {
                if (this.HCApprovelOfChair.Site != null)
                {
                    TTObjectContext objectContext = new TTObjectContext(false);

                    Guid savePoint = this.ObjectContext.BeginSavePoint();
                    string messageString = "";
                    try
                    {
                        List<DiagnosisGrid> diagnosisList = new List<DiagnosisGrid>();
                        foreach (DiagnosisGrid dg in this.Episode.Diagnosis)
                        {
                            diagnosisList.Add(dg.PrepareDiagnosisGridForRemoteMethod(true));
                        }

                        List<HealthCommittee_MatterSliceAnectodeGrid> matterSliceAnectodeList = new List<HealthCommittee_MatterSliceAnectodeGrid>();
                        foreach (HealthCommittee_MatterSliceAnectodeGrid msa in this.MatterSliceAnectodes)
                        {
                            matterSliceAnectodeList.Add(msa.PrepareForRemoteMethod(true));
                        }

                        Sites localSite = TTObjectClasses.SystemParameter.GetSite();
                        TTMessage message = HealthCommittee.RemoteMethods.SendHealthCommittee(this.HCApprovelOfChair.Site.ObjectID, this.Episode.Patient, this.Episode.PrepareEpisodeForRemoteMethod(true), this.SubEpisode.PatientAdmission.PreparePatientAdmissionForRemoteMethod(true), (HealthCommittee)this.PrepareEpisodeActionForRemoteMethod(true), diagnosisList, matterSliceAnectodeList, localSite, this.ObjectID, this.Episode.GetMyEpisodeProtocolForRemoteMethod());
                        messageString = message.MessageID.ToString();
                        // SYNC aşağısı
                        //Common.RemotingResultClass rrc = HealthCommittee.RemoteMethods.SendHealthCommittee(this.HCApprovelOfChair.Site.ObjectID, this.Episode.Patient, this.Episode.PrepareEpisodeForRemoteMethod(true), this.SubEpisode.PatientAdmission.PreparePatientAdmissionForRemoteMethod(true), (HealthCommittee)this.PrepareEpisodeActionForRemoteMethod(true), diagnosisList, matterSliceAnectodeList, localSite, this.ObjectID);
                        //messageString = rrc.resultMessage.ToString();
                    }
                    finally
                    {
                        this.ObjectContext.RollbackSavePoint(savePoint);
                        this.MessageID = messageString;
                        this.ObjectContext.Save();
                    }
                }
                //else
                //    throw new Exception("Gönderilen Makamın Saha Adı boş olmamalıdır.");
            }
            //else
            //    throw new Exception("Gönderilen Makamı seçiniz.");
        }

        public void RunReturnHealthCommittee()
        {
            Guid savePoint = this.ObjectContext.BeginSavePoint();
            String messageString = "";
            try
            {
                List<DiagnosisGrid> diagnosisList = new List<DiagnosisGrid>();
                foreach (DiagnosisGrid dg in this.Diagnosis) // Geriye gönderilirken yalnız HealthCommittee konulan tanılar geriye gönderiliyor.
                {
                    if (dg.ResponsibleUser != null)
                        diagnosisList.Add(dg.PrepareDiagnosisGridForRemoteMethod(true));
                }
                TTMessage message = HealthCommittee.RemoteMethods.ReturnHealthCommittee(this.Episode.CreaterSite.ObjectID, (HealthCommittee)this.PrepareEpisodeActionForRemoteMethod(true), diagnosisList, this.ObjectID);
                messageString = message.MessageID.ToString();
                // SYNC aşağısı
                //Common.RemotingResultClass rrc = HealthCommittee.RemoteMethods.ReturnHealthCommittee(this.Episode.CreaterSite.ObjectID, (HealthCommittee)this.PrepareEpisodeActionForRemoteMethod(true), diagnosisList, this.ObjectID);
                //messageString = rrc.resultMessage.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.ObjectContext.RollbackSavePoint(savePoint);
                this.MessageID = messageString;
                this.ObjectContext.Save();
            }
        }
        */
        public override EpisodeAction PrepareEpisodeActionForRemoteMethod(bool withNewObjectID)
        {
            HealthCommittee hc = (HealthCommittee)base.PrepareEpisodeActionForRemoteMethod(withNewObjectID);
            if (withNewObjectID)
            {
                hc.Department = null;
                hc.Doctor = null;
                hc.Requester = null;
            }

            return (EpisodeAction)hc;
        }

        [TTStorageManager.Attributes.TTRequiredRoles(TTRoleNames.Saglik_Kurulu_Yeni_RU, TTRoleNames.Saglik_Kurulu_Yeni_RUW, TTRoleNames.Saglik_Kurulu_Yeni_ruw)]
        // Laboratuvar isteklerini LabAsistan'a gönderen metod
        public static void SendToLab(HealthCommittee healthCommittee)
        {
            foreach (BaseAction baseAction in healthCommittee.LinkedActions)
            {
                //if (baseAction is LaboratoryRequest)
                //{
                //    //                    Cursor current = Cursor.Current;
                //    //                    Cursor.Current = Cursors.WaitCursor;
                //    try
                //    {
                //        LaboratoryRequest labRequest = baseAction as LaboratoryRequest;
                //        if (labRequest != null && labRequest.ID.Value.HasValue)
                //        {
                //            string sysparam = TTObjectClasses.SystemParameter.GetParameterValue("LABINTEGRATED", null);
                //            if (sysparam == "TRUE")
                //            {
                //                if (labRequest.IsRequestSent != true)
                //                {
                //                    Guid messageID = LaboratoryRequest.SendToLabASync(labRequest);
                //                    TTObjectContext context = new TTObjectContext(false);
                //                    LaboratoryRequest request = (LaboratoryRequest)context.GetObject(labRequest.ObjectID, "LaboratoryRequest");
                //                    request.MessageID = messageID.ToString();
                //                    request.IsRequestSent = true;
                //                    context.Save();
                //                }
                //            }
                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //        throw;
                //    }
                ////                    finally
                ////                    {
                ////                        Cursor.Current = current;
                ////                    }
                //}
            }
        }

        // Muayene sebebi "Hasta Öder" şeklinde tanımlı ise Sağlık Kurulu işleminin ve sağlık kuruluna bağlı işlemlerin içindeki
        // hizmet ve malzemeleri hasta payına çevirir.
        public void ControlReasonForExaminationToTurnPatientShare()
        {
            if (AutomaticallyCreated != true && WhoPays == WhoPaysEnum.PatientPays)
            {
                TurnMySubActionsToPatientShare(true);
                foreach (BaseAction baseAction in LinkedActions)
                {
                    EpisodeAction episodeAction = baseAction as EpisodeAction;
                    // Sağlık Kurulu Muayenesi zaten bu aşamada ücretlenmiş oluyor, şablondaki Laboratuvar ve Radyoloji
                    // işlemlerini de burada ücretlendirmek gerekiyor ki, AccTrx leri hasta payına çevrilebilsin
                    if (!(episodeAction is HealthCommitteeExamination))
                        episodeAction.AccountOperationDirect(AccountOperationTimeEnum.PREPOST);
                    episodeAction.TurnMySubActionsToPatientShare(true);
                }
            }
        }

        public ExaminationQueueItem CreateMyExaminationQueueItem(PatientAdmission patientAdmission, ExaminationQueueDefinition appQueueDef)
        {
            Dictionary<int, string> PriorityPair;
            ExaminationQueueItem examinationQueueItem = null;
            if (TTObjectClasses.SystemParameter.GetParameterValue("CloseExaminationQueueItem", "FALSE") != "TRUE")
            {
                if (MasterResource != null && MasterResource is ResHealthCommittee && ((ResHealthCommittee)MasterResource).PCSInUse == true)
                {
                    if (HasActiveQueueItem() == false)
                    {
                        /* PriorityPair = this.SubEpisode.PatientAdmission.GetMyPriority(appQueueDef, false);
                         KeyValuePair<int, string> kp = new KeyValuePair<int,string>();
                         foreach (KeyValuePair<int, string> kpair in PriorityPair)
                         {
                             kp = kpair;
                             break;
                         }*/
                        examinationQueueItem = new ExaminationQueueItem(ObjectContext);
                        examinationQueueItem.EpisodeAction = this;
                        examinationQueueItem.Appointment = null;
                        examinationQueueItem.CurrentStateDefID = TTObjectClasses.ExaminationQueueItem.States.New;
                        examinationQueueItem.Patient = Episode.Patient;
                        examinationQueueItem.Priority = (patientAdmission.PriorityStatus == null) ? 5000 : patientAdmission.PriorityStatus.Order;
                        examinationQueueItem.PriorityReason = (patientAdmission.PriorityStatus == null) ? "" : patientAdmission.PriorityStatus.Name;
                        examinationQueueItem.QueueDate = Common.RecTime().Date;
                        examinationQueueItem.CallTime = Common.RecTime();
                        examinationQueueItem.ExaminationQueueDefinition = appQueueDef;
                        examinationQueueItem.DivertedTime = Common.RecTime();
                        examinationQueueItem.Doctor = ProcedureDoctor;
                        examinationQueueItem.CallCount = 0;
                    }
                }
            }

            return examinationQueueItem;
        }

        // Sağlık Kurulu Paket Hizmeti oluşturulur ve ücretlendirilir
        public void CreateHCPackageProcedure()
        {
            bool isExists = false;
            Guid procedureCode = ProcedureDefinition.HCPackageProcedureObjectId; // Sağlık Kurulu Raporu paket hizmeti
            Guid procedureCodeGunLicense = ProcedureDefinition.HCGunLicensePackageProcedureObjectId; // Silah Ruhsatı için Sağlık Raporu paket hizmeti
            Guid procedureCodeOneDoctor = ProcedureDefinition.HCOneDoctorPackageProcedureObjectId; // Tek Hekim Sağlık Raporu paket hizmeti
            foreach (HealthCommitteeProcedure HCProc in HealthCommitteeProcedures)
            {
                if (HCProc.CurrentStateDefID != SubActionProcedure.States.Cancelled)
                {
                    Guid procedureObjectID = HCProc.ProcedureObject.ObjectID;
                    if (procedureObjectID.Equals(procedureCode) || procedureObjectID.Equals(procedureCodeGunLicense) || procedureObjectID.Equals(procedureCodeOneDoctor))
                    {
                        isExists = true;
                        break;
                    }
                }
            }

            if (!isExists)
            {
                //Guid procedureObjectID = procedureCode;
                //if (this.HospitalsUnits != null && this.HospitalsUnits.Count == 1) // Tek Hekim Sağlık Raporu Paket Hizmetine çevirme kodu kaldırıldı )
                //    procedureObjectID = procedureCodeOneDoctor;
                if (HCRequestReason.ReasonForExamination.PackageProcedure == null)
                    throw new TTException(TTUtils.CultureService.GetText("M26820", "Seçilen sağlık kurulu muayene tipinin Paket Hizmet tanımı boş. Kontrol ediniz."));
                HealthCommitteeProcedure pProcedure = new HealthCommitteeProcedure(this, HCRequestReason.ReasonForExamination.PackageProcedure.ObjectID.ToString());
                pProcedure.AccountOperation(AccountOperationTimeEnum.PREPOST);
                // Kurum hastaları için sağlık kurulu paketi hasta payına çevrilir
                foreach (AccountTransaction AccTrx in pProcedure.AccountTransactions)
                {
                    if (WhoPays == WhoPaysEnum.PatientPays)
                    {
                        if (AccTrx.AccountPayableReceivable.Type == APRTypeEnum.PAYER)
                            AccTrx.TurnToPatientShare(true);
                        AccTrx.CurrentStateDefID = AccountTransaction.States.New;
                    }
                    else if (WhoPays == WhoPaysEnum.Free)
                        AccTrx.InvoiceInclusion = false;
                }
            }
        }

        public void CreateHCReportProcedure()
        {
            bool isExists = false;
            Guid procedureCode = ProcedureDefinition.HCReportProcedureObjectId; // Sağlık Kurulu Rapor hizmeti
            foreach (HealthCommitteeProcedure HCProc in HealthCommitteeProcedures)
            {
                if (HCProc.CurrentStateDefID != SubActionProcedure.States.Cancelled && HCProc.ProcedureObject.ObjectID.Equals(procedureCode))
                {
                    isExists = true;
                    break;
                }
            }

            if (!isExists)
            {
                HealthCommitteeProcedure pProcedure = new HealthCommitteeProcedure(this, procedureCode.ToString());
                pProcedure.AccountOperation(AccountOperationTimeEnum.PREPOST);
                // Kurum hastaları için sağlık kurulu rapor hizmeti hasta payına çevrilir
                foreach (AccountTransaction AccTrx in pProcedure.AccountTransactions)
                {
                    if (WhoPays == WhoPaysEnum.PatientPays)
                    {
                        if (AccTrx.AccountPayableReceivable.Type == APRTypeEnum.PAYER)
                            AccTrx.TurnToPatientShare();
                        AccTrx.CurrentStateDefID = AccountTransaction.States.New;
                        AccTrx.InvoiceInclusion = false;
                    }
                    else if (WhoPays == WhoPaysEnum.Free)
                        AccTrx.InvoiceInclusion = false;
                }
            }
        }

        public void CreateHCTetkik()
        {
            bool isExists = false;
            //Guid procedureCode = ProcedureDefinition.HCReportProcedureObjectId; // Sağlık Kurulu Rapor hizmeti
            //foreach (HealthCommitteeProcedure HCProc in HealthCommitteeProcedures)
            //{
            //    if (HCProc.CurrentStateDefID != SubActionProcedure.States.Cancelled && HCProc.ProcedureObject.ObjectID.Equals(procedureCode))
            //    {
            //        isExists = true;
            //        break;
            //    }
            //}

            if (!isExists)
            {
                HealthCommitteeProcedure pProcedure = new HealthCommitteeProcedure(this, "73c56aef-e385-4624-8d81-d2f0db52f73a");
                pProcedure.AccountOperation(AccountOperationTimeEnum.PREPOST);
                // Kurum hastaları için sağlık kurulu rapor hizmeti hasta payına çevrilir
                foreach (AccountTransaction AccTrx in pProcedure.AccountTransactions)
                {
                    if (WhoPays == WhoPaysEnum.PatientPays)
                    {
                        if (AccTrx.AccountPayableReceivable.Type == APRTypeEnum.PAYER)
                            AccTrx.TurnToPatientShare();
                        AccTrx.CurrentStateDefID = AccountTransaction.States.New;
                        AccTrx.InvoiceInclusion = false;
                    }
                    else if (WhoPays == WhoPaysEnum.Free)
                        AccTrx.InvoiceInclusion = false;
                }
            }
        }

        // İlgili klasörde hastanın TC Kimlik No ile aynı isimde bir fotoğraf dosyası varsa,
        // sağlık kurulu işleminin ve hastanın fotoğraf alanına set edilir
        public bool DecisionExistsInExaminations()
        {
            ArrayList arrList = EpisodeAction.GetLinkedEpisodeActions(this);
            foreach (EpisodeAction eaction in arrList)
            {
                if (eaction is HealthCommitteeExamination)
                {
                    HealthCommitteeExamination exam = (HealthCommitteeExamination)eaction;
                    if (exam.CurrentStateDefID.Equals(HealthCommitteeExamination.States.Completed))
                    {
                        if ((exam.OfferOfDecision != null && !string.IsNullOrEmpty(exam.OfferOfDecision.Trim())) || (exam.MatterSliceAnectodes != null && exam.MatterSliceAnectodes.Count > 0) || exam.Report != null)
                            return true;
                    }
                }
                else if (eaction is HealthCommitteeExaminationFromOtherHospitals)
                {
                    HealthCommitteeExaminationFromOtherHospitals exam = (HealthCommitteeExaminationFromOtherHospitals)eaction;
                    if (exam.CurrentStateDefID.Equals(HealthCommitteeExaminationFromOtherHospitals.States.Resulted))
                    {
                        if ((exam.OfferOfDecision != null && !string.IsNullOrEmpty(exam.OfferOfDecision.Trim())) || (exam.MatterSliceAnectodes != null && exam.MatterSliceAnectodes.Count > 0) || exam.Report != null)
                            return true;
                    }
                }
            }

            return false;
        }

        public void SetCommitteeAcceptanceStatus()
        {
            if (CurrentStateDefID.Equals(HealthCommittee.States.New) || CurrentStateDefID.Equals(HealthCommittee.States.Cancelled))
                CommitteeAcceptanceStatus = HCCommitteeAcceptanceStatus.Unknown;
            else if (CurrentStateDefID.Equals(HealthCommittee.States.CommitteeAcceptance))
            {
                if (HealthCommittee.UnCompletedExaminationExists(this))
                    CommitteeAcceptanceStatus = HCCommitteeAcceptanceStatus.ExaminationsNotCompleted;
                else
                {
                    if (DecisionExistsInExaminations())
                        CommitteeAcceptanceStatus = HCCommitteeAcceptanceStatus.ExaminationsCompletedDecisionExists;
                    else
                        CommitteeAcceptanceStatus = HCCommitteeAcceptanceStatus.ExaminationsCompletedDecisionNotExists;
                }
            }
            else
                CommitteeAcceptanceStatus = HCCommitteeAcceptanceStatus.CommitteeAcceptancePassed;
        }

#endregion Methods
        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof (HealthCommittee).Name)
                return;
            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;
            if (fromState == HealthCommittee.States.New && toState == HealthCommittee.States.CommitteeAcceptance)
                PreTransition_New2CommitteeAcceptance();
            else if (fromState == HealthCommittee.States.CommitteeAcceptance && toState == HealthCommittee.States.Appointment)
                PreTransition_CommitteeAcceptance2Appointment();
            else if (fromState == HealthCommittee.States.CommitteeAcceptance && toState == HealthCommittee.States.Report)
                PreTransition_CommitteeAcceptance2Report();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof (HealthCommittee).Name)
                return;
            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;
            if (fromState == HealthCommittee.States.New && toState == HealthCommittee.States.Cancelled)
                PostTransition_New2Cancelled();
            else if (fromState == HealthCommittee.States.New && toState == HealthCommittee.States.CommitteeAcceptance)
                PostTransition_New2CommitteeAcceptance();
            else if (fromState == HealthCommittee.States.CommitteeAcceptance && toState == HealthCommittee.States.Appointment)
                PostTransition_CommitteeAcceptance2Appointment();
            else if (fromState == HealthCommittee.States.CommitteeAcceptance && toState == HealthCommittee.States.Cancelled)
                PostTransition_CommitteeAcceptance2Cancelled();
            else if (fromState == HealthCommittee.States.Completed && toState == HealthCommittee.States.Cancelled)
                PostTransition_Completed2Cancelled();
            else if (fromState == HealthCommittee.States.CommitteeAcceptance && toState == HealthCommittee.States.Report)
                PostTransition_CommitteeAcceptance2Report();
            else if (fromState == HealthCommittee.States.Report && toState == HealthCommittee.States.Completed)
                PostTransition_Report2Completed();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof (HealthCommittee).Name)
                return;
            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;
            if (fromState == HealthCommittee.States.New && toState == HealthCommittee.States.CommitteeAcceptance)
                UndoTransition_New2CommitteeAcceptance(transDef);
            else if (fromState == HealthCommittee.States.CommitteeAcceptance && toState == HealthCommittee.States.Report)
                UndoTransition_CommitteeAcceptance2Report(transDef);
        }

        #region ICreateSubEpisode metodları


        public override bool IsNewSubEpisodeNeeded()
        {
            if (MasterAction is InPatientTreatmentClinicApplication)
                return true;
            return false;
        }

        public override DateTime SubEpisodeOpeningDate()
        {
            return RequestDate.Value;
        }

        public override DiagnosisCopyEnum GetDiagnosisCopyEnum()
        {

            return DiagnosisCopyEnum.DontCopy;
        }

        //TODO ismail
        public override void FillLocalSEPProperties(ref SubEpisodeProtocol sep)
        {
            if (MasterAction is InPatientTreatmentClinicApplication)
            {
                sep.Brans = SpecialityDefinition.GetBrans("9999");
                sep.MedulaTedaviTuru = TedaviTuru.GetTedaviTuru("A");
                sep.MedulaTedaviTipi = TedaviTipi.GetTedaviTipi("0");
            }
        }

        //TODO ismail
        public override SubEpisodeStatusEnum GetSubEpisodePatientStatus()
        {
                return SubEpisodeStatusEnum.Outpatient;
        }

        public override ResSection GetSubEpisodeResSection()
        {
                return MasterResource;
        }

        public override SpecialityDefinition GetSubEpisodeSpeciality()
        {
                return null;//Sağlık kurulu işleminin uzmanılığı yok
        }

        //Episode Episode { get; set; }

        //public override List<EpisodeAction> LinkedEpisodeActionsForSubEpisode
        //{
        //    get
        //    {
        //        List<EpisodeAction> eaList = base.LinkedEpisodeActionsForSubEpisode;

        //        foreach (EpisodeAction episodeAction in this.LinkedActions)//muayeneleri 
        //        {
        //            eaList.Add((EpisodeAction)episodeAction);
        //        }

        //        return eaList;
        //    }
        //    set { }
        //}

        //public override ISubEpisodeStarter SubEpisodeStarter { get { return this} set { } }

        //public override SubEpisode SubEpisodeCreatedByMe { get; set; }



        #endregion


    }
}