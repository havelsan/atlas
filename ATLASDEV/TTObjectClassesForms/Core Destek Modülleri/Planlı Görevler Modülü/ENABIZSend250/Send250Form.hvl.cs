
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
    public partial class Send250Form : ScheduledTaskBaseForm
    {
    /// <summary>
    /// NABIZ - Verem 
    /// </summary>
        protected TTObjectClasses.ENABIZSend250 _ENABIZSend250
        {
            get { return (TTObjectClasses.ENABIZSend250)_ttObject; }
        }

        public Send250Form() : base("ENABIZSEND250", "Send250Form")
        {
        }

        protected Send250Form(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}