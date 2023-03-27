
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
    /// İade Belgesi (Reçeteler İçin)
    /// </summary>
    public partial class PresReturningDocument : ReturningDocument, IAutoDocumentNumber, ICheckStockActionOutDetail, IReturningDocument, IStockTransferTransaction, IBasePrescriptionTransaction
    {
        protected void PreTransition_Approval2Cancelled()
        {
            // From State : Approval   To State : Cancelled
            #region PreTransition_Approval2Cancelled


            foreach (PresReturningDocMaterial presReturningDocMaterial in PresReturningDocumentMaterials)
                presReturningDocMaterial.Status = StockActionDetailStatusEnum.Cancelled;
            #endregion PreTransition_Approval2Cancelled
        }

        protected void PreTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
            #region PreTransition_Completed2Cancelled


            foreach (PresReturningDocMaterial presReturningDocMaterial in PresReturningDocumentMaterials)
                presReturningDocMaterial.Status = StockActionDetailStatusEnum.Cancelled;
            #endregion PreTransition_Completed2Cancelled
        }

        protected void PreTransition_Request2Cancelled()
        {
            // From State : Request   To State : Cancelled
            #region PreTransition_Request2Cancelled


            foreach (PresReturningDocMaterial presReturningDocMaterial in PresReturningDocumentMaterials)
                presReturningDocMaterial.Status = StockActionDetailStatusEnum.Cancelled;

            #endregion PreTransition_Request2Cancelled
        }

        protected void PreTransition_StockCardRegistry2Cancelled()
        {
            // From State : StockCardRegistry   To State : Cancelled
            #region PreTransition_StockCardRegistry2Cancelled


            foreach (PresReturningDocMaterial presReturningDocMaterial in PresReturningDocumentMaterials)
                presReturningDocMaterial.Status = StockActionDetailStatusEnum.Cancelled;

            #endregion PreTransition_StockCardRegistry2Cancelled
        }

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PresReturningDocument).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == PresReturningDocument.States.Approval && toState == PresReturningDocument.States.Cancelled)
                PreTransition_Approval2Cancelled();
            else if (fromState == PresReturningDocument.States.Completed && toState == PresReturningDocument.States.Cancelled)
                PreTransition_Completed2Cancelled();
        }

    }
}