
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
    /// Döner Sermaye Hasta İade
    /// </summary>
    public partial class FinancialPatientReturnForm : TTForm
    {
    /// <summary>
    /// Döner Sermaye Hasta İade
    /// </summary>
        protected TTObjectClasses.FinancialPatientReturn _FinancialPatientReturn
        {
            get { return (TTObjectClasses.FinancialPatientReturn)_ttObject; }
        }

        protected ITTObjectListBox RETURNREASON;
        protected ITTLabel ttlabel3;
        protected ITTTextBox DESCRIPTION;
        protected ITTLabel ttlabel4;
        override protected void InitializeControls()
        {
            RETURNREASON = (ITTObjectListBox)AddControl(new Guid("5ba3e3d8-63a7-4acc-beca-cbc1ebf763f1"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("eeb49135-f2eb-4f80-8c17-a6788664cae5"));
            DESCRIPTION = (ITTTextBox)AddControl(new Guid("d1e4ab18-99b5-4fb8-b5ff-b1ca407a2a84"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("27ff70cf-d836-400a-a1b0-2f9cd82a22d7"));
            base.InitializeControls();
        }

        public FinancialPatientReturnForm() : base("FINANCIALPATIENTRETURN", "FinancialPatientReturnForm")
        {
        }

        protected FinancialPatientReturnForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}