
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
    /// 663db642-20db-4160-bd77-c9be99c7f496
    /// </summary>
    public  partial class SKRSVakaTipi : BaseSKRSDefinition
    {
        public partial class GetSKRSVakaTipi_Class : TTReportNqlObject 
        {
        }

#region Methods
        public static SKRSVakaTipi GetByDiagnosisStatusEnum(int diagnosisStatusEnum)
        {
            TTObjectContext objectContext = new TTObjectContext(true);
            var sKRVakaTipi = SKRSVakaTipi.GetByKodu(objectContext,diagnosisStatusEnum.ToString());

            if (sKRVakaTipi.Count > 0)
                return sKRVakaTipi[0];


            return null;

        }
        
#endregion Methods

    }
}