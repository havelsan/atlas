
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
    /// Patoloji Kayıt
    /// </summary>
    public partial class Send201Form : ScheduledTaskBaseForm
    {
        protected TTObjectClasses.ENABIZSend201 _ENABIZSend201
        {
            get { return (TTObjectClasses.ENABIZSend201)_ttObject; }
        }

        public Send201Form() : base("ENABIZSEND201", "Send201Form")
        {
        }

        protected Send201Form(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}