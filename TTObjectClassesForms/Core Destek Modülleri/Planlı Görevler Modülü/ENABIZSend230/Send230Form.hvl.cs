
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
    public partial class Send230Form : ScheduledTaskBaseForm
    {
        protected TTObjectClasses.ENABIZSend230 _ENABIZSend230
        {
            get { return (TTObjectClasses.ENABIZSend230)_ttObject; }
        }

        public Send230Form() : base("ENABIZSEND230", "Send230Form")
        {
        }

        protected Send230Form(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}