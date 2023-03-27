
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
    /// Tamamlanmış Kalibrasyon[Stok Numaralı]
    /// </summary>
    public partial class MaterialCalibrationCompletedForm : CalibrationBaseForm
    {
    /// <summary>
    /// Kalibrasyon [Stok Numaralı]
    /// </summary>
        protected TTObjectClasses.MaterialCalibration _MaterialCalibration
        {
            get { return (TTObjectClasses.MaterialCalibration)_ttObject; }
        }

        protected ITTLabel CalibrationStatusLabel;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox RequestNO;
        protected ITTTextBox Description;
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
        protected ITTLabel ttlabel5;
        protected ITTLabel labelRequestNO;
        protected ITTLabel labelDescription;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox ttobjectlistbox4;
        protected ITTObjectListBox FixedAssetDefinition;
        protected ITTLabel labelFixedAsset;
        override protected void InitializeControls()
        {
            CalibrationStatusLabel = (ITTLabel)AddControl(new Guid("117dab6b-ed0d-4be5-86a0-58327f938e41"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("cf27dfc3-4ebe-47bd-9258-930a6c747a4b"));
            RequestNO = (ITTTextBox)AddControl(new Guid("4e46704a-642f-4fca-b970-93b3c37b6c37"));
            Description = (ITTTextBox)AddControl(new Guid("b88ddbd3-cf82-400d-897e-4175f3ca2521"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("612f62b1-ce76-41df-ba2e-cc3fb25ac856"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("6d6ecf4e-6b1f-4141-8398-9a8bd68dab98"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("9e63a057-6ecd-4d7e-b242-58c258c9136a"));
            ttgrid2 = (ITTGrid)AddControl(new Guid("94007917-edca-4cfb-852c-639849e9edab"));
            ItemName = (ITTTextBoxColumn)AddControl(new Guid("88f91f85-fc87-4c0b-aa94-db72072c148f"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("3aa515c7-074b-499d-8d3b-ee874b710800"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("b28382fb-9ad1-4d3d-b526-09949c0bef43"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("e9fdb426-c01f-4a44-9f81-d290c8579b93"));
            Calibrator = (ITTListBoxColumn)AddControl(new Guid("760bcdbd-054e-42f7-8336-488e68f3214f"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("c2d9f42d-2ffb-45d5-be2b-cc7e0f59e53a"));
            CalibrationTests = (ITTGrid)AddControl(new Guid("f1d213d3-78e1-481e-97b3-56c492958449"));
            CalibrationTestDefinition = (ITTListBoxColumn)AddControl(new Guid("012e62a6-a1e9-4778-a2b8-e1b87ff046f1"));
            ApplicableTestCount = (ITTTextBoxColumn)AddControl(new Guid("24c3f4a6-6f6f-4e3f-b22e-5204c6aee2fa"));
            ExistingTestCount = (ITTTextBoxColumn)AddControl(new Guid("39ef2a0d-efde-433a-8600-0003350516f0"));
            cmdReport = (ITTButtonColumn)AddControl(new Guid("b962cda6-ca98-4e15-9011-64aafc812386"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("efc125bd-e3a0-4c0c-95f0-5e02214f1955"));
            FullCalibration = (ITTCheckBox)AddControl(new Guid("8a018355-4b58-4ceb-9804-20c9de6dd4f6"));
            LimitedCalibration = (ITTCheckBox)AddControl(new Guid("be608e94-ac86-43b5-b33d-d5e6bebb3c61"));
            NoNeedCalibration = (ITTCheckBox)AddControl(new Guid("c9670a22-e0ac-41be-8243-14c77d486a60"));
            NotCalibration = (ITTCheckBox)AddControl(new Guid("e05c7c3a-0671-491b-a8a2-72e2ead4d46f"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("2e8051ef-8777-4813-8f3b-dc0fe93d8962"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("cdf95260-e83d-4409-8d53-f3d2687b8c0e"));
            tttextbox7 = (ITTTextBox)AddControl(new Guid("3a48c091-5996-443e-af6a-93807dbfc386"));
            tttextbox6 = (ITTTextBox)AddControl(new Guid("2495728b-b37c-4891-af55-d46f46adb275"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("681492bb-8924-451a-b7f5-9dd6c14f594a"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("1771001b-b86f-4553-8e65-832cf41b1eed"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("e02e219f-beff-4ee8-8739-ee498d460c56"));
            ttobjectlistbox3 = (ITTObjectListBox)AddControl(new Guid("b6eaae4e-80ee-4da5-8ab4-503a89d734a0"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("e4f9da15-1012-4041-b4a1-eb5e4d123e0a"));
            tttextbox5 = (ITTTextBox)AddControl(new Guid("ea40b265-0a6d-4c2c-9c07-305e7fa5f9fc"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("78def17e-28df-46f9-892a-0b08004b7f47"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("9021ab26-e7c3-4139-a551-9f664d44abec"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("4321b833-5f53-4474-8430-3e19d7a83f8c"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("f461903f-a602-491f-a7cc-c4f1c5633ec3"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("82a9fe9d-8bc5-4fc6-b429-c7a1f0474745"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("51d50dd9-6906-4c0b-8442-2030a37aee14"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("d69c517d-2de2-4d29-ac86-d2635eadf041"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("7ede7fe6-ad8d-4620-9bf8-c0d3fd404b69"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("2e4064e2-44e5-4b2b-9b92-6481e97045b7"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("4abcc7ab-d48b-4122-9a84-dcd438ceb8b5"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("f9af02f0-b351-400f-981a-86392a44fae9"));
            labelStartDate = (ITTLabel)AddControl(new Guid("7ff3cc25-e754-4ec8-a3ae-5739a6ad8f37"));
            ttlabel16 = (ITTLabel)AddControl(new Guid("0a176dad-11b8-40a6-92ca-60a3bafa2d32"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("e22ac47a-7943-4085-8fc2-60ae7fbd09bc"));
            labelNotCalibreReasonDesc = (ITTLabel)AddControl(new Guid("6397cf06-2475-41d7-822d-16ecbd13b49c"));
            NotCalibreReason1 = (ITTCheckBox)AddControl(new Guid("581d1bdc-e7a6-4539-abab-a40e8f28b2b4"));
            NotCalibreReason5 = (ITTCheckBox)AddControl(new Guid("bbe01236-d321-4d61-80f0-926e1cc99c13"));
            NotCalibreReason4 = (ITTCheckBox)AddControl(new Guid("ef03bba3-12e9-4a3a-a30a-fa9385563844"));
            NotCalibreReason3 = (ITTCheckBox)AddControl(new Guid("13d20ee8-3b02-4285-a86b-73b5856e1f09"));
            NotCalibreReason2 = (ITTCheckBox)AddControl(new Guid("5212faec-c355-481a-8bf0-5db0ff51fe51"));
            NotCalibreReasonDesc = (ITTTextBox)AddControl(new Guid("3ace90bf-a099-4560-beae-cc45cfd195a9"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("3a69a5be-cc8a-4219-aaa3-0ebeebf4640c"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("31f47f04-7403-4e19-9187-d39c48fd96bc"));
            labelDescription = (ITTLabel)AddControl(new Guid("7ca08d0a-31d9-4a76-9a89-fed0018750b8"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("80c1fcc2-7970-4b5d-865f-1d8840a37237"));
            ttobjectlistbox4 = (ITTObjectListBox)AddControl(new Guid("300385f3-d78b-4fdc-b3a8-1387ea5ebcba"));
            FixedAssetDefinition = (ITTObjectListBox)AddControl(new Guid("d2406eff-2454-4392-ba13-0c4e6c466602"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("f1e284d2-8535-495b-94ca-7d179d2580cf"));
            base.InitializeControls();
        }

        public MaterialCalibrationCompletedForm() : base("MATERIALCALIBRATION", "MaterialCalibrationCompletedForm")
        {
        }

        protected MaterialCalibrationCompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}