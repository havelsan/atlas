
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
    /// Amir Onayı [Stok Numaralı]
    /// </summary>
    public partial class MaterialCalibrationChiefApprovalForm : CalibrationBaseForm
    {
    /// <summary>
    /// Kalibrasyon [Stok Numaralı]
    /// </summary>
        protected TTObjectClasses.MaterialCalibration _MaterialCalibration
        {
            get { return (TTObjectClasses.MaterialCalibration)_ttObject; }
        }

        protected ITTTextBox RequestNO;
        protected ITTTextBox tttextbox1;
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
        protected ITTLabel ttlabel9;
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
        protected ITTDateTimePicker StartDate;
        protected ITTDateTimePicker EndDate;
        protected ITTLabel labelStartDate;
        protected ITTLabel ttlabel8;
        protected ITTLabel labelEndDate;
        protected ITTLabel ttlabel7;
        protected ITTLabel ttlabel6;
        protected ITTTabPage tttabpage3;
        protected ITTCheckBox NotCalibreReason1;
        protected ITTCheckBox NotCalibreReason2;
        protected ITTCheckBox NotCalibreReason3;
        protected ITTCheckBox NotCalibreReason4;
        protected ITTCheckBox NotCalibreReason5;
        protected ITTLabel labelNotCalibreReasonDesc;
        protected ITTTextBox NotCalibreReasonDesc;
        protected ITTTextBox Description;
        protected ITTLabel CalibrationStatusLabel;
        protected ITTLabel ttlabel5;
        protected ITTLabel labelRequestNO;
        protected ITTLabel labelDescription;
        protected ITTRichTextBoxControl ttrichtextboxcontrol2;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox ttobjectlistbox4;
        protected ITTLabel labelFixedAsset;
        protected ITTObjectListBox FixedAssetDefinition;
        override protected void InitializeControls()
        {
            RequestNO = (ITTTextBox)AddControl(new Guid("ee2df70f-b119-45d3-ac94-42ce75642610"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("d881420e-5ea2-44db-96cc-9f9f037520db"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("b1fa80a6-bd1d-4e98-be27-2ef41a945bf5"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("9b9094ed-4446-4865-8fce-8bf030ee34e2"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("105c2b31-0c4c-4eb2-8352-393d45fe5616"));
            ttgrid2 = (ITTGrid)AddControl(new Guid("c7e36cc3-4682-4a33-962b-bf373e598dd3"));
            ItemName = (ITTTextBoxColumn)AddControl(new Guid("33502b06-3be9-4f7e-8bc3-7859d17ea79c"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("c0a6181f-76c4-44dd-8f32-e1ff493acf8b"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("18bb4a38-4ed6-4a3b-b4ae-f8b15c4ae2f9"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("9011e097-ac20-4164-a982-e9d80900561a"));
            Calibrator = (ITTListBoxColumn)AddControl(new Guid("0bb78e30-0b4b-40d8-a788-5377e6fb4afc"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("803c27f0-62cd-4138-94ee-f297e6737a69"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("b7b60d62-31d2-43ba-9cd7-7d54edfcaee7"));
            CalibrationTests = (ITTGrid)AddControl(new Guid("5dc8d86c-3336-468c-aa68-d21e7e8f21c6"));
            CalibrationTestDefinition = (ITTListBoxColumn)AddControl(new Guid("b032fa52-0841-4c2f-af03-aee1168e7967"));
            ApplicableTestCount = (ITTTextBoxColumn)AddControl(new Guid("e8c96c39-7658-4921-bbbb-ea0aa3e8ecb5"));
            ExistingTestCount = (ITTTextBoxColumn)AddControl(new Guid("9cd7c21c-8e74-432e-804e-bd94ce7d2e7a"));
            cmdReport = (ITTButtonColumn)AddControl(new Guid("8a34310a-d3b9-4a13-9100-9c2dc65e25a6"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("96e1c6f9-ddec-4071-8c93-1ec5f081f78a"));
            FullCalibration = (ITTCheckBox)AddControl(new Guid("a2b88e65-f6c9-468f-8444-41d81d4f10f1"));
            LimitedCalibration = (ITTCheckBox)AddControl(new Guid("c499a44e-0dc1-4a46-a623-395f9720f12c"));
            NoNeedCalibration = (ITTCheckBox)AddControl(new Guid("dca6692a-35a8-4db7-a3eb-6d4e76562206"));
            NotCalibration = (ITTCheckBox)AddControl(new Guid("154516f1-6129-46a1-94b5-6445096936f9"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("5bf010e6-9fa7-4515-b373-dae850cafe49"));
            tttextbox7 = (ITTTextBox)AddControl(new Guid("edf18965-5c8c-45cc-a0e2-df4c91dd8b84"));
            tttextbox6 = (ITTTextBox)AddControl(new Guid("6b341e43-2a32-4188-b187-bf50bc2ce4de"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("79fa09b1-db66-4412-8a9f-24cae3ff8c4a"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("b16e8da5-5c55-4913-bcb6-173cfc84141e"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("aec9f5ff-6edb-45fc-a772-62e4f8212c6e"));
            ttobjectlistbox3 = (ITTObjectListBox)AddControl(new Guid("2a160358-7484-4f19-a246-de6704f64562"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("47c6fd74-7597-4f53-b387-396a935cd50c"));
            tttextbox5 = (ITTTextBox)AddControl(new Guid("050fc060-aa8a-4159-b85a-d6291ae17a99"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("27889d4c-7add-4c97-ac3e-5e8bb93d031c"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("6f7a04ae-b034-4f3c-96ef-ac68b3936849"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("5c3c5d02-3271-4408-8aaa-590eb3fadea0"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("df4024bc-a922-43f8-b63c-86612135c10b"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("8d4f9b87-e494-43ee-a76a-bb2797b10816"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("592063e6-1b35-4328-bff5-408ce676c91d"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("ca86d456-6f6d-455c-b1de-224fde06dc5c"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("05b21e55-6230-44f4-8a8e-534b6b27e97c"));
            labelStartDate = (ITTLabel)AddControl(new Guid("487f450e-571d-4a7b-b5cc-0a6938ac84a9"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("4fe08ef0-8e0e-46fe-992d-ea2ee92ae84d"));
            labelEndDate = (ITTLabel)AddControl(new Guid("3fce914f-faef-48cf-9065-31b265c8719e"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("73feb8e8-bcae-48da-b414-0880912048cd"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("6b5a9ee7-33c9-4f8c-9784-a2c39f0e37c5"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("8ceeb4ac-3502-4e5f-abdc-1a381f9c40a4"));
            NotCalibreReason1 = (ITTCheckBox)AddControl(new Guid("6f68d7f8-a835-4fdd-ae72-b0100a687e04"));
            NotCalibreReason2 = (ITTCheckBox)AddControl(new Guid("650b7d22-5e1d-4577-a8d1-2f040962d85a"));
            NotCalibreReason3 = (ITTCheckBox)AddControl(new Guid("6398649a-1c0b-4f86-af57-9b6988d9af70"));
            NotCalibreReason4 = (ITTCheckBox)AddControl(new Guid("fd1741d5-b64e-4fd6-8b8e-f50233adf20b"));
            NotCalibreReason5 = (ITTCheckBox)AddControl(new Guid("a5631116-5650-44be-ac86-60fa6a16db83"));
            labelNotCalibreReasonDesc = (ITTLabel)AddControl(new Guid("42643d74-b10c-420e-a71b-de63edb72a49"));
            NotCalibreReasonDesc = (ITTTextBox)AddControl(new Guid("841b9813-9031-469c-9665-f85b31a05a12"));
            Description = (ITTTextBox)AddControl(new Guid("220474aa-4a12-44dc-b847-0ce16d5e6512"));
            CalibrationStatusLabel = (ITTLabel)AddControl(new Guid("28c97fde-18e8-45e2-93ee-0837ece5984c"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("2fd2adfb-82a2-4f95-98a3-52eb3ba4e73c"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("7a998ad1-acf3-439a-aef9-b163087770bd"));
            labelDescription = (ITTLabel)AddControl(new Guid("c9d10d0e-eb1a-4b81-b777-e258d41ec60e"));
            ttrichtextboxcontrol2 = (ITTRichTextBoxControl)AddControl(new Guid("5dc6b638-b438-4b89-a5f7-64bbdbc1b118"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("3328781b-ba18-47fb-ad4d-62b7771ef8c6"));
            ttobjectlistbox4 = (ITTObjectListBox)AddControl(new Guid("c060d297-f6f3-4343-a24a-4b890d1c1ffc"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("9bb013ae-0340-471e-b8d7-bde34e74032a"));
            FixedAssetDefinition = (ITTObjectListBox)AddControl(new Guid("b3c64a80-f628-4d9a-af93-443247676c06"));
            base.InitializeControls();
        }

        public MaterialCalibrationChiefApprovalForm() : base("MATERIALCALIBRATION", "MaterialCalibrationChiefApprovalForm")
        {
        }

        protected MaterialCalibrationChiefApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}