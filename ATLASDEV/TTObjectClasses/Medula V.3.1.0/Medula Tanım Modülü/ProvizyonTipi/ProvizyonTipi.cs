
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
    /// Provizyon Tipi
    /// </summary>
    public  partial class ProvizyonTipi : BaseMedulaDefinition
    {
        public partial class GetProvizyonTipiDefinitionQuery_Class : TTReportNqlObject 
        {
        }

#region Methods
        public static ProvizyonTipi GetProvizyonTipi(string provizyonTipiKodu)
        {
            ProvizyonTipi retValue = null;
            if (string.IsNullOrEmpty(provizyonTipiKodu) == false)
                _allProvizyonTipi.TryGetValue(provizyonTipiKodu, out retValue);
            return retValue;
        }

        private static Dictionary<string, ProvizyonTipi> _allProvizyonTipi;

        static ProvizyonTipi()
        {
            TTObjectContext context = new TTObjectContext(true);
            _allProvizyonTipi = new Dictionary<string, ProvizyonTipi>();
            foreach (ProvizyonTipi provizyonTipi in context.QueryObjects<ProvizyonTipi>())
                _allProvizyonTipi.Add(provizyonTipi.provizyonTipiKodu, provizyonTipi);
        }

        public override string ToString()
        {
            return provizyonTipiKodu + " : " + provizyonTipiAdi;
        }
        
#endregion Methods

    }
}