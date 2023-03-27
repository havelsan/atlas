
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
    /// XXXXXX Sınıf Tanımlama
    /// </summary>
    public  partial class MilitaryClassDefinitions : TerminologyManagerDef
    {
        public partial class GetMilitaryClassDefinitions_Class : TTReportNqlObject 
        {
        }

        public partial class OLAP_GetMilitaryClass_Class : TTReportNqlObject 
        {
        }

        
                    
#region Methods
        public static MilitaryClassDefinitions GetMilitaryClassDefinitionsFromExternalCode(string externalCode)
        {
            MilitaryClassDefinitions returnValue = null;
            if (string.IsNullOrEmpty(externalCode) == false)
            {
                if (_militaryClassDefinitionsListKeyExternalCode == null)
                    RefreshMilitaryClassDefinitionsListKeyExternalCode();
                _militaryClassDefinitionsListKeyExternalCode.TryGetValue(externalCode, out returnValue);
            }
            return returnValue;
        }

        private static Dictionary<string, MilitaryClassDefinitions> _militaryClassDefinitionsListKeyExternalCode = null;
        private static void RefreshMilitaryClassDefinitionsListKeyExternalCode()
        {
            TTObjectContext context = new TTObjectContext(true);
            _militaryClassDefinitionsListKeyExternalCode = new Dictionary<string, MilitaryClassDefinitions>();
            foreach (MilitaryClassDefinitions militaryClassDefinition in context.QueryObjects<MilitaryClassDefinitions>())
                _militaryClassDefinitionsListKeyExternalCode.Add(militaryClassDefinition.ExternalCode, militaryClassDefinition);
        }

        public override string ToString()
        {
            return Code + " " + Name;
        }
        public override SendDataTypesEnum?  GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.MilitaryClassInfo;
        }
        
#endregion Methods

    }
}