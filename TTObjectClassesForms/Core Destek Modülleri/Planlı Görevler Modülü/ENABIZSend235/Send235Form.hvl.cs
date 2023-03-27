
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
    public partial class Send235Form : ScheduledTaskBaseForm
    {
        protected TTObjectClasses.ENABIZSend235 _ENABIZSend235
        {
            get { return (TTObjectClasses.ENABIZSend235)_ttObject; }
        }

        public Send235Form() : base("ENABIZSEND235", "Send235Form")
        {
        }

        protected Send235Form(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}