
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
    public partial class Send105Form : ScheduledTaskBaseForm
    {
        protected TTObjectClasses.ENABIZSend105 _ENABIZSend105
        {
            get { return (TTObjectClasses.ENABIZSend105)_ttObject; }
        }

        public Send105Form() : base("ENABIZSEND105", "Send105Form")
        {
        }

        protected Send105Form(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}