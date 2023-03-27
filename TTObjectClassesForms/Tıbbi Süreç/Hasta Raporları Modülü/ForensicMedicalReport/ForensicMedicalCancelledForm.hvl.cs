
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
    /// Adli Tıp Raporları
    /// </summary>
    public partial class ForensicMedicalCancelledForm : EpisodeActionForm
    {
    /// <summary>
    /// Adli Tıp Raporlarının Girişinin Yapıldığı Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.ForensicMedicalReport _ForensicMedicalReport
        {
            get { return (TTObjectClasses.ForensicMedicalReport)_ttObject; }
        }

        protected ITTTextBox ReasonOfCancel;
        protected ITTTextBox ProtocolNo;
        protected ITTTextBox DocumentNumber;
        protected ITTTextBox ReportNo;
        protected ITTRichTextBoxControl Report;
        protected ITTLabel labelFormalPaper;
        protected ITTLabel LabelRequestDate;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelProtocolNo;
        protected ITTLabel labelJudicialNo;
        protected ITTLabel labelJudicialDate;
        protected ITTLabel labelReportNo;
        protected ITTDateTimePicker DocumetDate;
        protected ITTObjectListBox SenderChair;
        protected ITTLabel labelSenderChair;
        override protected void InitializeControls()
        {
            ReasonOfCancel = (ITTTextBox)AddControl(new Guid("f07edc78-8fac-4246-8c71-8775749cbdd5"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("5fe1225e-c0db-4e8d-ac29-8264f31e8226"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("cc286d95-928c-46eb-b27a-7affed0c0e96"));
            ReportNo = (ITTTextBox)AddControl(new Guid("0a353cf9-a6bb-4f5d-8f28-ea3e98a8dd16"));
            Report = (ITTRichTextBoxControl)AddControl(new Guid("288c1809-bfb0-43aa-8e28-c375d3a3e639"));
            labelFormalPaper = (ITTLabel)AddControl(new Guid("c724ea8e-d433-4b8c-81b0-be62f26a483b"));
            LabelRequestDate = (ITTLabel)AddControl(new Guid("d15647cc-75d4-4c13-927a-091f0cee0b26"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("f4f7f581-5da6-4a46-b272-891e69262907"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("fbbe4d60-1639-4ffd-9434-578f641f6557"));
            labelJudicialNo = (ITTLabel)AddControl(new Guid("978c93cb-cbed-4701-94d0-cc630f66b7e6"));
            labelJudicialDate = (ITTLabel)AddControl(new Guid("771b0f5b-dd31-46fa-b7b3-1a440207dd64"));
            labelReportNo = (ITTLabel)AddControl(new Guid("075635d5-4eeb-4e84-be61-fa56fbce9304"));
            DocumetDate = (ITTDateTimePicker)AddControl(new Guid("50764b86-a55b-49df-94c5-6f4dee6c6dfe"));
            SenderChair = (ITTObjectListBox)AddControl(new Guid("7e1a1a2e-92db-45e8-8562-7bca13fcd5e4"));
            labelSenderChair = (ITTLabel)AddControl(new Guid("1089e466-223d-4e3b-b463-b70264568178"));
            base.InitializeControls();
        }

        public ForensicMedicalCancelledForm() : base("FORENSICMEDICALREPORT", "ForensicMedicalCancelledForm")
        {
        }

        protected ForensicMedicalCancelledForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}