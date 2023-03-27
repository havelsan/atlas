
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
    public partial class CentralActionWLCriteriaForm : BaseCriteriaForm
    {
        protected ITTTextBox StockActionID;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTComboBox StatusBox;
        override protected void InitializeControls()
        {
            StockActionID = (ITTTextBox)AddControl(new Guid("0d5abb18-2ee8-4127-a23d-f0498487bc1d"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("7d552a93-e3f4-4cec-99c0-bff26eb6f353"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("670e435a-7e8c-4ebe-aff4-586b848b1fe1"));
            StatusBox = (ITTComboBox)AddControl(new Guid("5f6fe0a0-262e-4850-b551-2044d67b26af"));
            base.InitializeControls();
        }

        public CentralActionWLCriteriaForm() : base("CentralActionWLCriteriaForm")
        {
        }

        protected CentralActionWLCriteriaForm(string formDefName) : base(formDefName)
        {
        }
    }
}