
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
    /// Diğer Raporlar
    /// </summary>
    public partial class OtherReportsCancelledForm : EpisodeActionForm
    {
    /// <summary>
    /// Diğer Raporlar
    /// </summary>
        protected TTObjectClasses.OtherReports _OtherReports
        {
            get { return (TTObjectClasses.OtherReports)_ttObject; }
        }

        protected ITTLabel labelDocumentNumber;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTLabel labelRequestDate;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelReportNo;
        protected ITTTextBox ReportNo;
        protected ITTLabel labelProtocolNo;
        protected ITTTextBox ProtocolNo;
        protected ITTTextBox DocumentNumber;
        protected ITTLabel labelDocumentDate;
        protected ITTDateTimePicker DocumentDate;
        override protected void InitializeControls()
        {
            labelDocumentNumber = (ITTLabel)AddControl(new Guid("cb82e222-cf2e-4b34-ae73-0b924c65d1f5"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("4a659eed-b0d6-4a22-9add-9e5c22614130"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("40a7881e-7f1a-4dac-9fd7-4f2533b2cf6f"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("aa02761f-7fd3-435b-af67-3979ff8941bf"));
            labelReportNo = (ITTLabel)AddControl(new Guid("a20d94ab-3b90-4986-a224-eb63797c5cf3"));
            ReportNo = (ITTTextBox)AddControl(new Guid("17279fe9-ce7e-41f1-869d-7c8237bcf422"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("ed325114-b5af-4ebf-94e9-dfa274ca95d2"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("a273651c-6c05-46c0-bbc6-adcb0c6069d4"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("bec02d71-a434-4f0a-9451-90a0e6ac7014"));
            labelDocumentDate = (ITTLabel)AddControl(new Guid("878cbbcd-14ef-4ada-8f78-c881d4442c27"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("85cb4ed9-c414-4702-a083-d960b34ab9c7"));
            base.InitializeControls();
        }

        public OtherReportsCancelledForm() : base("OTHERREPORTS", "OtherReportsCancelledForm")
        {
        }

        protected OtherReportsCancelledForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}