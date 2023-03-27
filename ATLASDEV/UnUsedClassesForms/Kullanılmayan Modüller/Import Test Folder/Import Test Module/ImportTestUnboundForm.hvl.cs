
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
    /// New Unbound Form
    /// </summary>
    public partial class ImportTestUnboundForm : TTUnboundForm
    {
        protected ITTButton ttbutton2;
        protected ITTLabel ttlabel1;
        protected ITTCheckBox ttcheckbox1;
        protected ITTTextBox tttextbox1;
        protected ITTButton ttbutton1;
        override protected void InitializeControls()
        {
            ttbutton2 = (ITTButton)AddControl(new Guid("9476c99c-caa3-454e-9ad5-cdc95988acb4"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("090c0600-67eb-4209-aacd-e4aa4c36a6a2"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("7c061073-5283-4e94-99ff-c9a13291ec2a"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("5f519252-209b-4888-a9f7-7966aa126641"));
            ttbutton1 = (ITTButton)AddControl(new Guid("349c65e4-4e7b-429d-b3d8-fc85b14027ce"));
            base.InitializeControls();
        }

        public ImportTestUnboundForm() : base("ImportTestUnboundForm")
        {
        }

        protected ImportTestUnboundForm(string formDefName) : base(formDefName)
        {
        }
    }
}