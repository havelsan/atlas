
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
    public  partial class PeriodicOrderDetail : SubactionProcedureFlowable, IAppointmentWithoutResources
    {
#region Methods
        public virtual void ExecuteOrderDetail()
        {
            foreach(AppointmentWithoutResource appointmentWithoutResource in  AppointmentWithoutResources)
            {
                if(appointmentWithoutResource.CurrentStateDef.Status==StateStatusEnum.Uncompleted)
                {
                    appointmentWithoutResource.CurrentStateDefID=AppointmentWithoutResource.States.Completed;
                }
            }
            if(ExecutionDate==null)
            {
                ExecutionDate=Common.RecTime();
            }
        }
        public virtual void CancelOrderDetail()
        {
            //Bu kod SubactionProcedure ün cancel metoduna taşındı.
        }
        
#endregion Methods

    }
}