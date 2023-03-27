
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
    /// Rapor Teşhis Listesi
    /// </summary>
    public partial class ReportDiagnosticListForm : ScheduledTaskBaseForm
    {
    /// <summary>
    /// Rapor Teşhis Listesi
    /// </summary>
        protected TTObjectClasses.ReportDiagnosticList _ReportDiagnosticList
        {
            get { return (TTObjectClasses.ReportDiagnosticList)_ttObject; }
        }

        protected ITTTextBox FilePath;
        protected ITTButton btnChoose;
        protected ITTLabel labelFilePath;
        override protected void InitializeControls()
        {
            FilePath = (ITTTextBox)AddControl(new Guid("70cfa019-2f08-40e8-8fdc-b85df91a2778"));
            btnChoose = (ITTButton)AddControl(new Guid("de8573bf-b3b3-4982-81c8-10700ba2a66b"));
            labelFilePath = (ITTLabel)AddControl(new Guid("aa3b78b3-144b-400b-992f-b1e6d976df91"));
            base.InitializeControls();
        }

        public ReportDiagnosticListForm() : base("REPORTDIAGNOSTICLIST", "ReportDiagnosticListForm")
        {
        }

        protected ReportDiagnosticListForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}