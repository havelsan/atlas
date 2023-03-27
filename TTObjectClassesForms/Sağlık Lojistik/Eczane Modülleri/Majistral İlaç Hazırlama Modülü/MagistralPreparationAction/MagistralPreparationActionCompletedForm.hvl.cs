
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
    public partial class MagistralPreparationActionCompletedForm : TTForm
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
            cmdCalculateAmount = (ITTButton)AddControl(new Guid("f68bf935-baa0-4b92-84eb-164fb6a54389"));
            labelMagistralAmount = (ITTLabel)AddControl(new Guid("1c9f71bf-66fc-4ca9-9627-09a3cf1f2c13"));
            MagistralAmount = (ITTTextBox)AddControl(new Guid("8243504e-ba46-4eef-98d4-5a7b100aaa2c"));
            MagistralVolume = (ITTTextBox)AddControl(new Guid("92d7240f-d9bf-4d51-bd7e-00ecfdd50984"));
            MagistralPrice = (ITTTextBox)AddControl(new Guid("bd07a8dd-2110-4630-9c25-f0690f1efa95"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("3d76f912-ffba-4e0e-8c4d-f4c10143e84e"));
            Sterilization = (ITTCheckBox)AddControl(new Guid("d75dea93-7c1a-4d39-a182-61d22dbdb8af"));
            tttabcontrol2 = (ITTTabControl)AddControl(new Guid("c87512fd-30dc-4b52-8d0e-d8835ef96e26"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("631a4a0e-3beb-4267-a4d6-6e44187b05cf"));
            MagistralPreparationUsedDrugs = (ITTGrid)AddControl(new Guid("ec6cb70c-d887-44c2-b6ec-76e701b53bee"));
            UsedDrug = (ITTListBoxColumn)AddControl(new Guid("f2214f19-f2f5-4793-9b6c-f916434a47a0"));
            DrugAmount = (ITTTextBoxColumn)AddControl(new Guid("887db8e0-5181-4ab2-b9c5-86d247655ccc"));
            DistributionType = (ITTListBoxColumn)AddControl(new Guid("2c2e2d90-a067-4bfc-a1bb-c02595bddd22"));
            tttabpage4 = (ITTTabPage)AddControl(new Guid("ce0dbab6-398f-451e-ae9e-00d61cca8c11"));
            MagistralPreparationUsedChemicals = (ITTGrid)AddControl(new Guid("1df1e768-7648-4a11-b535-827996128bba"));
            UsedChemical = (ITTListBoxColumn)AddControl(new Guid("63b0d522-9fed-440a-b3b2-d2bb826ff41f"));
            ChemicalAmount = (ITTTextBoxColumn)AddControl(new Guid("e3be3e74-2a85-4095-8719-fdb2a9c4b5c0"));
            ChemicalDistributionType = (ITTListBoxColumn)AddControl(new Guid("7a85d5ed-216a-4cd6-b4c4-05a2989fae2a"));
            tttabpage6 = (ITTTabPage)AddControl(new Guid("2477ca97-cf87-4202-96e1-b38a846ce9a4"));
            MagistralPreparationUsedMaterials = (ITTGrid)AddControl(new Guid("1ad08421-7f3e-464a-9e94-1417f849a34d"));
            ConsumableMaterial = (ITTListBoxColumn)AddControl(new Guid("27e652ed-74f9-4c09-8403-b1874bc6e1ef"));
            MaterialAmount = (ITTTextBoxColumn)AddControl(new Guid("85dbf120-d61f-4455-a0c8-1d4569bafe88"));
            ConsumableMaterialDistType = (ITTListBoxColumn)AddControl(new Guid("554479a0-d991-4e62-a665-e4192cef41f0"));
            tttabpage5 = (ITTTabPage)AddControl(new Guid("294e1a30-140d-41f5-96f4-0bcb55fd5b8f"));
            Description = (ITTTextBox)AddControl(new Guid("02d999db-219e-4255-ab89-62924a635777"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("8f98387b-8b25-4069-8767-8db5761ee370"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("90717e82-111a-422b-8e62-decb68f0fef4"));
            MagistralPreparationDetails = (ITTGrid)AddControl(new Guid("667826da-c83a-4ce7-8968-c474db1eaf59"));
            MagistralPreparationDef = (ITTListBoxColumn)AddControl(new Guid("dcc464c5-fec8-46f8-b933-0d7e57be8603"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("6dfed718-2702-4ddb-ac95-dc4d42f7bdcd"));
            ExpairDate = (ITTDateTimePickerColumn)AddControl(new Guid("5c773a0d-8919-4adb-af3e-a52d14371f98"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("4f5e3a69-6fdf-4515-85db-2eb4bc8a7e5b"));
            StockActionDetails = (ITTGrid)AddControl(new Guid("e43149a1-2219-41e6-8f5d-35c84b6253c2"));
            Material = (ITTListBoxColumn)AddControl(new Guid("5b52427f-fd0c-4191-8d91-d26ed15aff08"));
            UsedMaterialAmount = (ITTTextBoxColumn)AddControl(new Guid("ac366556-6719-44b9-a849-52fb9b8ac385"));
            UsedDistributionType = (ITTListBoxColumn)AddControl(new Guid("e66da28f-db0e-4b24-9cdd-a69fef911fd0"));
            StockActionID = (ITTTextBox)AddControl(new Guid("259b1e88-618f-4c69-af8f-577e09f6bf9d"));
            ProducedAmount = (ITTTextBox)AddControl(new Guid("47ad6068-b8c2-4524-96af-b61212096feb"));
            labelStore = (ITTLabel)AddControl(new Guid("16aea634-d3b5-42b2-8bb0-6245ce8f393e"));
            DestinationStore = (ITTObjectListBox)AddControl(new Guid("50c03d1f-4b32-40d5-976a-e18e320140d1"));
            labelActionDate = (ITTLabel)AddControl(new Guid("6e95bc72-d3dd-4659-9261-7d01c6e7e89f"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("0708629d-2a99-4760-8429-4ec8e12cd24d"));
            labelStockActionID = (ITTLabel)AddControl(new Guid("e55e4bb8-2ead-43d6-ac67-d343a8b6a594"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("aa875677-c664-42a3-b664-5767bcb557cc"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("3966949c-e592-4162-a374-d4e0787cd806"));
            MagistralPackagingType = (ITTListDefComboBox)AddControl(new Guid("4a4ce558-7518-4c34-ac0d-868c7184c9ae"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("d4a1bba1-31ec-4567-be6e-88ebecb77f34"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("158a0f29-a172-40cf-ac89-d1df2bb095d3"));
            MagistralPackagingSubType = (ITTListDefComboBox)AddControl(new Guid("7baf6b94-baca-4a87-b943-50619cea9bcc"));
            NightShift = (ITTCheckBox)AddControl(new Guid("bc7cdf7a-076c-433e-8ec7-d7adae05d9ad"));
            labelVolume = (ITTLabel)AddControl(new Guid("4759589b-4cf8-4bfb-9321-8f1cc255436a"));
            labelProducedAmount = (ITTLabel)AddControl(new Guid("5172e9b8-5ddb-4354-84eb-670bbf8c000f"));
            labelVolumeGram = (ITTLabel)AddControl(new Guid("1732c796-49a4-4a86-9746-aa7e6d65b8f1"));
            MagistralPreparationSubType = (ITTListDefComboBox)AddControl(new Guid("6c354e86-bb63-494c-a1cd-9b699bf404b2"));
            MagistralPreparationType = (ITTListDefComboBox)AddControl(new Guid("96038a16-243a-4478-aa0b-63f66fc4dc8e"));
            base.InitializeControls();
        }

        public MagistralPreparationActionCompletedForm() : base("MAGISTRALPREPARATIONACTION", "MagistralPreparationActionCompletedForm")
        {
        }

        protected MagistralPreparationActionCompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}