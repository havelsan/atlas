
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
    public partial class ExternalReportTypeForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.ExternalReportTypeDefinition _ExternalReportTypeDefinition
        {
            get { return (TTObjectClasses.ExternalReportTypeDefinition)_ttObject; }
        }

        protected ITTLabel labelReportType;
        protected ITTTextBox ReportType;
        override protected void InitializeControls()
        {
            labelReportType = (ITTLabel)AddControl(new Guid("9d28e07c-6ecd-4d55-9957-55d12a825e5e"));
            ReportType = (ITTTextBox)AddControl(new Guid("e0049f69-9260-42c0-97af-862ae0a158b9"));
            base.InitializeControls();
        }

        public ExternalReportTypeForm() : base("EXTERNALREPORTTYPEDEFINITION", "ExternalReportTypeForm")
        {
        }

        protected ExternalReportTypeForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}