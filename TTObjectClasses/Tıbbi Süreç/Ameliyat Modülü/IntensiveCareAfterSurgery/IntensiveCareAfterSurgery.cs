
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
    /// Ameliyat Sonrası  Derlenme İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
    public  partial class IntensiveCareAfterSurgery : BaseInpatientAdmission, IWorkListEpisodeAction, ITreatmentMaterialCollection, IStockOutCancel
    {
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
            if( CurrentStateDefID == IntensiveCareAfterSurgery.States.Procedure )
            {
                //ilk atamada hastanın son yatağı varsa onu rezerve yapar .Kendini Used yapar
                if (BedProcedures.Count<1)
                {
                    AllocateNewBed(true,false);
                }
                else// Sonraki atamalarda Yatan hasta gibi davranır.
                {
                    AllocateNewBed(false,false);
                }
            }
            
            base.PostUpdate();
#endregion PostUpdate
        }

        protected void PostTransition_PostOp2DischargedWithoutProcedure()
        {
            // From State : PostOp   To State : DischargedWithoutProcedure
#region PostTransition_PostOp2DischargedWithoutProcedure
            //this.SetEpisodeMainSpecialityAfterSurgery();
#endregion PostTransition_PostOp2DischargedWithoutProcedure
        }

        protected void UndoTransition_PostOp2DischargedWithoutProcedure(TTObjectStateTransitionDef transitionDef)
        {
            // From State : PostOp   To State : DischargedWithoutProcedure
#region UndoTransition_PostOp2DischargedWithoutProcedure
            StepBackToSpeciality();
#endregion UndoTransition_PostOp2DischargedWithoutProcedure
        }

        protected void PostTransition_PostOp2Procedure()
        {
            // From State : PostOp   To State : Procedure
            #region PostTransition_PostOp2Procedure
            new InPatientTreatmentClinicApplication(this, TreatmentClinic, FromResource);
            #endregion PostTransition_PostOp2Procedure
        }

        protected void UndoTransition_PostOp2Procedure(TTObjectStateTransitionDef transitionDef)
        {
            // From State : PostOp   To State : Procedure
#region UndoTransition_PostOp2Procedure
            NoBackStateBack();
#endregion UndoTransition_PostOp2Procedure
        }

        protected void PostTransition_PostOp2Cancelled()
        {
            // From State : PostOp   To State : Cancelled
#region PostTransition_PostOp2Cancelled
            Cancel();
#endregion PostTransition_PostOp2Cancelled
        }

        protected void UndoTransition_PostOp2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : PostOp   To State : Cancelled
#region UndoTransition_PostOp2Cancelled
            UndoCancel();
#endregion UndoTransition_PostOp2Cancelled
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
            UndoCancel();
#endregion UndoTransition_Discharged2Cancelled
        }

        protected void PreTransition_Procedure2Discharged()
        {
            // From State : Procedure   To State : Discharged
#region PreTransition_Procedure2Discharged
            DeallocateLastBed();
#endregion PreTransition_Procedure2Discharged
        }

        protected void PostTransition_Procedure2Discharged()
        {
            // From State : Procedure   To State : Discharged
#region PostTransition_Procedure2Discharged
            //this.SetEpisodeMainSpecialityAfterSurgery();
#endregion PostTransition_Procedure2Discharged
        }

        protected void UndoTransition_Procedure2Discharged(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Procedure   To State : Discharged
#region UndoTransition_Procedure2Discharged
            StepBackToClinicProcedure();
            if(Bed!=null)
            {
                if(Bed.UsedByBedProcedure==null)
                {
                    Bed=null;
                    Room=null;
                    RoomGroup=null;
                }
            }            
            StepBackToSpeciality();
#endregion UndoTransition_Procedure2Discharged
        }

        protected void PostTransition_Procedure2Cancelled()
        {
            // From State : Procedure   To State : Cancelled
#region PostTransition_Procedure2Cancelled
            Cancel();
#endregion PostTransition_Procedure2Cancelled
        }

        protected void UndoTransition_Procedure2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Procedure   To State : Cancelled
