
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
    public partial class CloseDailyAdmisnsAfter24Form : ScheduledTaskBaseForm
    {
    /// <summary>
    /// Kabülü izerinden 24 saat geçmiş günübirlik kabullerin kapatılması
    /// </summary>
        protected TTObjectClasses.CloseDailyAdmisnsAfter24 _CloseDailyAdmisnsAfter24
        {
            get { return (TTObjectClasses.CloseDailyAdmisnsAfter24)_ttObject; }
        }

        public CloseDailyAdmisnsAfter24Form() : base("CLOSEDAILYADMISNSAFTER24", "CloseDailyAdmisnsAfter24Form")
        {
        }

        protected CloseDailyAdmisnsAfter24Form(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}