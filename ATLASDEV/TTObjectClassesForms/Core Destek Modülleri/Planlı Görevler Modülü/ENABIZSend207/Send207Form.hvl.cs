
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
    public partial class Send207Form : ScheduledTaskBaseForm
    {
        protected TTObjectClasses.ENABIZSend207 _ENABIZSend207
        {
            get { return (TTObjectClasses.ENABIZSend207)_ttObject; }
        }

        public Send207Form() : base("ENABIZSEND207", "Send207Form")
        {
        }

        protected Send207Form(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}