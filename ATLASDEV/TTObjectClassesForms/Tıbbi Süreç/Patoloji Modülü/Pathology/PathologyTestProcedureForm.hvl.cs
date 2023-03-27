
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
    public partial class PathologyTestProcedureForm : TTForm
    {
    /// <summary>
    /// Patoloji
    /// </summary>
        protected TTObjectClasses.Pathology _Pathology
        {
            get { return (TTObjectClasses.Pathology)_ttObject; }
        }

        protected ITTTabControl tttabcontrol2;
        protected ITTTabPage pageAnamnez;
        protected ITTTabPage pageDescription;
        protected ITTTextBox tttextbox2;
        protected ITTTabPage pageAcceptionNotes;
        protected ITTTextBox REQUESTDOCTORPHONENUMBER;
        protected ITTTextBox MaterialProtocolNo;
        protected ITTTextBox RESPONSIBLEDOCTORPHONENO;
        protected ITTTextBox MaterialResponsible;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel4;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelActionDate;
        protected ITTObjectListBox REQUESTDOCTOR;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn ttcheckboxcolumn1;
        protected ITTListBoxColumn ttlistboxcolumn1;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn ttcheckboxcolumn2;
        protected ITTListBoxColumn ttlistboxcolumn2;
        protected ITTDateTimePickerColumn ttdatetimepickercolumn1;
        protected ITTEnumComboBoxColumn ttenumcomboboxcolumn2;
        protected ITTLabel ttlabel9;
        protected ITTLabel ttlabel20;
        protected ITTLabel ttlabel10;
        protected ITTLabel ttlabel12;
        protected ITTLabel ttlabel13;
        protected ITTLabel ttlabel14;
        protected ITTObjectListBox ResposibleDoctor;
        protected ITTLabel ttlabel18;
        protected ITTObjectListBox AssistantDoctor;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tabReport;
        protected ITTTabPage tabLaboratory;
        protected ITTTabPage tabInspection;
        protected ITTGrid ttgrid1;
        protected ITTTextBoxColumn Description;
        protected ITTTabControl TabPathologyProcedure;
        protected ITTTabPage TabPageProcedure;
        protected ITTTabPage TabPageMaterial;
        protected ITTGrid GridPathologyMaterials;
        protected ITTDateTimePickerColumn MActionDate;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTextBoxColumn MAmount;
        protected ITTTextBoxColumn UBBCODE;
        protected ITTTabPage TabPageSpecialProcedure;
        protected ITTButton cmdNumberIncrement;
        protected ITTGrid GridProtocolNumbers;
        protected ITTTextBoxColumn SubMatPrtNoString;
        protected ITTListBoxColumn SpecialProcedureDefinition;
        protected ITTTextBoxColumn SubMatPrtNoSuffixNo;
        protected ITTCheckBoxColumn IsApplied;
        protected ITTButtonColumn AddSpecial;
        protected ITTButtonColumn Print;
        protected ITTButton btnPrintLabel;
        protected ITTCheckBox ttBarcodePreviewCheck;
        protected ITTButton ttPrintRequestBarcode;
        override protected void InitializeControls()
        {
            tttabcontrol2 = (ITTTabControl)AddControl(new Guid("ee537688-8056-4c5f-a10d-783ed89ee050"));
            pageAnamnez = (ITTTabPage)AddControl(new Guid("678a7f17-d325-46e5-b21d-183959324611"));
            pageDescription = (ITTTabPage)AddControl(new Guid("6662ae01-40d5-42f3-bbdb-f8238f761f92"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("1984fc72-421a-4bdb-b365-72114f5ca4c7"));
            pageAcceptionNotes = (ITTTabPage)AddControl(new Guid("30a7ea14-4c3b-4b40-9eb9-6c386b5bacf8"));
            REQUESTDOCTORPHONENUMBER = (ITTTextBox)AddControl(new Guid("d58d421e-f850-47fe-9fc4-d607e494971d"));
            MaterialProtocolNo = (ITTTextBox)AddControl(new Guid("46da62ed-5ca3-4c4d-8f73-2aec4c10a0b5"));
            RESPONSIBLEDOCTORPHONENO = (ITTTextBox)AddControl(new Guid("b86edcf6-a5dc-4d95-a80e-44fac83693e5"));
            MaterialResponsible = (ITTTextBox)AddControl(new Guid("d2891b62-30f9-416e-b8b3-1d276d551f5a"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("1cf8e2a0-adee-4e95-b3ce-1e64f89189d6"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("4a7f9be6-226b-41de-a893-2fe4521b3235"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("841e0f1a-11af-4797-8fb3-d594f9cb8239"));
            labelActionDate = (ITTLabel)AddControl(new Guid("6667ca26-c561-4151-b895-934c98e3f787"));
            REQUESTDOCTOR = (ITTObjectListBox)AddControl(new Guid("f30c964a-1ae8-43b0-979c-abf977ab1c82"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("e0e51691-afa3-45e0-88a1-6e0332d86892"));
            ttcheckboxcolumn1 = (ITTCheckBoxColumn)AddControl(new Guid("7c6c809e-f638-453d-9ca8-90d8c7e7732a"));
            ttlistboxcolumn1 = (ITTListBoxColumn)AddControl(new Guid("e8120ceb-86d6-4e9d-af6a-86b1bc072c7e"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("53a12293-5c8f-4d19-89fb-889ccf6343e2"));
            ttcheckboxcolumn2 = (ITTCheckBoxColumn)AddControl(new Guid("a9283f6a-e842-4fde-b1e8-a6798fc9ba0e"));
            ttlistboxcolumn2 = (ITTListBoxColumn)AddControl(new Guid("aa814256-740f-4045-a6f5-5ae79c2c9987"));
            ttdatetimepickercolumn1 = (ITTDateTimePickerColumn)AddControl(new Guid("f2bc68c1-f7b2-479d-8648-60ece4dbb7f5"));
            ttenumcomboboxcolumn2 = (ITTEnumComboBoxColumn)AddControl(new Guid("9973ac52-3442-481a-b3d0-1a7e8104bbcd"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("d3b4fbcb-38c9-4e5b-a5e6-297b9daecb33"));
            ttlabel20 = (ITTLabel)AddControl(new Guid("3498756c-bf7d-4049-bcc2-06b9d386d763"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("efeb3859-b5cd-473d-a929-56d3477aa2c2"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("344f6fcb-c6fd-4ab7-bdd3-99617883bf49"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("86cafda1-0a06-4825-a6f2-910e10ea8938"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("10f9973f-7326-4f0b-89bf-26213c6329fc"));
            ResposibleDoctor = (ITTObjectListBox)AddControl(new Guid("106f866b-bb2e-4cb7-8831-395c004d525e"));
            ttlabel18 = (ITTLabel)AddControl(new Guid("b505663e-360e-4ebb-8880-696828e57d8e"));
            AssistantDoctor = (ITTObjectListBox)AddControl(new Guid("1e947cdd-a712-4be9-9e7c-a3721178901c"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("74e81456-8443-45d7-864f-690175dd3571"));
            tabReport = (ITTTabPage)AddControl(new Guid("08727a4a-3200-48c4-9739-19638a4a89aa"));
            tabLaboratory = (ITTTabPage)AddControl(new Guid("b65d235c-6f43-46c8-9ab6-9825be1c1a13"));
            tabInspection = (ITTTabPage)AddControl(new Guid("eb4176f4-5b2b-4251-b330-4d1569a6b876"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("20e370ef-5ead-400f-b9c8-926fd9fbbb5e"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("3b8f8b50-49a3-4b22-81d1-4c395345f6fe"));
            TabPathologyProcedure = (ITTTabControl)AddControl(new Guid("4a34fd3a-fd44-4c51-8674-7f448894dd09"));
            TabPageProcedure = (ITTTabPage)AddControl(new Guid("3c709731-7a4c-49ba-8392-a2439cc1e2f1"));
            TabPageMaterial = (ITTTabPage)AddControl(new Guid("d8ec07cc-af35-4ec9-b802-90d8b133bdc1"));
            GridPathologyMaterials = (ITTGrid)AddControl(new Guid("125854e5-2b10-442c-b82f-d5ac44daf996"));
            MActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("9760af1f-1b69-4d6e-a046-6968998479ee"));
            Material = (ITTListBoxColumn)AddControl(new Guid("cd25dd64-354b-4e22-bc03-90f7c79a335c"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("9e7e1c7e-e180-41dd-9551-20bf9dd7f772"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("ceb6a8c0-82a4-4b70-b593-bae8cf4fa03a"));
            MAmount = (ITTTextBoxColumn)AddControl(new Guid("bd0b3c3b-f47b-4250-acf1-dcbce06cc653"));
            UBBCODE = (ITTTextBoxColumn)AddControl(new Guid("d0b45ace-d46c-4a70-b11b-6ac37e186174"));
            TabPageSpecialProcedure = (ITTTabPage)AddControl(new Guid("453c9fea-7a89-4b08-bbfc-acb01c400fbb"));
            cmdNumberIncrement = (ITTButton)AddControl(new Guid("91d185b9-469f-479f-b256-ed2f98c6dc4c"));
            GridProtocolNumbers = (ITTGrid)AddControl(new Guid("02dc9bbe-9c9d-46c2-9a9d-dfd8f08d399a"));
            SubMatPrtNoString = (ITTTextBoxColumn)AddControl(new Guid("d7037810-3986-48bd-ad84-ae896612132d"));
            SpecialProcedureDefinition = (ITTListBoxColumn)AddControl(new Guid("f69ee938-8730-461c-97c2-1ba7d35ba729"));
            SubMatPrtNoSuffixNo = (ITTTextBoxColumn)AddControl(new Guid("68f9f4b6-d7f6-470e-b485-b26a041e1d04"));
            IsApplied = (ITTCheckBoxColumn)AddControl(new Guid("d5b10121-8d90-47b4-b6b4-73ee3cab0366"));
            AddSpecial = (ITTButtonColumn)AddControl(new Guid("90997e01-64b8-49b4-822c-cd53c646ce0d"));
            Print = (ITTButtonColumn)AddControl(new Guid("b2c83fde-14cc-47a9-8c4a-dfd18de42dd0"));
            btnPrintLabel = (ITTButton)AddControl(new Guid("d2bdc417-314e-47a3-b2e7-77c4273854fc"));
            ttBarcodePreviewCheck = (ITTCheckBox)AddControl(new Guid("f1637bbc-7fca-4d8b-9992-d019732bd7e7"));
            ttPrintRequestBarcode = (ITTButton)AddControl(new Guid("d0ee755a-1d84-4b37-8344-afdfca0b0cab"));
            base.InitializeControls();
        }

        public PathologyTestProcedureForm() : base("PATHOLOGY", "PathologyTestProcedureForm")
        {
        }

        protected PathologyTestProcedureForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}