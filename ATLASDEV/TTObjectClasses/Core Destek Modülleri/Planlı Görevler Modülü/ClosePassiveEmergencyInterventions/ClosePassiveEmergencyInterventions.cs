
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
    public partial class ClosePassiveEmergencyInterventions : BaseScheduledTask
    {
        #region Methods
        public override void TaskScript()
        {

            int counter = 0;
            TTObjectContext context = new TTObjectContext(false);
            DateTime startDate = ((DateTime)TTObjectClasses.Common.RecTime()).Date.AddDays(-7);
            DateTime endDate = ((DateTime)TTObjectClasses.Common.RecTime()).Date.AddDays(-2);
            IBindingList EIs = EmergencyIntervention.GetEmergencyInterventionsByDate(context, startDate, endDate);
            bool hasInpatientApplication = false;

            foreach (EmergencyIntervention ei in EIs)
            {
                try
                {
                    if (ei.Episode.InpatientAdmissions.Count > 0 || ei.CurrentStateDef.Status == StateStatusEnum.CompletedSuccessfully || ei.Episode.Diagnosis.Count > 0)
                        continue;

                    counter++;
                    ei.Episode.CurrentStateDefID = Episode.States.ClosedToNew;
                    if (ei.CurrentStateDefID == EmergencyIntervention.States.Triage)
                        ei.CurrentStateDefID = EmergencyIntervention.States.Missing;

                    //if (ei.Episode.IsMedulaEpisode())  kontrolü vardı kaldırıldı (MDZ)
                    ei.SubEpisode.CancelSubEpisodeProtocols();

                    context.Save();
                }
                catch (Exception ex)
                {
                    AddLog(ex.Message);
                }
            }
            AddLog(counter.ToString() + " adet epizot kapatıldı");
        }

        #endregion Methods

    }
}