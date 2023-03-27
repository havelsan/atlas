
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
    public  partial class RTFTemplate : BaseTemplate
    {
        public partial class GetRTFTemplateDefinition_Class : TTReportNqlObject 
        {
        }

        protected override void PreUpdate()
        {
#region PreUpdate
            base.PreUpdate();
            
            //TODO: Server-Client calismasindan dolayi commentlendi. 
            //NoChangeOtherUsersTeamplate methodu RTFTemplateForm un clientmethods larina tasindi. Object pre-update ve pre-delete den cagrilmasina bakilacak.
            
            //TTFormClasses.RTFTemplateForm.NoChangeOtherUsersTeamplate(this.ObjectID, false);

#endregion PreUpdate
        }

        protected override void PreDelete()
        {
#region PreDelete
            base.PreDelete();
            
            //TODO: Server-Client calismasindan dolayi commentlendi.
            //NoChangeOtherUsersTeamplate methodu RTFTemplateForm un clientmethods larina tasindi. Object pre-update ve pre-delete den cagrilmasina bakilacak.

            //TTFormClasses.RTFTemplateForm.NoChangeOtherUsersTeamplate(this.ObjectID, true);

#endregion PreDelete
        }

    }
}