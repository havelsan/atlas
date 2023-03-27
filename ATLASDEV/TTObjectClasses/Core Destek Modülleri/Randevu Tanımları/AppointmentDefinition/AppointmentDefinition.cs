
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
    public  partial class AppointmentDefinition : TTDefinitionSet
    {
        public partial class GetAppointmentDefinition_Class : TTReportNqlObject 
        {
        }

        public string AppointmentDefinitionNameDisplayText
        {
            get
            {
                try
                {
#region AppointmentDefinitionNameDisplayText_GetScript                    
                    return (string)(Common.GetEnumValueDefOfEnumValue(AppointmentDefinitionName).DisplayText);
#endregion AppointmentDefinitionNameDisplayText_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "AppointmentDefinitionNameDisplayText") + " : " + ex.Message, ex);
                }
            }
        }

        protected override void PreInsert()
        {
#region PreInsert
            base.PreInsert();
            if(Common.CurrentUser.AllRoles.ContainsKey(AppointmentDefinition.AppointmentDefinitionRoleID) != true)
                throw new Exception(SystemMessage.GetMessage(550));
            
            if(StateOnly == null)
                StateOnly = false;
            
            if(GiveToMaster == null)
                GiveToMaster = false;
            
            if(OverlapAllowed == null)
                OverlapAllowed = false;
            
            if(ScheduleOverlapAllowed == null)
                ScheduleOverlapAllowed = false;
            
            if(GiveFromResource == null)
                GiveFromResource = false;
            
            if(IsDescReqForNonScheduledApps == null)
                IsDescReqForNonScheduledApps = false;
            
            AppDefNameDisplayText = AppointmentDefinitionNameDisplayText;
#endregion PreInsert
        }

        protected override void PreUpdate()
        {
#region PreUpdate
            base.PreUpdate();
            
            if(!Common.CurrentUser.IsSuperUser){
                if(Common.CurrentUser.AllRoles.ContainsKey(AppointmentDefinition.AppointmentDefinitionRoleID) != true)
                    throw new Exception(SystemMessage.GetMessage(550));
            }
            if(StateOnly == null)
                StateOnly = false;
            
            if(GiveToMaster == null)
                GiveToMaster = false;
            
            if(OverlapAllowed == null)
                OverlapAllowed = false;
            
            if(ScheduleOverlapAllowed == null)
                ScheduleOverlapAllowed = false;
            
            if(GiveFromResource == null)
                GiveFromResource = false;
            
            if(IsDescReqForNonScheduledApps == null)
                IsDescReqForNonScheduledApps = false;
            
            AppDefNameDisplayText = AppointmentDefinitionNameDisplayText;
#endregion PreUpdate
        }

#region Methods
        public static Guid AppointmentDefinitionRoleID
        {
            //Randevu Tanımlama RoleID
            get {return new Guid("85e44379-4042-432d-83c0-a0407dcdaeb5");}
        }
        
#endregion Methods

    }
}