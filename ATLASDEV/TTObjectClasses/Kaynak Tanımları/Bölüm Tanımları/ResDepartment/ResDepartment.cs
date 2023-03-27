
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
    /// Bölüm 
    /// </summary>
    public  partial class ResDepartment : ResSection
    {
        public partial class OLAP_ResDepartment_Class : TTReportNqlObject 
        {
        }

        public partial class GetDepartmentDefinition_Class : TTReportNqlObject 
        {
        }

        protected override void PreInsert()
        {
#region PreInsert
            base.PreInsert();
            if (EnabledType==null)
            {
                EnabledType=ResourceEnableType.BothInpatientAndOutPatient;
            }
#endregion PreInsert
        }

        protected override void PostInsert()
        {
#region PostInsert
            base.PostInsert();
            SetActionCancelledTimeToChildResSections(ActionCancelledTime);
#endregion PostInsert
        }

        protected override void PostUpdate()
        {
#region PostUpdate
            base.PostUpdate();
           SetActionCancelledTimeToChildResSections(ActionCancelledTime);
#endregion PostUpdate
        }

    }
}