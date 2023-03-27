
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
    public  partial class AgeCondition : RuleConditionBase
    {
#region Methods
        public bool IsSuitable(ISUTPatient patient)
        {
            int age;
            switch ((int)AgeType)
            {
                case (int)AgeTypeEnum.Year:
                    if (patient.GetAge().HasValue == false && patient.GetAge() <= 0)
                        return false;
                    age = patient.GetAge().Value;
                    break;
                case (int)AgeTypeEnum.Month:
                    if (patient.GetAgeMonth().HasValue == false && patient.GetAgeMonth() <= 0)
                        return false;
                    age = patient.GetAgeMonth().Value;
                    break;
                case (int)AgeTypeEnum.Day:
                    if (patient.GetAgeDay().HasValue == false && patient.GetAgeDay() <= 0)
                        return false;
                    age = patient.GetAgeDay().Value;
                    break;
                default:
                    return false;
            }

            switch ((int)OperatorType)
            {
                case (int)OperatorTypeEnum.Equal:
                    return age <= LastValue.Value && age >= FirstValue.Value;
                case (int)OperatorTypeEnum.NotEqual:
                    return age > LastValue.Value && age < FirstValue.Value;
                default:
                    return false;
            }
        }
        
#endregion Methods

    }
}