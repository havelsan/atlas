
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
    /// Diğer Birimlerden Sağlık Kurulu Muayenesi
    /// </summary>
    public  partial class HealthCommitteeExaminationFromOtherDepartments : BaseHealthCommittee, IWorkListEpisodeAction
    {
        protected override void PreInsert()
        {
#region PreInsert
            
            base.PreInsert();
            
            // SAGLIKKURULU ? GENEL Heyet Kabul adımında iptal olmamış actionların sayısı 2 veya daha
            // fazla ise bir liste ile ?Ek istek yapılacak Sağlık Kurulu işlemi seçiniz? ibaresini kullanarak
            // kullanıcıya seçtirilir.  Eğer sadece 1 adet SAGLIKKURULU ? GENEL/ Heyet Kabul otomatik olarak
            // o action üzerinden action yatatılır.Eğer bunlardan ikisi de yoksa, hastanın bu işlem için uygun
            // olmadığına dair hata mesajı verilir.
            
            //Aşağıdaki kod SetEpisode scriptine taşındı....YY
            
//            ArrayList healthCommitteeActionList = new ArrayList();
//            foreach(EpisodeAction episodeAction in this.Episode.EpisodeActions){
//                if(episodeAction is HealthCommittee && episodeAction.Cancelled == false)
//                {
//                    HealthCommittee healthCommitteeEA= (HealthCommittee) episodeAction;
//                    if(healthCommitteeEA.CurrentStateDefID == HealthCommittee.States.CommitteeAcceptance)
//                    {
//                        healthCommitteeActionList.Add(healthCommitteeEA);
//                    }
//                }
//            }
//            
//            if(healthCommitteeActionList.Count == 0)
//            {
//                throw new TTException("Hastanın durumu bu işlem için uygun değildir. ");
//            }
//            else
//            {
//                if(healthCommitteeActionList.Count >= 1)
//                {
//                    foreach(HealthCommittee healthCommittee in healthCommitteeActionList)
//                    {
//                        // YAPILACAKLAR //Burada kullanıcıya göstereceğimiz listeyi dolduracağız.
//                        // BURASI SİLİNECEK  (burası defult en son)
//                        this.HCActionToBeLinked=  healthCommittee;
//                        // BURAYA KADAR
//                    }
//                    // YAPILACAKLAR // Seçildikten sonra burada aslında HCActionHCExaminationsToBeLinked set edilmeli...
//                }
//            }
#endregion PreInsert
        }

        protected override void PostInsert()
        {
#region PostInsert
            
            base.PostInsert();
            SetHCCommitteeAcceptanceStatus();

#endregion PostInsert
        }

        protected override void PostUpdate()
        {
#region PostUpdate
            
            base.PostUpdate();
            SetHCCommitteeAcceptanceStatus();

#endregion PostUpdate
        }

        protected void PostTransition_New2Acceptance()
        {
            // From State : New   To State : Acceptance
#region PostTransition_New2Acceptance
            
            CheckHospitalsUnitsGridForFork();

#endregion PostTransition_New2Acceptance
        }

        protected void UndoTransition_New2Acceptance(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : Acceptance
#region UndoTransition_New2Acceptance
            
            NoBackStateBack();
#endregion UndoTransition_New2Acceptance
        }

        protected void UndoTransition_Approval2Rejected(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Approval   To State : Rejected
#region UndoTransition_Approval2Rejected
            
            NoBackStateBack();
#endregion UndoTransition_Approval2Rejected
        }

        protected void PostTransition_Approval2Acceptance()
        {
            // From State : Approval   To State : Acceptance
#region PostTransition_Approval2Acceptance
            
            CheckHospitalsUnitsGridForFork();

#endregion PostTransition_Approval2Acceptance
        }

        protected void UndoTransition_Approval2Acceptance(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Approval   To State : Acceptance
#region UndoTransition_Approval2Acceptance
            
            NoBackStateBack();
#endregion UndoTransition_Approval2Acceptance
        }

#region Methods
        public HealthCommitteeExaminationFromOtherDepartments(TTObjectContext objectContext, EpisodeAction episodeAction) : this(objectContext)
        {
            ActionDate = Common.RecTime();
            MasterResource = episodeAction.MasterResource;
            FromResource = episodeAction.MasterResource;
            CurrentStateDefID = HealthCommitteeExaminationFromOtherDepartments.States.New;
            Episode = episodeAction.Episode;
        }
        
        public override ActionTypeEnum ActionType
        {
            get {
                return ActionTypeEnum.HealthCommitteeExaminationFromOtherDepartments;
            }
        }
        /// <summary>
        /// HospitalsUnits içindeki her bir satırın SK Muayenesi olarak fork edilmesini sağlar.
        /// </summary>
        protected void CheckHospitalsUnitsGridForFork()
        {
            foreach(BaseHealthCommittee_HospitalsUnitsGrid hospitalUnit in _HospitalsUnits)
            {
                EpisodeAction.ForkHealthCommitteeExamination((HospitalsUnitsGrid) hospitalUnit,this);

                if (hospitalUnit.EpisodeActionTemplate != null)
                    FireEpisodeActionByTemplate(hospitalUnit.EpisodeActionTemplate, hospitalUnit.Unit);
                else if (hospitalUnit.Template != null) // Eski ActionTemplate kalmadığında silinecek
                {
                    EpisodeAction templateEA = hospitalUnit.Template.Action as EpisodeAction;
                    if (templateEA != null)
                    {
                        EpisodeAction firedAction = templateEA.CreateNewActionFromTemplate(hospitalUnit.Unit, this);
                        firedAction.MasterAction = this;
                    }
                }
            }            
            ControlReasonForExaminationToTurnPatientShare();
        }
        
       
        
        // Muayenelerin bağlanacağı Sağlık Kurulu işleminin Muayene sebebi "Hasta Öder" şeklinde tanımlı ise Sağlık Kurulu
        // işleminin ve sağlık kuruluna bağlı işlemlerin içindeki hizmet ve malzemeleri hasta payına çevirir.
        public void ControlReasonForExaminationToTurnPatientShare()
        {
            //if(this.HCActionToBeLinked != null)
            //{
            //    if(this.HCActionToBeLinked.AutomaticallyCreated != true && this.HCActionToBeLinked.ReasonForExamination != null && this.HCActionToBeLinked.ReasonForExamination.PatientPays == true)
            //    {
            //        this.TurnMySubActionsToPatientShare(true);
                    
            //        foreach(HealthCommitteeExamination hce in this.HealthCommitteeExaminations)
            //            hce.TurnMySubActionsToPatientShare(true);
                    
            //        // Laboratuvar ve Radyoloji gibi şablon olan işlemler, bu işlemin LinkedActions ları.
            //        // Sağlık Kurulu Muayeneleri, Sağlık Kurulu işlemine bağlanıyor LinkedActions olarak.
            //        // Dolayısıyla aşağıdaki döngüye Sağlık Kurulu Muayeneleri gelmiyor.
            //        foreach(BaseAction baseAction in this.LinkedActions)
            //        {
            //            EpisodeAction episodeAction = baseAction as EpisodeAction;
            //            // Şablondaki Laboratuvar ve Radyoloji işlemlerini burada ücretlendirmek gerekiyor ki,
            //            // AccTrx leri hasta payına çevrilebilsin
            //            episodeAction.AccountOperationDirect(AccountOperationTimeEnum.PREPOST);
            //            episodeAction.TurnMySubActionsToPatientShare(true);
            //        }
            //    }
            //}
        }
        
        // Sağlık Kurulu işleminin Heyet Kabul Durumu güncellenir
        public void SetHCCommitteeAcceptanceStatus()
        {
            if(HCActionToBeLinked != null)
                HCActionToBeLinked.SetCommitteeAcceptanceStatus();
        }
        
       
        
#endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(HealthCommitteeExaminationFromOtherDepartments).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == HealthCommitteeExaminationFromOtherDepartments.States.New && toState == HealthCommitteeExaminationFromOtherDepartments.States.Acceptance)
                PostTransition_New2Acceptance();
            else if (fromState == HealthCommitteeExaminationFromOtherDepartments.States.Approval && toState == HealthCommitteeExaminationFromOtherDepartments.States.Acceptance)
                PostTransition_Approval2Acceptance();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(HealthCommitteeExaminationFromOtherDepartments).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == HealthCommitteeExaminationFromOtherDepartments.States.New && toState == HealthCommitteeExaminationFromOtherDepartments.States.Acceptance)
                UndoTransition_New2Acceptance(transDef);
            else if (fromState == HealthCommitteeExaminationFromOtherDepartments.States.Approval && toState == HealthCommitteeExaminationFromOtherDepartments.States.Rejected)
                UndoTransition_Approval2Rejected(transDef);
            else if (fromState == HealthCommitteeExaminationFromOtherDepartments.States.Approval && toState == HealthCommitteeExaminationFromOtherDepartments.States.Acceptance)
                UndoTransition_Approval2Acceptance(transDef);
        }

    }
}