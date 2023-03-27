
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
    /// ControlPatientName
    /// </summary>
    public partial class ControlPatientName : ScheduledTaskBaseForm
    {
    /// <summary>
    /// Hasta Adlarının Kontrol Edilmesi
    /// </summary>
        protected TTObjectClasses.ControlPatientNames _ControlPatientNames
        {
            get { return (TTObjectClasses.ControlPatientNames)_ttObject; }
        }

        public ControlPatientName() : base("CONTROLPATIENTNAMES", "ControlPatientName")
        {
        }

        protected ControlPatientName(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}