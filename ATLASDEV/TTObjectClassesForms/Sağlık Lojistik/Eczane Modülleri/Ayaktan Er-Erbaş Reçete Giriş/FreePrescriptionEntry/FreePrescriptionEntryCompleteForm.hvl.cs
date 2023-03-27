
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
    public partial class FreePrescriptionEntryCompleteForm : StockActionBaseForm
    {
    /// <summary>
    /// Ayaktan Er/Erbaş Reçete Giriş
    /// </summary>
        protected TTObjectClasses.FreePrescriptionEntry _FreePrescriptionEntry
        {
            get { return (TTObjectClasses.FreePrescriptionEntry)_ttObject; }
        }

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
        protected ITTGrid FreePrescriptionEntryDetails;
        protected ITTListBoxColumn MaterialFreePrescriptionEntryDet;
        protected ITTTextBoxColumn AmountFreePrescriptionEntryDet;
        protected ITTListBoxColumn StockLevelTypeFreePrescriptionEntryDet;
        override protected void InitializeControls()
        {
            PatientNameLabel = (ITTLabel)AddControl(new Guid("0ea309a0-1938-4523-bbad-97b1dc4e6cd7"));
            PatientName = (ITTTextBox)AddControl(new Guid("3339cc67-712c-4fe1-b149-474df04b2fb5"));
            UniqueNo = (ITTTextBox)AddControl(new Guid("058a0de4-1945-422f-a78b-6240cc2dcd29"));
            StockActionID = (ITTTextBox)AddControl(new Guid("7a63cd02-7f8d-4032-bf49-c4a5af56f56f"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("5476ccb8-79be-4896-9e2b-6c557c0db8ab"));
            cmdFindPatient = (ITTButton)AddControl(new Guid("65052149-82ae-4850-aa99-28346dbf45fb"));
            labelStore = (ITTLabel)AddControl(new Guid("4cdb758e-8228-4707-bf11-844c67276fd7"));
            Store = (ITTObjectListBox)AddControl(new Guid("5e55575e-0acd-4c71-85ea-23d2be2cd73d"));
            labelTransactionDate = (ITTLabel)AddControl(new Guid("f18d1d77-3b1f-4e1f-89f7-8b8c6bc5a3d6"));
            TransactionDate = (ITTDateTimePicker)AddControl(new Guid("92419845-ac79-45d2-89e1-a249d336fd29"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("56452628-ca61-4710-999a-48cc1dc0d426"));
            FreePrescriptionEntryDetails = (ITTGrid)AddControl(new Guid("bbc84755-867d-4561-bcac-58a01ff55a51"));
            MaterialFreePrescriptionEntryDet = (ITTListBoxColumn)AddControl(new Guid("274c7fea-8c8f-44b3-8138-237c7056273c"));
            AmountFreePrescriptionEntryDet = (ITTTextBoxColumn)AddControl(new Guid("851d8eb5-6daf-471d-aaac-8bee68ed8b15"));
            StockLevelTypeFreePrescriptionEntryDet = (ITTListBoxColumn)AddControl(new Guid("6d223121-5ba0-40ff-bd28-8d3541e59266"));
            base.InitializeControls();
        }

        public FreePrescriptionEntryCompleteForm() : base("FREEPRESCRIPTIONENTRY", "FreePrescriptionEntryCompleteForm")
        {
        }

        protected FreePrescriptionEntryCompleteForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}