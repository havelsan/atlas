
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
    public partial class PanicAlertForm : TTForm
    {
        protected TTObjectClasses.PathologyPanicAlert _PathologyPanicAlert
        {
            get { return (TTObjectClasses.PathologyPanicAlert)_ttObject; }
        }

        protected ITTLabel labelPathologyPanicReason;
        protected ITTObjectListBox PathologyPanicReason;
        protected ITTLabel labelPanicAlertDate;
        protected ITTDateTimePicker PanicAlertDate;
        override protected void InitializeControls()
        {
            labelPathologyPanicReason = (ITTLabel)AddControl(new Guid("b60bc69c-9bdb-4a64-8d1f-a8ad52e09c58"));
            PathologyPanicReason = (ITTObjectListBox)AddControl(new Guid("ff6d4b6b-166e-4ba3-b9eb-d09f2771d45f"));
            labelPanicAlertDate = (ITTLabel)AddControl(new Guid("6f9265f0-de08-4e46-aa56-5cd19dca33ad"));
            PanicAlertDate = (ITTDateTimePicker)AddControl(new Guid("cda033ef-f847-46bb-801a-d67e8b9eb1f6"));
            base.InitializeControls();
        }

        public PanicAlertForm() : base("PATHOLOGYPANICALERT", "PanicAlertForm")
        {
        }

        protected PanicAlertForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}