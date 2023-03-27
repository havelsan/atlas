
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
    public partial class AppointmentDefinitionAttribute : TTAttributeInstance
    {
        public override void Run(AttributeWhenEnum when)
        {
#region Body
            try
            {
                if(Interface.GetMyNewAppointments().Count <=0)
                {
                    
                    RadiologyTest radiologyTest = Interface as RadiologyTest;
                    if(radiologyTest != null)
                    {
                        string injectionStr = "WHERE INITIALOBJECTID = '" + radiologyTest.ObjectID + "'";
                        IList appList = Appointment.GetByInjection(_objectContext, injectionStr);
                        if(appList.Count > 0)
                            return;
                    }
                    NuclearMedicine nuclearMedicine = Interface as NuclearMedicine;
                    if(nuclearMedicine != null)
                    {
                        string injectionStr = "WHERE INITIALOBJECTID = '" + nuclearMedicine.ObjectID + "'";
                        IList appList = Appointment.GetByInjection(_objectContext, injectionStr);
                        if(appList.Count > 0)
                            return;
                    }
                     throw new Exception(SystemMessage.GetMessage(516));
                }
            }
            catch
            {
                throw;
            }
#endregion Body
        }

        public override void Check(TTAttribute attribute)
        {
#region CheckBody
        
#endregion CheckBody
        }
    }
}