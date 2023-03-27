
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
    public partial class ClearCovidInfoFromPatientForm : ScheduledTaskBaseForm
    {
    /// <summary>
    /// 15 gün içinde Covid Tanısı Girilmemiş Hastaların Pandemi bilgisini siler
    /// </summary>
        protected TTObjectClasses.ClearCovidInfoFromPatient _ClearCovidInfoFromPatient
        {
            get { return (TTObjectClasses.ClearCovidInfoFromPatient)_ttObject; }
        }

        public ClearCovidInfoFromPatientForm() : base("CLEARCOVIDINFOFROMPATIENT", "ClearCovidInfoFromPatientForm")
        {
        }

        protected ClearCovidInfoFromPatientForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}