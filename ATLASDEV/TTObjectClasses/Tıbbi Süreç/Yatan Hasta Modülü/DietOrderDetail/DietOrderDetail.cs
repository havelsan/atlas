
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
    /// Yatan Hasta Diyet
    /// </summary>
    public  partial class DietOrderDetail : BaseDietOrderDetail, ITreatmentMaterialCollection, IWorkListEpisodeAction, IWorkListInpatient
    {
        protected override void PostUpdate()
        {
            #region PostUpdate

            base.PostUpdate();

            #endregion PostUpdate
        }

        protected override void PreDelete()
        {
            #region PreDelete

            base.PreDelete();
            throw new Exception((SystemMessage.GetMessage(1166)));
            #endregion PreDelete
        }

        protected void PostTransition_Execution2Completed()
        {
            // From State : Execution   To State : Completed
            #region PostTransition_Execution2Completed
            ExecuteOrderDetail();
            SetPerformedDate();
            #endregion PostTransition_Execution2Completed
        }

        #region Methods
        #region ITreatmentMaterialCollection Members
        public BaseTreatmentMaterial.ChildBaseTreatmentMaterialCollection GetTreatmentMaterials()
        {
            return TreatmentMaterials;
        }
        #endregion
        public DietOrderDetail(DietOrder dietOrder) : this(dietOrder.ObjectContext)
        {
            CurrentStateDefID = DietOrderDetail.States.Execution;
            ProcedureObject = dietOrder.ProcedureObject;
            ActionDate = Common.RecTime().Date;
            List<ResSection> actionDefualtMasterResourcesList = EpisodeAction.AcionDefualtMasterResources(ObjectContext, ActionTypeEnum.DietOrder, dietOrder);
            foreach (var defualtMasterResource in actionDefualtMasterResourcesList)
            {
                MasterResource = (ResSection)defualtMasterResource;
                break;
            } 
            if( MasterResource == null )
                MasterResource = (ResSection)dietOrder.MasterResource;
            FromResource = (ResSection)dietOrder.FromResource;
            Episode = (Episode)dietOrder.Episode;

            MealTypes _newMeal = null;
            _newMeal = (MealTypes)dietOrder.MealType.Clone();

            MealType = _newMeal;
            //TODO ismail nursingapplication yeirne diyet modülüne atılacak
            EpisodeAction = dietOrder;
            //CreateMyVitalSign(); Bu Kod  Formdan Value irişi yapılıp kaydedilirken çağırılmalı
        }

        public override void SetMyPropertiesByMasterAction(EpisodeAction episodeAction)
        {
            EpisodeAction = episodeAction;
            CurrentStateDefID = DietOrderDetail.States.Execution;
            ActionDate = Common.RecTime().Date;
            MasterResource = (ResSection)episodeAction.MasterResource;
            FromResource = (ResSection)episodeAction.FromResource;
            Episode = (Episode)episodeAction.Episode;
        }

        public override void Cancel()
        {
            //Cancelled stateine geçerken yapılan şeyler yapılacak
            CancelOrderDetail();
            base.Cancel();
        }


        public override Resource SpecialResourceForStore()
        {//TODO ismail bunu nidaya sor
            //if (TTObjectClasses.SystemParameter.GetParameterValue("UseSecMasterResourceAsSpecialResourceForStore", "TRUE") == "FALSE") // Hastanın tedavi gördüğü birim
            //{
            //    Resource tgb = null;
            //    if (this.EpisodeAction is NursingApplication)
            //    {
            //        if (((NursingApplication)this.EpisodeAction).InPatientTreatmentClinicApp != null)
            //            return (Resource)(((NursingApplication)this.EpisodeAction).InPatientTreatmentClinicApp.MasterResource);
            //    }
            //}
            return SecondaryMasterResource == null ? MasterResource : SecondaryMasterResource;
        }

        #endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DietOrderDetail ).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DietOrderDetail.States.Execution && toState == DietOrderDetail.States.Completed)
                PostTransition_Execution2Completed();
        }

        public override bool NotSetWorklist
        {
            get { return (WorkListDate == null ? false : true); }// subepisode seti için
            set
            {
            }
        }

        public override void SetPerformedDate()
        {
            if (CreationDate == null || CreationDate > ExecutionDate)
                CreationDate = ExecutionDate;
            if (PerformedDate == null)
                PerformedDate = ExecutionDate;

        }
    }
}