
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
    public  partial class MissionDefinition : TerminologyManagerDef
    {
        public partial class GetMissionDefinitionList_Class : TTReportNqlObject 
        {
        }

        public partial class OLAP_GetMissionDefinition_Class : TTReportNqlObject 
        {
        }

        protected override void PostInsert()
        {
#region PostInsert
            base.PostInsert();
                ITTObject iTTObject = (ITTObject)this;           
                MissionDefinition item = iTTObject as MissionDefinition;
                if (item != null)
                {                    
                    IList missionDefinitionList = ObjectContext.QueryObjects<MissionDefinition>(" NAME = '"+ item.NAME+"'");
                    if(missionDefinitionList.Count>0)
                        throw new Exception(SystemMessage.GetMessage(1429));
                    
                }

#endregion PostInsert
        }

        protected override void PreUpdate()
        {
#region PreUpdate
            base.PreUpdate();
#endregion PreUpdate
        }

        protected override void PostUpdate()
        {
#region PostUpdate
            base.PostUpdate();
             ITTObject iTTObject = (ITTObject)this;           
                MissionDefinition item = iTTObject as MissionDefinition;
                if (item != null)
                {                  
                    IList missionDefinitionList = ObjectContext.QueryObjects<MissionDefinition>("OBJECTID <> " + ConnectionManager.GuidToString(item.ObjectID) + " AND NAME = '"+ item.NAME+"'");
                    if(missionDefinitionList.Count>0)
                        throw new Exception(SystemMessage.GetMessage(1429));
                    
                }

#endregion PostUpdate
        }

#region Methods
        public override bool IsActiveLocal()
        {
            return false;
        }
        
#endregion Methods

    }
}