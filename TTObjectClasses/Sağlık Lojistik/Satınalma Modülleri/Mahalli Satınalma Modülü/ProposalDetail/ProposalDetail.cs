
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
    /// Proposal Sınıfına Bağlıdır. Firmaların Verdiği Her Teklif İçin Bir Adet Proposal Instance'ı Yaratılırken Her Teklif Detayı, Yani Her Kalem İçin Bir Adette ProposalDetail Instance'ı Yaratılır.
    /// </summary>
    public  partial class ProposalDetail : TTObject
    {
        public partial class GetWinnerFirmsWithObjectID_Class : TTReportNqlObject 
        {
        }

        public partial class GetTotalPriceForDirectPurchaseQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetProposalledTotalPrices_Class : TTReportNqlObject 
        {
        }

        public partial class GetProposalledTotalPricesByGroup_Class : TTReportNqlObject 
        {
        }

    }
}