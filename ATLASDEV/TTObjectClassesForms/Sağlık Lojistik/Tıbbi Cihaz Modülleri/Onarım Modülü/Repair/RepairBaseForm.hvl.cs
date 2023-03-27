
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
    public partial class RepairBaseForm : BaseCMRActionForm
    {
    /// <summary>
    /// Onarım
    /// </summary>
        protected TTObjectClasses.Repair _Repair
        {
            get { return (TTObjectClasses.Repair)_ttObject; }
        }

        protected ITTToolStrip tttoolstrip1;
        override protected void InitializeControls()
        {
            tttoolstrip1 = (ITTToolStrip)AddControl(new Guid("bd107b2f-8193-43da-8f1f-5074ac75c82a"));
            base.InitializeControls();
        }

        public RepairBaseForm() : base("REPAIR", "RepairBaseForm")
        {
        }

        protected RepairBaseForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}