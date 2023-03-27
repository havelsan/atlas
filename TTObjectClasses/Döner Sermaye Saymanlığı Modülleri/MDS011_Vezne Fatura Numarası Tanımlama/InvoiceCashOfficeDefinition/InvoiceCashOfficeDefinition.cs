
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
    /// Sayman Mutemetliği / Fatura Servisi Fatura Numarası Tanımlama
    /// </summary>
    public partial class InvoiceCashOfficeDefinition : TTDefinitionSet
    {
        public partial class GetInvoiceCashOfficeDefinitions_Class : TTReportNqlObject
        {
        }

        #region Methods
        public static string GetCurrentInvoiceNumber(InvoiceCashOfficeDefinition invoiceCashOfficeDef)
        {
            return invoiceCashOfficeDef.InvoiceSeriesNo + invoiceCashOfficeDef.CurrentInvoiceNumber;
        }

        public static void SetNextInvoiceNumber(InvoiceCashOfficeDefinition invoiceCashOfficeDef)
        {
            invoiceCashOfficeDef.CurrentInvoiceNumber = invoiceCashOfficeDef.CurrentInvoiceNumber + 1;
        }

        #endregion Methods

    }
}