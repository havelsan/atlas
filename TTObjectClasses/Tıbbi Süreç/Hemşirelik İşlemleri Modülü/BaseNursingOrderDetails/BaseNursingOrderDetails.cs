
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
    /// <summary>
    /// Ana Hemşirelik Uygulamaları Sekmesi
    /// </summary>
    public  partial class BaseNursingOrderDetails : PeriodicOrderDetail
    {
        protected override void PostInsert()
        {
#region PostInsert
            
            base.PostInsert();

#endregion PostInsert
        }

        protected override void PostUpdate()
        {
#region PostUpdate
            
            base.PostUpdate();

#endregion PostUpdate
        }

        public void CreateMyVitalSign()
        {
            if (ProcedureObject != null && VitalSign == null)
            {
                if (((VitalSignAndNursingDefinition)ProcedureObject).VitalSignType != null)
                {
                    switch (((VitalSignAndNursingDefinition)ProcedureObject).VitalSignType)
                    {
                        case VitalSignType.BloodPressure:
                            {
                                new BloodPressure(this);
                                break;
                            }
                        case VitalSignType.Height:
                            {
                                new Height(this);
                                break;
                            }
                        case VitalSignType.Weight:
                            {
                                new Weight(this);
                                break;
                            }
                        case VitalSignType.Temperature:
                            {
                                new Temperature(this);
                                break;
                            }
                        case VitalSignType.Pulse:
                            {
                                new Pulse(this);
                                break;
                            }
                        case VitalSignType.Respiration:
                            {
                                new Respiration(this);
                                break;
                            }
                        case VitalSignType.SPO2:
                            {
                                new SPO2(this);
                                break;
                            }
                        case VitalSignType.ANT:
                            {
                                if (Result != null && !string.IsNullOrEmpty(Result))
                                    new Temperature(this);
                                if (Result_Pulse != null && !string.IsNullOrEmpty(Result_Pulse))
                                    new Pulse(this);
                                if (ResultBloodPressure != null && !string.IsNullOrEmpty(ResultBloodPressure))
                                    new BloodPressure(this);
                                if (Result_SPO2 != null && !string.IsNullOrEmpty(Result_SPO2))
                                    new SPO2(this);
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        }

        public override bool SendToENabiz(bool isNewInserted)
        {
            if (IsOldAction == true)
                return false;
            if (ProcedureObject != null && string.IsNullOrEmpty(ProcedureObject.SUTPriceCode()))
                return false;
            return isNewInserted;
        }

    }
}