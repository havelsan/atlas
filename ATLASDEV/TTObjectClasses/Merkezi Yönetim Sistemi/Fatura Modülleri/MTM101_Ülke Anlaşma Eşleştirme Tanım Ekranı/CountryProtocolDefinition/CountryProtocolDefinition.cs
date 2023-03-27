
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
    /// Ãœlke Anlaşma Eşleştirme Tanım Ekranı
    /// </summary>
    public  partial class CountryProtocolDefinition : TerminologyManagerDef
    {
        public partial class GetCountryProtocolDefinitions_Class : TTReportNqlObject 
        {
        }

#region Methods
        // Ãœniversite XXXXXX veya normal XXXXXX olmasına göre uygun anlaşmayı döndürür
        public ProtocolDefinition GetProperProtocol()
        {
            if (SystemParameter.IsUniversityHospital && ProtocolUniversity != null)
                return ProtocolUniversity;
            
            return Protocol; // Anlaşma(Ãœniversite) boş ise hata alınmaması için Anlaşma döndürülür
        }
        
#endregion Methods

    }
}