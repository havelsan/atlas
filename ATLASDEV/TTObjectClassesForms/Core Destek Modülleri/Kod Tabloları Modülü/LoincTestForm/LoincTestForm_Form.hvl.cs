
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
    public partial class LoincTestForm : TTForm
    {
    /// <summary>
    /// LoincTestForm
    /// </summary>
        protected TTObjectClasses.LoincTestForm _LoincTestForm
        {
            get { return (TTObjectClasses.LoincTestForm)_ttObject; }
        }

        protected ITTButton cmdCreate;
        override protected void InitializeControls()
        {
            cmdCreate = (ITTButton)AddControl(new Guid("472c9ebb-d065-4ca0-9289-834cd7705392"));
            base.InitializeControls();
        }

        public LoincTestForm() : base("LOINCTESTFORM", "LoincTestForm")
        {
        }

        protected LoincTestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}