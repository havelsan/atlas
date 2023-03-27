
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
    public partial class MaintenanceBaseForm : BaseCMRActionForm
    {
    /// <summary>
    /// Bakım
    /// </summary>
        protected TTObjectClasses.Maintenance _Maintenance
        {
            get { return (TTObjectClasses.Maintenance)_ttObject; }
        }

        protected ITTToolStrip tttoolstrip1;
        override protected void InitializeControls()
        {
            tttoolstrip1 = (ITTToolStrip)AddControl(new Guid("d40ad23b-439f-48c8-801f-e9b525381e80"));
            base.InitializeControls();
        }

        public MaintenanceBaseForm() : base("MAINTENANCE", "MaintenanceBaseForm")
        {
        }

        protected MaintenanceBaseForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}