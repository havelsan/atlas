
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
    /// dc6ff680-555f-44b2-855e-a47c51207e4f
    /// </summary>
    public  partial class SKRSYatisinAciliyeti : BaseSKRSCommonDef
    {
        public partial class GetSKRSYatisinAciliyeti_Class : TTReportNqlObject 
        {
        }

#region Methods
        public static SKRSYatisinAciliyeti GetSKRSYatisinAciliyetiByEmergencyValue(TTObjectContext objectContext,bool? Emergency)
        {
           string Kodu = "3";// Belirtilmedi
            if(Emergency == true)
                Kodu = "1";
           IList sKRSYatisinAciliyetiList = SKRSYatisinAciliyeti.GetByKodu(objectContext,Kodu);
           
           if(sKRSYatisinAciliyetiList!= null && sKRSYatisinAciliyetiList.Count>0)
               return (SKRSYatisinAciliyeti)sKRSYatisinAciliyetiList[0];
           return null;
                
        }
        
#endregion Methods

    }
}