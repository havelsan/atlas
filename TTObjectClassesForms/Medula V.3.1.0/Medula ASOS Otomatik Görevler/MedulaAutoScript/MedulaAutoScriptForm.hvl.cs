
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
    /// Medula Otomatik Görev
    /// </summary>
    public partial class MedulaAutoScriptForm : ScheduledTaskBaseForm
    {
    /// <summary>
    /// Medula Otomatik Görevler
    /// </summary>
        protected TTObjectClasses.MedulaAutoScript _MedulaAutoScript
        {
            get { return (TTObjectClasses.MedulaAutoScript)_ttObject; }
        }

        public MedulaAutoScriptForm() : base("MEDULAAUTOSCRIPT", "MedulaAutoScriptForm")
        {
        }

        protected MedulaAutoScriptForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}