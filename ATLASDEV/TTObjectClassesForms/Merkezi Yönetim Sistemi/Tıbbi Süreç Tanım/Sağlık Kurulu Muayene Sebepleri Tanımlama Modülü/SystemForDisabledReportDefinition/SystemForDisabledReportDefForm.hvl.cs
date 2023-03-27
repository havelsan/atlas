
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
    public partial class SystemForDisabledReportDefForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Engelli Raporu için Sistem Tanımlama
    /// </summary>
        protected TTObjectClasses.SystemForDisabledReportDefinition _SystemForDisabledReportDefinition
        {
            get { return (TTObjectClasses.SystemForDisabledReportDefinition)_ttObject; }
        }

        protected ITTCheckBox IsActive;
        protected ITTGrid DisabledReport;
        protected ITTListBoxColumn SpecialityDisabledReportSpecialGrid;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTTextBox Code;
        protected ITTLabel labelCode;
        override protected void InitializeControls()
        {
            IsActive = (ITTCheckBox)AddControl(new Guid("c8833695-15e3-4f9f-84a8-04aaddf2f8e2"));
            DisabledReport = (ITTGrid)AddControl(new Guid("25ac5a20-a2f3-477f-b98a-5d38deca44fc"));
            SpecialityDisabledReportSpecialGrid = (ITTListBoxColumn)AddControl(new Guid("56877887-b872-46af-aa4c-74b1df407abb"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("11b23df1-a6b3-4153-bedd-f110ac4568a6"));
            labelName = (ITTLabel)AddControl(new Guid("268a71cc-9f20-46f8-8702-6943a1af8719"));
            Name = (ITTTextBox)AddControl(new Guid("1fe4b719-fa85-4271-a958-83322560bf5a"));
            Code = (ITTTextBox)AddControl(new Guid("443ec699-e997-4f26-809f-a6867eaa1d8c"));
            labelCode = (ITTLabel)AddControl(new Guid("21895a8e-4d4e-45b2-8e31-b9eac0aab15b"));
            base.InitializeControls();
        }

        public SystemForDisabledReportDefForm() : base("SYSTEMFORDISABLEDREPORTDEFINITION", "SystemForDisabledReportDefForm")
        {
        }

        protected SystemForDisabledReportDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}