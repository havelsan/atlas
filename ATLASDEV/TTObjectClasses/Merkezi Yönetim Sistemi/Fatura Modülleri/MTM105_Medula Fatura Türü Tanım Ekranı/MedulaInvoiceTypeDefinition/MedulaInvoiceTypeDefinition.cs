
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
    /// Medula Fatura Türü Tanım Ekranı
    /// </summary>
    public  partial class MedulaInvoiceTypeDefinition : TerminologyManagerDef
    {
        public partial class GetMedulaInvoiceTypeDefs_Class : TTReportNqlObject 
        {
        }

        public partial class GetMedulaInvoiceTypeDefinitions_Class : TTReportNqlObject 
        {
        }

        protected override void PreInsert()
        {
#region PreInsert
            base.PreInsert();

#endregion PreInsert
        }

        protected override void PostInsert()
        {
#region PostInsert
            base.PostInsert();

#endregion PostInsert
        }

    }
}