
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
    public  partial class SurgeryExtension : EpisodeAction, IStockOutCancel
    {

        public SurgeryExtension(TTObjectContext objectContext, Surgery surgery) : this(objectContext)
        {
            IsOldAction = surgery.IsOldAction;
            ActionDate = Common.RecTime();
            //this.SetMandatoryEpisodeActionProperties((EpisodeAction)surgery, masterResource, surgery.FromResource, true);
            surgery.LinkedActions.Add(this);
            MasterResource = surgery.MasterResource;
            FromResource = surgery.FromResource;
            Episode = surgery.Episode;
            surgery.SurgeryExtension = this;
            MainSurgery = surgery;
            DescriptionToPreOp = surgery.DescriptionToPreOp;
            RequestDate = Common.RecTime();
            CurrentStateDefID = SurgeryExtension.States.Application;  

        }

        public override void Cancel()
        {
           if (CancelledBySurgery == true)
            {
                base.Cancel();
            }
            else
            {
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25153", "Ameliyat Ek İşlemleri ,ancak Ameliyat iptal edildiğinde iptal edilebilir"));
                //throw new Exception("Ameliyat için istenen anestezi ve reanimasyon işlemleri Ameliyat işlemi iptal edilmeden iptal edilemez.");
            }

        }


        protected void PostTransition_Application2Cancelled()
        {
            // From State : Application   To State : Cancelled
            #region PostTransition_Application2Cancelled
            Cancel();
            #endregion PostTransition_Application2Cancelled
        }
        protected void PostTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
            #region PostTransition_Completed2Cancelled
            Cancel();
            #endregion PostTransition_Completed2Cancelled
        }


        protected void PostTransition_Application2Rejected()
        {
            // From State : Completed   To State : Rejected
            #region PostTransition_Application2Rejected

            if (CancelledBySurgery != true)
            {
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25154", "Ameliyat Ek İşlemleri ,ancak Ameliyat reddedildiğinde  edildiğinde reddedilebilir edilebilir"));
                //throw new Exception("Ameliyat için istenen anestezi ve reanimasyon işlemleri Ameliyat işlemi iptal edilmeden iptal edilemez.");
            }
            #endregion PostTransition_Application2Rejected
        }

        protected void PostTransition_Application2Completed()
        {
            // From State : Application   To State : Completed
            #region PostTransition_Application2Completed

            CheckDirectPurchaseGridToComplete();
            foreach (Surgery surgery in Surgeries)
            {
                surgery.CheckAndComplete(this);
            }

            #endregion PostTransition_Application2Completed
        }

 
        protected void UndoTransition_Application2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Application   To State : Cancelled
            #region UndoTransition_Application2Cancelled
            NoBackStateBack();
            #endregion UndoTransition_Application2Cancelled
        }
        protected void UndoTransition_Completed2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Completed   To State : Cancelled
            #region UndoTransition_Completed2Cancelled
            NoBackStateBack();
            #endregion UndoTransition_Completed2Cancelled
        }
        protected void UndoTransition_Application2Completed(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Application   To State : Completed
            #region UndoTransition_Application2Completed
            foreach(Surgery surgery in Surgeries)
            { 
                if (surgery.CurrentStateDefID == Surgery.States.Completed)
                {
                    throw new TTUtils.TTException(SystemMessage.GetMessage(204));
                    //throw new Exception("Bağlı olduğu Ameliyat işlemi Tamam'  adımında iken işlem geri alınamaz.");
                }
            }
            #endregion UndoTransition_Application2Completed
        }
        protected void UndoTransition_Application2Rejected(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Application   To State : Rejected
            #region UndoTransition_Application2Rejected
            NoBackStateBack();
            #endregion UndoTransition_Application2Rejected
        }


        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(SurgeryExtension).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == SurgeryExtension.States.Application && toState == SurgeryExtension.States.Cancelled)
                PostTransition_Application2Cancelled();
            else if (fromState == SurgeryExtension.States.Completed && toState == SurgeryExtension.States.Cancelled)
                PostTransition_Completed2Cancelled();
            else if (fromState == SurgeryExtension.States.Application && toState == SurgeryExtension.States.Rejected)
                PostTransition_Application2Rejected();
            else if (fromState == SurgeryExtension.States.Application && toState == SurgeryExtension.States.Completed)
                PostTransition_Application2Completed();

        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(SurgeryExtension).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;


            if (fromState == SurgeryExtension.States.Application && toState == SurgeryExtension.States.Cancelled)
                UndoTransition_Application2Cancelled(transDef);
            else if (fromState == SurgeryExtension.States.Completed && toState == SurgeryExtension.States.Cancelled)
                UndoTransition_Completed2Cancelled(transDef);
            else if (fromState == SurgeryExtension.States.Application && toState == SurgeryExtension.States.Rejected)
                UndoTransition_Application2Rejected(transDef);
            else if (fromState == SurgeryExtension.States.Application && toState == SurgeryExtension.States.Completed)
                UndoTransition_Application2Completed(transDef);

        }
        #region Methods
        #region IStockOutCancel Members
        public BaseTreatmentMaterial.ChildBaseTreatmentMaterialCollection GetTreatmentMaterials()
        {
            return TreatmentMaterials;
        }
        #endregion
        #endregion
    }
}