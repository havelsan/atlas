
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
    /// Ãœlke Tanımları
    /// </summary>
    public  partial class Country : TerminologyManagerDef
    {
        public partial class GetCountryDefinitionNQL_Class : TTReportNqlObject 
        {
        }

        public partial class OLAP_GetCountryDefinition_Class : TTReportNqlObject 
        {
        }

#region Methods
        public static Country GetCountryFromExternalCode(string externalCode)
        {
            Country returnValue = null;
            if (string.IsNullOrEmpty(externalCode) == false)
            {
                if (_countryListKeyExternalCode == null)
                    RefreshCountryListKeyExternalCode();
                _countryListKeyExternalCode.TryGetValue(externalCode, out returnValue);
            }
            return returnValue;
        }

        private static Dictionary<string, Country> _countryListKeyExternalCode = null;
        private static void RefreshCountryListKeyExternalCode()
        {
            TTObjectContext context = new TTObjectContext(true);
            _countryListKeyExternalCode = new Dictionary<string, Country>();
            foreach (Country country in context.QueryObjects<Country>())
                _countryListKeyExternalCode.Add(country.ExternalCode, country);
        }

        public override string ToString()
        {
            return Name;
        }
         public override SendDataTypesEnum?  GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.CountryDefinitionInfo;
        }
         
         
        public override BaseSKRSDefinition GetSKRSDefinition()
        {
            var sKRSUlkeKodlariList =SKRSUlkeKodlari.GetByMernisKodu(ObjectContext,MernisCode);
            if(sKRSUlkeKodlariList == null || sKRSUlkeKodlariList.Count == 0)
                return null;
            return sKRSUlkeKodlariList[0] ;
        }
        
#endregion Methods

    }
}