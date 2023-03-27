
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
    public partial class ChngeStockLvlTypeComlatedForm : ChangeStockLevelTypeForm
    {
    /// <summary>
    /// İhtiyaç Fazlası İade
    /// </summary>
        protected TTObjectClasses.ChangeStockLevelType _ChangeStockLevelType
        {
            get { return (TTObjectClasses.ChangeStockLevelType)_ttObject; }
        }

        protected ITTTabPage DocumentRecordLogTab;
        protected ITTGrid DocumentRecordLogs;
        protected ITTDateTimePickerColumn DocumentDateTimeDocumentRecordLog;
        protected ITTTextBoxColumn DocumentRecordLogNumberDocumentRecordLog;
        protected ITTEnumComboBoxColumn DocumentTransactionTypeDocumentRecordLog;
        protected ITTEnumComboBoxColumn BUDGETYPE;
        protected ITTTextBoxColumn SubjectDocumentRecordLog;
        protected ITTTextBoxColumn ReceiptNumber;
        protected ITTButton SendToMKYS;
        override protected void InitializeControls()
        {
            DocumentRecordLogTab = (ITTTabPage)AddControl(new Guid("1b7a5c04-55a1-4a54-9ac0-a9ecfaca96b6"));
            DocumentRecordLogs = (ITTGrid)AddControl(new Guid("47a0a8ba-8759-48e7-a2c6-4e33e5502bb7"));
            DocumentDateTimeDocumentRecordLog = (ITTDateTimePickerColumn)AddControl(new Guid("971f8965-96c8-4c58-a64d-c3d6c2d54285"));
            DocumentRecordLogNumberDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("d0669a73-9809-4c6a-b7e0-94bd53abf7a0"));
            DocumentTransactionTypeDocumentRecordLog = (ITTEnumComboBoxColumn)AddControl(new Guid("ca170918-6745-4c3c-83b2-9ff99bfaa9f9"));
            BUDGETYPE = (ITTEnumComboBoxColumn)AddControl(new Guid("8e92036d-5348-442a-8469-e7fb8ec5cb1d"));
            SubjectDocumentRecordLog = (ITTTextBoxColumn)AddControl(new Guid("b3adb223-4f5f-46c1-a427-2ae96926195b"));
            ReceiptNumber = (ITTTextBoxColumn)AddControl(new Guid("a25aa801-5727-4c17-bc66-b7cb69d1f2b7"));
            SendToMKYS = (ITTButton)AddControl(new Guid("99f890d1-33f0-44ad-ab2f-5368589928d6"));
            base.InitializeControls();
        }

        public ChngeStockLvlTypeComlatedForm() : base("CHANGESTOCKLEVELTYPE", "ChngeStockLvlTypeComlatedForm")
        {
        }

        protected ChngeStockLvlTypeComlatedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}