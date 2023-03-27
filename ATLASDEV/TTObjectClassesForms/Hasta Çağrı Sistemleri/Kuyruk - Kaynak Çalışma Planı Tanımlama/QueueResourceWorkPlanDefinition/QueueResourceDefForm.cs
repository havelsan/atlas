
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

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    public partial class QueueResourceDefForm : TTDefinitionForm
    {
        override protected void BindControlEvents()
        {
            Resource.SelectedObjectChanged += new TTControlEventDelegate(Resource_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            Resource.SelectedObjectChanged -= new TTControlEventDelegate(Resource_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void Resource_SelectedObjectChanged()
        {
#region QueueResourceDefForm_Resource_SelectedObjectChanged
   SetQueueListFilterExpression();
#endregion QueueResourceDefForm_Resource_SelectedObjectChanged
        }

        protected override void PreScript()
        {
#region QueueResourceDefForm_PreScript
    base.PreScript();
            SetQueueListFilterExpression();
#endregion QueueResourceDefForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region QueueResourceDefForm_PostScript
    base.PostScript(transDef);
            this._QueueResourceWorkPlanDefinition.UpdateIsActiveOfResourcesOtherQueues();
#endregion QueueResourceDefForm_PostScript

            }
            
#region QueueResourceDefForm_Methods
        protected void SetQueueListFilterExpression()
        {
            //this._QueueResourceWorkPlanDefinition.Queue = null;
            if(this._QueueResourceWorkPlanDefinition.Resource != null && this._QueueResourceWorkPlanDefinition.Resource is ResUser)
            {
                ResUser user = (ResUser)this._QueueResourceWorkPlanDefinition.Resource;
                string filterExpression = String.Empty;
                string objectIDs = String.Empty;
                foreach(UserResource userResource in user.UserResources)
                {
                    if(userResource.Resource != null)
                    {
                        ResSection resSection = (ResSection)userResource.Resource;
                        foreach(ExaminationQueueDefinition queueDef in resSection.ExaminationQueueDefinitions)
                        {
                            if(objectIDs.Length > 0)
                                objectIDs += ",";
                            objectIDs += "'" + queueDef.ObjectID.ToString() + "'";
                        }
                    }
                }
                if(objectIDs.Length > 0)                    
                    this.Queue.ListFilterExpression = " OBJECTID IN (" + objectIDs + ")";
                else
                    this.Queue.ListFilterExpression = " 1=0";
            }
            else
                this.Queue.ListFilterExpression = null;
        }
        
#endregion QueueResourceDefForm_Methods
    }
}