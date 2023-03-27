
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
    public partial class ReportForm : TTForm
    {
    /// <summary>
    /// Temel Yazışma
    /// </summary>
        protected TTObjectClasses.BaseCorrespondence _BaseCorrespondence
        {
            get { return (TTObjectClasses.BaseCorrespondence)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTTextBox tttextbox2;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel2;
        protected ITTTextBox tttextbox1;
        protected ITTRichTextBoxControl ttrichtextboxcontrol2;
        protected ITTRichTextBoxControl ttrichtextboxcontrol3;
        protected ITTRichTextBoxControl ttrichtextboxcontrol4;
        protected ITTTabPage tttabpage2;
        protected ITTLabel ttlabel1;
        protected ITTTextBox DocumentDate;
        protected ITTGrid DistributionPlacesGrid;
        protected ITTTextBoxColumn DistributionLine;
        protected ITTGrid InfosGrid;
        protected ITTTextBoxColumn InfoLine;
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
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("def63d96-6907-4a06-a689-669053a773e6"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("6283c391-788f-4e61-841a-09d9186eed89"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("611ad291-5777-4789-80cf-8909f60999ad"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("e616526b-16d3-4aab-b50f-bafb6265b966"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("a3f049be-080b-48a2-9f59-4cb6da0166f6"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("7ffd8d5a-b186-4458-9daa-b9b95c496da9"));
            ttrichtextboxcontrol2 = (ITTRichTextBoxControl)AddControl(new Guid("3dcb7cd4-1ba2-452e-a064-16de3d805387"));
            ttrichtextboxcontrol3 = (ITTRichTextBoxControl)AddControl(new Guid("1f237f71-855e-4b14-a6fb-d4c8e40c1d47"));
            ttrichtextboxcontrol4 = (ITTRichTextBoxControl)AddControl(new Guid("a69d7974-f9aa-4ec5-a883-d6464656c162"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("a6f5c1ce-68eb-45e2-98d5-c0b37d6201d3"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("dd11d5b0-8508-4bb6-b509-8e9bd95640e4"));
            DocumentDate = (ITTTextBox)AddControl(new Guid("41680a3e-6946-4065-9a78-d208d1a28902"));
            DistributionPlacesGrid = (ITTGrid)AddControl(new Guid("93e3fe42-3ae5-463b-9f60-9eb75768e142"));
            DistributionLine = (ITTTextBoxColumn)AddControl(new Guid("5f7ff222-260d-429e-99fb-bcc6adcb2bfb"));
            InfosGrid = (ITTGrid)AddControl(new Guid("899dc8ab-35f6-4202-8c52-3bfa7dd066fb"));
            InfoLine = (ITTTextBoxColumn)AddControl(new Guid("a9b3851c-374f-4fb9-a8cc-83caad03da7d"));
            labelDocumentDate = (ITTLabel)AddControl(new Guid("732afee4-482a-4f1d-94ca-8e1b49c59bd2"));
            ttenumcombobox1 = (ITTEnumComboBox)AddControl(new Guid("6802124a-3042-46b8-be7e-58de7bc89322"));
            labelReportSender = (ITTLabel)AddControl(new Guid("630683b7-895a-48a7-bd95-724ee89bb4af"));
            ParaphsGrid = (ITTGrid)AddControl(new Guid("cf80c7d3-301f-401b-b4e4-e9357b47c31e"));
            ParaphLine = (ITTTextBoxColumn)AddControl(new Guid("d7193321-76ce-4234-80c1-cee86c0407f9"));
            ReportSender = (ITTObjectListBox)AddControl(new Guid("15ddb1cf-9908-4686-9d47-830fd1a5bb95"));
            NumberLiteral = (ITTTextBox)AddControl(new Guid("e175f1b9-3408-4dc4-93df-2dec6a1c8f9c"));
            labelNumberLiteral = (ITTLabel)AddControl(new Guid("6c8bf71b-a6de-4fdb-a289-1d6188b11e1d"));
            Number = (ITTTextBox)AddControl(new Guid("564fdc81-8be0-4f67-8ab6-487e0296ac3f"));
            labelNumber = (ITTLabel)AddControl(new Guid("e8ed9279-9702-4df1-8354-217be1420102"));
            Description = (ITTTextBox)AddControl(new Guid("27c52775-e64b-4cce-b9c2-39129fbed075"));
            labelDescription = (ITTLabel)AddControl(new Guid("b14f7bf4-27dc-466e-87a0-d3d8959aa338"));
            base.InitializeControls();
        }

        public ReportForm() : base("BASECORRESPONDENCE", "ReportForm")
        {
        }

        protected ReportForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}