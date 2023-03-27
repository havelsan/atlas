
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
    /// Stok Bilgi (Kılavuz) Kartı Tanımları
    /// </summary>
    public  partial class StockGuideCard : TTDefinitionSet
    {
        public partial class GetStockGuideCard_Class : TTReportNqlObject 
        {
        }

        public partial class GetAllStockGuideCard_Class : TTReportNqlObject 
        {
        }

        public partial class GetStockGuideCardDetails_Class : TTReportNqlObject 
        {
        }

        public partial class GetStockGuideCardDetailsRpt_Class : TTReportNqlObject 
        {
        }

    }
}