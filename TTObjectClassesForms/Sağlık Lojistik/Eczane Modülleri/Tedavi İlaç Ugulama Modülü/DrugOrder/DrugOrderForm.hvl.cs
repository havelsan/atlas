
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
    /// İlaç Direktifi
    /// </summary>
    public partial class DrugOrderForm : TTForm
    {
    /// <summary>
    /// İlaç Direktifi
    /// </summary>
        protected TTObjectClasses.DrugOrder _DrugOrder
        {
            get { return (TTObjectClasses.DrugOrder)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid DrugOrderDetails;
        protected ITTDateTimePickerColumn OrderPlannedDate;
        protected ITTTextBoxColumn Note;
        protected ITTStateComboBoxColumn State;
        protected ITTTextBoxColumn Amount;
        protected ITTTabPage tttabpage2;
        protected ITTGroupBox ttgroupbox2;
        protected ITTGrid MagistralChemicalDetails;
        protected ITTListBoxColumn MagistralChemicalDefinition;
        protected ITTTextBoxColumn ChemicalAmount;
        protected ITTListBoxColumn ChemicalDistType;
        protected ITTGroupBox ttgroupbox1;
        protected ITTGrid MagistralDrugDetails;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn PreparatAmount;
        protected ITTListBoxColumn DistributType;
        protected ITTTextBox Day;
        protected ITTTextBox UsageNote;
        protected ITTTextBox ID;
        protected ITTTextBox DoseAmount;
        protected ITTTextBox Type;
        protected ITTLabel labelUsageNote;
        protected ITTEnumComboBox Frequency;
        protected ITTObjectListBox Drug;
        protected ITTDateTimePicker PlannedStartTime;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelDay;
        protected ITTLabel labelFrequency;
        protected ITTLabel labelActionDate;
        protected ITTLabel labelDrug;
        protected ITTLabel labelID;
        protected ITTLabel labelDoseAmount;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelType;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("a8207246-2df5-41fb-90b5-1518c7bf0dac"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("351fb973-028f-4545-97f0-92f8ae581048"));
            DrugOrderDetails = (ITTGrid)AddControl(new Guid("d1377f94-8890-48dd-aa09-8056795b76a3"));
            OrderPlannedDate = (ITTDateTimePickerColumn)AddControl(new Guid("4dc9a28a-7b0d-45d9-aecf-5a2aa11faf6e"));
            Note = (ITTTextBoxColumn)AddControl(new Guid("5ad0f737-7f59-41b0-a91a-ceaba6245113"));
            State = (ITTStateComboBoxColumn)AddControl(new Guid("1671d326-5f3d-4691-bb8a-98af66aa18e7"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("97512623-a6df-4671-87c8-0e03d2c957d5"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("b7fc1f32-c79d-4f20-b655-c312dbf67640"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("0a25a3c8-b98c-477e-b163-146ec66e1fe0"));
            MagistralChemicalDetails = (ITTGrid)AddControl(new Guid("9bd4387b-1de6-4569-a6d7-20d339eb25da"));
            MagistralChemicalDefinition = (ITTListBoxColumn)AddControl(new Guid("20cf4906-d8c4-44a0-b4db-5b2182f0a77e"));
            ChemicalAmount = (ITTTextBoxColumn)AddControl(new Guid("8f296997-2bc0-4edc-a637-f73fa6c0cc9d"));
            ChemicalDistType = (ITTListBoxColumn)AddControl(new Guid("a39f9708-92c7-4011-9e63-16fc6a273db2"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("f65f7dee-cc14-45ca-938b-e7037f3696db"));
            MagistralDrugDetails = (ITTGrid)AddControl(new Guid("f06a3f1c-9aa7-4537-8cfc-e33b7af55089"));
            Material = (ITTListBoxColumn)AddControl(new Guid("7c399b34-a727-4215-9979-67133b5761c4"));
            PreparatAmount = (ITTTextBoxColumn)AddControl(new Guid("1a50104f-8080-4107-aa51-28c6ee1463b8"));
            DistributType = (ITTListBoxColumn)AddControl(new Guid("906be56f-0baf-46e3-bb5f-28f408a0b753"));
            Day = (ITTTextBox)AddControl(new Guid("6ea05fc2-f210-4d00-8a70-352896cf8e18"));
            UsageNote = (ITTTextBox)AddControl(new Guid("8a139c97-cff7-4cd0-8d70-3f5047538715"));
            ID = (ITTTextBox)AddControl(new Guid("94b46bc5-6ec8-4a9e-8498-423d05cdaf41"));
            DoseAmount = (ITTTextBox)AddControl(new Guid("84b8adf4-4fca-43a7-a862-50948988b69f"));
            Type = (ITTTextBox)AddControl(new Guid("3c8b43e4-cd1a-48ca-bb85-e9209ce8cc95"));
            labelUsageNote = (ITTLabel)AddControl(new Guid("c6dabfcf-44ef-4c46-bd88-1fc8fd120b85"));
            Frequency = (ITTEnumComboBox)AddControl(new Guid("347d401e-64ec-4e8b-b9f9-35f73b81c882"));
            Drug = (ITTObjectListBox)AddControl(new Guid("cd160b20-e160-4a61-ae60-420d0e5ae0fa"));
            PlannedStartTime = (ITTDateTimePicker)AddControl(new Guid("ba7ff7d1-d53c-419b-aed8-7a418f1c1751"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("b11c5cd7-7637-4dd9-b1e1-a084d541734a"));
            labelDay = (ITTLabel)AddControl(new Guid("dfc08dc3-be1f-42b1-8e96-a4d830a59eca"));
            labelFrequency = (ITTLabel)AddControl(new Guid("1a520420-4d7a-4ded-9e80-a51fbe7e20e2"));
            labelActionDate = (ITTLabel)AddControl(new Guid("24f1b4cd-5643-4df3-b52d-c227d658dd2a"));
            labelDrug = (ITTLabel)AddControl(new Guid("1e35eb43-0586-4eff-98b3-c5dc6733f666"));
            labelID = (ITTLabel)AddControl(new Guid("42357f43-58cc-43ce-812b-c991ae9972d1"));
            labelDoseAmount = (ITTLabel)AddControl(new Guid("360c59e0-9646-42ab-87c4-e51724187756"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("bc337662-6bc5-4d79-a639-eff2eee51452"));
            labelType = (ITTLabel)AddControl(new Guid("f10bb960-66cf-4519-b3af-b82f4b38e8b7"));
            base.InitializeControls();
        }

        public DrugOrderForm() : base("DRUGORDER", "DrugOrderForm")
        {
        }

        protected DrugOrderForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}