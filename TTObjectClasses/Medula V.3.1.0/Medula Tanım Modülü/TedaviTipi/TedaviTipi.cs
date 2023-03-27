
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
    /// Tedavi Tipi
    /// </summary>
    public  partial class TedaviTipi : BaseMedulaDefinition
    {
        public partial class GetTedaviTipiNql_Class : TTReportNqlObject 
        {
        }

        public partial class GetTedaviTipiDefinitionQuery_Class : TTReportNqlObject 
        {
        }

#region Methods
        public static TedaviTipi GetTedaviTipi(string tedaviTipiKodu)
        {
            TedaviTipi retValue = null;
            if (string.IsNullOrEmpty(tedaviTipiKodu) == false)
                _allTedaviTipi.TryGetValue(tedaviTipiKodu, out retValue);
            return retValue;
        }

        private static Dictionary<string, TedaviTipi> _allTedaviTipi;

        static TedaviTipi()
        {
            TTObjectContext context = new TTObjectContext(true);
            _allTedaviTipi = new Dictionary<string, TedaviTipi>();
            foreach (TedaviTipi tedaviTipi in context.QueryObjects<TedaviTipi>())
                _allTedaviTipi.Add(tedaviTipi.tedaviTipiKodu, tedaviTipi);
        }

        public override string ToString()
        {
            return tedaviTipiKodu + " : " + tedaviTipiAdi;
        }
        
#endregion Methods

    }
}