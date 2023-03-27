
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
    /// Randevu Formu
    /// </summary>
    public partial class AppointmentFormBase : TTForm
    {
    /// <summary>
    /// Program üzerinde orak özelikler taşıyan işlemlerin ana Nesnesi
    /// </summary>
        protected TTObjectClasses.BaseAction _BaseAction
        {
            get { return (TTObjectClasses.BaseAction)_ttObject; }
        }

        protected ITTTextBox tttextboxDescription;
        override protected void InitializeControls()
        {
            tttextboxDescription = (ITTTextBox)AddControl(new Guid("156b2323-0d35-4e6c-bded-21a13e870864"));
            base.InitializeControls();
        }

        public AppointmentFormBase() : base("BASEACTION", "AppointmentFormBase")
        {
        }

        protected AppointmentFormBase(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}