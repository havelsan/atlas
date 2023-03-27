
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
    public  partial class UnitEnclosureDefinition : TerminologyManagerDef, ITMK
    {
        public partial class GetUnitEnclosureDefinitionList_Class : TTReportNqlObject 
        {
        }

        public partial class OLAP_GetUnitEnclosureDefinition_Class : TTReportNqlObject 
        {
        }

        protected override void PreUpdate()
        {
#region PreUpdate
            
            
            

            base.PreUpdate();

             if(MilitaryUnit != null && MilitaryUnit.Site != null)
            {
            SITEIP = MilitaryUnit.Site.IP;
            }
            if (GetOwnerSite() == null)
                throw new Exception(SystemMessage.GetMessage(575));
#endregion PreUpdate
        }

#region Methods
        public override bool IsActiveLocal()
        {
            return false;
        }
        #region ITMK Members

        public ISites GetOwnerSite()
        {
            return (ISites)MilitaryUnit.Site; 
        }

        #endregion
        
#endregion Methods

    }
}