
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
    /// Laboratuvar Sonuç Sorgulama Formu
    /// </summary>
    public partial class LISLabResultQueryForm : ScheduledTaskBaseForm
    {
    /// <summary>
    /// Laboratuvar Sonuçlarını LIS den Sorgulama
    /// </summary>
        protected TTObjectClasses.LISLabResultQuery _LISLabResultQuery
        {
            get { return (TTObjectClasses.LISLabResultQuery)_ttObject; }
        }

        public LISLabResultQueryForm() : base("LISLABRESULTQUERY", "LISLabResultQueryForm")
        {
        }

        protected LISLabResultQueryForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}