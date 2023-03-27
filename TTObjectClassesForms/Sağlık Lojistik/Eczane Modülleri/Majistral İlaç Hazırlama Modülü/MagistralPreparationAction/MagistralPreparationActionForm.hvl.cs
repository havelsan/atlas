
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
    /// Majistral İlaç Hazırlama
    /// </summary>
    public partial class MagistralPreparationActionForm : TTForm
    {
    /// <summary>
    /// Majistral İlaç Hazırlama
    /// </summary>
        protected TTObjectClasses.MagistralPreparationAction _MagistralPreparationAction
        {
            get { return (TTObjectClasses.MagistralPreparationAction)_ttObject; }
        }

        protected ITTButton cmdCalculateAmount;
        protected ITTLabel labelMagistralAmount;
        protected ITTTextBox MagistralAmount;
        protected ITTTextBox MagistralVolume;
        protected ITTTextBox MagistralPrice;
        protected ITTLabel ttlabel5;
        protected ITTCheckBox Sterilization;
        protected ITTTabControl tttabcontrol2;
        protected ITTTabPage tttabpage3;
        protected ITTGrid MagistralPreparationUsedDrugs;
        protected ITTListBoxColumn UsedDrug;
        protected ITTTextBoxColumn DrugAmount;
        protected ITTListBoxColumn DistributionType;
        protected ITTTabPage tttabpage4;
        protected ITTGrid MagistralPreparationUsedChemicals;
        protected ITTListBoxColumn UsedChemical;
        protected ITTTextBoxColumn ChemicalAmount;
        protected ITTListBoxColumn ChemicalDistributionType;
        protected ITTTabPage tttabpage6;
        protected ITTGrid MagistralPreparationUsedMaterials;
        protected ITTListBoxColumn ConsumableMaterial;
        protected ITTTextBoxColumn MaterialAmount;
        protected ITTListBoxColumn ConsumableMaterialDistType;
        protected ITTTabPage tttabpage5;
        protected ITTTextBox Description;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGrid MagistralPreparationDetails;
        protected ITTListBoxColumn MagistralPreparationDef;
        protected ITTTextBoxColumn Amount;
        protected ITTDateTimePickerColumn ExpairDate;
        protected ITTTabPage tttabpage2;
        protected ITTGrid StockActionDetails;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn UsedMaterialAmount;
        protected ITTListBoxColumn UsedDistributionType;
        protected ITTTextBox StockActionID;
        protected ITTTextBox ProducedAmount;
        protected ITTLabel labelStore;
        protected ITTObjectListBox DestinationStore;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelStockActionID;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTListDefComboBox MagistralPackagingType;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel4;
        protected ITTListDefComboBox MagistralPackagingSubType;
        protected ITTCheckBox NightShift;
        protected ITTLabel labelVolume;
        protected ITTLabel labelProducedAmount;
        protected ITTLabel labelVolumeGram;
        protected ITTListDefComboBox MagistralPreparationSubType;
        protected ITTListDefComboBox MagistralPreparationType;
        override protected void InitializeControls()
        {
            cmdCalculateAmount = (ITTButton)AddControl(new Guid("d59d3532-0cf6-4f8f-8c01-3413b187b64c"));
            labelMagistralAmount = (ITTLabel)AddControl(new Guid("7ef3a3f9-2b8f-4897-b01b-12af6891f71a"));
            MagistralAmount = (ITTTextBox)AddControl(new Guid("f4a5d5c5-637d-41c0-8448-fda27ee3b0c0"));
            MagistralVolume = (ITTTextBox)AddControl(new Guid("b712cec8-0b68-4d05-a6ed-adf67fac08e0"));
            MagistralPrice = (ITTTextBox)AddControl(new Guid("59db47b9-0ce9-4942-b0cb-f513a3dd8237"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("0f291bcf-118c-491b-a94d-63805bc8c0b3"));
            Sterilization = (ITTCheckBox)AddControl(new Guid("e1cfea7e-57a7-46b9-8abc-e93f09ea05d4"));
            tttabcontrol2 = (ITTTabControl)AddControl(new Guid("09d25078-4094-49e3-880b-e886e5ef5473"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("259bcc3e-fd44-4565-bcb6-0172c881c9eb"));
            MagistralPreparationUsedDrugs = (ITTGrid)AddControl(new Guid("92f55a53-a9ae-47c6-a536-edfffaa4f7ea"));
            UsedDrug = (ITTListBoxColumn)AddControl(new Guid("84649e6c-dd4d-4592-8a07-1e033e39bdd2"));
            DrugAmount = (ITTTextBoxColumn)AddControl(new Guid("b7630d5f-883d-47f5-81fb-7abaead1c31b"));
            DistributionType = (ITTListBoxColumn)AddControl(new Guid("829fbf5a-dd65-4bd0-a9a0-9442913e3899"));
            tttabpage4 = (ITTTabPage)AddControl(new Guid("72c57925-1777-43ac-be7d-5f38d89f9248"));
            MagistralPreparationUsedChemicals = (ITTGrid)AddControl(new Guid("2203efdd-7af9-4e2d-8115-0957a61e6914"));
            UsedChemical = (ITTListBoxColumn)AddControl(new Guid("f0aa40d5-a1ef-4176-8789-a4472566cc32"));
            ChemicalAmount = (ITTTextBoxColumn)AddControl(new Guid("5f87b803-9636-42d8-a6ec-1658f0f670d0"));
            ChemicalDistributionType = (ITTListBoxColumn)AddControl(new Guid("00c4f2de-128d-4544-98ca-2349db8f4ec1"));
            tttabpage6 = (ITTTabPage)AddControl(new Guid("b8b3825b-c698-4a51-b507-216a9e8bab0c"));
            MagistralPreparationUsedMaterials = (ITTGrid)AddControl(new Guid("f3cd08cf-7968-4526-8bd1-5a347e14b78e"));
            ConsumableMaterial = (ITTListBoxColumn)AddControl(new Guid("c14d36a7-a163-46c9-a458-c653fe12f13c"));
            MaterialAmount = (ITTTextBoxColumn)AddControl(new Guid("75e18a48-bd45-4406-a284-fdb112ef12ea"));
            ConsumableMaterialDistType = (ITTListBoxColumn)AddControl(new Guid("7733d692-97ae-459a-819c-629e602cb88a"));
            tttabpage5 = (ITTTabPage)AddControl(new Guid("55deaf36-39d4-42ea-a572-383758dcdc63"));
            Description = (ITTTextBox)AddControl(new Guid("f051d699-ce03-47ad-b4eb-e7c5066318c8"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("92b93f0c-5132-49d1-a064-c0606b90414d"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("86378c4d-2e2f-4d9a-bb22-ccbbd47ddb3c"));
            MagistralPreparationDetails = (ITTGrid)AddControl(new Guid("5de47e63-6ee2-411c-addf-06ac55fff2e5"));
            MagistralPreparationDef = (ITTListBoxColumn)AddControl(new Guid("273a41e5-2742-49cb-af3f-034781efebe7"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("06426cb3-6abb-4ff2-b9bb-e025760853df"));
            ExpairDate = (ITTDateTimePickerColumn)AddControl(new Guid("43dc8431-84ae-4523-b12c-17c07718e3f4"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("ed4b2221-e003-40b5-9df1-a19d5650e1dc"));
            StockActionDetails = (ITTGrid)AddControl(new Guid("bf0de681-b41f-4cc0-91f7-40ed428affad"));
            Material = (ITTListBoxColumn)AddControl(new Guid("e11b2ec8-2605-4b05-a161-89ac6a6c187e"));
            UsedMaterialAmount = (ITTTextBoxColumn)AddControl(new Guid("fd0a6492-45e7-4117-a6af-15848e5363de"));
            UsedDistributionType = (ITTListBoxColumn)AddControl(new Guid("a44cf2a8-9e81-46cd-a1c2-b6ac21c9d99b"));
            StockActionID = (ITTTextBox)AddControl(new Guid("01d9dbca-0b50-4158-95aa-da17a696ce3c"));
            ProducedAmount = (ITTTextBox)AddControl(new Guid("395ea319-dd7e-4ad4-abdf-01bc48ab95f2"));
            labelStore = (ITTLabel)AddControl(new Guid("daf6649c-f650-439d-957e-8170ee775c00"));
            DestinationStore = (ITTObjectListBox)AddControl(new Guid("ef5807a7-e522-491a-b7f7-fd26e4e0f82f"));
            labelActionDate = (ITTLabel)AddControl(new Guid("27808769-2039-4d5a-8bd0-7464813c720a"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("04248c80-faee-49b3-a981-20db6fb485a0"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("f73651f3-2170-4479-8252-51d58037cfa9"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("59462519-fe67-4abc-b951-a30c9d6a188e"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("c331be78-8ec1-4b53-8eca-95c3ccddcb42"));
            MagistralPackagingType = (ITTListDefComboBox)AddControl(new Guid("69686df5-543f-49fd-af60-0f783a5ab5fc"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("8149f46d-d0ac-4b1c-92db-10089073496e"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("f52e161a-42c5-474e-b620-f6c64b0785db"));
            MagistralPackagingSubType = (ITTListDefComboBox)AddControl(new Guid("d686d612-54e5-4da6-9a71-e613d3a9fdf3"));
            NightShift = (ITTCheckBox)AddControl(new Guid("98d26d61-0dcb-41ce-b60c-de34cdb0ad42"));
            labelVolume = (ITTLabel)AddControl(new Guid("70563208-2f13-4080-ba7a-1d3d8d938dd3"));
            labelProducedAmount = (ITTLabel)AddControl(new Guid("c5939d7a-caa5-4239-aa33-a7b154423d5c"));
            labelVolumeGram = (ITTLabel)AddControl(new Guid("b8869be3-f4a2-47f5-8072-e5b4168391a1"));
            MagistralPreparationSubType = (ITTListDefComboBox)AddControl(new Guid("52aef8d2-5670-4f96-b5e0-82acf096db67"));
            MagistralPreparationType = (ITTListDefComboBox)AddControl(new Guid("0b655996-5955-4f33-ab13-566b3176f9ff"));
            base.InitializeControls();
        }

        public MagistralPreparationActionForm() : base("MAGISTRALPREPARATIONACTION", "MagistralPreparationActionForm")
        {
        }

        protected MagistralPreparationActionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}