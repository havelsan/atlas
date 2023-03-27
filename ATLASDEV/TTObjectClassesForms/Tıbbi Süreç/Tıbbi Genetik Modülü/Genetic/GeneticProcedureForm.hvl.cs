
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
    /// Tıbbi Genetik İşlemde Formu
    /// </summary>
    public partial class GeneticProcedureForm : EpisodeActionForm
    {
    /// <summary>
    /// Tıbbi Genetik İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.Genetic _Genetic
        {
            get { return (TTObjectClasses.Genetic)_ttObject; }
        }

        protected ITTTabControl TabTextInfos;
        protected ITTTabPage TabPageRequestDesc;
        protected ITTTextBox RequestDescription;
        protected ITTTabPage TabPagePrediagnosis;
        protected ITTTextBox PreDiagnosis;
        protected ITTTabPage TabPageDescription;
        protected ITTTextBox Description;
        protected ITTTabControl TabTests;
        protected ITTTabPage TabPageTests;
        protected ITTGrid grdGeneticTests;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTTextBoxColumn TestAmount;
        protected ITTTabPage TabPageMaterial;
        protected ITTGrid GridGeneticMaterials;
        protected ITTDateTimePickerColumn MACTIONDATE;
        protected ITTListBoxColumn MATERIAL;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTextBoxColumn AMOUNT;
        protected ITTTextBoxColumn UBBCODE;
        protected ITTTextBox MaterialResponsible;
        protected ITTTextBox SendenMaterial;
        protected ITTTextBox tttextbox2;
        protected ITTTextBox PatientAge;
        protected ITTTextBox tttextbox3;
        protected ITTLabel ttlabel11;
        protected ITTObjectListBox TestToStudyTTListBox;
        protected ITTCheckBox EmergencyCheckBox;
        protected ITTLabel ttlabel8;
        protected ITTLabel ttlabel7;
        protected ITTGrid GridDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnoseType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTTextBoxColumn EntryActionType;
        protected ITTObjectListBox RequestDoctor;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel ttlabel15;
        protected ITTObjectListBox PatientRoom;
        protected ITTLabel ttlabel10;
        protected ITTLabel ttlabel9;
        protected ITTObjectListBox PatientClinic;
        protected ITTEnumComboBox PatientSexEnum;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel6;
        protected ITTObjectListBox RepeatReason;
        protected ITTLabel ttlabel12;
        protected ITTButton cmdPrintBarcode;
        protected ITTGrid GridEquipments;
        protected ITTListBoxColumn Equipment;
        override protected void InitializeControls()
        {
            TabTextInfos = (ITTTabControl)AddControl(new Guid("bac6a447-542d-486b-973c-c36624a32880"));
            TabPageRequestDesc = (ITTTabPage)AddControl(new Guid("99af795f-1806-4a68-947f-0fbe7485ec3e"));
            RequestDescription = (ITTTextBox)AddControl(new Guid("04bb5c14-99d1-462f-8a1b-5f769c4aac11"));
            TabPagePrediagnosis = (ITTTabPage)AddControl(new Guid("8d21af10-dbcd-4c09-a0e0-cc2efe9c5eee"));
            PreDiagnosis = (ITTTextBox)AddControl(new Guid("fbc4d02f-bb18-4895-8952-14890c315f77"));
            TabPageDescription = (ITTTabPage)AddControl(new Guid("904d58fb-8c5c-4a8a-b94e-18310497e3ea"));
            Description = (ITTTextBox)AddControl(new Guid("086a82a0-de47-48fc-a8dd-9a3658bba37d"));
            TabTests = (ITTTabControl)AddControl(new Guid("3a8724d4-aac8-4a18-85ce-947f6a06ff9b"));
            TabPageTests = (ITTTabPage)AddControl(new Guid("cfc7d1fb-fc68-4f83-819b-c5a27ab2bc7a"));
            grdGeneticTests = (ITTGrid)AddControl(new Guid("afec034f-41b7-46e2-bc4f-7bba92610fab"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("e042ae65-ddde-4db2-852e-135b546f1757"));
            TestAmount = (ITTTextBoxColumn)AddControl(new Guid("eb589d94-e843-4014-b090-06b3a3ac47bf"));
            TabPageMaterial = (ITTTabPage)AddControl(new Guid("0e278e76-70ad-4ae5-9c36-bf5a635bfa7b"));
            GridGeneticMaterials = (ITTGrid)AddControl(new Guid("2ad9990c-28e3-4f36-901b-8609c8a73b08"));
            MACTIONDATE = (ITTDateTimePickerColumn)AddControl(new Guid("03ebeaca-5cde-4be5-8529-a115e7ebb8e9"));
            MATERIAL = (ITTListBoxColumn)AddControl(new Guid("fd6fd71f-5e88-4a36-9844-c42ad89caf93"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("aa7fd91f-26e7-48a2-8289-58fa534a1f74"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("24e4daf6-74f2-4aad-8eb5-f918e02e884c"));
            AMOUNT = (ITTTextBoxColumn)AddControl(new Guid("2583407e-6de1-4a77-962d-d4066ce536f9"));
            UBBCODE = (ITTTextBoxColumn)AddControl(new Guid("f6da8165-139f-4a61-81bd-a0e8c9b993e2"));
            MaterialResponsible = (ITTTextBox)AddControl(new Guid("f7ab9038-2c39-458d-9e6c-b2d67ab7033a"));
            SendenMaterial = (ITTTextBox)AddControl(new Guid("44364d12-7c69-4d8c-81ba-d8c8ec3ef2b9"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("62066361-b0f4-4011-abcf-a1f9d0801115"));
            PatientAge = (ITTTextBox)AddControl(new Guid("64ff59f6-063d-4cdc-bb9c-af1538b2b0d8"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("9709aad9-5ae8-4766-bb1a-c47bf3f3350d"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("1dd37b57-2421-44e8-8be9-64ff51400939"));
            TestToStudyTTListBox = (ITTObjectListBox)AddControl(new Guid("497db1c6-37f4-4971-b3ec-b79aba8c5c09"));
            EmergencyCheckBox = (ITTCheckBox)AddControl(new Guid("37b1a2f8-f5e1-4759-8fcb-2967a8c30c86"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("5ea6aa9a-abb1-4d51-beb9-695cf9ee8241"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("2f313d57-ec9d-46b8-8ccf-d33ed8c2bff7"));
            GridDiagnosis = (ITTGrid)AddControl(new Guid("64cfba3b-8b2f-4ebb-8e2b-d28971647ce4"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("4ed902ac-bf94-4c0e-92cf-22285204622b"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("41ff3600-38bf-4905-8657-7634b82094ab"));
            EpisodeDiagnoseType = (ITTEnumComboBoxColumn)AddControl(new Guid("b28601bc-146b-44f2-98ac-63db28e6def9"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("ac6ccfae-441e-4964-b99b-fb6f05f5f4c7"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("697e5874-6b15-4978-b30b-d347b6be6bd7"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("63a1035a-24cc-496a-85f6-975b3b2a30e2"));
            EntryActionType = (ITTTextBoxColumn)AddControl(new Guid("81c8855c-b1a6-4266-a559-acf0f419ed60"));
            RequestDoctor = (ITTObjectListBox)AddControl(new Guid("a34b691c-4e6d-4798-af5a-aa2f2a2f37cb"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("edab861d-e38e-4b4d-95ba-1b14424226d2"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("d01eb202-a84a-4754-9003-86085cefafe2"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("5725adcc-d95e-454b-845b-a9859d9fe9b9"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("721a5bfe-8530-43cb-877d-284455f76887"));
            PatientRoom = (ITTObjectListBox)AddControl(new Guid("fce95a66-a5a1-4013-98f4-e05314f79c1b"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("ec0b05fd-fe91-434d-af8c-1cc4c29dc448"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("fc7c8adc-ed3a-4ff5-98e6-9fa4dce60109"));
            PatientClinic = (ITTObjectListBox)AddControl(new Guid("83a07e19-4f33-4f14-94dc-4d90a4ebd1e5"));
            PatientSexEnum = (ITTEnumComboBox)AddControl(new Guid("7f613964-bc3e-4a62-9f73-3f9628d7cc5a"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("5909af3f-b05f-42c4-9539-5a64c36d03a7"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("f3c1ab9d-c4ce-4f80-a8fc-bae08b87d33f"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("f25bf08c-4431-4066-b33f-8bacce7d03e7"));
            RepeatReason = (ITTObjectListBox)AddControl(new Guid("e9362623-0605-4aec-a97c-f957aa7d36f1"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("aa17ead2-33cc-4813-896d-06eb6d237ef0"));
            cmdPrintBarcode = (ITTButton)AddControl(new Guid("bc9ecd01-5cd3-4645-aebc-e063da677be8"));
            GridEquipments = (ITTGrid)AddControl(new Guid("6e70d2d9-8737-47cb-b23a-5103729d2533"));
            Equipment = (ITTListBoxColumn)AddControl(new Guid("1b8c8de7-698f-452b-bc42-9e9f38ae5e11"));
            base.InitializeControls();
        }

        public GeneticProcedureForm() : base("GENETIC", "GeneticProcedureForm")
        {
        }

        protected GeneticProcedureForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}