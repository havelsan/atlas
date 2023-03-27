
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
    public partial class BaseDrugOrder : SubActionMaterial
    {
        public partial class GetDrugPrescriptionTotalReportQuery_Class : TTReportNqlObject
        {

        }

        protected override void PreInsert()
        {
            #region PreInsert
            base.PreInsert();
            if (Frequency.HasValue == false && HospitalTimeSchedule != null)
            {
                SetFrequencyByHospitalTimeSchedule(HospitalTimeSchedule);
            }
            #endregion PreInsert
        }

        private void SetFrequencyByHospitalTimeSchedule(HospitalTimeSchedule timeSchedule)
        {
            switch (timeSchedule.Frequency)
            {
                case RefactoredFrequencyEnum.Q1H:
                    Frequency = FrequencyEnum.Q1H;
                    break;
                case RefactoredFrequencyEnum.Q2H:
                    Frequency = FrequencyEnum.Q2H;
                    break;
                case RefactoredFrequencyEnum.Q3H:
                    Frequency = FrequencyEnum.Q3H;
                    break;
                case RefactoredFrequencyEnum.Q4H:
                    Frequency = FrequencyEnum.Q4H;
                    break;
                case RefactoredFrequencyEnum.Q6H:
                    Frequency = FrequencyEnum.Q6H;
                    break;
                case RefactoredFrequencyEnum.Q8H:
                    Frequency = FrequencyEnum.Q8H;
                    break;
                case RefactoredFrequencyEnum.Q12H:
                    Frequency = FrequencyEnum.Q12H;
                    break;
                case RefactoredFrequencyEnum.Q24H:
                    Frequency = FrequencyEnum.Q24H;
                    break;
                default:
                    break;
            }
        }

    }
}