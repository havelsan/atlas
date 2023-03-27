
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
    public  partial class QueueResourceWorkPlanDefinition : TTDefinitionSet
    {
        public partial class QueueResourceWorkPlanDefNQL_Class : TTReportNqlObject 
        {
        }

        public partial class GetMaxWorkdateForQueue_Class : TTReportNqlObject 
        {
        }

        protected override void PreInsert()
        {
#region PreInsert
            base.PreInsert();
            CheckUserSpeciality();
            

#endregion PreInsert
        }

        protected override void PostInsert()
        {
#region PostInsert
            base.PostInsert();
            
            WorkDate = ((DateTime)WorkDate).Date;
#endregion PostInsert
        }

        protected override void PreUpdate()
        {
#region PreUpdate
            base.PreUpdate();
            CheckUserSpeciality();

#endregion PreUpdate
        }

        protected override void PostUpdate()
        {
#region PostUpdate
            base.PostUpdate();
            
            WorkDate = ((DateTime)WorkDate).Date;
#endregion PostUpdate
        }

#region Methods
        protected void CheckUserSpeciality()
        {
            if(Common.CurrentUser.IsPowerUser == false && Common.CurrentUser.IsSuperUser == false)
            {
                QueueResourceWorkPlanDefinition queueResourceWorkPlanDef = null;
                if(((ITTObject)this).IsNew == true)
                    queueResourceWorkPlanDef = this;
                else
                    queueResourceWorkPlanDef =((ITTObject)this).Original as QueueResourceWorkPlanDefinition;
                if(queueResourceWorkPlanDef != null && queueResourceWorkPlanDef.Queue != null)
                {
                    ResSection resSection = (ResSection)queueResourceWorkPlanDef.Queue.ResSection;
                    if(resSection != null)
                    {
                        bool found = false;
                        foreach(UserResource userResource in Common.CurrentResource.UserResources)
                        {
                            foreach(ResourceSpecialityGrid speciality1 in userResource.Resource.ResourceSpecialities)
                            {
                                foreach(ResourceSpecialityGrid speciality2 in resSection.ResourceSpecialities)
                                {
                                    if(speciality1.Speciality.ObjectID == speciality2.Speciality.ObjectID)
                                    {
                                        found = true;
                                        break;
                                    }
                                }
                            }
                        }
                        if(!found)
                            throw new Exception(SystemMessage.GetMessage(591));
                    }
                }
            }
        }
        
        protected override void OnConstruct()
        {
            base.OnConstruct();
            ITTObject theObject = (ITTObject)this;
            if(theObject.IsNew)
            {
                if(IsActive == null)
                    IsActive = true;
                if(WorkDate == null)
                    WorkDate = Common.RecTime().Date;
               
            }
        }
        
        public void UpdateIsActiveOfResourcesOtherQueues()
        {
            if(IsActive == true)
            {
                IList queueResourceList = QueueResourceWorkPlanDefinition.GetTodaysQueueOfResource(ObjectContext, WorkDate.Value.Date, Resource.ObjectID);
                if (queueResourceList.Count > 1)
                {
                    foreach(QueueResourceWorkPlanDefinition queueResourceDef in queueResourceList)
                    {
                        if(queueResourceDef.ObjectID != ObjectID)
                        {
                            queueResourceDef.IsActive = false;
                        }
                    }
                }
            }
        }
        
#endregion Methods

    }
}