#region UndoTransition_Procedure2Cancelled
            UndoCancel();
#endregion UndoTransition_Procedure2Cancelled
        }

        protected void PostTransition_DischargedWithoutProcedure2Cancelled()
        {
            // From State : DischargedWithoutProcedure   To State : Cancelled
#region PostTransition_DischargedWithoutProcedure2Cancelled
            Cancel();
#endregion PostTransition_DischargedWithoutProcedure2Cancelled
        }

        protected void UndoTransition_DischargedWithoutProcedure2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : DischargedWithoutProcedure   To State : Cancelled
#region UndoTransition_DischargedWithoutProcedure2Cancelled
            UndoCancel();
#endregion UndoTransition_DischargedWithoutProcedure2Cancelled
        }

#region Methods
        public override ActionTypeEnum ActionType
        {
            get {
                return ActionTypeEnum.IntensiveCareAfterSurgery;
            }
        }
        
        public IntensiveCareAfterSurgery(Surgery surgery,ResSection masterResource) : this(surgery.ObjectContext)
        {
            SetMandatoryEpisodeActionProperties((EpisodeAction)surgery,masterResource,true);
            CurrentStateDefID = IntensiveCareAfterSurgery.States.PostOp;
            Surgery=surgery;
            
        }
        
        public IntensiveCareAfterSurgery(AnesthesiaAndReanimation anesthesiaAndReanimation,ResSection masterResource) : this(anesthesiaAndReanimation.ObjectContext)
        {
            SetMandatoryEpisodeActionProperties((EpisodeAction)anesthesiaAndReanimation,masterResource,true);
            CurrentStateDefID = IntensiveCareAfterSurgery.States.PostOp;
            Surgery = anesthesiaAndReanimation.MainSurgery;
            AnesthesiaAndReanimation = anesthesiaAndReanimation;
            
        }
        
        public void StepBackToClinicProcedure()
        {
            foreach(InPatientTreatmentClinicApplication iPTCA in InPatientTreatmentClinicApplications)
            {
                if (!iPTCA.IsCancelled && iPTCA.CurrentStateDefID==InPatientTreatmentClinicApplication.States.Discharged)
                {
                    ((ITTObject)iPTCA).UndoLastTransition();
                }
            }
            
            
        }
        

        public override void Cancel()
        {
            foreach (InPatientTreatmentClinicApplication inPatientTreatClinicApp in InPatientTreatmentClinicApplications)
            {
                if (inPatientTreatClinicApp.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                {
                    inPatientTreatClinicApp.CancelledByMasterAction = true;
                    if (string.IsNullOrEmpty(inPatientTreatClinicApp.ReasonOfCancel))
                    {
                        inPatientTreatClinicApp.ReasonOfCancel = ReasonOfCancel;
                    }
                    ((ITTObject)inPatientTreatClinicApp).Cancel();
                }
            }
            DeallocateLastBed();
            base.Cancel();
        }
        
        public override void UndoCancel()
        {
            NoBackStateBack();
        }
        //Ameliyat Derleme'den taburcu ya da derleme sonu aşamasına geçişte uzmanlık dalı bilgisi set edilmekte.
        //public void SetEpisodeMainSpecialityAfterSurgery()
        //{
        //    if(this.Episode.PatientStatus != PatientStatusEnum.Outpatient)
        //    {
        //        bool IsInpatientTreatmentClinicAppExists = false;
        //        foreach(EpisodeAction ea in this.Episode.EpisodeActions)
        //        {                
        //            if(ea is InPatientTreatmentClinicApplication &&(((InPatientTreatmentClinicApplication)ea).BaseInpatientAdmission is  IntensiveCareAfterSurgery) == false)                    
        //            {
        //                IsInpatientTreatmentClinicAppExists = true;
        //                this.Episode.MainSpeciality = ea.SubEpisode.Speciality;                    
        //                break;
        //            }
        //        }
        //        if(!IsInpatientTreatmentClinicAppExists)
        //        {                                        
        //            IList subEpisodes = SubEpisode.GetSpecialityBySubEpisodeFilter(this.ObjectContext, this.Episode.ObjectID.ToString(), this.SubEpisode.ObjectID.ToString());
        //            if(subEpisodes.Count > 0)                                                                                     
        //                this.Episode.MainSpeciality = ((SubEpisode)subEpisodes[0]).Speciality;                                           
        //        }
        //    }
        //}
        //Uzmanlık dalı bilgisi eski haline getiriliyor.
        public void StepBackToSpeciality()
        {
            //this.Episode.MainSpeciality = this.SubEpisode.Speciality;
        }
        //        protected void SetLastBedProcedureDischargedDate()
        //        {
        //            // Benzer bir kod InPatient Procedure işlemindede var
        //            IList bedProceduresInBed = BaseBedProcedure.GetByEpisodeActıonAndIsLast(this.ObjectContext,this.ObjectID.ToString(),true);
        //            int k =  bedProceduresInBed.Count-1;
        //            ((BaseBedProcedure)bedProceduresInBed[k]).IsLast=false;
        //            ((BaseBedProcedure)bedProceduresInBed[k]).BedDischargeDate=DateTime.Now;
        //        }
        //        /// <summary>
        /// Bed değerei her değişip kaydedildiğindeYatak Gridine yeni bir satır atılır
        /// </summary>
        //        protected void AddBedProcedures()
        //        {
        //            // Benzer bir kod InPatient Procedure işlemindede var
        //            //            if (this.IntensiveCareAfterSurgeryBedProcedures.Count<1 )
        //            //            {
        //            //                BaseBedProcedure baseBedProcedure = new BaseBedProcedure(this.ObjectContext);
        //            //                baseBedProcedure.CurrentStateDefID= BaseBedProcedure.States.InBed;
        //            //                baseBedProcedure.BedInPatientDate=this.ClinicInPatientDate;
        //            //                baseBedProcedure.Bed=this.Bed;
        //            //                this.InpatientProcedureBedProcedures.Add(baseBedProcedure);
        ////
        //            //            }
        //            //            else
        //            //            {
        //
        //            IList bedProceduresInBed = BaseBedProcedure.GetByEpisodeActıonAndIsLast(this.ObjectContext,this.ObjectID.ToString(),true);
        //            int count=bedProceduresInBed.Count ;
        //            if (count==0)
        //            {
        //                BaseBedProcedure baseBedProcedure = new BaseBedProcedure(this.ObjectContext);
        //                baseBedProcedure.IsLast=true;
        //                baseBedProcedure.Bed=this.Bed;
        //                this.IntensiveCareAfterSurgeryBedProcedures.Add(baseBedProcedure);
        //
        //            }
        //            else if (count==1)
        //            {
        //                if (((BaseBedProcedure)bedProceduresInBed[0]).Bed!=this.Bed)
        //                {
        //                    ((BaseBedProcedure)bedProceduresInBed[0]).IsLast=false;
        //                    ((BaseBedProcedure)bedProceduresInBed[0]).BedDischargeDate=DateTime.Now;
        //                    BaseBedProcedure baseBedProcedure = new BaseBedProcedure(this.ObjectContext);
        //                    baseBedProcedure.IsLast=true;
        //                    baseBedProcedure.Bed=this.Bed;
        //                    this.IntensiveCareAfterSurgeryBedProcedures.Add(baseBedProcedure);
        //
        //                }
        //            }
        //            else
        //            {
        //                int k;
        //                for(int i = 0; i < count; i ++)
        //                {
        //                    k=i+1;
        //                    if (k==count)
        //                    {
        //                        if (((BaseBedProcedure)bedProceduresInBed[i]).Bed!=this.Bed)
        //                        {
        //                            ((BaseBedProcedure)bedProceduresInBed[i]).IsLast=false;
        //                            ((BaseBedProcedure)bedProceduresInBed[i]).BedDischargeDate=DateTime.Now;
        //                            BaseBedProcedure baseBedProcedure = new BaseBedProcedure(this.ObjectContext);
        //                            baseBedProcedure.IsLast=true;
        //                            baseBedProcedure.Bed=this.Bed;
        //                            this.IntensiveCareAfterSurgeryBedProcedures.Add(baseBedProcedure);
        //
        //                        }
        //                    }
        //                    else
        //                    {
        //                        ((BaseBedProcedure)bedProceduresInBed[i]).IsLast=false;
        //                        ((BaseBedProcedure)bedProceduresInBed[i]).BedDischargeDate=((BaseBedProcedure)bedProceduresInBed[k]).BedInPatientDate;
        //
        //                    }
        //                }
        //            }
        //
        //            //            }
        //

        //        }

        #endregion Methods

        #region IStockOutCancel Members
        public BaseTreatmentMaterial.ChildBaseTreatmentMaterialCollection GetTreatmentMaterials()
        {
            return TreatmentMaterials;
        }
        #endregion

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(IntensiveCareAfterSurgery).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == IntensiveCareAfterSurgery.States.Procedure && toState == IntensiveCareAfterSurgery.States.Discharged)
                PreTransition_Procedure2Discharged();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(IntensiveCareAfterSurgery).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == IntensiveCareAfterSurgery.States.PostOp && toState == IntensiveCareAfterSurgery.States.DischargedWithoutProcedure)
                PostTransition_PostOp2DischargedWithoutProcedure();
            else if (fromState == IntensiveCareAfterSurgery.States.PostOp && toState == IntensiveCareAfterSurgery.States.Procedure)
                PostTransition_PostOp2Procedure();
            else if (fromState == IntensiveCareAfterSurgery.States.PostOp && toState == IntensiveCareAfterSurgery.States.Cancelled)
                PostTransition_PostOp2Cancelled();
            else if (fromState == IntensiveCareAfterSurgery.States.Discharged && toState == IntensiveCareAfterSurgery.States.Cancelled)
                PostTransition_Discharged2Cancelled();
            else if (fromState == IntensiveCareAfterSurgery.States.Procedure && toState == IntensiveCareAfterSurgery.States.Discharged)
                PostTransition_Procedure2Discharged();
            else if (fromState == IntensiveCareAfterSurgery.States.Procedure && toState == IntensiveCareAfterSurgery.States.Cancelled)
                PostTransition_Procedure2Cancelled();
            else if (fromState == IntensiveCareAfterSurgery.States.DischargedWithoutProcedure && toState == IntensiveCareAfterSurgery.States.Cancelled)
                PostTransition_DischargedWithoutProcedure2Cancelled();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(IntensiveCareAfterSurgery).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == IntensiveCareAfterSurgery.States.PostOp && toState == IntensiveCareAfterSurgery.States.DischargedWithoutProcedure)
                UndoTransition_PostOp2DischargedWithoutProcedure(transDef);
            else if (fromState == IntensiveCareAfterSurgery.States.PostOp && toState == IntensiveCareAfterSurgery.States.Procedure)
                UndoTransition_PostOp2Procedure(transDef);
            else if (fromState == IntensiveCareAfterSurgery.States.PostOp && toState == IntensiveCareAfterSurgery.States.Cancelled)
                UndoTransition_PostOp2Cancelled(transDef);
            else if (fromState == IntensiveCareAfterSurgery.States.Discharged && toState == IntensiveCareAfterSurgery.States.Cancelled)
                UndoTransition_Discharged2Cancelled(transDef);
            else if (fromState == IntensiveCareAfterSurgery.States.Procedure && toState == IntensiveCareAfterSurgery.States.Discharged)
                UndoTransition_Procedure2Discharged(transDef);
            else if (fromState == IntensiveCareAfterSurgery.States.Procedure && toState == IntensiveCareAfterSurgery.States.Cancelled)
                UndoTransition_Procedure2Cancelled(transDef);
            else if (fromState == IntensiveCareAfterSurgery.States.DischargedWithoutProcedure && toState == IntensiveCareAfterSurgery.States.Cancelled)
                UndoTransition_DischargedWithoutProcedure2Cancelled(transDef);
        }

    }
}