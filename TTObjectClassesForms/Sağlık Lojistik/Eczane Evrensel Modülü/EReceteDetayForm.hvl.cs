
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
    /// E Reçete Detayı
    /// </summary>
    public partial class EReceteDetayForm : TTUnboundForm
    {
        protected ITTGroupBox ttgroupbox1;
        protected ITTGrid ilacGrid;
        protected ITTCheckBoxColumn Check;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn Name;
        protected ITTTextBoxColumn Frequency;
        protected ITTTextBoxColumn DoseAmount;
        protected ITTTextBoxColumn Day;
        protected ITTTextBoxColumn PeryodUnit;
        protected ITTTextBoxColumn Amount;
        protected ITTButton cmdAddSignedDrugDetail;
        protected ITTLabel ttlabel1;
        protected ITTTextBox DrugDescription;
        protected ITTEnumComboBox descriptionType;
        protected ITTLabel ttlabel2;
        protected ITTButton cmdAddDrugDetail;
        protected ITTButton cmdClose;
        protected ITTGroupBox ttgroupbox2;
        protected ITTObjectListBox Diag;
        protected ITTLabel ttlabel3;
        protected ITTButton cmdAddDiag;
        protected ITTButton cmdAddSignedDiag;
        protected ITTGroupBox ttgroupbox3;
        protected ITTButton cmdAddPresDesc;
        protected ITTTextBox PresDesc;
        protected ITTEnumComboBox presDescriptionType;
        protected ITTLabel ttlabel10;
        protected ITTButton cmdAddSignedPresDesc;
        protected ITTTextBox EReceteNo;
        protected ITTTextBox edtPassword;
        protected ITTTextBox edtDoktorTC;
        protected ITTLabel labelEReceteNo;
        override protected void InitializeControls()
        {
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("25618805-5233-48b9-b1da-2fe746f3b430"));
            ilacGrid = (ITTGrid)AddControl(new Guid("e7a268ce-2b8d-4620-9d81-86799048d018"));
            Check = (ITTCheckBoxColumn)AddControl(new Guid("c4983eab-7ea4-4671-92a8-1014f753dea2"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("611ba234-6abe-4688-8e2b-959d233b81ac"));
            Name = (ITTTextBoxColumn)AddControl(new Guid("0d704450-aa1f-4d2d-a80d-694dd8dc1eb8"));
            Frequency = (ITTTextBoxColumn)AddControl(new Guid("793b6ee3-fa4f-4146-bcc7-9c9a8736ea3b"));
            DoseAmount = (ITTTextBoxColumn)AddControl(new Guid("bb94ea0e-7e14-4976-8f50-8c36b11ab5b7"));
            Day = (ITTTextBoxColumn)AddControl(new Guid("239afb76-f345-4945-bbe2-3fe5222f3fe0"));
            PeryodUnit = (ITTTextBoxColumn)AddControl(new Guid("08338343-77b0-4003-a6a7-9cad4197cd05"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("2c234d0a-5d4b-42c9-9865-583c64ba9eb8"));
            cmdAddSignedDrugDetail = (ITTButton)AddControl(new Guid("e645bc0d-5ecb-4397-8aa7-9825860c315e"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("23594271-e32c-4f09-bafa-97253b4abb10"));
            DrugDescription = (ITTTextBox)AddControl(new Guid("4f635970-c81e-43ee-9638-27fdb8a77854"));
            descriptionType = (ITTEnumComboBox)AddControl(new Guid("a0f54cf8-b754-4fe2-901d-32b520739a4e"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("949d2db5-8e00-4681-980e-8f05c3225285"));
            cmdAddDrugDetail = (ITTButton)AddControl(new Guid("f686267d-3d4b-45f2-a0fe-0560a5c54c1c"));
            cmdClose = (ITTButton)AddControl(new Guid("b624618b-b4ba-43f7-8776-67dd13656e3f"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("71601369-f8db-48cc-bbd3-022772b32581"));
            Diag = (ITTObjectListBox)AddControl(new Guid("4ecab181-40df-492c-805b-c9450431035b"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("65d3b35f-ed91-4738-adda-a40111b79b33"));
            cmdAddDiag = (ITTButton)AddControl(new Guid("5ed53974-d103-40be-b4c2-357ef187aeaa"));
            cmdAddSignedDiag = (ITTButton)AddControl(new Guid("86e23ed4-a17a-4c5f-97af-47247fff929d"));
            ttgroupbox3 = (ITTGroupBox)AddControl(new Guid("2c2ae93e-55af-4adc-ad00-e14dea975363"));
            cmdAddPresDesc = (ITTButton)AddControl(new Guid("8876bf87-763d-4e8e-bc53-0118001f64f7"));
            PresDesc = (ITTTextBox)AddControl(new Guid("56bbc6bf-f8d0-485b-ad78-56fb21e30722"));
            presDescriptionType = (ITTEnumComboBox)AddControl(new Guid("e26cf0f0-a721-4b37-94c2-87d2a3ee6f12"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("13840fcb-65b7-4bdf-bd9b-fb964bc1cc72"));
            cmdAddSignedPresDesc = (ITTButton)AddControl(new Guid("3eba0a92-5552-4207-a06e-e641da42b515"));
            EReceteNo = (ITTTextBox)AddControl(new Guid("b6bbb1ae-013f-4630-af56-a53e0c236038"));
            edtPassword = (ITTTextBox)AddControl(new Guid("4d3c6fb6-dc23-4d53-a0e7-4ce78a3aa22f"));
            edtDoktorTC = (ITTTextBox)AddControl(new Guid("28d8ea23-2e5e-4663-98e1-64ebb223c2ac"));
            labelEReceteNo = (ITTLabel)AddControl(new Guid("372d084e-90a5-49a3-aa13-d4c3e96db243"));
            base.InitializeControls();
        }

        public EReceteDetayForm() : base("EReceteDetayForm")
        {
        }

        protected EReceteDetayForm(string formDefName) : base(formDefName)
        {
        }
    }
}