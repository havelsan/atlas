
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
    /// Mahalli Satınalmada PurchaseProject Sınıfı İçin Proposal Sınıfını Barındıran Sınıftır.
    /// </summary>
    public  partial class PurchaseProjectProposalFirm : TTObject
    {
        public partial class GetDocumentNamesForFirmsBySupplierIDQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetProposalFirmsByObjectID_Class : TTReportNqlObject 
        {
        }

        public partial class GetDocumentNamesForFirmsQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetUnEligibleProposalFirms_Class : TTReportNqlObject 
        {
        }

        public partial class GetFirmOrderNOQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetAllFirmOrderNoQuery_Class : TTReportNqlObject 
        {
        }

    }
}