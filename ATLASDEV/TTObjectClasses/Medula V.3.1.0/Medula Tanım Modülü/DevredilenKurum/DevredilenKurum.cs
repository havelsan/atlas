
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


namespace TTObjectClasses
{
    /// <summary>
    /// Devredilen Kurum
    /// </summary>
    public  partial class DevredilenKurum : BaseMedulaDefinition
    {
        public partial class GetDevredilenKurumDefinitionQuery_Class : TTReportNqlObject 
        {
        }

#region Methods
        public static DevredilenKurum GetDevredilenKurum(string devredilenKurumKodu)
        {
            DevredilenKurum retValue = null;
            if (string.IsNullOrEmpty(devredilenKurumKodu) == false)
                _allDevredilenKurum.TryGetValue(devredilenKurumKodu, out retValue);
            return retValue;
        }

        private static Dictionary<string, DevredilenKurum> _allDevredilenKurum;

        static DevredilenKurum()
        {
            TTObjectContext context = new TTObjectContext(true);
            _allDevredilenKurum = new Dictionary<string, DevredilenKurum>();
            foreach (DevredilenKurum devredilenKurum in context.QueryObjects<DevredilenKurum>())
                _allDevredilenKurum.Add(devredilenKurum.devredilenKurumKodu, devredilenKurum);
        }

        public override string ToString()
        {
            return devredilenKurumKodu + " : " + devredilenKurumAdi;
        }
        
#endregion Methods

    }
}