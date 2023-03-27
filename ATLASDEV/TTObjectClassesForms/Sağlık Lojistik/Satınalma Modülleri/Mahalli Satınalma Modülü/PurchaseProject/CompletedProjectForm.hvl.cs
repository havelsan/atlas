
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
    /// Sonuçlanmış İhale Bilgileri
    /// </summary>
    public partial class CompletedProjectForm : TTForm
    {
    /// <summary>
    /// Mahalli Satınalma Ana Sınıfı
    /// </summary>
        protected TTObjectClasses.PurchaseProject _PurchaseProject
        {
            get { return (TTObjectClasses.PurchaseProject)_ttObject; }
        }

        protected ITTButton cmdContractsForm;
        protected ITTButton cmdDetailingForm;
        protected ITTTextBox PurchaseProjectNO;
        protected ITTTextBox ActAttribute;
        protected ITTTextBox ConfirmNO;
        protected ITTTextBox ActDefine;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel9;
        protected ITTObjectListBox PurchaseType;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel10;
        protected ITTEnumComboBox EvaluationType;
        protected ITTGrid ProjectDetailsGrid;
        protected ITTListBoxColumn PurchaseItem;
        protected ITTTextBoxColumn GMDNNo;
        protected ITTTextBoxColumn NSN;
        protected ITTTextBoxColumn Amount;
        protected ITTButtonColumn Details;
        protected ITTEnumComboBox PurchaseMainType;
        protected ITTLabel ttlabel2;
        protected ITTEnumComboBox AnnounceTypeandCount;
        protected ITTDateTimePicker ConfirmDate;
        protected ITTLabel labelConfirmNO;
        protected ITTLabel labelConfirmDate;
        protected ITTLabel labelPurchaseProjectNO;
        protected ITTLabel ttlabel5;
        override protected void InitializeControls()
        {
            cmdContractsForm = (ITTButton)AddControl(new Guid("beae7131-c49b-4d07-8b72-74a347153ba7"));
            cmdDetailingForm = (ITTButton)AddControl(new Guid("1aaed65a-f8f7-4a03-b477-4bd1f73dbab2"));
            PurchaseProjectNO = (ITTTextBox)AddControl(new Guid("4bd3c316-e471-43c7-820b-01026a57d4ff"));
            ActAttribute = (ITTTextBox)AddControl(new Guid("4ba81a34-c46b-4d84-bfe3-a219839edf50"));
            ConfirmNO = (ITTTextBox)AddControl(new Guid("039348ba-573e-4c37-a9fb-afb956018d64"));
            ActDefine = (ITTTextBox)AddControl(new Guid("1d7653dd-cf5b-4c60-838b-fa746914273c"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("34cdfed5-4ef9-4971-b81f-07c3e0870a81"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("57dc8500-ed43-44bb-997e-07e3a4eca1af"));
            PurchaseType = (ITTObjectListBox)AddControl(new Guid("e219bfbf-48d6-4038-88fd-087ed027c4d6"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("24303175-fa99-47f9-805a-1d300505ab5f"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("57151150-bdb0-44f3-88ac-27862f95d935"));
            EvaluationType = (ITTEnumComboBox)AddControl(new Guid("cc02859a-663d-4d48-b355-2c896ea96f5b"));
            ProjectDetailsGrid = (ITTGrid)AddControl(new Guid("300f23ef-c68c-4366-8144-393f50f6335f"));
            PurchaseItem = (ITTListBoxColumn)AddControl(new Guid("0ae30a42-1e3b-45c9-9769-a1ab054995d8"));
            GMDNNo = (ITTTextBoxColumn)AddControl(new Guid("520e9838-0502-47ef-be89-a7de4103aa45"));
            NSN = (ITTTextBoxColumn)AddControl(new Guid("6a315935-4e14-49b3-abc4-59e0c43d5c8d"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("90903c5b-eee5-4751-bc49-97c1b4727149"));
            Details = (ITTButtonColumn)AddControl(new Guid("c7143fc1-475f-482e-82d4-9d65d1d9471b"));
            PurchaseMainType = (ITTEnumComboBox)AddControl(new Guid("9d5c2cba-cb94-41cd-ae94-6166567eb50f"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("2205fa85-8cb8-418b-8000-95a2415019b4"));
            AnnounceTypeandCount = (ITTEnumComboBox)AddControl(new Guid("264062a1-c6cc-4b29-b99a-98d75fa2676c"));
            ConfirmDate = (ITTDateTimePicker)AddControl(new Guid("69a718ea-a023-4944-946a-a729dfccb4f5"));
            labelConfirmNO = (ITTLabel)AddControl(new Guid("5c824421-750d-4ac5-95b9-a768b6015b24"));
            labelConfirmDate = (ITTLabel)AddControl(new Guid("9a0ab2d4-5cde-4894-a5df-bc0b89b288b5"));
            labelPurchaseProjectNO = (ITTLabel)AddControl(new Guid("f5cfc70d-f641-496f-96e4-c92941a477d4"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("6f1ad1c6-dc05-4383-adf7-d3baf6d1e825"));
            base.InitializeControls();
        }

        public CompletedProjectForm() : base("PURCHASEPROJECT", "CompletedProjectForm")
        {
        }

        protected CompletedProjectForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}