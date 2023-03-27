
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
    /// İl Tanımları
    /// </summary>
    public  partial class City : TerminologyManagerDef
    {
        public partial class GetCityDefinition_Class : TTReportNqlObject 
        {
        }

        public partial class OLAP_GetCityDefinition_Class : TTReportNqlObject 
        {
        }

#region Methods
        public override SendDataTypesEnum? GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.CityDefinitionInfo;
        }


        public static City GetCityFromExternalCode(string externalCode)
        {
            City returnValue = null;
            if (string.IsNullOrEmpty(externalCode) == false)
            {
                if (_cityListKeyExternalCode == null)
                    RefreshCityListKeyExternalCode();
                _cityListKeyExternalCode.TryGetValue(externalCode, out returnValue);
            }
            return returnValue;
        }

        private static Dictionary<string, City> _cityListKeyExternalCode = null;
        private static void RefreshCityListKeyExternalCode()
        {
            TTObjectContext context = new TTObjectContext(true);
            _cityListKeyExternalCode = new Dictionary<string, City>();
            foreach (City city in context.QueryObjects<City>())
                _cityListKeyExternalCode.Add(city.ExternalCode, city);
        }

        public override string ToString()
        {
            return Code + " " + Name;
        }
        
#endregion Methods

    }
}