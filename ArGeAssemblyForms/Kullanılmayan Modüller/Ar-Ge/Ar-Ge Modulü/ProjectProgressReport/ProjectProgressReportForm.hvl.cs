
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
    public partial class ProjectProgressReportForm : TTForm
    {
        protected TTObjectClasses.ProjectProgressReport _ProjectProgressReport
        {
            get { return (TTObjectClasses.ProjectProgressReport)_ttObject; }
        }

        protected ITTTextBox ReportText;
        protected ITTTextBox ReportNo;
        protected ITTLabel labelReportText;
        protected ITTLabel labelReportNo;
        protected ITTLabel labelReportDate;
        protected ITTDateTimePicker ReportDate;
        override protected void InitializeControls()
        {
            ReportText = (ITTTextBox)AddControl(new Guid("61a6daeb-09c3-48ca-a917-109f475df495"));
            ReportNo = (ITTTextBox)AddControl(new Guid("648373b1-8e69-463d-bf0b-a87a7cac7ccf"));
            labelReportText = (ITTLabel)AddControl(new Guid("5265c36e-94d8-432a-8f15-316de41e9adc"));
            labelReportNo = (ITTLabel)AddControl(new Guid("6350ffa2-dd0c-4bfe-a1c6-3227520bcd6c"));
            labelReportDate = (ITTLabel)AddControl(new Guid("802ba00d-ea67-4d06-8853-d33322c91662"));
            ReportDate = (ITTDateTimePicker)AddControl(new Guid("0d33c5c0-ed85-4903-84c5-22a9a8141474"));
            base.InitializeControls();
        }

        public ProjectProgressReportForm() : base("PROJECTPROGRESSREPORT", "ProjectProgressReportForm")
        {
        }

        protected ProjectProgressReportForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}