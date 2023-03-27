
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
    /// Kalibrasyon (Firma) [Stok Numaralı]
    /// </summary>
    public partial class MaterialCalibrationFirmForm : CalibrationBaseForm
    {
    /// <summary>
    /// Kalibrasyon [Stok Numaralı]
    /// </summary>
        protected TTObjectClasses.MaterialCalibration _MaterialCalibration
        {
            get { return (TTObjectClasses.MaterialCalibration)_ttObject; }
        }

        protected ITTTextBox RequestNO;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGroupBox ttgroupbox2;
        protected ITTCheckBox FullCalibration;
        protected ITTCheckBox LimitedCalibration;
        protected ITTCheckBox NoNeedCalibration;
        protected ITTCheckBox NotCalibration;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTGrid ttgrid2;
        protected ITTTextBoxColumn ItemName;
        protected ITTTextBoxColumn Amount;
        protected ITTLabel ttlabel3;
        protected ITTGrid ttgrid1;
        protected ITTListBoxColumn Calibrator;
        protected ITTTextBoxColumn Traceability;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel9;
        protected ITTGrid CalibrationTests;
        protected ITTListBoxColumn CalibrationTestDefinition;
        protected ITTTextBoxColumn ApplicableTestCount;
        protected ITTTextBoxColumn ExistingTestCount;
        protected ITTButtonColumn cmdReport;
        protected ITTTabPage tttabpage2;
        protected ITTTextBox tttextbox6;
        protected ITTObjectListBox ttobjectlistbox3;
        protected ITTObjectListBox ttobjectlistbox2;
        protected ITTTextBox tttextbox5;
        protected ITTTextBox tttextbox4;
        protected ITTTextBox tttextbox3;
        protected ITTTextBox tttextbox2;
        protected ITTLabel ttlabel12;
        protected ITTLabel ttlabel11;
        protected ITTLabel ttlabel10;
        protected ITTDateTimePicker StartDate;
        protected ITTLabel ttlabel8;
        protected ITTLabel ttlabel19;
        protected ITTGroupBox ttgroupbox3;
        protected ITTTextBox tttextbox10;
        protected ITTTextBox tttextbox9;
        protected ITTTextBox tttextbox7;
        protected ITTLabel ttlabel34;
        protected ITTLabel ttlabel35;
        protected ITTLabel ttlabel36;
        protected ITTLabel ttlabel37;
        protected ITTLabel ttlabel38;
        protected ITTLabel ttlabel39;
        protected ITTLabel ttlabel40;
        protected ITTLabel ttlabel41;
        protected ITTTextBox tttextbox8;
        protected ITTLabel labelStartDate;
        protected ITTLabel ttlabel7;
        protected ITTLabel ttlabel6;
        protected ITTTabPage tttabpage3;
        protected ITTCheckBox NotCalibreReason1;
        protected ITTCheckBox NotCalibreReason3;
        protected ITTCheckBox NotCalibreReason2;
        protected ITTCheckBox NotCalibreReason4;
        protected ITTCheckBox NotCalibreReason5;
        protected ITTTextBox NotCalibreReasonDesc;
        protected ITTLabel labelNotCalibreReasonDesc;
        protected ITTTabPage DemandTabPage;
        protected ITTRichTextBoxControl ttrichtextboxcontrol2;
        protected ITTButton ttbutton1;
        protected ITTObjectListBox ttobjectlistbox5;
        protected ITTLabel ttlabel22;
        protected ITTLabel ttlabel23;
        protected ITTTextBox txtProject;
        protected ITTLabel ttlabel26;
        protected ITTTextBox txtDemandNo;
        protected ITTLabel ttlabel25;
        protected ITTLabel ttlabel21;
        protected ITTTextBox txtDemand;
        protected ITTLabel ttlabel20;
        protected ITTTextBox txtLast;
        protected ITTButton cmdSupplierDef;
        protected ITTDateTimePicker ttdatetimepicker2;
        protected ITTLabel ttlabel27;
        protected ITTObjectListBox ttobjectlistbox6;
        protected ITTLabel ttlabel29;
        protected ITTLabel ttlabel28;
        protected ITTDateTimePicker ttdatetimepicker3;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox Description;
        protected ITTLabel labelRequestNO;
        protected ITTObjectListBox ttobjectlistbox4;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel5;
        protected ITTLabel labelDescription;
        protected ITTObjectListBox FixedAssetDefinition;
        protected ITTLabel labelFixedAsset;
        override protected void InitializeControls()
        {
            RequestNO = (ITTTextBox)AddControl(new Guid("be16e3ee-eadd-4335-b84f-0d61bd7c591c"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("80acbc19-b632-4641-a1ad-73bcedb0853d"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("7e098036-93cf-4981-89b5-d8c10e0615a0"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("7eaf6af8-8776-4005-9a98-33ce877203db"));
            FullCalibration = (ITTCheckBox)AddControl(new Guid("10497aa7-dd04-4a85-8c90-5edc7e9bed95"));
            LimitedCalibration = (ITTCheckBox)AddControl(new Guid("b97ad68d-d032-406f-a4b8-629e08c7be00"));
            NoNeedCalibration = (ITTCheckBox)AddControl(new Guid("bd41f7d7-91e3-40f7-8b94-f64724d34c68"));
            NotCalibration = (ITTCheckBox)AddControl(new Guid("230f98ba-e857-4cd4-a583-2a4df96d98e6"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("80a29aba-add8-4dac-9f2c-4c4be555976b"));
            ttgrid2 = (ITTGrid)AddControl(new Guid("ce0c2cfd-a7bf-4468-9f99-2060008663f7"));
            ItemName = (ITTTextBoxColumn)AddControl(new Guid("72dd1502-ebee-4670-b90e-bf636ee8a444"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("48bd9a86-4143-4762-a101-ed10b5d2e28b"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("8cca2a1c-5d34-41d2-94b7-dd8ef371ac82"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("0ca333e5-fcad-4cee-8ba0-5bb4841664d5"));
            Calibrator = (ITTListBoxColumn)AddControl(new Guid("18898840-ef42-4cb9-b0e2-4c5e8247e55d"));
            Traceability = (ITTTextBoxColumn)AddControl(new Guid("f4ff1f96-d82a-4fed-bca4-7c05f037aac0"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("ee237075-684d-453d-8424-eaccfc0420de"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("fa564a08-5624-4a49-a177-87e11b19f664"));
            CalibrationTests = (ITTGrid)AddControl(new Guid("7122a0d6-8ee7-41bb-ad10-0b9096d9b053"));
            CalibrationTestDefinition = (ITTListBoxColumn)AddControl(new Guid("4051471d-429a-4ae7-9023-4a852f250229"));
            ApplicableTestCount = (ITTTextBoxColumn)AddControl(new Guid("810460a2-08fb-4677-a4a3-c6bbddf566ac"));
            ExistingTestCount = (ITTTextBoxColumn)AddControl(new Guid("e781d86c-688c-4874-89e5-e62a9e6d1b3e"));
            cmdReport = (ITTButtonColumn)AddControl(new Guid("86fb2589-8fac-4808-a271-8ff882a327e1"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("e39904fe-3182-44be-834c-a505f099885a"));
            tttextbox6 = (ITTTextBox)AddControl(new Guid("c7e271d3-1b11-413c-ad9c-e7434a857753"));
            ttobjectlistbox3 = (ITTObjectListBox)AddControl(new Guid("e3b54d1c-52d2-4561-af34-ae1f9451c0a6"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("b1b264c3-cfcc-4ccf-9222-b5703e8b6a64"));
            tttextbox5 = (ITTTextBox)AddControl(new Guid("de758931-17c6-42dc-9f5e-7601c20878fa"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("32388030-da97-435b-8ccc-2a0235f304b0"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("6532bedc-4c83-496f-aeae-9ff980eab1c3"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("7df33803-109f-4412-ab0d-57b20f2a7ece"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("8df8133c-7233-4b4d-99e2-5412a23cdb86"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("949be7a3-101b-4230-90cf-568024bfcc97"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("c89c2701-41ec-44d1-a7f2-65f4af55451b"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("95181db9-4a6a-4139-a0b7-24416516af96"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("69570dde-644b-42c3-b169-da4703250a5a"));
            ttlabel19 = (ITTLabel)AddControl(new Guid("8e456d36-79c7-4190-b0b0-648c723eb94c"));
            ttgroupbox3 = (ITTGroupBox)AddControl(new Guid("768801b7-96f2-4a81-9aa7-6d2f19ee2ffc"));
            tttextbox10 = (ITTTextBox)AddControl(new Guid("39d95a55-8980-430a-8f1f-6f9c2c149220"));
            tttextbox9 = (ITTTextBox)AddControl(new Guid("91dbb0d6-cfcd-4e32-8712-b028061f8d78"));
            tttextbox7 = (ITTTextBox)AddControl(new Guid("c2a782ad-ff24-405f-aa8d-49667a086503"));
            ttlabel34 = (ITTLabel)AddControl(new Guid("842e1561-434f-40ed-ab8e-47bac43384ed"));
            ttlabel35 = (ITTLabel)AddControl(new Guid("06249a97-4c86-4327-b41d-8eaf732a4905"));
            ttlabel36 = (ITTLabel)AddControl(new Guid("d2abdb5d-9b32-476c-b4f0-a843ef16deef"));
            ttlabel37 = (ITTLabel)AddControl(new Guid("4268ea1d-7761-4f52-bd7a-612c57ef657b"));
            ttlabel38 = (ITTLabel)AddControl(new Guid("507eea9c-a576-4e9d-8ee3-07974c798395"));
            ttlabel39 = (ITTLabel)AddControl(new Guid("51e8f790-466d-45a0-9f5c-a89f07405fc9"));
            ttlabel40 = (ITTLabel)AddControl(new Guid("2bfe9a0d-2974-4fc3-bc5b-dda54a1cba15"));
            ttlabel41 = (ITTLabel)AddControl(new Guid("ec6fa24d-10f7-4be7-aa76-1f5657f77272"));
            tttextbox8 = (ITTTextBox)AddControl(new Guid("9f7bd426-1647-4861-8e81-d78c7eb52e6d"));
            labelStartDate = (ITTLabel)AddControl(new Guid("cedd6f59-ec55-451a-9184-915ed0d939f6"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("9c2847f6-0a62-4c2c-bfa7-9442e9df7333"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("69bdce39-2374-428a-8f76-8ea392a975d3"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("ec9f10b8-3c00-4ada-ae99-ac75326c1cc8"));
            NotCalibreReason1 = (ITTCheckBox)AddControl(new Guid("93f95eb3-247a-4917-b119-ce3cb2709580"));
            NotCalibreReason3 = (ITTCheckBox)AddControl(new Guid("7adb21ef-be00-48f4-94ec-1269fa073dff"));
            NotCalibreReason2 = (ITTCheckBox)AddControl(new Guid("77df0347-652c-4eec-af28-14be51373a47"));
            NotCalibreReason4 = (ITTCheckBox)AddControl(new Guid("f00d873a-e6fb-4077-8d40-ddd62957baf4"));
            NotCalibreReason5 = (ITTCheckBox)AddControl(new Guid("748deb15-d770-430d-9c92-a71882057f27"));
            NotCalibreReasonDesc = (ITTTextBox)AddControl(new Guid("c1ca4004-caf6-416d-b1e9-0e6b524d98e9"));
            labelNotCalibreReasonDesc = (ITTLabel)AddControl(new Guid("6763b317-237d-4b98-bd90-aa8e6ced4f05"));
            DemandTabPage = (ITTTabPage)AddControl(new Guid("26312af0-c258-4f3d-82ed-8362f3103bce"));
            ttrichtextboxcontrol2 = (ITTRichTextBoxControl)AddControl(new Guid("0eff3adb-da91-45bc-826f-f4020e66577f"));
            ttbutton1 = (ITTButton)AddControl(new Guid("fa766c8e-0ab0-4183-9df7-badd96b27f6e"));
            ttobjectlistbox5 = (ITTObjectListBox)AddControl(new Guid("42d005b1-a99c-4074-845c-805d24256e0e"));
            ttlabel22 = (ITTLabel)AddControl(new Guid("e72f566b-57b2-4771-b1ee-004c9b560267"));
            ttlabel23 = (ITTLabel)AddControl(new Guid("5dfb1149-922f-4baf-9e03-901a8acd03ec"));
            txtProject = (ITTTextBox)AddControl(new Guid("b7568ed3-de62-4530-911f-2b1793ab868a"));
            ttlabel26 = (ITTLabel)AddControl(new Guid("821e901a-da0f-47d2-a20f-fb3613f726a6"));
            txtDemandNo = (ITTTextBox)AddControl(new Guid("4aab15d1-3bd6-461d-9a57-b3c2ac96eb0d"));
            ttlabel25 = (ITTLabel)AddControl(new Guid("7f76bfad-f097-4bc4-94fe-9de9f3b2c26f"));
            ttlabel21 = (ITTLabel)AddControl(new Guid("a7a017d2-d18d-48c7-a469-be7f6cb33602"));
            txtDemand = (ITTTextBox)AddControl(new Guid("7f2b0735-e918-46dd-b698-5a26ce0a9120"));
            ttlabel20 = (ITTLabel)AddControl(new Guid("1924db79-5382-4ac0-ab2a-54871ada90f8"));
            txtLast = (ITTTextBox)AddControl(new Guid("f534f3eb-042a-4ede-aeab-b4c4639d48df"));
            cmdSupplierDef = (ITTButton)AddControl(new Guid("611d6260-b548-44a0-9b03-fbdb2d148252"));
            ttdatetimepicker2 = (ITTDateTimePicker)AddControl(new Guid("39bbb103-9066-4ab6-bacb-65ce88ed47ea"));
            ttlabel27 = (ITTLabel)AddControl(new Guid("fac7bea0-1f23-44d2-b608-b20de8ef6a6d"));
            ttobjectlistbox6 = (ITTObjectListBox)AddControl(new Guid("2d398fac-fb83-4354-90a2-f7863671c5fa"));
            ttlabel29 = (ITTLabel)AddControl(new Guid("e15265c1-64fc-48c7-8a35-ecf7fc78d2d0"));
            ttlabel28 = (ITTLabel)AddControl(new Guid("dabfc8d0-b3de-48b1-a957-a23e791826cd"));
            ttdatetimepicker3 = (ITTDateTimePicker)AddControl(new Guid("84e6cefd-64fc-47b1-8c38-616e66580c85"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("5e00f441-9216-44f1-bcde-23765f97bc3c"));
            Description = (ITTTextBox)AddControl(new Guid("2a1c3127-2320-4354-aa98-696c51375acd"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("81a04df3-fb41-4d1e-9697-868f9abef3c9"));
            ttobjectlistbox4 = (ITTObjectListBox)AddControl(new Guid("bda60b44-7a8d-42cb-994f-0b6b5a7af9dc"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("28c8a4fc-1dff-4e75-9a80-a195d85ca122"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("a40e2925-d093-4d08-9847-a27b0267c152"));
            labelDescription = (ITTLabel)AddControl(new Guid("56c36844-3578-4e39-b441-5deee0474f0f"));
            FixedAssetDefinition = (ITTObjectListBox)AddControl(new Guid("24f98def-3fd4-4de7-bd65-91d65862d4f4"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("18d8e365-bfde-4264-8278-636f1cdc83fa"));
            base.InitializeControls();
        }

        public MaterialCalibrationFirmForm() : base("MATERIALCALIBRATION", "MaterialCalibrationFirmForm")
        {
        }

        protected MaterialCalibrationFirmForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}