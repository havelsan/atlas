
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
    /// Coombs Testi
    /// </summary>
    public  partial class BloodBankCoombs : EpisodeAction, IWorkListEpisodeAction
    {
#region Methods
        //        override protected void OnConstruct()
//        {
//            base.OnConstruct();
//            ITTObject ttObject = (ITTObject)this;
//            if(ttObject.IsNew)
//            {
//                this.ActionDate = DateTime.Now.Date;
//                this.ID = 1289 ;
//                
//                Guid FromResourceObjectID = new Guid("203cabfe-c961-41e0-b17b-3d16330abc22");
//                
//                IList FromResource = ObjectContext.QueryObjects("Resource", "OBJECTID = " + ConnectionManager.GuidToString(FromResourceObjectID));
//                if(Convert.ToBoolean(FromResource.Count))
//                {
//                    this.FromResource = (ResSection)FromResource[0];
//                }
//                
//                Guid MasterResourceObjectID = new Guid("bb62010d-a097-42f8-af86-a17d2e9de6ea");
//                
//                IList MasterResource = ObjectContext.QueryObjects("Resource", "OBJECTID = " + ConnectionManager.GuidToString(MasterResourceObjectID));
//                if(Convert.ToBoolean(MasterResource.Count))
//                {
//                    this.MasterResource = (ResSection)MasterResource[0];
//                }
//            }
//        }
   public override ActionTypeEnum ActionType
        {
            get {
                return ActionTypeEnum.BloodBankCoombs;
            }
        }
        
#endregion Methods

    }
}