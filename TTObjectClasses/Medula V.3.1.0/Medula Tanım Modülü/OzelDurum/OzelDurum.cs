
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
    public  partial class OzelDurum : BaseMedulaDefinition
    {
        public partial class GetOzelDurumDefinitionQuery_Class : TTReportNqlObject 
        {
        }

        private static Dictionary<string, OzelDurum> _allOzelDurum;

        static OzelDurum()
        {
            TTObjectContext context = new TTObjectContext(true);
            _allOzelDurum = new Dictionary<string, OzelDurum>();
            foreach (OzelDurum ozelDurum in context.QueryObjects<OzelDurum>())
                _allOzelDurum.Add(ozelDurum.ozelDurumKodu, ozelDurum);
        }

        public static OzelDurum GetOzelDurum(string ozelDurumKodu)
        {
            OzelDurum retValue = null;
            if (string.IsNullOrEmpty(ozelDurumKodu) == false)
                _allOzelDurum.TryGetValue(ozelDurumKodu, out retValue);
            return retValue;
        }
    }
}