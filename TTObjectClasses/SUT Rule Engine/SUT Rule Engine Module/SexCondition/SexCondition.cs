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
    public  partial class SexCondition : RuleConditionBase
    {
#region Methods
        public bool IsSuitable(ISUTPatient patient)
        {
            if (patient.GetSex() == null)
                return false;
            //todo bg
            SKRSCinsiyet sex = patient.GetSex();
            switch ((int)OperatorType)
            {
                case (int)OperatorTypeEnum.Equal:
                    return true;
                case (int)OperatorTypeEnum.NotEqual:
                    return false;
                default:
                    return false;
            }
        }
        
#endregion Methods

    }
}