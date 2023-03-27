
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
    /// Bölük Bilgileri
    /// </summary>
    public partial class NewCompanyForm : TTForm
    {
    /// <summary>
    /// Bölük Tanımlama
    /// </summary>
        protected TTObjectClasses.MPBSCompanyDefinition _MPBSCompanyDefinition
        {
            get { return (TTObjectClasses.MPBSCompanyDefinition)_ttObject; }
        }

        protected ITTCheckBox Active;
        protected ITTTextBox Name;
        protected ITTLabel labelName;
        override protected void InitializeControls()
        {
            Active = (ITTCheckBox)AddControl(new Guid("5ec8882e-cb28-4887-9c27-3b2e0d2c1bb7"));
            Name = (ITTTextBox)AddControl(new Guid("41b4e949-31bb-4dbc-bb31-415d2f5ba5c8"));
            labelName = (ITTLabel)AddControl(new Guid("153fae05-9153-4120-9678-dca85e7de129"));
            base.InitializeControls();
        }

        public NewCompanyForm() : base("MPBSCOMPANYDEFINITION", "NewCompanyForm")
        {
        }

        protected NewCompanyForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}