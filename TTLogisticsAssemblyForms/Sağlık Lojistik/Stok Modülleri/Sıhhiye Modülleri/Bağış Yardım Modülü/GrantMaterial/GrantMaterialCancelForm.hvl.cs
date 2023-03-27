
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
    public partial class GrantMaterialCancelForm : BaseGrantMaterialForm
    {
    /// <summary>
    /// Bağış Yardım
    /// </summary>
        protected TTObjectClasses.GrantMaterial _GrantMaterial
        {
            get { return (TTObjectClasses.GrantMaterial)_ttObject; }
        }

        protected ITTButton SendToMKYS;
        override protected void InitializeControls()
        {
            SendToMKYS = (ITTButton)AddControl(new Guid("a5e362d6-d4fa-40d8-a0a5-1607a13df004"));
            base.InitializeControls();
        }

        public GrantMaterialCancelForm() : base("GRANTMATERIAL", "GrantMaterialCancelForm")
        {
        }

        protected GrantMaterialCancelForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}