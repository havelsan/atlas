
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


using static TTObjectClasses.DrugReturnAction;

namespace TTObjectClasses
{
    /// <summary>
    /// Muayene Tedavi Sonuçlarının Sisteme Girildiği  Nesnedir
    /// </summary>
    public partial class TreatmentDischarge : EpisodeActionWithDiagnosis
    {
        public partial class TreatmentDischargeReport_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetTreatmentDischarge_Class : TTReportNqlObject
        {
        }

        public partial class GetDispatchToOtherHospital_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_Sevk_Class : TTReportNqlObject
        {
        }

        /// 


        protected override void PreInsert()
        {
            #region PreInsert
            base.PreInsert();
            CheckRequiredPropertyAndRelations();
            // SetNursingApplicationAsReadyToDischarge();
            #endregion PreInsert
        }

        protected override void PostUpdate()
        {
            #region PostUpdate
            base.PostUpdate();
            CheckRequiredPropertyAndRelations();
            #endregion PostUpdate
        }

        protected void PreTransition_New2PreDischarge()
        {
            // From State : New   To State : PreDischarge
            #region PreTransition_New2Completed
            CheckRequiredPropertyAndRelationsForPreDischarge();
            #endregion PreTransition_New2PreDischarge
        }

        public void createNewTigObject()
        {
            TigEpisode tigEpisode = new TigEpisode(ObjectContext);
            //SubEpisodeProtocol firstSEP = this.Episode.GetFirstSEP();
            //var firstInpatientTratmentApp = this.Episode.GetFirstInpatientTreatmentClinicApp();
            var inpatientAdmission = InPatientTreatmentClinicApp.BaseInpatientAdmission;// this.Episode.InpatientAdmissions.Where(t => t.HospitalDischargeDate == this.InPatientTreatmentClinicApp.ClinicDischargeDate).FirstOrDefault();
            InPatientTreatmentClinicApplication firstInpatientTratmentApp;
            if (inpatientAdmission != null)
            {
                tigEpisode.PatientType = TIGPatientTypeEnum.Inpatient;
                if (SEP.MedulaTedaviTuru.tedaviTuruKodu != null && SEP.MedulaTedaviTuru.tedaviTuruKodu == "G")
                    tigEpisode.PatientType = TIGPatientTypeEnum.Outpatient;

                if (tigEpisode.PatientType == TIGPatientTypeEnum.Outpatient)
                    firstInpatientTratmentApp = inpatientAdmission.InPatientTreatmentClinicApplications.Where(t => t.ClinicInpatientDate == inpatientAdmission.HospitalInPatientDate && t.IsDailyOperation != null && t.IsDailyOperation == true).FirstOrDefault();
                else
                    firstInpatientTratmentApp = inpatientAdmission.InPatientTreatmentClinicApplications.Where(t => t.ClinicInpatientDate == inpatientAdmission.HospitalInPatientDate &&
                    ((t.IsDailyOperation != null && t.IsDailyOperation == false) || (t.IsDailyOperation == null))).FirstOrDefault();
                if (firstInpatientTratmentApp == null)
                    firstInpatientTratmentApp = inpatientAdmission.InPatientTreatmentClinicApplications[0];
                tigEpisode.InpatientDate = firstInpatientTratmentApp.ClinicInpatientDate;
                tigEpisode.AppointmentStatus = true;
                tigEpisode.BranchGuid = firstInpatientTratmentApp.ProcedureSpeciality.ObjectID;
                tigEpisode.Cancelled = false;
                tigEpisode.CodingStatus = false;
                tigEpisode.DischargeDate = InPatientTreatmentClinicApp.ClinicDischargeDate;
                tigEpisode.DischargerDoctorGuid = ProcedureDoctor.ObjectID;
                tigEpisode.DoctorGuid = firstInpatientTratmentApp.ProcedureDoctor.ObjectID;
                tigEpisode.EpicrisisStatus = HasEpicrisis();
                tigEpisode.EpisodeGuid = Episode.ObjectID;
                tigEpisode.InPatientProtocolNo = firstInpatientTratmentApp.SubEpisode.ProtocolNo;
                tigEpisode.InvoiceStatus = SEP.InvoiceCollectionDetail != null ? true : false;// TODO Mustafa abiye sor Bütün faturalar mı yoksa en az bir tane mi
                BindingList<Pathology.GetPathologyStatesForTIG_Class> tests = Pathology.GetPathologyStatesForTIG(Episode.ObjectID, null);
                if (tests.Count > 0)
                {
                    tigEpisode.PathologyRequestStatus = true;
                    tigEpisode.PathologyReportStatus = false;
                    foreach (Pathology.GetPathologyStatesForTIG_Class pT in tests)
                    {
                        if (pT.CurrentStateDefID == Pathology.States.Approvement || pT.CurrentStateDefID == Pathology.States.Report)
                        {
                            tigEpisode.PathologyReportStatus = true;
                            break;
                        }
                    }
                }
                else
                {
                    tigEpisode.PathologyRequestStatus = true;
                    tigEpisode.PathologyReportStatus = false;
                }
                tigEpisode.PatientGuid = Episode.Patient.ObjectID;

                tigEpisode.ResourceGuid = firstInpatientTratmentApp.MasterResource.ObjectID;
                tigEpisode.SEPGuid = firstInpatientTratmentApp.SEP.ObjectID;
                //TODO Mert Nida hanıma sor tigEpisode.Surgeries
                tigEpisode.XMLStatus = false;
            }

        }
        protected void PostTransition_New2PreDischarge()
        {
            // From State : New   To State : PreDischarge
            #region PostTransition_New2PreDischarge
            if (SubEpisode.PatientStatus == SubEpisodeStatusEnum.Inpatient)
                SubEpisode.InpatientStatus = InpatientStatusEnum.Predischarged;
            PreDischargeNursingAndPhysicianApplications();
            DischagedOrTransferInPatientTreatmentClinicApp();
            //CheckAndFireMorgue(); // artık Client tarafında yapılıyor 

            // SubEpisode kapatılmasada Taburcu Tarihi set ediliyor ki Taburcu tarihinden sonra işlem başlatmama kontrolü burdan yapılabilsin
            SubEpisode.ClosingDate = InPatientTreatmentClinicApp.ClinicDischargeDate;


            if (!IsTransferToOtherClinic)
            {
                Episode.PatientStatus = PatientStatusEnum.PreDischarge;
                if (InPatientTreatmentClinicApp.ClinicDischargeDate == null)
                    throw new Exception(TTUtils.CultureService.GetText("M26980", "Taburcu tarihi olmadan Hasta Taburcu edilemez..."));
                else
                    ((InpatientAdmission)InPatientTreatmentClinicApp.BaseInpatientAdmission).HospitalDischargeDate = InPatientTreatmentClinicApp.ClinicDischargeDate;


                createNewTigObject();
            }

            if (SendToENabiz())
            {
                new SendToENabiz(ObjectContext, SubEpisode, SubEpisode.ObjectID, SubEpisode.ObjectDef.Name, "106", Common.RecTime());
            }
            #endregion PostTransition_New2PreDischarge
        }

        protected void UndoTransition_New2PreDischarge(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : PreDischarge
            #region UndoTransition_New2PreDischarge
            if (SubEpisode.PatientStatus == SubEpisodeStatusEnum.Inpatient)
                SubEpisode.InpatientStatus = InpatientStatusEnum.Inpatient;
            UndoPreDischargeNursingAndPhysicianApplications();
            UndoDischagedOrTransferInPatientTreatmentClinicApp();
            CheckAndCancelMorgue();

            SubEpisode.ClosingDate = null;
            if (!IsTransferToOtherClinic)
            {
                Episode.PatientStatus = PatientStatusEnum.Inpatient;
                ((InpatientAdmission)InPatientTreatmentClinicApp.BaseInpatientAdmission).HospitalDischargeDate = null;
            }
            #endregion UndoTransition_New2PreDischarge
        }

        protected void PostTransition_PreDischarge2Discharged()
        {
            // From State : PreDischarge   To State : Dischged
            #region PostTransition_PreDischarge2Dischged
            if (SubEpisode.PatientStatus == SubEpisodeStatusEnum.Inpatient)
            {
                if (IsTransferToOtherClinic)
                    SubEpisode.InpatientStatus = InpatientStatusEnum.TransferToOtherClinic;
                else
                    SubEpisode.InpatientStatus = InpatientStatusEnum.Discharged;
            }

            else if (SubEpisode.PatientStatus == SubEpisodeStatusEnum.Daily)
            {
                SubEpisode.InpatientStatus = InpatientStatusEnum.Discharged;
            }
            DischargeNursingAndPhysicianApplications();
            DischargeInpatientAdmission();
            if (!IsTransferToOtherClinic)
            {
                Episode.PatientStatus = PatientStatusEnum.Discharge;
                InPatientTreatmentClinicApp.MedulaHastaCikisKayit(false); // predischargeda hata aldı ise medula çıkışını burda yapsın diye
            }
            #endregion PostTransition_PreDischarge2Dischged
        }

