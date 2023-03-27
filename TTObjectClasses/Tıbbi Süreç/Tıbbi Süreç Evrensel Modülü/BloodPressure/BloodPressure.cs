
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
    public  partial class BloodPressure : VitalSign
    {

        public BloodPressure(BaseNursingOrderDetails baseNursingOrderDetails) : this(baseNursingOrderDetails.ObjectContext)
        {
            if (baseNursingOrderDetails.Result != null || (baseNursingOrderDetails.ResultBloodPressure != null && baseNursingOrderDetails.ResultBloodPressure != " -"))//order iptal et dediğimizde de buraya geliyor
            {
                string[] _array = null;

                if (((TTObjectClasses.VitalSignAndNursingDefinition)baseNursingOrderDetails.ProcedureObject).VitalSignType == VitalSignType.ANT)
                    _array = baseNursingOrderDetails.ResultBloodPressure.Split('-');
                else
                    _array = baseNursingOrderDetails.Result.Split('-');

                Diastolik = Convert.ToInt32(_array[1].Replace(" ", "").Replace(".", ""));
                Sistolik = Convert.ToInt32(_array[0].Replace(" ", "").Replace(".", ""));
            }
            SetDefaultVitalSignProperties(baseNursingOrderDetails);
        }
        override public string GetResult()
        {
            return (Sistolik == null ? string.Empty : Sistolik.ToString()) + "-" + (Diastolik == null ? string.Empty : Diastolik.ToString());
        }
    }
}