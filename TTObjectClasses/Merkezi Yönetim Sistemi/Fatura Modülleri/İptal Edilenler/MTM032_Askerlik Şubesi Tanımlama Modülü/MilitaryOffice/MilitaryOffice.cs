
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
    /// XXXXXXlik Şubesi Tanımları
    /// </summary>
    public  partial class MilitaryOffice : TerminologyManagerDef
    {
        public partial class GetMilitaryOfficeNQL_Class : TTReportNqlObject 
        {
        }

#region Methods
        public static MilitaryOffice GetMilitaryOfficeFromExternalCode(string externalCode)
        {
            MilitaryOffice returnValue = null;
            if (string.IsNullOrEmpty(externalCode) == false)
            {
                if (_militaryOfficeListKeyExternalCode == null)
                    RefreshMilitaryOfficeListKeyExternalCode();
                _militaryOfficeListKeyExternalCode.TryGetValue(externalCode, out returnValue);
            }
            return returnValue;
        }

        private static Dictionary<string, MilitaryOffice> _militaryOfficeListKeyExternalCode = null;
        private static void RefreshMilitaryOfficeListKeyExternalCode()
        {
            TTObjectContext context = new TTObjectContext(true);
            _militaryOfficeListKeyExternalCode = new Dictionary<string, MilitaryOffice>();
            foreach (MilitaryOffice militaryOffice in context.QueryObjects<MilitaryOffice>())
                _militaryOfficeListKeyExternalCode.Add(militaryOffice.ExternalCode, militaryOffice);
        }

        public override string ToString()
        {
            return Code + " " + Name;
        }
        
        public override SendDataTypesEnum?  GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.MilitaryOffice;
        }
        
#endregion Methods

    }
}