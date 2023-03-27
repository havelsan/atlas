
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
    /// İl/İlçe Tanımlama
    /// </summary>
    public  partial class TownDefinitions : TerminologyManagerDef
    {
        public partial class GetTownDefinitions_Class : TTReportNqlObject 
        {
        }

#region Methods
        public static TownDefinitions GetTownDefinitionsFromExternalCode(string externalCode)
        {
            TownDefinitions returnValue = null;
            if (string.IsNullOrEmpty(externalCode) == false)
            {
                if (_townDefinitionsListKeyExternalCode == null)
                    RefreshTownDefinitionsListKeyExternalCode();
                _townDefinitionsListKeyExternalCode.TryGetValue(externalCode, out returnValue);
            }
            return returnValue;
        }

        private static Dictionary<string, TownDefinitions> _townDefinitionsListKeyExternalCode = null;
        private static void RefreshTownDefinitionsListKeyExternalCode()
        {
            TTObjectContext context = new TTObjectContext(true);
            _townDefinitionsListKeyExternalCode = new Dictionary<string, TownDefinitions>();
            foreach (TownDefinitions townDefinition in context.QueryObjects<TownDefinitions>())
                _townDefinitionsListKeyExternalCode.Add(townDefinition.ExternalCode, townDefinition);
        }

        public override string ToString()
        {
            return Name;
        }
        public override SendDataTypesEnum?  GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.TownDefinitionsInfo;
        }
        
        public static TownDefinitions GetTownDefinitionsFromMernisCode(string mernisCode)
        {
            TownDefinitions returnValue = null;
            if (string.IsNullOrEmpty(mernisCode) == false)
            {
                if (_townDefinitionsListKeyMernisCode == null)
                    RefreshTownDefinitionsListKeyMernisCode();
                _townDefinitionsListKeyMernisCode.TryGetValue(mernisCode, out returnValue);
            }
            return returnValue;
        }

        private static Dictionary<string, TownDefinitions> _townDefinitionsListKeyMernisCode = null;
        private static void RefreshTownDefinitionsListKeyMernisCode()
        {
            TTObjectContext context = new TTObjectContext(true);
            _townDefinitionsListKeyMernisCode = new Dictionary<string, TownDefinitions>();
            foreach (TownDefinitions townDefinition in context.QueryObjects<TownDefinitions>())
                _townDefinitionsListKeyMernisCode.Add(Convert.ToString(townDefinition.MernisCode), townDefinition);
        }
        
#endregion Methods

    }
}