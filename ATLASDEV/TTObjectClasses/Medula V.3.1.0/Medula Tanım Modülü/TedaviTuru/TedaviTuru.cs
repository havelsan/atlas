
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
    /// Tedavi Türü
    /// </summary>
    public  partial class TedaviTuru : BaseMedulaDefinition
    {
        public partial class Olap_GetTedaviTuruDef_Class : TTReportNqlObject 
        {
        }

        public partial class GetTedaviTuruDefinitionQuery_Class : TTReportNqlObject 
        {
        }

#region Methods
        public static TedaviTuru GetTedaviTuru(string tedaviTuruKodu)
        {
            TedaviTuru retValue = null;
            if (string.IsNullOrEmpty(tedaviTuruKodu) == false)
                _allTedaviTuru.TryGetValue(tedaviTuruKodu, out retValue);
            return retValue;
        }

        private static Dictionary<string, TedaviTuru> _allTedaviTuru;

        static TedaviTuru()
        {
            TTObjectContext context = new TTObjectContext(true);
            _allTedaviTuru = new Dictionary<string, TedaviTuru>();
            foreach (TedaviTuru tedaviTuru in context.QueryObjects<TedaviTuru>())
                _allTedaviTuru.Add(tedaviTuru.tedaviTuruKodu, tedaviTuru);
        }

        public override string ToString()
        {
            return tedaviTuruKodu + " : " + tedaviTuruAdi;
        }
        
#endregion Methods

    }
}