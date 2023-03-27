
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
    /// Otopsi Raporu
    /// </summary>
    public partial class AutopsyReportForm : EpisodeActionForm
    {
    /// <summary>
    /// Otopsi Raporunın Yazıldığı Nesnedir
    /// </summary>
        protected TTObjectClasses.AutopsyReport _AutopsyReport
        {
            get { return (TTObjectClasses.AutopsyReport)_ttObject; }
        }

        protected ITTRichTextBoxControl Report;
        protected ITTLabel LabelRequestDate;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelJudicialNo;
        protected ITTLabel labelJudicialDate;
        protected ITTDateTimePicker DocumentDate;
        protected ITTLabel labelSenderChair;
        protected ITTObjectListBox SenderChair;
        protected ITTTextBox DocumetNumber;
        protected ITTTextBox ProtocolNo;
        protected ITTTextBox ReportNo;
        protected ITTLabel labelReportNo;
        protected ITTLabel labelProtocolNo;
        override protected void InitializeControls()
        {
            Report = (ITTRichTextBoxControl)AddControl(new Guid("5c8c2cb3-3344-4e50-abf9-9b9782d651fd"));
            LabelRequestDate = (ITTLabel)AddControl(new Guid("fee421bb-674d-41a2-9537-bdd349f7308f"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("01dcee7d-9571-40fa-b975-55f16ceba78e"));
            labelJudicialNo = (ITTLabel)AddControl(new Guid("a04527c8-987a-40bd-a81f-05b7e7e0c3be"));
            labelJudicialDate = (ITTLabel)AddControl(new Guid("11bcff50-e8a2-479b-b05d-139bddffc015"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("d312d916-4ee4-4fd2-befd-2eba777851b4"));
            labelSenderChair = (ITTLabel)AddControl(new Guid("b2db80f3-7aee-49a4-84f1-55bf0466be93"));
            SenderChair = (ITTObjectListBox)AddControl(new Guid("211d8e00-477d-4e7d-960e-5ec32ab3fdc5"));
            DocumetNumber = (ITTTextBox)AddControl(new Guid("35fb5319-3fdf-4359-ab96-61fc1c0b117f"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("03fd80d5-fee6-4cc3-85a1-91988d0d72cb"));
            ReportNo = (ITTTextBox)AddControl(new Guid("ba3f2eb0-6daa-4baa-b213-a2aca4bdd87f"));
            labelReportNo = (ITTLabel)AddControl(new Guid("cc12cabb-7b27-4460-9087-9edee065a90f"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("e8611eef-71ec-40da-9065-e419bf6aae87"));
            base.InitializeControls();
        }

        public AutopsyReportForm() : base("AUTOPSYREPORT", "AutopsyReportForm")
        {
        }

        protected AutopsyReportForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}