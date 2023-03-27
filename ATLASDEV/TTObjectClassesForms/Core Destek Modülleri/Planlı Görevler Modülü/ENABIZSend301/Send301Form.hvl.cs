
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
    public partial class Send301Form : ScheduledTaskBaseForm
    {
        protected TTObjectClasses.ENABIZSend301 _ENABIZSend301
        {
            get { return (TTObjectClasses.ENABIZSend301)_ttObject; }
        }

        public Send301Form() : base("ENABIZSEND301", "Send301Form")
        {
        }

        protected Send301Form(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}