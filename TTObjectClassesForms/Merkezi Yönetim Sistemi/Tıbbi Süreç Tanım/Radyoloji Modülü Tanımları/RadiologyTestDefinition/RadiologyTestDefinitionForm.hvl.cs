
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
    /// Radyoloji Tetkik Tanımları
    /// </summary>
    public partial class RadiologyTestDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Radyoloji Tetkik Tanımları
    /// </summary>
        protected TTObjectClasses.RadiologyTestDefinition _RadiologyTestDefinition
        {
            get { return (TTObjectClasses.RadiologyTestDefinition)_ttObject; }
        }

        protected ITTLabel labelSUTAppendix;
        protected ITTEnumComboBox SUTAppendix;
        protected ITTLabel labelMedulaProcedureType;
        protected ITTEnumComboBox MedulaProcedureType;
        protected ITTLabel ttlabel15;
        protected ITTTextBox txtReasonForPassive;
        protected ITTTextBox Qref;
        protected ITTTextBox ID;
        protected ITTTextBox EnglishName;
        protected ITTTextBox Code;
        protected ITTCheckBox chlPassiveNow;
        protected ITTLabel labelName;
        protected ITTLabel labelQref;
        protected ITTLabel labelID;
        protected ITTCheckBox IsActive;
        protected ITTLabel ttlabel14;
        protected ITTLabel labelCode;
        protected ITTObjectListBox ttobjectlistbox3;
        protected ITTLabel labelEnglishName;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage4;
        protected ITTLabel ttlabel16;
        protected ITTGrid TabNameGrid;
        protected ITTListBoxColumn TabNames;
        protected ITTTextBoxColumn TabOrder;
        protected ITTGroupBox ttgroupbox2;
        protected ITTCheckBox chkSunday;
        protected ITTCheckBox chkSaturday;
        protected ITTCheckBox chkFriday;
        protected ITTCheckBox chkThursday;
        protected ITTCheckBox chkWednesday;
        protected ITTCheckBox chkTuesday;
        protected ITTCheckBox chkMonday;
        protected ITTCheckBox ttcheckbox1;
        protected ITTLabel labelBodyPart;
        protected ITTCheckBox ttcheckbox2;
        protected ITTEnumComboBox ttenumcombobox2;
        protected ITTTextBox TimeLimit;
        protected ITTTextBox TabRow;
        protected ITTLabel ttlabel7;
        protected ITTLabel ttlabel8;
        protected ITTObjectListBox TestType;
        protected ITTLabel ttlabel6;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTEnumComboBox ttenumcombobox1;
        protected ITTLabel labelDescription;
        protected ITTObjectListBox ttobjectlistbox2;
        protected ITTObjectListBox ttobjectlistbox4;
        protected ITTLabel ttlabel12;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel13;
        protected ITTTextBox Description;
        protected ITTLabel ttlabel11;
        protected ITTLabel ttlabel18;
        protected ITTTextBox tttextbox2;
        protected ITTTabPage tttabpage6;
        protected ITTLabel ttlabel4;
        protected ITTGrid ttgrid2;
        protected ITTListBoxColumn Test;
        protected ITTTabPage tttabpage1;
        protected ITTLabel ttlabel1;
        protected ITTGrid ttgrid3;
        protected ITTListBoxColumn Department;
        protected ITTTabPage tttabpage7;
        protected ITTGrid ttgrid4;
        protected ITTListBoxColumn Equipment;
        protected ITTLabel ttlabel2;
        protected ITTTabPage tttabpage5;
        protected ITTGrid ttgrid1;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Amount;
        protected ITTLabel ttlabel3;
        protected ITTTabPage tttabpage3;
        protected ITTGrid ttgrid5;
        protected ITTTextBoxColumn OrderNo;
        protected ITTListBoxColumn Name;
        protected ITTLabel ttlabel9;
        protected ITTLabel ttlabel10;
        protected ITTTabPage tttabpage2;
        protected ITTCheckBox chkAccessionModality;
        protected ITTTabPage tttabpage8;
        protected ITTLabel labelPreInformation;
        protected ITTTextBox PreInformation;
        protected ITTTextBox tttextbox1;
        protected ITTCheckBox ttcheckbox3;
        protected ITTLabel ttlabel17;
        protected ITTObjectListBox TTListBox;
        override protected void InitializeControls()
        {
            labelSUTAppendix = (ITTLabel)AddControl(new Guid("84bb48a3-fd62-4b1b-9cd0-3e20344b6e67"));
            SUTAppendix = (ITTEnumComboBox)AddControl(new Guid("66470707-fef6-4d0b-80b8-2e7357b42818"));
            labelMedulaProcedureType = (ITTLabel)AddControl(new Guid("696492d6-c327-4b5a-8449-b10e3518834c"));
            MedulaProcedureType = (ITTEnumComboBox)AddControl(new Guid("1a20b6f2-ee2f-4445-bd99-297d0a66f6d0"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("9b1d936f-8edf-4531-b19b-9eab2d4fed2c"));
            txtReasonForPassive = (ITTTextBox)AddControl(new Guid("d39a57c9-e99c-45a4-9b01-70ad69a3327a"));
            Qref = (ITTTextBox)AddControl(new Guid("3b7ba2e6-fc80-4c51-8be0-132acb976a07"));
            ID = (ITTTextBox)AddControl(new Guid("5c1cb0fa-249d-4ed8-9014-8e52c84ae835"));
            EnglishName = (ITTTextBox)AddControl(new Guid("94804a48-8bc2-44bb-bdba-9c3074593d6f"));
            Code = (ITTTextBox)AddControl(new Guid("528005c3-96d1-4a39-935a-9e225703d329"));
            chlPassiveNow = (ITTCheckBox)AddControl(new Guid("faca9d4f-eaa6-47d5-9764-b4d0525b080b"));
            labelName = (ITTLabel)AddControl(new Guid("8578ac86-ac8d-4202-9e8f-24d73614f564"));
            labelQref = (ITTLabel)AddControl(new Guid("c64ade00-38b3-4332-a373-4803d0e79b42"));
            labelID = (ITTLabel)AddControl(new Guid("17833cd9-8d27-46d0-be22-703c77eb30cd"));
            IsActive = (ITTCheckBox)AddControl(new Guid("b7487fe7-d16e-492c-a466-9cc675112b99"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("167e0bfd-c443-4d23-89d5-b30a438bebfa"));
            labelCode = (ITTLabel)AddControl(new Guid("cdb8dfad-ca69-43c5-9ea6-c08d2d4302dc"));
            ttobjectlistbox3 = (ITTObjectListBox)AddControl(new Guid("fdded459-a68c-4503-b1bf-ca9e8af5fe2f"));
            labelEnglishName = (ITTLabel)AddControl(new Guid("3ab8b002-943c-4e82-9830-db4f299ba8d5"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("df6a5d2a-dc5f-4fed-97cb-dde6c065b7ae"));
            tttabpage4 = (ITTTabPage)AddControl(new Guid("f3c8c9e8-8c05-44c4-8539-39ef5f497abb"));
            ttlabel16 = (ITTLabel)AddControl(new Guid("45aabe7d-010e-4e44-b883-dcb3ed128693"));
            TabNameGrid = (ITTGrid)AddControl(new Guid("6d27929d-5ba7-4a49-9dd5-4b6c92a6e592"));
            TabNames = (ITTListBoxColumn)AddControl(new Guid("3893df1c-50c8-4414-8404-42aa944f9ff9"));
            TabOrder = (ITTTextBoxColumn)AddControl(new Guid("6b845742-300f-46f1-87f0-7b6babd90a18"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("db346b91-4330-441e-a01f-f30738c0e433"));
            chkSunday = (ITTCheckBox)AddControl(new Guid("0d59f13e-03d7-4ef7-9d36-44a97631081f"));
            chkSaturday = (ITTCheckBox)AddControl(new Guid("90033d6d-41a2-4749-b558-84a350f6de69"));
            chkFriday = (ITTCheckBox)AddControl(new Guid("1e88192f-fe48-458a-932c-6cb6eb3241aa"));
            chkThursday = (ITTCheckBox)AddControl(new Guid("cbb3f174-c511-4f5a-877f-fd75be7be387"));
            chkWednesday = (ITTCheckBox)AddControl(new Guid("ef691a63-f0bd-49ea-aa99-51b6ffa0cb94"));
            chkTuesday = (ITTCheckBox)AddControl(new Guid("7d216782-d7b6-4918-b724-03c59c8f520a"));
            chkMonday = (ITTCheckBox)AddControl(new Guid("258f96f6-0bd5-4ee3-9a3d-f5c3b62523e6"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("bb0d55e8-39b5-4481-ba1f-435c19e8a4db"));
            labelBodyPart = (ITTLabel)AddControl(new Guid("6f2e7d8e-1b10-4163-9b23-4b1f31651cb0"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("fe19dc4b-4323-4c64-8273-5ff26089d96d"));
            ttenumcombobox2 = (ITTEnumComboBox)AddControl(new Guid("b9689683-2c9d-4f6e-a80f-70c3e3333b40"));
            TimeLimit = (ITTTextBox)AddControl(new Guid("8797963b-be2e-48ad-b3d3-740b19e6ed53"));
            TabRow = (ITTTextBox)AddControl(new Guid("f32c5b8b-9b69-485a-9859-77aa6e9fd6c4"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("44ebe4d1-9ed3-4e2f-877e-8506c4115192"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("3532e8fc-cea0-4ea4-91e0-8bf6f2e91784"));
            TestType = (ITTObjectListBox)AddControl(new Guid("c45b466f-03d3-429a-b8c1-9ca2db78ccfb"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("46808fa6-2d82-42d1-958a-be8ef655b3e7"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("7da3ad0f-76b1-49be-846f-cbff9b41e94f"));
            ttenumcombobox1 = (ITTEnumComboBox)AddControl(new Guid("ed52e92b-0182-47d2-b917-d5fa77c57c13"));
            labelDescription = (ITTLabel)AddControl(new Guid("8b21cd2f-8bd4-49f2-8606-e2f092fd3636"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("ffd0f5b5-b37a-48e8-a309-0b3d9ee5a8f7"));
            ttobjectlistbox4 = (ITTObjectListBox)AddControl(new Guid("54a100ea-f011-4217-b5ad-e29d1bdef8f5"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("4e26db58-a884-49a0-9759-50d36ff825db"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("4ae31f74-d5d4-4404-8e35-0d3b8e7c28c1"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("22f506c7-9203-4538-b208-17415c95a437"));
            Description = (ITTTextBox)AddControl(new Guid("1fbe743a-b4b2-4b34-bc88-1f628f73443b"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("5151482b-97a3-4ffb-a52a-2668dec7c849"));
            ttlabel18 = (ITTLabel)AddControl(new Guid("6c48ca95-429a-4abd-9a4f-30b70b51fa03"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("62393397-a0f8-424d-ba38-fe365215c0c8"));
            tttabpage6 = (ITTTabPage)AddControl(new Guid("6e71f251-5499-4a6d-a79a-ef0964b35713"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("aefc83ec-ef55-430f-8ff5-7f1452dea4c3"));
            ttgrid2 = (ITTGrid)AddControl(new Guid("43de1316-25aa-4812-a1a0-f79baa6ba086"));
            Test = (ITTListBoxColumn)AddControl(new Guid("419eaee1-2fa1-48b5-9d88-526e8a988ea5"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("06d3863e-28e6-4020-8064-53568203d787"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("79b4116a-f015-47dd-a995-7b0dcb776766"));
            ttgrid3 = (ITTGrid)AddControl(new Guid("8847ead5-5821-4d81-8b44-9d1a95aa5008"));
            Department = (ITTListBoxColumn)AddControl(new Guid("8fb760e5-8b9b-470a-b224-b3c588690c8a"));
            tttabpage7 = (ITTTabPage)AddControl(new Guid("827c9c4e-0f6c-42e6-9095-56abe3af4b6c"));
            ttgrid4 = (ITTGrid)AddControl(new Guid("9f45859b-7d63-4f0c-b4ad-5a121c1eb6a8"));
            Equipment = (ITTListBoxColumn)AddControl(new Guid("5ee043be-5d65-4d39-94b3-106607a0aba7"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("54e91276-a30a-42d9-b951-0ac044f5495f"));
            tttabpage5 = (ITTTabPage)AddControl(new Guid("03c77c58-0f32-4968-8881-77e18baddf17"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("207ab45c-8227-46ed-8fca-1eecf8eae074"));
            Material = (ITTListBoxColumn)AddControl(new Guid("513651f2-0ba6-46b7-bd6d-eef38d5d0c22"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("932ebabc-3521-42d3-b874-9466d22c302c"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("9140a461-869f-4547-b8eb-3cd6945b200c"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("6abcd58b-d86a-4e46-b3c1-9d8157204252"));
            ttgrid5 = (ITTGrid)AddControl(new Guid("2955ab67-bfa9-4a1b-bf77-25206600e8f1"));
            OrderNo = (ITTTextBoxColumn)AddControl(new Guid("03a4aca2-f05b-48ba-a9af-5100a93b48ea"));
            Name = (ITTListBoxColumn)AddControl(new Guid("db7f92cf-7227-4015-98c2-99b9a8b1a9b0"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("8e9ef41b-7dd9-42f1-8ff7-4fc86a927cdf"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("90526793-f908-4cc5-a561-5b3d0de99ea6"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("557b027e-7a26-40fa-b3eb-f5f5645c3380"));
            chkAccessionModality = (ITTCheckBox)AddControl(new Guid("bf2870b7-17a1-40e0-b16d-04085ed7227e"));
            tttabpage8 = (ITTTabPage)AddControl(new Guid("db13f2eb-afff-4e68-a279-74bb5e2bf96f"));
            labelPreInformation = (ITTLabel)AddControl(new Guid("a3eff869-28fb-4dfb-9f3b-e2a017e6af39"));
            PreInformation = (ITTTextBox)AddControl(new Guid("00071db5-a9de-48ad-b3e4-4ef1f4dc7a10"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("b29c1254-d079-42fe-b6a4-edb71bfd0b76"));
            ttcheckbox3 = (ITTCheckBox)AddControl(new Guid("7d53eabf-43cc-4adb-9f07-8981aa5bd83a"));
            ttlabel17 = (ITTLabel)AddControl(new Guid("f82f0e4b-ad77-4753-8c9f-3cbe20781b10"));
            TTListBox = (ITTObjectListBox)AddControl(new Guid("23d5d81e-7ab5-40c3-8e32-ee4aa0d59a53"));
            base.InitializeControls();
        }

        public RadiologyTestDefinitionForm() : base("RADIOLOGYTESTDEFINITION", "RadiologyTestDefinitionForm")
        {
        }

        protected RadiologyTestDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}