
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
    /// Sample Unbound Form
    /// </summary>
    public partial class SampleUnboundForm : TTUnboundForm
    {
        protected ITTButton ttAddConsultationProcedureBtn;
        protected ITTCheckBox ttcheckbox2;
        protected ITTCheckBox ttcheckbox1;
        protected ITTCheckBox ttcheckbox3;
        override protected void InitializeControls()
        {
            ttAddConsultationProcedureBtn = (ITTButton)AddControl(new Guid("93570513-a35a-403a-923d-f18a9f926be4"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("e1369c72-9df6-4e77-a24a-14685b8bda8c"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("ad3d6689-14fd-4691-9650-51fe28fb173b"));
            ttcheckbox3 = (ITTCheckBox)AddControl(new Guid("b0e2239e-9700-4414-b2b7-dc6d590fa0ec"));
            base.InitializeControls();
        }

        public SampleUnboundForm() : base("SampleUnboundForm")
        {
        }

        protected SampleUnboundForm(string formDefName) : base(formDefName)
        {
        }
    }
}