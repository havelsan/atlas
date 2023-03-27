
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
    /// İçerisinde Episode Bulunduran Teşhis İlişkili Gruplar Nesnesi
    /// </summary>
    public  partial class TigEpisode : TTObject
    {
        public static void createNewTigObjectForTreatmentCure(SubEpisodeProtocol sep,TTObjectContext objectContext)
        {
            TigEpisode tigEpisode = new TigEpisode(objectContext);
            tigEpisode.InpatientDate = Common.RecTime();
            tigEpisode.AppointmentStatus = true;
            tigEpisode.BranchGuid = sep.Brans.ObjectID;
            tigEpisode.Cancelled = false;
            tigEpisode.CodingStatus = false;
            tigEpisode.DischargeDate = Common.RecTime();
            tigEpisode.DischargerDoctorGuid = sep.SubEpisode.StarterEpisodeAction.ProcedureDoctor.ObjectID;
            tigEpisode.DoctorGuid = sep.SubEpisode.StarterEpisodeAction.ProcedureDoctor.ObjectID;
            tigEpisode.EpicrisisStatus = false;
            tigEpisode.EpisodeGuid = sep.Episode.ObjectID;
            tigEpisode.InPatientProtocolNo = sep.SubEpisode.ProtocolNo;
            tigEpisode.InvoiceStatus = sep.InvoiceCollectionDetail != null ? true : false;
            BindingList<Pathology.GetPathologyStatesForTIG_Class> tests = Pathology.GetPathologyStatesForTIG(sep.Episode.ObjectID, null);
            if (tests.Count > 0)
            {
                tigEpisode.PathologyRequestStatus = true;
                tigEpisode.PathologyReportStatus = false;
                foreach (Pathology.GetPathologyStatesForTIG_Class pT in tests)
                {
                    if (pT.CurrentStateDefID == Pathology.States.Approvement || pT.CurrentStateDefID == Pathology.States.Report)
                    {
                        tigEpisode.PathologyReportStatus = true;
                        break;
                    }
                }
            }
            else
            {
                tigEpisode.PathologyRequestStatus = false;
                tigEpisode.PathologyReportStatus = false;
            }
            tigEpisode.PatientGuid = sep.Episode.Patient.ObjectID;
            tigEpisode.PatientType = TIGPatientTypeEnum.Outpatient;

            var firstInPatientTreatmentClinicApplication = sep.Episode.InPatientTreatmentClinicApplications.OrderBy(dr => dr.ClinicInpatientDate).FirstOrDefault(dr => dr.CurrentStateDef.Status != StateStatusEnum.Cancelled);
            if (firstInPatientTreatmentClinicApplication != null)
                tigEpisode.ResourceGuid = firstInPatientTreatmentClinicApplication.MasterResource.ObjectID;
            if (tigEpisode.ResourceGuid == null)
                tigEpisode.ResourceGuid = sep.SubEpisode.PatientAdmission.Policlinic.ObjectID;
            tigEpisode.SEPGuid = sep.ObjectID;
            //tigEpisode.Surgeries
            tigEpisode.XMLStatus = false;
            tigEpisode.IsCreatedByTreatmentCure = true;
        }
    }
}