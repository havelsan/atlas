
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
    public partial class FieldWorkForm_MaintenanceO : TTForm
    {
    /// <summary>
    /// Şipariş İşlemi
    /// </summary>
        protected TTObjectClasses.MaintenanceOrder _MaintenanceOrder
        {
            get { return (TTObjectClasses.MaintenanceOrder)_ttObject; }
        }

        protected ITTObjectListBox objFirm;
        protected ITTLabel ttlabel5;
        protected ITTDateTimePicker ttdatetimepicker2;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTLabel ttlabel4;
        protected ITTButton cmdSupplierDef;
        protected ITTLabel labelDescription;
        protected ITTDateTimePicker ttdatetimepicker3;
        protected ITTLabel ttlabel6;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTTextBox RequestNO;
        protected ITTEnumComboBox ttenumcombobox1;
        protected ITTLabel labelActionDate;
        protected ITTLabel ttlabel11;
        protected ITTRichTextBoxControl ttrichtextboxcontrol2;
        protected ITTDateTimePicker RequestDate;
        protected ITTTextBox tttextbox4;
        protected ITTLabel labelOrderName;
        protected ITTLabel ttlabel10;
        protected ITTObjectListBox SenderAccountancy;
        protected ITTTextBox OrderNO;
        protected ITTLabel labelFromResource;
        protected ITTDateTimePicker ActionDate;
        protected ITTObjectListBox FixedAsset;
        protected ITTObjectListBox OrderTypeList;
        protected ITTDateTimePicker ttdatetimepicker5;
        protected ITTTextBox tttextbox1;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTLabel labelFixedAsset;
        protected ITTLabel labelID;
        protected ITTLabel labelRequestDate;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel16;
        protected ITTLabel labelOrderNO;
        protected ITTLabel ttlabel1;
        protected ITTTabPage tttabpage2;
        protected ITTTextBox txtDemandNo;
        protected ITTTextBox txtLast;
        protected ITTTextBox txtProject;
        protected ITTTextBox txtDemand;
        protected ITTLabel ttlabel19;
        protected ITTLabel ttlabel20;
        protected ITTButton cmdForkDemand;
        protected ITTRichTextBoxControl ttrichtextboxcontrol3;
        protected ITTObjectListBox PurchaseItem;
        protected ITTLabel ttlabel8;
        protected ITTLabel ttlabel14;
        protected ITTLabel ttlabel13;
        protected ITTLabel ttlabel12;
        override protected void InitializeControls()
        {
            objFirm = (ITTObjectListBox)AddControl(new Guid("3fdfa9d9-5a4a-4fff-8cd7-3c66c4808b8c"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("b7314dad-7ea5-4e66-8ff4-49144725561a"));
            ttdatetimepicker2 = (ITTDateTimePicker)AddControl(new Guid("999a2a49-9556-4d37-bb0b-51af134fdbe4"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("ab95a8f9-9930-4c04-982e-771eb925450d"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("d41bc671-bfe1-410c-ad39-b85150a74a51"));
            cmdSupplierDef = (ITTButton)AddControl(new Guid("2a339954-0f02-4f7e-b5ff-d3146296161f"));
            labelDescription = (ITTLabel)AddControl(new Guid("fdb635a3-1674-4a0e-9f07-d65afc4b6e75"));
            ttdatetimepicker3 = (ITTDateTimePicker)AddControl(new Guid("d1f307a5-cb51-4745-85a5-df0394e54df8"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("b3ad4ae4-cb2a-4697-ae7e-e3cf239242c3"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("f288e350-dbf6-4d7f-bdfc-2dd525927999"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("34945c2c-9e3a-4885-bfac-aa58fec61c64"));
            RequestNO = (ITTTextBox)AddControl(new Guid("18abde03-ec60-45ed-963a-19d36af9716b"));
            ttenumcombobox1 = (ITTEnumComboBox)AddControl(new Guid("6bba798d-b823-4d57-bcab-740804dc1856"));
            labelActionDate = (ITTLabel)AddControl(new Guid("fca038c1-f8eb-42a0-bb88-14b0b662820f"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("264d5b82-1ca1-4c0a-9659-1ea673720c81"));
            ttrichtextboxcontrol2 = (ITTRichTextBoxControl)AddControl(new Guid("e89e7017-2711-4530-aa49-e40343260d7d"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("00202ce8-e667-4d54-a477-0e667469c619"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("1c8d53d9-f0b7-4dff-9c54-64e03db2184f"));
            labelOrderName = (ITTLabel)AddControl(new Guid("9d047365-c71d-4e2a-8aba-96455df572d6"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("60de7111-89aa-41c7-bd88-d791c787a8d1"));
            SenderAccountancy = (ITTObjectListBox)AddControl(new Guid("0d5595c6-22ac-4518-a9df-99145ee82a39"));
            OrderNO = (ITTTextBox)AddControl(new Guid("c7d21ade-b823-4f98-847a-d1383b287d2b"));
            labelFromResource = (ITTLabel)AddControl(new Guid("e4941a89-8bb6-4b25-b092-ca5565902607"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("b94fe366-5813-4695-8819-413046b6a401"));
            FixedAsset = (ITTObjectListBox)AddControl(new Guid("1ef40eda-e419-4ae2-9e01-1a7cfb93e632"));
            OrderTypeList = (ITTObjectListBox)AddControl(new Guid("70a1d9e4-38b9-46ae-8f38-751d0da91f80"));
            ttdatetimepicker5 = (ITTDateTimePicker)AddControl(new Guid("5d079eff-bf88-47ce-9d54-3c0717b423f6"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("a813ff40-99a7-42ee-82c0-db2a8eae5936"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("33799285-f480-4be3-89b2-63bd66088082"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("afd5c896-4bae-49e6-9290-01933e1d55bd"));
            labelID = (ITTLabel)AddControl(new Guid("fe59315e-5c67-4938-8a96-403cc0961aa5"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("df97e329-7367-40dc-83c5-a3f4b61ce226"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("2baf909b-0e6e-466f-a30b-a232c0f9cc49"));
            ttlabel16 = (ITTLabel)AddControl(new Guid("d560ea09-ad75-43c5-9136-93b145c0aa45"));
            labelOrderNO = (ITTLabel)AddControl(new Guid("1961e3cf-08aa-4180-8f18-e745b9cd13e7"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("2bc1b300-0615-453e-9676-61130fae1c2a"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("cb5f9ba8-0f6c-4f10-9eae-62244888e3f3"));
            txtDemandNo = (ITTTextBox)AddControl(new Guid("d79553ca-0183-4577-925b-6fadca3bccfe"));
            txtLast = (ITTTextBox)AddControl(new Guid("62535607-5c24-48dc-84dd-e42141e17646"));
            txtProject = (ITTTextBox)AddControl(new Guid("ff0304c6-a096-4add-971f-3763b1351f6e"));
            txtDemand = (ITTTextBox)AddControl(new Guid("4660de2f-86ed-4339-85a0-cdcc9ab33959"));
            ttlabel19 = (ITTLabel)AddControl(new Guid("d275947f-60df-443e-93cf-b531e1ffa784"));
            ttlabel20 = (ITTLabel)AddControl(new Guid("379e0ca8-554d-46c4-8acf-1db052d360f4"));
            cmdForkDemand = (ITTButton)AddControl(new Guid("f5353743-feba-49d6-a3cd-0a77f58eb26d"));
            ttrichtextboxcontrol3 = (ITTRichTextBoxControl)AddControl(new Guid("e5fdf920-e671-475e-b3b3-bb847a0b5f0f"));
            PurchaseItem = (ITTObjectListBox)AddControl(new Guid("e0643f06-2941-4f3c-9f0f-a67f5f4f79b0"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("fdeea558-bc36-4e1b-9bba-3cc17965bca7"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("99e08191-2ce1-409b-a998-71510d95c4a3"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("5e34874b-aab6-40be-a64b-164928c4f7ac"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("273575bf-0530-4b4e-88cf-b491b12547b1"));
            base.InitializeControls();
        }

        public FieldWorkForm_MaintenanceO() : base("MAINTENANCEORDER", "FieldWorkForm_MaintenanceO")
        {
        }

        protected FieldWorkForm_MaintenanceO(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}