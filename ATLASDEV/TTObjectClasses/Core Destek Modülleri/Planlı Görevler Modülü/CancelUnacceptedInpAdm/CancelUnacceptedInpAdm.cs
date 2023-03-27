
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
    public  partial class CancelUnacceptedInpAdm : BaseScheduledTask
    {
#region Methods
        public override void TaskScript()
        {
            TTObjectContext context = new TTObjectContext(false);
            try
            {
                double LimitHour = Convert.ToDouble(TTObjectClasses.SystemParameter.GetParameterValue("UNACCEPTEDINPATIENTADMISSIONLIMIT","2"));
                LimitHour = (-1*LimitHour);
                DateTime LimitRequestDate = Convert.ToDateTime(Common.RecTime()).AddHours(LimitHour);
                IList list = InpatientAdmission.GetUnacceptedInLimitedTime(context,LimitRequestDate);
                foreach (InpatientAdmission inpatientAdmission in list)
                {
                    if (inpatientAdmission.InPatientTreatmentClinicApplications.Count<1)
                    {
                        inpatientAdmission.ReasonOfCancel = (-1 * LimitHour) + " saat içinde kabulü yapılmadığı için.İptal tarihi "  +  Common.RecTime().ToString();
                        ((ITTObject)inpatientAdmission).Cancel();
                        
                    }
                }
                context.Save();
            }
            catch (Exception ex)
            {
                AddLog(ex.Message);
                context.Dispose();
            }
        }
        
#endregion Methods

    }
}