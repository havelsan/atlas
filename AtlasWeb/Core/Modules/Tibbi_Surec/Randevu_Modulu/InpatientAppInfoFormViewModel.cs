//$6149BA9A
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;

namespace Core.Controllers
{
    public partial class InpatientAppointmentServiceController
    {
        partial void PreScript_InpatientAppInfoForm(InpatientAppInfoFormViewModel viewModel, InpatientAppointment inpatientAppointment, TTObjectContext objectContext)
        {
            InPatientTreatmentClinicApplication episodeAction = inpatientAppointment.StarterInPatient;
            if (episodeAction == null)
            {
                Guid? selectedEpisodeActionObjectID = viewModel.GetSelectedEpisodeActionID();
                if (selectedEpisodeActionObjectID.HasValue)
                {
                    episodeAction = objectContext.GetObject<InPatientTreatmentClinicApplication>(selectedEpisodeActionObjectID.Value);
                    inpatientAppointment.StarterInPatient = episodeAction;
                }
            }
            inpatientAppointment.EntryUser = Common.CurrentResource;
            inpatientAppointment.EntryDate = Common.RecTime();

            if (((ITTObject)inpatientAppointment).IsNew)
            {
                inpatientAppointment.IsQueue = true;
            }

            if (inpatientAppointment.StarterInPatient != null)
            {
                var inPatientTreatmentClinicApplication = objectContext.GetObject<InPatientTreatmentClinicApplication>(inpatientAppointment.StarterInPatient.ObjectID);
                if (inPatientTreatmentClinicApplication.BaseInpatientAdmission.EstimatedInpatientDateCount != null)
                {
                    inpatientAppointment.InpatientDay = inPatientTreatmentClinicApplication.BaseInpatientAdmission.EstimatedInpatientDateCount;
                }

                //inpatientAppointment.MasterResource = inPatientTreatmentClinicApplication.MasterResource;
                //inpatientAppointment.ResponsibleDoctor = inPatientTreatmentClinicApplication.ProcedureDoctor;
                inpatientAppointment.Patient = inPatientTreatmentClinicApplication.Episode.Patient;
                inpatientAppointment.SubEpisode = inPatientTreatmentClinicApplication.SubEpisode;
            }
        }
        partial void PostScript_InpatientAppInfoForm(InpatientAppInfoFormViewModel viewModel, InpatientAppointment inpatientAppointment, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (inpatientAppointment.StarterInPatient != null)
            {
                inpatientAppointment.InpatientAcceptionType = GetTreatmentClinicAcceptionType(inpatientAppointment.StarterInPatient.ObjectID, inpatientAppointment.StarterInPatient.ObjectDef.ID);
            }
        }

        public InpatientAcceptionTypeEnum GetTreatmentClinicAcceptionType(Guid ObjectID, Guid ObjectDefID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                InPatientTreatmentClinicApplication _inPatientTreatmentClinicApplication = objectContext.GetObject(ObjectID, ObjectDefID) as InPatientTreatmentClinicApplication;
                if (_inPatientTreatmentClinicApplication.CurrentStateDefID != null && (_inPatientTreatmentClinicApplication.CurrentStateDefID == InPatientTreatmentClinicApplication.States.Acception || _inPatientTreatmentClinicApplication.CurrentStateDefID == InPatientTreatmentClinicApplication.States.PreAcception))//Klini�e yat�rmadan �nce yat�� iste�i yap�lan hasta yeni yat�� m�?/ transfer mi? bilgileri tutuluyor.
                {
                    if (_inPatientTreatmentClinicApplication.FromInPatientTrtmentClinicApp == null)//bir �nceki ba�lat�ld��� yat�� yoksa transfer de�il yeni yat��t�r.
                    {
                        if (_inPatientTreatmentClinicApplication.BaseInpatientAdmission.Emergency == true)
                        {
                            _inPatientTreatmentClinicApplication.InpatientAcceptionType = InpatientAcceptionTypeEnum.EmergencyInpatient;//Acilden yeni yat�r�lan hasta
                        }
                        else
                        {
                            _inPatientTreatmentClinicApplication.InpatientAcceptionType = InpatientAcceptionTypeEnum.NewInpatient;//Yeni yat�r�lan hasta
                        }

                    }
                    else
                    {
                        if (((ResClinic)_inPatientTreatmentClinicApplication.FromInPatientTrtmentClinicApp.MasterResource).IsIntensiveCare == true)//tedavi g�rece�i klinik yo�un bak�m ise
                        {
                            _inPatientTreatmentClinicApplication.InpatientAcceptionType = InpatientAcceptionTypeEnum.IntensiveCareTransfer;//Yeni yat�r�lan hasta
                        }
                        else
                        {
                            _inPatientTreatmentClinicApplication.InpatientAcceptionType = InpatientAcceptionTypeEnum.OtherClinicTransfer;//Yeni yat�r�lan hasta
                        }
                    }
                }
                else
                {
                    throw new Exception("Klinik Kabul a�amas�nda olmayan i�lemlere 'Yat�� Bekliyor' i�lemi yap�lamaz!");
                }
                _inPatientTreatmentClinicApplication.DescriptionForWorkList += " ";
                return _inPatientTreatmentClinicApplication.InpatientAcceptionType.Value;
            }
        }
    }
}

namespace Core.Models
{
    public partial class InpatientAppInfoFormViewModel : BaseViewModel
    {
    }
}
