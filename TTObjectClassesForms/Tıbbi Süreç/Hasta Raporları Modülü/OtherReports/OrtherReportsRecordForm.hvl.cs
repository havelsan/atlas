
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
    public partial class OrtherReportsRecordForm : EpisodeActionForm
    {
    /// <summary>
    /// Diğer Raporlar
    /// </summary>
        protected TTObjectClasses.OtherReports _OtherReports
        {
            get { return (TTObjectClasses.OtherReports)_ttObject; }
        }

        protected ITTRichTextBoxControl Report;
        protected ITTLabel labelRequestDate;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelReportNo;
        protected ITTTextBox ReportNo;
        protected ITTTextBox ProtocolNo;
        protected ITTTextBox DocumentNumber;
        protected ITTLabel labelProtocolNo;
        protected ITTLabel labelDocumentNumber;
        protected ITTLabel labelDocumentDate;
        protected ITTDateTimePicker DocumentDate;
        override protected void InitializeControls()
        {
            Report = (ITTRichTextBoxControl)AddControl(new Guid("82c9603b-f197-445d-a307-18febc8ec019"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("294b6c8a-b080-4588-8510-2282ca286eb2"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("abd18f38-ba89-4548-9a82-1c882b13211b"));
            labelReportNo = (ITTLabel)AddControl(new Guid("e6e17b5d-e3e5-4ce5-a073-f970f6ed534b"));
            ReportNo = (ITTTextBox)AddControl(new Guid("62acd844-0063-41a2-8ea2-b0692ee0cb22"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("33e339a1-366a-4c9f-b372-4c84f4c57280"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("245e630b-fa72-46f5-b231-bb0dcc471e8c"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("3d696ab7-2f82-41e3-8cdb-9c22f666f330"));
            labelDocumentNumber = (ITTLabel)AddControl(new Guid("7b24c857-0277-4c51-996f-a33bb74b29dc"));
            labelDocumentDate = (ITTLabel)AddControl(new Guid("7c986c1a-1cf8-46f3-be3d-68d1d3540118"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("207f5c13-960c-4c59-b7bc-af997a1979a9"));
            base.InitializeControls();
        }

        public OrtherReportsRecordForm() : base("OTHERREPORTS", "OrtherReportsRecordForm")
        {
        }

        protected OrtherReportsRecordForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}