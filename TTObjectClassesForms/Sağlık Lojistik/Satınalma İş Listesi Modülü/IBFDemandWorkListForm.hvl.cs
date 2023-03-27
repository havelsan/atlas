
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
    public partial class IBFDemandWorkListForm : BaseCriteriaForm
    {
        protected ITTTextBox txtRequestNo;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTComboBox StatusBox;
        override protected void InitializeControls()
        {
            txtRequestNo = (ITTTextBox)AddControl(new Guid("5cc1eafe-9e1e-4179-af9d-750f1eb94cc5"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("562e8303-4cf1-4893-b43a-4bcdc83641d3"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("7761b2bb-25a7-40dd-8492-c0feaec6646c"));
            StatusBox = (ITTComboBox)AddControl(new Guid("dd1784bd-f69d-41f6-a969-2799a5781ddf"));
            base.InitializeControls();
        }

        public IBFDemandWorkListForm() : base("IBFDemandWorkListForm")
        {
        }

        protected IBFDemandWorkListForm(string formDefName) : base(formDefName)
        {
        }
    }
}