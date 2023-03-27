
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
    public partial class CheckTreatmentMaterialIsEmptyAttribute : TTAttributeInstance
    {
        public override void Run(AttributeWhenEnum when)
        {
#region Body
            PatientExamination patientExamination = Interface as PatientExamination;
            if (Interface.GetTreatmentMaterials().Count == 0)
                if (patientExamination != null && patientExamination.Episode != null && patientExamination.SubEpisode.PatientAdmission != null && patientExamination.SubEpisode.PatientAdmission.AdmissionType != null)
                {
                    //if (1==0)
                    //{
                    //    if(Interface.IsTreatmentMaterialEmpty != true && !(patientExamination is HealthCommitteeExamination) && patientExamination.SubEpisode.PatientAdmission.AdmissionStatus == AdmissionStatusEnum.Acil)
                    //        throw new Exception(SystemMessage.GetMessage(515));
                    //}

                }
                else
                {
                    if (Interface.GetIsTreatmentMaterialEmpty() != true)
                        throw new Exception(SystemMessage.GetMessage(515));
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