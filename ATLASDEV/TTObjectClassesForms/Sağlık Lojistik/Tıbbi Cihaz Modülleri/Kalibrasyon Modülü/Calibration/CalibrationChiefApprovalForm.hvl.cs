
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
    /// Amir Onayı
    /// </summary>
    public partial class CalibrationChiefApprovalForm : CalibrationBaseForm
    {
    /// <summary>
    /// Kalibrasyon
    /// </summary>
        protected TTObjectClasses.Calibration _Calibration
        {
            get { return (TTObjectClasses.Calibration)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTRichTextBoxControl ttrichtextboxcontrol2;
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
        protected ITTTextBox tttextbox1;
        protected ITTTextBox RequestNO;
        protected ITTTextBox Description;
        protected ITTLabel CalibrationStatusLabel;
        protected ITTLabel ttlabel5;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel4;
        protected ITTLabel labelRequestNO;
        protected ITTLabel labelDescription;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox ttobjectlistbox4;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("190f38d3-0fb1-4c49-807c-c34eb34bf943"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("68fc4762-4cb5-4055-97c8-87e2593fee30"));
            ttrichtextboxcontrol2 = (ITTRichTextBoxControl)AddControl(new Guid("f9a8c7f8-8acf-453e-ad86-2cafe7a4904c"));
            ttgrid2 = (ITTGrid)AddControl(new Guid("a5054941-0fa5-4803-8933-4c4f18b13f58"));
            ItemName = (ITTTextBoxColumn)AddControl(new Guid("fa2c2e5e-b6f8-4fbd-8fac-0a0bae35b770"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("de48deae-65c4-42d0-bd13-cf99a0edba15"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("b2691e65-bee1-4c4a-af3e-f16040bf3c04"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("44f0f17b-f0e8-42c0-a6f6-d1a20f7e8373"));
            Calibrator = (ITTListBoxColumn)AddControl(new Guid("f84aa36f-e92b-4564-abbd-d27c8f9edd0b"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("69a6d9ac-7bed-47a6-a940-895c81d1a112"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("20ac1e1e-e83a-45e0-ad4f-6bcb143ce472"));
            CalibrationTests = (ITTGrid)AddControl(new Guid("339f2724-caf4-4a31-b35f-4cf83f8f55d5"));
            CalibrationTestDefinition = (ITTListBoxColumn)AddControl(new Guid("982e47b8-6451-4b41-be5d-454fc16da298"));
            ApplicableTestCount = (ITTTextBoxColumn)AddControl(new Guid("18c57a03-d4f9-4869-95e3-f0478bb00b08"));
            ExistingTestCount = (ITTTextBoxColumn)AddControl(new Guid("fba61196-796f-4cc5-8462-0e8e4558e945"));
            cmdReport = (ITTButtonColumn)AddControl(new Guid("dd5b55d2-c5f0-4bcc-a338-48dd3e97db46"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("e625334b-8534-462c-9699-c2b0dcf35aa6"));
            FullCalibration = (ITTCheckBox)AddControl(new Guid("7c4c4935-62b8-44de-ab17-6b3710de292a"));
            LimitedCalibration = (ITTCheckBox)AddControl(new Guid("06849aa6-6cd4-480e-bf84-284fdb4b5283"));
            NoNeedCalibration = (ITTCheckBox)AddControl(new Guid("dd40fcf5-9a58-4a2d-97ae-6f5ad2c053a4"));
            NotCalibration = (ITTCheckBox)AddControl(new Guid("e519a686-6759-4a85-8916-79e08d4460c4"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("07fbfe91-f9b7-4057-896f-dc7168667f51"));
            tttextbox7 = (ITTTextBox)AddControl(new Guid("42739b4b-943a-4002-b439-5a64d2e41ccb"));
            tttextbox6 = (ITTTextBox)AddControl(new Guid("8a8d4cda-000a-459c-8b9d-ed59591b84ed"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("0f5792b2-8d44-4c39-9edf-f632b6c709ea"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("1b1c69e9-4f1b-4956-a031-be5dffa8dfd7"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("5ff5bb71-7ab1-40c4-8a7e-1a5d6b9cbeeb"));
            ttobjectlistbox3 = (ITTObjectListBox)AddControl(new Guid("9327ef00-1a04-4e24-aa89-fa505753155c"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("537633ec-ac1a-41cb-b403-f5f9c6fb0a1c"));
            tttextbox5 = (ITTTextBox)AddControl(new Guid("e3c70670-b710-4cd1-b0d5-5025597b6ed7"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("08e62b6c-e1b5-4658-85ce-708f1ae57f7d"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("14afc019-3ad6-4310-93ea-c6262234b8a1"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("98bd4b41-0019-4ee2-80d4-3613a82da5c3"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("442256b0-0b22-426e-9cbb-838f22f685bf"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("c0d9a5a0-a99a-4e15-b814-1120cea8f979"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("b350d0bb-60f3-43b3-a676-1171f2a3af48"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("540f884b-c668-4e2d-9226-eb6988aa6459"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("c3814030-4334-4dbe-bf42-853565260fa6"));
            labelStartDate = (ITTLabel)AddControl(new Guid("04c99b99-2c62-4f9b-a56f-fe3ee94b931d"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("66bf5c2a-4a7e-42d0-9431-b0a5aa938001"));
            labelEndDate = (ITTLabel)AddControl(new Guid("e17bcedb-fc07-445d-bb21-ed0818f49030"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("3149e794-df97-4b3b-85ac-c2db31d00943"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("a38bfccc-e27b-4c3e-b9c8-f9f6c2eace20"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("a486b505-5663-4007-8eed-38250bb0fc41"));
            NotCalibreReason1 = (ITTCheckBox)AddControl(new Guid("5e2455a5-0959-431c-8304-a8cb0e5169ff"));
            NotCalibreReason2 = (ITTCheckBox)AddControl(new Guid("90f642e2-be91-4947-8ed6-c0172b804176"));
            NotCalibreReason3 = (ITTCheckBox)AddControl(new Guid("e7b04c15-d888-40db-a317-a86eb4a8440f"));
            NotCalibreReason4 = (ITTCheckBox)AddControl(new Guid("82ced4bd-6c87-4935-9c4a-27e66a11017c"));
            NotCalibreReason5 = (ITTCheckBox)AddControl(new Guid("28d96319-c131-4ca7-82ce-5de9dc6c8225"));
            labelNotCalibreReasonDesc = (ITTLabel)AddControl(new Guid("b684bbd7-f4ea-402c-a991-266d7c3e6124"));
            NotCalibreReasonDesc = (ITTTextBox)AddControl(new Guid("ea5c134c-9801-4fb6-a990-5f6eaa8ccc37"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("91898dac-4d61-46f8-8e45-162f97646c1d"));
            RequestNO = (ITTTextBox)AddControl(new Guid("dabb8784-980c-4795-bf3f-8af3b028167d"));
            Description = (ITTTextBox)AddControl(new Guid("1c8ef5d1-d4f8-4aec-8666-f2db3be59017"));
            CalibrationStatusLabel = (ITTLabel)AddControl(new Guid("cf698449-504b-48d6-a12d-2fe35b9f6f91"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("9066f3b8-05af-438c-8985-49ab92d68253"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("1a157189-bec0-4451-a110-5c6e54370cd6"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("af7b5126-6241-405e-9e3c-3db058d18812"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("ff8f2de5-c252-467f-b074-988d11832320"));
            labelDescription = (ITTLabel)AddControl(new Guid("c0a41276-231f-4f88-a696-c21d8d303458"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("63b5eb94-2cf1-4ae9-aca4-65a478afda69"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("0167763e-fd34-4631-bf1b-e83c88c4c3d9"));
            ttobjectlistbox4 = (ITTObjectListBox)AddControl(new Guid("98e1c5e4-7753-426c-a969-31fd6abb2bfd"));
            base.InitializeControls();
        }

        public CalibrationChiefApprovalForm() : base("CALIBRATION", "CalibrationChiefApprovalForm")
        {
        }

        protected CalibrationChiefApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}