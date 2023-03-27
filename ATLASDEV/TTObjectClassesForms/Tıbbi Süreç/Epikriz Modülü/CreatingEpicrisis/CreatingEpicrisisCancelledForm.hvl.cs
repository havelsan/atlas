
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
    /// Epikriz Oluşturma
    /// </summary>
    public partial class CreatingEpicrisisCancelledForm : EpisodeActionForm
    {
    /// <summary>
    /// Epikriz Oluşturma  İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.CreatingEpicrisis _CreatingEpicrisis
        {
            get { return (TTObjectClasses.CreatingEpicrisis)_ttObject; }
        }

        protected ITTTextBox Report;
        protected ITTLabel labelReport;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage page1;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTTabPage page2;
        protected ITTRichTextBoxControl ttrichtextboxcontrol2;
        protected ITTTabPage page3;
        protected ITTRichTextBoxControl ttrichtextboxcontrol3;
        protected ITTTabPage page4;
        protected ITTRichTextBoxControl ttrichtextboxcontrol4;
        protected ITTTabPage page5;
        protected ITTRichTextBoxControl ttrichtextboxcontrol5;
        protected ITTTextBox ReportNo;
        protected ITTLabel LabelRequestDate;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelReportNo;
        override protected void InitializeControls()
        {
            Report = (ITTTextBox)AddControl(new Guid("5144f311-effa-448f-bb08-958e980efeff"));
            labelReport = (ITTLabel)AddControl(new Guid("97480432-8fd3-4cc8-aa3b-bb9e7c34697c"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("f324ccba-7790-4f27-9b7b-ddcc5d91c1aa"));
            page1 = (ITTTabPage)AddControl(new Guid("89ad1897-d195-4b9e-ab29-c63da1274b8e"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("ef5b2e06-669a-4dc0-99c9-57a70cfe7fd9"));
            page2 = (ITTTabPage)AddControl(new Guid("ced90071-1914-4f94-8dd1-b59f705f593e"));
            ttrichtextboxcontrol2 = (ITTRichTextBoxControl)AddControl(new Guid("56908d6a-bce1-487b-acd3-e118c05f9df7"));
            page3 = (ITTTabPage)AddControl(new Guid("8600de90-a9c9-441b-9d79-45279d758696"));
            ttrichtextboxcontrol3 = (ITTRichTextBoxControl)AddControl(new Guid("9e17a936-b6dc-4c56-a2b2-e9b52ee844f3"));
            page4 = (ITTTabPage)AddControl(new Guid("6d4d4db4-30a8-446d-9e39-85ecfc0ab73a"));
            ttrichtextboxcontrol4 = (ITTRichTextBoxControl)AddControl(new Guid("8cdc8384-fed3-4c99-8ca2-f501459a99aa"));
            page5 = (ITTTabPage)AddControl(new Guid("9aa4f263-a798-46d8-a1b8-3bffcecf40c4"));
            ttrichtextboxcontrol5 = (ITTRichTextBoxControl)AddControl(new Guid("c74c5b39-c65c-49eb-bf5e-7c9349a84796"));
            ReportNo = (ITTTextBox)AddControl(new Guid("15e77189-7c26-4211-ade2-427a8ba676a9"));
            LabelRequestDate = (ITTLabel)AddControl(new Guid("8d5ae473-cc68-4bf2-ac3c-a880055305d2"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("3f71b580-b918-4362-9980-6171754724e8"));
            labelReportNo = (ITTLabel)AddControl(new Guid("70da0cf5-d7c0-455f-918f-cc8aef43e5fe"));
            base.InitializeControls();
        }

        public CreatingEpicrisisCancelledForm() : base("CREATINGEPICRISIS", "CreatingEpicrisisCancelledForm")
        {
        }

        protected CreatingEpicrisisCancelledForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}