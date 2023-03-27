
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
    public partial class DemandWorkListForm : BaseCriteriaForm
    {
        protected ITTTextBox txtRequestNo;
        protected ITTLabel ttlabel1;
        protected ITTComboBox StatusBox;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            txtRequestNo = (ITTTextBox)AddControl(new Guid("3d3ea8b6-aef3-490a-99ad-e1d0e86bc82f"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("c853a9f6-6343-4ff9-be69-d1cee2559635"));
            StatusBox = (ITTComboBox)AddControl(new Guid("d8aded6b-99fa-44d9-a2c1-84402e6a291d"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("eaddf244-be6c-44e5-b67c-4242ff5ca6f9"));
            base.InitializeControls();
        }

        public DemandWorkListForm() : base("DemandWorkListForm")
        {
        }

        protected DemandWorkListForm(string formDefName) : base(formDefName)
        {
        }
    }
}