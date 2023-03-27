
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
    /// Majistral İlaç Tanımı
    /// </summary>
    public partial class MagistralPreparationDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Majistral İlaç Tanımı
    /// </summary>
        protected TTObjectClasses.MagistralPreparationDefinition _MagistralPreparationDefinition
        {
            get { return (TTObjectClasses.MagistralPreparationDefinition)_ttObject; }
        }

        protected ITTLabel labelMkysMalzemeKodu;
        protected ITTTextBox MkysMalzemeKodu;
        protected ITTCheckBox Pharmacology;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGroupBox ttgroupbox1;
        protected ITTGrid DrugActiveIngredients;
        protected ITTListBoxColumn ActiveIngredient;
        protected ITTListBoxColumn Unit;
        protected ITTTextBoxColumn Value;
        protected ITTGroupBox ttgroupbox2;
        protected ITTLabel labelVolume;
        protected ITTTextBox Volume;
        protected ITTTextBox MaxDose;
        protected ITTLabel labelPrescriptionType;
        protected ITTTextBox MaxDoseDay;
        protected ITTLabel labelRoutineDose;
        protected ITTTextBox RoutineDay;
        protected ITTLabel labelMaxDoseDay;
        protected ITTEnumComboBox PrescriptionType;
        protected ITTTextBox RoutineDose;
        protected ITTLabel labelRoutineDay;
        protected ITTLabel labelMaxDose;
        protected ITTTabPage tttabpage2;
        protected ITTTabControl tttabcontrol2;
        protected ITTTabPage tttabpage3;
        protected ITTGrid MagistralDefUsedDrugs;
        protected ITTListBoxColumn Drug;
        protected ITTTextBoxColumn UnitAmount;
        protected ITTTabPage tttabpage4;
        protected ITTGrid MagistralDefUsedChemicals;
        protected ITTListBoxColumn MagistralChemicalDefinition;
        protected ITTTextBoxColumn ChemUnitAmount;
        protected ITTTabPage tttabpage5;
        protected ITTGrid MagistralDefUsedConsMats;
        protected ITTListBoxColumn ConsumableMaterialMagistralDefUsedConsMat;
        protected ITTTextBoxColumn UnitAmountMagistralDefUsedConsMat;
        protected ITTListDefComboBox MagistralPreparationType;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel4;
        protected ITTListDefComboBox MagistralPackagingSubType;
        protected ITTLabel ttlabel2;
        protected ITTListDefComboBox MagistralPreparationSubType;
        protected ITTLabel ttlabel1;
        protected ITTListDefComboBox MagistralPackagingType;
        protected ITTTextBox Code;
        protected ITTTextBox EnglishName;
        protected ITTTextBox Name;
        protected ITTTextBox Description;
        protected ITTLabel Sınıfı;
        protected ITTLabel labelCode;
        protected ITTLabel labelEnglishName;
        protected ITTCheckBox IsActive;
        protected ITTObjectListBox MaterialTree;
        protected ITTLabel labelName;
        protected ITTLabel labelStockCard;
        protected ITTLabel labelDescription;
        protected ITTObjectListBox StockCard;
        protected ITTCheckBox Chargable;
        override protected void InitializeControls()
        {
            labelMkysMalzemeKodu = (ITTLabel)AddControl(new Guid("20c13bc1-3b50-48f3-8c4d-12266dabdd0b"));
            MkysMalzemeKodu = (ITTTextBox)AddControl(new Guid("0f40d8ed-958f-49b6-8eeb-e4b7da8b9060"));
            Pharmacology = (ITTCheckBox)AddControl(new Guid("4228094e-6c89-422d-bf88-1c49af957339"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("dee3935d-d3ec-487d-b3b8-dfc9e78bf444"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("dd059580-8165-4f08-8eac-ad2db2209eab"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("206998a4-913f-44d6-8526-8c807739e6bd"));
            DrugActiveIngredients = (ITTGrid)AddControl(new Guid("618ee1da-24a9-4b44-80d0-bce4e5a0c382"));
            ActiveIngredient = (ITTListBoxColumn)AddControl(new Guid("c6909a2e-4212-4b45-9b89-56515dbc44ba"));
            Unit = (ITTListBoxColumn)AddControl(new Guid("8a4f382f-ef1e-40fc-b26e-31b9b009c2f7"));
            Value = (ITTTextBoxColumn)AddControl(new Guid("c4a07173-948d-4b62-afbf-9877e158af76"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("3098f3d6-a010-47e1-96c2-0b6ab0cb45b6"));
            labelVolume = (ITTLabel)AddControl(new Guid("9a7d274f-7885-48c1-9c30-a06c8ee13c04"));
            Volume = (ITTTextBox)AddControl(new Guid("6dbe379c-30df-458e-93de-30ae8e76495d"));
            MaxDose = (ITTTextBox)AddControl(new Guid("76ff19d0-9a84-45fb-9214-b4263b614cea"));
            labelPrescriptionType = (ITTLabel)AddControl(new Guid("918b828e-ead0-4663-9957-229e63a5c826"));
            MaxDoseDay = (ITTTextBox)AddControl(new Guid("e723d64a-4e7b-43d9-beeb-74b634e1096b"));
            labelRoutineDose = (ITTLabel)AddControl(new Guid("86639cfd-11f5-49af-92c3-9c6a1818dee9"));
            RoutineDay = (ITTTextBox)AddControl(new Guid("12d92b23-fe58-46ee-acb4-c848c5c9a044"));
            labelMaxDoseDay = (ITTLabel)AddControl(new Guid("a6fba7bb-863e-4c88-a2d5-af917a253e83"));
            PrescriptionType = (ITTEnumComboBox)AddControl(new Guid("cc5a168c-895d-4da3-9cee-069353394642"));
            RoutineDose = (ITTTextBox)AddControl(new Guid("db5faaaa-50e2-4fbf-91fb-75b9a0c8e5f3"));
            labelRoutineDay = (ITTLabel)AddControl(new Guid("5c4580ac-097c-4c10-bcaf-5789860ff45c"));
            labelMaxDose = (ITTLabel)AddControl(new Guid("b9ca70d2-4bf6-4e62-a59a-6adf082c8a3b"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("3b31a4f7-fee7-4529-8239-92754398559c"));
            tttabcontrol2 = (ITTTabControl)AddControl(new Guid("632a512d-a1c6-4c73-b060-2794167d2397"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("8166c4b7-fec4-4949-9ef1-3652f47a0e52"));
            MagistralDefUsedDrugs = (ITTGrid)AddControl(new Guid("1ec7b720-38c7-4693-82d9-ef202e77ade4"));
            Drug = (ITTListBoxColumn)AddControl(new Guid("1fecba60-c652-4fea-a381-c808ca313e23"));
            UnitAmount = (ITTTextBoxColumn)AddControl(new Guid("4a87aa87-7ed5-4a74-ab15-8124372c0ca8"));
            tttabpage4 = (ITTTabPage)AddControl(new Guid("d0601fc7-c8e9-4133-b9b5-f2745a91666a"));
            MagistralDefUsedChemicals = (ITTGrid)AddControl(new Guid("8c6c7894-c77f-4b14-ac6a-a58dfc9d7677"));
            MagistralChemicalDefinition = (ITTListBoxColumn)AddControl(new Guid("d3522ea4-21fe-4708-9f83-53593f257905"));
            ChemUnitAmount = (ITTTextBoxColumn)AddControl(new Guid("23fc1520-254a-46fc-9e9a-9434812210d9"));
            tttabpage5 = (ITTTabPage)AddControl(new Guid("8e02434a-6b03-46dc-a752-250c6538fe53"));
            MagistralDefUsedConsMats = (ITTGrid)AddControl(new Guid("dffd9e94-b356-47b4-873e-6df5f4501e32"));
            ConsumableMaterialMagistralDefUsedConsMat = (ITTListBoxColumn)AddControl(new Guid("7540173e-af7e-4bf4-997e-3d72076973be"));
            UnitAmountMagistralDefUsedConsMat = (ITTTextBoxColumn)AddControl(new Guid("828b6450-ce21-4ffe-9380-ab57efb69f27"));
            MagistralPreparationType = (ITTListDefComboBox)AddControl(new Guid("9fb3b67f-c34d-46cf-84ea-3725a105cf5f"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("42645c52-50dd-4c63-84cd-9ee571525aa3"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("ce5b799c-29d8-4342-8979-0cc92772cc85"));
            MagistralPackagingSubType = (ITTListDefComboBox)AddControl(new Guid("0aa869d0-807b-427e-bbbb-5c286bb60163"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("ce9dcdfa-0d21-47dc-a365-214e614f3874"));
            MagistralPreparationSubType = (ITTListDefComboBox)AddControl(new Guid("c37ad61f-a5cb-459b-8216-a115502b7da8"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("bd6bb1c4-529d-4dac-9db0-849795eddce9"));
            MagistralPackagingType = (ITTListDefComboBox)AddControl(new Guid("dc455951-9ab2-44d2-868c-1e1f4a8fbd6a"));
            Code = (ITTTextBox)AddControl(new Guid("f6ac79d0-a34e-4b84-a376-33be315f5098"));
            EnglishName = (ITTTextBox)AddControl(new Guid("82bd96e4-f9d2-4f79-ba80-68535cd426a7"));
            Name = (ITTTextBox)AddControl(new Guid("98fe4592-db91-489b-9300-8529d722d794"));
            Description = (ITTTextBox)AddControl(new Guid("ae23cdf3-637b-4be2-b392-d35c4f80b998"));
            Sınıfı = (ITTLabel)AddControl(new Guid("eb42dbf1-aef5-4134-a10c-034d82116b97"));
            labelCode = (ITTLabel)AddControl(new Guid("834fcf6d-1188-4f7a-89dd-07445ca06b78"));
            labelEnglishName = (ITTLabel)AddControl(new Guid("4675aa72-c0f5-4301-88b0-08688527c3c5"));
            IsActive = (ITTCheckBox)AddControl(new Guid("93635ec0-e93b-4df1-a18b-362a7bdd8501"));
            MaterialTree = (ITTObjectListBox)AddControl(new Guid("46d08d86-2e3d-46ca-905f-41ef986b2675"));
            labelName = (ITTLabel)AddControl(new Guid("7b4fae59-513c-4bec-9267-84048bb3fdeb"));
            labelStockCard = (ITTLabel)AddControl(new Guid("d40b4ac9-4ec1-49f0-b8e3-ad570b7ae6e5"));
            labelDescription = (ITTLabel)AddControl(new Guid("2fc2d700-a624-4d00-9581-e9ca583e7327"));
            StockCard = (ITTObjectListBox)AddControl(new Guid("e30fc65b-6456-493e-91da-fc6315c0e46a"));
            Chargable = (ITTCheckBox)AddControl(new Guid("b74bda21-c2f3-41f2-895c-76029839e782"));
            base.InitializeControls();
        }

        public MagistralPreparationDefinitionForm() : base("MAGISTRALPREPARATIONDEFINITION", "MagistralPreparationDefinitionForm")
        {
        }

        protected MagistralPreparationDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}