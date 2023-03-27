
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
    /// Rapor Bilgisi Bul TC Kimlik Numarasından
    /// </summary>
    public  partial class RaporBilgisiBulTCKimlikNodan : BaseMedulaAction
    {
        public partial class GetRaporBilgisiBulTCKWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
        }

#region Methods
        protected override void OnConstruct()
        {
            base.OnConstruct();

            if (((ITTObject)this).IsNew)
                raporOkuTCKimlikNodanDVO = new RaporOkuTCKimlikNodanDVO(ObjectContext);
        }
        
#endregion Methods

    }
}