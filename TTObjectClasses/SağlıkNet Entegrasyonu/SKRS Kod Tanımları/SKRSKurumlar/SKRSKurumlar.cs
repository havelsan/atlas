
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
    /// c3eade04-4f91-5dab-e043-14031b0ac9f9
    /// </summary>
    public  partial class SKRSKurumlar : BaseSKRSDefinition
    {
        public partial class GetSKRSKurumlar_Class : TTReportNqlObject 
        {
        }

#region Methods
        public static SKRSKurumlar GetMyTesisSKRSKurumlarDefinition()
        {
              TTObjectContext objectContext = new TTObjectContext(false);
            string saglikTesisKodu = TTObjectClasses.SystemParameter.GetParameterValue("SAGLIKNETKURUMKODU", "XXXXXX");
            IList sKRSKurumlarList =  SKRSKurumlar.GetByKodu(objectContext,saglikTesisKodu,"");
            if (sKRSKurumlarList != null && sKRSKurumlarList.Count > 0)
            {
                return (SKRSKurumlar)sKRSKurumlarList[0];
            }
           return null;
        }
        
#endregion Methods

    }
}