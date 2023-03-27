
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
    /// Son Kontrol
    /// </summary>
    public partial class LastControlForm_MaintenanceO : TTForm
    {
    /// <summary>
    /// Şipariş İşlemi
    /// </summary>
        protected TTObjectClasses.MaintenanceOrder _MaintenanceOrder
        {
            get { return (TTObjectClasses.MaintenanceOrder)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage2;
        protected ITTTextBox RequestNO;
        protected ITTTextBox RepairWorkLoad;
        protected ITTLabel labelRepairWorkLoad;
        protected ITTTextBox SpecialWorkAmount;
        protected ITTLabel labelSpecialWorkAmount;
        protected ITTTextBox tttextbox4;
        protected ITTTextBox ManufacturingAmount;
        protected ITTLabel ttlabel10;
        protected ITTLabel labelManufacturingAmount;
        protected ITTObjectListBox SenderAccountancy;
        protected ITTObjectListBox FixedAssetDefinition;
        protected ITTLabel labelFromResource;
        protected ITTLabel labelFixedAssetDefinition;
        protected ITTObjectListBox OrderTypeList;
        protected ITTLabel ttlabel2;
        protected ITTTextBox tttextbox1;
        protected ITTObjectListBox ttobjectlistbox2;
        protected ITTLabel ttlabel11;
        protected ITTLabel ttlabel3;
        protected ITTEnumComboBox ttenumcombobox1;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTLabel labelActionDate;
        protected ITTLabel PlanlamaZaman;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelOrderNO;
        protected ITTLabel labelOrderName;
        protected ITTLabel ttlabel9;
        protected ITTTextBox OrderNO;
        protected ITTLabel labelRequestDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelID;
        protected ITTDateTimePicker ttdatetimepicker2;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTTabPage tttabpage6;
        protected ITTTextBox PackagingDepActionStatus;
        protected ITTButton cmdPackagingDep;
        protected ITTLabel labelPackagingDepReturnDate;
        protected ITTDateTimePicker PackagingDepSendingDate;
        protected ITTLabel ttlabel4;
        protected ITTDateTimePicker PackagingDepReturnDate;
        protected ITTLabel labelPackagingDepartment;
        protected ITTTextBox PackagingDepartmentDesc;
        protected ITTLabel labelPackagingDepSendingDate;
        protected ITTLabel labelPackagingDepartmentDesc;
        protected ITTObjectListBox PackagingDepartment;
        protected ITTTabPage tttabpage3;
        protected ITTLabel labelPreventiveTreatment;
        protected ITTLabel labelPreventiveTreatmentWorkLoad;
        protected ITTTextBox PreventiveTreatment;
        protected ITTTextBox PreventiveTreatmentWorkLoad;
        protected ITTTextBox Agenda;
        protected ITTLabel labelAgenda;
        protected ITTTextBox ErrorReason;
        protected ITTLabel labelErrorReason;
        protected ITTTabPage tttabpage7;
        protected ITTLabel ttlabel6;
        protected ITTTextBox ReportNo;
        protected ITTButton ttbutton1;
        protected ITTLabel ttlabel5;
        protected ITTGrid gridFaalMalzemeImza;
        protected ITTEnumComboBoxColumn SignUserTypeCMRActionSignDetail;
        protected ITTListBoxColumn SignUserCMRActionSignDetail;
        protected ITTCheckBoxColumn IsDeputyCMRActionSignDetail;
        protected ITTTabPage tttabpage8;
        protected ITTLabel labelDescriptionPart;
        protected ITTTextBox DescriptionPart;
        protected ITTToolStrip tttoolstrip1;
        protected ITTTabControl tttabcontrol2;
        protected ITTTabPage tttabpage4;
        protected ITTGrid UsedConsumedMaterails;
        protected ITTListBoxColumn UsedMaterial;
        protected ITTListBoxColumn UsedMaterialDistType;
        protected ITTTextBoxColumn RequestAmountForDepot;
        protected ITTTextBoxColumn SuppliedAmount;
        protected ITTTextBoxColumn UsedAmount;
        protected ITTTabPage tttabpage5;
        protected ITTGrid UsedMaterialWorkSteps;
        protected ITTListBoxColumn WorkStepUsedMaterial;
        protected ITTListBoxColumn WorkStepUsedMaterialDistType;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn UnitAmout;
        protected ITTTabPage tttabpage1;
        protected ITTGrid WorkStepsGrid;
        protected ITTListBoxColumn WorkShop;
        protected ITTListBoxColumn Personel;
        protected ITTTextBoxColumn Workload;
        protected ITTTextBoxColumn Comments;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("3d249a26-8e14-4942-b41a-d113232c3599"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("19aef142-2a50-4988-880c-aca93453ccb3"));
            RequestNO = (ITTTextBox)AddControl(new Guid("13632c45-c174-4bc0-bc27-ab6bd38b3933"));
            RepairWorkLoad = (ITTTextBox)AddControl(new Guid("4e0417d6-d64c-4838-b485-c41740aff574"));
            labelRepairWorkLoad = (ITTLabel)AddControl(new Guid("c9f04fd2-6c95-4d37-8da3-9e22c3e6f982"));
            SpecialWorkAmount = (ITTTextBox)AddControl(new Guid("00514ddb-f632-46da-a68c-3ad78ee0fa15"));
            labelSpecialWorkAmount = (ITTLabel)AddControl(new Guid("43fa8f54-b182-44e7-854f-c30920b1a028"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("1454b2aa-72cf-401c-a0f9-df0efe0c58f2"));
            ManufacturingAmount = (ITTTextBox)AddControl(new Guid("d6a3501d-b455-411f-89e7-99577e14300c"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("c047c801-35fe-4563-bb0e-e74043f3d7ff"));
            labelManufacturingAmount = (ITTLabel)AddControl(new Guid("00163113-cb04-4fa6-a3b3-e2d98f8f9fea"));
            SenderAccountancy = (ITTObjectListBox)AddControl(new Guid("4d595a09-c2dc-47fe-ad34-0c5f76042696"));
            FixedAssetDefinition = (ITTObjectListBox)AddControl(new Guid("b64eccf1-8ae2-4315-9035-af974b4c9966"));
            labelFromResource = (ITTLabel)AddControl(new Guid("ae55cb70-19ed-4222-ab96-44775007c224"));
            labelFixedAssetDefinition = (ITTLabel)AddControl(new Guid("e23de1e7-0b84-44eb-a858-180defd34faf"));
            OrderTypeList = (ITTObjectListBox)AddControl(new Guid("1c4939ae-cfc6-4b3d-a96d-5df1dd3610f5"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("54f946c1-9727-4d09-b475-10512d684b1b"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("a0ec8d68-2db3-4217-97a6-64bb5617bccc"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("ff93d28b-0004-4694-8535-90769d9604ff"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("35a3ad82-3891-48c2-86b6-b046938d8cc4"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("c599da49-b0b4-45c7-9654-e2d95d10abc6"));
            ttenumcombobox1 = (ITTEnumComboBox)AddControl(new Guid("3b041df8-eb39-4e99-bfd1-5a006b877f75"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("67c77fd1-42c5-4ff0-8ffe-1f9c3500198d"));
            labelActionDate = (ITTLabel)AddControl(new Guid("b29d5d16-44de-47c0-91f4-94c976438680"));
            PlanlamaZaman = (ITTLabel)AddControl(new Guid("009cf5a9-a78c-46fe-b21e-fff79760ae31"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("7fb83090-56b1-4e92-88fd-6a72594a6ca0"));
            labelOrderNO = (ITTLabel)AddControl(new Guid("a4c4d8e7-145d-433c-85aa-0d3b54421769"));
            labelOrderName = (ITTLabel)AddControl(new Guid("a7fe1ed2-28ce-463a-9dc1-79f20bfec869"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("fe53c7f1-c18d-4fe9-a8e2-352b1ecf6cbf"));
            OrderNO = (ITTTextBox)AddControl(new Guid("3696ba90-b1ab-49b1-9eca-d108f7705101"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("6dfbd2cd-1a7b-4afb-8d0f-b50022a61dfd"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("21542d5c-b4a8-4681-a028-d1f9ab6cfd61"));
            labelID = (ITTLabel)AddControl(new Guid("54a7bc17-ddb6-41da-ba0d-47124949be59"));
            ttdatetimepicker2 = (ITTDateTimePicker)AddControl(new Guid("21064584-eb59-4e1e-824b-6d16cbca4b4a"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("c680977b-3838-48b0-8181-46b0663bbc14"));
            tttabpage6 = (ITTTabPage)AddControl(new Guid("3dc94a67-faac-4519-96cc-70067eadc6f1"));
            PackagingDepActionStatus = (ITTTextBox)AddControl(new Guid("066569d3-97d4-41dc-8c28-1b34a90d9f0a"));
            cmdPackagingDep = (ITTButton)AddControl(new Guid("e4dc33d9-f0d1-4934-9deb-82309a2c3968"));
            labelPackagingDepReturnDate = (ITTLabel)AddControl(new Guid("bc059b8c-6bbb-481f-a04b-969afdad1b43"));
            PackagingDepSendingDate = (ITTDateTimePicker)AddControl(new Guid("475aad97-9813-4879-945d-280a6b229ce2"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("d36c988b-aa53-4be8-9055-89bead2c0547"));
            PackagingDepReturnDate = (ITTDateTimePicker)AddControl(new Guid("f02e8164-7575-4f2f-b0ae-7cc9b7d76af7"));
            labelPackagingDepartment = (ITTLabel)AddControl(new Guid("eab97e1c-dd82-4710-a317-fe74844afb9a"));
            PackagingDepartmentDesc = (ITTTextBox)AddControl(new Guid("5e1f2089-c041-4503-a528-2e53c1a9019c"));
            labelPackagingDepSendingDate = (ITTLabel)AddControl(new Guid("22d38cc7-f8e2-4572-9c95-56056a416aa8"));
            labelPackagingDepartmentDesc = (ITTLabel)AddControl(new Guid("005f40bf-446a-4858-8eee-5758ef169e77"));
            PackagingDepartment = (ITTObjectListBox)AddControl(new Guid("4d1982f3-9b18-4e5e-aa5f-462bf5cc34a5"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("76c2232f-9392-4539-a4b1-41a17aee86ea"));
            labelPreventiveTreatment = (ITTLabel)AddControl(new Guid("3b8dec0f-806b-4b85-a275-b606fdaabf00"));
            labelPreventiveTreatmentWorkLoad = (ITTLabel)AddControl(new Guid("b87e18cf-7edc-47dc-b57d-804d97797722"));
            PreventiveTreatment = (ITTTextBox)AddControl(new Guid("0498f9a1-d4f3-4dd2-92ae-2bcdf04fb51c"));
            PreventiveTreatmentWorkLoad = (ITTTextBox)AddControl(new Guid("27630629-0110-45e8-9c26-9065c529689b"));
            Agenda = (ITTTextBox)AddControl(new Guid("d1a756fe-2f21-49ff-9032-33da49a3d713"));
            labelAgenda = (ITTLabel)AddControl(new Guid("38bc0d07-c7d1-486d-a5f5-fe3b76a5f404"));
            ErrorReason = (ITTTextBox)AddControl(new Guid("8fa4e44c-a409-481c-8895-f0eb5073da90"));
            labelErrorReason = (ITTLabel)AddControl(new Guid("7c9e267a-67ce-4393-9c57-67b9ff611251"));
            tttabpage7 = (ITTTabPage)AddControl(new Guid("5a1a3655-4d3c-4dea-a506-245015a8b180"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("4ef15ad3-5430-43d3-86ad-8f3601570889"));
            ReportNo = (ITTTextBox)AddControl(new Guid("af581123-c437-430c-9699-36b88bc25e13"));
            ttbutton1 = (ITTButton)AddControl(new Guid("118ff38a-e9f7-4a17-abfa-8249d32c0f2f"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("5eae49d6-30f6-4fc0-a989-42b6c9452e8e"));
            gridFaalMalzemeImza = (ITTGrid)AddControl(new Guid("30a9e174-1dc4-4865-88f7-c7faaeda981e"));
            SignUserTypeCMRActionSignDetail = (ITTEnumComboBoxColumn)AddControl(new Guid("a719418d-db78-4f48-b0cb-6728d6c51431"));
            SignUserCMRActionSignDetail = (ITTListBoxColumn)AddControl(new Guid("5655294b-b510-440b-a595-8a2bca81cba2"));
            IsDeputyCMRActionSignDetail = (ITTCheckBoxColumn)AddControl(new Guid("ee29c365-b72e-4875-8449-89ee40933a76"));
            tttabpage8 = (ITTTabPage)AddControl(new Guid("0dcbb896-f880-4b07-94de-e2963f0521fd"));
            labelDescriptionPart = (ITTLabel)AddControl(new Guid("4c664ff4-0aed-4073-8000-19dcb4d7aef4"));
            DescriptionPart = (ITTTextBox)AddControl(new Guid("7fe1b6c4-7a49-455f-9b7f-8e93c493775d"));
            tttoolstrip1 = (ITTToolStrip)AddControl(new Guid("49b9a1e2-92ab-4252-bf29-e2b38453cca7"));
            tttabcontrol2 = (ITTTabControl)AddControl(new Guid("4934aecd-721d-4d8d-98fc-27930ca19c71"));
            tttabpage4 = (ITTTabPage)AddControl(new Guid("10550b94-20eb-407e-a669-1bdd4e00fe96"));
            UsedConsumedMaterails = (ITTGrid)AddControl(new Guid("62f1d995-8285-4362-b737-bf5f6598271f"));
            UsedMaterial = (ITTListBoxColumn)AddControl(new Guid("7707fc7f-5c37-4b10-8ee6-6bc45dbfb487"));
            UsedMaterialDistType = (ITTListBoxColumn)AddControl(new Guid("d6084c7f-479d-46fa-b29c-dd5dfae37b84"));
            RequestAmountForDepot = (ITTTextBoxColumn)AddControl(new Guid("b4d873dc-9b68-403e-b4a9-bac166fd2c5e"));
            SuppliedAmount = (ITTTextBoxColumn)AddControl(new Guid("9df54cc5-4cad-4d26-90d7-937edf58a638"));
            UsedAmount = (ITTTextBoxColumn)AddControl(new Guid("f5f77a25-df5f-4475-b50b-3f762d66c864"));
            tttabpage5 = (ITTTabPage)AddControl(new Guid("d373f90f-9f0e-4ab5-88a0-2baf9becb08c"));
            UsedMaterialWorkSteps = (ITTGrid)AddControl(new Guid("e6a9f940-a524-4f30-b720-9a14dcc71bed"));
            WorkStepUsedMaterial = (ITTListBoxColumn)AddControl(new Guid("fa44333c-6daf-4960-b99b-ffd0a183c65f"));
            WorkStepUsedMaterialDistType = (ITTListBoxColumn)AddControl(new Guid("dc746865-9cbb-4aa9-b03e-9f6fd154b548"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("42aae4ec-8037-4c14-883b-fe7e4c279d68"));
            UnitAmout = (ITTTextBoxColumn)AddControl(new Guid("4ba5b064-a2b1-45f9-84ec-a659f07ed4ac"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("59d034ad-659e-41e5-9434-67d4989b0cb1"));
            WorkStepsGrid = (ITTGrid)AddControl(new Guid("c510f1bf-b0ef-4bc5-b893-87e791f4975e"));
            WorkShop = (ITTListBoxColumn)AddControl(new Guid("ac75486c-be55-4520-a859-5fd8079dd19d"));
            Personel = (ITTListBoxColumn)AddControl(new Guid("213bb6fc-7b4b-41e9-978a-dbfadf545425"));
            Workload = (ITTTextBoxColumn)AddControl(new Guid("593468c9-6cb1-48d1-88c6-aece007a3377"));
            Comments = (ITTTextBoxColumn)AddControl(new Guid("1991f3df-6d16-45c2-91ac-e7dd624859d0"));
            base.InitializeControls();
        }

        public LastControlForm_MaintenanceO() : base("MAINTENANCEORDER", "LastControlForm_MaintenanceO")
        {
        }

        protected LastControlForm_MaintenanceO(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}