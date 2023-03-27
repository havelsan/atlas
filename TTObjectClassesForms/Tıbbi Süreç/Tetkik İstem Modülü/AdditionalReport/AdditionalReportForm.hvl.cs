
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
    public partial class AdditionalReportForm : BaseAdditionalInfoForm
    {
    /// <summary>
    /// İşlem Raporu
    /// </summary>
        protected TTObjectClasses.AdditionalReport _AdditionalReport
        {
            get { return (TTObjectClasses.AdditionalReport)_ttObject; }
        }

        protected ITTLabel labelCreationDate;
        protected ITTDateTimePicker CreationDate;
        protected ITTLabel labelReport;
        protected ITTRichTextBoxControl Report;
        protected ITTCheckBox IsCompleted;
        override protected void InitializeControls()
        {
            labelCreationDate = (ITTLabel)AddControl(new Guid("865ab7f9-7489-4535-84c3-28101c2adff0"));
            CreationDate = (ITTDateTimePicker)AddControl(new Guid("3b48dd83-b71d-4920-a28d-ac5ccc951fd2"));
            labelReport = (ITTLabel)AddControl(new Guid("8d0750c0-c794-423b-ad0b-2e9079eab70c"));
            Report = (ITTRichTextBoxControl)AddControl(new Guid("16098885-2f6d-4c97-9ab4-c339ff3ed32e"));
            IsCompleted = (ITTCheckBox)AddControl(new Guid("8a37ff51-6e38-4a0e-8c47-f2c519b327e6"));
            base.InitializeControls();
        }

        public AdditionalReportForm() : base("ADDITIONALREPORT", "AdditionalReportForm")
        {
        }

        protected AdditionalReportForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}