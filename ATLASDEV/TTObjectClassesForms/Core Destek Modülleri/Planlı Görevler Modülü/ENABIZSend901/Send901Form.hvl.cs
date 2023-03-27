
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
    /// Yatak Bilgisi Kayıt
    /// </summary>
    public partial class Send901Form : ScheduledTaskBaseForm
    {
        protected TTObjectClasses.ENABIZSend901 _ENABIZSend901
        {
            get { return (TTObjectClasses.ENABIZSend901)_ttObject; }
        }

        public Send901Form() : base("ENABIZSEND901", "Send901Form")
        {
        }

        protected Send901Form(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}