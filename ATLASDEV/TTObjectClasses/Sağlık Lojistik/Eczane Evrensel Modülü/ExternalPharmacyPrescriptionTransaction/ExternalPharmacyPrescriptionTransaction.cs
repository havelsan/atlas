
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
    /// Diş Eczaneye Dağıtılmış Reçeteler 
    /// </summary>
    public  partial class ExternalPharmacyPrescriptionTransaction : TTObject
    {
        public partial class GetDistributeGraphReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetDistributePrescriptionByTransactionDate_Class : TTReportNqlObject 
        {
        }

        public partial class GetPrescriptionReportQuery_Class : TTReportNqlObject 
        {
        }

        protected override void PreInsert()
        {
#region PreInsert
            
            base.PreInsert();

//            if (((DateTime)this.TransactionDate).Date < ((DateTime)this.DistributionTerm.StartDate).Date && ((DateTime)this.TransactionDate).Date > ((DateTime)this.DistributionTerm.EndDate).Date)
//            {
//                throw new TTException("Yaptığınız dagıtım işlemi açık olan reçete dagıtım döneminin içinde değildir. İşleme devam edemezsiniz!");  
//            }

#endregion PreInsert
        }

    }
}