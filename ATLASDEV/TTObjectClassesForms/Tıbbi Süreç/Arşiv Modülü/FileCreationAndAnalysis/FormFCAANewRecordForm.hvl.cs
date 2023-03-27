
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
    /// Dosya Oluşturma ve Analiz
    /// </summary>
    public partial class FormFCAANewRecord : EpisodeActionForm
    {
    /// <summary>
    /// Dosya Oluşturma ve Analiz (Arşiv Oluşturma) İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.FileCreationAndAnalysis _FileCreationAndAnalysis
        {
            get { return (TTObjectClasses.FileCreationAndAnalysis)_ttObject; }
        }

        protected ITTCheckBox chkAdliVaka;
        protected ITTLabel ttlabel1;
        protected ITTTextBox tttextboxOnlyYear;
        protected ITTTextBox Shelf;
        protected ITTTextBox FolderInformation;
        protected ITTTextBox Row;
        protected ITTTextBox PatientFolderID;
        protected ITTTextBox EpisodeFolderDefID;
        protected ITTTextBox txtRoom;
        protected ITTLabel LabelRequestDate;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelFolderContent;
        protected ITTLabel labelShelf;
        protected ITTGrid FolderContents;
        protected ITTTextBoxColumn EpisodeFolderID;
        protected ITTListBoxColumn File;
        protected ITTCheckBoxColumn Status;
        protected ITTLabel labelFolderInformation;
        protected ITTLabel labelRow;
        protected ITTLabel labelPatientFolderID;
        protected ITTLabel labelEpisodeFolderID;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox listBoxBuilding;
        protected ITTLabel lblBuilding;
        protected ITTGrid PatientEpisodeDetails;
        protected ITTDateTimePickerColumn OpeningDate;
        protected ITTTextBoxColumn EpisodeID;
        protected ITTTextBoxColumn VolumeNo;
        protected ITTListBoxColumn ReasonForAdmission;
        protected ITTLabel ttlabel3;
        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel ttlabel4;
        protected ITTTextBox tttextbox1;
        protected ITTCheckBox chkHMHastaYakini;
        protected ITTCheckBox ttcheckbox2;
        protected ITTCheckBox ttcheckbox3;
        protected ITTCheckBox ttcheckbox4;
        protected ITTCheckBox ttcheckbox5;
        protected ITTCheckBox ttcheckbox6;
        protected ITTCheckBox ttcheckbox7;
        protected ITTGroupBox ttgroupbox2;
        protected ITTCheckBox ttcheckbox8;
        protected ITTCheckBox ttcheckbox9;
        protected ITTCheckBox ttcheckbox10;
        protected ITTCheckBox ttcheckbox11;
        protected ITTCheckBox ttcheckbox12;
        protected ITTCheckBox ttcheckbox13;
        protected ITTCheckBox ttcheckbox14;
        protected ITTCheckBox ttcheckbox18;
        protected ITTCheckBox ttcheckbox17;
        protected ITTCheckBox ttcheckbox16;
        protected ITTCheckBox ttcheckbox15;
        protected ITTCheckBox ttcheckbox19;
        protected ITTTextBox tttextbox2;
        protected ITTLabel ttlabel5;
        protected ITTGroupBox ttgroupbox3;
        protected ITTCheckBox ttcheckbox20;
        protected ITTTextBox tttextbox3;
        protected ITTLabel ttlabel6;
        override protected void InitializeControls()
        {
            chkAdliVaka = (ITTCheckBox)AddControl(new Guid("fa4740f8-2269-4967-94b8-b26cdaa938e2"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("6c64f553-98cc-4b98-b4bf-1d0b96487eb0"));
            tttextboxOnlyYear = (ITTTextBox)AddControl(new Guid("8ebf4662-5547-401f-9913-1d18f60ed88b"));
            Shelf = (ITTTextBox)AddControl(new Guid("5f0c71e6-8452-442c-b658-1ec867e06fbe"));
            FolderInformation = (ITTTextBox)AddControl(new Guid("78672568-db39-4122-9f58-7a8356359100"));
            Row = (ITTTextBox)AddControl(new Guid("1f0ef6df-c3fd-4260-bfe3-8e81e5644133"));
            PatientFolderID = (ITTTextBox)AddControl(new Guid("953f578d-f4d4-4825-b79c-91a0d590c9ed"));
            EpisodeFolderDefID = (ITTTextBox)AddControl(new Guid("4e541bfc-9c91-4317-be7f-aebfcd1dc8d3"));
            txtRoom = (ITTTextBox)AddControl(new Guid("d1260261-8362-4701-9719-1084f0c644a9"));
            LabelRequestDate = (ITTLabel)AddControl(new Guid("316ca0b0-2809-43ef-8d7d-f58f494bd0d4"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("56391863-e6ee-42ec-8b1d-23d43c807c8e"));
            labelFolderContent = (ITTLabel)AddControl(new Guid("7226179a-4dd9-4e40-8f5c-21ead2b57273"));
            labelShelf = (ITTLabel)AddControl(new Guid("485e5f94-35ef-478a-b8d7-4e1c13a65893"));
            FolderContents = (ITTGrid)AddControl(new Guid("990fc8b1-24ac-4fce-999b-650e5386f544"));
            EpisodeFolderID = (ITTTextBoxColumn)AddControl(new Guid("bf54bb48-adfb-4c64-a140-973902c8a8fc"));
            File = (ITTListBoxColumn)AddControl(new Guid("c9a1133c-4226-44c8-a7c9-ab3a0b1f2075"));
            Status = (ITTCheckBoxColumn)AddControl(new Guid("bf075e63-0c76-439a-95b8-6741301e4f67"));
            labelFolderInformation = (ITTLabel)AddControl(new Guid("62b357f7-aded-4823-a276-697bfb7e7d45"));
            labelRow = (ITTLabel)AddControl(new Guid("1d874d5e-84ed-404f-acdb-9a57043c8609"));
            labelPatientFolderID = (ITTLabel)AddControl(new Guid("2c227b26-0980-414f-842e-aa24433ec00c"));
            labelEpisodeFolderID = (ITTLabel)AddControl(new Guid("ba977ac5-6bf1-430e-8188-ab5fd8f53360"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("119d89fb-2461-4ca9-a48b-6882d5f424dd"));
            listBoxBuilding = (ITTObjectListBox)AddControl(new Guid("1a66f333-af45-4243-a20a-603199ca82f0"));
            lblBuilding = (ITTLabel)AddControl(new Guid("35598310-48c8-4da4-9d49-d8b596810d79"));
            PatientEpisodeDetails = (ITTGrid)AddControl(new Guid("c1abc258-74b7-44c1-9705-f39e06164e44"));
            OpeningDate = (ITTDateTimePickerColumn)AddControl(new Guid("ea07b455-7a73-4515-b4eb-26b6d8dc7ec5"));
            EpisodeID = (ITTTextBoxColumn)AddControl(new Guid("67ba2301-f41a-4653-93ca-325d52b9e9cf"));
            VolumeNo = (ITTTextBoxColumn)AddControl(new Guid("095f5243-6081-4bf8-b553-cacd828b91db"));
            ReasonForAdmission = (ITTListBoxColumn)AddControl(new Guid("ce8589f6-34d8-4094-b734-7d7565b3c7fc"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("c34c3288-8f5f-4a3b-a2dc-95064d19dfde"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("60c8f9a2-5f36-4c55-ae50-1250450054d8"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("e631cb67-4efa-4058-bf50-f49cc9185b98"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("a2554d78-430b-4975-bb38-a2d63abb3696"));
            chkHMHastaYakini = (ITTCheckBox)AddControl(new Guid("d65d39e3-b1bb-4131-b0ac-3b313134b85a"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("713b19fe-78c3-45e3-88cb-a78caa7f44ec"));
            ttcheckbox3 = (ITTCheckBox)AddControl(new Guid("7ef66769-f1a9-4f1c-82ef-0f2e3381734b"));
            ttcheckbox4 = (ITTCheckBox)AddControl(new Guid("b0bf8db6-3e85-4967-9487-f738de18adef"));
            ttcheckbox5 = (ITTCheckBox)AddControl(new Guid("ac0ef690-4cb5-410a-b9b7-ac8e70a10438"));
            ttcheckbox6 = (ITTCheckBox)AddControl(new Guid("1b5dc725-1d95-4621-b460-9dd65e5d6d76"));
            ttcheckbox7 = (ITTCheckBox)AddControl(new Guid("f82a53b2-a8c9-466f-8300-915bb6d637ed"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("9e156471-5017-41d4-a474-af4ea328979a"));
            ttcheckbox8 = (ITTCheckBox)AddControl(new Guid("ff8f6215-1004-482e-ab7e-25b6f2106517"));
            ttcheckbox9 = (ITTCheckBox)AddControl(new Guid("fc35ceee-e99a-49a3-8a52-cc02c788e568"));
            ttcheckbox10 = (ITTCheckBox)AddControl(new Guid("605e6baf-3059-4b7e-bf4f-4e5f57b60b06"));
            ttcheckbox11 = (ITTCheckBox)AddControl(new Guid("e6e8664a-3512-47c2-8850-309c065ee31b"));
            ttcheckbox12 = (ITTCheckBox)AddControl(new Guid("80696bdb-605e-431e-9fc2-eb17293078c5"));
            ttcheckbox13 = (ITTCheckBox)AddControl(new Guid("0b222c3b-7778-40c0-9300-0eedcb3c33f4"));
            ttcheckbox14 = (ITTCheckBox)AddControl(new Guid("bdb46447-10f1-4630-9a40-500de6254ebe"));
            ttcheckbox18 = (ITTCheckBox)AddControl(new Guid("6ad9c0fe-b814-48c0-9efa-b153a3f1a998"));
            ttcheckbox17 = (ITTCheckBox)AddControl(new Guid("cb64d083-5f1e-4553-b817-7a6486a860e2"));
            ttcheckbox16 = (ITTCheckBox)AddControl(new Guid("c24dac42-077c-4ff3-ad0e-d027bee93849"));
            ttcheckbox15 = (ITTCheckBox)AddControl(new Guid("d815b700-6688-4179-bb50-699c65b08eb4"));
            ttcheckbox19 = (ITTCheckBox)AddControl(new Guid("65dd0ba5-af87-4be5-8c49-2d39346a737d"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("2fc1b671-6a62-4ffc-a42c-a40760a40274"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("7f362a68-8704-462b-828b-2b7ff5c9593d"));
            ttgroupbox3 = (ITTGroupBox)AddControl(new Guid("7d004539-ab5a-4669-932c-1a1d9d3567f7"));
            ttcheckbox20 = (ITTCheckBox)AddControl(new Guid("7d475af7-1e02-4af0-99b9-651e8f342aed"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("43eaec74-fa42-4665-a374-a50850436016"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("fed2a060-6ef2-489e-8afb-ed25b77653d9"));
            base.InitializeControls();
        }

        public FormFCAANewRecord() : base("FILECREATIONANDANALYSIS", "FormFCAANewRecord")
        {
        }

        protected FormFCAANewRecord(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}