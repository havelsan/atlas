
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
    /// Kayıt Silme Belgesi - Yok Edilen Belgesi (Reçeteler İçin)
    /// </summary>
    public  partial class PresDeleteRecordDocumentDestroyable : DeleteRecordDocumentDestroyable, IBasePrescriptionTransaction, IAutoDocumentNumber, IAutoDocumentRecordLog, IDeleteRecordDocumentDestroyable, IStockOutTransaction
    {
        protected void PreTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
#region PreTransition_Completed2Cancelled
            

            foreach (PresDelRecDoctDesMatlOut presDeleteRecordDocumentDestroyableMaterialOut in PresDeleteRecordDocumentDestroyableOutMaterials)
                presDeleteRecordDocumentDestroyableMaterialOut.Status = StockActionDetailStatusEnum.Cancelled;

#endregion PreTransition_Completed2Cancelled
        }

        protected void PreTransition_StockCardRegistry2Cancelled()
        {
            // From State : StockCardRegistry   To State : Cancelled
#region PreTransition_StockCardRegistry2Cancelled
            

            foreach (PresDelRecDoctDesMatlOut presDeleteRecordDocumentDestroyableMaterialOut in PresDeleteRecordDocumentDestroyableOutMaterials)
                presDeleteRecordDocumentDestroyableMaterialOut.Status = StockActionDetailStatusEnum.Cancelled;

#endregion PreTransition_StockCardRegistry2Cancelled
        }

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PresDeleteRecordDocumentDestroyable).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == PresDeleteRecordDocumentDestroyable.States.Completed && toState == PresDeleteRecordDocumentDestroyable.States.Cancelled)
                PreTransition_Completed2Cancelled();
            else if (fromState == PresDeleteRecordDocumentDestroyable.States.StockCardRegistry && toState == PresDeleteRecordDocumentDestroyable.States.Cancelled)
                PreTransition_StockCardRegistry2Cancelled();
        }

    }
}