
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
    /// SGK İşlem Bildir Oluştur
    /// </summary>
    public partial class Create700Form : ScheduledTaskBaseForm
    {
        protected TTObjectClasses.ENABIZCreate700 _ENABIZCreate700
        {
            get { return (TTObjectClasses.ENABIZCreate700)_ttObject; }
        }

        public Create700Form() : base("ENABIZCREATE700", "Create700Form")
        {
        }

        protected Create700Form(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}