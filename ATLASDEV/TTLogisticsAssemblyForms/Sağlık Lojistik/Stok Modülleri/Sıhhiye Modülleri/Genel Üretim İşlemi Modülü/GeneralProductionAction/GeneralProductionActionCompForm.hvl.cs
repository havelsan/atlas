
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
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// Genel Üretim İşlemi
    /// </summary>
    public partial class GeneralProductionActionCompForm : BaseGeneralProductionActionFrom
    {
    /// <summary>
    /// Genel Üretim İşlemi
    /// </summary>
        protected TTObjectClasses.GeneralProductionAction _GeneralProductionAction
        {
            get { return (TTObjectClasses.GeneralProductionAction)_ttObject; }
        }

        protected ITTTabPage tttabpage2;
        protected ITTGrid DocumentRecordLogs;
        protected ITTDateTimePickerColumn DocumentDateTimeDocumentRecordLog;
        protected ITTTextBoxColumn DocumentRecordLogNumberDocumentRecordLog;
        protected ITTEnumComboBoxColumn BUDGETYPE;
        protected ITTEnumComboBoxColumn DocumentTransactionTypeDocumentRecordLog;
        protected ITTTextBoxColumn NumberOfRowsDocumentRecordLog;
        protected ITTTextBoxColumn ReceiptNumber;
        protected ITTTextBoxColumn DescriptionsDocumentRecordLog;
        protected ITTButton SendToMKYS;
        override protected void InitializeControls()
        {
            tttabpage2 = (ITTTabPage)AddControl(new Guid("f060863b-5138-4b7e-a4eb-3008b569db67"));
            DocumentRecordLogs = (ITTGrid)AddControl(new Guid("82621922-70c0-46d2-a91f-5d6902c23560"));
            DocumentDateTimeDocumentRecordLog = (ITTDateTimePickerColumn)AddControl(new Guid("799e9e1c-e9d6-41f2-b472-7fddde1c58cc"));
            DocumentRecordLogNumberDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("8a65cc3c-d5b8-40d3-bf9d-27c0f88cd546"));
            BUDGETYPE = (ITTEnumComboBoxColumn)AddControl(new Guid("6b6fe212-3f50-4882-a7b9-02091c055b28"));
            DocumentTransactionTypeDocumentRecordLog = (ITTEnumComboBoxColumn)AddControl(new Guid("d15b5e24-8ddb-46a7-a365-83cad37f1ff6"));
            NumberOfRowsDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("ba4aacd7-8713-4f5d-a630-2935cee6e4f6"));
            ReceiptNumber = (ITTTextBoxColumn)AddControl(new Guid("8ebc87c7-1d13-48ac-94de-21bd652e1b56"));
            DescriptionsDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("4d8dd744-eb79-4869-a2dc-491c440dc4e4"));
            SendToMKYS = (ITTButton)AddControl(new Guid("dffcd3e4-bba0-43b5-8d47-6b432a776f6e"));
            base.InitializeControls();
        }

        public GeneralProductionActionCompForm() : base("GENERALPRODUCTIONACTION", "GeneralProductionActionCompForm")
        {
        }

        protected GeneralProductionActionCompForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}