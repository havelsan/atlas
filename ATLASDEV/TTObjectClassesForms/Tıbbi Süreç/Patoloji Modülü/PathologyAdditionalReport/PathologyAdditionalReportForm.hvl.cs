
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
    public partial class PathologyAdditionalReportForm : TTForm
    {
    /// <summary>
    /// Patoloji Ek Rapor
    /// </summary>
        protected TTObjectClasses.PathologyAdditionalReport _PathologyAdditionalReport
        {
            get { return (TTObjectClasses.PathologyAdditionalReport)_ttObject; }
        }

        protected ITTLabel labelAdditionalReport;
        protected ITTRichTextBoxControl AdditionalReport;
        protected ITTLabel labelReportDate;
        protected ITTDateTimePicker ReportDate;
        protected ITTLabel labelApproveDate;
        protected ITTDateTimePicker ApproveDate;
        override protected void InitializeControls()
        {
            labelAdditionalReport = (ITTLabel)AddControl(new Guid("8dc5ec2b-e81d-409e-9990-184888916b5e"));
            AdditionalReport = (ITTRichTextBoxControl)AddControl(new Guid("9d4dd3b3-c5ce-4dd2-9a01-594428a3e1f1"));
            labelReportDate = (ITTLabel)AddControl(new Guid("3854162d-cee3-49ff-a4f1-0eda5700cf1d"));
            ReportDate = (ITTDateTimePicker)AddControl(new Guid("d4c734b2-96be-4d76-9774-161844c69f38"));
            labelApproveDate = (ITTLabel)AddControl(new Guid("cca89668-243f-4b07-ae07-7789925158a8"));
            ApproveDate = (ITTDateTimePicker)AddControl(new Guid("68df5f52-9450-4aa1-a5d3-892a42ce207f"));
            base.InitializeControls();
        }

        public PathologyAdditionalReportForm() : base("PATHOLOGYADDITIONALREPORT", "PathologyAdditionalReportForm")
        {
        }

        protected PathologyAdditionalReportForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}