
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
    /// Birimlerarası Nakil
    /// </summary>
    public  partial class PatientTransfer : EpisodeAction, IWorkListEpisodeAction, IWorkListInpatient
    {
//        public int? NumberOfBed
//        {
//            get
//            {
//                try
//                {
//#region NumberOfBed_GetScript                    
//                    if (this.TreatmentClinic!=null)
//                    return (int?) Common.GetNumberOfEmptyBeds(this.TreatmentClinic.ObjectID);
//                else
//                    return 0;
//#endregion NumberOfBed_GetScript
//                }
//                catch (Exception ex)
//                {
//                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "NumberOfBed") + " : " + ex.Message, ex);
//                }
//            }
//        }

//        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
//        override protected void RunSetMemberValueScript(string memberName, object newValue)
//        {
//            switch (memberName)
//            {
//                case "TREATMENTCLINIC":
//                    {
//                        ResClinic value = (ResClinic)newValue;
//#region TREATMENTCLINIC_SetParentScript
//            //bool hasQuota = value.CheckInpatientQuota(this.Episode);
//            //if(!hasQuota) 
//            //{
//            //    this.TreatmentClinic = null;
//            //    throw new Exception(SystemMessage.GetMessageV2(920,value.Name));
//            //}
//            this.SecondaryMasterResource=value;
//#endregion TREATMENTCLINIC_SetParentScript
//                    }
//                    break;

//                default:
//                    base.RunSetMemberValueScript(memberName, newValue);
//                    break;

//            }
//        }

//        protected override void PostUpdate()
//        {
//#region PostUpdate
            
            
//            // Eğer bir kere tahsis yapıldı ise değişen bed'e göre tahsisi açar
//          base.PostUpdate(); 
//          if(this.CurrentStateDef.Status == StateStatusEnum.Uncompleted)
//            {
//                //if(this.ReservedBedProcedures.Count>0)
//                //{
//                //    if(this.ReservedBedProcedures[0].Bed!=this.Bed)
//                //    {
//                //        this.UnReservedBedProcedure();
//                //        this.ReservedCurrentBedProcedure();
//                //    }
//                //}
//            }
//#endregion PostUpdate
//        }

//        protected void PostTransition_Request2Cancelled()
//        {
//            // From State : Request   To State : Cancelled
//#region PostTransition_Request2Cancelled
//            Cancel();
//#endregion PostTransition_Request2Cancelled
//        }

//        protected void UndoTransition_Request2Cancelled(TTObjectStateTransitionDef transitionDef)
//        {
//            // From State : Request   To State : Cancelled
//#region UndoTransition_Request2Cancelled
//            NoBackStateBack();
//#endregion UndoTransition_Request2Cancelled
//        }


//        protected void UndoTransition_Request2Transferred(TTObjectStateTransitionDef transitionDef)
//        {
//            // From State : Request   To State : Transferred
//            #region UndoTransition_Request2Transferred
//            NoBackStateBack();
//            #endregion UndoTransition_Request2Transferred
//        }

//        protected void PostTransition_Request2Transferred()
//        {
//            // From State : Request   To State : Transferred
//            #region PostTransition_Request2Transferred
//            //ilk tahsisi açar
//            this.ReservedCurrentBedProcedure();
//            TransferInPatientTreatmentClinicApplication();
//            #endregion PostTransition_Request2Transferred
//        }

//        protected void UndoTransition_Requestl2Transferred(TTObjectStateTransitionDef transitionDef)
//        {
//            // From State : Request   To State : Transferred
//            #region UndoTransition_Requestl2Transferred
//            this.NoBackStateBack();
//            #endregion UndoTransition_Requestl2Transferred
//        }

//        protected void PostTransition_ClinicApproval2Transferred()
//        {
//            // From State : ClinicApproval   To State : Transferred
//            #region PostTransition_ClinicApproval2Transferred
//            //ilk tahsisi açar
//            this.ReservedCurrentBedProcedure();
//            TransferInPatientTreatmentClinicApplication();
//            #endregion PostTransition_ClinicApproval2Transferred
//        }

//        protected void UndoTransition_ClinicApproval2Transferred(TTObjectStateTransitionDef transitionDef)
//        {
//            // From State : ClinicApproval   To State : Transferred
//            #region UndoTransition_ClinicApproval2Transferred
//            this.NoBackStateBack();
//            #endregion UndoTransition_ClinicApproval2Transferred
//        }


//        protected void PostTransition_ClinicApproval2Cancelled()
//        {
//            // From State : ClinicApproval   To State : Cancelled
//#region PostTransition_ClinicApproval2Cancelled
//            this.Cancel();
//#endregion PostTransition_ClinicApproval2Cancelled
//        }

//        protected void UndoTransition_ClinicApproval2Cancelled(TTObjectStateTransitionDef transitionDef)
//        {
//            // From State : ClinicApproval   To State : Cancelled
//#region UndoTransition_ClinicApproval2Cancelled
//            NoBackStateBack();
//#endregion UndoTransition_ClinicApproval2Cancelled
//        }



//        protected void PostTransition_Transferred2Cancelled()
//        {
//            // From State : Transferred   To State : Cancelled
//#region PostTransition_Transferred2Cancelled
//            this.Cancel();
//#endregion PostTransition_Transferred2Cancelled
//        }

//        protected void UndoTransition_Transferred2Cancelled(TTObjectStateTransitionDef transitionDef)
//        {
//            // From State : Transferred   To State : Cancelled
//#region UndoTransition_Transferred2Cancelled
//            NoBackStateBack();
//#endregion UndoTransition_Transferred2Cancelled
//        }

//#region Methods
//        public override ActionTypeEnum ActionType
//        {
//            get {
//                return ActionTypeEnum.PatientTransfer;
//            }
//        }
//        protected void TransferInPatientTreatmentClinicApplication()
//        {
            
//            if(this.OldInPatientTrtmentClinicApp==null)
//            {
//                throw new Exception(SystemMessage.GetMessage(921));
//            }
//            else
//            {
//                bool found=false;
//                foreach(NursingApplication nA in this.OldInPatientTrtmentClinicApp.NursingApplications)
//                {
//                    if (nA.CurrentStateDefID!=NursingApplication.States.Discharged)
//                    {
//                        found=true;
//                        break;
//                    }
//                }
//                if(found)
//                {
//                    throw new Exception (SystemMessage.GetMessage(922));
//                }
                
//                UnReservedBedProcedure();
//                this.OldInPatientTrtmentClinicApp.BaseInpatientAdmission.TreatmentClinic=this.TreatmentClinic;
//                this.OldInPatientTrtmentClinicApp.BaseInpatientAdmission.PhysicalStateClinic=this.PhysicalStateClinic;
//                this.OldInPatientTrtmentClinicApp.BaseInpatientAdmission.RoomGroup=this.RoomGroup;
//                this.OldInPatientTrtmentClinicApp.BaseInpatientAdmission.Room=this.Room;
//                this.OldInPatientTrtmentClinicApp.BaseInpatientAdmission.Bed=this.Bed;
//                //PateintTransfer Artık kullanılmıyor
//             //   InPatientTreatmentClinicApplication inPatientTreatmentClinicApplication=this.OldInPatientTrtmentClinicApp.BaseInpatientAdmission.FireInPatientTreatmentClinicApplication();
//              //  inPatientTreatmentClinicApplication.FromResource=this.OldInPatientTrtmentClinicApp.MasterResource;
//               // inPatientTreatmentClinicApplication.FromTransferObject=this; // PateintTransfer Artık kullanılmıyor
//               // this.NewInPatientTrtmentClinicApp=inPatientTreatmentClinicApplication;
//               // this.OldInPatientTrtmentClinicApp.CurrentStateDefID = InPatientTreatmentClinicApplication.States.Transferred;
                
                
//            }
//        }
//        protected void ReservedCurrentBedProcedure()
//        {
//            if(this.Bed!=null)
//            {
//                bool startNewReservation=true;
//                if(this.Bed.UsedByBedProcedure!=null)
//                {
//                    if(this.Bed.UsedByBedProcedure.UsedStatus==UsedStatusEnum.ReservedToUse)
//                    {
//                        startNewReservation=false;
//                    }
//                }
//                if(startNewReservation)
//                {
//                    //BaseBedProcedure baseBedProcedure = new BaseBedProcedure(this.ObjectContext);
//                    //this.ReservedBedProcedures.Add(baseBedProcedure);
//                    //baseBedProcedure.Bed=this.Bed;
//                    //baseBedProcedure.Room=this.Room;
//                    //baseBedProcedure.RoomGroup=this.RoomGroup;
//                    //baseBedProcedure.UsedStatus=UsedStatusEnum.ReservedToUse;
//                }
                
//            }
//        }
//        protected void UnReservedBedProcedure()
//        {
//            //foreach (BaseBedProcedure reservedBedProcedure in this.ReservedBedProcedures)
//            //{
//            //    reservedBedProcedure.UsedStatus=UsedStatusEnum.WasReserved;
//            //}
//        }
        
//        public PatientTransfer(TreatmentDischarge treatmentDischarge) : this(treatmentDischarge.ObjectContext)
//        {
//            this.CurrentStateDefID = PatientTransfer.States.Request;
//            this.OldInPatientTrtmentClinicApp= treatmentDischarge.InPatientTreatmentClinicApp;
//           // this.OldInPatientTrtmentClinicApp.ToTransferObject=this;// PateintTransfer Artık kullanılmıyor
//            this.SetMandatoryEpisodeActionProperties((EpisodeAction)treatmentDischarge, treatmentDischarge.MasterResource,null,false);
//            this.TreatmentClinic = treatmentDischarge.TransferTreatmentClinic;
//            this.ReasonForTransfer = Common.GetTextOfRTFString(treatmentDischarge.Conclusion.ToString());
//        }

//        protected override void BeforeSetSubEpisode(SubEpisode subEpisode)
//        {
//            base.BeforeSetSubEpisode(subEpisode);
//            if (this.OldInPatientTrtmentClinicApp==null)
//            {
//                throw new Exception(SystemMessage.GetMessage(923));
//            }
//        }

//        public override void Cancel()
//        {
//            if (this.NewInPatientTrtmentClinicApp != null)
//            {
//                if (this.NewInPatientTrtmentClinicApp.CurrentStateDef.Status != StateStatusEnum.Cancelled)
//                {
//                    if (string.IsNullOrEmpty(this.NewInPatientTrtmentClinicApp.ReasonOfCancel))
//                    {
//                        this.NewInPatientTrtmentClinicApp.ReasonOfCancel = this.ReasonOfCancel;
//                    }
//                    this.NewInPatientTrtmentClinicApp.CancelledByMasterAction = true;
//                    ((ITTObject)this.NewInPatientTrtmentClinicApp).Cancel();
//                }
//                if (this.NewInPatientTrtmentClinicApp.BaseInpatientAdmission != null)
//                    this.NewInPatientTrtmentClinicApp.BaseInpatientAdmission.DeallocateLastBed();
//            }

//            if (this.OldInPatientTrtmentClinicApp != null)
//            {
//                // Eğer  Birimler arası nakili başlatan MTS iptal edilmedi ise yada Bieimlerarasınakil olarak  seçilmiş taburcu sebebi değişmedi ise ? Birimlerarası Nakil?i başlatan Muayene Tedavi Sonuç işlemindeki Taburcu sebebi değiştirilmeden  Birimlerarası nakil iptal edilemez? hatası alınır;

//                if (this.OldInPatientTrtmentClinicApp.TreatmentDischarge.GetMyDischargeTypeEnum() == DischargeTypeEnum.TransferToOtherClinic && this.OldInPatientTrtmentClinicApp.TreatmentDischarge.CurrentStateDef.Status != StateStatusEnum.Cancelled)
//                {
//                    throw new Exception(SystemMessage.GetMessage(924));
//                }
//                //bir önceki Hemşirelik işlemleri  ?taburcu? adımına geldi ise "taburuca hazır"a step back yapılır.
//                //Böylece hemşire hasta taburcu edilecekse işlemi tekrar tamamlar yok yatmaya devam ededekse doktor İşlemleri geri alındığında Hemşirelik hizmetleri de Hemşirelik hizmetlerine geri döner ve hastanın yatışına devam edilir.
//                foreach (NursingApplication nursingApplication in this.OldInPatientTrtmentClinicApp.NursingApplications)
//                {
//                    if (nursingApplication.CurrentStateDefID == NursingApplication.States.Discharged)
//                    {
//                        ((ITTObject)nursingApplication).UndoLastTransition();
//                    }
//                }
//                //this.OldInPatientTrtmentClinicApp.ToTransferObject = null; // PateintTransfer Artık kullanılmıyor
//            }

//            UnReservedBedProcedure();

//            base.Cancel();
//        }
        
//#endregion Methods

//        protected void PostTransition(TTObjectStateTransitionDef transDef)
//        {
//            if (transDef.ObjectDef.CodeName != typeof(PatientTransfer).Name)
//                return;

//            var fromState = transDef.FromStateDefID;
//            var toState = transDef.ToStateDefID;

//            if (fromState == States.Request && toState == States.Cancelled)
//                PostTransition_Request2Cancelled();
//            else if (fromState == States.Request && toState == States.Transferred)
//                PostTransition_Request2Transferred();       
//            else if (fromState == States.ClinicApproval && toState == States.Cancelled)
//                PostTransition_ClinicApproval2Cancelled();
//            else if (fromState == States.ClinicApproval && toState == States.Transferred)
//                PostTransition_ClinicApproval2Transferred();
//            else if (fromState == States.Transferred && toState == States.Cancelled)
//                PostTransition_Transferred2Cancelled();
           
//        }

//        protected void UndoTransition(TTObjectStateTransitionDef transDef)
//        {
//            if (transDef.ObjectDef.CodeName != typeof(PatientTransfer).Name)
//                return;

//            var fromState = transDef.FromStateDefID;
//            var toState = transDef.ToStateDefID;

//            if (fromState == States.Request && toState == States.Cancelled)
//                UndoTransition_Request2Cancelled(transDef);
//            else if (fromState == States.Request && toState == States.Transferred)
//                UndoTransition_Request2Transferred(transDef);
//            else if (fromState == States.ClinicApproval && toState == States.Cancelled)
//                UndoTransition_ClinicApproval2Cancelled(transDef);
//            else if (fromState == States.ClinicApproval && toState == States.Transferred)
//                UndoTransition_ClinicApproval2Transferred(transDef);
//            else if (fromState == States.Transferred && toState == States.Cancelled)
//                UndoTransition_Transferred2Cancelled(transDef);

//        }

    }
}