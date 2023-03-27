
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
    public  partial class TedaviRaporTuru : BaseMedulaDefinition
    {
        public partial class GetTedaviRaporTuruDefinitionQuery_Class : TTReportNqlObject 
        {
        }

#region Methods
        public static TedaviRaporTuru GetTedaviRaporTuru(int tedaviRaporTuruKodu)
        {
            TedaviRaporTuru retValue = null;
            _allTedaviRaporTuru.TryGetValue(tedaviRaporTuruKodu, out retValue);
            return retValue;
        }

        private static Dictionary<int, TedaviRaporTuru> _allTedaviRaporTuru;

        static TedaviRaporTuru()
        {
            TTObjectContext context = new TTObjectContext(true);
            _allTedaviRaporTuru = new Dictionary<int, TedaviRaporTuru>();
            foreach (TedaviRaporTuru tedaviRaporTuru in context.QueryObjects<TedaviRaporTuru>())
                _allTedaviRaporTuru.Add(tedaviRaporTuru.tedaviRaporTuruKodu.Value, tedaviRaporTuru);
        }

        public override string ToString()
        {
            return tedaviRaporTuruKodu + " : " + tedaviRaporTuruAdi;
        }
        
#endregion Methods

    }
}