
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
    /// Reçete Çıkış
    /// </summary>
    public partial class StockPrescriptionOutForm : TTForm
    {
    /// <summary>
    /// Reçete Çıkış
    /// </summary>
        protected TTObjectClasses.StockPrescriptionOut _StockPrescriptionOut
        {
            get { return (TTObjectClasses.StockPrescriptionOut)_ttObject; }
        }

        protected ITTLabel labelTransactionDate;
        protected ITTDateTimePicker TransactionDate;
        protected ITTLabel labelStockActionID;
        protected ITTTextBox StockActionID;
        protected ITTTextBox Description;
        protected ITTLabel labelDescription;
        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTLabel labelPrescriptionPaper;
        protected ITTObjectListBox PrescriptionPaper;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid StockPrescriptionOutMaterials;
        protected ITTListBoxColumn MaterialStockPrescriptionOutMat;
        protected ITTTextBoxColumn AmountStockPrescriptionOutMat;
        protected ITTListBoxColumn StockLevelTypeStockPrescriptionOutMat;
        protected ITTEnumComboBoxColumn StatusStockPrescriptionOutMat;
        override protected void InitializeControls()
        {
            labelTransactionDate = (ITTLabel)AddControl(new Guid("eb5565a7-38df-4d41-b6ce-a5e59e25daea"));
            TransactionDate = (ITTDateTimePicker)AddControl(new Guid("df407bf7-0eba-46b3-9dd6-c132c56afd4c"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("afc0543b-0acf-4e37-9055-71c222aebbb6"));
            StockActionID = (ITTTextBox)AddControl(new Guid("24ed6136-98ae-4889-a726-8f5d603f3ea1"));
            Description = (ITTTextBox)AddControl(new Guid("3b3e9990-db17-4f33-9be6-f0f9210ef20b"));
            labelDescription = (ITTLabel)AddControl(new Guid("ddcb9e7c-ae7b-4644-9c74-e43511bea9d7"));
            labelStore = (ITTLabel)AddControl(new Guid("b12c8c13-2a41-495d-888e-4fe3a0c6e759"));
            Store = (ITTObjectListBox)AddControl(new Guid("d691e47d-ec6c-4970-9e01-4a112338139a"));
            labelPrescriptionPaper = (ITTLabel)AddControl(new Guid("86792240-1724-471b-82e8-816e0db6689e"));
            PrescriptionPaper = (ITTObjectListBox)AddControl(new Guid("c211b861-387f-4872-892a-6490a5962bc5"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("e82a8186-f98f-4f66-b0c2-ba7f72eab9a1"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("08b3a9c3-3c89-4c02-ae67-608d2e694560"));
            StockPrescriptionOutMaterials = (ITTGrid)AddControl(new Guid("f978b7ac-fa6e-4ba3-9ef5-15deede74528"));
            MaterialStockPrescriptionOutMat = (ITTListBoxColumn)AddControl(new Guid("def98fef-a0f9-4e2c-be05-bd070b30e9fc"));
            AmountStockPrescriptionOutMat = (ITTTextBoxColumn)AddControl(new Guid("503859ea-fd5d-4061-998e-7ed1add6a8ec"));
            StockLevelTypeStockPrescriptionOutMat = (ITTListBoxColumn)AddControl(new Guid("d784dbea-6e65-48c3-b58d-4e7b59871d59"));
            StatusStockPrescriptionOutMat = (ITTEnumComboBoxColumn)AddControl(new Guid("0b3ad2aa-d1b2-497f-8cc3-b8ba2e3c4acf"));
            base.InitializeControls();
        }

        public StockPrescriptionOutForm() : base("STOCKPRESCRIPTIONOUT", "StockPrescriptionOutForm")
        {
        }

        protected StockPrescriptionOutForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}