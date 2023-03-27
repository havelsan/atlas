
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
    public partial class Send237Form : ScheduledTaskBaseForm
    {
        protected TTObjectClasses.ENABIZSend237 _ENABIZSend237
        {
            get { return (TTObjectClasses.ENABIZSend237)_ttObject; }
        }

        public Send237Form() : base("ENABIZSEND237", "Send237Form")
        {
        }

        protected Send237Form(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}