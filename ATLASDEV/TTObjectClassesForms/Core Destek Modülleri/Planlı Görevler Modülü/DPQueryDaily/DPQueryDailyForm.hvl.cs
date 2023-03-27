
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
    /// DP Günlük Sorgulama Formu
    /// </summary>
    public partial class DPQueryDailyForm : ScheduledTaskBaseForm
    {
        protected TTObjectClasses.DPQueryDaily _DPQueryDaily
        {
            get { return (TTObjectClasses.DPQueryDaily)_ttObject; }
        }

        public DPQueryDailyForm() : base("DPQUERYDAILY", "DPQueryDailyForm")
        {
        }

        protected DPQueryDailyForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}