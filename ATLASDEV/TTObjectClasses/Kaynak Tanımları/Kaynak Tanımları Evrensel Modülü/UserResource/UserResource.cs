
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
    public  partial class UserResource : TTObject
    {
        public partial class GetUserResourceNames_Class : TTReportNqlObject 
        {
        }

        public partial class GetUserResourcesByResource_Class : TTReportNqlObject 
        {
        }

        protected override void PostInsert()
        {
#region PostInsert
            
            base.PostInsert();

            //SITEID ye gore PACS a gonderim yapilmis, o kod kaldirildi. PACS entegrasyonu olup olmadigi bilgisi sistem parametresi ile tutulup gonderim yapilabilir. 
            SendUserToPACS(User);


#endregion PostInsert
        }

        protected override void PostUpdate()
        {
#region PostUpdate
            
            base.PostUpdate();

            //SITEID ye gore PACS a gonderim yapilmis, o kod kaldirildi. PACS entegrasyonu olup olmadigi bilgisi sistem parametresi ile tutulup gonderim yapilabilir. 
            SendUserToPACS(User);


#endregion PostUpdate
        }

        protected override void PreDelete()
        {
#region PreDelete
            
            base.PreDelete();

            //            
            //            foreach(UserResource userRes in this.User.UserResources)
            //            {
            //                if(userRes.Resource is ResRadiologyDepartment)
            //                {
            //                    
            //                }
            //            }

#endregion PreDelete
        }

        protected override void PostDelete()
        {
#region PostDelete
            
            base.PostDelete();


            //Post delete de object silinmiş oluyor. O sebeple kendisi ile ilgili hiçbir şeye ulaşamıyor.


            //            foreach(UserResource userRes in this.User.UserResources)
            //            {
            //                if(userRes.Resource is ResRadiologyDepartment)
            //                {
            //                    
            //                }
            //            }


#endregion PostDelete
        }

#region Methods
        public void SendUserToPACS(ResUser userRes)
        {
            return;
            //string sysparam = TTObjectClasses.SystemParameter.GetParameterValue("HL7ENGINEALIVE", null);
            //if (sysparam == "TRUE")
            //{
            //    bool hasDepartment = false;
            //    if (this.User.UserResources.Count > 0)
            //        hasDepartment = true;

            //    if (hasDepartment)
            //    {
            //        List<Guid> resUserIDs = new List<Guid>();
            //        resUserIDs.Add(userRes.ObjectID);
            //        try
            //        {
            //            TTMessageFactory.ASyncCall(Sites.SiteLocalHost, TTMessagePriorityEnum.MediumPriority, "InternalTCPClient", "HL7Remoting", "SendHospitalMessageToEngine", null, resUserIDs, "M02", "PACS");
            //        }
            //        catch (Exception ex)
            //        {
            //            InfoBox.Alert("Kullanıcı bilgisi PACS'a gönderilmedi! " + ex.Message, MessageIconEnum.WarningMessage);
            //        }
            //    }
            //}
        }
        
#endregion Methods

    }
}