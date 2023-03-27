
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
    /// Firma Onarımı
    /// </summary>
    public partial class FirmRepairForm : RepairBaseForm
    {
    /// <summary>
    /// Onarım
    /// </summary>
        protected TTObjectClasses.Repair _Repair
        {
            get { return (TTObjectClasses.Repair)_ttObject; }
        }

        protected ITTObjectListBox ttobjectlistbox2;
        protected ITTButton cmdSupplierDef;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel10;
        protected ITTLabel ttlabel9;
        protected ITTDateTimePicker ttdatetimepicker3;
        protected ITTLabel ttlabel8;
        protected ITTDateTimePicker ttdatetimepicker2;
        protected ITTLabel labelRequestNO;
        protected ITTTextBox tttextbox1;
        protected ITTObjectListBox FromResource;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelRequestDate;
        protected ITTLabel ttlabel2;
        protected ITTTextBox RequestNO;
        protected ITTGrid ItemEquipmentsGrid;
        protected ITTTextBoxColumn ItemName;
        protected ITTTextBoxColumn Amount2;
        protected ITTListBoxColumn DistType;
        protected ITTCheckBoxColumn IsMissing;
        protected ITTCheckBoxColumn IsChanged;
        protected ITTCheckBoxColumn IsDamaged;
        protected ITTCheckBoxColumn Normal;
        protected ITTTextBoxColumn Comments;
        protected ITTTextBox tttextbox3;
        protected ITTLabel labelDescription;
        protected ITTLabel labelFromResource;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox FixedAsset;
        protected ITTLabel ttlabel5;
        protected ITTDateTimePicker RequestDate;
        protected ITTEnumComboBox RepairPlace;
        protected ITTTextBox Description;
        protected ITTTextBox tttextbox4;
        protected ITTLabel labelFixedAsset;
        protected ITTLabel ttlabel7;
        protected ITTButton cmdForkDemand;
        protected ITTLabel ttlabel19;
        protected ITTObjectListBox PurchaseItem;
        protected ITTRichTextBoxControl DetailDescription;
        protected ITTTextBox txtDemandNo;
        protected ITTLabel ttlabel11;
        protected ITTTextBox txtDemand;
        protected ITTLabel ttlabel12;
        protected ITTTextBox txtProject;
        protected ITTLabel ttlabel13;
        protected ITTTextBox txtLast;
        protected ITTLabel ttlabel14;
        override protected void InitializeControls()
        {
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("c72ccb03-7749-4e31-8304-cb9407001030"));
            cmdSupplierDef = (ITTButton)AddControl(new Guid("43d283c9-7fbd-4f03-9cbd-9aaebde50724"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("c0b585c0-0e90-4128-b045-e6cffa82cade"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("a110fcf7-3378-4a8e-82ee-57e1b4cf58dc"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("bc29d902-9a79-4915-a58a-af4bfd90f67d"));
            ttdatetimepicker3 = (ITTDateTimePicker)AddControl(new Guid("6de21da3-9600-4a36-b99f-68ab47888164"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("0d2763b4-9636-4ff9-a48d-7f30f62e4895"));
            ttdatetimepicker2 = (ITTDateTimePicker)AddControl(new Guid("4b3a9316-6f1e-4c80-a05e-afb011850468"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("1fe84a5c-d9b5-4f5c-ae4d-0375fb52205a"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("3af20742-57e5-4cd2-bbad-04a212037b80"));
            FromResource = (ITTObjectListBox)AddControl(new Guid("bf8846ff-933f-421a-863a-1f791260938a"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("a8eb98e2-639d-4975-86c0-21240ddc934d"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("d4e03d69-d737-4e27-99ae-33f0b8ef1eef"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("48027285-cb57-47bc-84a2-4da74fce8a5b"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("cd52d9be-1207-42bf-bc17-524a781a8c9f"));
            RequestNO = (ITTTextBox)AddControl(new Guid("4afff2a7-ddc0-4375-a343-6059fdaa9456"));
            ItemEquipmentsGrid = (ITTGrid)AddControl(new Guid("2602058c-16e9-4878-9221-68541b2f51ec"));
            ItemName = (ITTTextBoxColumn)AddControl(new Guid("488190f8-4c76-4b23-b80d-d14c7b247056"));
            Amount2 = (ITTTextBoxColumn)AddControl(new Guid("3009841c-6c27-4ff0-a10b-b7872c672c8a"));
            DistType = (ITTListBoxColumn)AddControl(new Guid("84727d31-05e9-49fa-8736-b02c76421988"));
            IsMissing = (ITTCheckBoxColumn)AddControl(new Guid("dec773aa-0572-41d6-9bfe-2b9076f2796c"));
            IsChanged = (ITTCheckBoxColumn)AddControl(new Guid("3f3be585-3bc6-4c03-b2a9-53e392fe8971"));
            IsDamaged = (ITTCheckBoxColumn)AddControl(new Guid("6f3052a4-97c0-43e7-9919-849e3de2902b"));
            Normal = (ITTCheckBoxColumn)AddControl(new Guid("96196ae8-000d-4e8e-a90e-42c79bb77306"));
            Comments = (ITTTextBoxColumn)AddControl(new Guid("b3a6e0c7-2ffa-45d0-92f7-e746dc9f8936"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("02f77793-5686-4d7e-a229-7b1ba9f22425"));
            labelDescription = (ITTLabel)AddControl(new Guid("d1071592-8abb-4949-905b-81ff8c77bf1f"));
            labelFromResource = (ITTLabel)AddControl(new Guid("e241e339-851d-4c90-868c-87e7e40b08a9"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("a471050e-6385-4a68-987e-8c3657c6eaba"));
            FixedAsset = (ITTObjectListBox)AddControl(new Guid("0b268e23-ec6c-4f7b-b474-bab9b67100b2"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("9f706326-c914-4905-a1b8-bb6421bae227"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("5bb1ae01-2807-4767-806e-bfdcec380517"));
            RepairPlace = (ITTEnumComboBox)AddControl(new Guid("1d26a3db-c088-45f6-b1de-cd1a9bda3844"));
            Description = (ITTTextBox)AddControl(new Guid("57500610-3ec5-479a-a12a-cd84a3445da0"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("b244b4a5-51a1-40ae-a4f3-d88fdb6e81f8"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("fb21413b-e81c-42b8-b047-e86cdc187fd8"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("1d9aa92a-7e63-4852-af4a-f737d0ce1cbd"));
            cmdForkDemand = (ITTButton)AddControl(new Guid("097876a7-ff29-4936-8c35-505f839e7934"));
            ttlabel19 = (ITTLabel)AddControl(new Guid("c85dc500-d707-4bfa-a37d-ddf05b156080"));
            PurchaseItem = (ITTObjectListBox)AddControl(new Guid("4e348e2a-8812-4838-b4a3-3e6cde7cf137"));
            DetailDescription = (ITTRichTextBoxControl)AddControl(new Guid("77abcfd5-2ecc-41f7-9afc-de1a5876e905"));
            txtDemandNo = (ITTTextBox)AddControl(new Guid("9b1b125f-df3c-4f36-b200-e906c401a997"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("ef64d4e0-664f-4093-a885-c0fc9673bbf4"));
            txtDemand = (ITTTextBox)AddControl(new Guid("90f3dd4c-7477-479a-aa92-a65c16db4b7c"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("a75e98aa-ec37-49df-ba12-d50d4208bf02"));
            txtProject = (ITTTextBox)AddControl(new Guid("34e3ba1b-1976-4150-bb72-cc11babfaebf"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("feebfa6f-062d-4096-aa13-331fa1bcaca8"));
            txtLast = (ITTTextBox)AddControl(new Guid("2511fa6e-6ad1-4665-a5b2-7d0f6076a916"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("da23cf05-eb89-4414-bea1-c07cc5984283"));
            base.InitializeControls();
        }

        public FirmRepairForm() : base("REPAIR", "FirmRepairForm")
        {
        }

        protected FirmRepairForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}