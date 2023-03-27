
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
    public partial class Send108Form : ScheduledTaskBaseForm
    {
        protected TTObjectClasses.ENABIZSend108 _ENABIZSend108
        {
            get { return (TTObjectClasses.ENABIZSend108)_ttObject; }
        }

        public Send108Form() : base("ENABIZSEND108", "Send108Form")
        {
        }

        protected Send108Form(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}