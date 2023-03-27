
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
    /// Bitmiş Onarım
    /// </summary>
    public partial class CompletedForm : RepairBaseForm
    {
    /// <summary>
    /// Onarım
    /// </summary>
        protected TTObjectClasses.Repair _Repair
        {
            get { return (TTObjectClasses.Repair)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTTextBox tttextbox5;
        protected ITTTextBox tttextbox4;
        protected ITTLabel ttlabel2;
        protected ITTTextBox tttextbox1;
        protected ITTLabel ttlabel7;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel6;
        protected ITTTextBox tttextbox2;
        protected ITTTabPage tttabpage2;
        protected ITTGrid UsedConsumedMaterails;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn RequestAmount;
        protected ITTTextBoxColumn SuppliedAmount;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn UnitPrice;
        protected ITTTabPage tttabpage3;
        protected ITTGrid ItemEquipmentsGrid;
        protected ITTTextBoxColumn ItemName;
        protected ITTTextBoxColumn Amount2;
        protected ITTCheckBoxColumn IsMissing;
        protected ITTCheckBoxColumn IsChanged;
        protected ITTCheckBoxColumn IsDamaged;
        protected ITTCheckBoxColumn Normal;
        protected ITTTextBoxColumn Comments;
        protected ITTTabPage tttabpage4;
        protected ITTRichTextBoxControl TTRichTextBoxUserControl;
        protected ITTObjectListBox ttobjectlistbox2;
        protected ITTDateTimePicker StartDate;
        protected ITTObjectListBox ToResource;
        protected ITTObjectListBox FromResource;
        protected ITTLabel labelStartDate;
        protected ITTObjectListBox FixedAsset;
        protected ITTDateTimePicker RequestDate;
        protected ITTTextBox RequestNO;
        protected ITTLabel labelRequestNO;
        protected ITTLabel labelResult;
        protected ITTTextBox Result;
        protected ITTLabel labelFromResource;
        protected ITTLabel ttlabel3;
        protected ITTDateTimePicker EndDate;
        protected ITTLabel ttlabel4;
        protected ITTLabel labelToResource;
        protected ITTObjectListBox ResponsibleResource;
        protected ITTLabel labelFixedAsset;
        protected ITTTextBox tttextbox3;
        protected ITTLabel labelRequestDate;
        protected ITTLabel labelResponsibleResource;
        protected ITTLabel labelEndDate;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("9aec55b8-24d2-49d2-a963-284093fee3f3"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("e5d77904-14ea-4c10-920b-c6dcaaa9bbe3"));
            tttextbox5 = (ITTTextBox)AddControl(new Guid("2d07d3d4-d8dc-4ab5-8330-68bba422ed47"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("ccdc25c3-f2de-4a1e-b612-09b2fb6a6cc0"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("a576dd58-9cc2-44d7-bd15-9fa94024a7f2"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("40d0be88-7372-496f-87dc-4427e66b8bcb"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("78acc4b0-e4e0-4a5e-a3b5-d95b04ad8eb0"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("4757749b-e683-4cdc-8f19-186f93550a76"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("25f5eade-487a-49ba-9776-f1332de5581a"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("b4b6b997-5c67-4e2f-9949-29407323241f"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("def4ebfc-2295-4a3d-a7bd-dd0ec1d31b7f"));
            UsedConsumedMaterails = (ITTGrid)AddControl(new Guid("a5a18aba-5ed5-4f41-b9a1-579117a51a53"));
            Material = (ITTListBoxColumn)AddControl(new Guid("1a1e48ed-ff72-4cf7-8169-8eed99bbf49b"));
            RequestAmount = (ITTTextBoxColumn)AddControl(new Guid("b6d0487a-291e-4350-9399-0d629888f55a"));
            SuppliedAmount = (ITTTextBoxColumn)AddControl(new Guid("cb3f4dee-2fec-49b3-a1a7-d6302a6e8b08"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("f154307e-bfd4-409a-835f-a052b87fab78"));
            UnitPrice = (ITTTextBoxColumn)AddControl(new Guid("ca092206-8884-4b98-96ee-da336f59ba72"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("4ea4bd9e-47d4-4b25-b034-944457be0b1f"));
            ItemEquipmentsGrid = (ITTGrid)AddControl(new Guid("677023a7-948e-43e5-884a-131fd611c7b2"));
            ItemName = (ITTTextBoxColumn)AddControl(new Guid("42e12484-971b-4168-9280-e07caab0cbe2"));
            Amount2 = (ITTTextBoxColumn)AddControl(new Guid("1f08f08d-d1b4-430c-b9a3-78766330f124"));
            IsMissing = (ITTCheckBoxColumn)AddControl(new Guid("e667278b-4eec-4847-969f-5e0a1b717bff"));
            IsChanged = (ITTCheckBoxColumn)AddControl(new Guid("f8b6b02e-bcdc-4c18-af78-9b69b521129c"));
            IsDamaged = (ITTCheckBoxColumn)AddControl(new Guid("7219f6cc-e1df-44f6-846a-a3c3c0b707b1"));
            Normal = (ITTCheckBoxColumn)AddControl(new Guid("68cabb7f-f0f4-43c8-a1b4-808c1e9759f3"));
            Comments = (ITTTextBoxColumn)AddControl(new Guid("94fd8281-591e-4e3c-b9d4-61f5899d4303"));
            tttabpage4 = (ITTTabPage)AddControl(new Guid("5f08c5c1-e0de-4c0b-85c0-51d934ed113f"));
            TTRichTextBoxUserControl = (ITTRichTextBoxControl)AddControl(new Guid("55708283-8f77-41d1-b440-95e849a414d1"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("e831a934-2b72-422b-a0c7-d9d1ed118dd7"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("5d4c9c92-7f1f-4919-88c6-046651f4e281"));
            ToResource = (ITTObjectListBox)AddControl(new Guid("63ec09cb-74c8-4734-8ec6-1573260b165b"));
            FromResource = (ITTObjectListBox)AddControl(new Guid("25d2a9b1-f02c-4391-b347-4cce78658795"));
            labelStartDate = (ITTLabel)AddControl(new Guid("b5b147ea-c54c-48ec-bca2-4f1eb343059d"));
            FixedAsset = (ITTObjectListBox)AddControl(new Guid("5cfd0d2b-b966-4dfb-a76d-67da980a2d6b"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("3d94cf4f-8975-4dbd-a1ca-698842a892ed"));
            RequestNO = (ITTTextBox)AddControl(new Guid("e06a53f3-def5-4fd2-a3fb-70636e9f519c"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("b57f6c8d-b6bb-4557-9578-72e1c962ff38"));
            labelResult = (ITTLabel)AddControl(new Guid("a54ff3c0-fa06-40bb-81cd-75119fdd2bb5"));
            Result = (ITTTextBox)AddControl(new Guid("f2820287-0e81-4b52-9a5d-75bcef89ac86"));
            labelFromResource = (ITTLabel)AddControl(new Guid("5e012c0c-58be-4bf2-a5cc-941a03564b83"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("cb470f7e-924d-4abf-a5d5-9b43111a01f5"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("7cf98b4d-73ed-4511-963a-a3c8a09ceceb"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("ff5b90af-75ff-4af7-84b9-a6377cd856ab"));
            labelToResource = (ITTLabel)AddControl(new Guid("e00a05d7-f5f2-4b98-bc98-aa33c0cced6f"));
            ResponsibleResource = (ITTObjectListBox)AddControl(new Guid("3b9dd5c0-d2b0-44b6-9ebf-af5fa0e8fab0"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("292be6a8-29b1-4465-8dc8-bba34629225a"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("b901fdbd-ab67-4000-a2f2-d1dd0fde1a0f"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("95fa7fb1-f396-4c62-9aed-ed5c4c603308"));
            labelResponsibleResource = (ITTLabel)AddControl(new Guid("c012b17c-9594-453f-8dd2-ef079ccdde5a"));
            labelEndDate = (ITTLabel)AddControl(new Guid("e715b3e0-a839-4e34-8577-f5b4d6df879b"));
            base.InitializeControls();
        }

        public CompletedForm() : base("REPAIR", "CompletedForm")
        {
        }

        protected CompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}