
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
    /// Hizmet Tanımı
    /// </summary>
    public partial class ProcedureForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Hizmet Tanımı
    /// </summary>
        protected TTObjectClasses.ProcedureDefinition _ProcedureDefinition
        {
            get { return (TTObjectClasses.ProcedureDefinition)_ttObject; }
        }

        protected ITTTabControl tabProcedure;
        protected ITTTabPage tpProcedure;
        protected ITTCheckBox RepetitionQueryNeeded;
        protected ITTCheckBox RightLeftInfoNeeded;
        protected ITTCheckBox IsVisible;
        protected ITTCheckBox IsResultNeeded;
        protected ITTLabel labelProcedureType;
        protected ITTEnumComboBox ProcedureType;
        protected ITTLabel ttlabel22;
        protected ITTLabel ttlabel21;
        protected ITTLabel ttlabel13;
        protected ITTGrid GridRequiredDiagnosis;
        protected ITTListBoxColumn DiagnosisDefinitionRequiredDiagnoseProcedure;
        protected ITTCheckBox IsDescriptionNeeded;
        protected ITTLabel labelInpatientDayCount;
        protected ITTTextBox InpatientDayCount;
        protected ITTCheckBox QualifiedMedicalProcess;
        protected ITTCheckBox PathologyOperationNeeded;
        protected ITTCheckBox ExternalOperation;
        protected ITTLabel labelSUTPoint;
        protected ITTTextBox SUTPoint;
        protected ITTLabel labelHUVPoint;
        protected ITTTextBox HUVPoint;
        protected ITTLabel labelHUVCode;
        protected ITTTextBox HUVCode;
        protected ITTCheckBox ForbiddenForInpatient;
        protected ITTCheckBox ForbiddenForExamination;
        protected ITTCheckBox ForbiddenForEmergency;
        protected ITTCheckBox ForbiddenForDaily;
        protected ITTCheckBox ForbiddenForControl;
        protected ITTLabel labelExaminationDayCount;
        protected ITTTextBox ExaminationDayCount;
        protected ITTLabel labelEmergencyDayCount;
        protected ITTTextBox EmergencyDayCount;
        protected ITTLabel labelDailyDayCount;
        protected ITTTextBox DailyDayCount;
        protected ITTLabel labelControlDayCount;
        protected ITTTextBox ControlDayCount;
        protected ITTLabel labelGILDefinition;
        protected ITTObjectListBox GILDefinition;
        protected ITTCheckBox ParticipationProcedure;
        protected ITTCheckBox DontBlockInvoice;
        protected ITTTextBox txtSUTCode;
        protected ITTLabel lblSUTCode;
        protected ITTCheckBox QuickEntryAllowed;
        protected ITTCheckBox Chargable;
        protected ITTCheckBox ReportSelectionRequired;
        protected ITTEnumComboBox SUTAppendix;
        protected ITTLabel lblSUTAppendix;
        protected ITTTextBox txtGILCode;
        protected ITTLabel lblGILCode;
        protected ITTTextBox txtGILPoint;
        protected ITTLabel lblGILPoint;
        protected ITTObjectListBox PackageProcedure;
        protected ITTLabel ttlabel10;
        protected ITTLabel labelQref;
        protected ITTLabel labelName;
        protected ITTLabel labelDescription;
        protected ITTTextBox ProcType;
        protected ITTLabel ttlabel1;
        protected ITTCheckBox IsActive;
        protected ITTLabel labelID;
        protected ITTTextBox Name;
        protected ITTObjectListBox REVENUESUBACCOUNTCODE;
        protected ITTLabel labelCode;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel2;
        protected ITTGrid GridSubProcedures;
        protected ITTListBoxColumn ttlistboxcolumn1;
        protected ITTTextBoxColumn tttextboxcolumn1;
        protected ITTTextBox Description;
        protected ITTLabel ttlabel4;
        protected ITTTextBox Qref;
        protected ITTTextBox Code;
        protected ITTTextBox ID;
        protected ITTTabPage ttlabel9;
        protected ITTGroupBox MedulaProvisionProperties;
        protected ITTLabel ttlabel11;
        protected ITTCheckBox DailyMedulaProvisionNecessity;
        protected ITTObjectListBox ttobjectlistbox2;
        protected ITTLabel DoctorLabel;
        protected ITTObjectListBox DoctorListBox;
        protected ITTCheckBox CreateInMedulaDontSendState;
        protected ITTObjectListBox TedaviTipi;
        protected ITTObjectListBox TakipTipi;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel8;
        protected ITTObjectListBox ProvizyonTipi;
        protected ITTCheckBox PreProcedureEntryNecessity;
        protected ITTLabel ttlabel6;
        protected ITTEnumComboBox MedulaProcedureType;
        protected ITTObjectListBox OzelDurum;
        protected ITTLabel labelMedulaReportNecessity;
        protected ITTLabel ttlabel7;
        protected ITTEnumComboBox MedulaReportNecessity;
        protected ITTLabel ttlabel12;
        protected ITTTabPage tpPrices;
        protected ITTGrid grdPrices;
        protected ITTListBoxColumn PricingDetail;
        protected ITTListDefComboBoxColumn PriceList;
        protected ITTDateTimePickerColumn PriceStartDate;
        protected ITTDateTimePickerColumn PriceEndDate;
        protected ITTTextBoxColumn Price;
        protected ITTCheckBox ttcheckbox1;
        protected ITTCheckBox ttcheckbox3;
        protected ITTCheckBox ttcheckbox2;
        override protected void InitializeControls()
        {
            tabProcedure = (ITTTabControl)AddControl(new Guid("66dd6838-52a5-4cc3-a214-62bae32a5df3"));
            tpProcedure = (ITTTabPage)AddControl(new Guid("281fa5d5-7e30-4526-a80d-e4985a87dd45"));
            RepetitionQueryNeeded = (ITTCheckBox)AddControl(new Guid("49649462-e9b0-4b3d-ac8b-17bf95c1f88d"));
            RightLeftInfoNeeded = (ITTCheckBox)AddControl(new Guid("2e522822-1b9c-4ff1-82ea-1df485093089"));
            IsVisible = (ITTCheckBox)AddControl(new Guid("f9e3ed7f-b789-4b84-b705-90e09f036dde"));
            IsResultNeeded = (ITTCheckBox)AddControl(new Guid("24f466d9-d35c-4d76-97a6-bd3e23e9df17"));
            labelProcedureType = (ITTLabel)AddControl(new Guid("6bcb20f3-279d-4e1f-86b7-a31d13ea42d6"));
            ProcedureType = (ITTEnumComboBox)AddControl(new Guid("e02ab07e-5592-4dea-bd6a-598d07f86034"));
            ttlabel22 = (ITTLabel)AddControl(new Guid("c8ec665c-68d0-41ed-ab60-97abc0b28f12"));
            ttlabel21 = (ITTLabel)AddControl(new Guid("aeb95208-7363-4a4a-a8c6-a86c35abda1c"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("d29f6b13-e8d2-4577-a37e-5c0fcb90b174"));
            GridRequiredDiagnosis = (ITTGrid)AddControl(new Guid("b5efcd2b-1e5c-471f-9cd6-62a22d4c0ffa"));
            DiagnosisDefinitionRequiredDiagnoseProcedure = (ITTListBoxColumn)AddControl(new Guid("803edb96-60a0-45fd-bd36-2384cc3539c6"));
            IsDescriptionNeeded = (ITTCheckBox)AddControl(new Guid("05989093-3d24-43fa-b92a-fdbb77db6d70"));
            labelInpatientDayCount = (ITTLabel)AddControl(new Guid("fb1a6e67-2099-4cfa-9f08-49e32a2995df"));
            InpatientDayCount = (ITTTextBox)AddControl(new Guid("339b38c3-24db-4ddd-aaea-e7ef239004aa"));
            QualifiedMedicalProcess = (ITTCheckBox)AddControl(new Guid("b6c73b73-0d3e-4b5f-9f8f-9fc4555280a5"));
            PathologyOperationNeeded = (ITTCheckBox)AddControl(new Guid("f17dadcc-75c9-41a6-a315-5c6162487b68"));
            ExternalOperation = (ITTCheckBox)AddControl(new Guid("f6ee0c53-6f35-4d63-8594-9d42fccb8be4"));
            labelSUTPoint = (ITTLabel)AddControl(new Guid("adb1531f-8607-4f8f-8355-b7e131b1b2f6"));
            SUTPoint = (ITTTextBox)AddControl(new Guid("962a57a7-026d-42b6-934a-b4a23b98eabd"));
            labelHUVPoint = (ITTLabel)AddControl(new Guid("498798a5-58f5-4651-953d-cf4f42307214"));
            HUVPoint = (ITTTextBox)AddControl(new Guid("7718f2f3-68ad-42fc-90d4-044a007ea5d8"));
            labelHUVCode = (ITTLabel)AddControl(new Guid("67454c2d-0d1d-412d-b86d-304738db434c"));
            HUVCode = (ITTTextBox)AddControl(new Guid("b86b9228-d2cf-431d-a6ca-9cfc0e795317"));
            ForbiddenForInpatient = (ITTCheckBox)AddControl(new Guid("be9b745c-d351-45ea-9084-a3dbcf3004ba"));
            ForbiddenForExamination = (ITTCheckBox)AddControl(new Guid("4e7d48c4-c092-4aca-8a05-bf3656a3f9c4"));
            ForbiddenForEmergency = (ITTCheckBox)AddControl(new Guid("156dee53-eff7-4ba2-b04e-15f03f42e0f8"));
            ForbiddenForDaily = (ITTCheckBox)AddControl(new Guid("27a235d9-b903-4882-87e4-e3113061f1ee"));
            ForbiddenForControl = (ITTCheckBox)AddControl(new Guid("543975da-ad81-4dd8-8173-8417c371319d"));
            labelExaminationDayCount = (ITTLabel)AddControl(new Guid("ce6e0c29-5765-46b5-a57d-eb8e1feb08ec"));
            ExaminationDayCount = (ITTTextBox)AddControl(new Guid("caeb2143-ea77-4d8e-957b-72f942100781"));
            labelEmergencyDayCount = (ITTLabel)AddControl(new Guid("7de98362-eb9e-445f-867f-012e43feb073"));
            EmergencyDayCount = (ITTTextBox)AddControl(new Guid("997a754e-f8bc-4519-adcd-dbf7d591ffa5"));
            labelDailyDayCount = (ITTLabel)AddControl(new Guid("cbca2cfa-a109-4844-b3c3-a73c243168a5"));
            DailyDayCount = (ITTTextBox)AddControl(new Guid("a87bd8dd-3e9d-4347-b971-4a8c51dfe21c"));
            labelControlDayCount = (ITTLabel)AddControl(new Guid("b8639c63-13ea-4ee3-b72f-bdb9cbd5b07b"));
            ControlDayCount = (ITTTextBox)AddControl(new Guid("e2b5ff5a-823f-4d4b-8145-dec100524c75"));
            labelGILDefinition = (ITTLabel)AddControl(new Guid("22c675f1-6297-4d78-9c50-8799a30f36b3"));
            GILDefinition = (ITTObjectListBox)AddControl(new Guid("bcf990da-fd97-4d58-9e9b-207056faefab"));
            ParticipationProcedure = (ITTCheckBox)AddControl(new Guid("17077f74-dc69-4049-aecb-fc3427343ca3"));
            DontBlockInvoice = (ITTCheckBox)AddControl(new Guid("e9d32c44-5b32-48fd-bd1c-31bc8273231c"));
            txtSUTCode = (ITTTextBox)AddControl(new Guid("4e1146e8-ccd2-4f2f-ad3f-a7d492614523"));
            lblSUTCode = (ITTLabel)AddControl(new Guid("4bf0808c-e12b-4484-9396-4822d68b2846"));
            QuickEntryAllowed = (ITTCheckBox)AddControl(new Guid("344ee303-75e6-4a08-ae45-286711670450"));
            Chargable = (ITTCheckBox)AddControl(new Guid("e77549b6-7838-418b-bb6c-b6a96a5f39d7"));
            ReportSelectionRequired = (ITTCheckBox)AddControl(new Guid("26e703bf-109d-44b1-89d3-f210ae64036a"));
            SUTAppendix = (ITTEnumComboBox)AddControl(new Guid("6af71af2-7251-48df-ad64-49d98effb301"));
            lblSUTAppendix = (ITTLabel)AddControl(new Guid("2cfc9d26-3d72-452a-b986-1d1227fa5f7d"));
            txtGILCode = (ITTTextBox)AddControl(new Guid("6828334f-f00c-48b8-a668-4b1fb1244d97"));
            lblGILCode = (ITTLabel)AddControl(new Guid("cccdeb03-a912-4288-a0eb-bdebd34006e4"));
            txtGILPoint = (ITTTextBox)AddControl(new Guid("d92f0292-aee9-42a2-8dbf-64d56e3bd970"));
            lblGILPoint = (ITTLabel)AddControl(new Guid("d2918ce9-1a9e-4f73-abc9-7ca0cc89b00b"));
            PackageProcedure = (ITTObjectListBox)AddControl(new Guid("cf34f840-bd47-4fc9-8655-7df360ff6e38"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("47ecc6bc-e5bf-4163-9a71-aa38892d107c"));
            labelQref = (ITTLabel)AddControl(new Guid("cccf8103-5908-4060-a2e7-1e28984810f5"));
            labelName = (ITTLabel)AddControl(new Guid("41258b8e-69a8-4345-8304-e132cc155cbb"));
            labelDescription = (ITTLabel)AddControl(new Guid("d494defc-daf9-46bd-96b9-0de462a6c576"));
            ProcType = (ITTTextBox)AddControl(new Guid("15448fd9-0a91-4f9c-b0f1-2cdb1d8157bd"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("8b66f997-52c1-44eb-b051-d72c15219f6d"));
            IsActive = (ITTCheckBox)AddControl(new Guid("9bdc45ef-c323-4939-a930-2ffdda859340"));
            labelID = (ITTLabel)AddControl(new Guid("3ac6023b-52ac-4b74-853c-6ededc3af40f"));
            Name = (ITTTextBox)AddControl(new Guid("be76d819-8e9a-428d-8fff-26a0d93a7c25"));
            REVENUESUBACCOUNTCODE = (ITTObjectListBox)AddControl(new Guid("2f010a03-f103-4663-b83e-38ac329127be"));
            labelCode = (ITTLabel)AddControl(new Guid("ce6955a5-629d-40f6-83ba-5ae75fe6f223"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("6f6b8ce6-35e5-45f0-9eb5-397d2106fb31"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("46f93362-b8d3-4925-85c0-314f5690e6da"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("802d90f9-0642-4459-9149-8c1a0b247b31"));
            GridSubProcedures = (ITTGrid)AddControl(new Guid("a17c4d52-3d41-4e32-abab-7e778e289e48"));
            ttlistboxcolumn1 = (ITTListBoxColumn)AddControl(new Guid("4e6382a7-e81b-4e3d-ae32-58523ceca69e"));
            tttextboxcolumn1 = (ITTTextBoxColumn)AddControl(new Guid("a638a2bd-ec1e-425d-aa36-5ca49ecaa917"));
            Description = (ITTTextBox)AddControl(new Guid("cff6aaab-d4a8-40a3-9e26-820f8269968b"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("41199f60-caaf-499c-b522-fc81e8619739"));
            Qref = (ITTTextBox)AddControl(new Guid("e974b397-113e-4eb3-a040-f258a464eb95"));
            Code = (ITTTextBox)AddControl(new Guid("19bd609e-62e3-448c-ad22-9219d3f768cf"));
            ID = (ITTTextBox)AddControl(new Guid("8bb8772c-6470-4d4c-94ba-e968801e1429"));
            ttlabel9 = (ITTTabPage)AddControl(new Guid("57aa1269-9ecd-4f7d-8ec5-851efe4a964f"));
            MedulaProvisionProperties = (ITTGroupBox)AddControl(new Guid("06ca4bee-dfbb-485a-8fd3-d7b7bc2f61af"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("17a12f9c-3ea5-4f51-b62f-71251ec4a9e2"));
            DailyMedulaProvisionNecessity = (ITTCheckBox)AddControl(new Guid("e40e5917-ac00-49c6-81c6-feb5a78bb090"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("0752442a-7cd9-4547-b19a-3f19d6831e21"));
            DoctorLabel = (ITTLabel)AddControl(new Guid("3b06985d-6a8d-4eff-9eaa-0b201b51f56b"));
            DoctorListBox = (ITTObjectListBox)AddControl(new Guid("38ded186-cb00-406e-b75e-72f814530cf5"));
            CreateInMedulaDontSendState = (ITTCheckBox)AddControl(new Guid("1c2fd909-856d-47de-9d70-be03cfba37c9"));
            TedaviTipi = (ITTObjectListBox)AddControl(new Guid("a4959375-9bb3-4e0e-9d41-0ed7ed0dc0ec"));
            TakipTipi = (ITTObjectListBox)AddControl(new Guid("4e96d6fc-9bff-424e-891c-a23fd5af34f2"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("0398bc7a-b9bc-48b5-9c06-07b23567ae99"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("8fb647d5-e2ee-4f65-a6c8-5753ad7302ed"));
            ProvizyonTipi = (ITTObjectListBox)AddControl(new Guid("3e72a57c-bb30-4117-b1ac-09326ab2c107"));
            PreProcedureEntryNecessity = (ITTCheckBox)AddControl(new Guid("2b6f76f1-f6c3-436b-9b75-f651e206f6db"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("a80491fe-2701-4ce0-95bf-bb56ed67668c"));
            MedulaProcedureType = (ITTEnumComboBox)AddControl(new Guid("27445248-0561-4dff-aeba-fd246f0e8531"));
            OzelDurum = (ITTObjectListBox)AddControl(new Guid("7475940a-2a1e-4269-8c02-9ab627d854c3"));
            labelMedulaReportNecessity = (ITTLabel)AddControl(new Guid("72640a3f-da1c-4e47-b572-cb5189611e4c"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("f85a1915-1ae4-4108-bd4f-6966057e1e58"));
            MedulaReportNecessity = (ITTEnumComboBox)AddControl(new Guid("6255e624-ac1d-41fc-8099-89193f7b91a9"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("6dfcb06b-b609-47f2-b841-db7616547f89"));
            tpPrices = (ITTTabPage)AddControl(new Guid("b82815e8-a25d-4e02-a032-0b94d363533b"));
            grdPrices = (ITTGrid)AddControl(new Guid("eefee81c-8be1-469b-ac8d-61c9f658ac33"));
            PricingDetail = (ITTListBoxColumn)AddControl(new Guid("b2d5eeaf-7dff-4224-917d-92415bcd3bc8"));
            PriceList = (ITTListDefComboBoxColumn)AddControl(new Guid("a035b9d6-5620-40f6-b39f-7a499f4db242"));
            PriceStartDate = (ITTDateTimePickerColumn)AddControl(new Guid("8ef101f9-9ac2-4cfd-b40d-d63595e8c290"));
            PriceEndDate = (ITTDateTimePickerColumn)AddControl(new Guid("b21d03df-d2f6-4359-a3cb-0ed96b7d2174"));
            Price = (ITTTextBoxColumn)AddControl(new Guid("2be6d403-867d-4b2e-bb60-01192e577656"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("9389d6c8-2075-4ee7-ae5c-b14a0fc04dd8"));
            ttcheckbox3 = (ITTCheckBox)AddControl(new Guid("dc2623fa-3782-42a9-bd89-8b8359aa2d0a"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("4a9a9597-442a-4702-b5c3-ed1789be03a9"));
            base.InitializeControls();
        }

        public ProcedureForm() : base("PROCEDUREDEFINITION", "ProcedureForm")
        {
        }

        protected ProcedureForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}