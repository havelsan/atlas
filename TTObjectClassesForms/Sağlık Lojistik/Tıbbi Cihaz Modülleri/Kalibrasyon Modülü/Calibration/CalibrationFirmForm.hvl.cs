
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
    /// Kalibrasyon (Firma)
    /// </summary>
    public partial class CalibrationFirmForm : CalibrationBaseForm
    {
    /// <summary>
    /// Kalibrasyon
    /// </summary>
        protected TTObjectClasses.Calibration _Calibration
        {
            get { return (TTObjectClasses.Calibration)_ttObject; }
        }

        protected ITTLabel ttlabel24;
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
        protected ITTRichTextBoxControl DetailDescription;
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
        protected ITTTextBox RequestNO;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox Description;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel labelRequestNO;
        protected ITTLabel ttlabel4;
        protected ITTObjectListBox ttobjectlistbox4;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel5;
        protected ITTLabel labelDescription;
        protected ITTLabel ttlabel30;
        override protected void InitializeControls()
        {
            ttlabel24 = (ITTLabel)AddControl(new Guid("659c47df-a7b4-4a9d-8673-b0f9977ceeac"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("9deab6c9-a8be-4e65-891e-31258a456eeb"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("73aa24ed-0579-4e31-b6c8-47223f493e39"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("7d8ece47-67c2-43fb-8d6d-20f210be0ab6"));
            FullCalibration = (ITTCheckBox)AddControl(new Guid("4c6bcab0-4bb4-446d-9460-59031f4e8fce"));
            LimitedCalibration = (ITTCheckBox)AddControl(new Guid("df1826eb-56de-4a2b-acd0-61067bb7ae1c"));
            NoNeedCalibration = (ITTCheckBox)AddControl(new Guid("d6af010d-37ee-49f3-a439-e6ff7589d96b"));
            NotCalibration = (ITTCheckBox)AddControl(new Guid("c59b9c03-9cf9-475c-841f-15aa71471222"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("2b5663b2-afa6-4d79-96a9-ec9c615e0583"));
            ttgrid2 = (ITTGrid)AddControl(new Guid("fa67e41d-5567-4513-8d83-39657ccd0c74"));
            ItemName = (ITTTextBoxColumn)AddControl(new Guid("5a2b3e21-4e07-4dcc-bef1-0e5f2e32a371"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("4e7a239f-ef1d-4376-bb23-6f22b881bc87"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("5b523aba-9c0f-42f0-b697-20a249a1e9a7"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("8f074fab-e95a-49d8-94d2-0803de4bd85e"));
            Calibrator = (ITTListBoxColumn)AddControl(new Guid("a1fa1ed1-ae87-492a-bc33-a0ea1888db7d"));
            Traceability = (ITTTextBoxColumn)AddControl(new Guid("51b1fca3-7e49-45ec-8e5d-c13f3cea8fad"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("eee10f30-1f24-47bc-9179-8e2ca67b144b"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("a6b5fd12-00b9-4bb7-83ff-5064f9d4012f"));
            CalibrationTests = (ITTGrid)AddControl(new Guid("98b82aa3-2acf-449f-9d99-848fc8d4cd3a"));
            CalibrationTestDefinition = (ITTListBoxColumn)AddControl(new Guid("13da0cf0-8791-431f-970b-b966eba2086c"));
            ApplicableTestCount = (ITTTextBoxColumn)AddControl(new Guid("0cb0e281-395c-43a3-9daf-bf19b1214047"));
            ExistingTestCount = (ITTTextBoxColumn)AddControl(new Guid("f94749aa-1e37-4e0f-bc1c-79efced2ca2f"));
            cmdReport = (ITTButtonColumn)AddControl(new Guid("63786084-60c5-47c7-a5ee-29954dc3ce98"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("3d5907ac-7016-4ee0-b1b0-506604bb6479"));
            tttextbox6 = (ITTTextBox)AddControl(new Guid("ba06d730-1b9a-402a-94de-96360e554944"));
            ttobjectlistbox3 = (ITTObjectListBox)AddControl(new Guid("094551c7-8120-4602-adf7-4da9217a006d"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("f88841c5-8519-488f-ae5d-3a58d46337fd"));
            tttextbox5 = (ITTTextBox)AddControl(new Guid("75ea1ba1-f009-4044-b33e-73c5a512eb5a"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("a8083237-7182-46c1-b3f2-69ef8f9bb27d"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("a9508dbe-e560-451d-a8d1-788dc8999cda"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("53241b6e-b921-4ba8-a080-c8be9335d472"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("31976a22-5d0d-4e0f-bf2d-fc759fa84789"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("4a00eef2-0072-469a-8baf-6a5ced906841"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("b2af25bf-025e-499c-9f6d-47211f749d9b"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("62a7654c-1696-496d-abb2-eb9dab9d134b"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("b7000b4f-cbfd-4218-9e32-72507938c6bd"));
            ttlabel19 = (ITTLabel)AddControl(new Guid("01ba561b-40a1-4c00-9130-2cbbe2ad3baa"));
            ttgroupbox3 = (ITTGroupBox)AddControl(new Guid("d2e9a9a6-cdfd-46eb-a2bb-dae332fde5e7"));
            tttextbox10 = (ITTTextBox)AddControl(new Guid("d0b4e086-02a0-4d89-add9-43c097459609"));
            tttextbox9 = (ITTTextBox)AddControl(new Guid("0192983c-b714-428c-b94d-30f34de2fb8d"));
            tttextbox7 = (ITTTextBox)AddControl(new Guid("3d0bcf46-fb27-47fa-8aec-5c2a5b6236fe"));
            ttlabel34 = (ITTLabel)AddControl(new Guid("88c0d95c-74cc-41f8-874f-78af14fa932b"));
            ttlabel35 = (ITTLabel)AddControl(new Guid("c3c70f08-d2b7-4ee0-a29b-01b39a8ef518"));
            ttlabel36 = (ITTLabel)AddControl(new Guid("b8139063-f60e-4178-b8fe-abafe0206b75"));
            ttlabel37 = (ITTLabel)AddControl(new Guid("d8f4c1d5-5592-42fc-bd8d-b5581f254bee"));
            ttlabel38 = (ITTLabel)AddControl(new Guid("199da480-c445-4d72-9d0b-09c4693c8474"));
            ttlabel39 = (ITTLabel)AddControl(new Guid("f9a66380-4bae-493d-a363-857a48d5a345"));
            ttlabel40 = (ITTLabel)AddControl(new Guid("dc4979f3-d511-4afc-9758-75c9186c044a"));
            ttlabel41 = (ITTLabel)AddControl(new Guid("ad093d18-c8e6-4c25-88d8-3e4ec39bbef9"));
            tttextbox8 = (ITTTextBox)AddControl(new Guid("98ee6694-8e8c-4cc6-9a88-97899b9509ce"));
            labelStartDate = (ITTLabel)AddControl(new Guid("1ab869fd-4588-4ae9-b916-9638dc01df0e"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("be4f6c82-ecf3-4c28-bd92-3dcdbf2db823"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("a0488ef6-0209-481c-a9d4-6630c62ffc42"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("488b0db2-5759-4a83-9a38-81328d739f81"));
            NotCalibreReason1 = (ITTCheckBox)AddControl(new Guid("28876df9-a708-414c-805b-5be37a96983b"));
            NotCalibreReason3 = (ITTCheckBox)AddControl(new Guid("c95eeae6-eaf8-47de-bbf4-4be43c90bfd5"));
            NotCalibreReason2 = (ITTCheckBox)AddControl(new Guid("87beea17-88d9-4339-9813-490f68d71359"));
            NotCalibreReason4 = (ITTCheckBox)AddControl(new Guid("5bbeda5b-62e3-43f4-82df-7c9b646e15cd"));
            NotCalibreReason5 = (ITTCheckBox)AddControl(new Guid("5db3fc92-f665-48f6-a814-a0e55862156f"));
            NotCalibreReasonDesc = (ITTTextBox)AddControl(new Guid("d583fb7e-b2f9-47c4-a0d6-6af5fa479111"));
            labelNotCalibreReasonDesc = (ITTLabel)AddControl(new Guid("c786e09d-48bd-472d-a46b-486acb9d8bb6"));
            DemandTabPage = (ITTTabPage)AddControl(new Guid("8ce81698-dc32-43a8-af6a-cc542819e675"));
            DetailDescription = (ITTRichTextBoxControl)AddControl(new Guid("7a8654e4-1112-4854-ba9b-790cdcd213aa"));
            ttbutton1 = (ITTButton)AddControl(new Guid("398fd2ac-8f34-4ea4-b072-a4c997edfda5"));
            ttobjectlistbox5 = (ITTObjectListBox)AddControl(new Guid("cbba9e83-7108-423c-a4d9-b550bbe490de"));
            ttlabel22 = (ITTLabel)AddControl(new Guid("71e4d478-e4a5-43b5-9f29-a454ca14450d"));
            ttlabel23 = (ITTLabel)AddControl(new Guid("42f433f8-ebca-4b95-9916-7df26a08d5ae"));
            txtProject = (ITTTextBox)AddControl(new Guid("4afdfdf1-85ca-4565-9965-a190b1fd1024"));
            ttlabel26 = (ITTLabel)AddControl(new Guid("284847f4-884a-4bb0-970f-8230369c0c24"));
            txtDemandNo = (ITTTextBox)AddControl(new Guid("d5f29228-b366-4346-85ad-2aacaa7d402b"));
            ttlabel25 = (ITTLabel)AddControl(new Guid("19c4f108-d896-48ab-8afa-9ba3eebf8682"));
            ttlabel21 = (ITTLabel)AddControl(new Guid("dfe8be63-fa34-401c-bd3a-9ecc24a0f3a3"));
            txtDemand = (ITTTextBox)AddControl(new Guid("7f278595-37fe-4808-ad98-f21fbb017330"));
            ttlabel20 = (ITTLabel)AddControl(new Guid("94a15996-cfd4-4764-a617-c2db643ba2f9"));
            txtLast = (ITTTextBox)AddControl(new Guid("f3dd969a-a6cc-4e8b-94a1-2c1e5d3d01c1"));
            cmdSupplierDef = (ITTButton)AddControl(new Guid("bae08695-7e2b-4fb8-a58c-2f4647191096"));
            ttdatetimepicker2 = (ITTDateTimePicker)AddControl(new Guid("56731fe5-6f54-42fd-b51d-d4723534d0a2"));
            ttlabel27 = (ITTLabel)AddControl(new Guid("4bc8fb0c-12c2-4421-99da-a77ee6e47f89"));
            ttobjectlistbox6 = (ITTObjectListBox)AddControl(new Guid("d538daf7-abef-4bf7-87cf-8a0eb74033e5"));
            ttlabel29 = (ITTLabel)AddControl(new Guid("a2e1742d-e385-4cea-848b-10fc83417c66"));
            ttlabel28 = (ITTLabel)AddControl(new Guid("c36ca0c3-5c41-4c1c-aac7-39f181d0088e"));
            ttdatetimepicker3 = (ITTDateTimePicker)AddControl(new Guid("801e8fd6-7da9-456e-9942-75d8d15f6512"));
            RequestNO = (ITTTextBox)AddControl(new Guid("3554cd4d-b1d2-4a11-9ccd-0421b460d408"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("2d235381-b557-47e6-ba4c-c21b8d8d254d"));
            Description = (ITTTextBox)AddControl(new Guid("b3560af8-3656-4a58-9173-885cfdf68387"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("53262ac2-3f44-4a6a-a7b0-3f5bb8bce156"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("ae9b2e1e-611d-4059-99be-33eeb215df33"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("f49d87a7-daa6-4ed9-acdd-203879f145ca"));
            ttobjectlistbox4 = (ITTObjectListBox)AddControl(new Guid("5f52b9c4-7c3b-40b0-80e3-4fbc13c81716"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("c2994e82-90f8-4dce-a874-bf2d2b31445a"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("9c342a93-a447-4698-bbe7-cf5f0db5cb00"));
            labelDescription = (ITTLabel)AddControl(new Guid("3ba1ce05-4e24-4504-b0bb-597a8b8b0b83"));
            ttlabel30 = (ITTLabel)AddControl(new Guid("a388a0f4-39c3-46f2-b319-641e99889b47"));
            base.InitializeControls();
        }

        public CalibrationFirmForm() : base("CALIBRATION", "CalibrationFirmForm")
        {
        }

        protected CalibrationFirmForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}