
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
    /// Konsültasyonı Kayıt
    /// </summary>
    public partial class Send252Form : ScheduledTaskBaseForm
    {
        protected TTObjectClasses.ENABIZSend252 _ENABIZSend252
        {
            get { return (TTObjectClasses.ENABIZSend252)_ttObject; }
        }

        public Send252Form() : base("ENABIZSEND252", "Send252Form")
        {
        }

        protected Send252Form(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}