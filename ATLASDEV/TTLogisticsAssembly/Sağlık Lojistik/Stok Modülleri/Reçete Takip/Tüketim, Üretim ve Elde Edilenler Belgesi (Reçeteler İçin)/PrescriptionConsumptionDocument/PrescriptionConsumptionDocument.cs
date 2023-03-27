
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
    /// Tüketim, Ãœretim ve Elde Edilenler Belgesi (Reçeteler İçin)
    /// </summary>
    public  partial class PrescriptionConsumptionDocument : ProductionConsumptionDocument, IAutoDocumentNumber, IAutoDocumentRecordLog, IProductionConsumptionDocument, IStockConsumptionTransaction, IStockProductionTransaction, IBasePrescriptionTransaction
    {
        public partial class GetPrescriptionConsumptionDetails_Class : TTReportNqlObject 
        {
        }

        protected void PreTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
#region PreTransition_Completed2Cancelled
            

            foreach (PrescriptionConsDocMatOut prescriptionConsumptionDocumentMaterialOut in PresConsumptionDocOutMaterials)
                prescriptionConsumptionDocumentMaterialOut.Status = StockActionDetailStatusEnum.Cancelled;

#endregion PreTransition_Completed2Cancelled
        }

        protected void PreTransition_Approval2Cancelled()
        {
            // From State : Approval   To State : Cancelled
#region PreTransition_Approval2Cancelled
            

            foreach (PrescriptionConsDocMatOut prescriptionConsumptionDocumentMaterialOut in PresConsumptionDocOutMaterials)
                prescriptionConsumptionDocumentMaterialOut.Status = StockActionDetailStatusEnum.Cancelled;

#endregion PreTransition_Approval2Cancelled
        }

        protected void PreTransition_StockCardRegistry2Cancelled()
        {
            // From State : StockCardRegistry   To State : Cancelled
#region PreTransition_StockCardRegistry2Cancelled
            

            foreach (PrescriptionConsDocMatOut prescriptionConsumptionDocumentMaterialOut in PresConsumptionDocOutMaterials)
                prescriptionConsumptionDocumentMaterialOut.Status = StockActionDetailStatusEnum.Cancelled;

#endregion PreTransition_StockCardRegistry2Cancelled
        }

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PrescriptionConsumptionDocument).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == PrescriptionConsumptionDocument.States.Completed && toState == PrescriptionConsumptionDocument.States.Cancelled)
                PreTransition_Completed2Cancelled();
            else if (fromState == PrescriptionConsumptionDocument.States.Approval && toState == PrescriptionConsumptionDocument.States.Cancelled)
                PreTransition_Approval2Cancelled();
            else if (fromState == PrescriptionConsumptionDocument.States.StockCardRegistry && toState == PrescriptionConsumptionDocument.States.Cancelled)
                PreTransition_StockCardRegistry2Cancelled();
        }

    }
}