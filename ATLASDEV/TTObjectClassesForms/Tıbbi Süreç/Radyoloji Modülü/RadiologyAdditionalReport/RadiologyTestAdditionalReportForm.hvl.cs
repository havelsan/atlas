
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
    public partial class RadiologyTestAdditionalReportForm : TTForm
    {
    /// <summary>
    /// Radyoloji Test Ek Rapor
    /// </summary>
        protected TTObjectClasses.RadiologyAdditionalReport _RadiologyAdditionalReport
        {
            get { return (TTObjectClasses.RadiologyAdditionalReport)_ttObject; }
        }

        protected ITTLabel labelAdditionalResults;
        protected ITTRichTextBoxControl AdditionalResults;
        protected ITTLabel labelReportDate;
        protected ITTDateTimePicker ReportDate;
        protected ITTLabel labelAdditionalReport;
        protected ITTRichTextBoxControl AdditionalReport;
        override protected void InitializeControls()
        {
            labelAdditionalResults = (ITTLabel)AddControl(new Guid("57f71926-c953-47f0-bf13-44408f11e165"));
            AdditionalResults = (ITTRichTextBoxControl)AddControl(new Guid("0834ec6d-39ed-44ac-8dc0-5f46e2087826"));
            labelReportDate = (ITTLabel)AddControl(new Guid("c1476318-d81e-4c12-ae7d-263bc28f1b4c"));
            ReportDate = (ITTDateTimePicker)AddControl(new Guid("4b77ff67-24e8-448d-8365-5a3210869765"));
            labelAdditionalReport = (ITTLabel)AddControl(new Guid("b97e08dd-4ea7-4495-9eb9-073d2e97b3ba"));
            AdditionalReport = (ITTRichTextBoxControl)AddControl(new Guid("051cf9cb-2251-4a01-9458-10a078acc629"));
            base.InitializeControls();
        }

        public RadiologyTestAdditionalReportForm() : base("RADIOLOGYADDITIONALREPORT", "RadiologyTestAdditionalReportForm")
        {
        }

        protected RadiologyTestAdditionalReportForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}