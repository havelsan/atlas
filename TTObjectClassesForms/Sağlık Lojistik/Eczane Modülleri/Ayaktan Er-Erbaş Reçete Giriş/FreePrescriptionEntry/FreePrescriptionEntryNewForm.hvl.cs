
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
    /// Ayaktan Er/Erbaş Reçete Giriş 
    /// </summary>
    public partial class FreePrescriptionEntryNewForm : StockActionBaseForm
    {
    /// <summary>
    /// Ayaktan Er/Erbaş Reçete Giriş
    /// </summary>
        protected TTObjectClasses.FreePrescriptionEntry _FreePrescriptionEntry
        {
            get { return (TTObjectClasses.FreePrescriptionEntry)_ttObject; }
        }

        protected ITTGrid FreePrescriptionEntryDetails;
        protected ITTListBoxColumn MaterialFreePrescriptionEntryDet;
        protected ITTTextBoxColumn AmountFreePrescriptionEntryDet;
        protected ITTListBoxColumn StockLevelTypeFreePrescriptionEntryDet;
        protected ITTLabel PatientNameLabel;
        protected ITTTextBox PatientName;
        protected ITTTextBox UniqueNo;
        protected ITTTextBox StockActionID;
        protected ITTLabel ttlabel1;
        protected ITTButton cmdFindPatient;
        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTLabel labelTransactionDate;
        protected ITTDateTimePicker TransactionDate;
        protected ITTLabel labelStockActionID;
        override protected void InitializeControls()
        {
            FreePrescriptionEntryDetails = (ITTGrid)AddControl(new Guid("268b1ff0-6278-4585-b499-7eee9b47a266"));
            MaterialFreePrescriptionEntryDet = (ITTListBoxColumn)AddControl(new Guid("69b6c563-f1e2-4e09-bcca-c4f33f69af22"));
            AmountFreePrescriptionEntryDet = (ITTTextBoxColumn)AddControl(new Guid("2ea9ec27-2dac-4de8-92fc-35f61b48e250"));
            StockLevelTypeFreePrescriptionEntryDet = (ITTListBoxColumn)AddControl(new Guid("1c849f7d-5bc6-4493-b3c0-9e8e6064653f"));
            PatientNameLabel = (ITTLabel)AddControl(new Guid("c778a7f3-be67-4f8c-ac91-33231f92bcfb"));
            PatientName = (ITTTextBox)AddControl(new Guid("ef4669ad-46e0-4b82-9f57-3ca9a158c70a"));
            UniqueNo = (ITTTextBox)AddControl(new Guid("90e3de2e-32fd-495b-82cb-ed88a8059543"));
            StockActionID = (ITTTextBox)AddControl(new Guid("e5752ce0-aa20-4bbb-9498-b95636d9c810"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("431fce80-f971-4104-9b1f-89ade9bd9ff0"));
            cmdFindPatient = (ITTButton)AddControl(new Guid("7582e2b0-31c4-4a59-ab12-9f81d021faa6"));
            labelStore = (ITTLabel)AddControl(new Guid("af4ddeff-0f90-4d76-b302-eaf671fe0be1"));
            Store = (ITTObjectListBox)AddControl(new Guid("8639f661-b591-4437-a7c7-1b40a8635afb"));
            labelTransactionDate = (ITTLabel)AddControl(new Guid("e82d8381-6e47-4d04-8c2b-9732b74a1726"));
            TransactionDate = (ITTDateTimePicker)AddControl(new Guid("8db7a0f1-c246-4833-a70f-ea04a8041c67"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("45b7ebd4-c28c-4f55-80a5-653acc4972e5"));
            base.InitializeControls();
        }

        public FreePrescriptionEntryNewForm() : base("FREEPRESCRIPTIONENTRY", "FreePrescriptionEntryNewForm")
        {
        }

        protected FreePrescriptionEntryNewForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}