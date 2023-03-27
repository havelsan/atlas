
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
    public partial class CreatingEpicrisisForm : EpisodeActionForm
    {
    /// <summary>
    /// Epikriz Oluşturma  İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.CreatingEpicrisis _CreatingEpicrisis
        {
            get { return (TTObjectClasses.CreatingEpicrisis)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage page1;
        protected ITTRichTextBoxControl Report;
        protected ITTTabPage page2;
        protected ITTRichTextBoxControl ttrichtextboxcontrol2;
        protected ITTTabPage page3;
        protected ITTRichTextBoxControl ttrichtextboxcontrol3;
        protected ITTTabPage page4;
        protected ITTRichTextBoxControl ttrichtextboxcontrol4;
        protected ITTTabPage page5;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTTextBox ReportNo;
        protected ITTLabel LabelRequestDate;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelReportNo;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("82878c6e-669e-47da-b422-3ca5dd6c16b3"));
            page1 = (ITTTabPage)AddControl(new Guid("f826a417-2079-4a29-9be1-0fbd6ebf1903"));
            Report = (ITTRichTextBoxControl)AddControl(new Guid("4d3eb205-75d8-4cfe-81db-08c7f0560fa4"));
            page2 = (ITTTabPage)AddControl(new Guid("9908a0ca-c4ea-478f-b39d-ab35b7bbf789"));
            ttrichtextboxcontrol2 = (ITTRichTextBoxControl)AddControl(new Guid("a32e5f8d-8ccf-4ae7-bd21-91b80c416b86"));
            page3 = (ITTTabPage)AddControl(new Guid("0e98795b-3444-4a65-820b-adbd09977e18"));
            ttrichtextboxcontrol3 = (ITTRichTextBoxControl)AddControl(new Guid("abcdcf88-0cd0-40b9-94da-670ff1026e97"));
            page4 = (ITTTabPage)AddControl(new Guid("0c123e46-2d33-493d-939f-b69975313cdc"));
            ttrichtextboxcontrol4 = (ITTRichTextBoxControl)AddControl(new Guid("8567151a-9a99-418f-aab5-f0a3b0b02b77"));
            page5 = (ITTTabPage)AddControl(new Guid("abc838e8-ae1f-4b9b-9eed-11efa99d48da"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("bc4e6e18-8f48-470d-9e69-2921a72c5a17"));
            ReportNo = (ITTTextBox)AddControl(new Guid("f14e49a3-6e48-4458-8cad-7528108449b6"));
            LabelRequestDate = (ITTLabel)AddControl(new Guid("8e2acb69-649b-44a1-898e-c9617af6963f"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("0874d55a-1599-4a52-8741-276073bcf822"));
            labelReportNo = (ITTLabel)AddControl(new Guid("6ceebd08-3c1b-47b3-acd0-4ad6fe915b69"));
            base.InitializeControls();
        }

        public CreatingEpicrisisForm() : base("CREATINGEPICRISIS", "CreatingEpicrisisForm")
        {
        }

        protected CreatingEpicrisisForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}