﻿
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
    public  partial class Pulse : VitalSign
    {
        public Pulse(BaseNursingOrderDetails baseNursingOrderDetails) : this(baseNursingOrderDetails.ObjectContext)
        {
            if (baseNursingOrderDetails.Result_Pulse != null && !string.IsNullOrEmpty(baseNursingOrderDetails.Result_Pulse)) 
                Value = Convert.ToInt32(baseNursingOrderDetails.Result_Pulse);
            else if (baseNursingOrderDetails.Result != null && !string.IsNullOrEmpty(baseNursingOrderDetails.Result))
                Value = Convert.ToInt32(baseNursingOrderDetails.Result);

            SetDefaultVitalSignProperties(baseNursingOrderDetails);

        }
        override public string GetResult()
        {
            return Value == null ? string.Empty : Value.ToString();
        }

       
    }
}