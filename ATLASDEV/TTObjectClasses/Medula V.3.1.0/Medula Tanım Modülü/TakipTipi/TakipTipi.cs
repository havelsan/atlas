
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
    /// Takip Tipi
    /// </summary>
    public  partial class TakipTipi : BaseMedulaDefinition
    {
        public partial class GetTakipTipiDefinitionQuery_Class : TTReportNqlObject 
        {
        }

#region Methods
        public static TakipTipi GetTakipTipi(string takipTipiKodu)
        {
            TakipTipi retValue = null;
            if (string.IsNullOrEmpty(takipTipiKodu) == false)
                _allTakipTipi.TryGetValue(takipTipiKodu, out retValue);
            return retValue;
        }

        private static Dictionary<string, TakipTipi> _allTakipTipi;

        static TakipTipi()
        {
            TTObjectContext context = new TTObjectContext(true);
            _allTakipTipi = new Dictionary<string, TakipTipi>();
            foreach (TakipTipi takipTipi in context.QueryObjects<TakipTipi>())
                _allTakipTipi.Add(takipTipi.takipTipiKodu, takipTipi);
        }

        public override string ToString()
        {
            return takipTipiKodu + " : " + takipTipiAdi;
        }
        
#endregion Methods

    }
}