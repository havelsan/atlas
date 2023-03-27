
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
    /// Çıkış Biglisi Kayıt
    /// </summary>
    public partial class Send106Form : ScheduledTaskBaseForm
    {
        protected TTObjectClasses.ENABIZSend106 _ENABIZSend106
        {
            get { return (TTObjectClasses.ENABIZSend106)_ttObject; }
        }

        public Send106Form() : base("ENABIZSEND106", "Send106Form")
        {
        }

        protected Send106Form(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}