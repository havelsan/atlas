
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
    /// Acil Hemşirelik Hizmetleri
    /// </summary>
    public  partial class EmergencyInterventionNursingDetail : EpisodeActionWithDiagnosis, IWorkListEpisodeAction
    {
#region Methods
        public override BaseAdditionalApplication CreateBaseAdditionalApplication()
            {
                return new EmergencyInterventionAdditionalApplication(ObjectContext);
            }


        public EmergencyInterventionNursingDetail(EmergencyIntervention emergencyIntervention) : this(emergencyIntervention.ObjectContext)
        {
            SetMandatoryEpisodeActionProperties((EpisodeAction)emergencyIntervention, emergencyIntervention.MasterResource, emergencyIntervention.MasterResource, true);
            EmergencyIntervention = emergencyIntervention;
            CurrentStateDefID = EmergencyInterventionNursingDetail.States.New;
        }


        #endregion Methods

    }
}