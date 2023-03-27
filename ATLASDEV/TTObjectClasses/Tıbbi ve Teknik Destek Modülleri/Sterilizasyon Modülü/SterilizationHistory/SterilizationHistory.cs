
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
    /// Sterilizasyon Geçmişi
    /// </summary>
    public  partial class SterilizationHistory : TTObject
    {
        protected override void PostInsert()
        {
            #region PostInsert
            base.PostInsert();
             if(ReusableMaterial == null)
            {
                throw new Exception("Sterile edilecek Malzeme seçimi yapılmadan işlem devam ettirilemez");
            }
             else if(ReusableMaterial.ActiveSterilization != null)
            {
                throw new Exception(ReusableMaterial + " Zaten Sterile Ediliyor");
            }
             else
            {
                ReusableMaterial.ActiveSterilization = this;
            }

            if (SterilizationRequest != null)
            {
                RequestDate = SterilizationRequest.RequestDate;
            }
           

            #endregion PostInsert
        }

        protected override void PreInsert()
        {
            #region PreInsert
            base.PreInsert();
            if(CurrentStateDefID == null)
            {
                CurrentStateDefID = SterilizationHistory.States.SterilizationRequest;
            }

            #endregion PreInsert
        }

        protected void PostTransition_Sterilization2Completed()
        {
            // From State : Sterilization   To State : Completed
            #region PostTransition_Sterilization2Completed
            if (ReusableMaterial == null)
            {
                throw new Exception("Sterile edilecek Malzeme yok  işlem devam ettirilemez. Lütfen Bilgi işlemi arayınız");
            }
            else if (ReusableMaterial.ActiveSterilization == this)
            {
                ReusableMaterial.ActiveSterilization = null;
            }

            #endregion PostTransition_Sterilization2Completed
        }

        protected void UndoTransition_Sterilization2Completed(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Discharged   To State : Cancelled
            #region UndoTransition_Sterilization2Completed
            if (ReusableMaterial == null)
            {
                throw new Exception("Sterile edilecek Malzeme yok  işlem devam ettirilemez. Lütfen Bilgi işlemi arayınız");
            }
            else if (ReusableMaterial.ActiveSterilization == null)
            {
                ReusableMaterial.ActiveSterilization = this;
            }
            else
            {
                throw new Exception(ReusableMaterial + " için  başka bir sterilizasyon süreci devam ediyor . İşlem geri alınamaz");
            }

            #endregion UndoTransition_Sterilization2Completed
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(SterilizationHistory).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == SterilizationHistory.States.Sterilization && toState == SterilizationHistory.States.Completed)
                PostTransition_Sterilization2Completed();
            
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(SterilizationHistory).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if(fromState == SterilizationHistory.States.Sterilization && toState == SterilizationHistory.States.Completed)
                UndoTransition_Sterilization2Completed(transDef);

 
          
        }
    }
}