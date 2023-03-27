
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
    /// Tıbbi/Cerrahi Uygulama İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
    public partial class Manipulation : EpisodeActionWithDiagnosis, IReasonOfReject, IAppointmentDef, IWorkListEpisodeAction, ICreateSubEpisode, IDiagnosisOzelDurum
    {
        public partial class GetAllManiplationOfPatient_Class : TTReportNqlObject
        {
        }

        public partial class GetManiplationbyEpisode_Class : TTReportNqlObject
        {
        }

        public partial class GetManipulationsbyRequest_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetManipulation22_Class : TTReportNqlObject
        {
        }

        #region IDiagnosisOzelDurum Members
        public OzelDurum GetOzelDurum()
        {
            return OzelDurum;
        }

        public void SetOzelDurum(OzelDurum value)
        {
            OzelDurum = value;
        }

        public DiagnosisGrid.ChildDiagnosisGridCollection GetDiagnosis()
        {
            return Diagnosis;
        }
        #endregion

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "MANIPULATIONREQUEST":
                    {
                        ManipulationRequest value = (ManipulationRequest)newValue;
                        #region MANIPULATIONREQUEST_SetParentScript
                        if (value != null)
                        {
                            MedulaHastaKabul = value.MedulaHastaKabul;
                            if (SubEpisode == null && value.SubEpisode != null)
                                SubEpisode = value.SubEpisode;
                        }
                        #endregion MANIPULATIONREQUEST_SetParentScript
                    }
                    break;

                default:
                    base.RunSetMemberValueScript(memberName, newValue);
                    break;

            }
        }

        protected override void PreUpdate()
        {
            #region PreUpdate
            base.PreUpdate();
            #endregion PreUpdate
        }

        protected override void PostUpdate()
        {
            #region PostUpdate
            base.PostUpdate();

            #endregion PostUpdate
        }

        protected void PostTransition_RequestingDoctorFromTechnicianProcedure2Cancelled()
        {
            // From State : RequestingDoctorFromTechnicianProcedure   To State : Cancelled
            #region PostTransition_RequestingDoctorFromTechnicianProcedure2Cancelled
            Cancel();

            #endregion PostTransition_RequestingDoctorFromTechnicianProcedure2Cancelled
        }

        protected void UndoTransition_RequestAcception2Appointment(TTObjectStateTransitionDef transitionDef)
        {
            // From State : RequestAcception   To State : Appointment
            #region UndoTransition_RequestAcception2Appointment

            /*Verilmiş bütün randevuların stepbackte iptal edilmesi gerekir. */
            foreach (Appointment app in EpisodeAction.GetMyNewAppointments(ObjectID))
            {
                app.CurrentStateDefID = Appointment.States.Cancelled;
            }


            #endregion UndoTransition_RequestAcception2Appointment
        }

        protected void UndoTransition_RequestAcception2DoctorProcedure(TTObjectStateTransitionDef transitionDef)
        {
            // From State : RequestAcception   To State : DoctorProcedure
            #region UndoTransition_RequestAcception2DoctorProcedure

            /*Form prede doldurulan ProcrdureDoctor un içini boşaltır. */
            EmptyProcedureDoctorAsCurrentResource();

            #endregion UndoTransition_RequestAcception2DoctorProcedure
        }

        protected void PostTransition_RequestAcception2Cancelled()
        {
            // From State : RequestAcception   To State : Cancelled
            #region PostTransition_RequestAcception2Cancelled
            Cancel();
            #endregion PostTransition_RequestAcception2Cancelled
        }

        protected void PostTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
            #region PostTransition_Completed2Cancelled
            Cancel();
            #endregion PostTransition_Completed2Cancelled
        }

        protected void PostTransition_RequestingDoctorFromAcception2Cancelled()
        {
            // From State : RequestingDoctorFromAcception   To State : Cancelled
            #region PostTransition_RequestingDoctorFromAcception2Cancelled
            Cancel();
            #endregion PostTransition_RequestingDoctorFromAcception2Cancelled
        }

        protected void PreTransition_ResultEntry2Completed()
        {
            // From State : ResultEntry   To State : Completed
            #region PreTransition_ResultEntry2Completed
            CheckIfReportIsRequired();
            CheckIfReportIsRequiredForMedulaInpatient();
            #endregion PreTransition_ResultEntry2Completed
        }

        protected void PostTransition_ResultEntry2Completed()
        {
            // From State : ResultEntry   To State : Completed
            #region PostTransition_ResultEntry2Completed
            SetMySubActionProceduresPerformedDate();
            #endregion PostTransition_ResultEntry2Completed
        }

        protected void PostTransition_ResultEntry2Cancelled()
        {
            // From State : ResultEntry   To State : Cancelled
            #region PostTransition_ResultEntry2Cancelled
            Cancel();
            #endregion PostTransition_ResultEntry2Cancelled
        }

        protected void PreTransition_DoctorProcedure2Completed()
        {
            // From State : DoctorProcedure   To State : Completed
            #region PreTransition_DoctorProcedure2Completed

            CheckIfReportIsRequired();

            CheckIfReportIsRequiredForMedulaInpatient();

            SetMySubActionProceduresPerformedDate();
            #endregion PreTransition_DoctorProcedure2Completed
        }

        protected void PostTransition_DoctorProcedure2Cancelled()
        {
            // From State : DoctorProcedure   To State : Cancelled
            #region PostTransition_DoctorProcedure2Cancelled
            Cancel();
            #endregion PostTransition_DoctorProcedure2Cancelled
        }

        protected void PostTransition_Appointment2Cancelled()
        {
            // From State : Appointment   To State : Cancelled
            #region PostTransition_Appointment2Cancelled
            Cancel();
            #endregion PostTransition_Appointment2Cancelled
        }

        protected void PostTransition_TechnicianProcedure2Cancelled()
        {
            // From State : TechnicianProcedure   To State : Cancelled
            #region PostTransition_TechnicianProcedure2Cancelled
            Cancel();
            #endregion PostTransition_TechnicianProcedure2Cancelled
        }

        protected void UndoTransition_TechnicianProcedure2ResultEntry(TTObjectStateTransitionDef transitionDef)
        {
            // From State : TechnicianProcedure   To State : ResultEntry
            #region UndoTransition_TechnicianProcedure2ResultEntry

            /*Form prede doldurulan ProcrdureDoctor un içini boşaltır. */
            EmptyProcedureDoctorAsCurrentResource();

            #endregion UndoTransition_TechnicianProcedure2ResultEntry
        }

        protected void PostTransition_RequestingDoctorFromDoctorProcedure2Cancelled()
        {
            // From State : RequestingDoctorFromDoctorProcedure   To State : Cancelled
            #region PostTransition_RequestingDoctorFromDoctorProcedure2Cancelled
            Cancel();

            #endregion PostTransition_RequestingDoctorFromDoctorProcedure2Cancelled
        }

        protected void UndoTransition_RequestingDoctorFromDoctorProcedure2DoctorProcedure(TTObjectStateTransitionDef transitionDef)
        {
            // From State : RequestingDoctorFromDoctorProcedure   To State : DoctorProcedure
            #region UndoTransition_RequestingDoctorFromDoctorProcedure2DoctorProcedure

            /*Form prede doldurulan ProcrdureDoctor un içini boşaltır. */
            EmptyProcedureDoctorAsCurrentResource();

            #endregion UndoTransition_RequestingDoctorFromDoctorProcedure2DoctorProcedure
        }

        protected void PostTransition_NursingProcedure2Cancelled()
        {
            // From State : NursingProcedure   To State : Cancelled
            #region PostTransition_NursingProcedure2Cancelled

            Cancel();

            #endregion PostTransition_NursingProcedure2Cancelled
        }

        protected void UndoTransition_NursingProcedure2ResultEntry(TTObjectStateTransitionDef transitionDef)
        {
            // From State : NursingProcedure   To State : ResultEntry
            #region UndoTransition_NursingProcedure2ResultEntry

            /*Form prede doldurulan ProcrdureDoctor un içini boşaltır. */
            EmptyProcedureDoctorAsCurrentResource();

            #endregion UndoTransition_NursingProcedure2ResultEntry
        }

        #region Methods
        //
        //        protected override List<OldActionPropertyObject> OldActionPropertyList()
        //        {
        //            List<OldActionPropertyObject> propertyList = base.OldActionPropertyList();
        //            if(propertyList==null)
        //                propertyList = new List<OldActionPropertyObject>();
        //
        //            //-------------------------------------
        //
        //            propertyList.Add(new OldActionPropertyObject("Önbilgi", Common.ReturnObjectAsString(ManipulationRequest.PreInformation)));
        //            propertyList.Add(new OldActionPropertyObject("İşlem Raporu", Common.ReturnObjectAsString(ProcedureReport)));
        //            propertyList.Add(new OldActionPropertyObject("Rapor",Common.ReturnObjectAsString(Report)));
        //            propertyList.Add(new OldActionPropertyObject("Teknisyen Notu",Common.ReturnObjectAsString(TechnicianNote)));
        //            propertyList.Add(new OldActionPropertyObject("İşlem Tarihi",Common.ReturnObjectAsString(ActionDate)));
        //
        //            //---------------------------------------
        //            return propertyList;
        //
        //        }



        protected override List<List<List<EpisodeAction.OldActionPropertyObject>>> OldActionChildRelationList()
        {
            List<List<List<EpisodeAction.OldActionPropertyObject>>> gridList = base.OldActionChildRelationList();
            if (gridList == null)
                gridList = new List<List<List<EpisodeAction.OldActionPropertyObject>>>();

            List<List<EpisodeAction.OldActionPropertyObject>> gridPersonelCaptionRowList = new List<List<EpisodeAction.OldActionPropertyObject>>();
            List<EpisodeAction.OldActionPropertyObject> gridPersonelCaptionRowColumnList = new List<EpisodeAction.OldActionPropertyObject>();
            gridPersonelCaptionRowColumnList.Add(new EpisodeAction.OldActionPropertyObject("İşlevde Görev Alan Personel ", null));
            gridPersonelCaptionRowList.Add(gridPersonelCaptionRowColumnList);

            gridList.Add(gridPersonelCaptionRowList);

            List<List<EpisodeAction.OldActionPropertyObject>> gridFolderContentsRowList = new List<List<EpisodeAction.OldActionPropertyObject>>();
            foreach (ManipulationPersonnel personnel in ManipulationPersonnel)
            {
                List<EpisodeAction.OldActionPropertyObject> gridFolderContentsRowColumnList = new List<EpisodeAction.OldActionPropertyObject>();
                gridFolderContentsRowColumnList.Add(new EpisodeAction.OldActionPropertyObject("Personel", Common.ReturnObjectAsString(personnel.Personnel.Name)));
                gridFolderContentsRowList.Add(gridFolderContentsRowColumnList);
            }
            gridList.Add(gridFolderContentsRowList);
            //
            //            gridFolderContentsRowList = new List<List<OldActionPropertyObject>>();
            //            foreach(ManipulationReturnReasonsGrid manipRetRes in ManipulationReturnReasons)
            //            {
            //                List<OldActionPropertyObject> gridFolderContentsRowColumnList=new List<OldActionPropertyObject>();
            //                gridFolderContentsRowColumnList.Add(new OldActionPropertyObject("İade Nedeni",Common.ReturnObjectAsString(manipRetRes.ReturnReason)));
            //                gridFolderContentsRowList.Add(gridFolderContentsRowColumnList);
            //            }
            //            gridList.Add(gridFolderContentsRowList);
            //
            //
            //            gridFolderContentsRowList = new List<List<OldActionPropertyObject>>();
            //            foreach( SubActionProcedure  subProc in SubactionProcedures)
            //            {
            //                List<OldActionPropertyObject> gridFolderContentsRowColumnList=new List<OldActionPropertyObject>();
            //                gridFolderContentsRowColumnList.Add(new OldActionPropertyObject("Tarih/Saat",Common.ReturnObjectAsString(subProc.ActionDate)));
            //                if(subProc.ProcedureObject != null)
            //                    gridFolderContentsRowColumnList.Add(new OldActionPropertyObject("Tıbbi Cerrahi Uygulama",Common.ReturnObjectAsString(subProc.ProcedureObject.Name)));
            //                //if(subProc.ProcedureDepartment != null )
            //                //    gridFolderContentsRowColumnList.Add(new OldActionPropertyObject("Uygulanacak Birim",Common.ReturnObjectAsString(subProc.ProcedureDepartment)));
            //                gridFolderContentsRowColumnList.Add(new OldActionPropertyObject("Acil",Common.ReturnObjectAsString(subProc.Emergency)));
            //
            //                if(subProc.ProcedureDoctor != null )
            //                    gridFolderContentsRowColumnList.Add(new OldActionPropertyObject("İşlemi Yapması Öngörülen Doktor",Common.ReturnObjectAsString(subProc.ProcedureDoctor.Name)));
            //                gridFolderContentsRowList.Add(gridFolderContentsRowColumnList);
            //            }
            //            gridList.Add(gridFolderContentsRowList);

            return gridList;
        }

        public List<AppointmentCarrier> AppointmentCarrierList
        {
            get
            {
                List<AppointmentCarrier> _appointmentList = new List<AppointmentCarrier>();
                TTObjectContext context = new TTObjectContext(false);
                AppointmentDefinition appDef = null;
                IList appDefList = AppointmentDefinition.GetAppointmentDefinitionByName(context, AppointmentDefinitionEnum.Manipulation);
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
                    carrier.MasterResource = "ResPoliclinic";
                    carrier.SubResource = "ResUser";
                    carrier.RelationParentName = "";

                    _appointmentList.Add(carrier);
                }
                ClearAppointmentCarrierDynamicFields(_appointmentList);
                return _appointmentList;
            }
        }

        #region IAppointmentDef Members
        public List<AppointmentCarrier> GetAppointmentCarrierList()
        {
            return AppointmentCarrierList;
        }
        #endregion


        /*
        public override System.Collections.Generic.IEnumerable<SubActionProcedure> AccountableSubActionProcedures
        {
            get{ if (ManipulationProcedures.Count > 0)
                {
                    List<SubActionProcedure> accountableSubActions = new List<SubActionProcedure>();
                    foreach(ManipulationProcedure myDet in ManipulationProcedures)
                        accountableSubActions.Add((SubActionProcedure)myDet);
                    return accountableSubActions;
                }
                else
                    return null;
            }
        }
         */
        /* public override List<SubActionMaterial> AccountableSubActionMaterials
        {
            get { if (_TreatmentMaterials != null)
                {
                    if (_TreatmentMaterials.Count > 0)
                    {
                        List <SubActionMaterial> accountableSubActions = new List<SubActionMaterial>();
                        foreach(BaseTreatmentMaterial  myDet in _TreatmentMaterials)
                            accountableSubActions.Add((SubActionMaterial)myDet);
                        return accountableSubActions;
                    }
                    else return null;
                }
                else return null;
            }
            
        }*/

        public Manipulation(ManipulationRequest maniplationRequest, TTObjectClasses.ResSection masterResource)
            : this(maniplationRequest.ObjectContext)
        {
            CurrentStateDefID = Manipulation.States.RequestAcception;
            PatientAdmission = maniplationRequest.PatientAdmission;
            SetMandatoryEpisodeActionProperties((EpisodeAction)maniplationRequest, masterResource, false);
            ManipulationRequest = maniplationRequest;

        }



        public void CheckIfReportIsRequired()
        {

            if (!(Report != null && !string.IsNullOrEmpty(Common.GetTextOfRTFString(Report.ToString()).Trim())))
            {
                foreach (ManipulationProcedure mp in ManipulationProcedures)
                {
                    if (mp.ProcedureObject is SurgeryDefinition)
                    {
                        if (((SurgeryDefinition)mp.ProcedureObject).ReportIsRequired == true)
                        {
                            throw new Exception(SystemMessage.GetMessageV3(1132, new string[] { mp.ProcedureObject.Name.ToString() }));
                        }
                    }
                }
            }

        }

        public void CheckIfReportIsRequiredForMedulaInpatient()
        {
            if (SubEpisode.IsSGK && Episode.PatientStatus != PatientStatusEnum.Outpatient)
            {
                if (Report == null || string.IsNullOrEmpty(Common.GetTextOfRTFString(Report.ToString()).Trim()))
                {
                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26875", "SGK'lı yatan hastalarda rapor yazılması zorunludur!"));
                }
            }
        }

        public override SubEpisodeStatusEnum GetSubEpisodePatientStatus()
        {
                return SubEpisodeStatusEnum.Daily;
        }

        // Yeni SubEpisode oluşturulmasına karar veren metod
        public override bool IsNewSubEpisodeNeeded()
        {
            if (base.IsNewSubEpisodeNeeded() == false)
                return false;

            // TODO: IsGunubirlikTakip property si kullanılacak mı ? Kullanılacaksa buraya da eklenmeli. (MDZ)

            if (Episode.PatientStatus == PatientStatusEnum.Outpatient && SubEpisode.IsSGK == true && IsMedulaProvisionNecessaryProcedureExists() == true)
                return Episode.Patient.SuitableToCreateNewDailySubEpisode(GetSubEpisodeSpeciality());

            return false;
        }

        // SEP in değiştirilmesi gereken propertyleri varsa bu metodda set edilmeli
        public override void FillLocalSEPProperties(ref SubEpisodeProtocol sep)
        {
            //Takip Tipi (Zorunlu)
            //if (this.MedulaProvision != null && this.MedulaProvision.TakipTipi != null && this.MedulaProvision.TakipTipi.takipTipiKodu != null)
            //    provizyonGirisDVO.takipTipi = this.MedulaProvision.TakipTipi.takipTipiKodu;

            //Tedavi Tipi (Zorunlu)
            //if (this.MedulaProvision != null && this.MedulaProvision.TedaviTipi != null && this.MedulaProvision.TedaviTipi.tedaviTipiKodu != null)
            //    provizyonGirisDVO.tedaviTipi = this.MedulaProvision.TedaviTipi.tedaviTipiKodu;

            //Brans Kodu (Zorunlu)
            //if (this.MedulaProvision != null && this.MedulaProvision.Brans != null && this.MedulaProvision.Brans.bransKodu != null)
            //    provizyonGirisDVO.bransKodu = this.MedulaProvision.Brans.bransKodu;

            //SubEpisodeProtocol parentSEP = this.Episode.GetFirstSEP();
            //if (parentSEP != null)
            //    subEpisodeProtocol.ParentSEP = parentSEP;

            if (IsGunubirlikTakip == true)  // Bu kontrol önceden de olduğu için kaldırılmadı, gereksiz ise kaldırılacak (MDZ)
            {
                if (sep.ParentSEP != null && sep.ParentSEP.MedulaProvizyonTarihi.Value.DayOfYear < Common.RecTime().DayOfYear)
                    sep.ParentSEP = null;
            }
        }

        public override void Cancel()
        {
            base.Cancel();
            MakingDirectPurchaseMaterialsUnUsed();
        }

        public void MakingDirectPurchaseMaterialsUnUsed()
        {
            foreach (SurgeryDirectPurchaseGrid sdg in Manipulation_SurgeryDirectPurchaseGrids)
            {
                if (sdg.DPADetailFirmPriceOffer != null && sdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail != null)
                    sdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.HasUsed = false;
            }
        }

        #endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(Manipulation).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == Manipulation.States.ResultEntry && toState == Manipulation.States.Completed)
                PreTransition_ResultEntry2Completed();
            else if (fromState == Manipulation.States.DoctorProcedure && toState == Manipulation.States.Completed)
                PreTransition_DoctorProcedure2Completed();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(Manipulation).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == Manipulation.States.RequestingDoctorFromTechnicianProcedure && toState == Manipulation.States.Cancelled)
                PostTransition_RequestingDoctorFromTechnicianProcedure2Cancelled();
            else if (fromState == Manipulation.States.RequestAcception && toState == Manipulation.States.Cancelled)
                PostTransition_RequestAcception2Cancelled();
            else if (fromState == Manipulation.States.Completed && toState == Manipulation.States.Cancelled)
                PostTransition_Completed2Cancelled();
            else if (fromState == Manipulation.States.RequestingDoctorFromAcception && toState == Manipulation.States.Cancelled)
                PostTransition_RequestingDoctorFromAcception2Cancelled();
            else if (fromState == Manipulation.States.ResultEntry && toState == Manipulation.States.Completed)
                PostTransition_ResultEntry2Completed();
            else if (fromState == Manipulation.States.ResultEntry && toState == Manipulation.States.Cancelled)
                PostTransition_ResultEntry2Cancelled();
            else if (fromState == Manipulation.States.DoctorProcedure && toState == Manipulation.States.Cancelled)
                PostTransition_DoctorProcedure2Cancelled();
            else if (fromState == Manipulation.States.Appointment && toState == Manipulation.States.Cancelled)
                PostTransition_Appointment2Cancelled();
            else if (fromState == Manipulation.States.TechnicianProcedure && toState == Manipulation.States.Cancelled)
                PostTransition_TechnicianProcedure2Cancelled();
            else if (fromState == Manipulation.States.RequestingDoctorFromDoctorProcedure && toState == Manipulation.States.Cancelled)
                PostTransition_RequestingDoctorFromDoctorProcedure2Cancelled();
            else if (fromState == Manipulation.States.NursingProcedure && toState == Manipulation.States.Cancelled)
                PostTransition_NursingProcedure2Cancelled();

            //if(toState == States.DoctorProcedure || toState == States.TechnicianProcedure || toState == States.NursingProcedure)
            //    this.SubEpisode.ArrangeMeOrCreateNewSubEpisode(this, false);  // SubEpisode ve SubEpisodeProtocol oluşturup meduladan takip alan metod
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(Manipulation).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == Manipulation.States.RequestAcception && toState == Manipulation.States.Appointment)
                UndoTransition_RequestAcception2Appointment(transDef);
            else if (fromState == Manipulation.States.RequestAcception && toState == Manipulation.States.DoctorProcedure)
                UndoTransition_RequestAcception2DoctorProcedure(transDef);
            else if (fromState == Manipulation.States.TechnicianProcedure && toState == Manipulation.States.ResultEntry)
                UndoTransition_TechnicianProcedure2ResultEntry(transDef);
            else if (fromState == Manipulation.States.RequestingDoctorFromDoctorProcedure && toState == Manipulation.States.DoctorProcedure)
                UndoTransition_RequestingDoctorFromDoctorProcedure2DoctorProcedure(transDef);
            else if (fromState == Manipulation.States.NursingProcedure && toState == Manipulation.States.ResultEntry)
                UndoTransition_NursingProcedure2ResultEntry(transDef);
        }

        protected override void PreInsert()
        {
            #region PreInsert
            base.PreInsert();
            #endregion PreInsert
        }

        public virtual void CreateManipulationFormBaseObject() // Uzmanlık için  Ayaktan da ve Default olarak
        {
            if (ManipulationFormBaseObject == null || ManipulationFormBaseObject.Count == 0)
            {
                if (ManipulationProcedures != null && ManipulationProcedures.Count > 0)
                {
                    if (ManipulationProcedures[0].ProcedureObject != null)
                    {
                        ManipulationFormBaseObject manipulationFormBaseObject = null;
                        SurgeryDefinition surgeryDefinition = (SurgeryDefinition)ManipulationProcedures[0].ProcedureObject;
                        if (surgeryDefinition.ManipulationFormName != null)
                        {

                            switch ((ManipulationFormNameEnum)surgeryDefinition.ManipulationFormName)
                            {
                                case ManipulationFormNameEnum.EkokardiografiForm:
                                    manipulationFormBaseObject = new EkokardiografiFormObject(this);
                                    break;
                                case ManipulationFormNameEnum.AudiologyForm:
                                    manipulationFormBaseObject = new AudiologyObject(this);
                                    break;

                            }
                        }
                        if (manipulationFormBaseObject != null)
                        {
                            manipulationFormBaseObject.Manipulation = this;
                        }
                    }
                }
            }
        }

    }
}