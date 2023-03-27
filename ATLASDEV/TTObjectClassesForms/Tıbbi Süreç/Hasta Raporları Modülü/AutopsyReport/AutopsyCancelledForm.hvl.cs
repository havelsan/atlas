
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
    public partial class AutopsyCancelledForm : EpisodeActionForm
    {
    /// <summary>
    /// Otopsi Raporunın Yazıldığı Nesnedir
    /// </summary>
        protected TTObjectClasses.AutopsyReport _AutopsyReport
        {
            get { return (TTObjectClasses.AutopsyReport)_ttObject; }
        }

        protected ITTLabel LabelRequestDate;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelJudicialNo;
        protected ITTLabel labelJudicialDate;
        protected ITTDateTimePicker DocumentDate;
        protected ITTTextBox Report;
        protected ITTTextBox DocumetNumber;
        protected ITTTextBox ProtocolNo;
        protected ITTTextBox ReportNo;
        protected ITTLabel labelSenderChair;
        protected ITTObjectListBox SenderChair;
        protected ITTLabel labelReport;
        protected ITTLabel labelReportNo;
        protected ITTLabel labelProtocolNo;
        override protected void InitializeControls()
        {
            LabelRequestDate = (ITTLabel)AddControl(new Guid("b693bdca-7a77-4395-a5e0-d95981961ade"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("b3571777-c13f-4703-97c9-f5dba3bc5503"));
            labelJudicialNo = (ITTLabel)AddControl(new Guid("485e630f-707e-46ed-8306-8ca175dc08dc"));
            labelJudicialDate = (ITTLabel)AddControl(new Guid("058d72a2-54a7-4030-8c03-aa343c96501c"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("5bbe10d7-5a30-4f6e-bf62-7d58642e2eca"));
            Report = (ITTTextBox)AddControl(new Guid("69ccc19b-a864-4577-b4bd-098c0f2e7300"));
            DocumetNumber = (ITTTextBox)AddControl(new Guid("b8e2f9a8-adcf-493a-b60a-15b2c300b4ad"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("b67fc481-dc5e-4e28-8232-b30365266035"));
            ReportNo = (ITTTextBox)AddControl(new Guid("baeaf8ee-ce9f-4596-aad7-8a4f6cd7c273"));
            labelSenderChair = (ITTLabel)AddControl(new Guid("398b7de1-79e4-4da7-b15e-2308f7ee6488"));
            SenderChair = (ITTObjectListBox)AddControl(new Guid("8725b019-1688-4bc6-b461-fdaaae80fec0"));
            labelReport = (ITTLabel)AddControl(new Guid("7433d126-0b5c-4ba3-80b9-0e6923fc7ffb"));
            labelReportNo = (ITTLabel)AddControl(new Guid("896c6d6c-2d46-41d5-8f15-8c2f151c91df"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("f1a0359c-d29c-4ef2-a640-91792773022d"));
            base.InitializeControls();
        }

        public AutopsyCancelledForm() : base("AUTOPSYREPORT", "AutopsyCancelledForm")
        {
        }

        protected AutopsyCancelledForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}