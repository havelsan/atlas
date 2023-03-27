
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
    public partial class GrantMaterialCompletedForm : BaseGrantMaterialForm
    {
    /// <summary>
    /// Bağış Yardım
    /// </summary>
        protected TTObjectClasses.GrantMaterial _GrantMaterial
        {
            get { return (TTObjectClasses.GrantMaterial)_ttObject; }
        }

        protected ITTTabPage tttabpage1;
        protected ITTTabPage DocumentRecordLogTab;
        protected ITTGrid DocumentRecordLogs;
        protected ITTDateTimePickerColumn DocumentDateTimeDocumentRecordLog;
        protected ITTTextBoxColumn DocumentRecordLogNumberDocumentRecordLog;
        protected ITTEnumComboBoxColumn DocumentTransactionTypeDocumentRecordLog;
        protected ITTEnumComboBoxColumn BUDGETYPE;
        protected ITTTextBoxColumn SubjectDocumentRecordLog;
        protected ITTTextBoxColumn ReceiptNumber;
        protected ITTTextBoxColumn DescriptionsDocumentRecordLog;
        protected ITTButton SendToMKYS;
        override protected void InitializeControls()
        {
            tttabpage1 = (ITTTabPage)AddControl(new Guid("6949d457-521a-41bc-8d5b-11c5de9a83fb"));
            DocumentRecordLogTab = (ITTTabPage)AddControl(new Guid("b2c656e1-58ff-4aa5-baf3-adf911f56f4a"));
            DocumentRecordLogs = (ITTGrid)AddControl(new Guid("c2e13ac7-510c-48c3-87f9-5c26d7ffe0e5"));
            DocumentDateTimeDocumentRecordLog = (ITTDateTimePickerColumn)AddControl(new Guid("b29d3972-393e-4cd9-aacb-098d263c84ad"));
            DocumentRecordLogNumberDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("f357275d-2fd3-44da-b75d-555f1581eff3"));
            DocumentTransactionTypeDocumentRecordLog = (ITTEnumComboBoxColumn)AddControl(new Guid("d87525c4-58ba-487e-bf24-5a95c5c7a3d7"));
            BUDGETYPE = (ITTEnumComboBoxColumn)AddControl(new Guid("a3b5f15b-74a0-44eb-a96c-b0a40fb56a52"));
            SubjectDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("aa974241-6a52-4b18-b4fd-277e5c0f3025"));
            ReceiptNumber = (ITTTextBoxColumn)AddControl(new Guid("b514a256-4d20-4fbb-abb4-bf313623b7cc"));
            DescriptionsDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("235b382d-cbb4-41c8-9935-bce436c6a96f"));
            SendToMKYS = (ITTButton)AddControl(new Guid("3d1d0008-cdf1-46f9-80e4-e332cd6ed8a6"));
            base.InitializeControls();
        }

        public GrantMaterialCompletedForm() : base("GRANTMATERIAL", "GrantMaterialCompletedForm")
        {
        }

        protected GrantMaterialCompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}