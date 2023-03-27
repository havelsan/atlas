
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
    public  partial class OLAPQuery : OLAPBaseAction
    {
        public partial class GetOLAPQuery_NWS_Class : TTReportNqlObject 
        {
        }

        public partial class GetChildOLAPQueries_Class : TTReportNqlObject 
        {
        }

        public partial class GetOLAPQueryItems_Class : TTReportNqlObject 
        {
        }

        public partial class GetOLAPQueries_Class : TTReportNqlObject 
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