        protected void UndoTransition_PreDischarge2Discharged(TTObjectStateTransitionDef transitionDef)
        {
            // From State : PreDischarge   To State : Dischged
            #region UndoTransition_PreDischarge2Dischged
            if (SubEpisode.PatientStatus == SubEpisodeStatusEnum.Inpatient)
                SubEpisode.InpatientStatus = InpatientStatusEnum.Predischarged;
            UndoDischargeNursingAndPhysicianApplications();
            UndoDischargeInpatientAdmission();
            UndoDischagedOrTransferInPatientTreatmentClinicApp();
            if (!IsTransferToOtherClinic)
                Episode.PatientStatus = PatientStatusEnum.PreDischarge;
            #endregion UndoTransition_PreDischarge2Dischged
        }


        protected void PostTransition_New2Cancelled()
        {
            // From State : New   To State : Cancelled
            #region PostTransition_New2Cancelled
            Cancel();
            #endregion PostTransition_New2Cancelled
        }

        protected void UndoTransition_New2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : Cancelled
            #region UndoTransition_New2Cancelled
            NoBackStateBack();
            #endregion UndoTransition_New2Cancelled
        }

        protected void PostTransition_PreDischarge2Cancelled()
        {
            // From State : PreDischarge   To State : Cancelled
            #region PostTransition_PreDischarge2Cancelled
            Cancel();
            #endregion PostTransition_PreDischarge2Cancelled
        }

        protected void UndoTransition_PreDischarge2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : PreDischarge  To State : Cancelled
            #region UndoTransition_PreDischarge2Cancelled
            NoBackStateBack();

