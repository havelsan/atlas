
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
    public partial class RUL_BaseForm : TTForm
    {
    /// <summary>
    /// Üst Kademeye Sevk
    /// </summary>
        protected TTObjectClasses.ReferToUpperLevel _ReferToUpperLevel
        {
            get { return (TTObjectClasses.ReferToUpperLevel)_ttObject; }
        }

        protected ITTToolStrip tttoolstrip1;
        override protected void InitializeControls()
        {
            tttoolstrip1 = (ITTToolStrip)AddControl(new Guid("d586a615-ec61-4e94-885b-edd65cdb7bb1"));
            base.InitializeControls();
        }

        public RUL_BaseForm() : base("REFERTOUPPERLEVEL", "RUL_BaseForm")
        {
        }

        protected RUL_BaseForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}