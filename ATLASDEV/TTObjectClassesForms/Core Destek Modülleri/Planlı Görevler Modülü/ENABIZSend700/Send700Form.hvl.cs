
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
    /// SGK İşlem Bildir Kayıt
    /// </summary>
    public partial class Send700Form : ScheduledTaskBaseForm
    {
        protected TTObjectClasses.ENABIZSend700 _ENABIZSend700
        {
            get { return (TTObjectClasses.ENABIZSend700)_ttObject; }
        }

        public Send700Form() : base("ENABIZSEND700", "Send700Form")
        {
        }

        protected Send700Form(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}