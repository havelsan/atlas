
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
    /// Set Detayları
    /// </summary>
    public partial class SetMaterialDetailDefForm : TTForm
    {
        protected TTObjectClasses.SetMaterialDetailDef _SetMaterialDetailDef
        {
            get { return (TTObjectClasses.SetMaterialDetailDef)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox2;
        protected ITTLabel labelLifePeriodFixedAssetMaterialDefinitionDetail;
        protected ITTDateTimePicker UseStartDate;
        protected ITTTextBox LifePeriodFixedAssetMaterialDefinitionDetail;
        protected ITTLabel labelUseStartDate;
        protected ITTMaskedTextBox ProposedNATOStockNo;
        protected ITTTextBox IntendedUse;
        protected ITTTextBox Frequency;
        protected ITTLabel labelVoltage;
        protected ITTLabel labelFrequency;
        protected ITTLabel labelIntendedUse;
        protected ITTTextBox Voltage;
        protected ITTEnumComboBox IsAdvancedTechnology;
        protected ITTTextBox Power;
        protected ITTEnumComboBox CalibrationPeriod;
        protected ITTLabel labelPower;
        protected ITTTextBox GuarantiePeriod;
        protected ITTLabel labelCalibrationPeriod;
        protected ITTEnumComboBox CalibrationStatus;
        protected ITTLabel labelLastMaintenanceDate;
        protected ITTLabel labelMaintenancePeriod;
        protected ITTTextBox ProposedStockcardName;
        protected ITTDateTimePicker LastMaintenanceDate;
        protected ITTTextBox ProposedNATOStockNo1;
        protected ITTLabel labelCalibrationStatus;
        protected ITTEnumComboBox MaintenancePeriod;
        protected ITTLabel labelMaintanenceStatus;
        protected ITTLabel labelGuarantiePeriod;
        protected ITTEnumComboBox MaintanenceStatus;
        protected ITTDateTimePicker GuarantyStartDate;
        protected ITTLabel labelGuarantyStartDate;
        protected ITTEnumComboBox GuarantyStatus;
        protected ITTLabel labelGuarantyStatus;
        protected ITTLabel labelLastCalibrationDate;
        protected ITTLabel labelIsAdvancedTechnology;
        protected ITTDateTimePicker LastCalibrationDate;
        protected ITTLabel labelProposedNATOStockNo;
        protected ITTLabel labelProposedStockcardName;
        protected ITTGroupBox ttgroupbox1;
        protected ITTCheckBox OtherLenght;
        protected ITTCheckBox OtherModel;
        protected ITTCheckBox OtherEdge;
        protected ITTTextBox PhysicalBarcode;
        protected ITTCheckBox OtherBody;
        protected ITTCheckBox OtherMark;
        protected ITTObjectListBox Length;
        protected ITTCheckBox OtherMainClass;
        protected ITTEnumComboBox DetailType;
        protected ITTLabel labelFixedAssetDetailEdgeDef;
        protected ITTLabel labelDetailType;
        protected ITTObjectListBox FixedAssetDetailEdgeDef;
        protected ITTEnumComboBox IsDemoded;
        protected ITTLabel labelFixedAssetDetailBodyDef;
        protected ITTLabel labelIsDemoded;
        protected ITTTextBox Description;
        protected ITTButton cmdFind;
        protected ITTObjectListBox FixedAssetDetailBodyDef;
        protected ITTEnumComboBox OperationStatus;
        protected ITTLabel labelFixedAssetDetailModelDef;
        protected ITTLabel labelProductionDate;
        protected ITTLabel labelOperationStatus;
        protected ITTDateTimePicker ProductionDate;
        protected ITTTextBox SerialNumber;
        protected ITTObjectListBox FixedAssetDetailModelDef;
        protected ITTTextBox ReferansNo;
        protected ITTLabel labelPhysicalBarcode;
        protected ITTLabel labelFixedAssetDetailMarkDef;
        protected ITTTextBox MarkModelReason;
        protected ITTObjectListBox FixedAssetDetailMarkDef;
        protected ITTLabel labelMarkModelReason;
        protected ITTLabel labelFixedAssetDetailMainClass;
        protected ITTEnumComboBox MarkModelStatus;
        protected ITTObjectListBox FixedAssetDetailMainClass;
        protected ITTLabel labelMarkModelStatus;
        protected ITTLabel labelDescription;
        protected ITTLabel labelLength;
        protected ITTLabel labelSerialNumber;
        protected ITTLabel labelReferansNo;
        protected ITTPictureBoxControl Picture;
        protected ITTLabel labelPicture;
        override protected void InitializeControls()
        {
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("15b50935-1575-467a-a263-264301129db5"));
            labelLifePeriodFixedAssetMaterialDefinitionDetail = (ITTLabel)AddControl(new Guid("951c3da0-766a-4373-8450-758dffe3194b"));
            UseStartDate = (ITTDateTimePicker)AddControl(new Guid("347394ef-8f0b-4cc6-ac35-5feaa28df8a9"));
            LifePeriodFixedAssetMaterialDefinitionDetail = (ITTTextBox)AddControl(new Guid("1e6d13aa-15e4-404f-bb2f-6d88c10fd3e6"));
            labelUseStartDate = (ITTLabel)AddControl(new Guid("69675029-e7ba-4dbe-a1c3-f750add22a56"));
            ProposedNATOStockNo = (ITTMaskedTextBox)AddControl(new Guid("bc8283c0-37e2-4622-bb6e-37c43e171cf4"));
            IntendedUse = (ITTTextBox)AddControl(new Guid("759faaac-cf5d-4568-a5d2-ab98a3375988"));
            Frequency = (ITTTextBox)AddControl(new Guid("4f907a00-9999-4da1-8fc3-b911db3b7650"));
            labelVoltage = (ITTLabel)AddControl(new Guid("6b6cbd37-43a2-4e39-89e1-b8914b72bc7a"));
            labelFrequency = (ITTLabel)AddControl(new Guid("d65550f4-8364-4784-8c47-73802afea150"));
            labelIntendedUse = (ITTLabel)AddControl(new Guid("a7a4a74d-1730-44d4-9191-48b6384bc2f3"));
            Voltage = (ITTTextBox)AddControl(new Guid("a219d598-ad04-4cfa-b71e-1b15a8926e62"));
            IsAdvancedTechnology = (ITTEnumComboBox)AddControl(new Guid("c8d5f1f1-4371-4330-b42e-c9fd007d5580"));
            Power = (ITTTextBox)AddControl(new Guid("976f006f-8f74-4398-8e16-bbd98703a423"));
            CalibrationPeriod = (ITTEnumComboBox)AddControl(new Guid("af65e1de-7c86-4d72-86aa-1b82f49ae952"));
            labelPower = (ITTLabel)AddControl(new Guid("1c744870-5224-43a6-b84f-0d8af4079e39"));
            GuarantiePeriod = (ITTTextBox)AddControl(new Guid("f56ed39f-12e2-47d5-bf71-75ea009d6f01"));
            labelCalibrationPeriod = (ITTLabel)AddControl(new Guid("1f0fe8cb-d916-4e2e-a220-cb3484dc91f5"));
            CalibrationStatus = (ITTEnumComboBox)AddControl(new Guid("d0a97b4c-613e-40cd-abda-17cda5829481"));
            labelLastMaintenanceDate = (ITTLabel)AddControl(new Guid("53cdca57-d576-49bc-9bdf-d828906bd8c9"));
            labelMaintenancePeriod = (ITTLabel)AddControl(new Guid("2d3d5654-46e8-4ba0-9b9f-cd8f9bd062d5"));
            ProposedStockcardName = (ITTTextBox)AddControl(new Guid("fb7f6843-4d94-40dd-9e98-633fef4bb9cb"));
            LastMaintenanceDate = (ITTDateTimePicker)AddControl(new Guid("b6e293bd-c46b-4f16-bc20-d6e2387d7fe7"));
            ProposedNATOStockNo1 = (ITTTextBox)AddControl(new Guid("9d373967-1e68-4117-8ee8-1f785d7f84c9"));
            labelCalibrationStatus = (ITTLabel)AddControl(new Guid("4df90c0f-240a-48a2-b58d-cdb93eecc5be"));
            MaintenancePeriod = (ITTEnumComboBox)AddControl(new Guid("102e0117-df84-4653-940d-98c9a4a9b141"));
            labelMaintanenceStatus = (ITTLabel)AddControl(new Guid("84c3501c-455b-4272-be20-a834fc014974"));
            labelGuarantiePeriod = (ITTLabel)AddControl(new Guid("439609fa-3174-43ab-ae34-0b4fed60e130"));
            MaintanenceStatus = (ITTEnumComboBox)AddControl(new Guid("459cb948-d831-412a-92f9-f9606eedc2d7"));
            GuarantyStartDate = (ITTDateTimePicker)AddControl(new Guid("262302c7-da58-4957-a472-a32dcf615b4b"));
            labelGuarantyStartDate = (ITTLabel)AddControl(new Guid("69112ace-9acc-4f3e-bdcd-e7c5c067bf71"));
            GuarantyStatus = (ITTEnumComboBox)AddControl(new Guid("ecbfdeaa-e6df-41a0-8aaa-acb2aebf0f5a"));
            labelGuarantyStatus = (ITTLabel)AddControl(new Guid("8759ca73-97c1-40af-b6d1-aa472c23d0c9"));
            labelLastCalibrationDate = (ITTLabel)AddControl(new Guid("71c3d82a-e678-4734-8715-ffae1a986b1d"));
            labelIsAdvancedTechnology = (ITTLabel)AddControl(new Guid("67bc3f09-a1ca-4899-8d58-8f30ffd0a0d7"));
            LastCalibrationDate = (ITTDateTimePicker)AddControl(new Guid("1f7ec04c-8de9-4892-9601-5b3ac5fbfe1e"));
            labelProposedNATOStockNo = (ITTLabel)AddControl(new Guid("df923fa5-88bd-4bc1-a3a7-a8e28296de92"));
            labelProposedStockcardName = (ITTLabel)AddControl(new Guid("dff29bdb-79b9-4aaf-a7bf-52f2fba4dd61"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("c73f682b-32a9-48a7-a34e-f4f93b48d2b5"));
            OtherLenght = (ITTCheckBox)AddControl(new Guid("c9daabaf-6add-434d-802a-0e7b301ef1cb"));
            OtherModel = (ITTCheckBox)AddControl(new Guid("33f340a3-b6e9-4995-9973-4067bb43df3b"));
            OtherEdge = (ITTCheckBox)AddControl(new Guid("8511d5e9-0970-4227-8c2a-611875b30023"));
            PhysicalBarcode = (ITTTextBox)AddControl(new Guid("8e9fa56b-bce9-4c29-a208-c3a630c01df0"));
            OtherBody = (ITTCheckBox)AddControl(new Guid("15d3e78e-dcf9-4d35-971b-ad7396eaf171"));
            OtherMark = (ITTCheckBox)AddControl(new Guid("de95138a-f9fb-4d41-b106-1135bda766bf"));
            Length = (ITTObjectListBox)AddControl(new Guid("75a49aa4-ad41-4f4f-877d-d773215f1e8f"));
            OtherMainClass = (ITTCheckBox)AddControl(new Guid("af5c5de6-8c2b-4e38-9fd2-756aca5e51b5"));
            DetailType = (ITTEnumComboBox)AddControl(new Guid("bd5bd341-e6fa-4b7f-9031-eaa6fd6e8f4b"));
            labelFixedAssetDetailEdgeDef = (ITTLabel)AddControl(new Guid("a2f89547-6902-498d-af9f-a7fb987b9bfa"));
            labelDetailType = (ITTLabel)AddControl(new Guid("afc00e73-ed74-45ce-a95e-11a637c4bc76"));
            FixedAssetDetailEdgeDef = (ITTObjectListBox)AddControl(new Guid("ca45eba7-4872-4e0d-b9eb-0a3d5d70b818"));
            IsDemoded = (ITTEnumComboBox)AddControl(new Guid("c9063cd2-2673-4c54-875e-ac6020d19f52"));
            labelFixedAssetDetailBodyDef = (ITTLabel)AddControl(new Guid("20e8cd22-23e6-44fd-a10a-d4af5f7a36bf"));
            labelIsDemoded = (ITTLabel)AddControl(new Guid("b97a99c1-6f76-48f2-a058-547ed8a68620"));
            Description = (ITTTextBox)AddControl(new Guid("7a6dafc8-4397-402f-8caf-6967e97a17c0"));
            cmdFind = (ITTButton)AddControl(new Guid("c2d35605-2142-4a00-bfb9-b1c20000dadc"));
            FixedAssetDetailBodyDef = (ITTObjectListBox)AddControl(new Guid("0323f16c-e2e6-4409-9b05-8514a1eaec73"));
            OperationStatus = (ITTEnumComboBox)AddControl(new Guid("e39a8f68-6498-4fe1-bfa6-85bad472a8f3"));
            labelFixedAssetDetailModelDef = (ITTLabel)AddControl(new Guid("ca0d26ae-7a46-4661-890c-ccee179a5eb5"));
            labelProductionDate = (ITTLabel)AddControl(new Guid("a50486b9-cd26-4084-ac36-f65d190f05b6"));
            labelOperationStatus = (ITTLabel)AddControl(new Guid("635b5244-2c8b-4e91-9e5f-f36044c978de"));
            ProductionDate = (ITTDateTimePicker)AddControl(new Guid("1343483a-c4d4-4ecd-9da6-e3bed41f3e1e"));
            SerialNumber = (ITTTextBox)AddControl(new Guid("f3fea6a5-84fd-4918-bf37-0a2ca1f54156"));
            FixedAssetDetailModelDef = (ITTObjectListBox)AddControl(new Guid("927342f8-b68a-489b-a996-fba3ac594bc3"));
            ReferansNo = (ITTTextBox)AddControl(new Guid("31109472-3a22-4f8b-a2da-718740c5cf40"));
            labelPhysicalBarcode = (ITTLabel)AddControl(new Guid("b6cb4470-e738-4b1c-b883-4619b88df812"));
            labelFixedAssetDetailMarkDef = (ITTLabel)AddControl(new Guid("e0d9aedf-1c64-42b3-91c0-27a0fdff9622"));
            MarkModelReason = (ITTTextBox)AddControl(new Guid("7ea1c04e-0012-4071-981a-d5e8c9ce9762"));
            FixedAssetDetailMarkDef = (ITTObjectListBox)AddControl(new Guid("056d3517-587e-4ec2-91e3-62784cda1338"));
            labelMarkModelReason = (ITTLabel)AddControl(new Guid("6c20f9a0-fd85-46d3-a929-842b8f2a906b"));
            labelFixedAssetDetailMainClass = (ITTLabel)AddControl(new Guid("ef6c0b86-14ab-406e-8489-8accca372f48"));
            MarkModelStatus = (ITTEnumComboBox)AddControl(new Guid("68e1f6b5-d2c5-4f67-8cb6-f7217bbab849"));
            FixedAssetDetailMainClass = (ITTObjectListBox)AddControl(new Guid("88102af3-701b-4b0a-9499-c6aa5e219be8"));
            labelMarkModelStatus = (ITTLabel)AddControl(new Guid("9a5e40be-5856-4898-9649-daee90de177d"));
            labelDescription = (ITTLabel)AddControl(new Guid("37adfe59-dde9-4e40-8728-03a3e1545fbf"));
            labelLength = (ITTLabel)AddControl(new Guid("006a41cb-3fd7-4e34-8cf0-77e113349e04"));
            labelSerialNumber = (ITTLabel)AddControl(new Guid("89f3ed1d-1295-429d-8f65-3add97e52f93"));
            labelReferansNo = (ITTLabel)AddControl(new Guid("537443d9-5648-4888-a0b1-26f66046b474"));
            Picture = (ITTPictureBoxControl)AddControl(new Guid("11d7e4c8-16b7-4018-979c-94e5ce3cfcc7"));
            labelPicture = (ITTLabel)AddControl(new Guid("d08838d7-6d05-4d7f-b7fa-a877c48c165a"));
            base.InitializeControls();
        }

        public SetMaterialDetailDefForm() : base("SETMATERIALDETAILDEF", "SetMaterialDetailDefForm")
        {
        }

        protected SetMaterialDetailDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}