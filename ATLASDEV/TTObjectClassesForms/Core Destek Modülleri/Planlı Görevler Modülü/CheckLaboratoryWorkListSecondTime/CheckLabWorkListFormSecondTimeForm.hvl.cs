
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
    /// Laboratuvar İş Listesi Kontrol Formu
    /// </summary>
    public partial class CheckLabWorkListFormSecondTime : ScheduledTaskBaseForm
    {
    /// <summary>
    /// Laboratouvar Kan Alma işleminin tanımlanan zaman parametresinde başlayıp başlamadığını kontrol eder. İşleme başlanmadıysa ilgili kullanıcılara SMS gönderilir. 
    /// </summary>
        protected TTObjectClasses.CheckLaboratoryWorkListSecondTime _CheckLaboratoryWorkListSecondTime
        {
            get { return (TTObjectClasses.CheckLaboratoryWorkListSecondTime)_ttObject; }
        }

        public CheckLabWorkListFormSecondTime() : base("CHECKLABORATORYWORKLISTSECONDTIME", "CheckLabWorkListFormSecondTime")
        {
        }

        protected CheckLabWorkListFormSecondTime(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}