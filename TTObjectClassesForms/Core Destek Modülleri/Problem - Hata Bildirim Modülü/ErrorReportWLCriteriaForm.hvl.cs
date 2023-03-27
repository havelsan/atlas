
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
    /// Filtre
    /// </summary>
    public partial class ErrorReportWLCriteriaForm : BaseCriteriaForm
    {
        protected ITTTextBox ErrorReportNO;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTComboBox StatusBox;
        override protected void InitializeControls()
        {
            ErrorReportNO = (ITTTextBox)AddControl(new Guid("ab5e767e-c6e9-4061-b040-261f93885d95"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("b848f1af-779f-480a-9adf-34f57a3c2074"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("7a946db1-9487-4a03-b8a8-fc7a9e1ae995"));
            StatusBox = (ITTComboBox)AddControl(new Guid("17b20253-2f5c-47bb-a37d-0fdb970a889a"));
            base.InitializeControls();
        }

        public ErrorReportWLCriteriaForm() : base("ErrorReportWLCriteriaForm")
        {
        }

        protected ErrorReportWLCriteriaForm(string formDefName) : base(formDefName)
        {
        }
    }
}