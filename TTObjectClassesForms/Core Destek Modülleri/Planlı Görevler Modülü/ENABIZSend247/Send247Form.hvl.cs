
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
    /// Toplum Tabanlı Kanser Tarama
    /// </summary>
    public partial class Send247Form : ScheduledTaskBaseForm
    {
        protected TTObjectClasses.ENABIZSend247 _ENABIZSend247
        {
            get { return (TTObjectClasses.ENABIZSend247)_ttObject; }
        }

        public Send247Form() : base("ENABIZSEND247", "Send247Form")
        {
        }

        protected Send247Form(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}