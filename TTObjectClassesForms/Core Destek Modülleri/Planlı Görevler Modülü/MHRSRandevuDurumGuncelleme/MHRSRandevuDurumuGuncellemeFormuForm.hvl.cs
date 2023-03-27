
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
    /// MHRS Randevu Durumu Güncelleme Formu
    /// </summary>
    public partial class MHRSRandevuDurumuGuncellemeFormu : ScheduledTaskBaseForm
    {
    /// <summary>
    /// MHRS Randevu Durum Güncelleme
    /// </summary>
        protected TTObjectClasses.MHRSRandevuDurumGuncelleme _MHRSRandevuDurumGuncelleme
        {
            get { return (TTObjectClasses.MHRSRandevuDurumGuncelleme)_ttObject; }
        }

        public MHRSRandevuDurumuGuncellemeFormu() : base("MHRSRANDEVUDURUMGUNCELLEME", "MHRSRandevuDurumuGuncellemeFormu")
        {
        }

        protected MHRSRandevuDurumuGuncellemeFormu(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}