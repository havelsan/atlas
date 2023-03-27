
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
    /// Kalibrasyon
    /// </summary>
    public partial class CalibrationForm : CalibrationBaseForm
    {
    /// <summary>
    /// Kalibrasyon
    /// </summary>
        protected TTObjectClasses.Calibration _Calibration
        {
            get { return (TTObjectClasses.Calibration)_ttObject; }
        }

        protected ITTTextBox Description;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTGroupBox ttgroupbox2;
        protected ITTCheckBox FullCalibration;
        protected ITTCheckBox LimitedCalibration;
        protected ITTCheckBox NoNeedCalibration;
        protected ITTCheckBox NotCalibration;
        protected ITTRichTextBoxControl Result;
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
        protected ITTGroupBox ttgroupbox1;
        protected ITTTextBox HumidityDeviationText;
        protected ITTTextBox TemperatureDeviationText;
        protected ITTTextBox TemperatureText;
        protected ITTLabel ttlabel23;
        protected ITTLabel ttlabel22;
        protected ITTLabel ttlabel16;
        protected ITTLabel ttlabel13;
        protected ITTLabel ttlabel14;
        protected ITTLabel ttlabel15;
        protected ITTLabel ttlabel18;
        protected ITTLabel ttlabel17;
        protected ITTTextBox RelativeHumidityText;
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
        protected ITTTabPage tttabpage4;
        protected ITTLabel ttlabel20;
        protected ITTRichTextBoxControl DetailDescription;
        protected ITTLabel ttlabel21;
        protected ITTButton cmdForkDemand;
        protected ITTObjectListBox PurchaseItem;
        protected ITTTabPage tttabpage5;
        protected ITTLabel ttlabel25;
        protected ITTLabel ttlabel24;
        protected ITTGrid UsedConsumedMaterails;
        protected ITTListBoxColumn MaterialUsedConsumedMaterail;
        protected ITTTextBoxColumn RequestAmountUsedConsumedMaterail;
        protected ITTTextBoxColumn SuppliedAmountUsedConsumedMaterail;
        protected ITTTextBoxColumn AmountUsedConsumedMaterail;
        protected ITTTextBoxColumn UnitPriceUsedConsumedMaterail;
        protected ITTGrid CalibrationConsumedMaterials;
        protected ITTListBoxColumn MaterialCalibrationConsumedMat;
        protected ITTTextBoxColumn SparePartMaterialDescriptionCalibrationConsumedMat;
        protected ITTTextBoxColumn RequestAmountCalibrationConsumedMat;
        protected ITTTextBoxColumn DescriptionCalibrationConsumedMat;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox RequestNO;
        protected ITTLabel CalibrationStatusLabel;
        protected ITTLabel ttlabel5;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel4;
        protected ITTLabel labelRequestNO;
        protected ITTLabel labelDescription;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox ttobjectlistbox4;
        override protected void InitializeControls()
        {
            Description = (ITTTextBox)AddControl(new Guid("027d70f5-8d6b-49bc-92fd-d2996cfb3081"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("06b3bbbf-8edb-43af-8728-2baff070230f"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("3a375df4-f30f-45f9-8b74-7cd87fbd2e0d"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("7f29eb94-34d8-4506-9e36-11e409a21965"));
            FullCalibration = (ITTCheckBox)AddControl(new Guid("e3530225-6a92-48fe-9582-caf2ed8dc1a8"));
            LimitedCalibration = (ITTCheckBox)AddControl(new Guid("50f23a16-88d7-415f-bfb9-4a562897fdbc"));
            NoNeedCalibration = (ITTCheckBox)AddControl(new Guid("0107b4dc-c4c4-4fec-bd75-ee7f29f194cf"));
            NotCalibration = (ITTCheckBox)AddControl(new Guid("b09442f6-a4f5-4b36-be1f-a92eebdfed69"));
            Result = (ITTRichTextBoxControl)AddControl(new Guid("af773e74-a622-40e0-94cd-5698b9cd9fc0"));
            ttgrid2 = (ITTGrid)AddControl(new Guid("d3510641-1328-4685-9995-02fc90688cab"));
            ItemName = (ITTTextBoxColumn)AddControl(new Guid("cfedae9d-5964-4c28-aa38-290e4c0d76de"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("426f0a60-443a-49f6-b57f-182fdec00e7b"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("0b33c00f-a5c1-4cb8-8af3-28a553524e21"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("ea74bfc7-9953-4dab-958b-aeb4fe87c164"));
            Calibrator = (ITTListBoxColumn)AddControl(new Guid("0e15b5f8-f271-4ff2-b293-45cb3bbb4f39"));
            Traceability = (ITTTextBoxColumn)AddControl(new Guid("83dd1dc4-9007-476b-a5da-57d925591ba3"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("3d07066e-9733-4dae-a527-716ee54a7a7d"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("b5fe783c-36e9-4417-a593-95425d8dbad5"));
            CalibrationTests = (ITTGrid)AddControl(new Guid("1c57a900-98a4-4899-9439-8f4544034133"));
            CalibrationTestDefinition = (ITTListBoxColumn)AddControl(new Guid("afda0969-815f-4947-b450-5dc734b6eb66"));
            ApplicableTestCount = (ITTTextBoxColumn)AddControl(new Guid("7c960822-15f3-498f-bcf5-848086aface5"));
            ExistingTestCount = (ITTTextBoxColumn)AddControl(new Guid("a3f0bc16-a5b4-4540-afaa-732bd538fd16"));
            cmdReport = (ITTButtonColumn)AddControl(new Guid("9895bb57-5f44-4106-b88d-c851c04167b6"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("e7135a28-1d97-4eda-b7dc-aadb1752cb00"));
            tttextbox6 = (ITTTextBox)AddControl(new Guid("0510471e-aec8-4264-b4b2-ab9f2f2fe922"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("e80dbe27-6607-46e2-bf30-8c0900e09686"));
            HumidityDeviationText = (ITTTextBox)AddControl(new Guid("92d65de1-4fde-47a9-a26f-0dc08ca16d3c"));
            TemperatureDeviationText = (ITTTextBox)AddControl(new Guid("2c4e3294-3f01-47c4-9559-a3db15d88451"));
            TemperatureText = (ITTTextBox)AddControl(new Guid("40098896-0478-4aac-8dd2-bb121bb2de28"));
            ttlabel23 = (ITTLabel)AddControl(new Guid("76b082d3-f219-4347-86f4-d302deaa7137"));
            ttlabel22 = (ITTLabel)AddControl(new Guid("b29fe7f5-5e31-4dec-918d-982497698ed5"));
            ttlabel16 = (ITTLabel)AddControl(new Guid("9aef6f2b-cccc-4fea-911e-dd959def01ba"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("85b29f3a-30e1-44cf-8f17-6f524a4f33db"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("96db91b2-d56c-49fc-8aef-d3b9459ad9ce"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("30ba8174-ffdb-49c9-8706-9f342309b058"));
            ttlabel18 = (ITTLabel)AddControl(new Guid("2aa3f61f-c3cb-4417-aa50-c8149fd38a46"));
            ttlabel17 = (ITTLabel)AddControl(new Guid("dc3218c1-77d4-436f-8844-146a3997ac0c"));
            RelativeHumidityText = (ITTTextBox)AddControl(new Guid("89e982c6-e83a-43db-9a8b-5e418e276c07"));
            ttobjectlistbox3 = (ITTObjectListBox)AddControl(new Guid("aaffa5e1-2f16-4488-bef3-90ba080e0a5a"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("078d6190-2a78-451e-855f-aeac814c7e21"));
            tttextbox5 = (ITTTextBox)AddControl(new Guid("c14f06a0-408c-406e-8597-648804f662ad"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("6a264edf-a001-44e4-bed0-088eb8d20ec2"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("bad7c54b-16ae-4a4c-8ad0-7f3ac506b58d"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("fd29e432-d72b-4e9a-8456-0621f4ededcb"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("4c1b4745-57fb-4407-ab56-c1e597a3306f"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("bd66cbd5-d579-4143-b750-7011965d80f9"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("654cfbf2-0c05-4266-b351-e21d646403f2"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("c58494a5-9370-4bdb-88c8-7320a5412af7"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("018042b6-cf8c-49b6-bff4-526eaa77180e"));
            ttlabel19 = (ITTLabel)AddControl(new Guid("66778709-7d2b-44a1-a144-7db9e40e64b9"));
            labelStartDate = (ITTLabel)AddControl(new Guid("03882646-a2cc-4928-a27c-e5e7f1f36cef"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("69d9594e-8689-4ede-8848-e1b6c0007b21"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("7f54c380-cba5-4bff-b9fd-0737361f73e9"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("1e78ee33-7c8f-4426-9069-38646c35a34c"));
            NotCalibreReason1 = (ITTCheckBox)AddControl(new Guid("b8060562-017e-4507-bdbc-80de9392a5a6"));
            NotCalibreReason3 = (ITTCheckBox)AddControl(new Guid("a98cd767-d854-4ca1-94c5-53a4fefac61e"));
            NotCalibreReason2 = (ITTCheckBox)AddControl(new Guid("51739d72-8fb7-4012-9f96-52fa4513e000"));
            NotCalibreReason4 = (ITTCheckBox)AddControl(new Guid("1555879e-c823-403a-a76b-a37eb0d887c0"));
            NotCalibreReason5 = (ITTCheckBox)AddControl(new Guid("4557d7d6-611a-4c23-8c0f-1f35e724cd35"));
            NotCalibreReasonDesc = (ITTTextBox)AddControl(new Guid("58d09040-6ada-4374-996b-7d9303da6a8e"));
            labelNotCalibreReasonDesc = (ITTLabel)AddControl(new Guid("f76bb233-1bf0-4038-9b48-9cb52fdf1051"));
            tttabpage4 = (ITTTabPage)AddControl(new Guid("400e43b8-eec5-4c74-9781-479585bc6fd7"));
            ttlabel20 = (ITTLabel)AddControl(new Guid("54e9a881-20d3-48fe-b762-dfa0bf03e99b"));
            DetailDescription = (ITTRichTextBoxControl)AddControl(new Guid("8b422092-64c6-46ae-a488-ac8c022f11af"));
            ttlabel21 = (ITTLabel)AddControl(new Guid("501c870b-c9f4-4ba1-8bb3-dd9c9ca23a96"));
            cmdForkDemand = (ITTButton)AddControl(new Guid("afe37657-a4ef-4a43-b8d7-3935738c0da8"));
            PurchaseItem = (ITTObjectListBox)AddControl(new Guid("54b4aaef-18b6-4440-9de0-d87463c69bbf"));
            tttabpage5 = (ITTTabPage)AddControl(new Guid("47cae83d-92cd-45a7-8f11-4f0551946aa1"));
            ttlabel25 = (ITTLabel)AddControl(new Guid("14fb2885-aa0a-4598-8c35-0a16ffa07864"));
            ttlabel24 = (ITTLabel)AddControl(new Guid("69ce7e67-a51f-4dbf-a022-b3f0061224af"));
            UsedConsumedMaterails = (ITTGrid)AddControl(new Guid("00aa07ff-bef1-4553-84d0-cb822d077952"));
            MaterialUsedConsumedMaterail = (ITTListBoxColumn)AddControl(new Guid("07686014-c34e-4fa7-93f5-5d8b12cbe3e7"));
            RequestAmountUsedConsumedMaterail = (ITTTextBoxColumn)AddControl(new Guid("8523711c-665f-4303-8be2-ebdce3ab7ab4"));
            SuppliedAmountUsedConsumedMaterail = (ITTTextBoxColumn)AddControl(new Guid("0b094d38-7af0-4d48-b1f2-a0c5c94b8e27"));
            AmountUsedConsumedMaterail = (ITTTextBoxColumn)AddControl(new Guid("c9a4d38f-c82f-4912-b2c8-ed0f3d6ccf78"));
            UnitPriceUsedConsumedMaterail = (ITTTextBoxColumn)AddControl(new Guid("f72936e5-149d-4c66-bfe6-52934ac2ddd0"));
            CalibrationConsumedMaterials = (ITTGrid)AddControl(new Guid("424c6ab7-f80e-4fe7-8178-6668a33c71e6"));
            MaterialCalibrationConsumedMat = (ITTListBoxColumn)AddControl(new Guid("c2d8b524-ae12-49ea-8685-2fabbc0e920c"));
            SparePartMaterialDescriptionCalibrationConsumedMat = (ITTTextBoxColumn)AddControl(new Guid("1c56ed2e-15c4-497c-adb5-1c921f1562dc"));
            RequestAmountCalibrationConsumedMat = (ITTTextBoxColumn)AddControl(new Guid("e3a2d86f-a43e-4f90-ae1d-24d7e5d0eaac"));
            DescriptionCalibrationConsumedMat = (ITTTextBoxColumn)AddControl(new Guid("7779c1fe-e562-4f0b-af14-3b44f7b33d97"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("c4396d0e-b54e-4032-a267-71f82ab35ef4"));
            RequestNO = (ITTTextBox)AddControl(new Guid("c6e87e5a-22ee-40ff-8fc0-64dbb0db9b07"));
            CalibrationStatusLabel = (ITTLabel)AddControl(new Guid("d98813df-233f-4c78-b0c1-5855af7bf85d"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("5730eb88-e3a1-4430-a4a3-80ef2becc734"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("7a02ebf0-2770-4e5c-a317-d3a4faa46869"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("69d05742-1ca5-480d-a9a3-98d6f7c09e28"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("512c1078-9cf5-4050-a4e1-5ac376953cc1"));
            labelDescription = (ITTLabel)AddControl(new Guid("940e72e3-9d81-4fcb-885f-5cfcb9508d9e"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("339046de-2e69-460c-be7f-f8511d5f120f"));
            ttobjectlistbox4 = (ITTObjectListBox)AddControl(new Guid("43765b09-e1a1-493a-b811-5af6ea0fe520"));
            base.InitializeControls();
        }

        public CalibrationForm() : base("CALIBRATION", "CalibrationForm")
        {
        }

        protected CalibrationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}