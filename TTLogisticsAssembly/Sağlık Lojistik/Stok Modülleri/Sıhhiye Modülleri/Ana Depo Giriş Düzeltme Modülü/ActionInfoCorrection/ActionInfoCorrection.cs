
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
    /// Fatura İşlem Düzeltme Belgesi
    /// </summary>
    public partial class ActionInfoCorrection : EntryCorrectionProcess
    {

        protected override void PreInsert()
        {
            #region PreInsert
            base.PreInsert();
            #endregion PreInsert
        }

        protected override void PreUpdate()
        {
            #region PreUpdate

            #endregion PreUpdate
        }

        protected override void PostUpdate()
        {
            #region PostUpdate
            #endregion PostUpdate
        }

        protected void PreTransition_New2Completed()
        {
            // From State : New   To State : Completed
            #region PreTransition_New2Completed

            ChattelDocumentWithPurchase chattelDocumentWithPurchase = (ChattelDocumentWithPurchase)this.BaseChattelDocument;
            chattelDocumentWithPurchase.MKYS_ETedarikTuru = MKYS_ETedarikTurEnum.satinalma;
            chattelDocumentWithPurchase.Waybill = this.BaseNumber;
            chattelDocumentWithPurchase.WaybillDate = this.BaseDateTime;
            chattelDocumentWithPurchase.ExaminationReportDate = this.ExaminationReportDate;
            chattelDocumentWithPurchase.ExaminationReportNo = this.ExaminationReportNo;

            #endregion PreTransition_New2Completed
        }

        protected void UndoTransition_New2Completed(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : Completed
            #region UndoTransition_New2Completed
            #endregion UndoTransition_New2Completed
        }

        protected void PreTransition_New2Cancelled()
        {
            // From State : New   To State : Cancelled
            #region PreTransition_New2Cancelled
            
            #endregion PreTransition_New2Cancelled
        }

        protected void UndoTransition_New2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : Cancelled
            #region UndoTransition_New2Cancelled
            throw new Exception(SystemMessage.GetMessage(1228));
            #endregion UndoTransition_New2Cancelled
        }

        protected void PreTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
            #region PreTransition_Completed2Cancelled
            #endregion PreTransition_Completed2Cancelled
        }

        protected void UndoTransition_Completed2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Completed   To State : Cancelled
            #region UndoTransition_Completed2Cancelled
            #endregion UndoTransition_Completed2Cancelled
        }

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ActionInfoCorrection).Name)
                return;
            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;
            if (fromState == ActionInfoCorrection.States.New && toState == ActionInfoCorrection.States.Completed)
                PreTransition_New2Completed();
            else if (fromState == ActionInfoCorrection.States.New && toState == ActionInfoCorrection.States.Cancelled)
                PreTransition_New2Cancelled();
            else if (fromState == ActionInfoCorrection.States.Completed && toState == ActionInfoCorrection.States.Cancelled)
                PreTransition_Completed2Cancelled();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ActionInfoCorrection).Name)
                return;
            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;
            if (fromState == ActionInfoCorrection.States.New && toState == ActionInfoCorrection.States.Completed)
                UndoTransition_New2Completed(transDef);
            else if (fromState == ActionInfoCorrection.States.New && toState == ActionInfoCorrection.States.Cancelled)
                UndoTransition_New2Cancelled(transDef);
            else if (fromState == ActionInfoCorrection.States.Completed && toState == ActionInfoCorrection.States.Cancelled)
                UndoTransition_Completed2Cancelled(transDef);
        }
    }
}