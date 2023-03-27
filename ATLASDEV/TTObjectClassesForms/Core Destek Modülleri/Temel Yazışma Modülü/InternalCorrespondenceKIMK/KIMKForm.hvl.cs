
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
    /// Yazı Bilgileri
    /// </summary>
    public partial class KIMKForm : TTForm
    {
    /// <summary>
    /// Karargah İçi Mütalaa
    /// </summary>
        protected TTObjectClasses.InternalCorrespondenceKIMK _InternalCorrespondenceKIMK
        {
            get { return (TTObjectClasses.InternalCorrespondenceKIMK)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTTextBox tttextbox2;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel2;
        protected ITTTextBox tttextbox1;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTRichTextBoxControl ttrichtextboxcontrol2;
        protected ITTRichTextBoxControl ttrichtextboxcontrol3;
        protected ITTTabPage tttabpage2;
        protected ITTTextBox tttextbox5;
        protected ITTLabel ttlabel6;
        protected ITTTextBox tttextbox4;
        protected ITTLabel ttlabel5;
        protected ITTTextBox tttextbox3;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel1;
        protected ITTTextBox DocumentDate;
        protected ITTLabel labelDocumentDate;
        protected ITTEnumComboBox ttenumcombobox1;
        protected ITTLabel labelReportSender;
        protected ITTGrid ParaphsGrid;
        protected ITTTextBoxColumn ParaphLine;
        protected ITTObjectListBox ReportSender;
        protected ITTTextBox NumberLiteral;
        protected ITTLabel labelNumberLiteral;
        protected ITTTextBox Number;
        protected ITTLabel labelNumber;
        protected ITTTextBox Description;
        protected ITTLabel labelDescription;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("b7aaba15-5c61-4cba-b235-98f14bd9ce7b"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("386d05df-c377-4532-8f92-b092cac309ee"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("9dfff216-1250-407f-ad88-0ff325dda936"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("2fc63097-e560-460d-bb15-cdbcf907a750"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("3bb4c299-a8a0-48d6-82b2-0d2c5f8237eb"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("8c387a66-55a9-45e8-be3a-ee42b4e5156d"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("9bae2554-a190-4631-a2f7-cf8351957d28"));
            ttrichtextboxcontrol2 = (ITTRichTextBoxControl)AddControl(new Guid("c89b61e9-d330-4bb9-a0a0-867f918c7d31"));
            ttrichtextboxcontrol3 = (ITTRichTextBoxControl)AddControl(new Guid("16268cb0-b200-4aca-9b61-4249e85b1611"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("6c742094-6af8-48ed-9dc9-d9d895a04325"));
            tttextbox5 = (ITTTextBox)AddControl(new Guid("5a68ed2d-d3ff-4a8c-be61-a2bc4cc37b7d"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("d6cfdee2-b1c2-44a7-9ce0-6e9e5c14c300"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("8bfedaf7-c592-4612-9b7b-3e5b16c86211"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("267af289-bcb7-455f-8167-7b145c7be6b8"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("1b3fb102-ea2c-47f9-9265-14766d13f251"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("c9ace418-e0c5-4c81-bf0f-567e01de2b1c"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("ed026685-83e0-4f37-9b21-7490e8145bc8"));
            DocumentDate = (ITTTextBox)AddControl(new Guid("304f0f19-84de-4d66-9a91-af0dae6ee202"));
            labelDocumentDate = (ITTLabel)AddControl(new Guid("752b7796-9074-4108-b58c-c1e19f770339"));
            ttenumcombobox1 = (ITTEnumComboBox)AddControl(new Guid("4238b38c-6bc5-4c73-81dd-ac6532587f64"));
            labelReportSender = (ITTLabel)AddControl(new Guid("f24134a7-d17a-4334-9bad-195062ec6a6d"));
            ParaphsGrid = (ITTGrid)AddControl(new Guid("37e30f17-71eb-45b3-97fe-119a919a0c4b"));
            ParaphLine = (ITTTextBoxColumn)AddControl(new Guid("3b55eed1-855c-4fb6-9351-7df8f1b1db2f"));
            ReportSender = (ITTObjectListBox)AddControl(new Guid("40f47a36-26a1-4ce7-84df-8b1c93d04222"));
            NumberLiteral = (ITTTextBox)AddControl(new Guid("bcaa86e8-d6c0-4fdf-92ab-36ae160317ae"));
            labelNumberLiteral = (ITTLabel)AddControl(new Guid("8b072649-a478-4fe7-9ce5-059cdebfb9fb"));
            Number = (ITTTextBox)AddControl(new Guid("72bae438-5306-475e-b19f-8688fd85f29e"));
            labelNumber = (ITTLabel)AddControl(new Guid("e4660e7f-996f-43b6-85c5-2ff64ac38f52"));
            Description = (ITTTextBox)AddControl(new Guid("1ca04931-6843-4f83-813f-fc60d9cd2c72"));
            labelDescription = (ITTLabel)AddControl(new Guid("3df47765-b1c0-4992-af86-41b29317a5d4"));
            base.InitializeControls();
        }

        public KIMKForm() : base("INTERNALCORRESPONDENCEKIMK", "KIMKForm")
        {
        }

        protected KIMKForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}