            #endregion UndoTransition_PreDischarge2Cancelled
        }


        protected void PostTransition_Discharged2Cancelled()
        {
            // From State : Discharged   To State : Cancelled
            #region PostTransition_Discharged2Cancelled
            Cancel();
            #endregion PostTransition_Discharged2Cancelled
        }

        protected void UndoTransition_Discharged2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Discharged   To State : Cancelled
            #region UndoTransition_Discharged2Cancelled
            NoBackStateBack();
            #endregion UndoTransition_Discharged2Cancelled
        }








        #region  Methods
        public override ActionTypeEnum ActionType
        {
            get
            {
                return ActionTypeEnum.TreatmentDischarge;
            }
        }

        protected bool IsTransferToOtherClinic
        {
            get
            {
                if (GetMyDischargeTypeEnum() == DischargeTypeEnum.TransferToOtherClinic)
                    return true;
                return false;
            }
        }
        //protected void setNumberOfReport()
        //{
        //    if(this.NumberOfReport==null)
        //        this.NumberOfReport.GetNextValue(Common.RecTime().Year);
        //}


        public TreatmentDischarge(EpisodeAction episodeAction) : this(episodeAction.ObjectContext)
        {
            SetTreatmentDischargePropertiesByMasterEpisodeAction(episodeAction);
        }



        public void SetTreatmentDischargePropertiesByMasterEpisodeAction(EpisodeAction episodeAction)
        {
            ActionDate = Common.RecTime();
            MasterResource = episodeAction.MasterResource;
            FromResource = episodeAction.MasterResource;
            CurrentStateDefID = TreatmentDischarge.States.New;

            if (episodeAction is InPatientPhysicianApplication)
                InPatientTreatmentClinicApp = ((InPatientPhysicianApplication)episodeAction).InPatientTreatmentClinicApp;
            else if (episodeAction is NursingApplication)
                InPatientTreatmentClinicApp = ((NursingApplication)episodeAction).InPatientTreatmentClinicApp;
            else if (episodeAction is InPatientTreatmentClinicApplication)
                InPatientTreatmentClinicApp = ((InPatientTreatmentClinicApplication)episodeAction);
            else
                throw new Exception(episodeAction.ObjectDef.ApplicationName + " işleminden Taburcu işlemi başlatılamaz");

            SecondaryMasterResource = InPatientTreatmentClinicApp.BaseInpatientAdmission.RoomGroup;
            InPatientTreatmentClinicApp.TreatmentDischarge = this;

            MasterAction = episodeAction;
            Episode = episodeAction.Episode;
            ProcedureSpeciality = episodeAction.ProcedureSpeciality;
            if (ProcedureDoctor == null)
                ProcedureDoctor = InPatientTreatmentClinicApp.ProcedureDoctor;

        }

        public void CheckRequiredPropertyAndRelations()
        {
            if (DischargeType == null)
                throw new Exception(SystemMessage.GetMessage(676));
        }
        // Taburcu etmeden önce yapılması gereken zorunluluk kontrollerini yapar

        public void CheckRequiredPropertyAndRelationsForPreDischarge()
        {
            // Çıkış tarihi yatan hasta için boş olamaz
            if (DischargeDate == null)
            {
                throw new Exception(SystemMessage.GetMessage(679));
            }
            else
            {
                // Yatan Hasta için Çıkış tarihi Servis Yatış Tarihinden küçük olamaz.

                if (InPatientTreatmentClinicApp != null)
                {
                    if (Convert.ToDateTime(InPatientTreatmentClinicApp.ClinicInpatientDate) != null)
                    {
                        if (Common.DateDiffV2(0, Convert.ToDateTime(DischargeDate), Convert.ToDateTime(InPatientTreatmentClinicApp.ClinicInpatientDate), false) < 0)
                        {
                            throw new Exception(SystemMessage.GetMessage(680));
                        }
                    }
                    else
                    {
                        throw new Exception(SystemMessage.GetMessage(681));
                    }
                }

                if (IsOldAction != true)//aktarımdan gelen işlem değilse kontrole girecek.
                {
                    //Yatan Hasta için Çıkış Tarihi ileri tarihli olamaz
                    if (Convert.ToDateTime(Common.RecTime().Date) < Convert.ToDateTime(DischargeDate.Value.Date))
                    {
                        throw new Exception("Çıkış Tarihi , ileri tarihli olamaz. ");
                    }
                }

            }

            //CheckForensicMedicalReport();

        }

        // InPatientTreatmentClinicApp PreDischageda Dischaged çekilir
        public void DischagedOrTransferInPatientTreatmentClinicApp()
        {
            if (IsTransferToOtherClinic)
            {
                TransferToOtherClinic(); // Patient Transfer yapar
            }
            else
            {
                InPatientTreatmentClinicApp.CurrentStateDefID = InPatientTreatmentClinicApplication.States.Discharged;// Taburcu Edilecek
            }

        }

        public void TransferToOtherClinic()
        {
            InPatientTreatmentClinicApp.BaseInpatientAdmission.TreatmentClinic = TransferTreatmentClinic;
            InPatientTreatmentClinicApplication inPatientTreatmentClinicApplication = new InPatientTreatmentClinicApplication(InPatientTreatmentClinicApp.BaseInpatientAdmission, TransferTreatmentClinic, MasterResource);
            inPatientTreatmentClinicApplication.FromInPatientTrtmentClinicApp = InPatientTreatmentClinicApp;
            InPatientTreatmentClinicApp.CurrentStateDefID = InPatientTreatmentClinicApplication.States.Transferred;// Transfer edilecek

        }

        public void UndoDischagedOrTransferInPatientTreatmentClinicApp()
        {
            InPatientTreatmentClinicApp.IsToInpatientClinicAppCancelled = IsToInpatientClinicAppCancelled;
            //TODO UNDO
            //Klinik İşlemleri  Taburcu Et geri al
            if (InPatientTreatmentClinicApp.CurrentStateDefID == InPatientTreatmentClinicApplication.States.Discharged)
            {
                InPatientTreatmentClinicApp.UndoByMasterAction = true;
                ((ITTObject)InPatientTreatmentClinicApp).UndoLastTransition();// Procedure'a gider
            }
            else if (InPatientTreatmentClinicApp.CurrentStateDefID == InPatientTreatmentClinicApplication.States.Transferred)
            {
                InPatientTreatmentClinicApp.UndoByMasterAction = true;
                ((ITTObject)InPatientTreatmentClinicApp).UndoLastTransition();// Procedure'a gider
            }
        }


        protected void PreDischargeNursingAndPhysicianApplications()
        {
            //Doktor İşlemleri Ön Taburcu Et
            foreach (InPatientPhysicianApplication inPatientPhysicianApplication in InPatientTreatmentClinicApp.InPatientPhysicianApplication)
            {
                if (inPatientPhysicianApplication.CurrentStateDefID == InPatientPhysicianApplication.States.Application)
                {
                    inPatientPhysicianApplication.CurrentStateDefID = InPatientPhysicianApplication.States.PreDischarged;
                }
            }

            // Hemşire İşlemleri Ön Taburcu Et
            foreach (NursingApplication nursingApplication in InPatientTreatmentClinicApp.NursingApplications)
            {
                if (nursingApplication.CurrentStateDefID == NursingApplication.States.Application)
                {
                    nursingApplication.CurrentStateDefID = NursingApplication.States.PreDischarged;
                }

            }
        }

        public void UndoPreDischargeNursingAndPhysicianApplications()
        {
            //Doktor İşlemleri Geri al
            foreach (InPatientPhysicianApplication inPatientPhysicianApplication in InPatientTreatmentClinicApp.InPatientPhysicianApplication)
            {
                if (inPatientPhysicianApplication.CurrentStateDefID == InPatientPhysicianApplication.States.PreDischarged)
                {
                    inPatientPhysicianApplication.UndoByMasterAction = true;
                    ((ITTObject)inPatientPhysicianApplication).UndoLastTransition();//// Application'a gider
                }
            }
            //Hemşire İşlemleri Geri Al
            foreach (NursingApplication nursingApplication in InPatientTreatmentClinicApp.NursingApplications)
            {
                if (nursingApplication.CurrentStateDefID == NursingApplication.States.PreDischarged)
                {
                    nursingApplication.UndoByMasterAction = true;
                    ((ITTObject)nursingApplication).UndoLastTransition();// Application'a gider

                }
            }

        }




        protected void DischargeNursingAndPhysicianApplications()
        {
            //Doktor İşlemleri Taburcu Et
            foreach (InPatientPhysicianApplication inPatientPhysicianApplication in InPatientTreatmentClinicApp.InPatientPhysicianApplication)
            {
                if (inPatientPhysicianApplication.CurrentStateDefID == InPatientPhysicianApplication.States.Application || inPatientPhysicianApplication.CurrentStateDefID == InPatientPhysicianApplication.States.PreDischarged)
                {
                    inPatientPhysicianApplication.CurrentStateDefID = InPatientPhysicianApplication.States.Discharged;
                }
            }

            // Hemşire İşlemleri  Taburcu Et
            foreach (NursingApplication nursingApplication in InPatientTreatmentClinicApp.NursingApplications)
            {
                if (nursingApplication.CurrentStateDefID == NursingApplication.States.Application || nursingApplication.CurrentStateDefID == NursingApplication.States.PreDischarged)
                {
                    nursingApplication.CurrentStateDefID = NursingApplication.States.Discharged;
                }

            }
        }


        public void UndoDischargeNursingAndPhysicianApplications()
        {
            //Doktor İşlemleri Geri al
            foreach (InPatientPhysicianApplication inPatientPhysicianApplication in InPatientTreatmentClinicApp.InPatientPhysicianApplication)
            {
                if (inPatientPhysicianApplication.CurrentStateDefID == InPatientPhysicianApplication.States.Discharged)
                {
                    inPatientPhysicianApplication.UndoByMasterAction = true;
                    ((ITTObject)inPatientPhysicianApplication).UndoLastTransition();//// Application'a gider yada PreDischarged a gider
                }
            }
            // Hemşire İşlemleri Geri Al
            foreach (NursingApplication nursingApplication in InPatientTreatmentClinicApp.NursingApplications)
            {

                if (nursingApplication.CurrentStateDefID == NursingApplication.States.Discharged)
                {
                    nursingApplication.UndoByMasterAction = true;
                    ((ITTObject)nursingApplication).UndoLastTransition();///  Application'a gider yada PreDischarged a gider
                }

            }

        }



        protected void DischargeInpatientAdmission()
        {
            if (!IsTransferToOtherClinic)
            {
                if (InPatientTreatmentClinicApp.BaseInpatientAdmission is InpatientAdmission)
                {
                    if (InPatientTreatmentClinicApp.BaseInpatientAdmission.CurrentStateDefID == InpatientAdmission.States.ClinicProcedure)
                        InPatientTreatmentClinicApp.BaseInpatientAdmission.CurrentStateDefID = InpatientAdmission.States.Discharged;
                }
            }
            //else if (this.BaseInpatientAdmission is IntensiveCareAfterSurgery)
            //{
            //    if (this.BaseInpatientAdmission.CurrentStateDefID == IntensiveCareAfterSurgery.States.Procedure)
            //        this.BaseInpatientAdmission.CurrentStateDefID = IntensiveCareAfterSurgery.States.Discharged;
            //}

        }

        protected void UndoDischargeInpatientAdmission()
        {
            if (!IsTransferToOtherClinic)
            {
                if (Episode.InpatientAdmissions.FirstOrDefault(dr => dr.ObjectID != InPatientTreatmentClinicApp.BaseInpatientAdmission.ObjectID && dr.ObjectID == InpatientAdmission.States.ClinicProcedure) != null)
                {
                    throw new Exception("Bu hastanın açık Yatan işlemi bulunduığu için işlem gerçekleştirilemez");
                }
                if (InPatientTreatmentClinicApp.BaseInpatientAdmission is InpatientAdmission)
                {
                    if (InPatientTreatmentClinicApp.BaseInpatientAdmission.CurrentStateDefID == InpatientAdmission.States.Discharged)
                    {
                        ((InpatientAdmission)InPatientTreatmentClinicApp.BaseInpatientAdmission).UndoByMasterAction = true;
                        ((ITTObject)InPatientTreatmentClinicApp.BaseInpatientAdmission).UndoLastTransition();
                    }
                }
            }
        }



        public void CheckAndFireMorgue()
        {
            bool found = false;
            foreach (BaseAction action in LinkedActions)
            {
                if (action is Morgue && !action.IsCancelled)
                {
                    found = true;
                    break;
                }
            }
            if (GetMyDischargeTypeEnum() == DischargeTypeEnum.Death)
            {
                Morgue theAction = new Morgue(ObjectContext);
                theAction.ActionDate = DischargeDate;
                theAction.MasterResource = null;
                theAction.FromResource = MasterResource;
                theAction.Episode = Episode;
                // theAction.CurrentStateDefID = Morgue.States.Request;
                theAction.MasterAction = this;
                theAction.SenderDoctor = ProcedureDoctor;


                //TODO:ShowEdit!
                //Guid savePointGuid= this._TreatmentDischarge.ObjectContext.BeginSavePoint();
                //try
                //{
                //    if (found==false)
                //    {
                //        if (TTObjectClasses.SystemParameter.GetParameterValue("ISTRANSPLANT", "TRUE") == "TRUE")
                //        {
                //            Transplant transplant = new Transplant(this._TreatmentDischarge.ObjectContext);
                //            transplant.ActionDate =  Common.RecTime();
                //            transplant.MasterResource = null;
                //            transplant.FromResource = this._TreatmentDischarge.MasterResource;
                //            transplant.Episode = this._TreatmentDischarge.Episode;
                //            transplant.CurrentStateDefID = Transplant.States.Request;
                //            transplant.MasterAction=this._TreatmentDischarge;
                //            transplant.SenderDoctor = this._TreatmentDischarge.ProcedureDoctor;
                //            TTForm theForm = TTForm.GetEditForm(transplant);
                //            this.PrapareFormToShow(theForm);
                //            DialogResult dialogResult=theForm.ShowEdit(this,transplant);
                //            if(dialogResult!= DialogResult.OK)
                //            {
                //                throw new Exception(SystemMessage.GetMessage(682));
                //            }
                //        }
                //        else
                //        {
                //            Morgue theAction = new Morgue(this._TreatmentDischarge.ObjectContext);
                //            theAction.ActionDate = Common.RecTime();
                //            theAction.MasterResource = null;
                //            theAction.FromResource = this._TreatmentDischarge.MasterResource;
                //            theAction.Episode = this._TreatmentDischarge.Episode;
                //            theAction.CurrentStateDefID = Morgue.States.InRequest;
                //            theAction.MasterAction=this._TreatmentDischarge;
                //            theAction.SenderDoctor = this._TreatmentDischarge.ProcedureDoctor;
                //            TTForm theForm = TTForm.GetEditForm(theAction);
                //            this.PrapareFormToShow(theForm);
                //            DialogResult dialogResult=theForm.ShowEdit(this,theAction);
                //            if(dialogResult!= DialogResult.OK)
                //            {
                //                throw new Exception(SystemMessage.GetMessage(682));
                //            }
                //        }   

                //    }
                //}
                //catch (Exception ex)
                //{
                //    this._TreatmentDischarge.ObjectContext.RollbackSavePoint(savePointGuid);
                //    throw ex;
                //}
                var a = 1;
            }
            else
            {
                if (found)
                {
                    TTUtils.InfoMessageService.Instance.ShowMessage(TTUtils.CultureService.GetText("M26982", "Taburcu Tipi değiştirildiği için başlatılmış olan morg işlemi İptal edilecektir."));
                    foreach (BaseAction action in LinkedActions)
                    {
                        if (action is Morgue && !action.IsCancelled)
                        {
                            ((Morgue)action).CancelledByMasterAction = true;
                            ((ITTObject)action).Cancel();
                        }
                    }
                }
            }
        }

        public void CheckAndCancelMorgue()
        {
            if (GetMyDischargeTypeEnum() != DischargeTypeEnum.Death)
            {
                foreach (BaseAction action in LinkedActions)
                {
                    if (action is Morgue && !action.IsCancelled)
                    {
                        ((Morgue)action).CancelledByMasterAction = true;
                        ((ITTObject)action).Cancel();
                    }
                }
            }
        }


        public bool IsInpatientAdmissionDischarged()
        {
            if (InPatientTreatmentClinicApp != null)
            {
                if (InPatientTreatmentClinicApp.IsInpatintAdmissionDischarged())
                {
                    return true;
                }
            }
            return false;
        }

        private bool _undoNursingAndPhysicianApplications = true;  // taburcu işlemi direk iptal edilirse True olur  , Klinik işlemleri iptal olduğu için taburcu iptal edilirse false olur
        public bool UndoNursingAndPhysicianApplications
        {
            get
            {
                return _undoNursingAndPhysicianApplications;
            }
            set
            {
                _undoNursingAndPhysicianApplications = value;
            }
        }

        public bool IsToInpatientClinicAppCancelled = false;
        public override void Cancel()
        {
            var toInPatientTrtmentClinicApp = InPatientTreatmentClinicApp.GetMyActiveToInPatientTrtmentClinicApp();

            if (SubEpisode.PatientStatus == SubEpisodeStatusEnum.Inpatient)
                SubEpisode.InpatientStatus = InpatientStatusEnum.Inpatient;

            SubEpisode.ClosingDate = null;
            CheckAndCancelMorgue();

            if (UndoNursingAndPhysicianApplications == true)// taburcu işlemi direk iptal edilirse True olur  , Klinik işlemleri iptal olduğu için taburcu iptal edilirse false olur
            {
                UndoDischargeNursingAndPhysicianApplications();
                UndoDischargeInpatientAdmission();
                UndoPreDischargeNursingAndPhysicianApplications();
                UndoDischagedOrTransferInPatientTreatmentClinicApp();

                InPatientTreatmentClinicApp.TreatmentDischarge = null;
                InPatientTreatmentClinicApp.ClinicDischargeDate = null;
                if (!IsTransferToOtherClinic)
                {
                    Episode.PatientStatus = PatientStatusEnum.Inpatient;
                    ((InpatientAdmission)InPatientTreatmentClinicApp.BaseInpatientAdmission).HospitalDischargeDate = null;
                }

            }

            if (!IsToInpatientClinicAppCancelled) // IsToInpatientClinicApp zaten Cancelled oldu ise(Tanı ToInpatientClinicApp İşlemi İptal dildiği için ben iptal edliyor isem) tekrra Cancelled etme
            {
                if (toInPatientTrtmentClinicApp != null) //  Kurum içi sevk için kullanılan taburcu işlemi iptal edildiğinde sevkin yapıldığı  Klinik İşlemleri de iptal edilir
                {
                    toInPatientTrtmentClinicApp.CancelledByMasterAction = true;
                    ((ITTObject)toInPatientTrtmentClinicApp).Cancel();
                }
                if (DispatchToOtherHospital != null)
                    ((ITTObject)DispatchToOtherHospital).Cancel();
            }

            if (this.CurrentStateDefID == TreatmentDischarge.States.Cancelled)
            {
                string filterExpression = "AND INPATIENTPROTOCOLNO='" + this.SubEpisode.ProtocolNo.ToString() + "' AND EPISODEGUID='" + this.Episode.ObjectID.ToString() + "' AND CANCELLED=0 ";
                var tigEpisodeList = TigEpisode.TigEpisodeNQL(filterExpression).ToList();

                if (tigEpisodeList.Count > 0)
                {
                    foreach (var tigEpisode in tigEpisodeList)
                    {
                        TigEpisode tigEpisodeItem = this.ObjectContext.GetObject<TigEpisode>((Guid)tigEpisode.ObjectID);
                        tigEpisodeItem.Cancelled = true;
                    }
                }

            }

            base.Cancel();
        }

        private bool _undoByMasterAction = false;
        public bool UndoByMasterAction
        {
            get
            {
                return _undoByMasterAction;
            }
            set
            {
                _undoByMasterAction = value;
            }
        }

        public void CheckUndo()
        {
            if (!UndoByMasterAction)
            {
                string msg = "Hemşirelik İşlemleri tek başına geri alınamaz ";
                throw new Exception(msg);
            }
        }


        // transaction Reporttan alınacak
        public void PrintTreatmentDischargeReport()
        {
            //            NumberOfCopiesGrid nOC = this.GetNumberOfCopisGridFromDefinition();
            //            if(nOC!=null){
            //                if( nOC.AutoPrint==true){
            //                    Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
            //                    TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
            //                    objectID.Add("VALUE", this.ObjectID.ToString());
            //                    parameters.Add("TTOBJECTID",objectID);
            //                    int copy=(int)this.NumberOfCopies;
            //                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_TreatmentDischargeReport),true, copy, parameters);
            //                }
            //            }
        }

        //        public bool IsTreatmentDiagnosisCloseEpisode()
        //        {
        //            if(IsTransferToOtherClinic)
        //                return false;
        //            if(this.Episode.InpatientAdmissions.Count > 0) // episodeda yatış varsa Acil ve derleme işlemlerinin tedavi sonucu Episodu kapatmaz
        //            {
        //                if(this.InPatientPhysicianApplication != null)
        //                {
        //                    if(this.InPatientPhysicianApplication.EmergencyIntervention != null)//Acil
        //                        return false;
        //                    if(this.InPatientPhysicianApplication.InPatientTreatmentClinicApp != null)
        //                    {
        //                        if(this.InPatientPhysicianApplication.InPatientTreatmentClinicApp.BaseInpatientAdmission is IntensiveCareAfterSurgery) // derlenme
        //                            return false;
        //                    }
        //                }
        //            }
        //            return true;
        //        }

        public DischargeTypeEnum GetMyDischargeTypeEnum()
        {
            if (DischargeType.SKRSCikisSekli == null)
                return DischargeTypeEnum.Other;
            if (!TTObjectDefManager.Instance.DataTypes[typeof(DischargeTypeEnum).Name].EnumValueDefs.ContainsKey(Convert.ToInt32(DischargeType.SKRSCikisSekli.KODU.ToString())))
                return DischargeTypeEnum.Other;
            var dischargeTypeEnum = TTObjectDefManager.Instance.DataTypes[typeof(DischargeTypeEnum).Name].EnumValueDefs[Convert.ToInt32(DischargeType.SKRSCikisSekli.KODU.ToString())];
            if (dischargeTypeEnum == null)
                return DischargeTypeEnum.Other;
            return (DischargeTypeEnum)dischargeTypeEnum.Value;
        }



        protected override List<EpisodeAction.OldActionPropertyObject> OldActionPropertyList()
        {
            List<EpisodeAction.OldActionPropertyObject> propertyList = base.OldActionPropertyList();
            if (propertyList == null)
                propertyList = new List<EpisodeAction.OldActionPropertyObject>();

            propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M20566", "Protokol No"), Common.ReturnObjectAsString(ProtocolNo)));
            if (ProcedureDoctor != null)
                propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M27077", "Tedavi Kararını Yazan Doktor"), Common.ReturnObjectAsString(ProcedureDoctor)));
            //            propertyList.Add(new OldActionPropertyObject("Tedavi Tipi",Common.ReturnObjectAsString(GssQueryType)));
            //            propertyList.Add(new OldActionPropertyObject("Taburcu Tipi",Common.ReturnObjectAsString(DischargeType)));
            //            propertyList.Add(new OldActionPropertyObject("Taburcu Gidiş Yeri",Common.ReturnObjectAsString(DischargeToPlace)));
            //            if(HospitalSendingTo!=null)
            //                propertyList.Add(new OldActionPropertyObject("Gönderilen Yer",Common.ReturnObjectAsString(HospitalSendingTo.Name)));
            //            propertyList.Add(new OldActionPropertyObject("Önerilen Taburcu Tarihi",Common.ReturnObjectAsString(DischargeDate)));
            //            propertyList.Add(new OldActionPropertyObject("Karar Tarihi",Common.ReturnObjectAsString(RequestDate)));
            //            propertyList.Add(new OldActionPropertyObject("Karar ",Common.ReturnObjectAsString(Conclusion)));


            return propertyList;
        }

        //Post

        //


        //public void CheckForensicMedicalReport()
        //{
        //    //todo bg
        //    /*
        //    if(this.SubEpisode.PatientAdmission.AdmissionType == AdmissionTypeEnum.JudicialObservation)
        //    {
        //        if(this.Episode.ForensicMedicalReports.Count==0)
        //            throw new Exception(SystemMessage.GetMessage(677));
        //    }*/
        //}

        #endregion  Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(TreatmentDischarge).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == TreatmentDischarge.States.New && toState == TreatmentDischarge.States.PreDischarge)
                PreTransition_New2PreDischarge();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(TreatmentDischarge).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == TreatmentDischarge.States.New && toState == TreatmentDischarge.States.PreDischarge)
                PostTransition_New2PreDischarge();
            else if (fromState == TreatmentDischarge.States.PreDischarge && toState == TreatmentDischarge.States.Discharged)
                PostTransition_PreDischarge2Discharged();
            else if (fromState == TreatmentDischarge.States.New && toState == TreatmentDischarge.States.Cancelled)
                PostTransition_New2Cancelled();
            else if (fromState == TreatmentDischarge.States.PreDischarge && toState == TreatmentDischarge.States.Cancelled)
                PostTransition_PreDischarge2Cancelled();
            else if (fromState == TreatmentDischarge.States.Discharged && toState == TreatmentDischarge.States.Cancelled)
                PostTransition_Discharged2Cancelled();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(TreatmentDischarge).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == TreatmentDischarge.States.New && toState == TreatmentDischarge.States.PreDischarge)
                UndoTransition_New2PreDischarge(transDef);
            else if (fromState == TreatmentDischarge.States.PreDischarge && toState == TreatmentDischarge.States.Discharged)
                UndoTransition_PreDischarge2Discharged(transDef);
            else if (fromState == TreatmentDischarge.States.New && toState == TreatmentDischarge.States.Cancelled)
                UndoTransition_New2Cancelled(transDef);
            else if (fromState == TreatmentDischarge.States.PreDischarge && toState == TreatmentDischarge.States.Cancelled)
                UndoTransition_PreDischarge2Cancelled(transDef);
            else if (fromState == TreatmentDischarge.States.Discharged && toState == TreatmentDischarge.States.Cancelled)
                UndoTransition_Discharged2Cancelled(transDef);

        }


        public bool HasEpicrisis()
        {
            // Boolean epicrisisFound = false;
            if (SubEpisode.InPatientPhysicianProgresses.Count > 0)
                return true;

            // Hasta Özgeçmişleri önceki Subepisodedan koyalandığı epikriz yazılmışmı kontrolünden çıkarıldı
            //if (!epicrisisFound)
            //{
            //    foreach (var inPatientTreatmentClinicApplication in treatmentDischarge.SubEpisode.InPatientTreatmentClinicApplications)
            //    {
            //        if (inPatientTreatmentClinicApplication.InPatientPhysicianApplication.Count() > 0)
            //        {
            //            var inPatientPhysicianApplication = inPatientTreatmentClinicApplication.InPatientPhysicianApplication[0];
            //            if (inPatientPhysicianApplication.Complaint != null && !String.IsNullOrEmpty(Common.GetTextOfRTFString(inPatientPhysicianApplication.Complaint.ToString())))
            //                return  true;
            //            else if (inPatientPhysicianApplication.PhysicalExamination != null && !String.IsNullOrEmpty(Common.GetTextOfRTFString(inPatientPhysicianApplication.PhysicalExamination.ToString())))
            //                return true;
            //            else if (inPatientPhysicianApplication.PatientStory != null && !String.IsNullOrEmpty(Common.GetTextOfRTFString(inPatientPhysicianApplication.PatientStory.ToString())))
            //                return true;
            //        }
            //    }
            //}

            foreach (var InPatientRtfBySpeciality in SubEpisode.InPatientRtfBySpecialities)
            {
                if (InPatientRtfBySpeciality.RTFDefinitionsBySpeciality.IsNeedForEpicrisis == true)
                {
                    if (InPatientRtfBySpeciality.Rtf != null && !String.IsNullOrEmpty(Common.GetTextOfRTFString(InPatientRtfBySpeciality.Rtf.ToString())))
                        return true;
                }
            }

            return false;
        }


        public bool CheckDatesByDischargeDate()// #TABURCULUK Taburcu tarihinden sonra Girilmiş Hizmet ve Orderlar için hata verip Taburculuğu engelleyen kod
        {
            if (DischargeDate != null)
            {
                // SubactionPropcedure
                string msg = string.Empty;
                string msgProc = string.Empty;
                int errcount = 0;
                foreach (var subActionProcedure in SubEpisode.SubActionProcedures)
                {
                    if (subActionProcedure.CheckSubepisodeClosingDate())
                    {
                        if (subActionProcedure.CurrentStateDef.Status != StateStatusEnum.Cancelled && subActionProcedure.CurrentStateDef.Status != StateStatusEnum.CompletedUnsuccessfully && !(subActionProcedure is NursingOrderDetail) && !(subActionProcedure is BaseBedProcedure) && !(subActionProcedure is BedProcedure))// Yatak hizmetleri state geçişi sırasında düzenlenir
                        {

                            var creationDate = subActionProcedure.CreationDate;
                            // Eski veriler patlamasın diye daha sonra silinebilir 
                            if (creationDate == null)
                                creationDate = subActionProcedure.ActionDate;
                            if (creationDate.Value.Date > DischargeDate.Value.Date)
                            {
                                if (errcount > 3)
                                {
                                    msgProc = msgProc + "...";
                                    break;
                                }
                                msgProc = msgProc + "\n" + subActionProcedure.CreationDate.ToString() + "-" + subActionProcedure.ProcedureObject.Name;
                                errcount++;
                            }
                        }
                    }
                }

                if (!string.IsNullOrEmpty(msgProc))
                {
                    msg = msg + "Seçilen taburcu tarihinden sonra gerçekleştirilmiş işlemler mevcuttur .   " + msgProc + "\n";
                }

                // TratmentMaterial
                string msgTreatmentMat = string.Empty;
                errcount = 0;
                foreach (var episodeAction in SubEpisode.EpisodeActions)
                {
                    if (episodeAction.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                    {
                        foreach (var treatmentMaterial in episodeAction.TreatmentMaterials)
                        {
                            if (treatmentMaterial.CurrentStateDef.Status != StateStatusEnum.Cancelled && treatmentMaterial.ActionDate.Value.Date > DischargeDate.Value.Date)
                            {
                                if (errcount > 3)
                                {
                                    msgTreatmentMat = msgTreatmentMat + "...";
                                    break;
                                }
                                msgTreatmentMat = msgTreatmentMat + "\n" + treatmentMaterial.ActionDate.ToString() + "-" + treatmentMaterial.Material.Name;
                                errcount++;
                            }
                        }
                    }
                }
                if (!string.IsNullOrEmpty(msgTreatmentMat))
                {
                    msg = msg + "Seçilen taburcu tarihinden sonra girilmiş  sarflar mevcuttur .   " + msgTreatmentMat + "\n";
                }

                // NursingOrder and  DrugOrder

                string msgNursingOrder = string.Empty;
                string msgDrugOrder = string.Empty;
                string msgDrugOrderSupply = string.Empty;
                foreach (var nursingApp in SubEpisode.NursingApplications)
                {
                    if (nursingApp.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                    {
                        errcount = 0;
                        foreach (var nursingOrderDetail in nursingApp.NursingApplicationNursingOrderDetails)
                        {
                            if (nursingOrderDetail.CurrentStateDefID == NursingOrderDetail.States.Completed && nursingOrderDetail.WorkListDate.Value.Date > DischargeDate.Value.Date)
                            {
                                if (errcount > 3)
                                {
                                    msgNursingOrder = msgNursingOrder + "...";
                                    break;
                                }

                                msgNursingOrder = msgNursingOrder + "\n" + nursingOrderDetail.WorkListDate.ToString() + "-" + nursingOrderDetail.ProcedureObject.Name;
                                errcount++;
                            }

                        }
                        errcount = 0;
                        var errSupplycount = 0;
                        foreach (var drugOrderDetail in nursingApp.DrugOrderDetails)
                        {
                            if (drugOrderDetail.OrderPlannedDate != null)
                            {
                                if (drugOrderDetail.OrderPlannedDate.Value.Date > DischargeDate.Value.Date)
                                {
                                    if ((drugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.Apply || drugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.PatientDelivery))
                                    {
                                        if (errcount > 3)
                                        {
                                            msgDrugOrder = msgDrugOrder + "...";
                                            break;
                                        }
                                        msgDrugOrder = msgDrugOrder + "\n" + drugOrderDetail.OrderPlannedDate.ToString() + "-" + drugOrderDetail.Material.Name;
                                        errcount++;
                                    }
                                    //53015 
                                    //if ((drugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.Supply) || (drugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.UseRestDose && drugOrderDetail.DrugOrder.PatientOwnDrug != true))
                                    //{

                                    //    if (errSupplycount > 3)
                                    //    {
                                    //        msgDrugOrderSupply = msgDrugOrderSupply + "...";
                                    //        break;
                                    //    }
                                    //    msgDrugOrderSupply = msgDrugOrderSupply + "\n" + drugOrderDetail.OrderPlannedDate.ToString() + "-" + drugOrderDetail.Material.Name;
                                    //    errSupplycount++;
                                    //}
                                }
                            }
                        }
                    }
                }
                if (!string.IsNullOrEmpty(msgNursingOrder))
                {
                    msg = msg + "Seçilen taburcu tarihinden sonra uygulanmış  Hemşire direktifleri  mevcuttur .   " + msgNursingOrder + "\n";
                }

                // DrugOrder
                if (!string.IsNullOrEmpty(msgDrugOrder))
                {
                    msg = msg + "Seçilen taburcu tarihinden sonra Uygulanmamış ilaçları bulunmaktadır. Hastaya ya da Eczaneye İade edilmesi gerekmektedir." + msgDrugOrder + "\n";
                }
                // DrugOrder
                if (!string.IsNullOrEmpty(msgDrugOrderSupply))
                {
                    msg = msg + "Seçilen taburcu tarihinden sonra Planlanmış ve Eczaneden Karşılanmış İlaç Orderları  mevcuttur .  " + msgDrugOrderSupply + "\n";
                }

                //---
                if (!string.IsNullOrEmpty(msg))
                {
                    throw new Exception(TTUtils.CultureService.GetText("M25800", "Hasta Taburcu Edilemez! ") + msg);
                }
            }

            return true;
        }

        public void CheckDischargeLimit()
        {
            int? predischageLimit = null;
            if (TTObjectClasses.SystemParameter.GetParameterValue("GETPREDISCHAGERLIMITBYPROCEDUREDOCTOR", "FALSE") == "TRUE")
            {
                predischageLimit = ProcedureDoctor.PreDischargeLimit;
                if (predischageLimit != null)
                {
                    var preDischargedInfoByProcedureDoctorList = TreatmentDischarge.GetPreDischargedInfoByProcedureDoctor(ProcedureDoctor.ObjectID);
                    if (preDischargedInfoByProcedureDoctorList.Count > predischageLimit)
                    {
                        string msg = "";
                        foreach (var preDischargedInfoByProcedureDoctor in preDischargedInfoByProcedureDoctorList)
                        {
                            msg += "\n" + preDischargedInfoByProcedureDoctor.Patientname;
                        }

                        throw new Exception(TTUtils.CultureService.GetText("M26984", "Taburcuya Karar Veren Tabip için Ön Taburcu limiti dolmuştur .Ön taburcu yapabilmek için  aşağıdaki hastalardan  en az birini taburcu etmelisiniz.") + msg);
                    }
                }
            }
            else
            {
                if (MasterResource is ResClinic)
                {
                    predischageLimit = ((ResClinic)MasterResource).PreDischargeLimit;
                    if (predischageLimit != null)
                    {
                        var preDischargedInfoByClinicList = TreatmentDischarge.GetPreDischargedInfoByClinic(MasterResource.ObjectID);
                        if (preDischargedInfoByClinicList.Count > predischageLimit)
                        {
                            string msg = "";
                            foreach (var preDischargedInfoByClinic in preDischargedInfoByClinicList)
                            {
                                msg += "\n" + preDischargedInfoByClinic.Patientname;
                            }

                            throw new Exception(TTUtils.CultureService.GetText("M27078", "Tedavi Kliniği için Ön Taburcu limiti dolmuştur .Ön taburcu yapabilmek için  aşağıdaki hastalardan  en az birini taburcu etmelisiniz.") + msg);
                        }
                    }
                }
            }
        }


        // WebApilerdede kullanılabilmesi için TreatmentDischargeFormViewModel 'den buraya  classına taşındı

        public bool IsAllRequiredProblemsOk(List<TreatmentDischarge.TreatmentDischargeProblemViewModel> treatmentDischargeProblemList)
        {
            foreach (var problem in treatmentDischargeProblemList)
            {
                if (problem.IsRequired && !problem.IsOk)
                    return false;
            }

            return true;
        }

        public List<TreatmentDischarge.TreatmentDischargeProblemViewModel> CheckProblemsAndAddToViewModel()
        {
            var treatmentDischargeProblemList = new List<TreatmentDischarge.TreatmentDischargeProblemViewModel>();
            AddEpicrisProblemToViewModel(treatmentDischargeProblemList);
            AddSecDiagnoseProblemToViewModel(treatmentDischargeProblemList);
            AddSurgeryReportProblemToViewModel(treatmentDischargeProblemList);
            AddDischargingInstructionPlansProblemToViewModel(treatmentDischargeProblemList);
            AddDepositMaterialProblemToViewModel(treatmentDischargeProblemList);
            // this.AddControlAppointmentProblemToViewModel(treatmentDischargeProblemList, treatmentDischarge);
            AddDrugOrderProblemToViewModel(treatmentDischargeProblemList);
            AddPhysiotherapyProblemToViewModel(treatmentDischargeProblemList);

            AddWaitingPharmacyDrugOrderProblemToViewModel(treatmentDischargeProblemList);

            //Yoğun Bakım Hastası ise taburculuk için en az 1 apache, 1 glaskow girmiş olması zorunlu kontrolü eklenmeli
            if (InPatientTreatmentClinicApp != null && ((ResWard)InPatientTreatmentClinicApp.MasterResource).IsIntensiveCare == true)
            {
                AddIntensiveCareProblemToViewModel(treatmentDischargeProblemList);
            }
            return treatmentDischargeProblemList;
        }

        // TreatmentDischargeProblemList oluşturacak Methodlar
        public void AddEpicrisProblemToViewModel(List<TreatmentDischarge.TreatmentDischargeProblemViewModel> TreatmentDischargeProblemList)
        {
            Boolean epicrisisFound = HasEpicrisis();

            TreatmentDischarge.TreatmentDischargeProblemViewModel problemViewModel = new TreatmentDischarge.TreatmentDischargeProblemViewModel();
            problemViewModel.IsRequired = true;
            if (epicrisisFound)
            {
                problemViewModel.ProblemString = TTUtils.CultureService.GetText("M25591", "Epikriz Var");
                problemViewModel.IsOk = true;
            }
            else
            {
                problemViewModel.ProblemString = (SubEpisode.Speciality == null ? "" : SubEpisode.Speciality.Name) + " uzmanlık dalı için epikriz yazılmamıştır.";
                problemViewModel.IsOk = false;
                var inPatientPhysicianApplication = InPatientTreatmentClinicApp.InPatientPhysicianApplication[0];
                problemViewModel.ObjectId = inPatientPhysicianApplication.ObjectID;
                problemViewModel.ObjectDefName = inPatientPhysicianApplication.ObjectDef.Name;
            }

            TreatmentDischargeProblemList.Add(problemViewModel);
        }

        public void AddIntensiveCareProblemToViewModel(List<TreatmentDischarge.TreatmentDischargeProblemViewModel> TreatmentDischargeProblemList)
        {
            TreatmentDischarge.TreatmentDischargeProblemViewModel problemViewModel = new TreatmentDischarge.TreatmentDischargeProblemViewModel();
            problemViewModel.IsRequired = true;
            var inPatientPhysicianApplication = InPatientTreatmentClinicApp.InPatientPhysicianApplication[0];
            IntensiveCareSpecialityObj _intensiveCareSpecialityObj = new IntensiveCareSpecialityObj();
            IntensiveCareTypeEnum IntensiveCareType = _intensiveCareSpecialityObj.SetIntensiveCareType(inPatientPhysicianApplication.Episode.Patient);
            if (IntensiveCareType == IntensiveCareTypeEnum.AdultIntensiveCare)
            {
                if (inPatientPhysicianApplication.ApacheScores != null && inPatientPhysicianApplication.ApacheScores.Count > 0 &&
                    inPatientPhysicianApplication.GlaskowScores != null && inPatientPhysicianApplication.GlaskowScores.Count > 0)
                {
                    problemViewModel.ProblemString = "Apache/Glaskow Skoru Var";
                    problemViewModel.IsOk = true;
                }
                else
                {
                    problemViewModel.ProblemString = "Yoğun Bakım Apache/Glaskow Skorlaması yapılmamıştır.";
                    problemViewModel.IsOk = false;
                    problemViewModel.ObjectId = inPatientPhysicianApplication.ObjectID;
                    problemViewModel.ObjectDefName = inPatientPhysicianApplication.ObjectDef.Name;
                }
            }
            else if (IntensiveCareType == IntensiveCareTypeEnum.NewBornIntensiveCare)
            {
                if (inPatientPhysicianApplication.SnappeScores != null && inPatientPhysicianApplication.SnappeScores.Count > 0)
                {
                    problemViewModel.ProblemString = "Snappe II Skoru Var";
                    problemViewModel.IsOk = true;
                }
                else
                {
                    problemViewModel.ProblemString = "Yoğun Bakım Snappe II Skorlaması yapılmamıştır.";
                    problemViewModel.IsOk = false;
                    problemViewModel.ObjectId = inPatientPhysicianApplication.ObjectID;
                    problemViewModel.ObjectDefName = inPatientPhysicianApplication.ObjectDef.Name;
                }
            }
            else if (IntensiveCareType == IntensiveCareTypeEnum.ChildIntensiveCare)
            {
                if (inPatientPhysicianApplication.Prisms != null && inPatientPhysicianApplication.Prisms.Count > 0 &&
                    inPatientPhysicianApplication.GlaskowScores != null && inPatientPhysicianApplication.GlaskowScores.Count > 0)
                {
                    problemViewModel.ProblemString = "Prisms/Glaskow Skoru Var";
                    problemViewModel.IsOk = true;
                }
                else
                {
                    problemViewModel.ProblemString = "Yoğun Bakım Prisms/Glaskow Skorlaması yapılmamıştır.";
                    problemViewModel.IsOk = false;
                    problemViewModel.ObjectId = inPatientPhysicianApplication.ObjectID;
                    problemViewModel.ObjectDefName = inPatientPhysicianApplication.ObjectDef.Name;
                }
            }

            TreatmentDischargeProblemList.Add(problemViewModel);
        }

        public void AddSecDiagnoseProblemToViewModel(List<TreatmentDischarge.TreatmentDischargeProblemViewModel> TreatmentDischargeProblemList)
        {
            TreatmentDischarge.TreatmentDischargeProblemViewModel problemViewModel = new TreatmentDischarge.TreatmentDischargeProblemViewModel();
            problemViewModel.IsRequired = true;
            if (Episode.SecDiagnosis.Count == 0)
            {
                problemViewModel.ProblemString = TTUtils.CultureService.GetText("M26296", "Kesin Tanı girişi yapılmamıştır");
                problemViewModel.IsOk = false;
                var inPatientPhysicianApplication = InPatientTreatmentClinicApp.InPatientPhysicianApplication[0];
                problemViewModel.ObjectId = inPatientPhysicianApplication.ObjectID;
                problemViewModel.ObjectDefName = inPatientPhysicianApplication.ObjectDef.Name;
            }
            else
            {
                problemViewModel.ProblemString = TTUtils.CultureService.GetText("M26297", "Kesin Tanı girişi yapılmıştır");
                problemViewModel.IsOk = true;
            }

            TreatmentDischargeProblemList.Add(problemViewModel);
        }

        public void AddDischargingInstructionPlansProblemToViewModel(List<TreatmentDischarge.TreatmentDischargeProblemViewModel> TreatmentDischargeProblemList)
        {
            TreatmentDischarge.TreatmentDischargeProblemViewModel problemViewModel = new TreatmentDischarge.TreatmentDischargeProblemViewModel();
            problemViewModel.IsRequired = false;
            if (InPatientTreatmentClinicApp.NursingApplications[0].BaseNursingDischargingInstructionPlans.Count == 0)
            {
                problemViewModel.ProblemString = TTUtils.CultureService.GetText("M25887", "Hastaya Taburculuk Planlama Yapılmamış");
                problemViewModel.IsOk = false;
                var nursingApplications = InPatientTreatmentClinicApp.NursingApplications[0];
                problemViewModel.ObjectId = nursingApplications.ObjectID;
                problemViewModel.ObjectDefName = nursingApplications.ObjectDef.Name;
            }
            else
            {
                problemViewModel.ProblemString = TTUtils.CultureService.GetText("M25888", "Hastaya Taburculuk Planlama Yapılmamıştır");
                problemViewModel.IsOk = true;
            }

            TreatmentDischargeProblemList.Add(problemViewModel);
        }

        public void AddSurgeryReportProblemToViewModel(List<TreatmentDischarge.TreatmentDischargeProblemViewModel> TreatmentDischargeProblemList)
        {
            foreach (Surgery surgery in SubEpisode.Surgeries)
            {
                if (surgery.CurrentStateDefID == Surgery.States.Surgery || surgery.CurrentStateDefID == Surgery.States.SurgeryRequest)
                {
                    TreatmentDischarge.TreatmentDischargeProblemViewModel problemViewModel = new TreatmentDischarge.TreatmentDischargeProblemViewModel();
                    problemViewModel.IsRequired = true;
                    problemViewModel.ProblemString = surgery.ID.ToString() + "' işlem no'lu ameliyat işlemi '" + surgery.CurrentStateDef.DisplayText + "' adımında kalmıştır";
                    problemViewModel.IsOk = false;
                    problemViewModel.ObjectId = surgery.ObjectID;
                    problemViewModel.ObjectDefName = surgery.ObjectDef.Name;
                    TreatmentDischargeProblemList.Add(problemViewModel);
                }
                foreach (SubSurgery subSurgery in surgery.SubSurgeries)
                {
                    if (subSurgery.CurrentStateDefID == SubSurgery.States.SubSurgeryReport)
                    {
                        TreatmentDischarge.TreatmentDischargeProblemViewModel problemViewModel = new TreatmentDischarge.TreatmentDischargeProblemViewModel();
                        problemViewModel.IsRequired = true;
                        problemViewModel.ProblemString = subSurgery.ID.ToString() + "' işlem no'lu ek ameliyat işlemi '" + subSurgery.CurrentStateDef.DisplayText + "' adımında kalmıştır";
                        problemViewModel.IsOk = false;
                        problemViewModel.ObjectId = subSurgery.ObjectID;
                        problemViewModel.ObjectDefName = subSurgery.ObjectDef.Name;
                        TreatmentDischargeProblemList.Add(problemViewModel);
                    }
                }
            }
        }

        public void AddControlAppointmentProblemToViewModel(List<TreatmentDischarge.TreatmentDischargeProblemViewModel> TreatmentDischargeProblemList)
        {
            TreatmentDischarge.TreatmentDischargeProblemViewModel problemViewModel = new TreatmentDischarge.TreatmentDischargeProblemViewModel();
            problemViewModel.IsRequired = false;
            if (!(GetMyDischargeTypeEnum() == DischargeTypeEnum.TransferToOtherClinic))
            {
                var appointmentList = AdmissionAppointment.GetActiveAppointmentByPatientAndSpeciality(ObjectContext, Episode.Patient.ObjectID, ProcedureSpeciality.ObjectID);
                if (appointmentList.Count == 0)
                {
                    problemViewModel.ProblemString = TTUtils.CultureService.GetText("M26335", "Kontrol Randevusu Planlanmamış");
                    problemViewModel.IsOk = false;
                    //problemViewModel.ObjectId = 
                    //problemViewModel.ObjectDefName = 
                }
                else
                {
                    problemViewModel.ProblemString = TTUtils.CultureService.GetText("M26336", "Kontrol Randevusu Planlanmış");
                    problemViewModel.IsOk = true;
                }
            }
        }

        public void AddDepositMaterialProblemToViewModel(List<TreatmentDischarge.TreatmentDischargeProblemViewModel> TreatmentDischargeProblemList)
        {
            TreatmentDischarge.TreatmentDischargeProblemViewModel problemViewModel = new TreatmentDischarge.TreatmentDischargeProblemViewModel();
            problemViewModel.IsRequired = false;
            //var GivenMsg = Episode.GivenValuableMaterialsMsg(treatmentDischarge.Episode);
            //var TakenMsg = Episode.TakenValuableMaterialsMsg(treatmentDischarge.Episode);
            //string msg = string.Empty;
            //if (!string.IsNullOrEmpty(GivenMsg))
            //    msg += "Hastaya Geri Verilmemiş Eşyalar";
            //if (!string.IsNullOrEmpty(TakenMsg))
            //{
            //    if (!string.IsNullOrEmpty(msg))
            //        msg += " ve ";
            //    msg += "Hastaya Fazladan Verilmiş Eşyalar";
            //}
            var esya_miktar = 0;
            foreach (var inpatientAdmissionDepositMaterial in Episode.InpatientAdmissionDepositMaterials)
            {
                if (inpatientAdmissionDepositMaterial.QuarantineProcessType == QuarantineProcessTypeEnum.GivedToPatient)
                    esya_miktar--;
                else //
                    esya_miktar++;
            }

            if (esya_miktar > 0)
            {
                string msg = " Hastanın emanete bıraktığı eşyalar mevcuttur.";
                problemViewModel.ProblemString = msg;
                problemViewModel.IsOk = false;
                var inPatientTreatmentClinicApp = InPatientTreatmentClinicApp;
                problemViewModel.ObjectId = inPatientTreatmentClinicApp.ObjectID;
                problemViewModel.ObjectDefName = inPatientTreatmentClinicApp.ObjectDef.Name;
                TreatmentDischargeProblemList.Add(problemViewModel);
            }
        }

        public void AddDrugOrderProblemToViewModel(List<TreatmentDischarge.TreatmentDischargeProblemViewModel> TreatmentDischargeProblemList)
        {
            //GetReturnDetails details = DrugReturnAction.GetReturnableDrugsOnPatient(Episode.ObjectID);// Changed By Murat Date : 30/05/2018

            CheckPatientDrugOrderTransaction details = DrugReturnAction.GetNewReturnableDrugsOnPatient(SubEpisode.ObjectID,DischargeDate);
            TreatmentDischarge.TreatmentDischargeProblemViewModel problemViewModel = new TreatmentDischarge.TreatmentDischargeProblemViewModel();
            problemViewModel.IsRequired = true;
            if (details.isDischarge == false)
            {
                problemViewModel.ProblemString = TTUtils.CultureService.GetText("M25858", "Hastanın Üzerinde Uygulanmamış İlaç Bulunmaktadır.");
                problemViewModel.IsOk = false;
                var nursingApplications = InPatientTreatmentClinicApp.NursingApplications[0];
                problemViewModel.ObjectId = nursingApplications.ObjectID;
                problemViewModel.ObjectDefName = nursingApplications.ObjectDef.Name;
                problemViewModel.problemDrugOrders = details.returnableDrugOrdes.Where(x=> x.isTransferable == true).ToList();
            }
            else
            {
                problemViewModel.ProblemString = "Hastanın Uygulanmamış İlaçı Bulunmamaktadır.";
                problemViewModel.IsOk = true;
                problemViewModel.problemDrugOrders = details.returnableDrugOrdes.Where(x => x.isTransferable == true).ToList();
            }

            TreatmentDischargeProblemList.Add(problemViewModel);
        }

        public void AddWaitingPharmacyDrugOrderProblemToViewModel(List<TreatmentDischarge.TreatmentDischargeProblemViewModel> TreatmentDischargeProblemList)
        {

            TTObjectContext context = new TTObjectContext(true);
            IBindingList waitingKschedules = context.QueryObjects("KSCHEDULE", " EPISODE = " + TTConnectionManager.ConnectionManager.GuidToString(Episode.ObjectID) + " AND CURRENTSTATEDEFID = STATES.REQUESTPREPARATION");
            TreatmentDischarge.TreatmentDischargeProblemViewModel problemViewModel = new TreatmentDischarge.TreatmentDischargeProblemViewModel();
            problemViewModel.IsRequired = true;

            if (waitingKschedules.Count > 0)
            {
                string waitingKSID = "";
                foreach (var item in waitingKschedules)
                {
                    waitingKSID += ((KSchedule)item).StockActionID.ToString() + ",";
                }

                problemViewModel.ProblemString = "Hastanın Eczanede Bekleyen İşlemleri Bulunmaktadır. İşlem Numaraları : " + waitingKSID.Substring(0, waitingKSID.Length - 1);
                problemViewModel.IsOk = false;
                //problemViewModel.ObjectId = nursingApplications.ObjectID;
                //problemViewModel.ObjectDefName = nursingApplications.ObjectDef.Name;
            }
            else
            {
                problemViewModel.ProblemString = "Hastanın Eczanede Bekleyen İşlemleri Bulunmamaktadır.";
                problemViewModel.IsOk = true;
            }

            TreatmentDischargeProblemList.Add(problemViewModel);
        }







        public void AddPhysiotherapyProblemToViewModel(List<TreatmentDischarge.TreatmentDischargeProblemViewModel> TreatmentDischargeProblemList)
        {
            TreatmentDischarge.TreatmentDischargeProblemViewModel problemViewModel = new TreatmentDischarge.TreatmentDischargeProblemViewModel();

            //Tamamlanmamış FTR istekleri
            var uncompletedPhysiotherapyRequest = Episode.PhysiotherapyRequests.Where(dr => dr.CurrentStateDef.Status == StateStatusEnum.Uncompleted);

            //Tamamlanmamış FTR istekleri arasında bu yatıştan başlatılmış olanlar var ise taburcu olması engellenecek, eğer başka action'dan başlatılmış ise sadece uyarı verilecek
            var uncompletedRequest = uncompletedPhysiotherapyRequest.Where(c => c.SubEpisode.StarterEpisodeAction == InPatientTreatmentClinicApp);
            if (uncompletedRequest.Count() > 0)//Bu yatıştan başlatılmış tamamlanmamış FTR isteği varsa tamamlanması zorunlu olacak
            {
                problemViewModel.IsRequired = false;//bugün ve öncesine ait uygulama aşamasında ftr işlemi var ise ftr tedavisi bulunmaktadır uyarısı devam edecek zorunlu olacak. yoksa zorunluluk kalkacak bilgilendirme verilecek.
            }
            //else
            //{
            //    var uncompletedOldPhysiotherapyRequest = this.Episode.PhysiotherapyRequests.
            //                                                                Where(c => c.SubEpisode.StarterEpisodeAction == this.InPatientTreatmentClinicApp).
            //                                                                Any(x => x.PhysiotherapyOrderDetails.Where(c => c.CurrentStateDefID == PhysiotherapyOrderDetail.States.Execution && c.PlannedDate.Value.Date <= dateNow.Date).Count() > 0);
            //    if (uncompletedOldPhysiotherapyRequest)//Bu yatıştan başlatılmış ve tamamlanmış FTR istek içerisinde tamamlanmamış işlem varsa tamamlanması zorunlu olacak 
            //    {
            //        problemViewModel.IsRequired = true;
            //    }
            //}

            if (uncompletedRequest != null && uncompletedRequest.Count() > 0)
            {
                problemViewModel.ProblemString = "Hastanın '" + uncompletedRequest.FirstOrDefault().CurrentStateDef.DisplayText + "' adımında  FTR Tedavisi bulunmaktadır.";
                problemViewModel.IsOk = false;
                problemViewModel.ObjectId = uncompletedRequest.FirstOrDefault().ObjectID;
                problemViewModel.ObjectDefName = uncompletedRequest.FirstOrDefault().ObjectDef.Name;
            }
            else if (uncompletedPhysiotherapyRequest != null && uncompletedPhysiotherapyRequest.Count() > 0)
            {
                problemViewModel.ProblemString = "Hastanın '" + uncompletedPhysiotherapyRequest.FirstOrDefault().CurrentStateDef.DisplayText + "' adımında  FTR Tedavisi bulunmaktadır.";
                problemViewModel.IsOk = false;
                problemViewModel.ObjectId = uncompletedPhysiotherapyRequest.FirstOrDefault().ObjectID;
                problemViewModel.ObjectDefName = uncompletedPhysiotherapyRequest.FirstOrDefault().ObjectDef.Name;
            }
            else
            {
                problemViewModel.ProblemString = TTUtils.CultureService.GetText("M30114", "Hastanın devam eden FTR Tedavisi yoktur");
                problemViewModel.IsOk = true;
            }

            TreatmentDischargeProblemList.Add(problemViewModel);
        }


        //public void AddUnCompletedProcedureProblemToViewModel(List<TreatmentDischargeProblemViewModel> TreatmentDischargeProblemList) 
        //{
        //    BindingList<AccountTransaction.GetToBeNewTrxsByEpisode_Class> getToBeNewTrxsByEpisode_ClassList = AccountTransaction.GetToBeNewTrxsByEpisode(this.ObjectContext, this.Episode.ObjectID);
        //    foreach (AccountTransaction.GetToBeNewTrxsByEpisode_Class tahakkuk in getToBeNewTrxsByEpisode_ClassList)
        //    {
        //       tahakkuk.TransactionDate + "'-" + tahakkuk.Description + " \r\n";
        //        count++;
        //    }
        //    if (message != "")
        //    {
        //        message += "işlemleri uygulandıysa tamamlanmalı, uygulanmadı ise iptal edilmelidir.\r\n";
        //    }
        //    return message;
        //}
        //[HttpGet]
        //public DynamicComponentInfoDVO GetDynamicComponentInfo([FromUri]string ObjectId)
        //{
        //    DynamicComponentInfoDVO dynamicComponentInfo = new DynamicComponentInfoDVO();
        //    using (TTObjectContext objectContext = new TTObjectContext(false))
        //    {
        //        TTObject obj = objectContext.GetObject(new Guid(ObjectId), typeof(EpisodeAction));
        //        var subFolders = GetParentFolders(obj.ObjectDef.ModuleDef);
        //        var folderPath = string.Join("/", subFolders.Reverse());
        //        var moduleName = obj.ObjectDef.ModuleDef.Name.GetTsModuleName();
        //        var modulePath = string.Format("/Modules/{0}/{1}", folderPath, moduleName);
        //        dynamicComponentInfo.ComponentName = obj.CurrentStateDef.FormDef.CodeName;
        //        dynamicComponentInfo.ModuleName = moduleName;
        //        dynamicComponentInfo.ModulePath = modulePath;
        //        dynamicComponentInfo.objectID = ObjectId;
        //        objectContext.FullPartialllyLoadedObjects();
        //        return dynamicComponentInfo;
        //    }
        //}



        public partial class TreatmentDischargeProblemViewModel
        {
            public string ProblemString;
            public bool IsOk;
            public bool IsRequired;
            public Guid? ObjectId;
            public string ObjectDefName;
            public Guid? FormDefId;
            public List<GetReturnableDrugOrders_Output> problemDrugOrders = new List<GetReturnableDrugOrders_Output>();
        }

        public partial class TreatmentDischargeDefaultActionViewModel
        {
            public Guid? ObjectId;
            public string ObjectDefName;
            public string ApplicationName;
            public Guid? FormDefId;
            public Object InputParam;
        }

    }
}