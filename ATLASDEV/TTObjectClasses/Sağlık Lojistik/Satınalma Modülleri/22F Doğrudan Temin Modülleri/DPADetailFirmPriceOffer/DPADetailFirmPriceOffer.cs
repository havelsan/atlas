
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
    /// Firma Fiyat Teklifleri
    /// </summary>
    public  partial class DPADetailFirmPriceOffer : TTObject
    {
        public partial class GetDirectPurchaseActionDetailList_Class : TTReportNqlObject 
        {
        }

        public partial class GetRadyofarmasotikDPADetailList_Class : TTReportNqlObject 
        {
        }

        public partial class GetCodelessMatDPADetailList_Class : TTReportNqlObject 
        {
        }

        public partial class GetTotalPriceDPADetailFirmOffer_Class : TTReportNqlObject 
        {
        }

        public partial class MaterialInspectionAndReceivingReportInfoNQL_Class : TTReportNqlObject 
        {
        }

        public partial class GetUygunGorulenFirmalarQuery_Class : TTReportNqlObject 
        {
        }

        protected override void PreDelete()
        {
#region PreDelete
            base.PreDelete();

#endregion PreDelete
        }

    }
}