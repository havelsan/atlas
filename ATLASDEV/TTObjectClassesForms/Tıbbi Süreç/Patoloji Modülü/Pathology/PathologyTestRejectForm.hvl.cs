
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
    public partial class PathologyTestRejectForm : TTForm
    {
    /// <summary>
    /// Patoloji
    /// </summary>
        protected TTObjectClasses.Pathology _Pathology
        {
            get { return (TTObjectClasses.Pathology)_ttObject; }
        }

        protected ITTLabel ttlabel3;
        protected ITTTextBox REQUESTDOCTORPHONENUMBER;
        protected ITTTextBox RESPONSIBLEDOCTORPHONENO;
        protected ITTTextBox MaterialResponsible;
        protected ITTTextBox Description;
        protected ITTTextBox AcceptionNote;
        protected ITTLabel ttlabel4;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelActionDate;
        protected ITTObjectListBox REQUESTDOCTOR;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn ttcheckboxcolumn1;
        protected ITTListBoxColumn ttlistboxcolumn1;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn ttcheckboxcolumn2;
        protected ITTListBoxColumn ttlistboxcolumn2;
        protected ITTDateTimePickerColumn ttdatetimepickercolumn1;
        protected ITTEnumComboBoxColumn ttenumcomboboxcolumn2;
        protected ITTLabel ttlabel9;
        protected ITTLabel ttlabel10;
        protected ITTLabel ttlabel12;
        protected ITTLabel ttlabel13;
        protected ITTLabel ttlabel14;
        protected ITTObjectListBox ResposibleDoctor;
        protected ITTLabel ttlabel15;
        protected ITTLabel labelPrediagnosis;
        protected ITTLabel labelDesctiption;
        protected ITTLabel ttlabel18;
        protected ITTObjectListBox AssistantDoctor;
        protected ITTTabControl TabPathologyProcedure;
        protected ITTTabPage TabPageProcedure;
        protected ITTLabel ttlabel16;
        override protected void InitializeControls()
        {
            ttlabel3 = (ITTLabel)AddControl(new Guid("2e39ecfc-6599-4467-b451-038b8324efef"));
            REQUESTDOCTORPHONENUMBER = (ITTTextBox)AddControl(new Guid("f6ecdddc-e9a9-4d89-9390-e47e415c16d3"));
            RESPONSIBLEDOCTORPHONENO = (ITTTextBox)AddControl(new Guid("f5dfb9b1-6c9f-4fee-939f-42e85b377e2a"));
            MaterialResponsible = (ITTTextBox)AddControl(new Guid("53ef21ac-f78d-40ed-9899-4e7018e6340f"));
            Description = (ITTTextBox)AddControl(new Guid("a010ab12-fac4-4a82-b9f9-d64dcd9abfb7"));
            AcceptionNote = (ITTTextBox)AddControl(new Guid("c3cb1e71-411d-476e-a056-a5d52b724e85"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("c8f13e4d-91ce-4cac-b8f5-2f16a5f7d9ab"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("42793c82-f89d-4d9f-80d0-6a8a1e2d77a1"));
            labelActionDate = (ITTLabel)AddControl(new Guid("3c2ac040-c38e-499c-b842-5ad5ae8abac7"));
            REQUESTDOCTOR = (ITTObjectListBox)AddControl(new Guid("f86934af-09aa-4178-8036-86ec60f671ae"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("f65eed5c-6c53-41b0-bb1e-e7792298b023"));
            ttcheckboxcolumn1 = (ITTCheckBoxColumn)AddControl(new Guid("5fecf1cb-ef54-41c3-bca1-8b031cb6dd1a"));
            ttlistboxcolumn1 = (ITTListBoxColumn)AddControl(new Guid("43ee8b55-dbd8-4480-980c-4478a6fb373c"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("cceddbff-e127-43a7-b2dc-a17994ef9b8e"));
            ttcheckboxcolumn2 = (ITTCheckBoxColumn)AddControl(new Guid("30d8839f-a45b-49f8-a2b5-c1e7ca7079b7"));
            ttlistboxcolumn2 = (ITTListBoxColumn)AddControl(new Guid("7a21198b-43e4-46f8-ad46-de161b01c47c"));
            ttdatetimepickercolumn1 = (ITTDateTimePickerColumn)AddControl(new Guid("eaf050ce-f7a3-4f24-b221-5821e9cc597a"));
            ttenumcomboboxcolumn2 = (ITTEnumComboBoxColumn)AddControl(new Guid("806200c5-dc64-4739-85fd-316eb66ca768"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("500d8454-d8cd-422f-8ee1-77bfa1b2ee79"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("fcecc12b-1ac8-44b5-bcab-7baf4ec857a0"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("912edb1a-6ea2-414b-9125-d03f45b64ae1"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("4e68b31b-7a7c-49d9-9fe0-41c4814318bf"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("71ac5381-c9fa-4955-ac9e-8f4febc4395a"));
            ResposibleDoctor = (ITTObjectListBox)AddControl(new Guid("41b555d0-11fc-4a75-a256-ae649ee08c1f"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("171570e4-248f-4196-9657-d5517b677e21"));
            labelPrediagnosis = (ITTLabel)AddControl(new Guid("7be6fe20-0bbc-4dbe-8b99-0e93b22c6ccc"));
            labelDesctiption = (ITTLabel)AddControl(new Guid("8100c4c6-1729-4a23-b113-fea2f39722a9"));
            ttlabel18 = (ITTLabel)AddControl(new Guid("b3f914c1-90d2-49b3-9d31-fabd8cba18ce"));
            AssistantDoctor = (ITTObjectListBox)AddControl(new Guid("8096089b-079b-4557-9e83-867385722351"));
            TabPathologyProcedure = (ITTTabControl)AddControl(new Guid("c987372d-e911-4e4f-91a8-f2e49dc80949"));
            TabPageProcedure = (ITTTabPage)AddControl(new Guid("2b56b4da-0ae2-4066-a857-e5352b85c064"));
            ttlabel16 = (ITTLabel)AddControl(new Guid("8d849f28-7c64-4a0a-99c4-d7367c28f249"));
            base.InitializeControls();
        }

        public PathologyTestRejectForm() : base("PATHOLOGY", "PathologyTestRejectForm")
        {
        }

        protected PathologyTestRejectForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}