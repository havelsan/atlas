
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
    /// E Reçete Detay Ekleme
    /// </summary>
    public partial class InpatientPresEReceteDetailForm : InpatientPrescriptionBaseForm
    {
    /// <summary>
    /// Yatan Hasta Reçetesi
    /// </summary>
        protected TTObjectClasses.InpatientPrescription _InpatientPrescription
        {
            get { return (TTObjectClasses.InpatientPrescription)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox3;
        protected ITTButton cmdAddSignedPresDesc;
        protected ITTButton cmdAddPresDesc;
        protected ITTTextBox PresDesc;
        protected ITTEnumComboBox presDescriptionType;
        protected ITTLabel ttlabel5;
        protected ITTGroupBox ttgroupbox2;
        protected ITTButton cmdAddSignedDiag;
        protected ITTObjectListBox Diag;
        protected ITTLabel ttlabel3;
        protected ITTButton cmdAddDiag;
        protected ITTGroupBox ttgroupbox1;
        protected ITTButton cmdAddSignedDrugDetail;
        protected ITTGrid DrugGrid;
        protected ITTCheckBoxColumn Select;
        protected ITTListBoxColumn Drug;
        protected ITTEnumComboBoxColumn Frequency;
        protected ITTTextBoxColumn DoseAmount;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBox DrugDescription;
        protected ITTLabel ttlabel1;
        protected ITTButton cmdAddDrugDetail;
        protected ITTEnumComboBox descriptionType;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel4;
        protected ITTTextBox EReceteNo;
        protected ITTLabel labelEReceteNo;
        override protected void InitializeControls()
        {
            ttgroupbox3 = (ITTGroupBox)AddControl(new Guid("832b90e3-1beb-4291-abbf-9c25743852f6"));
            cmdAddSignedPresDesc = (ITTButton)AddControl(new Guid("e372872b-549e-4464-9377-f173a5a02a92"));
            cmdAddPresDesc = (ITTButton)AddControl(new Guid("e40c4d39-0484-4ce1-a132-e769ffbc1845"));
            PresDesc = (ITTTextBox)AddControl(new Guid("6ca1a4f5-94bd-4d06-9aec-cfdf4421495d"));
            presDescriptionType = (ITTEnumComboBox)AddControl(new Guid("3de2a0fb-d085-4306-8c20-0e6e6018a9c5"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("7bd7c7c3-8a08-4163-bd99-341d12fa2bd5"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("350a5868-4d87-48a6-bc0d-528629db3f71"));
            cmdAddSignedDiag = (ITTButton)AddControl(new Guid("7edf6ad6-6f8d-4ff2-9db4-ea4ed3d6c853"));
            Diag = (ITTObjectListBox)AddControl(new Guid("63203ccf-d492-488c-821e-a9ea40de7153"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("1c05daee-4909-4a41-baa5-0a41f53ccb34"));
            cmdAddDiag = (ITTButton)AddControl(new Guid("674dd4e2-061a-4706-ab29-91325fdbd7b8"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("f2b5e5bd-06a2-4e60-9759-837285dcd827"));
            cmdAddSignedDrugDetail = (ITTButton)AddControl(new Guid("df002ac0-2595-43d9-b887-e71761e2087d"));
            DrugGrid = (ITTGrid)AddControl(new Guid("04588b04-6eb8-489f-ab9f-a0bf8c46c049"));
            Select = (ITTCheckBoxColumn)AddControl(new Guid("b4ec2d22-3253-46fe-89c1-4e009f0e6e91"));
            Drug = (ITTListBoxColumn)AddControl(new Guid("27e118b3-a18d-4c5b-ad8e-dfea57e74111"));
            Frequency = (ITTEnumComboBoxColumn)AddControl(new Guid("3376da33-b81f-4c7d-ad02-f24444b5a996"));
            DoseAmount = (ITTTextBoxColumn)AddControl(new Guid("bc0da608-fdc9-4d48-b7c4-8513bb211fa6"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("18f92628-f109-4cc5-83cd-846fa363f78f"));
            DrugDescription = (ITTTextBox)AddControl(new Guid("4da7c9d6-a01f-4f2d-9da0-fb242b70f617"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("4fd5b59d-a16b-4c86-a938-8fa2a86661ba"));
            cmdAddDrugDetail = (ITTButton)AddControl(new Guid("79e454cb-be08-4927-80a0-ed4c931e82d4"));
            descriptionType = (ITTEnumComboBox)AddControl(new Guid("d556bc05-8f93-4d66-a9c5-acf5def189d8"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("ebb81596-f9db-4b35-affa-417eee7dcc44"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("685b648f-ba77-42d5-aa40-b19febca7c94"));
            EReceteNo = (ITTTextBox)AddControl(new Guid("65f4ada8-500c-4ebc-9d33-b12e59346aa3"));
            labelEReceteNo = (ITTLabel)AddControl(new Guid("e367cf64-7b77-485c-b974-32b9ab91d8f0"));
            base.InitializeControls();
        }

        public InpatientPresEReceteDetailForm() : base("INPATIENTPRESCRIPTION", "InpatientPresEReceteDetailForm")
        {
        }

        protected InpatientPresEReceteDetailForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}