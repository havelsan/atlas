
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
    /// Aynı Farklı Kesi
    /// </summary>
    public  partial class AyniFarkliKesi : BaseMedulaDefinition
    {
        public partial class GetAyniFarkliKesiDefinitionQuery_Class : TTReportNqlObject 
        {
        }

#region Methods
        public static AyniFarkliKesi GetAyniFarkliKesi(string ayniFarkliKesiKodu)
        {
            AyniFarkliKesi retValue = null;
            if (string.IsNullOrEmpty(ayniFarkliKesiKodu) == false)
                _allAyniFarkliKesi.TryGetValue(ayniFarkliKesiKodu, out retValue);
            return retValue;
        }

        private static Dictionary<string, AyniFarkliKesi> _allAyniFarkliKesi;

        static AyniFarkliKesi()
        {
            TTObjectContext context = new TTObjectContext(true);
            _allAyniFarkliKesi = new Dictionary<string, AyniFarkliKesi>();
            foreach (AyniFarkliKesi ayniFarkliKesi in context.QueryObjects<AyniFarkliKesi>())
                _allAyniFarkliKesi.Add(ayniFarkliKesi.ayniFarkliKesiKodu, ayniFarkliKesi);
        }

        public override string ToString()
        {
            return ayniFarkliKesiKodu + " : " + ayniFarkliKesiAdi;
        }
        
#endregion Methods

    }
}