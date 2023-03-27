
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
    /// Dağıtım Belgesi (Reçeteler İçin)
    /// </summary>
    public  partial class PresDistributionDocument : DistributionDocument, IAutoDocumentNumber, ICheckStockActionOutDetail, IDistributionDocument, IStockReservation, IStockTransferTransaction, IBasePrescriptionTransaction
    {
        protected void PreTransition_Approval2Cancelled()
        {
            // From State : Approval   To State : Cancelled
#region PreTransition_Approval2Cancelled
            
            foreach (PresDistributionDocMaterial presDistributionDocMaterial in PresDistributionDocumentMaterials)
                presDistributionDocMaterial.Status = StockActionDetailStatusEnum.Cancelled;
#endregion PreTransition_Approval2Cancelled
        }

        protected void PreTransition_ClinicApproval2Cancelled()
        {
            // From State : ClinicApproval   To State : Cancelled
#region PreTransition_ClinicApproval2Cancelled
            
            foreach (PresDistributionDocMaterial presDistributionDocMaterial in PresDistributionDocumentMaterials)
                presDistributionDocMaterial.Status = StockActionDetailStatusEnum.Cancelled;

#endregion PreTransition_ClinicApproval2Cancelled
        }

        protected void PreTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
#region PreTransition_Completed2Cancelled
            

            foreach (PresDistributionDocMaterial presDistributionDocMaterial in PresDistributionDocumentMaterials)
                presDistributionDocMaterial.Status = StockActionDetailStatusEnum.Cancelled;

#endregion PreTransition_Completed2Cancelled
        }

        protected void PreTransition_Control2Cancelled()
        {
            // From State : Control   To State : Cancelled
#region PreTransition_Control2Cancelled
            
            foreach (PresDistributionDocMaterial presDistributionDocMaterial in PresDistributionDocumentMaterials)
                presDistributionDocMaterial.Status = StockActionDetailStatusEnum.Cancelled;

#endregion PreTransition_Control2Cancelled
        }

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PresDistributionDocument).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == PresDistributionDocument.States.Approval && toState == PresDistributionDocument.States.Cancelled)
                PreTransition_Approval2Cancelled();
            
            else if (fromState == PresDistributionDocument.States.Completed && toState == PresDistributionDocument.States.Cancelled)
                PreTransition_Completed2Cancelled();
           
        }

    }
}