
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
    public partial class AnnualRequirementWorkListForm : BaseCriteriaForm
    {
        protected ITTTextBox txtRequestNo;
        protected ITTLabel ttlabel1;
        protected ITTComboBox StatusBox;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            txtRequestNo = (ITTTextBox)AddControl(new Guid("827f8027-dbd1-4b66-b734-fb2168379e3e"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("9c20b0fb-ac85-49e3-8d69-cfe5e987b355"));
            StatusBox = (ITTComboBox)AddControl(new Guid("1723d616-20f7-4575-89ad-0ac4cbfaaeec"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("ace7e8ed-0d55-4415-8221-b480b6431251"));
            base.InitializeControls();
        }

        public AnnualRequirementWorkListForm() : base("AnnualRequirementWorkListForm")
        {
        }

        protected AnnualRequirementWorkListForm(string formDefName) : base(formDefName)
        {
        }
    }
}