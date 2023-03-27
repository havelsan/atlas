
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
    /// Tamamlanmış Kalibrasyon
    /// </summary>
    public partial class CalibrationCompletedForm : CalibrationBaseForm
    {
    /// <summary>
    /// Kalibrasyon
    /// </summary>
        protected TTObjectClasses.Calibration _Calibration
        {
            get { return (TTObjectClasses.Calibration)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTGrid ttgrid2;
        protected ITTTextBoxColumn ItemName;
        protected ITTTextBoxColumn Amount;
        protected ITTLabel ttlabel3;
        protected ITTGrid ttgrid1;
        protected ITTListBoxColumn Calibrator;
        protected ITTLabel ttlabel2;
        protected ITTGrid CalibrationTests;
        protected ITTListBoxColumn CalibrationTestDefinition;
        protected ITTTextBoxColumn ApplicableTestCount;
        protected ITTTextBoxColumn ExistingTestCount;
        protected ITTButtonColumn cmdReport;
        protected ITTGroupBox ttgroupbox2;
        protected ITTCheckBox FullCalibration;
        protected ITTCheckBox LimitedCalibration;
        protected ITTCheckBox NoNeedCalibration;
        protected ITTCheckBox NotCalibration;
        protected ITTLabel ttlabel9;
        protected ITTTabPage tttabpage2;
        protected ITTTextBox tttextbox7;
        protected ITTTextBox tttextbox6;
        protected ITTLabel ttlabel15;
        protected ITTLabel ttlabel14;
        protected ITTLabel ttlabel13;
        protected ITTObjectListBox ttobjectlistbox3;
        protected ITTObjectListBox ttobjectlistbox2;
        protected ITTTextBox tttextbox5;
        protected ITTTextBox tttextbox4;
        protected ITTTextBox tttextbox3;
        protected ITTTextBox tttextbox2;
        protected ITTLabel ttlabel12;
        protected ITTLabel ttlabel11;
        protected ITTLabel ttlabel10;
        protected ITTLabel ttlabel8;
        protected ITTLabel ttlabel7;
        protected ITTLabel ttlabel6;
        protected ITTDateTimePicker StartDate;
        protected ITTDateTimePicker EndDate;
        protected ITTLabel labelStartDate;
        protected ITTLabel ttlabel16;
        protected ITTTabPage tttabpage3;
        protected ITTLabel labelNotCalibreReasonDesc;
        protected ITTCheckBox NotCalibreReason1;
        protected ITTCheckBox NotCalibreReason5;
        protected ITTCheckBox NotCalibreReason4;
        protected ITTCheckBox NotCalibreReason3;
        protected ITTCheckBox NotCalibreReason2;
        protected ITTTextBox NotCalibreReasonDesc;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox RequestNO;
        protected ITTTextBox Description;
        protected ITTLabel CalibrationStatusLabel;
        protected ITTLabel ttlabel5;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel4;
        protected ITTLabel labelRequestDate;
        protected ITTLabel labelRequestNO;
        protected ITTLabel labelDescription;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox ttobjectlistbox4;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("0e3ab2fe-ed23-4f88-9520-93ff82427179"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("b085ae73-91ea-4f37-aaba-242d56636123"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("db24f2db-9b85-49e9-a9d6-479c3f3fd9ae"));
            ttgrid2 = (ITTGrid)AddControl(new Guid("e028aa48-443a-4698-ab52-7501e9c17ccf"));
            ItemName = (ITTTextBoxColumn)AddControl(new Guid("7d6dfd3f-31f4-4279-ad23-eb44a473a4e4"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("2ec45438-6259-4872-9b98-2361a7d1eb76"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("bdac2cb8-c74e-463d-ac4d-0dddc230de99"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("e8104d70-9cdb-45e0-a0de-a65a7a5990c1"));
            Calibrator = (ITTListBoxColumn)AddControl(new Guid("5cad96e8-45c6-4630-8d7e-ebc8a592b245"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("110a010b-0558-4f02-bcae-8994f595635a"));
            CalibrationTests = (ITTGrid)AddControl(new Guid("22b72043-1f2b-4f96-bd66-ec0fea0bb805"));
            CalibrationTestDefinition = (ITTListBoxColumn)AddControl(new Guid("18b6e0ec-24c2-4cc8-bc87-dc8a794136a6"));
            ApplicableTestCount = (ITTTextBoxColumn)AddControl(new Guid("cf77719e-a156-4b1a-866c-e3db12cdf8e8"));
            ExistingTestCount = (ITTTextBoxColumn)AddControl(new Guid("9d589930-1171-4ee9-b326-a1692c41f242"));
            cmdReport = (ITTButtonColumn)AddControl(new Guid("1538f202-fc1f-4b54-986b-1c89e7ce34f8"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("63ec8615-36c5-44c1-b9cb-1edaa390b232"));
            FullCalibration = (ITTCheckBox)AddControl(new Guid("c6d0637b-167e-4839-a865-9cb8166505b8"));
            LimitedCalibration = (ITTCheckBox)AddControl(new Guid("7ca5a912-636c-41ef-848c-b99b3ffd5754"));
            NoNeedCalibration = (ITTCheckBox)AddControl(new Guid("2a7f305d-d72b-43fd-bdca-671c0bff71e4"));
            NotCalibration = (ITTCheckBox)AddControl(new Guid("10a50071-c23f-43d0-b3f2-4729d6b8faeb"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("bfefab59-16a2-4b9d-a1d1-3862bd5ac57a"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("205caaf5-bb26-4365-975b-ddd85855c751"));
            tttextbox7 = (ITTTextBox)AddControl(new Guid("66282134-3917-4124-b447-1fe1cb4f3f88"));
            tttextbox6 = (ITTTextBox)AddControl(new Guid("491dbe51-70df-49ba-8748-c5b901f38093"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("b611f33b-2ed8-45a1-a46a-95940d8fb4fa"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("df50c431-fa33-457f-bbfe-2e650a1ad6a3"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("70487dac-3cfc-467c-ad7d-2e6e4cd6341f"));
            ttobjectlistbox3 = (ITTObjectListBox)AddControl(new Guid("86713bd3-052f-4818-a0c0-bc39d3e40d8c"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("4c5ddab2-6c38-4c6e-98ac-876b4b49e677"));
            tttextbox5 = (ITTTextBox)AddControl(new Guid("2fd18f94-5d8f-4ea4-b44f-6e1c9cfc7326"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("4d03ce72-dc14-4644-8e2b-e76d3491131d"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("432b39ea-ff9a-4348-a20f-9517df8c84f6"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("31a5a26a-312c-4b14-b01e-bf1b6a0729ff"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("6c5f62c6-4fc7-4ec0-9b0b-abbf8db700e7"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("158567dd-3b0a-4aff-9183-397e5a8a4716"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("43e8da77-8d4a-48c9-aed9-23cae9808440"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("0937f846-8643-4e95-aee3-2a1a198ce181"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("f4c1311d-25ac-45d0-bde6-70a053bc1398"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("dec9d8e2-202b-41cb-a63d-9cea7aac5261"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("7d745bcf-030d-4c06-a557-cf391c223931"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("a19dd960-a5df-45c3-ac43-5ff2da98aaca"));
            labelStartDate = (ITTLabel)AddControl(new Guid("89e3531e-65ff-49a7-9191-a897fb4a783f"));
            ttlabel16 = (ITTLabel)AddControl(new Guid("33f3531f-9c19-418d-a201-7473ee2444ce"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("4d835fbb-80be-4e36-be3b-1ab364232da6"));
            labelNotCalibreReasonDesc = (ITTLabel)AddControl(new Guid("95db0517-16b4-436d-a381-f40b10caab37"));
            NotCalibreReason1 = (ITTCheckBox)AddControl(new Guid("20e2c35c-8e7f-497f-8bbc-25da6975b592"));
            NotCalibreReason5 = (ITTCheckBox)AddControl(new Guid("d2de1400-7f09-42bb-81bd-11ab08426884"));
            NotCalibreReason4 = (ITTCheckBox)AddControl(new Guid("2ca008c0-8a10-4953-bdcf-979faf9f14cd"));
            NotCalibreReason3 = (ITTCheckBox)AddControl(new Guid("d89ae789-bb2c-469d-bf17-dce39cbf39b4"));
            NotCalibreReason2 = (ITTCheckBox)AddControl(new Guid("fe06bc6a-445b-4ce8-917a-962a420f4490"));
            NotCalibreReasonDesc = (ITTTextBox)AddControl(new Guid("4694526c-a23d-4be6-81f3-5b30f52eb8e8"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("ab0c44b0-2979-4e63-b2a3-a9ca6ef93f36"));
            RequestNO = (ITTTextBox)AddControl(new Guid("65c9910c-3d60-4e44-9222-87d36e5eecb3"));
            Description = (ITTTextBox)AddControl(new Guid("5543520c-eccf-44f6-9cd3-ba73d67a11ec"));
            CalibrationStatusLabel = (ITTLabel)AddControl(new Guid("552a399e-8f06-4f96-9438-519f9ab1bc19"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("b7a1f158-a48b-42b9-9cd5-e614dd3881cc"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("dad4d4ad-5ca6-479e-96a8-702c1ea2391d"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("005baa76-fce0-4dae-8d23-5db6ef3fac4f"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("b46be7e3-63cd-449c-a46c-bdb63fc3da73"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("bd844f53-9441-4c2d-a1de-29663e64f91d"));
            labelDescription = (ITTLabel)AddControl(new Guid("16ccf7fa-d1eb-4649-bde4-55bfd4a2497c"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("3f436974-949a-4f7a-b94d-f4c00f9e51e5"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("e40ffd67-935a-4949-9f74-b0b16d092cbf"));
            ttobjectlistbox4 = (ITTObjectListBox)AddControl(new Guid("fa9e4163-5356-4b8a-b3ca-9c404143394f"));
            base.InitializeControls();
        }

        public CalibrationCompletedForm() : base("CALIBRATION", "CalibrationCompletedForm")
        {
        }

        protected CalibrationCompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}