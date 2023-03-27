
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
    /// Flitre
    /// </summary>
    public partial class CMRActionWLCriterialForm : BaseCriteriaForm
    {
        protected ITTComboBox StatusBox;
        protected ITTLabel ttlabel1;
        protected ITTTextBox ActionID;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            StatusBox = (ITTComboBox)AddControl(new Guid("e459db45-c554-4180-ba35-1e12b603cc29"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("09a55164-2f25-4db2-8003-a08565243606"));
            ActionID = (ITTTextBox)AddControl(new Guid("f653633e-840f-4c85-a745-94925d799603"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("7e164c81-6a0b-4cd8-ba46-2e8f792700ba"));
            base.InitializeControls();
        }

        public CMRActionWLCriterialForm() : base("CMRActionWLCriterialForm")
        {
        }

        protected CMRActionWLCriterialForm(string formDefName) : base(formDefName)
        {
        }
    }
}