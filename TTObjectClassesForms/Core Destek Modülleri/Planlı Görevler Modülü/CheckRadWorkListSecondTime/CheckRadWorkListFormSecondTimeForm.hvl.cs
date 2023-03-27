
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
    /// Radyoloji iş listesi ilk işlem kontrolu için planlı görev
    /// </summary>
    public partial class CheckRadWorkListFormSecondTime : ScheduledTaskBaseForm
    {
    /// <summary>
    /// Radyoloji iş listesinde işleminin tanımlanan zaman parametresinde başlayıp başlamadığını kontrol eder. İşleme başlanmadıysa ilgili kullanıcılara SMS gönderilir. 
    /// </summary>
        protected TTObjectClasses.CheckRadWorkListSecondTime _CheckRadWorkListSecondTime
        {
            get { return (TTObjectClasses.CheckRadWorkListSecondTime)_ttObject; }
        }

        public CheckRadWorkListFormSecondTime() : base("CHECKRADWORKLISTSECONDTIME", "CheckRadWorkListFormSecondTime")
        {
        }

        protected CheckRadWorkListFormSecondTime(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}