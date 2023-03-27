
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
    /// Ana Malzeme Detayı
    /// </summary>
    public partial class FixedAssetDetailActionDetForm : TTForm
    {
        protected TTObjectClasses.FixedAssetDetailActionDet _FixedAssetDetailActionDet
        {
            get { return (TTObjectClasses.FixedAssetDetailActionDet)_ttObject; }
        }

        protected ITTTextBox materialNameTextBox;
        protected ITTTextBox barcodeTextBox;
        protected ITTTextBox stockCardTextBox;
        protected ITTGroupBox Stage2;
        protected ITTMaskedTextBox ProposedNATOStockNoFixedAssetMaterialDefinitionDetail;
        protected ITTTextBox ProposedNATOStockNoFixedAssetMaterialDefinitionDetail1;
        protected ITTEnumComboBox CalibrationPeriodFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelCalibrationPeriodFixedAssetMaterialDefinitionDetail;
        protected ITTEnumComboBox CalibrationStatusFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelCalibrationStatusFixedAssetMaterialDefinitionDetail;
        protected ITTTextBox FrequencyFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelFrequencyFixedAssetMaterialDefinitionDetail;
        protected ITTTextBox GuarantiePeriodFixedAssetMaterialDefinitionDetail;
        protected ITTDateTimePicker GuarantyEndDate;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelUseStartDateFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelVoltageFixedAssetMaterialDefinitionDetail;
        protected ITTDateTimePicker UseStartDateFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelGuarantiePeriodFixedAssetMaterialDefinitionDetail;
        protected ITTTextBox VoltageFixedAssetMaterialDefinitionDetail;
        protected ITTDateTimePicker GuarantyStartDateFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelGuarantyStartDateFixedAssetMaterialDefinitionDetail;
        protected ITTEnumComboBox GuarantyStatusFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelProposedStockcardNameFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelGuarantyStatusFixedAssetMaterialDefinitionDetail;
        protected ITTTextBox ProposedStockcardNameFixedAssetMaterialDefinitionDetail;
        protected ITTTextBox IntendedUseFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelProposedNATOStockNoFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelIntendedUseFixedAssetMaterialDefinitionDetail;
        protected ITTEnumComboBox IsAdvancedTechnologyFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelPowerFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelIsAdvancedTechnologyFixedAssetMaterialDefinitionDetail;
        protected ITTTextBox PowerFixedAssetMaterialDefinitionDetail;
        protected ITTDateTimePicker LastCalibrationDateFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelMaintenancePeriodFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelLastCalibrationDateFixedAssetMaterialDefinitionDetail;
        protected ITTEnumComboBox MaintenancePeriodFixedAssetMaterialDefinitionDetail;
        protected ITTDateTimePicker LastMaintenanceDateFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelMaintanenceStatusFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelLastMaintenanceDateFixedAssetMaterialDefinitionDetail;
        protected ITTEnumComboBox MaintanenceStatusFixedAssetMaterialDefinitionDetail;
        protected ITTTextBox LifePeriodFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelLifePeriodFixedAssetMaterialDefinitionDetail;
        protected ITTGrid SetMaterialDetailsSetMaterialDetailDef;
        protected ITTListBoxColumn FixedAssetDetailMainClassSetMaterialDetailDef;
        protected ITTGroupBox Stage1;
        protected ITTCheckBox OtherMainClass;
        protected ITTCheckBox OtherLenght;
        protected ITTButton cmdFind;
        protected ITTCheckBox OtherEdge;
        protected ITTCheckBox OtherBody;
        protected ITTObjectListBox LengthFixedAssetMaterialDefinitionDetail;
        protected ITTCheckBox OtherModel;
        protected ITTEnumComboBox OperationStatusFixedAssetMaterialDefinitionDetail;
        protected ITTCheckBox OtherMark;
        protected ITTTextBox PhysicalBarcodeFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelSetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail;
        protected ITTDateTimePicker AccountancyEntryDateFixedAssetMaterialDefinitionDetail;
        protected ITTObjectListBox SetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelAccountancyEntryDateFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelFixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail;
        protected ITTTextBox DescriptionFixedAssetMaterialDefinitionDetail;
        protected ITTObjectListBox FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelDescriptionFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelFixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail;
        protected ITTEnumComboBox DetailClassFixedAssetMaterialDefinitionDetail;
        protected ITTObjectListBox FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelDetailClassFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelFixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail;
        protected ITTEnumComboBox DetailTypeFixedAssetMaterialDefinitionDetail;
        protected ITTObjectListBox FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelDetailTypeFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelFixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail;
        protected ITTEnumComboBox IsDemodedFixedAssetMaterialDefinitionDetail;
        protected ITTObjectListBox FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelIsDemodedFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelFixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail;
        protected ITTEnumComboBox IsFixedAssetFixedAssetMaterialDefinitionDetail;
        protected ITTObjectListBox FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelIsFixedAssetFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelSerialNumberFixedAssetMaterialDefinitionDetail;
        protected ITTEnumComboBox IsSetSystemUnitFixedAssetMaterialDefinitionDetail;
        protected ITTTextBox SerialNumberFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelIsSetSystemUnitFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelReferansNoFixedAssetMaterialDefinitionDetail;
        protected ITTTextBox ReferansNoFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelLengthFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelProductionDateFixedAssetMaterialDefinitionDetail;
        protected ITTTextBox MarkModelReasonFixedAssetMaterialDefinitionDetail;
        protected ITTDateTimePicker ProductionDateFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelMarkModelReasonFixedAssetMaterialDefinitionDetail;
        protected ITTEnumComboBox MarkModelStatusFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelPhysicalBarcodeFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelMarkModelStatusFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelOperationStatusFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelStockCardFixedAssetMaterialDefinition;
        protected ITTLabel labelNameMaterial;
        protected ITTLabel labelBarcodeMaterial;
        protected ITTPictureBoxControl PictureFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelPictureFixedAssetMaterialDefinitionDetail;
        override protected void InitializeControls()
        {
            materialNameTextBox = (ITTTextBox)AddControl(new Guid("a3a275bf-73e6-4f1f-a341-aaca897261d4"));
            barcodeTextBox = (ITTTextBox)AddControl(new Guid("c73106d2-e6ba-49d7-98fa-fde622b5c208"));
            stockCardTextBox = (ITTTextBox)AddControl(new Guid("4e1529a7-1568-4a63-a7cf-ab61fad26cc6"));
            Stage2 = (ITTGroupBox)AddControl(new Guid("0ba5c87e-817d-4526-a7db-df4a9cd42040"));
            ProposedNATOStockNoFixedAssetMaterialDefinitionDetail = (ITTMaskedTextBox)AddControl(new Guid("7de8e000-b310-4948-a5eb-dc0538c6766a"));
            ProposedNATOStockNoFixedAssetMaterialDefinitionDetail1 = (ITTTextBox)AddControl(new Guid("ee2d3deb-859b-474a-8fbe-49d28de90fbe"));
            CalibrationPeriodFixedAssetMaterialDefinitionDetail = (ITTEnumComboBox)AddControl(new Guid("515d91ab-ab4c-42ff-846c-7bfc4eca3bef"));
            labelCalibrationPeriodFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("b92ace07-74e5-4891-b101-27091cf87d17"));
            CalibrationStatusFixedAssetMaterialDefinitionDetail = (ITTEnumComboBox)AddControl(new Guid("c212eb3a-40fe-44ef-aa87-ee7457878674"));
            labelCalibrationStatusFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("582cec6a-70e5-4837-b243-4bb588afc58e"));
            FrequencyFixedAssetMaterialDefinitionDetail = (ITTTextBox)AddControl(new Guid("c4461fc7-b091-42dd-bf24-ea96ac0d38a4"));
            labelFrequencyFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("006a1b8b-a724-4e9e-8a9e-3a67b82fb523"));
            GuarantiePeriodFixedAssetMaterialDefinitionDetail = (ITTTextBox)AddControl(new Guid("e3a581ad-b910-4be2-a797-fa9083974c07"));
            GuarantyEndDate = (ITTDateTimePicker)AddControl(new Guid("2d9a3156-d577-4f88-9b3f-f30fb4da7184"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("e2bd308a-b539-42db-8b6f-3ac3a00a9b72"));
            labelUseStartDateFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("c74a0caa-7c30-430b-afc3-42d809b52a93"));
            labelVoltageFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("90733c37-e3fd-4620-a488-4d019422b37c"));
            UseStartDateFixedAssetMaterialDefinitionDetail = (ITTDateTimePicker)AddControl(new Guid("04cd62c6-8f07-407b-ba54-e6b131a7a907"));
            labelGuarantiePeriodFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("ae69f754-4853-4aa8-b38f-320778763636"));
            VoltageFixedAssetMaterialDefinitionDetail = (ITTTextBox)AddControl(new Guid("7f895eba-50e8-47fe-b542-bd485246988b"));
            GuarantyStartDateFixedAssetMaterialDefinitionDetail = (ITTDateTimePicker)AddControl(new Guid("45980def-fff3-4d2f-9578-8c4cbfac08b9"));
            labelGuarantyStartDateFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("a54109da-415e-4237-8397-89c48cf206c9"));
            GuarantyStatusFixedAssetMaterialDefinitionDetail = (ITTEnumComboBox)AddControl(new Guid("4907eaf2-7d30-43ca-91ed-53cb50cb889a"));
            labelProposedStockcardNameFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("6448479c-8a62-4fb5-baae-7128cb9586ba"));
            labelGuarantyStatusFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("881ac0fd-a902-4202-976e-486edfb4d59d"));
            ProposedStockcardNameFixedAssetMaterialDefinitionDetail = (ITTTextBox)AddControl(new Guid("75508b5c-35ac-4fc1-88e4-e6729a0e508f"));
            IntendedUseFixedAssetMaterialDefinitionDetail = (ITTTextBox)AddControl(new Guid("8b63486b-aedf-4db6-bd02-88cbfd57d219"));
            labelProposedNATOStockNoFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("debf5ad4-1d5b-4ac8-9b23-2608abb240d1"));
            labelIntendedUseFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("ca2d7e81-e991-4634-a843-9a47bc293bcc"));
            IsAdvancedTechnologyFixedAssetMaterialDefinitionDetail = (ITTEnumComboBox)AddControl(new Guid("7e6ddd0a-9f2f-4349-9548-878c7b7a14db"));
            labelPowerFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("66130dcd-6bda-4cb0-aad1-971488d212e4"));
            labelIsAdvancedTechnologyFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("a082f941-1904-408a-8252-01f1de9550ef"));
            PowerFixedAssetMaterialDefinitionDetail = (ITTTextBox)AddControl(new Guid("c050b0c4-3580-41c0-aca7-3069ad111da4"));
            LastCalibrationDateFixedAssetMaterialDefinitionDetail = (ITTDateTimePicker)AddControl(new Guid("ea7db533-15f2-4a77-8bfb-df4b92b4d360"));
            labelMaintenancePeriodFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("442d38b9-a18c-4e12-b0f5-be575a3aecae"));
            labelLastCalibrationDateFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("9193e13c-57cc-4eca-967c-ac4a3cde5f52"));
            MaintenancePeriodFixedAssetMaterialDefinitionDetail = (ITTEnumComboBox)AddControl(new Guid("ecf41439-757a-4d19-b7c9-96f9ac484533"));
            LastMaintenanceDateFixedAssetMaterialDefinitionDetail = (ITTDateTimePicker)AddControl(new Guid("50d76c37-0b6c-43c6-a28c-3f39ad93423f"));
            labelMaintanenceStatusFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("94ae4b55-b91d-4cfb-a57b-c96f0ba3a50d"));
            labelLastMaintenanceDateFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("5b467088-547a-491d-a9c4-a2a0186c2df2"));
            MaintanenceStatusFixedAssetMaterialDefinitionDetail = (ITTEnumComboBox)AddControl(new Guid("b2acd7b7-3520-4ee1-a8ec-fb7aab02b78d"));
            LifePeriodFixedAssetMaterialDefinitionDetail = (ITTTextBox)AddControl(new Guid("200e424d-d0ee-4aa1-83d0-9e7a771f1967"));
            labelLifePeriodFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("cd2d479e-74de-4b36-acdd-3536092c9b28"));
            SetMaterialDetailsSetMaterialDetailDef = (ITTGrid)AddControl(new Guid("0ba99b39-b408-4775-a153-9951abd71963"));
            FixedAssetDetailMainClassSetMaterialDetailDef = (ITTListBoxColumn)AddControl(new Guid("36938495-1cc6-4454-b1a9-a6325f7cf61f"));
            Stage1 = (ITTGroupBox)AddControl(new Guid("c8079e51-5358-4ad8-a7b3-15be5b064ff8"));
            OtherMainClass = (ITTCheckBox)AddControl(new Guid("b5ab57f4-3600-40d1-9a83-1db885608c84"));
            OtherLenght = (ITTCheckBox)AddControl(new Guid("91bdc5a7-bce1-4412-9a2a-a2725f99267d"));
            cmdFind = (ITTButton)AddControl(new Guid("3170bcaa-62d1-40e8-85b9-457ef75f656a"));
            OtherEdge = (ITTCheckBox)AddControl(new Guid("3036fd05-82a9-49ef-85e4-7cc4ac69f598"));
            OtherBody = (ITTCheckBox)AddControl(new Guid("37410efd-0e61-4414-9cab-80f1f43debbc"));
            LengthFixedAssetMaterialDefinitionDetail = (ITTObjectListBox)AddControl(new Guid("ebbe03b7-a516-492d-9be7-dd0b827415b2"));
            OtherModel = (ITTCheckBox)AddControl(new Guid("98fa9797-be38-4dc4-8050-213c1b81fa49"));
            OperationStatusFixedAssetMaterialDefinitionDetail = (ITTEnumComboBox)AddControl(new Guid("803d477d-0ba6-498c-b9fb-5ae0607c03eb"));
            OtherMark = (ITTCheckBox)AddControl(new Guid("5a29825b-f8c3-4385-b57e-034b4899b438"));
            PhysicalBarcodeFixedAssetMaterialDefinitionDetail = (ITTTextBox)AddControl(new Guid("8352302b-6bcc-40c7-92ce-e42cbe4bb9cb"));
            labelSetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("f0351da5-e0a9-4c9a-831b-337a30f044a6"));
            AccountancyEntryDateFixedAssetMaterialDefinitionDetail = (ITTDateTimePicker)AddControl(new Guid("1b9f454c-8c50-430a-9769-161d5c60256b"));
            SetSystemUnitDefinitionFixedAssetMaterialDefinitionDetail = (ITTObjectListBox)AddControl(new Guid("cff0fe9c-f9d7-4dc7-a789-49fd57f5b8dd"));
            labelAccountancyEntryDateFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("8f1b2ba7-ec69-41bd-a9c5-f9d8cdb185f0"));
            labelFixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("052cb524-45b5-4dba-a26e-d5427f1a2b08"));
            DescriptionFixedAssetMaterialDefinitionDetail = (ITTTextBox)AddControl(new Guid("a17e9439-e02a-4a2d-9d11-3d2ed9102222"));
            FixedAssetDetailEdgeDefFixedAssetMaterialDefinitionDetail = (ITTObjectListBox)AddControl(new Guid("932a0edb-9a7a-4e6a-a2c5-b4841aac30e4"));
            labelDescriptionFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("e76199a4-6579-46da-89d9-a60dcaec2fc8"));
            labelFixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("2452795f-5a4f-40c4-9401-6488ec739076"));
            DetailClassFixedAssetMaterialDefinitionDetail = (ITTEnumComboBox)AddControl(new Guid("0a097100-ea28-4354-baab-d94bd6a7577c"));
            FixedAssetDetailBodyDefFixedAssetMaterialDefinitionDetail = (ITTObjectListBox)AddControl(new Guid("4951e4c9-e8ba-44bc-bf82-b3d691883052"));
            labelDetailClassFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("fd7eb14d-0e30-479a-9128-2469dc897971"));
            labelFixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("83df328e-04fb-46c3-81b2-064e5a53e356"));
            DetailTypeFixedAssetMaterialDefinitionDetail = (ITTEnumComboBox)AddControl(new Guid("4ab48a7c-93e8-4f7a-b5d4-64513dd9bb9a"));
            FixedAssetDetailModelDefFixedAssetMaterialDefinitionDetail = (ITTObjectListBox)AddControl(new Guid("ff7c0b23-28f1-4f69-bd0d-33255dadfe2f"));
            labelDetailTypeFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("4017e12a-6e00-4628-83ca-34026fca9792"));
            labelFixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("0a445537-7df4-4fc4-9809-6d062f1e91be"));
            IsDemodedFixedAssetMaterialDefinitionDetail = (ITTEnumComboBox)AddControl(new Guid("8104f393-c907-45be-8cfc-5fb9f2edc90c"));
            FixedAssetDetailMarkDefFixedAssetMaterialDefinitionDetail = (ITTObjectListBox)AddControl(new Guid("9dc2fb43-e417-437f-97bb-ec16da15911d"));
            labelIsDemodedFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("6c01c7aa-5d8d-4ebc-92eb-d0abbecaf6f3"));
            labelFixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("bb4a797a-bf85-487e-bd55-af6bb2b12d5a"));
            IsFixedAssetFixedAssetMaterialDefinitionDetail = (ITTEnumComboBox)AddControl(new Guid("eccf748f-47df-4227-a993-6170f71296af"));
            FixedAssetDetailMainClassFixedAssetMaterialDefinitionDetail = (ITTObjectListBox)AddControl(new Guid("2c350f17-b175-45d2-a29d-c59dbe880a87"));
            labelIsFixedAssetFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("3d4fbd28-ef25-4d82-9480-ce77bdb4f7be"));
            labelSerialNumberFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("68332b08-d154-45a2-97a5-55ee72d1d081"));
            IsSetSystemUnitFixedAssetMaterialDefinitionDetail = (ITTEnumComboBox)AddControl(new Guid("771b4473-0a0c-418d-b2ef-307a4a90cae0"));
            SerialNumberFixedAssetMaterialDefinitionDetail = (ITTTextBox)AddControl(new Guid("b675e721-df79-4017-a6bb-36ca96178a07"));
            labelIsSetSystemUnitFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("dd070295-10f3-47ca-a23f-c8cbbb6670d0"));
            labelReferansNoFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("9fa3f7f3-da6b-4873-9f5a-69e70aa34f28"));
            ReferansNoFixedAssetMaterialDefinitionDetail = (ITTTextBox)AddControl(new Guid("5d5dbab3-99b8-4c9b-843c-71f081a6612f"));
            labelLengthFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("6711c558-d2c2-4ae2-a83a-3b58a1cbe196"));
            labelProductionDateFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("22d09d12-074d-49dc-b010-085745d21900"));
            MarkModelReasonFixedAssetMaterialDefinitionDetail = (ITTTextBox)AddControl(new Guid("b2d7a026-4d92-406d-a97f-9e94b7bf6518"));
            ProductionDateFixedAssetMaterialDefinitionDetail = (ITTDateTimePicker)AddControl(new Guid("840c639c-6d4d-4f78-976e-60c6a4d3212c"));
            labelMarkModelReasonFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("70802ea2-8dbb-4d4d-9970-6ba406216e4c"));
            MarkModelStatusFixedAssetMaterialDefinitionDetail = (ITTEnumComboBox)AddControl(new Guid("cb57e57b-bd62-431f-b0a1-f788aeaf9b79"));
            labelPhysicalBarcodeFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("d2c4592b-97af-4d6e-8b76-5ec603833b15"));
            labelMarkModelStatusFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("0968fe44-4e3d-4ead-a94b-55acb7370ee0"));
            labelOperationStatusFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("4b544dd9-a71d-4f42-8277-b2416c057db6"));
            labelStockCardFixedAssetMaterialDefinition = (ITTLabel)AddControl(new Guid("bcffc834-7d4f-4fe5-96fc-818cab834820"));
            labelNameMaterial = (ITTLabel)AddControl(new Guid("db2cf59b-73cf-48de-ad95-f51848bc4975"));
            labelBarcodeMaterial = (ITTLabel)AddControl(new Guid("8602c6ba-c0ec-42db-b94c-c4f85efb77b8"));
            PictureFixedAssetMaterialDefinitionDetail = (ITTPictureBoxControl)AddControl(new Guid("a3ae5269-4d27-4e77-9b50-2756463373e9"));
            labelPictureFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("317cf7e5-4db0-412c-a5b6-ecc0a6c51b4c"));
            base.InitializeControls();
        }

        public FixedAssetDetailActionDetForm() : base("FIXEDASSETDETAILACTIONDET", "FixedAssetDetailActionDetForm")
        {
        }

        protected FixedAssetDetailActionDetForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}